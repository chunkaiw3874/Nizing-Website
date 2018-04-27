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
using System.Threading;
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
        if (dtProductBOMList.Rows.Count > 0)
        {
            lblProductName.Text = dtProductBOMList.Rows[0]["產品品名"].ToString();
            DataTable dt = dtProductBOMList.DefaultView.ToTable(true, new string[] { "製令單號" });
            gvBOMList.DataSource = dt;
            gvBOMList.DataBind();
        }
    }

    private DataTable GetBOMList()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT TA.TA006 '產品品號',PRODUCT_INFO.MB002 '產品品名',TA.TA015 '預計產量',TA.TA007 '單位'"
                        + " ,TB.TB002 '製令單號', TB.TB003 '材料品號', MATERIAL_INFO.MB002 '材料品名'"
                        + " FROM MOCTA TA"
                        + " LEFT JOIN INVMB PRODUCT_INFO ON TA.TA006=PRODUCT_INFO.MB001"
                        + " LEFT JOIN MOCTB TB ON TA.TA001=TB.TB001 AND TA.TA002=TB.TB002"
                        + " LEFT JOIN INVMB MATERIAL_INFO ON TB.TB003=MATERIAL_INFO.MB001"
                        + " WHERE TA.TA006=@PRODUCT";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PRODUCT", txtPrdId.Text.Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }
    protected void lbBOMID_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = (GridViewRow)(((LinkButton)sender).NamingContainer);
        LinkButton lb = (LinkButton)clickedRow.FindControl("lbBOMID");
        DataTable dtMaterialList = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT TA.TA002 '製令單號',TA.TA015 '預計產量',TA.TA007 '單位'"
                        + " , TB.TB003 '材料品號', MATERIAL_INFO.MB002 '材料品名', TB.TB005 '數量'"
                        + " FROM MOCTA TA"
                        + " LEFT JOIN MOCTB TB ON TA.TA001=TB.TB001 AND TA.TA002=TB.TB002"
                        + " LEFT JOIN INVMB MATERIAL_INFO ON TB.TB003=MATERIAL_INFO.MB001"
                        + " WHERE TA.TA002=@BOMID"; ;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BOMID", lb.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtMaterialList);
        }
        
        if (dtMaterialList.Rows.Count > 0)
        {
            lblProductionAmount.Text = "預計產量: " + dtMaterialList.Rows[0]["預計產量"].ToString() + dtMaterialList.Rows[0]["單位"].ToString();
            //FIND AVERAGE COST OF MATERIAL
            dtMaterialList.Columns.Add("成本");
            dtMaterialList.Columns.Add("小記");
            foreach (DataRow row in dtMaterialList.Rows)
            {
                DataTable dtMaterialPurchaseInfo = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TC.TC002 '採購單號', TC.TC005 '採購幣別', TC.TC006 '匯率'"
                                + " , TD.TD004 '品號', TD.TD005 '品名', TD.TD010*TC.TC006 '單價'"
                                + " ,TD.TD010*TC.TC006*TD.TD008 '總價', TD.TD008 '數量'"
                                + " FROM PURTC TC"
                                + " LEFT JOIN PURTD TD ON TC.TC001=TD.TD001 AND TC.TC002=TD.TD002"
                                + " WHERE TD.TD004=@PRODID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PRODID", row["材料品號"].ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtMaterialPurchaseInfo);
                }
                row["成本"] = (Convert.ToDecimal(dtMaterialPurchaseInfo.Compute("sum(總價)/sum(數量)", ""))).ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
                decimal cost;
                decimal.TryParse(row["成本"].ToString(), NumberStyles.Currency, null, out cost);
                row["小記"] = (cost * Convert.ToDecimal(row["數量"].ToString())).ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
            }
            
        }
        gvMaterialList.DataSource = dtMaterialList;
        gvMaterialList.DataBind();
        lblAvgCost.Text = "平均單價: " + (decimal.Parse(gvMaterialList.FooterRow.Cells[4].Text, NumberStyles.Currency) / Convert.ToDecimal(dtMaterialList.Rows[0]["預計產量"].ToString())).ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
    }
    protected void gvMaterialList_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvMaterialList);
    }
    protected void gvMaterialList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridviewAddFooter(string _strFooterName, GridViewRowEventArgs _gd)
    {
        int col = _gd.Row.Cells.Count;
        TableCellCollection tc = _gd.Row.Cells;
        tc.Clear();
        TableCell tc1;

        for (int i = 0; i < col; i++)
        {
            if (i == 3)
            {
                tc1 = new TableCell();
                tc1.Text = _strFooterName;
                tc.Add(tc1);
            }
            else
            {
                tc.Add(new TableCell());
            }
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        decimal sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 4; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    
                    sum += decimal.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("lblTotal")).Text, NumberStyles.Currency);
                    
                }
                if (i == 4)
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW"));
                }
            }
        }
    }
}