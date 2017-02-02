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
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class SD01 : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
            txtStart.Enabled = false;
            txtEnd.Enabled = false;
        }
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
        }
        else
        {
            txtStart.Enabled = true;
            txtEnd.Enabled = true;
            ddlYear.Enabled = false;
            ddlMonth.Enabled = false;
            rdoYear.Enabled = false;
            rdoMonth.Enabled = false;
        }
    }
    private string[] GetQuery()
    {
        string[] query = new string[2];


        if (ddlPersonnel.SelectedValue.ToString() == "全部人員")
        {
            query[0] = "WITH TEMP"
                    + " AS"
                    + " ("
                    + " SELECT TI.TI006, SUM(TI.TI037) R"
                    + " FROM COPTI TI"
                    + " LEFT JOIN CMSMV MV ON TI.TI006 = MV.MV001"
                    + " WHERE TI.TI019=N'Y' AND TI.TI034 BETWEEN @StartDate AND @EndDate"
                    + " GROUP BY MV.MV002, TI.TI006"
                    + " )"
                    + " SELECT ROW_NUMBER() OVER (ORDER BY SUM(TG045)-COALESCE(TI.R,0) DESC) 排名, MV002 業務名稱, TG006 業務代號, CONVERT(DECIMAL(20,2), SUM(TG045)) 銷貨金額, CONVERT(DECIMAL(20,2), COALESCE(TI.R,0)) 退貨金額, CONVERT(DECIMAL(20,2), SUM(TG045)-COALESCE(TI.R,0)) 銷貨淨額"
                    + " FROM COPTG TG"
                    + " LEFT JOIN CMSMV MV ON TG.TG006 = MV.MV001"
                    + " LEFT JOIN TEMP TI ON TG.TG006 = TI.TI006"
                    + " WHERE TG.TG023=N'Y' AND TG.TG042 BETWEEN @StartDate AND @EndDate"
                    + " GROUP BY MV.MV002, TG.TG006, TI.R";
            query[1] = "WITH CTE_RETURN(SALES, NUMBER)"
                    + " AS"
                    + " ("
                    + " SELECT COPTI.TI006, COUNT(*)"
                    + " FROM COPTI"
                    + " WHERE COPTI.TI019=N'Y' AND COPTI.TI034 BETWEEN @StartDate AND @EndDate"
                    + " GROUP BY COPTI.TI006"
                    + " )"
                    + " SELECT ROW_NUMBER() OVER (ORDER BY COALESCE(SUM(TI.TI037),0) DESC) 排名, MV.MV002 業務名稱, TI.TI006 業務代號, CONVERT(DECIMAL(20,2),SUM(TJ.TJ033)) 退貨金額, CTE_RETURN.NUMBER 退貨單數, COUNT(*) 退貨件數"
                    + " FROM COPTI TI"
                    + " LEFT JOIN COPTJ TJ ON TI.TI001 = TJ.TJ001 AND TI.TI002 = TJ.TJ002"
                    + " LEFT JOIN CMSMV MV ON TI.TI006 = MV.MV001"
                    + " LEFT JOIN CTE_RETURN ON TI.TI006 = CTE_RETURN.SALES"
                    + " WHERE TI.TI019=N'Y' AND TI.TI034 BETWEEN @StartDate AND @EndDate"
                    + " GROUP BY MV.MV002, TI.TI006, CTE_RETURN.NUMBER";
        }
        else
        {
            query[0] = "WITH TEMP"
                    + " AS"
                    + " ("
                    + " SELECT TI.TI006, SUM(TI.TI037) R"
                    + " FROM COPTI TI"
                    + " LEFT JOIN CMSMV MV ON TI.TI006 = MV.MV001"
                    + " WHERE TI.TI019=N'Y' AND TI.TI034 BETWEEN @StartDate AND @EndDate AND TI.TI006 = N'" + ddlPersonnel.SelectedValue.ToString() + "'"
                    + " GROUP BY MV.MV002, TI.TI006"
                    + " )"
                    + " SELECT ROW_NUMBER() OVER (ORDER BY SUM(TG045)-COALESCE(TI.R,0) DESC) 排名, MV002 業務名稱, TG006 業務代號, CONVERT(DECIMAL(20,2), SUM(TG045)) 銷貨金額, CONVERT(DECIMAL(20,2), COALESCE(TI.R,0)) 退貨金額, CONVERT(DECIMAL(20,2), SUM(TG045)-COALESCE(TI.R,0)) 銷貨淨額"
                    + " FROM COPTG TG"
                    + " LEFT JOIN CMSMV MV ON TG.TG006 = MV.MV001"
                    + " LEFT JOIN TEMP TI ON TG.TG006 = TI.TI006"
                    + " WHERE TG.TG023=N'Y' AND TG.TG042 BETWEEN @StartDate AND @EndDate AND TG.TG006 = N'" + ddlPersonnel.SelectedValue.ToString() + "'"
                    + " GROUP BY MV.MV002, TG.TG006, TI.R";
            query[1] = "WITH CTE_RETURN(SALES, NUMBER)"
                    + " AS"
                    + " ("
                    + " SELECT COPTI.TI006, COUNT(*)"
                    + " FROM COPTI"
                    + " WHERE COPTI.TI019=N'Y' AND COPTI.TI034 BETWEEN @StartDate AND @EndDate"
                    + " GROUP BY COPTI.TI006"
                    + " )"
                    + " SELECT ROW_NUMBER() OVER (ORDER BY COALESCE(SUM(TI.TI037),0) DESC) 排名, MV.MV002 業務名稱, TI.TI006 業務代號, CONVERT(DECIMAL(20,2),SUM(TJ.TJ033)) 退貨金額, CTE_RETURN.NUMBER 退貨單數, COUNT(*) 退貨件數"
                    + " FROM COPTI TI"
                    + " LEFT JOIN COPTJ TJ ON TI.TI001 = TJ.TJ001 AND TI.TI002 = TJ.TJ002"
                    + " LEFT JOIN CMSMV MV ON TI.TI006 = MV.MV001"
                    + " LEFT JOIN CTE_RETURN ON TI.TI006 = CTE_RETURN.SALES"
                    + " WHERE TI.TI019=N'Y' AND TI.TI034 BETWEEN @StartDate AND @EndDate AND TI.TI006= N'" + ddlPersonnel.SelectedValue.ToString() + "'"
                    + " GROUP BY MV.MV002, TI.TI006, CTE_RETURN.NUMBER";
        }
        return query;
    }

    private void SqlSearch(string[] query)
    {
        DateTime date = new DateTime();
        bool entryCorrect = false;
        string startYear = "";
        string startMonth = "";
        string endYear = "";
        string endMonth = "";
        if (rdoDDL.Checked)
        {
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
        if (entryCorrect == true)
        {
            lblError.Text = "";
            lblRange.Text = startYear + startMonth + "~" + endYear + endMonth;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //銷售淨額
                //get data from database
                SqlCommand cmd = new SqlCommand(query[0], conn);
                cmd.Parameters.AddWithValue("@StartDate", startYear + startMonth);
                cmd.Parameters.AddWithValue("@EndDate", endYear + endMonth);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //feed data from dataset to gridview
                grdReport.DataSource = ds;
                grdReport.DataBind();
                //feed data from dataset to chart
                Chart1.DataSource = ds;
                Chart1.Titles.Add("銷售淨額報告" + startYear + startMonth + " ~ " + endYear + endMonth);
                Chart1.Series[0].ChartType = SeriesChartType.Column;
                Chart1.Series[0].XValueMember = "業務名稱";
                Chart1.Series[0].YValueMembers = "銷貨淨額";
                Chart1.DataBind();

                //退貨金額
                cmd = new SqlCommand(query[1], conn);
                cmd.Parameters.AddWithValue("@StartDate", startYear + startMonth);
                cmd.Parameters.AddWithValue("@EndDate", endYear + endMonth);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                grdReport2.DataSource = ds;
                grdReport2.DataBind();
                Chart2.DataSource = ds;
                Chart2.Titles.Add("退貨金額報告" + startYear + startMonth + " ~ " + endYear + endMonth);
                Chart2.Series[0].ChartType = SeriesChartType.Column;
                Chart2.Series[0].XValueMember = "業務名稱";
                Chart2.Series[0].YValueMembers = "退貨金額";
                Chart2.DataBind();
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
            SqlSearch(GetQuery());
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

        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet1 = workbook.CreateSheet("銷售淨額報表" + startYear + startMonth + "~" + endYear + endMonth);
        ISheet sheet2 = workbook.CreateSheet("退貨金額報表" + startYear + startMonth + "~" + endYear + endMonth);
        IRow rowHeader1 = sheet1.CreateRow(0);
        IRow rowHeader2 = sheet2.CreateRow(0);
        IRow rowFooter1 = sheet1.CreateRow(grdReport.Rows.Count + 1);
        IRow rowFooter2 = sheet2.CreateRow(grdReport2.Rows.Count + 1);
        HSSFCellStyle headerCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
        HSSFCellStyle oddRowCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
        HSSFCellStyle evenRowCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
        HSSFFont headerFont = (HSSFFont)workbook.CreateFont();
        HSSFFont oddRowFont = (HSSFFont)workbook.CreateFont();
        HSSFFont evenRowFont = (HSSFFont)workbook.CreateFont();

        //set Header's Cell Style
        SetCustomCellColor(workbook, HSSFColor.CornflowerBlue.Index, "29ABE2");
        headerCellStyle.FillForegroundColor = HSSFColor.CornflowerBlue.Index;
        headerCellStyle.FillPattern = FillPattern.SolidForeground;
        headerFont.Color = HSSFColor.White.Index;
        headerFont.Boldweight = (short)FontBoldWeight.Bold;
        headerCellStyle.SetFont(headerFont);
        //set Odd Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.Grey25Percent.Index, "c3e8f4");
        oddRowCellStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
        oddRowCellStyle.FillPattern = FillPattern.SolidForeground;
        oddRowFont.Color = HSSFColor.Black.Index;
        oddRowCellStyle.SetFont(oddRowFont);
        //set Even Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.PaleBlue.Index, "ffffff");
        evenRowCellStyle.FillForegroundColor = HSSFColor.White.Index;
        evenRowCellStyle.FillPattern = FillPattern.SolidForeground;
        evenRowFont.Color = HSSFColor.PaleBlue.Index;
        evenRowFont.Color = HSSFColor.Black.Index;
        evenRowCellStyle.SetFont(evenRowFont);


        //grdReport資料匯入sheet1
        //sheet1 Header
        for (int i = 0, iCount = grdReport.HeaderRow.Cells.Count; i < iCount; i++)
        {
            ICell cell = rowHeader1.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdReport.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //sheet1 Body
        for (int i = 0, iCount = grdReport.Rows.Count; i < iCount; i++)
        {
            IRow rowItem = sheet1.CreateRow(i + 1);
            for (int j = 0, jCount = grdReport.HeaderRow.Cells.Count; j < jCount; j++)
            {
                ICell cell = rowItem.CreateCell(j);
                if ((i + 1) % 2 == 1)
                {
                    cell.CellStyle = oddRowCellStyle;
                }
                else
                {
                    cell.CellStyle = evenRowCellStyle;
                }
                cell.SetCellValue(grdReport.Rows[i].Cells[j].Text.Replace("&nbsp;", "").Trim());
                sheet1.AutoSizeColumn(j);
            }
            sheet1.GetRow(i).HeightInPoints = 16.5f;
        }
        //sheet1 footer
        for (int i = 0; i < grdReport.FooterRow.Cells.Count; i++)
        {
            ICell cell = rowFooter1.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdReport.FooterRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }

        //grdReport2資料匯入sheet2
        //sheet2 Header
        for (int i = 0, iCount = grdReport2.HeaderRow.Cells.Count; i < iCount; i++)
        {
            ICell cell = rowHeader2.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdReport2.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //sheet1 Body
        for (int i = 0, iCount = grdReport2.Rows.Count; i < iCount; i++)
        {
            IRow rowItem = sheet2.CreateRow(i + 1);
            for (int j = 0, jCount = grdReport2.HeaderRow.Cells.Count; j < jCount; j++)
            {
                ICell cell = rowItem.CreateCell(j);
                if ((i + 1) % 2 == 1)
                {
                    cell.CellStyle = oddRowCellStyle;
                }
                else
                {
                    cell.CellStyle = evenRowCellStyle;
                }
                cell.SetCellValue(((Label)grdReport2.Rows[i].Cells[j].FindControl("Label"+(j+3).ToString())).Text.Replace("&nbsp;", "").Trim());
                sheet2.AutoSizeColumn(j);
            }
            sheet2.GetRow(i).HeightInPoints = 16.5f;
        }
        //sheet2 footer
        for (int i = 0; i < grdReport2.FooterRow.Cells.Count; i++)
        {
            ICell cell = rowFooter2.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdReport2.FooterRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //workbook匯出至excel
        workbook.Write(ms);
        string fileName = "NetSaleReport" + startYear + startMonth + "~" + endYear + endMonth;
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + Server.UrlEncode(fileName) + ".xls"));
        Response.BinaryWrite(ms.ToArray());
        //收尾
        workbook = null;
        ms.Close();
        ms.Dispose();
    }
    private void SetCustomCellColor(HSSFWorkbook workbook, short originalColorIndex, string alternateColor)
    {
        HSSFPalette cellPalette = workbook.GetCustomPalette();
        byte CR, CG, CB;
        CR = Convert.ToByte("0x" + alternateColor.Substring(0, 2), 16);
        CG = Convert.ToByte("0x" + alternateColor.Substring(2, 2), 16);
        CB = Convert.ToByte("0x" + alternateColor.Substring(4, 2), 16);
        cellPalette.SetColorAtIndex(originalColorIndex, CR, CG, CB);
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

    protected void grdReport_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter_sum(grdReport);
    }
    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridViewAddFooter_sum(GridView _gd)
    {
        int sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 3; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum += int.Parse(_gd.Rows[j].Cells[i].Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                if (i == 3)
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW"));
                }
                else
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
                }
            }
        }
    }
    protected void grdReport2_DataBound(object sender, EventArgs e)
    {
        GridViewAddFooter2_sum(grdReport2);
    }
    protected void grdReport2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            GridviewAddFooter("小計", e);
        }
    }
    internal void GridViewAddFooter2_sum(GridView _gd)
    {
        int sum = 0;
        if (_gd.Rows.Count > 0)
        {
            for (int i = 3; i < _gd.Rows[0].Cells.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < _gd.Rows.Count; j++)
                {
                    sum += int.Parse(((Label)_gd.Rows[j].Cells[i].FindControl("Label" + (i+3).ToString())).Text, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                }
                if (i == 3)
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("C", new CultureInfo("zh-TW"));
                }
                else
                {
                    _gd.FooterRow.Cells[i].Text = sum.ToString("N0");
                }
            }
        }
    }
}