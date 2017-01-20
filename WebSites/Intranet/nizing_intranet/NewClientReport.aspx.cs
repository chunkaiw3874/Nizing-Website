using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System.IO;

public partial class NewClientReport : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtStartDate.Text.ToString()) || String.IsNullOrEmpty(txtEndDate.Text.ToString()))
        {
            lblError.Text = "請選擇起始與結束日期";
        }
        else if(Convert.ToInt32(txtStartDate.Text) > Convert.ToInt32(txtEndDate.Text))
        {
            lblError.Text = "起始日期不可大於結束日期";
        }
        else
        {
            lblError.Text = "";
            lblRange.Text = "查詢期間: " + txtStartDate.Text + " ~ " + txtEndDate.Text;
            SqlSearch(GetQuery());
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdDetail == null)
            {
                lblError.Text = "請先產生報表才能執行匯出";
            }
            else
            {
                Export_Excel();
            }
        }
        catch (Exception ex)
        {
            //handles exceptions
        }
    }

    protected string[] GetQuery()
    {
        string[] query = new string[2];

        query[0] = "SELECT MA.CREATE_DATE 建立日期, MA.MA001 客戶代號, MA.MA002 客戶名稱, MA.MA016 業務代號, MV.MV002 業務名稱"
                    + " FROM COPMA MA"
                    + " INNER JOIN CMSMV MV ON MA.MA016 = MV.MV001"
                    + " WHERE MA.CREATE_DATE BETWEEN N'" + txtStartDate.Text + "' AND N'" + txtEndDate.Text + "'"
                    + " ORDER BY MA.CREATE_DATE, MA.MA001";
        query[1] = "SELECT MV.MV002 業務名稱, COUNT(MA.MA016) 新客戶數"
                    + " FROM COPMA MA"
                    + " INNER JOIN CMSMV MV ON MA.MA016 = MV.MV001"
                    + " WHERE MA.CREATE_DATE BETWEEN N'" + txtStartDate.Text + "' AND N'" + txtEndDate.Text + "'"
                    + " GROUP BY MV.MV002";
        return query;
    }

    private void SqlSearch(string[] query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query[0], conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdDetail.DataSource = ds;
            grdDetail.DataBind();

            cmd = new SqlCommand(query[1], conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            grdSum.DataSource = ds;
            grdSum.DataBind();
        }
    }

    private void Export_Excel()
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet1 = workbook.CreateSheet("新客戶建立日期");
        ISheet sheet2 = workbook.CreateSheet("新客戶數");
        IRow rowHeader1 = sheet1.CreateRow(0);
        IRow rowHeader2 = sheet2.CreateRow(0);
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
                    

        //grdDetail資料匯入sheet1
        //sheet1 Header
        for(int i = 0, iCount = grdDetail.HeaderRow.Cells.Count; i < iCount; i++)
        {
            ICell cell = rowHeader1.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdDetail.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //sheet1 Body
        for(int i = 0, iCount = grdDetail.Rows.Count; i<iCount; i++)
        {
            IRow rowItem = sheet1.CreateRow(i + 1);
            for(int j=0, jCount = grdDetail.HeaderRow.Cells.Count; j<jCount; j++)
            {
                ICell cell = rowItem.CreateCell(j);
                if((i+1) % 2 == 1)
                {
                    cell.CellStyle = oddRowCellStyle;
                }
                else
                {
                    cell.CellStyle = evenRowCellStyle;
                }
                cell.SetCellValue(grdDetail.Rows[i].Cells[j].Text.Replace("&nbsp;", "").Trim());
                sheet1.AutoSizeColumn(j);
            }
            sheet1.GetRow(i).HeightInPoints = 16.5f;
        }

        //grdSum資料匯入sheet2
        //sheet2 header
        for (int i = 0, iCount = grdSum.HeaderRow.Cells.Count; i < iCount; i++)
        {
            ICell cell = rowHeader2.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdSum.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //sheet2 body
        for (int i = 0, iCount = grdSum.Rows.Count; i < iCount; i++)
        {
            IRow rowItem = sheet2.CreateRow(i + 1);
            for (int j = 0, jCount = grdSum.HeaderRow.Cells.Count; j < jCount; j++)
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
                cell.SetCellValue(grdSum.Rows[i].Cells[j].Text.Replace("&nbsp;", "").Trim());
                sheet2.AutoSizeColumn(j);
            }
            sheet2.GetRow(i).HeightInPoints = 16.5f;
        }

        //workbook匯出至excel
        workbook.Write(ms);
        string fileName = "NewClientReport" + txtStartDate.Text + "~" + txtEndDate.Text;
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
}