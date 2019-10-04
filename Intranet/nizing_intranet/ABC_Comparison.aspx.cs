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

public partial class ABC_Comparison : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlStartYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                ddlEndYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlStartYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlEndYear.SelectedValue = DateTime.Today.Year.ToString();
        }
    }
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        //put value into hiddenfields for later year
        string startyear = ddlStartYear.SelectedValue.ToString();
        string startmonth = ddlStartMonth.SelectedValue.ToString();
        string endyear = ddlEndYear.SelectedValue.ToString();
        string endmonth = ddlEndMonth.SelectedValue.ToString();
        if (ddlStartMonth.SelectedValue == "1226")
        {
            startyear = Convert.ToString(Convert.ToInt16(startyear) - 1);
        }
        hdnNewStart.Value = startyear + startmonth;
        hdnNewEnd.Value = endyear + endmonth;
        //put value into hiddenfields for previous year
        startyear = Convert.ToString(Convert.ToInt16(startyear) - 1);
        endyear = Convert.ToString(Convert.ToInt16(endyear) - 1);
        hdnPrevStart.Value = startyear + startmonth;
        hdnPrevEnd.Value = endyear + endmonth; 
        lblScope.Text = "查詢期間: " + hdnNewStart.Value.ToString() + "~" + hdnNewEnd.Value.ToString();

        string query = GetQuery();

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmdSelect = new SqlCommand(query, conn);
            cmdSelect.Parameters.AddWithValue("@NOWSTART", hdnNewStart.Value);
            cmdSelect.Parameters.AddWithValue("@NOWEND", hdnNewEnd.Value);
            cmdSelect.Parameters.AddWithValue("@PREVSTART", hdnPrevStart.Value);
            cmdSelect.Parameters.AddWithValue("@PREVEND", hdnPrevEnd.Value);
            cmdSelect.Parameters.AddWithValue("@SALESID", ddlPersonnel.SelectedValue.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                if (this.ViewState["SortExpression"] != null)
                {
                    dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());
                }
            }
            grdReport.DataSource = dt;
            grdReport.DataBind();
        }
    }

    private string GetQuery()
    {
        string query = "";
        string condition = "";
        
        if (ddlPersonnel.SelectedItem.Text != "全部人員")
        {
            condition = " AND [SALES_NOW].[SALESID] = @SALESID";
        }
//        query = "WITH [RETURN_NOW]"
//+ " AS"
//+ " ("
//+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, SUM(COPTI.TI037) [RETURN]"
//+ " FROM COPTI"
//+ " LEFT JOIN COPMA ON COPTI.TI004 = COPMA.MA001"
//+ " WHERE COPTI.TI034 BETWEEN @NOWSTART AND @NOWEND"
//+ " GROUP BY COPMA.MA001, COPMA.MA002"
//+ " )"
//+ " ,[RETURN_HISTORY]"
//+ " AS"
//+ " ("
//+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, SUM(COPTI.TI037) [RETURN]"
//+ " FROM COPTI"
//+ " LEFT JOIN COPMA ON COPTI.TI004 = COPMA.MA001"
//+ " WHERE COPTI.TI034 BETWEEN @PREVSTART AND @PREVEND"
//+ " GROUP BY COPMA.MA001, COPMA.MA002"
//+ " )"
//+ " ,[SALES_NOW]"
//+ " AS"
//+ " ("
//+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, CMSMV.MV002 SALESNAME, SUM(COPTG.TG045) [SALE]"
//+ " FROM COPTG"
//+ " LEFT JOIN COPMA ON COPTG.TG004 = COPMA.MA001"
//+ " LEFT JOIN CMSMV ON COPMA.MA016 = CMSMV.MV001"
//+ " WHERE COPTG.TG042 BETWEEN @NOWSTART AND @NOWEND"
//+ " GROUP BY COPMA.MA001, COPMA.MA002, CMSMV.MV002"
//+ " )"
//+ " ,[SALES_HISTORY]"
//+ " AS"
//+ " ("
//+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, SUM(COPTG.TG045) [SALE]"
//+ " FROM COPTG"
//+ " LEFT JOIN COPMA ON COPTG.TG004 = COPMA.MA001"
//+ " WHERE COPTG.TG042 BETWEEN @PREVSTART AND @PREVEND"
//+ " GROUP BY COPMA.MA001, COPMA.MA002"
//+ " )"
//+ " SELECT ROW_NUMBER() OVER (ORDER BY COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0) DESC) [RN]"
//+ " , [SALES_NOW].[CUSTID] [CUSTID]"
//+ " , [SALES_NOW].[CUSTNAME] [CUSTNAME]"
//+ " , [SALES_NOW].[SALESNAME] [SALESNAME]"
//+ " , CONVERT(VARCHAR, CONVERT(MONEY, COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0)), 1) [SALENOW]"
//+ " , CONVERT(VARCHAR, CONVERT(MONEY, COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)), 1) [SALEPREV]"
//+ " , CONVERT(NVARCHAR(20), CONVERT(DECIMAL(20,2), 100*COALESCE(((COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0))-(COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)))/NULLIF((COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)),0), N'0'))) [GROWTH]"
//+ " FROM [SALES_NOW]"
//+ " LEFT JOIN [SALES_HISTORY] ON [SALES_NOW].[CUSTID] = [SALES_HISTORY].[CUSTID]"
//+ " LEFT JOIN [RETURN_NOW] ON [SALES_NOW].[CUSTID] = [RETURN_NOW].[CUSTID]"
//+ " LEFT JOIN [RETURN_HISTORY] ON [SALES_NOW].[CUSTID] = [RETURN_HISTORY].[CUSTID]"
        query = "WITH [RETURN_NOW]"
+ " AS"
+ " ("
+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, COALESCE(SUM(COPTI.TI037),0) [RETURN]"
+ " FROM COPMA"
+ " LEFT JOIN COPTI ON COPMA.MA001=COPTI.TI004 AND COPTI.TI034 BETWEEN @NOWSTART AND @NOWEND"
+ " GROUP BY COPMA.MA001, COPMA.MA002"
+ " )"
+ " ,[RETURN_HISTORY]"
+ " AS"
+ " ("
+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, COALESCE(SUM(COPTI.TI037),0) [RETURN]"
+ " FROM COPMA"
+ " LEFT JOIN COPTI ON COPMA.MA001=COPTI.TI004 AND COPTI.TI034 BETWEEN @PREVSTART AND @PREVEND"
+ " GROUP BY COPMA.MA001, COPMA.MA002"
+ " )"
+ " ,[SALES_NOW]"
+ " AS"
+ " ("
+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, COALESCE(CMSMV.MV001,'NA') SALESID, COALESCE(CMSMV.MV002,'NA') SALESNAME, COALESCE(SUM(COPTG.TG045),0) [SALE]"
+ " FROM COPMA"
+ " LEFT JOIN COPTG ON COPMA.MA001=COPTG.TG004 AND COPTG.TG042 BETWEEN @NOWSTART AND @NOWEND"
+ " LEFT JOIN CMSMV ON COPMA.MA016=CMSMV.MV001"
+ " GROUP BY COPMA.MA001, COPMA.MA002, CMSMV.MV002, CMSMV.MV001"
+ " )"
+ " ,[SALES_HISTORY]"
+ " AS"
+ " ("
+ " SELECT COPMA.MA001 CUSTID, COPMA.MA002 CUSTNAME, COALESCE(SUM(COPTG.TG045),0) [SALE]"
+ " FROM COPMA"
+ " LEFT JOIN COPTG ON COPMA.MA001=COPTG.TG004 AND COPTG.TG042 BETWEEN @PREVSTART AND @PREVEND"
+ " GROUP BY COPMA.MA001, COPMA.MA002"
+ " )"
+ " SELECT ROW_NUMBER() OVER (ORDER BY COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0) DESC) [RN]"
+ " , [SALES_NOW].[CUSTID] [CUSTID]"
+ " , [SALES_NOW].[CUSTNAME] [CUSTNAME]"
+ " , [SALES_NOW].[SALESNAME] [SALESNAME]"
+ " , CONVERT(DECIMAL(20,2),COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0)) [SALENOW]"
+ " , CONVERT(DECIMAL(20,2),COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)) [SALEPREV]"
+ " , "
+ " CASE"
+ " WHEN SALES_HISTORY.SALE-RETURN_HISTORY.[RETURN] > 0 THEN CONVERT(DECIMAL(20,2), 100*COALESCE(((COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0))-(COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)))/NULLIF((COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)),0), N'0'))"
+ " WHEN SALES_NOW.SALE-RETURN_NOW.[RETURN] <= 0 THEN -100"
+ " ELSE 99999"
+ " END [GROWTH]"
+ " FROM [SALES_NOW]"
+ " LEFT JOIN [SALES_HISTORY] ON [SALES_NOW].[CUSTID] = [SALES_HISTORY].[CUSTID]"
+ " LEFT JOIN [RETURN_NOW] ON [SALES_NOW].[CUSTID] = [RETURN_NOW].[CUSTID]"
+ " LEFT JOIN [RETURN_HISTORY] ON [SALES_NOW].[CUSTID] = [RETURN_HISTORY].[CUSTID]"
+ " WHERE (COALESCE([SALES_NOW].[SALE],0)-COALESCE([RETURN_NOW].[RETURN],0)<>0"
+ " OR COALESCE([SALES_HISTORY].[SALE],0)-COALESCE([RETURN_HISTORY].[RETURN],0)<>0)"
+ condition;
        return query;
    }

    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
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
            if (i == 0)
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
        int sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 4; i < 6; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum += int.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("Label"+(i+4).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
            }
        }
    }
    protected void grdReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(grdReport);
    }
    protected void grdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sort"))
        {
            if (ViewState["SortExpression"] != null)
            {
                if (this.ViewState["SortExpression"].ToString() == e.CommandArgument.ToString())
                {
                    if (ViewState["SortOrder"].ToString() == "ASC")
                    {
                        ViewState["SortOrder"] = "DESC";
                    }
                    else
                    {
                        ViewState["SortOrder"] = "ASC";
                    }
                }
                else
                {
                    ViewState["SortOrder"] = "ASC";
                    ViewState["SortExpression"] = e.CommandArgument.ToString();
                }
            }
            else
            {
                ViewState["SortExpression"] = e.CommandArgument.ToString();
                ViewState["SortOrder"] = "ASC";
            }
        }
        btnGenerateReport_Click(sender, e);
    }
}