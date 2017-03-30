using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionProgress : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            grdList.DataSource = SqlSearch(GetParentQuery(""));
            grdList.DataBind();
        }
    }

    private string GetParentQuery(string str)
    {
        string query = "";

        query = "SELECT LTRIM(RTRIM(MOCTA.TA001))+LTRIM(RTRIM(MOCTA.TA002)) 製令編號, COALESCE(COPMA.MA002, '') 客戶簡稱, MOCTA.TA202 客戶交期"
                + " , CASE MOCTA.TA011"
                + " WHEN N'1' THEN N'未生產'"
                + " WHEN N'2' THEN N'已發料'"
                + " WHEN N'3' THEN N'生產中'"
                + " ELSE N'N/A'"
                + " END AS 狀態"
                + " , CASE MOCTA.TA203"
                + " WHEN N'1' THEN N'母'"
                + " WHEN N'2' THEN N'子'"
                + " ELSE N'N/A'"
                + " END AS '母/子'"
                + " , MOCTA.TA021 生產線別"
                + " , MOCTA.TA006 品號, MOCTA.TA034 品名, MOCTA.TA035 規格, MOCTA.TA015 預計產量"
                + " , MOCTA.TA007 單位, MOCTA.TA016 已領料量, MOCTA.TA017 已生產量, MOCTA.TA015-MOCTA.TA017 未生產量"
                + " FROM MOCTA"
                + " LEFT JOIN COPTC ON MOCTA.TA026 = COPTC.TC001 AND MOCTA.TA027 = COPTC.TC002"
                + " LEFT JOIN COPMA ON COPTC.TC004 = COPMA.MA001"
                + " WHERE LTRIM(RTRIM(MOCTA.TA001)) = N'W' AND MOCTA.TA011 <> N'Y' AND MOCTA.TA011 <> N'y' AND MOCTA.TA013=N'Y' AND MOCTA.TA203=1"
                + str
                + " ORDER BY CASE WHEN MOCTA.TA202 = N'' THEN 1 ELSE 0 END, MOCTA.TA202 ASC, MOCTA.TA002 ASC";

        return query;
    }

    private string GetChildQuery(string s)
    {
        string query = "";

        query = "SELECT LTRIM(RTRIM(MOCTA.TA001))+LTRIM(RTRIM(MOCTA.TA002)) 製令編號, MOCTA.TA010 預計完工日期"
                + " , CASE MOCTA.TA011"
                + " WHEN N'1' THEN N'未生產'"
                + " WHEN N'2' THEN N'已發料'"
                + " WHEN N'3' THEN N'生產中'"
                + " WHEN N'Y' THEN N'已完工'"
                + " WHEN N'y' THEN N'指定完工'"
                + " ELSE N'N/A'"
                + " END AS 狀態"
                + " , CASE MOCTA.TA203"
                + " WHEN N'1' THEN N'母'"
                + " WHEN N'2' THEN N'子'"
                + " ELSE N'N/A'"
                + " END AS '母/子'"
                + " , MOCTA.TA021 生產線別"
                + " , MOCTA.TA006 品號, MOCTA.TA034 品名, MOCTA.TA035 規格, MOCTA.TA015 預計產量"
                + " , MOCTA.TA007 單位, MOCTA.TA016 已領料量, MOCTA.TA017 已生產量, MOCTA.TA015-MOCTA.TA017 未生產量"
                + " FROM MOCTA"
                + " WHERE LTRIM(RTRIM(MOCTA.TA001)) = N'W' AND MOCTA.TA013=N'Y' AND MOCTA.TA203=2 AND LTRIM(RTRIM(MOCTA.TA025))=" + s
                + " ORDER BY MOCTA.TA010 DESC";
        return query;
    }
    
    private DataSet SqlSearch(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
    protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string proID = grdList.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView grdDetail = e.Row.FindControl("grdDetail") as GridView;
            grdDetail.DataSource = SqlSearch(GetChildQuery(proID.Substring(1, proID.Length - 1)));
            grdDetail.DataBind();
        }
    }
}