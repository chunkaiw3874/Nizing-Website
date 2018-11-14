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
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class nizing_intranet_M01 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

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
            hdnIsPostBack.Value = "1";
            
            try
            {
                List<string> roleList = getRoles();

                foreach (string s in roleList)
                {
                    if (s == "NIZING\\管理部" || s == "NIZING\\生管處")
                    {
                        Admin.Visible = true;
                        for (int i = DateTime.Today.Year; i > 2016; i--)
                        {
                            ddlTargetYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }
                        ddlTargetYear.SelectedIndex = 0;
                        using (SqlConnection conn = new SqlConnection(NZconnectionString))
                        {
                            conn.Open();
                            string query = "SELECT MD002, MD001"
                                        + " FROM CMSMD";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    ddlTargetProductionLine.Items.Add(new ListItem(dr[0].ToString(), dr[1].ToString()));
                                }
                            }
                        }
                        ddlTargetProductionLine.SelectedIndex = 0;
                        lblTargetSetterMessage.Text = "";
                    }
                }
            }
            catch
            {
                Server.Transfer("ErrorPage.aspx");
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
                string query = "SELECT '實際' [TYPE],*"
+" FROM"
+" ("
+" SELECT MOCTF.TF011 ProductionLine, SUBSTRING(MOCTF.TF003,1,4) YR, SUBSTRING(MOCTF.TF003,5,2) MN, CONVERT(INT, SUM(MOCTG.TG011)) ProductionAmount"
+" FROM MOCTF"
+" LEFT JOIN MOCTG ON MOCTF.TF001 = MOCTG.TG001 AND MOCTF.TF002 = MOCTG.TG002"
+" WHERE MOCTF.TF006 = N'Y' AND MOCTF.TF011 <> N'SM' AND SUBSTRING(MOCTF.TF003,1,4) BETWEEN @START AND @END"
+" GROUP BY MOCTF.TF011, SUBSTRING(MOCTF.TF003,5,2), SUBSTRING(MOCTF.TF003,1,4)"
+" ) AS PROD"
+" PIVOT"
+" ("
+" SUM(ProductionAmount)"
+" FOR"
+" MN IN ([01], [02], [03], [04], [05], [06], [07], [08], [09], [10], [11], [12])"
+" )"
+" AS PIVOTTABLE"
+" UNION"
+" SELECT '目標' [TYPE],*"
+" FROM("
+" SELECT ProductionLine"
+" , [Year] YR"
+" , RIGHT ('00'+LTRIM(STR([Month])),2 ) MN"
+" ,COALESCE(ProductionTarget,0) AS 'ProductionTarget'"
+" FROM NZ_ERP2.dbo.ProductionLineMonthlyTarget PLMT"
+" WHERE PLMT.[Year] BETWEEN @START AND @END"
+" ) AS SRC"
+" PIVOT"
+" ("
+" SUM(ProductionTarget)"
+" FOR"
+" MN IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12])"
+" )"
+ " AS PVT"
+" ORDER BY ProductionLine, YR, [TYPE]";
                SqlCommand cmdSelect = new SqlCommand(query, conn);
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

    protected void btnTargetSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = "SELECT *"
                        +" FROM("
                        +" SELECT ProductionLine"
                        +" ,[Year]"
                        +" ,[Month]"
                        +" ,COALESCE(ProductionTarget,0) AS 'ProductionTarget'"
                        +" FROM ProductionLineMonthlyTarget PLMT"
                        +" WHERE PLMT.ProductionLine=@ProductionLine"
                        +" AND PLMT.[Year]=@Year"
                        +" ) AS SRC"
                        +" PIVOT"
                        +" ("
                        +" SUM(ProductionTarget)"
                        +" FOR"
                        +" [Month] IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])"
                        +" )"
                        +" AS PVT";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductionLine", ddlTargetProductionLine.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", ddlTargetYear.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                for (int i = 0; i < 14; i++)
                {
                    DataColumn dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dt.Columns.Add(dc);
                }                
                dt.Columns[0].ColumnName = "ProductionLine";
                dt.Columns[1].ColumnName = "Year";
                dt.Columns[2].ColumnName = "1";
                dt.Columns[3].ColumnName = "2";
                dt.Columns[4].ColumnName = "3";
                dt.Columns[5].ColumnName = "4";
                dt.Columns[6].ColumnName = "5";
                dt.Columns[7].ColumnName = "6";
                dt.Columns[8].ColumnName = "7";
                dt.Columns[9].ColumnName = "8";
                dt.Columns[10].ColumnName = "9";
                dt.Columns[11].ColumnName = "10";
                dt.Columns[12].ColumnName = "11";
                dt.Columns[13].ColumnName = "12";
                DataRow dr = dt.NewRow();
                dr[0] = ddlTargetProductionLine.SelectedValue.Trim();
                dr[1] = ddlTargetYear.SelectedValue;
                dr[2] = "0";
                dr[3] = "0";
                dr[4] = "0";
                dr[5] = "0";
                dr[6] = "0";
                dr[7] = "0";
                dr[8] = "0";
                dr[9] = "0";
                dr[10] = "0";
                dr[11] = "0";
                dr[12] = "0";
                dr[13] = "0";
                dt.Rows.Add(dr);
            }
            gvTargetSetter.DataSource = dt;
            gvTargetSetter.DataBind();
        }
        if (gvTargetSetter.Rows.Count != 0)
        {
            ((Label)gvTargetSetter.HeaderRow.Cells[0].FindControl("lblTargetSetterProductionLine")).Text = ddlTargetProductionLine.SelectedValue.Trim();
            ((Label)gvTargetSetter.Rows[0].Cells[0].FindControl("lblTargetSetterProductionYear")).Text = ddlTargetYear.SelectedValue;
            btnSaveTarget.Visible = true;
        }
        else
        {
            btnSaveTarget.Visible = false;
        }
    }
    protected void btnSaveTarget_Click(object sender, EventArgs e)
    {
        //lblScope.Text = User.Identity.Name.Substring(7, User.Identity.Name.Length - 1);
        bool isProductionTargetValueCorrect = false;
        for (int i = 1; i < gvTargetSetter.Columns.Count; i++)
        {
            decimal result;
            if (!decimal.TryParse(((TextBox)gvTargetSetter.Rows[0].Cells[i].FindControl("txtTargetSetterProductionTarget" + i.ToString())).Text, out result) || result < 0)
            {
                isProductionTargetValueCorrect = false;
                lblTargetSetterMessage.Text = "生產目標有錯誤，請更正";
                lblTargetSetterMessage.ForeColor = System.Drawing.Color.Red;
                ((TextBox)gvTargetSetter.Rows[0].Cells[i].FindControl("txtTargetSetterProductionTarget" + i.ToString())).Focus();
                break;                
            }
            else
            {
                isProductionTargetValueCorrect = true;                
            }

        }
        if (isProductionTargetValueCorrect == true)
        {
            for (int i = 1; i < gvTargetSetter.Columns.Count; i++)
            {
                using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                {
                    conn.Open();
                    string query = "Update ProductionLineMonthlyTarget"
                                + " Set ProductionTarget=@ProductionTarget"
                                + " ,LastModifier=@LastModifier"
                                + " ,LastModifiedDate=GETDATE()"
                                + " Where [Year]=@Year"
                                + " And [Month]=@Month"
                                + " And ProductionLine=@ProductionLine"
                                + " If @@ROWCOUNT=0"
                                + " Insert Into ProductionLineMonthlyTarget"
                                + " Values (@Year,@Month,@ProductionLine,@ProductionTarget,@LastModifier,GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Year", ((Label)gvTargetSetter.Rows[0].Cells[0].FindControl("lblTargetSetterProductionYear")).Text);
                    cmd.Parameters.AddWithValue("@Month", i.ToString());
                    cmd.Parameters.AddWithValue("@ProductionLine", ((Label)gvTargetSetter.HeaderRow.Cells[0].FindControl("lblTargetSetterProductionLine")).Text);
                    cmd.Parameters.AddWithValue("@ProductionTarget", decimal.Parse(((TextBox)gvTargetSetter.Rows[0].Cells[i].FindControl("txtTargetSetterProductionTarget" + i.ToString())).Text));
                    cmd.Parameters.AddWithValue("@LastModifier", User.Identity.Name);
                    cmd.ExecuteNonQuery();
                }
            }
            lblTargetSetterMessage.Text = "儲存完成";
            lblTargetSetterMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}