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

public partial class ProductionEfficiencyReport : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    static string fileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > (2013 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlStartYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                ddlEndYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlStartYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlEndYear.SelectedValue = DateTime.Today.Year.ToString();
        }
    }
    protected void R1_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoYear.Checked == true)
        {
            ddlStartMonth.Enabled = false;
            ddlStartMonth.Visible = false;
            ddlEndMonth.Enabled = false;
            ddlEndMonth.Visible = false;
        }
        else
        {
            ddlStartMonth.Enabled = true;
            ddlStartMonth.Visible = true;
            ddlEndMonth.Enabled = true;
            ddlEndMonth.Visible = true;
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {            
            SqlSearch(GetQuery());
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    private string GetQuery()
    {
        string query = "";        
        if (rdoMonth.Checked == true) //月報表
        {
            if (ddlDept.SelectedValue.ToString() == "all") //全部部門月報表
            {
                query = "WITH PROD"
                            + " AS"
                            + " ("
                            + " SELECT SUBSTRING(TF.TF003, 1, 4) YR, SUBSTRING(TF.TF003, 5, 2) MN, TA.TA021 PROD_LINE, SUM(TG.TG011) TOTAL, CASE TA.TA021"
                            + " WHEN N'C' THEN N'B-C'"
                            + " WHEN N'D' THEN N'B-G'"
                            + " WHEN N'G' THEN N'B-G'"
                            + " WHEN N'GM' THEN N'B-G'"
                            + " WHEN N'E' THEN N'B-E'"
                            + " WHEN N'K' THEN N'B-K'"
                            + " WHEN N'P' THEN N'B-P'"
                            + " WHEN N'PK' THEN N'B-P'"
                            + " WHEN N'RD' THEN N'A-RD'"
                            + " WHEN N'S' THEN N'B-S'"
                            + " WHEN N'SM' THEN N'B-S'"
                            + " WHEN N'T' THEN N'B-T'"
                            + " WHEN N'TK' THEN N'B-T'"
                            + " END AS DEPT"
                            + " FROM MOCTG TG"
                            + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                            + " LEFT JOIN MOCTA TA ON TG.TG015 = TA.TA002 AND TG.TG014 = TA.TA001"
                            + " WHERE TF.TF003 BETWEEN N'" + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01' AND N'" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31'"
                            + " GROUP BY SUBSTRING(TF.TF003, 1, 4), SUBSTRING(TF.TF003,5,2), TA.TA021"
                            + " )"
                            + " SELECT PROD.YR 年, PROD.MN 月, PROD.PROD_LINE 生產線別, CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能"
                            + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8) + CONVERT(DECIMAL(10,2),SUM(TB.TB027))),'0.00'), N'-') 正常時數"
                            + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020))),'0.00'), N'-') 加班時數"
                            + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020))),'0.00'), N'-') 總工作時數"
                            + " , COALESCE(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2), PROD.TOTAL/NULLIF(((SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)),0))), N'未到當月底無法計算') 當月效率"
                            + " FROM PALTB TB"
                            + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                            + " WHERE TB.TB002 BETWEEN N'" + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01' AND N'" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31' AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR AND SUBSTRING(TB.TB002,5,2) = PROD.MN"
                            + " GROUP BY PROD.YR, PROD.MN, PROD.PROD_LINE, PROD.TOTAL"
                            + " ORDER BY PROD.PROD_LINE";

            }
            else //指定部門月報表
            {
                query = "WITH PROD"
                            + " AS"
                            + " ("
                            + " SELECT SUBSTRING(TF.TF003, 1, 4) YR, SUBSTRING(TF.TF003, 5, 2) MN, TA.TA021 PROD_LINE, SUM(TG.TG011) TOTAL, CASE TA.TA021"
                            + " WHEN N'C' THEN N'B-C'"
                            + " WHEN N'D' THEN N'B-G'"
                            + " WHEN N'G' THEN N'B-G'"
                            + " WHEN N'GM' THEN N'B-G'"
                            + " WHEN N'E' THEN N'B-E'"
                            + " WHEN N'K' THEN N'B-K'"
                            + " WHEN N'P' THEN N'B-P'"
                            + " WHEN N'PK' THEN N'B-P'"
                            + " WHEN N'RD' THEN N'A-RD'"
                            + " WHEN N'S' THEN N'B-S'"
                            + " WHEN N'SM' THEN N'B-S'"
                            + " WHEN N'T' THEN N'B-T'"
                            + " WHEN N'TK' THEN N'B-T'"
                            + " END AS DEPT"
                            + " FROM MOCTG TG"
                            + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                            + " LEFT JOIN MOCTA TA ON TG.TG015 = TA.TA002 AND TG.TG014 = TA.TA001"
                            + " WHERE TA.TA021 = N'" + ddlDept.SelectedValue.ToString() + "' AND TF.TF003 BETWEEN N'" + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01' AND N'" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31'"
                            + " GROUP BY SUBSTRING(TF.TF003, 1, 4), SUBSTRING(TF.TF003,5,2), TA.TA021"
                            + " )"
                            + " SELECT PROD.YR 年, PROD.MN 月, PROD.PROD_LINE 生產線別, CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能"
                            + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8) + CONVERT(DECIMAL(10,2),SUM(TB.TB027))),'0.00'), N'-') 正常時數"
                            + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020))),'0.00'), N'-') 加班時數"
                            + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020))),'0.00'), N'-') 總工作時數"
                            + " , COALESCE(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2), PROD.TOTAL/NULLIF(((SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)),0))), N'未到當月底無法計算') 當月效率"
                            + " FROM PALTB TB"
                            + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                            + " WHERE TB.TB003 = PROD.DEPT AND TB.TB002 BETWEEN N'" + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01' AND N'" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31' AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR AND SUBSTRING(TB.TB002,5,2) = PROD.MN"
                            + " GROUP BY PROD.YR, PROD.MN, PROD.PROD_LINE, PROD.TOTAL"
                            + " ORDER BY PROD.PROD_LINE";                
            }
            lblRange.Text = "查詢期間: " + ddlDept.SelectedItem.Text + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "~" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + rdoMonth.Text;
            fileName = ddlDept.SelectedItem.Text + "ProductionEfficiencyMonthlyReport" + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "~" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue;
        }
        else //年報表
        {            
            if (ddlDept.SelectedValue.ToString() == "all") //全部部門年報表
            {
                query = "WITH PROD"
                            + " AS"
                            + " ("
                            + " SELECT SUBSTRING(TF.TF003, 1, 4) YR, TA.TA021 PROD_LINE, SUM(TG.TG011) TOTAL, CASE TA.TA021"
                            + " WHEN N'C' THEN N'B-C'"
                            + " WHEN N'D' THEN N'B-G'"
                            + " WHEN N'G' THEN N'B-G'"
                            + " WHEN N'GM' THEN N'B-G'"
                            + " WHEN N'E' THEN N'B-E'"
                            + " WHEN N'K' THEN N'B-K'"
                            + " WHEN N'P' THEN N'B-P'"
                            + " WHEN N'PK' THEN N'B-P'"
                            + " WHEN N'RD' THEN N'A-RD'"
                            + " WHEN N'S' THEN N'B-S'"
                            + " WHEN N'SM' THEN N'B-S'"
                            + " WHEN N'T' THEN N'B-T'"
                            + " WHEN N'TK' THEN N'B-T'"
                            + " END AS DEPT"
                            + " FROM MOCTG TG"
                            + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                            + " LEFT JOIN MOCTA TA ON TG.TG015 = TA.TA002 AND TG.TG014 = TA.TA001"
                            + " WHERE TF.TF003 BETWEEN N'" + ddlStartYear.SelectedValue + "0101' AND N'" + ddlEndYear.SelectedValue + "1231'"
                            + " GROUP BY SUBSTRING(TF.TF003, 1, 4), TA.TA021"
                            + " )"
                            + " SELECT PROD.YR 年, PROD.PROD_LINE 生產線別" +
                            " , CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能" +
                            " , CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8 + CONVERT(DECIMAL(10,2),SUM(TB.TB027))) 正常時數" +
                            " , CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)) 加班時數" +
                            " , CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)) 總工作時數" +
                            " , COALESCE(CONVERT(NVARCHAR(20),(PROD.TOTAL/NULLIF(CONVERT(DECIMAL(20,2), SUM(TB.TB005)*8+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)),0))),N'未到本年度年底') 當年效率"
                            + " FROM PALTB TB"
                            + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                            + " WHERE TB.TB002 BETWEEN N'" + ddlStartYear.SelectedValue + "0101' AND N'" + ddlEndYear.SelectedValue + "1231' AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR"
                            + " GROUP BY PROD.YR, PROD.PROD_LINE, PROD.TOTAL"
                            + " ORDER BY PROD.PROD_LINE";

            }
            else //指定部門年報表
            {
                query = "WITH PROD"
                            + " AS"
                            + " ("
                            + " SELECT SUBSTRING(TF.TF003, 1, 4) YR, TA.TA021 PROD_LINE, SUM(TG.TG011) TOTAL, CASE TA.TA021"
                            + " WHEN N'C' THEN N'B-C'"
                            + " WHEN N'D' THEN N'B-G'"
                            + " WHEN N'G' THEN N'B-G'"
                            + " WHEN N'GM' THEN N'B-G'"
                            + " WHEN N'E' THEN N'B-E'"
                            + " WHEN N'K' THEN N'B-K'"
                            + " WHEN N'P' THEN N'B-P'"
                            + " WHEN N'PK' THEN N'B-P'"
                            + " WHEN N'RD' THEN N'A-RD'"
                            + " WHEN N'S' THEN N'B-S'"
                            + " WHEN N'SM' THEN N'B-S'"
                            + " WHEN N'T' THEN N'B-T'"
                            + " WHEN N'TK' THEN N'B-T'"
                            + " END AS DEPT"
                            + " FROM MOCTG TG"
                            + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                            + " LEFT JOIN MOCTA TA ON TG.TG015 = TA.TA002 AND TG.TG014 = TA.TA001"
                            + " WHERE TA.TA021 = N'" + ddlDept.SelectedValue.ToString() + "' AND TF.TF003 BETWEEN N'" + ddlStartYear.SelectedValue + "0101' AND N'" + ddlEndYear.SelectedValue + "1231'"
                            + " GROUP BY SUBSTRING(TF.TF003, 1, 4), TA.TA021"
                            + " )"
                            + " SELECT PROD.YR 年, PROD.PROD_LINE 生產線別" +
                            " , CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能" +
                            " , CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8 + CONVERT(DECIMAL(10,2),SUM(TB.TB027))) 正常時數" +
                            " , CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)) 加班時數" +
                            ", CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)) 總工作時數" +
                            ", COALESCE(CONVERT(NVARCHAR(20),(PROD.TOTAL/NULLIF(CONVERT(DECIMAL(20,2), SUM(TB.TB005)*8+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)),0))),N'未到本年度年底') 當年效率"
                            + " FROM PALTB TB"
                            + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                            + " WHERE TB.TB003 = PROD.DEPT AND TB.TB002 BETWEEN N'" + ddlStartYear.SelectedValue + "0101' AND N'" + ddlEndYear.SelectedValue + "1231' AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR"
                            + " GROUP BY PROD.YR, PROD.PROD_LINE, PROD.TOTAL"
                            + " ORDER BY PROD.PROD_LINE";
            }
            lblRange.Text = "查詢期間: " + ddlDept.SelectedItem.Text + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue + rdoYear.Text;
            fileName = ddlDept.SelectedItem.Text + "ProductionEfficiencyAnnualReport" + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue;
        }
        return query;
    }

    private void SqlSearch(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdReport.DataSource = ds;
            grdReport.DataBind();
            lblError.Text = "";
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (grdReport == null)
            {
                lblError.Text = "請先產生報表才能執行匯出";
            }
            else
            {
                lblError.Text = "";
                Export_Excel(fileName);
            }
        }
        catch (Exception ex)
        {
            //handles exceptions
            lblError.Text = ex.ToString();
        }
    }

    private void Export_Excel(string fileName)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet1 = workbook.CreateSheet("生產部門效能報表");
        IRow rowHeader1 = sheet1.CreateRow(0);
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