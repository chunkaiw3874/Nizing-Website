using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_mobile_OTForm : System.Web.UI.Page
{
    string NzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitApplicationForm();            
        }

        if (HR360LoggedUser.Dept != "B-PC"
            && HR360LoggedUser.Dept != "A-ADM")
        {
            btnOTAppointment.Visible = false;
        }
    }

    protected void btnOTApplication_Click(object sender, EventArgs e)
    {
        lblApplicationFormTitle.Text = "加班申請單";
        ShowModal("ApplicationForm");
    }

    protected void btnAddOTApplication_Click(object sender, EventArgs e)
    {
        Regex rgx = new Regex(@"^[0-8](.[05])?$");
        int errorCount = 0;
        string message = "";
        string uid = GetApplicationFormUID();

        message = uid + "\\n";
        //Error Check
        if (string.IsNullOrWhiteSpace(txtApplicationOTDate.Text))
        {
            message += "日期不可空白\\n";
            errorCount++;
        }

        if (!rgx.IsMatch(txtApplicationOTTimespan.Text.Trim()))
        {
            message += "加班時間" + txtApplicationOTTimespan.Text.Trim() + "格式不符(最小單位為0.5小時)\\n";
            errorCount++;
        }

        //Process after error check
        if (errorCount > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
            ShowModal("ApplicationForm");
        }
        else
        {
            //send out application
            try
            {
                InsertApplicationFormData(uid);
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627) //ID 重複錯誤
                {
                    uid = GetApplicationFormUID();
                    InsertApplicationFormData(uid);
                }
            }
            
            //register trail
            //check for application approval necessity
            //register trail if SYSTEM approval is activated
            message += "加班單已成功送出";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
        }
    }

    protected void InsertApplicationFormData(string formId)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "insert into OvertimeApplicationForm" +
                " values (@creator,@createTime,@modifier,@modifiedTime,@formId,@applicationDate,@overtimeAssignerId,@overtimeEmployeeId" +
                " ,@overtimeDepartment,@overtimeBeginTime,@overtimeElapseTime,@overtimeReason,@compensationMethodId,@statusId)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@creator", HR360LoggedUser.ERPId);
            cmd.Parameters.AddWithValue("@createTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@modifier", HR360LoggedUser.ERPId);
            cmd.Parameters.AddWithValue("@modifiedTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@formId", formId);
            cmd.Parameters.AddWithValue("@applicationDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@overtimeAssignerId", ddlOTAssigner.SelectedValue);
            cmd.Parameters.AddWithValue("@overtimeEmployeeId", HR360LoggedUser.ERPId);
            cmd.Parameters.AddWithValue("@overtimeDepartment", ddlApplicationOTDepartment.SelectedValue);
            cmd.Parameters.AddWithValue("@overtimeBeginTime", DateTime.Parse(txtApplicationOTDate.Text));
            cmd.Parameters.AddWithValue("@overtimeElapseTime", decimal.Parse(txtApplicationOTTimespan.Text));
            cmd.Parameters.AddWithValue("@overtimeReason", txtApplicationOTReason.Text.Trim());
            cmd.Parameters.AddWithValue("@compensationMethodId", ddlCompensationMethod.SelectedValue);
            cmd.Parameters.AddWithValue("@statusId", "02");

            cmd.ExecuteNonQuery();
        }
    }

    protected void UpdateApplicationFormStatus(string formId)
    {

    }

    protected string GetApplicationFormUID()
    {
        string uid;
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            string defaultUid = DateTime.Parse(txtApplicationOTDate.Text).ToString("yyyyMMdd") + "001";
            conn.Open();
            string query = "select max(FormId)" +
                " from OvertimeApplicationForm" +
                " where FormId like @otDate" +
                " and FormId >= @uid ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@otDate", defaultUid.Substring(0, 7) + "%");
            cmd.Parameters.AddWithValue("@uid", defaultUid);
            uid = cmd.ExecuteScalar() == DBNull.Value ? defaultUid : (Convert.ToInt64(cmd.ExecuteScalar().ToString()) + 1).ToString();
        }
        return uid;
    }

    protected void InitApplicationForm()
    {
        //load department
        using (SqlConnection conn = new SqlConnection(NzConnectionString))
        {
            conn.Open();
            string query = "select ME.ME001+' '+ME.ME002 'text'" +
                " , ME.ME001 'value'" +
                " from CMSME ME" +
                " where ME.ME001 <> 'A.PSD'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlApplicationOTDepartment.Items.Add(new ListItem(dt.Rows[i]["text"].ToString().Trim(), dt.Rows[i]["value"].ToString().Trim()));
            }

            ddlApplicationOTDepartment.SelectedValue = HR360LoggedUser.Dept;
        }

        //load 派工人員，preset to self
        using (SqlConnection conn = new SqlConnection(NzConnectionString))
        {
            conn.Open();
            string query = "select MV.MV001+' '+MV.MV002 'text'" +
                " , MV.MV001 'value'" +
                " from CMSMV MV" +
                " where MV.MV022 = ''" +
                " and MV.MV001 <> '0000'" +
                " and MV.MV001 <> '0098'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlOTAssigner.Items.Add(new ListItem(dt.Rows[i]["text"].ToString().Trim(), dt.Rows[i]["value"].ToString().Trim()));
            }

            ddlOTAssigner.SelectedValue = HR360LoggedUser.ERPId;
        }

        //load compensation method
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select [Id]" +
                " ,[Name]" +
                " from OvertimeCompensationMethod";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlCompensationMethod.Items.Add(new ListItem(dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Id"].ToString()));
            }

            ddlCompensationMethod.SelectedIndex = 0;
        }
    }

    private void ShowModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('show');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }
}