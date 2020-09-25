using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sunrise_employee_section_report_SD03_OrderInProgress : System.Web.UI.Page
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

            string query = "select TC.TC039 '單據日期'" +
                " ,TD.TD013 '預交日期'" +
                " ,TC.TC004 '客戶代號'" +
                " ,MA.MA002 '客戶名稱'" +
                " ,COALESCE(MV.MV002,'') '業務名稱'" +
                " ,TD.TD004 '品號'" +
                " ,TD.TD005 '品名'" +
                " ,TD.TD006 '規格'" +
                " ,CONVERT(DECIMAL(20,2),TD.TD011) '單價'" +
                " ,CONVERT(DECIMAL(20,0),TD.TD008) '數量'" +
                " ,CONVERT(DECIMAL(20,2),TD.TD012*TC.TC009) '金額'" +
                " ,TC.TC008 '幣別'" +
                " ,CONVERT(DECIMAL(20,0),TD.TD008-TD.TD009) '未交量'" +
                " ,CONVERT(DECIMAL(20,0),MB.MB064) '庫存數量'" +
                //" ,TD.TD007 '庫別'" +
                " ,MC.MC003 '儲位'" +
                " ,TD.TD020 '備註'" +
                " from COPTC TC" +
                " LEFT JOIN COPTD TD ON TC.TC001 = TD.TD001 AND TC.TC002 = TD.TD002" +
                " LEFT JOIN COPMA MA ON TC.TC004 = MA.MA001" +
                " LEFT JOIN INVMB MB ON TD.TD004 = MB.MB001" +
                " LEFT JOIN CMSMV MV ON TC.TC006 = MV.MV001" +
                " LEFT JOIN INVMC MC ON MB.MB001 = MC.MC001 AND MC.MC002='NZ-3F'" +
                " where TD.TD016='N'" +
                GetQueryCondition() +
                " order by TD.TD013,TC.TC004";

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

    protected void gvReport_PreRender(object sender, EventArgs e)
    {
        decimal totalSum = 0;
        decimal undeliveredSum = 0;
        decimal amountOrdered = 0;
        foreach(GridViewRow row in gvReport.Rows)
        {
            totalSum += Convert.ToDecimal(((Label)row.FindControl("lblTotalPrice")).Text);
            undeliveredSum += Convert.ToDecimal(((Label)row.FindControl("lblItemUndelivered")).Text);
            amountOrdered += Convert.ToDecimal(((Label)row.FindControl("lblItemUndelivered")).Text);
        }

        gvReport.FooterRow.Cells[6].Text = "小記";
        gvReport.FooterRow.Cells[7].Text = amountOrdered.ToString("0");
        gvReport.FooterRow.Cells[8].Text = totalSum.ToString("0.00");
        gvReport.FooterRow.Cells[9].Text = undeliveredSum.ToString("0");
    }
}