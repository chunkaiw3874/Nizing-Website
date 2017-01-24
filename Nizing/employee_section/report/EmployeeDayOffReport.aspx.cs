﻿using NPOI.HSSF.UserModel;
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

public partial class EmployeeDayOffReport : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    static string fileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            btnReport_Click(sender, e);
        }
    }


    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //private void SqlSearch(string query)
    //{
    //    using (SqlConnection conn = new SqlConnection(connectionString))
    //    {
    //        conn.Open();

    //        SqlCommand cmd = new SqlCommand(query, conn);
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        grdReport.DataSource = ds;
    //        grdReport.DataBind();
    //    }
    //}

    //private string GetQuery()
    //{
    //    string query = "SELECT *"
    //                    + " FROM"
    //                    + " ("
    //                    + " SELECT CMSMV.MV001 員工代號, CMSMV.MV002 員工名稱, PALMC.MC002 假別名稱, (PALTL.TL006+PALTL.TL007) 請假天數"
    //                    + " FROM PALTL"
    //                    + " RIGHT JOIN PALMC ON PALTL.TL004 = PALMC.MC001 "
    //                    + " RIGHT JOIN CMSMV ON PALTL.TL001 = CMSMV.MV001 AND PALTL.TL002 = " + ddlYear.SelectedValue.ToString()
    //                    + " WHERE (CMSMV.MV022 = 0 AND (CAST(SUBSTRING(CMSMV.MV021,1,4) AS INT) <= " + ddlYear.SelectedValue.ToString() + ")) OR (CAST(SUBSTRING(CMSMV.MV022,1,4) AS INT) >= " + ddlYear.SelectedValue.ToString() + " AND CAST(SUBSTRING(CMSMV.MV021,1,4) AS INT) <= " + ddlYear.SelectedValue.ToString() + ")"
    //                    + " ) AS S"
    //                    + " PIVOT"
    //                    + " ("
    //                    + " SUM(請假天數)"
    //                    + " FOR 假別名稱 IN ([特休], [病假], [事假], [婚假], [喪假], [產假], [陪產假], [曠職], [颱風假], [公假], [公休假], [公傷假], [產檢假])"
    //                    + " ) AS PIVOTTABLE"
    //                    + " ORDER BY 員工代號";
    //    return query;
    //}
    protected void btnReport_Click(object sender, EventArgs e)
    {
        lblScope.Text = ddlYear.SelectedValue.ToString() + "年度員工請假紀錄";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM ("
+ " SELECT CMSMV.MV001 [EMPLOYEE_ID]"
+ " , CMSMV.MV002 [EMPLOYEE_NAME]"
+ " , PALTK.TK002"
+ " , CONVERT(NVARCHAR,CONVERT(DECIMAL(4,0),PALTK.TK003))+N' / '+CONVERT(NVARCHAR,PALTK.TK003*8) [DAYOFF_TOTAL]"
+ " , PALMC.MC001 [DAYOFF_ID]"
+ " , (PALTL.TL006+PALTL.TL007) [DAYOFF_DAYS] "
+ " FROM CMSMV"
+ " LEFT JOIN PALTK ON CMSMV.MV001 = PALTK.TK001 AND PALTK.TK002 = @YEAR"
+ " LEFT JOIN PALTL ON PALTK.TK001 = PALTL.TL001 AND PALTL.TL002 = @YEAR"
+ " LEFT JOIN PALMC ON PALTL.TL004 = PALMC.MC001 "
+ " WHERE"
+ " (CMSMV.MV022 = 0 AND (CAST(SUBSTRING(CMSMV.MV021,1,4) AS INT) <= @YEAR)) "
+ " OR "
+ " (CAST(SUBSTRING(CMSMV.MV022,1,4) AS INT) >= @YEAR "
+ " AND CAST(SUBSTRING(CMSMV.MV021,1,4) AS INT) <= @YEAR) ) AS S PIVOT ( SUM([DAYOFF_DAYS]) FOR [DAYOFF_ID] IN ([03], [04], [05], [06], [07], [08], [09], [10], [11], [12], [13], [14], [15]) ) AS PIVOTTABLE", conn);
            cmdSelect.Parameters.AddWithValue("@YEAR", ddlYear.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grdReport.DataSource = dt;
            grdReport.DataBind();
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
        ISheet sheet1 = workbook.CreateSheet(ddlYear.SelectedValue.ToString()+"年度請假報表");
        IRow rowHeader1 = sheet1.CreateRow(0);
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
        headerCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        headerCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        headerCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
        headerCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        headerFont.Color = HSSFColor.White.Index;
        headerFont.Boldweight = (short)FontBoldWeight.Bold;
        headerCellStyle.SetFont(headerFont);
        //set Odd Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.Grey25Percent.Index, "F7F6F3");
        oddRowCellStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
        oddRowCellStyle.FillPattern = FillPattern.SolidForeground;
        oddRowCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        oddRowCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        oddRowCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
        oddRowCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        oddRowFont.Color = HSSFColor.Black.Index;
        oddRowCellStyle.SetFont(oddRowFont);
        //set Even Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.PaleBlue.Index, "284775");
        evenRowCellStyle.FillForegroundColor = HSSFColor.White.Index;
        evenRowCellStyle.FillPattern = FillPattern.SolidForeground;
        evenRowCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        evenRowCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        evenRowCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
        evenRowCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
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

        //workbook匯出至excel
        workbook.Write(ms);
        string fileName = ddlYear.SelectedValue.ToString() + "年度請假報表";
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

    //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    //{

    //    GridViewRow row = e.Row;
    //    // Intitialize TableCell list
    //    List<TableCell> columns = new List<TableCell>();
    //    foreach (DataControlField column in grdReport.Columns)
    //    {
    //        //Get the first Cell /Column
    //        TableCell cell = row.Cells[0];
    //        // Then Remove it after
    //        row.Cells.Remove(cell);
    //        //And Add it to the List Collections
    //        columns.Add(cell);
    //    }

    //    // Add cells
    //    row.Cells.AddRange(columns.ToArray());
    //}

    protected void grdReport_PreRender(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdReport.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                decimal sum = 0;
                decimal label4 = 0;
                decimal label5 = 0;
                decimal label6 = 0;
                decimal label7 = 0;
                decimal label8 = 0;
                decimal label9 = 0;
                decimal label10 = 0;
                decimal label11 = 0;
                decimal label12 = 0;
                decimal label13 = 0;
                decimal label14 = 0;
                decimal label15 = 0;
                if (decimal.TryParse((row.Cells[3].FindControl("Label4") as Label).Text.ToString(), out label4))
                {
                    sum += label4;
                }
                else
                {
                    sum += label4;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label5") as Label).Text.ToString(), out label5))
                {
                    sum += label5;
                }
                else
                {
                    sum += label5;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label6") as Label).Text.ToString(), out label6))
                {
                    sum += label6;
                }
                else
                {
                    sum += label6;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label7") as Label).Text.ToString(), out label7))
                {
                    sum += label7;
                }
                else
                {
                    sum += label7;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label8") as Label).Text.ToString(), out label8))
                {
                    sum += label8;
                }
                else
                {
                    sum += label8;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label9") as Label).Text.ToString(), out label9))
                {
                    sum += label9;
                }
                else
                {
                    sum += label9;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label10") as Label).Text.ToString(), out label10))
                {
                    sum += label10;
                }
                else
                {
                    sum += label10;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label11") as Label).Text.ToString(), out label11))
                {
                    sum += label11;
                }
                else
                {
                    sum += label11;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label12") as Label).Text.ToString(), out label12))
                {
                    sum += label12;
                }
                else
                {
                    sum += label12;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label13") as Label).Text.ToString(), out label13))
                {
                    sum += label13;
                }
                else
                {
                    sum += label13;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label14") as Label).Text.ToString(), out label14))
                {
                    sum += label14;
                }
                else
                {
                    sum += label14;
                }
                if (decimal.TryParse((row.Cells[3].FindControl("Label15") as Label).Text.ToString(), out label15))
                {
                    sum += label15;
                }
                else
                {
                    sum += label15;
                }
                (row.Cells[row.Cells.Count - 1].FindControl("lblRowSum") as Label).Text = sum.ToString();
            }
        }
    }
    protected void grdReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView ProductGrid = (GridView)sender;
            
            //Creating a Row
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                        
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "基本資料";
            HeaderCell.Font.Size = 14;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "特休天數";
            HeaderCell.Font.Size = 14;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "非特休已休時數";
            HeaderCell.Font.Size = 14;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 13;
            HeaderRow.Cells.Add(HeaderCell);
            
            //Adding the Row at the 0th position (first row) in the Grid
            ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);            
        }
    }
}