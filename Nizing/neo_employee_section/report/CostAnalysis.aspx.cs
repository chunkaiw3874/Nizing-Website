using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class neo_employee_section_report_CostAnalysis : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NEOConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtProductBOMList = GetBOMList();
        DataTable dt = dtProductBOMList.DefaultView.ToTable(true, new string[] { "製令單號" });
        gvBOMList.DataSource = dt;
        gvBOMList.DataBind();
    }

    private DataTable GetBOMList()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT TA.TA006 '產品品號',PRODUCT_INFO.MB002 '產品品名'"
                        + " ,TB.TB002 '製令單號', TB.TB003 '材料品號', MATERIAL_INFO.MB002 '材料品名'"
                        + " FROM MOCTA TA"
                        + " LEFT JOIN INVMB PRODUCT_INFO ON TA.TA006=PRODUCT_INFO.MB001"
                        + " LEFT JOIN MOCTB TB ON TA.TA001=TB.TB001 AND TA.TA002=TB.TB002"
                        + " LEFT JOIN INVMB MATERIAL_INFO ON TB.TB003=MATERIAL_INFO.MB001"
                        + " WHERE TA.TA006=@PRODUCT"
                        + " ORDER BY MATERIAL_INFO.MB002";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PRODUCT", txtPrdId.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }
}