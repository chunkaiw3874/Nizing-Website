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
using System.Web.UI.WebControls;

public partial class WorkDuration : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtEndDate.Text))
        {
            lblScope.Text = "";
            lblError.Text = "結束日期不可為空白";
        }
        else if (CheckDate(txtEndDate.Text)==false)
        {
            lblScope.Text = "";
            lblError.Text = "請使用正確的日期格式YYYYMMDD";
        }
        else
        {
            lblError.Text = "";
            lblScope.Text = "員工年資 - 截至" + txtEndDate.Text;
            SqlSearch(GetQuery());
        }
    }

    protected void SqlSearch(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            //get data from database
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //feed data from dataset to gridview
            grdReport.DataSource = ds;
            grdReport.DataBind();
        }
    }
    protected string GetQuery()
    {
        string query = "";

        if (chkDisplay.Checked == false)
        {
            query = "SELECT CMSMV.MV002 員工姓名, CMSMV.MV021 到職日, CMSMV.MV022 離職日, CONVERT(DECIMAL(5,2), CONVERT(DECIMAL(7,2), DATEDIFF(DAY, CMSMV.MV021, N'" + txtEndDate.Text + "'))/365) 年資"
                    + " FROM CMSMV"
                    + " WHERE CMSMV.MV022 = N''";
        }
        else
        {
            query = "SELECT CMSMV.MV002 員工姓名, CMSMV.MV021 到職日, CMSMV.MV022 離職日"
                    + " ,CASE"
                    + " WHEN CMSMV.MV022 = N'' THEN CONVERT(DECIMAL(5,2), CONVERT(DECIMAL(7,2), DATEDIFF(DAY, CMSMV.MV021, N'" + txtEndDate.Text + "'))/365)"
                    + " WHEN CMSMV.MV022 < N'" + txtEndDate.Text + "' THEN CONVERT(DECIMAL(5,2), CONVERT(DECIMAL(7,2), DATEDIFF(DAY, CMSMV.MV021, CMSMV.MV022))/365)"
                    + " ELSE CONVERT(DECIMAL(5,2), CONVERT(DECIMAL(7,2), DATEDIFF(DAY, CMSMV.MV021, N'" + txtEndDate.Text + "'))/365)"
                    + " END AS 年資"
                    + " ,CASE CMSMV.MV022"
                    + " WHEN N'' THEN N''"
                    + " ELSE N'已離職'"
                    + " END AS 是否在職"
                    + " FROM CMSMV"
                    + " WHERE CMSMV.MV021 <= N'" + txtEndDate.Text + "'";

        }

        return query;
    }
    private void Export_Excel()
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet1 = workbook.CreateSheet("年資" + txtEndDate.Text);
        IRow rowHeader1 = sheet1.CreateRow(0);
        IRow rowFooter1 = sheet1.CreateRow(grdReport.Rows.Count + 1);
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

        //workbook匯出至excel
        workbook.Write(ms);
        string fileName = "Seniority" + txtEndDate.Text;
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

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export_Excel();
    }
    protected bool CheckDate(String date)
    {
        DateTime d;
        return DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
    }
}