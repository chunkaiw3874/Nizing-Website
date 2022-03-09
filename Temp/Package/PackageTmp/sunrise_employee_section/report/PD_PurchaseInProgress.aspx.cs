using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sunrise_employee_section_report_PD_PurchaseInProgress : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = GetCategoryOne();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlCategoryOne.Items.Add(new ListItem(dt.Rows[i]["CategoryName"].ToString(), dt.Rows[i]["CategoryCode"].ToString()));
            }

            ddlCategoryOne.Items.Insert(0, new ListItem("全部產品", "0"));
            ddlCategoryOne.SelectedIndex = 0;
            dt = GetQueryTable();
            DisplayQueryTable(dt);
        }
    }

    private DataTable GetCategoryOne()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "select MA002 'CategoryCode'" +
                " , MA003 'CategoryName'" +
                " from INVMA MA" +
                " where MA.MA001 = '1'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private DataTable GetQueryTable()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string query = "select TC.TC024 '單據日期'" +
                " ,TD.TD012 '預交日期'" +
                " ,TC.TC004 '廠商代號'" +
                " ,MA.MA002 '廠商名稱'" +
                " ,COALESCE(MV.MV002,'') '採購人員'" +
                " ,TD.TD004 '品號'" +
                " ,TD.TD005 '品名'" +
                " ,TD.TD006 '規格'" +
                " ,CONVERT(DECIMAL(20,2),TD.TD010) '單價'" +
                " ,CONVERT(DECIMAL(20,0),TD.TD008) '採購數量'" +
                " ,CONVERT(DECIMAL(20,2),TD.TD011) '金額'" +
                " ,TC.TC005 '幣別'" +
                " ,CONVERT(DECIMAL(20,0),TD.TD008-TD.TD015) '未交量'" +
                " ,CONVERT(DECIMAL(20,0),MB.MB064) '庫存數量'" +
                " ,TD.TD007 '庫別'" +
                " ,TD.TD014 '備註'" +
                " from PURTC TC" +
                " LEFT JOIN PURTD TD ON TC.TC001 = TD.TD001 AND TC.TC002 = TD.TD002" +
                " LEFT JOIN PURMA MA ON TC.TC004 = MA.MA001" +
                " LEFT JOIN INVMB MB ON TD.TD004 = MB.MB001" +
                " LEFT JOIN CMSMV MV ON TC.TC011 = MV.MV001" +
                " where TD.TD016='N'" +
                GetQueryCondition() +
                " order by TD.TD012,TC.TC004";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@category", ddlCategoryOne.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private string GetQueryCondition()
    {
        string s = "";
        if(ddlCategoryOne.SelectedValue != "0")
        {
            s = " and MB.MB005=@category";
        }
        return s;
    }

    private void DisplayQueryTable(DataTable dt)
    {
        gvReport.DataSource = dt;
        gvReport.DataBind();
    }

    protected void ddlCategoryOne_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btnSubmit.Text = ddlCategoryOne.SelectedValue;
        DataTable dt = new DataTable();
        dt = GetQueryTable();
        DisplayQueryTable(dt);
    }
}