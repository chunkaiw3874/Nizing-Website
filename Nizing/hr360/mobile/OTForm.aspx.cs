using System;
using System.Collections.Generic;
using System.Configuration;
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
    private void ShowModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('show');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

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

        if(errorCount > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
            ShowModal("ApplicationForm");
        }
        else
        {
            message += "加班單已成功送出";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
        }
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
}