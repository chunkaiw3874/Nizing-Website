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
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


public partial class nizing_intranet_ACC01 : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["SunriseConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = DateTime.Today.Year; i > 2012; i--)
            {
                ddlStartYear.Items.Add(i.ToString());
                ddlEndYear.Items.Add(i.ToString());
            }
            for (int i = 1; i < 13; i++)
            {
                ddlStartMonth.Items.Add(i.ToString("D2"));
                ddlEndMonth.Items.Add(i.ToString("D2"));
            }
            ddlEndMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT LTRIM(RTRIM(MA001)) 'display'"
                            + " FROM TAXMA";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                ddlCompanyID.DataTextField = "display";
                ddlCompanyID.DataValueField = "display";
                ddlCompanyID.DataSource = dt;
                ddlCompanyID.DataBind();
            }
            ddlCompanyID.Items.Insert(0, new ListItem("全部", "ALL"));
            divAnnualReport.Visible = false;
            divDetailReport.Visible = true;
        }
    }
    protected void rdoDetailReport_CheckedChanged(object sender, EventArgs e)
    {
        
        if (rdoDetailReport.Checked)
        {
            ddlStartYear.Enabled = true;
            ddlStartMonth.Enabled = true;
            ddlEndYear.Enabled = true;
            ddlEndMonth.Enabled = true;
            txtClientID.Enabled = true;
            ddlCompanyID.Enabled = true;
            divAnnualReport.Visible = false;
            divDetailReport.Visible = true;
        }
        else
        {
            ddlStartYear.Enabled = true;
            ddlStartMonth.Enabled = false;
            ddlEndYear.Enabled = false;
            ddlEndMonth.Enabled = false;
            txtClientID.Enabled = false;
            ddlCompanyID.Enabled = false;
            divAnnualReport.Visible = true;
            divDetailReport.Visible = false;
        }
    }
    [WebMethod]
    public static string[] GetClientList(string keyword)
    {
        List<string> lstData = new List<string>();
        DataTable dt = new DataTable();
        string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            string query = "SELECT LTRIM(RTRIM(MA.MA001))+' '+LTRIM(RTRIM(MA.MA002)) 'display',LTRIM(RTRIM(MA001)) 'value'"
                         + " FROM COPMA MA"
                         + " WHERE MA001<>'0000' AND MA001<>'0001'"
                         + " AND LTRIM(RTRIM(MA.MA001))+' '+MA.MA002 LIKE '%'+@containedString+'%'"
                         + " ORDER BY MA001";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@containedString", keyword);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        foreach (DataRow row in dt.Rows)
        {
            string name = row[0].ToString();
            lstData.Add(name);
        }

        return lstData.ToArray<string>();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        gvAnnualReport.DataSource = null;
        gvAnnualReport.DataBind();
        chartAnnualReport.DataSource = null;
        chartAnnualReport.DataBind();
        gvDetailReport.DataSource = null;
        gvDetailReport.DataBind();
        if (rdoDetailReport.Checked)
        {
            string query = "";
            string clientCondition = "";
            string companyCondition = "";
            string clientID = "";
            if (txtClientID.Text.Trim() != "")
            {
                if (txtClientID.Text.Trim().Count() < 6)
                {

                }
                else
                {
                    clientID = txtClientID.Text.Trim().Substring(0, 6);
                    clientCondition = " AND TA.TA004=@CUSTID";
                }
            }
            if (ddlCompanyID.SelectedValue != "ALL")
            {
                companyCondition = " AND MB.MB001=@COMPID";
            }
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                query = "SELECT TA.TA003 '結帳單據日期'"
                    + " ,TA.TA004 '客戶代號'"
                    + " ,MA.MA002 '客戶名稱'"
                    + " ,TA.TA016 '發票日期'"
                    + " ,TA.TA015 '發票號碼'"
                    + " ,MB.MB001 '申報公司'"
                    + " ,TMA.MA002 '公司簡稱'"
                    + " ,CONVERT(DECIMAL(20,2),TA.TA041) '應收金額'"
                    + " ,CONVERT(DECIMAL(20,2),TA.TA042) '營業稅額'"
                    + " ,COALESCE(CONVERT(DECIMAL(20,2),TA041)+CONVERT(DECIMAL(20,2),TA042),0) '應收總計'"
                    + " FROM ACRTA TA"
                    + " LEFT JOIN COPMA MA ON TA.TA004=MA.MA001"
                    + " LEFT JOIN TAXMB MB ON TA.TA015 BETWEEN MB.MB006 AND MB.MB007"
                    + " LEFT JOIN TAXMA TMA ON MB.MB001=TMA.MA001"
                    + " WHERE TA.TA016 BETWEEN @STARTDATE AND @ENDDATE"
                    + clientCondition
                    + companyCondition
                    + " ORDER BY TA.TA016,TA.TA004,MB.MB001";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@STARTDATE", ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01");
                cmd.Parameters.AddWithValue("@ENDDATE", ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31");
                cmd.Parameters.AddWithValue("@CUSTID", clientID);
                cmd.Parameters.AddWithValue("@COMPID", ddlCompanyID.SelectedValue);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gvDetailReport.DataSource = dt;
                gvDetailReport.DataBind();
            }
        }
        else
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUBSTRING(LTRIM(RTRIM(TA.TA016)),1,4) '發票年度'"
                            + " ,MB.MB001 '申報公司'"
                            + " ,TMA.MA002 '公司簡稱'"
                            + " ,CONVERT(DECIMAL(20,2),SUM(COALESCE(TA.TA041,0))) '應收金額'"
                            + " ,CONVERT(DECIMAL(20,2),SUM(COALESCE(TA.TA042,0))) '營業稅額'"
                            + " ,CONVERT(DECIMAL(20,2),COALESCE(SUM(COALESCE(TA.TA041,0))+SUM(COALESCE(TA.TA042,0)),0)) '應收總計'"
                            + " FROM ACRTA TA"
                            + " LEFT JOIN TAXMB MB ON TA.TA015 BETWEEN MB.MB006 AND MB.MB007"
                            + " LEFT JOIN TAXMA TMA ON MB.MB001=TMA.MA001"
                            + " WHERE SUBSTRING(LTRIM(RTRIM(TA.TA016)),1,4)=@YEAR"
                            + " AND MB.MB001 IS NOT NULL"
                            + " GROUP BY SUBSTRING(LTRIM(RTRIM(TA.TA016)),1,4),MB.MB001,TMA.MA002"
                            + " ORDER BY SUBSTRING(LTRIM(RTRIM(TA.TA016)),1,4),MB.MB001";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR", ddlStartYear.SelectedValue);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gvAnnualReport.DataSource = dt;
                gvAnnualReport.DataBind();
                chartAnnualReport.DataSource = dt;
                chartAnnualReport.Titles.Add("發票年度" + ddlStartYear.SelectedValue);
                chartAnnualReport.Series[0].ChartType = SeriesChartType.Column;
                chartAnnualReport.Series[0].XValueMember = "公司簡稱";
                chartAnnualReport.Series[0].YValueMembers = "應收總計";
                chartAnnualReport.DataBind();
            }
        }
    }
    protected void gvDetailReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvDetailReport);
    }
    protected void gvDetailReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    protected void gvAnnualReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvAnnualReport);
    }
    protected void gvAnnualReport_RowCreated(object sender, GridViewRowEventArgs e)
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
            if (i == col-4)
            {
                tc1 = new TableCell();
                tc1.Text = _strFooterName;
                tc1.CssClass = "right-align";
                tc.Add(tc1);
            }
            else
            {
                TableCell tcOther = new TableCell();
                tcOther.CssClass = "right-align";
                tc.Add(tcOther);
            }
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        int sum = 0;
        int colNumberToBeSummed = 0;
        if (_gd == gvDetailReport)
        {
            colNumberToBeSummed = 7;
        }
        else
        {
            colNumberToBeSummed = 3;
        }
        if (_gd.Rows.Count > 0)
        {
            for (int i = colNumberToBeSummed; i < colNumberToBeSummed + 3; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum += int.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("lbl" + (i + 1).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                _gd.FooterRow.Cells[i].Text = sum.ToString("C2");
            }
        }
    }
}