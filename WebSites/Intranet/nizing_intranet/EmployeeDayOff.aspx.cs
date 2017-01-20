using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeDayOff : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            SqlSearch(GetQuery());
        }
    }
    private string GetQuery()
    {
        //使用PALTK員工出勤資料 及 CMSMV員工資料
        string query = "SELECT TK001 員工代號, MV002 員工姓名, TK002 年度, TK003 特休天數, TK004 已休天數, TK003-TK004 未休天數"
                    + " FROM PALTK"
                    + " LEFT JOIN CMSMV ON TK001 = MV001"
                    + " WHERE TK001 = " + ddlPerson.SelectedValue.ToString() + "AND TK002 = " + DateTime.Now.Year.ToString();

        return query;
    }
    private void SqlSearch(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdResult.DataSource = ds;
            grdResult.DataBind();
        }
    }
}