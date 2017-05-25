using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SaleRecord : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMax.Text = "";
        lblMin.Text = "";
        lblMode.Text = "";
        lblAvg.Text = "";
    }
    private string GetQuery()
    {
        string query = "";
        string condition = "";

        if (txtPrdNo.Text.Trim() != "" && txtCustName.Text.Trim() == "")
        {
            if (ckbExactProdId.Checked)
            {
                condition = " AND COPTH.TH004 = '" + txtPrdNo.Text.Trim() + "'";
            }
            else
            {
                condition = " AND COPTH.TH004 LIKE N'%" + txtPrdNo.Text.Trim() + "%'";
            }
        }
        else if (txtPrdNo.Text.Trim() == "" && txtCustName.Text.Trim() != "")
        {
            condition = " AND COPTG.TG007 LIKE N'%" + txtCustName.Text.Trim() + "%'";
        }
        else if (txtPrdNo.Text.Trim() != "" && txtCustName.Text.Trim() != "")
        {
            condition = " AND COPTH.TH004 LIKE N'%" + txtPrdNo.Text.Trim() + "%' AND COPTG.TG007 LIKE N'%" + txtCustName.Text.Trim() + "%'";
        }

        query = "SELECT COPTG.TG042 AS 銷貨日期, COPTG.TG004 AS 客戶代號, COPMA.MA002 AS 客戶簡稱, COPTH.TH004 AS 品號, COPTH.TH005 AS 品名"
            + " , CAST(CAST(COPTH.TH008 AS NUMERIC(10,2)) AS VARCHAR) AS 數量,COPTH.TH009 AS '單位', CAST(COPTH.TH012*COPTG.TG012 AS NUMERIC(10,4)) AS 單價"
            + " FROM COPTG"
            + " LEFT JOIN COPMA ON COPTG.TG004 = COPMA.MA001"
            + " LEFT JOIN COPTH ON COPTG.TG002 = COPTH.TH002 AND COPTG.TG001 = COPTH.TH001"
            + " WHERE COPTG.TG023 = N'Y' AND COPTG.TG042 >= N'" + txtStartDate.Text + "' AND COPTG.TG042 <= N'" + txtEndDate.Text + "'"
            + condition
            + " ORDER BY COPTH.TH004, COPTG.TG004, COPTG.TG042 DESC";        

        return query;
    }

    private void SqlSearch(string query)
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
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtStartDate.Text.ToString()) && String.IsNullOrEmpty(txtEndDate.Text.ToString()))
        {
            lblError.Text = "請選擇起始與結束日期";
        }
        else if (String.IsNullOrEmpty(txtStartDate.Text.ToString()))
        {
            lblError.Text = "請選擇起始日期";
        }
        else if (String.IsNullOrEmpty(txtEndDate.Text.ToString()))
        {
            lblError.Text = "請選擇結束日期";
        }
        else if (Convert.ToInt32(txtStartDate.Text) > Convert.ToInt32(txtEndDate.Text))
        {
            lblError.Text = "結束日期必須大於或等於起始日期";
        }
        else if (Convert.ToInt32(txtEndDate.Text) > Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")))
        {
            lblError.Text = "結束日期不可大於今日日期";
        }
        else
        {
            lblError.Text = "";
            lblRange.Text = "查詢期間: " + txtStartDate.Text + " ~ " + txtEndDate.Text;
            SqlSearch(GetQuery());
            calculate();
        }
        
    }

    private void calculate()
    {
        List<decimal> price = new List<decimal>();
        
        
        for (int i = 0; i < grdReport.Rows.Count; i++)
        {
            if (Convert.ToDecimal(grdReport.Rows[i].Cells[7].Text) > 0)
            {
                price.Add(Convert.ToDecimal(grdReport.Rows[i].Cells[7].Text));
            }
        }
        if (price.Count > 0)
        {
            lblMax.Text = price.Max().ToString();
            lblMin.Text = price.Min().ToString();
            lblMode.Text = (price.GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).Select(x => (decimal?)x.Key).FirstOrDefault()).ToString();
            lblAvg.Text = Math.Round(price.Average(), 4).ToString();
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
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet1 = workbook.CreateSheet("銷售商品單價明細" + txtStartDate.Text + "~" + txtEndDate.Text);
        IRow rowHeader1 = sheet1.CreateRow(0);
        IRow rowFooter1 = sheet1.CreateRow(grdReport.Rows.Count + 1);
        HSSFCellStyle headerCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
        HSSFCellStyle oddRowCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
        HSSFCellStyle evenRowCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
        HSSFFont headerFont = (HSSFFont)workbook.CreateFont();
        HSSFFont oddRowFont = (HSSFFont)workbook.CreateFont();
        HSSFFont evenRowFont = (HSSFFont)workbook.CreateFont();

        //set Header's Cell Style
        SetCustomCellColor(workbook, HSSFColor.CornflowerBlue.Index, "5D7B9D");
        headerCellStyle.FillForegroundColor = HSSFColor.CornflowerBlue.Index;
        headerCellStyle.FillPattern = FillPattern.SolidForeground;
        headerFont.Color = HSSFColor.White.Index;
        headerFont.Boldweight = (short)FontBoldWeight.Bold;
        headerCellStyle.SetFont(headerFont);
        //set Odd Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.Grey25Percent.Index, "F7F6F3");
        oddRowCellStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
        oddRowCellStyle.FillPattern = FillPattern.SolidForeground;
        oddRowFont.Color = HSSFColor.Black.Index;
        oddRowCellStyle.SetFont(oddRowFont);
        //set Even Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.PaleBlue.Index, "284775");
        evenRowCellStyle.FillForegroundColor = HSSFColor.White.Index;
        evenRowCellStyle.FillPattern = FillPattern.SolidForeground;
        evenRowFont.Color = HSSFColor.PaleBlue.Index;
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
        string fileName = "SaleItemPrice" + txtStartDate.Text + "~" + txtEndDate.Text;
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