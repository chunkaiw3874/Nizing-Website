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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;

public partial class CustomerTransactionReport : System.Web.UI.Page
{
    DateTime eom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month));
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlStartYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                ddlEndYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());               
            }
            ddlStartYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlEndYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlEndMonth.SelectedValue = eom.ToString("MMdd");
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        DataTable dt = getDataTable();
        grdReport.DataSource = dt;
        grdReport.DataBind();
        for (int i = 0; i < grdReport.Columns.Count; i++)
        {
            if (i > 0)
            {
                grdReport.Columns[i].ItemStyle.Width = new Unit(1000, UnitType.Pixel);
            }
        }
    }

    private DataTable getDataTable()
    {
        string query = "";
        string startYear = "";
        string condition = "";
        string includeNoSalesRecord = " WHERE COPTG.TG042 IS NOT NULL";
        if (ddlStartMonth.SelectedItem.Text == "01")
        {
            startYear = (Convert.ToInt16(ddlStartYear.SelectedItem.Text) - 1).ToString();
        }
        else
        {
            startYear = ddlStartYear.SelectedItem.Text;
        }
        if (ddlPersonnel.SelectedItem.Text != "全部人員")
        {
            condition = " WHERE SALENAME = N'" + ddlPersonnel.SelectedItem.Text + "'";
        }
        if (ckxIncludeNoSaleRecord.Checked == true)
        {
            includeNoSalesRecord = "";
        }
        query = "SELECT *,(ISNULL([01],0)+ISNULL([02],0)+ISNULL([03],0)+ISNULL([04],0)+ISNULL([05],0)+ISNULL([06],0)+ISNULL([07],0)+ISNULL([08],0)+ISNULL([09],0)+ISNULL([10],0)+ISNULL([11],0)+ISNULL([12],0)) TOTAL"
+ " FROM"
+ " ("
+ " SELECT"
+ " CASE"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'12' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN SUBSTRING(COPTG.TG042,1,4)+1"
+ " ELSE SUBSTRING(COPTG.TG042, 1, 4)"
+ " END YR"
+ " , CASE"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'01' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'01'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'12' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'01'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'02' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'02'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'01' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'02'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'03' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'03'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'02' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'03'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'04' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'04'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'03' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'04'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'05' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'05'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'04' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'05'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'06' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'06'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'05' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'06'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'07' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'07'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'06' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'07'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'08' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'08'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'07' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'08'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'09' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'09'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'08' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'09'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'10' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'10'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'09' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'10'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'11' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'11'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'10' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'11'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'12' AND SUBSTRING(COPTG.TG042,7,2)<=N'25' THEN N'12'"
+ " WHEN SUBSTRING(COPTG.TG042,5,2)=N'11' AND SUBSTRING(COPTG.TG042,7,2)>=N'26' THEN N'12'"
+ " END MN"
+ " , COPMA.MA001 CLIENTNO, COPMA.MA002 CLIENTNAME, CONVERT(DECIMAL(10,2),COALESCE(COPTG.TG045,0)) AMT,CMSMV.MV001 SALEID, CMSMV.MV002 SALENAME"
+ " FROM COPMA"
+ " LEFT JOIN COPTG ON COPMA.MA001 = COPTG.TG004 AND COPTG.TG042 BETWEEN N'" + startYear + ddlStartMonth.SelectedValue + "' AND N'" + ddlEndYear.SelectedItem.Text + ddlEndMonth.SelectedValue + "'"
+ " LEFT JOIN CMSMV ON COPMA.MA016 = CMSMV.MV001"
+ includeNoSalesRecord
+ " ) AS S"
+ " PIVOT"
+ " ("
+ " SUM(AMT)"
+ " FOR MN IN ([01], [02], [03], [04], [05], [06], [07], [08], [09], [10], [11], [12])"
+ " ) AS PIVOTTABLE"
+ condition
+ " ORDER BY CLIENTNO";
        DataSet ds = SqlSearch(query);
        return ds.Tables[0];
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
        SLDocument slCTR = new SLDocument();
        string fileName = "test";
        string fileExt = ".xlsx";
        //header
        for (int i = 0; i < grdReport.HeaderRow.Cells.Count; i++)
        {
            if (grdReport.HeaderRow.Cells[i].Controls.Count > 0)
            {
                
            }
            slCTR.SetCellValue(1, i + 1, grdReport.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //for (int i = 0; i < grdReport.Rows.Count; i++)
        //{
        //    for (int j = 0; j < grdReport.Columns.Count; j++)
        //    {
        //        slCTR.SetCellValue(i, j, grdReport.Rows[i].Cells[j].Text.Trim());
        //    }
        //}

        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + fileExt);
        slCTR.SaveAs(Response.OutputStream);
        Response.End();
    }
    //private void Export_Excel()
    //{
    //    string startYear = "";
    //    if (ddlStartMonth.SelectedItem.Text == "01")
    //    {
    //        startYear = Convert.ToString(Convert.ToInt16(ddlStartYear.SelectedValue) - 1);
    //    }
    //    else
    //    {
    //        startYear = ddlStartYear.Text;
    //    }
    //    //Response.ClearContent();
    //    //Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
    //    //string excelFileName = "CustomerTransactionReport" + startYear + ddlStartMonth.Text + "~" + ddlEndYear.Text + ddlEndMonth.Text + ".xls";
    //    //Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
    //    //Response.ContentType = "application/excel";
    //    //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //    //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    //    //grdReport.RenderControl(htmlWrite);
    //    //Response.Write(stringWrite.ToString());
    //    //Response.End();
        
        
    //    HSSFWorkbook workbook = new HSSFWorkbook();
    //    MemoryStream ms = new MemoryStream();        
    //    ISheet sheet1 = workbook.CreateSheet("客戶交易情況" + startYear + ddlStartMonth.Text + "~" + ddlEndYear.Text + ddlEndMonth.Text);
    //    IRow rowHeader1 = sheet1.CreateRow(0);
    //    //IRow rowFooter1 = sheet1.CreateRow(grdReport.Rows.Count + 1);
    //    HSSFCellStyle headerCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
    //    HSSFCellStyle oddRowCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
    //    HSSFCellStyle evenRowCellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
    //    HSSFFont headerFont = (HSSFFont)workbook.CreateFont();
    //    HSSFFont oddRowFont = (HSSFFont)workbook.CreateFont();
    //    HSSFFont evenRowFont = (HSSFFont)workbook.CreateFont();

    //    //set Header's Cell Style
    //    SetCustomCellColor(workbook, HSSFColor.CornflowerBlue.Index, "29ABE2");
    //    headerCellStyle.FillForegroundColor = HSSFColor.CornflowerBlue.Index;
    //    headerCellStyle.FillPattern = FillPattern.SolidForeground;
    //    headerFont.Color = HSSFColor.White.Index;
    //    headerFont.Boldweight = (short)FontBoldWeight.Bold;
    //    headerCellStyle.SetFont(headerFont);
    //    //set Odd Row's Cell Style
    //    SetCustomCellColor(workbook, HSSFColor.Grey25Percent.Index, "c3e8f4");
    //    oddRowCellStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
    //    oddRowCellStyle.FillPattern = FillPattern.SolidForeground;
    //    oddRowFont.Color = HSSFColor.Black.Index;
    //    oddRowCellStyle.SetFont(oddRowFont);
    //    //set Even Row's Cell Style
    //    SetCustomCellColor(workbook, HSSFColor.PaleBlue.Index, "ffffff");
    //    evenRowCellStyle.FillForegroundColor = HSSFColor.White.Index;
    //    evenRowCellStyle.FillPattern = FillPattern.SolidForeground;
    //    evenRowFont.Color = HSSFColor.PaleBlue.Index;
    //    evenRowFont.Color = HSSFColor.Black.Index;
    //    evenRowCellStyle.SetFont(evenRowFont);


    //    //grdReport資料匯入sheet1
    //    //sheet1 Header
    //    for (int i = 0, iCount = grdReport.HeaderRow.Cells.Count; i < iCount; i++)
    //    {
    //        ICell cell = rowHeader1.CreateCell(i);
    //        cell.CellStyle = headerCellStyle;
    //        cell.SetCellValue(grdReport.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
    //    }
    //    //sheet1 Body
    //    for (int i = 0, iCount = grdReport.Rows.Count; i < iCount; i++)
    //    {
    //        IRow rowItem = sheet1.CreateRow(i + 1);
    //        for (int j = 0, jCount = grdReport.HeaderRow.Cells.Count; j < jCount; j++)
    //        {
    //            ICell cell = rowItem.CreateCell(j);
    //            if ((i + 1) % 2 == 1)
    //            {
    //                cell.CellStyle = oddRowCellStyle;
    //            }
    //            else
    //            {
    //                cell.CellStyle = evenRowCellStyle;
    //            }
    //            //cell.SetCellValue(grdReport.Rows[i].Cells[j].Text.Replace("&nbsp;", "").Trim());
    //            cell.SetCellValue(((Label)grdReport.Rows[i].Cells[j].FindControl("Label" + (j + 4).ToString())).Text.Replace("&nbsp;", "").Trim());
    //            sheet1.AutoSizeColumn(j);
    //        }
    //        sheet1.GetRow(i).HeightInPoints = 16.5f;
    //    }
    //    //sheet1 footer
    //    //for (int i = 0; i < grdReport.FooterRow.Cells.Count; i++)
    //    //{
    //    //    ICell cell = rowFooter1.CreateCell(i);
    //    //    cell.CellStyle = headerCellStyle;
    //    //    cell.SetCellValue(grdReport.FooterRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
    //    //}

    //    //workbook匯出至excel
    //    workbook.Write(ms);
    //    string fileName = "CustomerTransactionReport" + startYear + ddlStartMonth.Text + "~" + ddlEndYear.Text + ddlEndMonth.Text;
    //    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + Server.UrlEncode(fileName) + ".xls"));
    //    Response.BinaryWrite(ms.ToArray());
    //    //收尾
    //    workbook = null;
    //    ms.Close();
    //    ms.Dispose();
    //}
    private void SetCustomCellColor(HSSFWorkbook workbook, short originalColorIndex, string alternateColor)
    {
        HSSFPalette cellPalette = workbook.GetCustomPalette();
        byte CR, CG, CB;
        CR = Convert.ToByte("0x" + alternateColor.Substring(0, 2), 16);
        CG = Convert.ToByte("0x" + alternateColor.Substring(2, 2), 16);
        CB = Convert.ToByte("0x" + alternateColor.Substring(4, 2), 16);
        cellPalette.SetColorAtIndex(originalColorIndex, CR, CG, CB);
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
    //}
    protected void grdReport_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdReport.Rows)
        {
            for (int i = 4; i < row.Cells.Count; i++)
            {
                if (((Label)row.Cells[i].FindControl("Label"+(i+4).ToString())).Text == "0.00")
                {
                    ((Label)row.Cells[i].FindControl("Label" + (i + 4).ToString())).Text = "-";
                }
            }
        }
    }
    protected void grdReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        string direction = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            direction = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            direction = " ASC";
        }
        DataTable table = getDataTable();
        table.DefaultView.Sort = sortExpression + direction;
        grdReport.DataSource = table;
        grdReport.DataBind();

    }
    public SortDirection SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirection"];
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }
}