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

public partial class SD01 : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    List<string> adm = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adm.Add("chun");

            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
            txtStart.Enabled = false;
            txtEnd.Enabled = false;

            List<string> roleList = getRoles();
            string id = getId();


            if (adm.Contains(id))
            {
                Admin.Visible = true;
            }
            else
            {
                foreach (string s in roleList)
                {
                    if (s == "NIZING\\管理部")
                    {
                        Admin.Visible = true;
                    }
                }
            }
        }
    }
    protected List<string> getRoles()
    {
        List<string> role = new List<string>();
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        foreach (IdentityReference SIDRef in identity.Groups)
        {
            SecurityIdentifier sid = (SecurityIdentifier)SIDRef.Translate(typeof(SecurityIdentifier));
            NTAccount account = (NTAccount)SIDRef.Translate(typeof(NTAccount));
            role.Add(account.Value);
        }
        return role;
    }
    protected string getId()
    {
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        string[] name = identity.Name.Split('\\');
        return name[1];
    }

    protected void R1_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoYear.Checked == true)
        {
            ddlMonth.Enabled = false;
            ddlMonth.Visible = false;
        }
        else
        {
            ddlMonth.Enabled = true;
            ddlMonth.Visible = true;
        }
    }
    protected void R2_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoDDL.Checked)
        {
            txtStart.Enabled = false;
            txtEnd.Enabled = false;
            ddlYear.Enabled = true;
            ddlMonth.Enabled = true;
            rdoYear.Enabled = true;
            rdoMonth.Enabled = true;
            lblRdoTextWarning.Visible = false;
        }
        else
        {
            txtStart.Enabled = true;
            txtEnd.Enabled = true;
            ddlYear.Enabled = false;
            ddlMonth.Enabled = false;
            rdoYear.Enabled = false;
            rdoMonth.Enabled = false;
            lblRdoTextWarning.Visible = true;
        }
    }

    private void SqlSearch()
    {
        DateTime date = new DateTime();
        bool entryCorrect = false;
        string startYear = "";
        string startMonth = "";
        string endYear = "";
        string endMonth = "";
        string personnelCondition = "";
        string timespanCondition = "";
        string query = "";
        if (rdoDDL.Checked)
        {
            if (rdoYear.Checked)
            {
                startYear = Convert.ToString(Convert.ToInt16(ddlYear.SelectedValue) - 1);
                startMonth = "1226";
                endYear = ddlYear.SelectedValue;
                endMonth = "1225";
                timespanCondition = "";
            }
            else
            {
                if (ddlMonth.SelectedValue == "01")
                {
                    startYear = Convert.ToString(Convert.ToInt16(ddlYear.SelectedValue) - 1);
                    startMonth = "1226";
                }
                else
                {
                    startYear = ddlYear.SelectedValue;
                    startMonth = (Convert.ToInt16(ddlMonth.SelectedValue) - 1).ToString().PadLeft(2, '0') + "26";
                }
                endYear = ddlYear.SelectedValue;
                endMonth = ddlMonth.SelectedValue + "25";
                timespanCondition = " and saleTarget.[MONTH]=SUBSTRING(@end,5,2)";
            }
            entryCorrect = true;
        }
        else
        {
            if (!DateTime.TryParseExact(txtStart.Text.Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)
                || !DateTime.TryParseExact(txtEnd.Text.Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                entryCorrect = false;
            }
            else
            {
                startYear = txtStart.Text.Trim().Substring(0, 4);
                startMonth = txtStart.Text.Trim().Substring(4, 4);
                endYear = txtEnd.Text.Trim().Substring(0, 4);
                endMonth = txtEnd.Text.Trim().Substring(4, 4);
                entryCorrect = true;
            }
        }

        if(ddlPersonnel.SelectedValue.ToString() != "全部人員")
        {
            personnelCondition = " where pvt.salesId=@salesId";
        }

        if (entryCorrect == true)
        {
            lblError.Text = "";
            lblRange.Text = startYear + startMonth + "~" + endYear + endMonth;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                query = ";with returnAmount" +
                    " as" +
                    " (" +
                    " select TI.TI006 'salesId'" +
                    " ,COUNT(*) 'returnAmount'" +
                    " from COPTI TI" +
                    " left" +
                    " join COPTJ TJ on TI.TI001 = TJ.TJ001 and TI.TI002 = TJ.TJ002" +
                    " where TI.TI019 = N'Y'" +
                    " and TI.TI034 between @start and @end" +
                    " group by TI.TI006" +
                    " )" +
                    " ,recordTable" +
                    " as" +
                    " (" +
                    " SELECT TG.TG023 'eventCode'" +
                    " ,TG.TG042 'eventDate'" +
                    " ,TG.TG001 'eventType'" +
                    " ,TG.TG004 'custId'" +
                    " ,TG.TG006 'salesId'" +
                    " ,TG.TG045 'amount'" +
                    " ,'sale' 'returnOrSale'" +
                    " ,case" +
                    " when TG.TG001 = 'A231' then 'foreign'" +
                    " else 'domestic'" +
                    " end as 'foreignOrDomestic'" +
                    " FROM COPTG TG" +
                    " UNION ALL" +
                    " SELECT TI.TI019 'eventCode'" +
                    " ,TI.TI034 'eventDate'" +
                    " ,TI.TI001 'eventType'" +
                    " ,TI.TI004" +
                    " ,TI.TI006" +
                    " ,TI.TI037" +
                    " ,'return'" +
                    " ,case" +
                    " when TI.TI004 like 'AE%' then 'foreign'" +
                    " else 'domestic'" +
                    " end" +
                    " FROM COPTI TI" +
                    " )" +
                    " select ROW_NUMBER() over(order by coalesce(pvt.domesticSale, 0) - coalesce(pvt.domesticReturn, 0) + coalesce(pvt.foreignSale, 0) - coalesce(pvt.foreignReturn, 0) desc) 'rank'" +
                    " ,MV.MV002 'salesName'" +
                    " ,pvt.salesId" +
                    " ,convert(decimal(20, 0), coalesce(pvt.domesticSale, 0)) 'domesticSale'" +
                    " ,convert(decimal(20, 0), coalesce(pvt.domesticReturn, 0)) 'domesticReturn'" +
                    " ,convert(decimal(20, 0), coalesce(pvt.foreignSale, 0)) 'foreignSale'" +
                    " ,convert(decimal(20, 0), coalesce(pvt.foreignReturn, 0)) 'foreignReturn'" +
                    " ,convert(decimal(20, 0), coalesce(pvt.domesticSale, 0) - coalesce(pvt.domesticReturn, 0)) 'domesticNetSale'" +
                    " ,convert(decimal(20, 0), coalesce(pvt.foreignSale, 0) - coalesce(pvt.foreignReturn, 0)) 'foreignNetSale'" +
                    " ,convert(nvarchar(6), convert(decimal(5, 2), convert(decimal(20, 0), coalesce(pvt.foreignSale, 0) - coalesce(pvt.foreignReturn, 0)) * 100 /convert(decimal(20, 0), coalesce(pvt.domesticSale, 0) - coalesce(pvt.domesticReturn, 0) + coalesce(pvt.foreignSale, 0) - coalesce(pvt.foreignReturn, 0)))) + '%' 'foreignNetSalePercent'" +
                    " ,convert(decimal(20, 0), coalesce(pvt.domesticSale, 0) - coalesce(pvt.domesticReturn, 0) + coalesce(pvt.foreignSale, 0) - coalesce(pvt.foreignReturn, 0)) 'netSale'" +
                    " ,convert(decimal(20, 0), coalesce(sum(saleTarget.[TARGET]), 0)) 'saleTarget'" +
                    " ,case" +
                    " when(coalesce(pvt.domesticSale, 0) - coalesce(domesticReturn, 0) + coalesce(foreignSale, 0) - coalesce(foreignReturn, 0)) - coalesce(sum(saleTarget.[TARGET]), 0) > 0 then convert(decimal(10,2),0)" +
                    " else convert(decimal(20, 0), (coalesce(pvt.domesticSale, 0) - coalesce(domesticReturn, 0) + coalesce(foreignSale, 0) - coalesce(foreignReturn, 0)) - coalesce(sum(saleTarget.[TARGET]), 0))" +
                    " end 'targetDifference'" +
                    " ,coalesce(ra.returnAmount,0) 'returnAmount'" +
                    " from" +
                    " (select salesId" +
                    " ,case" +
                    " when foreignOrDomestic = 'domestic' and returnOrSale = 'sale' then 'domesticSale'" +
                    " when foreignOrDomestic = 'domestic' and returnOrSale = 'return' then 'domesticReturn'" +
                    " when foreignOrDomestic = 'foreign' and returnOrSale = 'sale' then 'foreignSale'" +
                    " when foreignOrDomestic = 'foreign' and returnOrSale = 'return' then 'foreignReturn'" +
                    " end as eventType" +
                    " , amount" +
                    " from recordTable" +
                    " where eventCode = 'Y'" +
                    " and eventDate between @start and @end) as src" +
                    " pivot" +
                    " (sum(amount)" +
                    " for eventType " +
                    " in ([domesticSale],[domesticReturn],[foreignSale],[foreignReturn])" +
                    " ) as pvt" +
                    " left join CMSMV MV on pvt.salesId = MV.MV001" +
                    " left join returnAmount ra on pvt.salesId=ra.salesId" +
                    " left join NZ_ERP2.dbo.SD_SD01_A saleTarget ON pvt.salesId = saleTarget.EMP_ID and saleTarget.[YEAR]=SUBSTRING(@end,1,4)" +
                    timespanCondition +
                    personnelCondition +
                    " group by" +
                    " MV.MV002" +
                    " ,pvt.salesId" +
                    " ,pvt.domesticSale" +
                    " ,pvt.domesticReturn" +
                    " ,pvt.foreignSale" +
                    " ,pvt.foreignReturn" +
                    " ,ra.returnAmount";

                //銷售淨額
                //get data from database
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@salesId", ddlPersonnel.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@start", startYear + startMonth);
                cmd.Parameters.AddWithValue("@end", endYear + endMonth);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //feed data from dataset to gridview
                grdReport.DataSource = ds;
                grdReport.DataBind();

                //feed data from dataset to chart                
                Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                Chart1.Series["domestic"].XValueMember = "salesName";
                Chart1.Series["domestic"].YValueMembers = "domesticSale";
                Chart1.Series["foreign"].YValueMembers = "foreignSale";
                Chart1.Titles.Add("銷售淨額報告" + startYear + startMonth + " ~ " + endYear + endMonth);
                //取掃所有的Series 將其SmartLabelStyle更改樣式
                foreach (var series in Chart1.Series)
                {
                    series.SmartLabelStyle.CalloutStyle = LabelCalloutStyle.None;
                    series.SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.None;
                    series.SmartLabelStyle.CalloutLineColor = Color.Transparent;
                    series.SmartLabelStyle.CalloutLineWidth = 0;
                }
                
                //Chart1.DataSource = ds.Tables[0].DefaultView;
                Chart1.Series[0].Points.DataBindXY(ds.Tables[0].DefaultView, "salesName", ds.Tables[0].DefaultView, "domesticSale");
                Chart1.Series[1].Points.DataBindXY(ds.Tables[0].DefaultView, "salesName", ds.Tables[0].DefaultView, "foreignSale");

                //將 Point 數值 0給拿掉
                foreach (var point in from series in Chart1.Series from point in series.Points from t in point.YValues where t == 0 select point)
                {
                    point.Label = string.Empty;
                }
            }
        }
        else
        {
            lblError.Text = "請確認輸入資料的正確性";
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {            
            lblError.Text = "";
            SqlSearch();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.ToString();
        }        
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdReport.Rows.Count == 0)
            {
                lblError.Text = "請先產生報表才能執行匯出";
            }
            else
            {
                lblError.Text = "";
                Export_Excel();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.ToString();
        }
    }

    private void Export_Excel()
    {
        string startYear = "";
        string startMonth = "";
        string endYear = "";
        string endMonth = "";
        if (rdoYear.Checked)
        {
            startYear = Convert.ToString(Convert.ToInt16(ddlYear.SelectedValue) - 1);
            startMonth = "1226";
            endYear = ddlYear.SelectedValue;
            endMonth = "1225";
        }
        else
        {
            if (ddlMonth.SelectedValue == "01")
            {
                startYear = Convert.ToString(Convert.ToInt16(ddlYear.SelectedValue) - 1);
                startMonth = "1226";
            }
            else
            {
                startYear = ddlYear.SelectedValue;
                startMonth = (Convert.ToInt16(ddlMonth.SelectedValue) - 1).ToString().PadLeft(2, '0') + "26";
            }
            endYear = ddlYear.SelectedValue;
            endMonth = ddlMonth.SelectedValue + "25";
        }

        string filename = "業績排名表" + startYear + startMonth + "~" + endYear + endMonth;
        string strfileext = ".xls";
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
        HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

        //先把分頁關掉
        //gvResult.AllowPaging = false;
        //bindgv();

        //Get the HTML for the control.
        grdReport.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //用export_excel必須要有這個override
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
            else if (i==4 || i==6 || i == 8)
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

    protected void grdReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(grdReport);
    }
    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.CssClass = "stackedHeader-1";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "銷貨金額";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.CssClass = "stackedHeader-1";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "退貨金額";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.CssClass = "stackedHeader-1";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "銷售淨額";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.CssClass = "stackedHeader-1";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.CssClass = "stackedHeader-1";
            HeaderGridRow.Cells.Add(HeaderCell);
            grdReport.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
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
                if (i == 10)
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW")).Substring(0, sum.ToString("C", new CultureInfo("zh-TW")).Length-3);
                }
                else if (i == 9)
                {
                    _gd.FooterRow.Cells[i].Text = (Convert.ToDecimal(_gd.FooterRow.Cells[i - 1].Text) * 100 / (Convert.ToDecimal(_gd.FooterRow.Cells[i - 1].Text) + Convert.ToDecimal(_gd.FooterRow.Cells[i - 2].Text))).ToString("0.00") + "%";
                }
                else
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
                }
            }
        }
    }

    protected void btnTargetTrigger_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        SetTargetContent.Visible = true;
        for (int i = 2017; i <= DateTime.Now.Year + 1; i++)
        {
            ddlTargetYear.Items.Add(i.ToString());
        }
        for (int i = 1; i <= 12; i++)
        {
            ddlTargetMonth.Items.Add(i.ToString("D2"));
        }
        ddlTargetEmp.Items.Clear();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT CMSMV.MV001 EMP_ID, CMSMV.MV002 EMP_NAME"
                        + " FROM CMSMV"
                        + " WHERE (MV004='A-SD'"
                        + " AND MV022=''"
                        + " AND MV001<>'0098')" //黃耀南不顯示
                        + " OR MV001='0067'"
                        + " ORDER BY CMSMV.MV001";
            SqlCommand cmd = new SqlCommand(query, conn);            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ddlTargetEmp.Items.Add(ds.Tables[0].Rows[i][0].ToString() + " " + ds.Tables[0].Rows[i][1].ToString());
        }
    }
    protected void ddlTargetChanged(object sender, EventArgs e)
    {
        string query = "";
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            query = "SELECT TARGET"
                + " FROM SD_SD01_A"
                + " WHERE [YEAR]=@YEAR"
                + " AND [MONTH]=@MONTH"
                + " AND [EMP_ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", ddlTargetYear.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@MONTH", ddlTargetMonth.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@ID", ddlTargetEmp.SelectedValue.ToString().Substring(0, 4));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnTargetDelete.Enabled = true;
            txtTarget.Text = ds.Tables[0].Rows[0][0].ToString().Trim();
        }
        else
        {
            btnTargetDelete.Enabled = false;
            txtTarget.Text = "";
        }
    }
    protected void btnTargetSubmit_Click(object sender, EventArgs e)
    {
        bool exist = targetExist();
        string query = "";
        if (exist)
        {
            query = "UPDATE SD_SD01_A"
                + " SET TARGET=@TARGET"
                + " WHERE [YEAR]=@YEAR"
                + " AND [MONTH]=@MONTH"
                + " AND [EMP_ID]=@ID";
        }
        else
        {
            query = "INSERT INTO SD_SD01_A"
                + " VALUES"
                + " (@YEAR,@MONTH,@ID,@TARGET)";
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", ddlTargetYear.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@MONTH", ddlTargetMonth.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@ID", ddlTargetEmp.SelectedValue.ToString().Substring(0, 4));
            cmd.Parameters.AddWithValue("@TARGET", txtTarget.Text.Trim());
            cmd.ExecuteNonQuery();
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('目標金額儲存成功');", true);
        btnTargetDelete.Enabled = true;
    }

    /// <summary>
    /// check if a target amount is set for this employee at this month of this year
    /// </summary>
    /// <returns></returns>
    protected bool targetExist()
    {
        string query = "";
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "SELECT TARGET"
                + " FROM SD_SD01_A"
                + " WHERE [YEAR]=@YEAR"
                + " AND [MONTH]=@MONTH"
                + " AND [EMP_ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", ddlTargetYear.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@MONTH", ddlTargetMonth.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@ID", ddlTargetEmp.SelectedValue.ToString().Substring(0, 4));
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    btnTargetDelete.Enabled = true;
                    return true;
                }
                else
                {
                    btnTargetDelete.Enabled = false;
                    return false;
                }
            }
        }
    }
    protected void btnTargetDelete_Click(object sender, EventArgs e)
    {
        bool exist = targetExist();
        string query = "";
        if (exist)
        {
            query = "DELETE FROM SD_SD01_A"
                + " WHERE [YEAR]=@YEAR"
                + " AND [MONTH]=@MONTH"
                + " AND [EMP_ID]=@ID";
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", ddlTargetYear.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@MONTH", ddlTargetMonth.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@ID", ddlTargetEmp.SelectedValue.ToString().Substring(0, 4));
            cmd.ExecuteNonQuery();
        }
        txtTarget.Text = "";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('目標金額已刪除');", true);
        btnTargetDelete.Enabled = false;
    }
}