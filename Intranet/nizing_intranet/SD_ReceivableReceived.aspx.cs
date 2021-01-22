using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class SD_ReceivableReceived : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitControlData();
            ShowResult();
        }
    }

    private void InitControlData()
    {
        for (int i = DateTime.Today.Year; i >= 2014; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlYear.SelectedIndex = 0;

        for (int i = 1; i <= 12; i++)
        {
            ddlMonth.Items.Add(new ListItem(i.ToString("D2"), i.ToString("D2") + "25"));
        }
        ddlMonth.SelectedValue = DateTime.Today.Month.ToString("D2") + "25";

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            string query = "select distinct CMSMV.MV001 'value'" +
                " ,CMSMV.MV001+' '+CMSMV.MV002 'text'" +
                " from COPTG" +
                " left join CMSMV on COPTG.TG006=CMSMV.MV001" +
                " where COPTG.TG006<>''" +
                " order by CMSMV.MV001";

            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlPersonnel.Items.Add(new ListItem(dt.Rows[i]["text"].ToString().Trim(), dt.Rows[i]["value"].ToString().Trim()));
            }
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        ShowResult();
    }

    private string[] GetQueryRange()
    {
        string input;
        DateTime begin, end;
        string[] r = new string[2];

        if (rdoMonth.Checked)
        {
            input = ddlYear.SelectedValue + ddlMonth.SelectedValue;

            if (!DateTime.TryParseExact(input, "yyyyMMdd", null, DateTimeStyles.None, out end))
            {
                lblError.Text = "error";
            };


            begin = end.AddMonths(-1).AddDays(1);
        }
        else
        {
            input = ddlYear.SelectedValue + "1225";

            if (!DateTime.TryParseExact(input, "yyyyMMdd", null, DateTimeStyles.None, out end))
            {
                lblError.Text = "error";
            };

            begin = end.AddYears(-1).AddDays(1);
        }

        r[0] = begin.ToString("yyyyMMdd");
        r[1] = end.ToString("yyyyMMdd");
        return r;
    }

    private void GetQueryResult(string beginDate, string endDate)
    {
        string personnelCondition = "";

        if(ddlPersonnel.SelectedValue != "all")
        {
            personnelCondition = " where tbl.SalesId=@salesId";
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "select ROW_NUMBER() over(order by SUM(tbl.ReceivableReceiveValue) desc) 'Rank'" +
                " ,coalesce(tbl.SalesId,'') 'SalesId'" +
                " ,coalesce(CMSMV.MV002, '') 'SalesName'" +
                " ,convert(int,SUM(tbl.ReceivableReceiveValue)) 'ReceivableReceiveValue'" +
                " from" +
                " (" +
                " select '現銷' '貨款收取方式'" +
                " , COPTG.TG006 'SalesId'" +
                " , sum(COPTH.TH037 + COPTH.TH038) 'ReceivableReceiveValue'" +
                " from COPTG" +
                " left join COPTH on COPTG.TG001 = COPTH.TH001 and COPTG.TG002 = COPTH.TH002" +
                " where COPTG.TG001 = 'A233'" +
                " and COPTG.TG042 between @begin and @end" +
                " group by COPTG.TG006" +
                " union" +
                " select '匯款'" +
                " ,ACRTC.TC015" +
                " ,sum(ACRTD.TD015)" +
                " from ACRTC" +
                " left join ACRTD on ACRTC.TC001 = ACRTD.TD001 and ACRTC.TC002 = ACRTD.TD002 and ACRTD.TD004 = 1 and ACRTD.TD005 = '1'" +
                " where ACRTC.TC017 between @begin and @end" +
                " group by ACRTC.TC015" +
                " union" +
                " select '收票'" +
                " ,NOTTC.TC016" +
                " ,sum(NOTTC.TC003 * NOTTC.TC027)" +
                " from NOTTC" +
                " left join NOTTD on NOTTC.TC001 = NOTTD.TD001 and NOTTD.TD004 = '6'" +
                " where NOTTD.TD003 between @begin and @end" +
                " group by NOTTC.TC016" +
                " ) tbl" +
                " left join CMSMV on tbl.SalesId = CMSMV.MV001" +
                personnelCondition +
                " group by tbl.SalesId" +
                " ,CMSMV.MV002" +
                " order by ReceivableReceiveValue desc";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@begin", beginDate);
            cmd.Parameters.AddWithValue("@end", endDate);
            cmd.Parameters.AddWithValue("@salesId", ddlPersonnel.SelectedValue);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            gvReport.DataSource = dt;
            gvReport.DataBind();
        }
    }

    private void ShowResult()
    {
        string[] queryRange = new string[2];
        queryRange = GetQueryRange();
        lblRange.Text = "查詢期間由 " + queryRange[0] + " 至 " + queryRange[1];
        GetQueryResult(queryRange[0], queryRange[1]);
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
            else if (i == 4 || i == 6 || i == 8)
            {
                tc1 = new TableCell();
                tc1.BackColor = Color.Orange;
                tc.Add(tc1);
            }
            else
            {
                tc.Add(new TableCell());
            }
        }
    }

    protected void gvReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(gvReport);
    }
    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        decimal sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 3; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    if (i != 9) //row 9 是 %，為字串
                    {
                        sum += decimal.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("Label" + (i + 1).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                }
                _gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW")).Substring(0, sum.ToString("C", new CultureInfo("zh-TW")).Length - 3);
            }
        }
    }

}