using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class employee_section_report_GoOutReport : System.Web.UI.Page
{
    string SunrizeConnectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;
    string NzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = DateTime.Now.Year; i > 2018; i--)
            {
                ddlParameterYear.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                ddlParameterMonth.Items.Add(i.ToString("D2"));
            }
            ddlParameterYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlParameterMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
            DataTable dt = new DataTable();
            dt = GetGoOutFormData(new DateTime(Convert.ToInt32(ddlParameterYear.SelectedValue), Convert.ToInt32(ddlParameterMonth.SelectedValue), 1));
            BindGridView(gvGoOutData, dt);
        }
    }

    private DataTable GetGoOutFormData(DateTime date)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();

            string query = "select form.*" +
                " ,Convert(nvarchar(3),DATEDIFF(MINUTE,form.ActualStartTime,form.ActualEndTime)/60)+':'+RIGHT('0'+Convert(nvarchar(2),DATEDIFF(MINUTE,form.ActualStartTime,form.ActualEndTime)%60),2) 'Timespan'" +
                " ,code.Name 'FormStatus' " +
                " ,coalesce(nzMV.MV002, szMV.MV002) 'UserName'" +
                " from GoOutForm form" +
                " left join GoOutForm_StatusCode code on form.[Status] = code.Code" +
                " left join NZ.dbo.CMSMV nzMV on form.UserId = nzMV.MV001 and form.UserCompany = 'NIZING'" +
                " left join SUNRIZE.dbo.CMSMV szMV on form.UserId = szMV.MV001 and form.UserCompany = 'SUNRIZE'" +
                " where form.ActualStartTime>=@bom" +
                " and form.ActualStartTime<=@eom" +
                " order by form.ActualStartTime desc" +
                " ,form.EstimateStartTime" +
                " ,form.[Status] desc";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@bom", new DateTime(date.Year, date.Month, 1));
            cmd.Parameters.AddWithValue("@eom", new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }


        return dt;
    }

    private void BindGridView(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnSearchGoOutData_Click(object sender, EventArgs e)
    {
        DataTable dt = GetGoOutFormData(new DateTime(Convert.ToInt32(ddlParameterYear.SelectedValue), Convert.ToInt32(ddlParameterMonth.SelectedValue), 1));
        BindGridView(gvGoOutData, dt);
    }
}