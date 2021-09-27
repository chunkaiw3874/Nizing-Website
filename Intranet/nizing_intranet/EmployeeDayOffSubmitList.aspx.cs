using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_EmployeeDayOffSubmitList : System.Web.UI.Page
{
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Attributes.Add("readonly", "readonly");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {

            conn.Open();
            string query = "select app.APPLICANT_ID [員工ID]" +
                " , mv.MV002 [員工名稱]" +
                " ,app.DAYOFF_START_TIME [請假開始時間]" +
                " ,app.DAYOFF_END_TIME [請假結束時間]" +
                " ,sta.NAME [請假單狀態]" +
                " from HR360_DAYOFFAPPLICATION_APPLICATION app" +
                " left join HR360_DAYOFFAPPLICATION_APPLICATION_STATUS sta on app.APPLICATION_STATUS_ID = sta.ID" +
                " left join NZ.dbo.CMSMV mv on app.APPLICANT_ID = mv.MV001" +
                " where app.DAYOFF_START_TIME like @Date" +
                " and app.APPLICATION_STATUS_ID <> '98'" +
                " and app.APPLICATION_STATUS_ID <> '99'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Date", txtDate.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        gvResult.DataSource = dt;
        gvResult.DataBind();
    }
}