﻿using NPOI.HSSF.UserModel;
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

public partial class nizing_intranet_M01 : System.Web.UI.Page
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
            ddlStartYear.SelectedIndex = 0;
            ddlEndYear.SelectedIndex = 0;
        }
    }
    //protected void R1_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (rdoYear.Checked == true)
    //    {
    //        ddlMonth.Enabled = false;
    //        ddlMonth.Visible = false;
    //    }
    //    else
    //    {
    //        ddlMonth.Enabled = true;
    //        ddlMonth.Visible = true;
    //    }
    //}
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT *"
                                                    + " FROM"
                                                    + " ("
                                                    + " SELECT MOCTF.TF011 ProductionLine, SUBSTRING(MOCTF.TF003,1,4) YR, SUBSTRING(MOCTF.TF003,5,2) MN, CONVERT(INT, SUM(MOCTG.TG011)) ProductionAmount"
                                                    + " FROM MOCTF"
                                                    + " LEFT JOIN MOCTG ON MOCTF.TF001 = MOCTG.TG001 AND MOCTF.TF002 = MOCTG.TG002"
                                                    + " WHERE MOCTF.TF006 = N'Y' AND MOCTF.TF011 <> N'SM' AND SUBSTRING(MOCTF.TF003,1,4) BETWEEN @START AND @END"
                                                    + " GROUP BY MOCTF.TF011, SUBSTRING(MOCTF.TF003,5,2), SUBSTRING(MOCTF.TF003,1,4)"
                                                    + " ) AS PROD"
                                                    + " PIVOT"
                                                    + " ("
                                                    + " SUM(ProductionAmount)"
                                                    + " FOR"
                                                    + " MN IN ([01], [02], [03], [04], [05], [06], [07], [08], [09], [10], [11], [12])"
                                                    + " )"
                                                    + " AS PIVOTTABLE"
                                                    + " ORDER BY ProductionLine, YR", conn);
                cmdSelect.Parameters.AddWithValue("@START", ddlStartYear.SelectedValue);
                cmdSelect.Parameters.AddWithValue("@END", ddlEndYear.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdProduction.DataSource = dt;
                grdProduction.DataBind();
            }            
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }

    }
    protected void grdProduction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double jan = 0;
            double feb = 0;
            double mar = 0;
            double apr = 0;
            double may = 0;
            double june = 0;
            double july = 0;
            double aug = 0;
            double sep = 0;
            double oct = 0;
            double nov = 0;
            double dec = 0;

            if (!double.TryParse(((Label)e.Row.FindControl("lbl3")).Text, out jan))
            {
                jan = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl4")).Text, out feb))
            {
                feb = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl5")).Text, out mar))
            {
                mar = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl6")).Text, out apr))
            {
                apr = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl7")).Text, out may))
            {
                may = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl8")).Text, out june))
            {
                june = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl9")).Text, out july))
            {
                july = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl10")).Text, out aug))
            {
                aug = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl11")).Text, out sep))
            {
                sep = 0;

            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl12")).Text, out oct))
            {
                oct = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl13")).Text, out nov))
            {
                nov = 0;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl14")).Text, out dec))
            {
                dec = 0;
            }

            ((Label)e.Row.FindControl("lbl15")).Text = Math.Round((jan + feb + mar + apr + may + june + july + aug + sep + oct + nov + dec), 2).ToString();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdProduction.Rows.Count == 0)
            {
                lblErrorMessage.Text = "請先產生報表才能執行匯出";
            }
            else
            {
                lblErrorMessage.Text = "";
                Export_Excel();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    private void Export_Excel()
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet1 = workbook.CreateSheet("生產統計表" + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue);
        IRow rowHeader1 = sheet1.CreateRow(0);
        IRow rowFooter1 = sheet1.CreateRow(grdProduction.Rows.Count + 1);
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
        headerCellStyle.Alignment = HorizontalAlignment.Center;
        headerFont.Color = HSSFColor.White.Index;
        headerFont.Boldweight = (short)FontBoldWeight.Bold;        
        headerCellStyle.SetFont(headerFont);
        //set Odd Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.Grey25Percent.Index, "c3e8f4");
        oddRowCellStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
        oddRowCellStyle.FillPattern = FillPattern.SolidForeground;
        oddRowCellStyle.Alignment = HorizontalAlignment.Center;
        oddRowFont.Color = HSSFColor.Black.Index;
        oddRowCellStyle.SetFont(oddRowFont);
        //set Even Row's Cell Style
        SetCustomCellColor(workbook, HSSFColor.PaleBlue.Index, "ffffff");
        evenRowCellStyle.FillForegroundColor = HSSFColor.White.Index;
        evenRowCellStyle.FillPattern = FillPattern.SolidForeground;
        evenRowCellStyle.Alignment = HorizontalAlignment.Center;
        evenRowFont.Color = HSSFColor.PaleBlue.Index;
        evenRowFont.Color = HSSFColor.Black.Index;
        evenRowCellStyle.SetFont(evenRowFont);


        //grdReport資料匯入sheet1
        //sheet1 Header
        for (int i = 0, iCount = grdProduction.HeaderRow.Cells.Count; i < iCount; i++)
        {
            ICell cell = rowHeader1.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdProduction.HeaderRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }
        //sheet1 Body
        for (int i = 0, iCount = grdProduction.Rows.Count; i < iCount; i++)
        {
            IRow rowItem = sheet1.CreateRow(i + 1);
            for (int j = 0, jCount = grdProduction.HeaderRow.Cells.Count; j < jCount; j++)
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
                cell.SetCellValue(((Label)grdProduction.Rows[i].Cells[j].FindControl("lbl" + (j+1).ToString())).Text.Replace("&nbsp;", "").Trim());
                sheet1.AutoSizeColumn(j);
            }
            sheet1.GetRow(i).HeightInPoints = 16.5f;
        }
        //sheet1 footer
        for (int i = 0; i < grdProduction.FooterRow.Cells.Count; i++)
        {
            ICell cell = rowFooter1.CreateCell(i);
            cell.CellStyle = headerCellStyle;
            cell.SetCellValue(grdProduction.FooterRow.Cells[i].Text.Replace("&nbsp;", "").Trim());
        }

        //workbook匯出至excel
        workbook.Write(ms);
        string fileName = "ProductionReport" + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue;
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