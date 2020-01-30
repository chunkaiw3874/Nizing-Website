using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_ProductionProgress_Dept : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string GetParentQuery(string str)
    {
        string query = "";

        query = "SELECT LTRIM(RTRIM(MOCTA.TA001))+LTRIM(RTRIM(MOCTA.TA002)) 製令編號,LTRIM(RTRIM(MOCTA.TA024))+LTRIM(RTRIM(MOCTA.TA025)) 母製令編號, COALESCE(COPMA.MA002, '') 客戶簡稱, MOCTA.TA202 客戶交期"
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
                + " , MOCTA.TA006 品號, MOCTA.TA034 品名, MOCTA.TA035 規格" +
                ", CONVERT(DECIMAL(20,0),MOCTA.TA015) 預計產量"
                + " , MOCTA.TA007 單位" +
                ", CONVERT(DECIMAL(20,0),MOCTA.TA016) 已領料量" +
                ", CONVERT(DECIMAL(20,0),MOCTA.TA017) 已生產量" +
                ", CONVERT(DECIMAL(20,0),MOCTA.TA015-MOCTA.TA017) 未生產量"
                + " FROM MOCTA"
                + " LEFT JOIN COPTC ON MOCTA.TA026 = COPTC.TC001 AND MOCTA.TA027 = COPTC.TC002"
                + " LEFT JOIN COPMA ON COPTC.TC004 = COPMA.MA001"
                + " WHERE LTRIM(RTRIM(MOCTA.TA001)) = N'W' AND MOCTA.TA011 <> N'Y' AND MOCTA.TA011 <> N'y' AND MOCTA.TA013=N'Y'"
                + str
                + " ORDER BY CASE WHEN MOCTA.TA202 = N'' THEN 1 ELSE 0 END, MOCTA.TA202 ASC, MOCTA.TA002 ASC";

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
    protected void btnC_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'C'"));
        grdList.DataBind();
    }
    protected void btnD_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'D'"));
        grdList.DataBind();
    }
    protected void btnE_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'E'"));
        grdList.DataBind();
    }
    protected void btnG_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'G'"));
        grdList.DataBind();
    }
    protected void btnK_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'K'"));
        grdList.DataBind();
    }
    protected void btnP_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'P'"));
        grdList.DataBind();
    }
    protected void btnS_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'S'"));
        grdList.DataBind();
    }
    protected void btnT_Click(object sender, ImageClickEventArgs e)
    {
        grdList.DataSource = SqlSearch(GetParentQuery(" AND MOCTA.TA021=N'T'"));
        grdList.DataBind();
    }
    protected void grdList_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(grdList);
    }
    protected void grdList_RowCreated(object sender, GridViewRowEventArgs e)
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
            if (i == 7)
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
            for (int i = 10; i < _gd.Columns.Count; i++)
            {
                sum = 0;
                if (i != 11)
                {
                    for (int j = 0; j < _gd.Rows.Count; j++)
                    {
                        sum += decimal.Parse(((Label)_gd.Rows[j].FindControl("Label" + (i + 1).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
                }
                else if (i == 11)
                {
                    List<string> unitList = new List<string>();
                    for (int j = 0; j < _gd.Rows.Count; j++)
                    {
                        unitList.Add(((Label)_gd.Rows[j].FindControl("Label" + (i + 1).ToString())).Text);
                    }
                    unitList = unitList.Distinct().ToList();
                    if (unitList.Count == 1)
                    {
                        _gd.FooterRow.Cells[i].Text = unitList[0];
                    }

                }
            }
            _gd.FooterRow.Cells[8].Text = _gd.Rows.Count.ToString() + "筆";
        }
    }

}