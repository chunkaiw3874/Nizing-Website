using NPOI.POIFS.FileSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class QC_QC02_Report : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    string StartDate;
    string EndDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    DateManipulation(Request.QueryString["Method"], Request.QueryString["Year"], Request.QueryString["Month"]);
                    LoadData();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void DateManipulation(string method, string year, string month)
    {
        string startYear = "";
        string startMonth = "";
        string endYear = "";
        string endMonth = "";
        if (method == "Year")
        {
            startYear = Convert.ToString(Convert.ToInt16(year) - 1);
            startMonth = "1226";
            endYear = year;
            endMonth = "1225";
        }
        else
        {
            if (month == "01")
            {
                startYear = Convert.ToString(Convert.ToInt16(year) - 1);
                startMonth = "1226";
            }
            else
            {
                startYear = year;
                startMonth = (Convert.ToInt16(month) - 1).ToString().PadLeft(2, '0') + "26";
            }
            endYear = year;
            endMonth = month + "25"; ;
        }
        StartDate = startYear + startMonth;
        EndDate = endYear + endMonth;
    }
    protected void LoadData()
    {
        lblScope.Text = "退貨明細 " + StartDate + "~" + EndDate;
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            SqlCommand cmdSelect = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY COPTI.TI034) RN"
                                                + " , (COPTJ.TJ001+N'-'+COPTJ.TJ002+N'-'+COPTJ.TJ003) ID"
                                                + " , COPTI.TI034"
                                                + " , COPTI.TI004"
                                                + " , COPMA.MA002"
                                                + " , CMSMV.MV002"
                                                + " , COPTJ.TJ004"
                                                + " , COPTJ.TJ005"
                                                + " , COPTJ.TJ007"
                                                + " , COPTJ.TJ008"
                                                + " , QC01.PIC_NAME"
                                                + " , QC01.CAUSE"
                                                + " , QC01.RESPONSIBLE"
                                                + " , QC01.HANDLE"
                                                + " , QC01.[DESCRIPTION]"
                                                + " , COPTI.TI008"
                                                + " , CONVERT(DECIMAL(20,4), COPTJ.TJ011) TJ011"
                                                + " , CONVERT(DECIMAL(20,2), COPTJ.TJ033) TJ033"
                                                + " , QC01.AMOUNT_GOOD"
                                                + " , QC01.AMOUNT_REDO"
                                                + " , QC01.AMOUNT_SCRAP"
                                                + " , QC01.AMOUNT_OTHER"
                                                + " , QC01.AMOUNT_LOSS"
                                                + " , QC01.SIGNOFF"
                                                + " , COPTI.TI020"
                                                + " FROM COPTI"
                                                + " LEFT JOIN COPMA ON COPTI.TI004=COPMA.MA001"
                                                + " LEFT JOIN CMSMV ON COPTI.TI006=CMSMV.MV001"
                                                + " LEFT JOIN COPTJ ON COPTI.TI001=COPTJ.TJ001 AND COPTI.TI002=COPTJ.TJ002"
                                                + " LEFT JOIN NZ_ERP2.dbo.QC_QC01_A QC01 ON COPTJ.TJ001=QC01.RETURN_TYPE AND COPTJ.TJ002=QC01.RETURN_ID AND COPTJ.TJ003=QC01.RETURN_ITEMNUMBER"
                                                + " WHERE COPTI.TI034 BETWEEN @StartDate AND @EndDate"
                                                + " ORDER BY COPTI.TI034", conn);            
            cmdSelect.Parameters.AddWithValue("@StartDate", StartDate);
            cmdSelect.Parameters.AddWithValue("@EndDate", EndDate);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            da.Fill(dt);
            grdReport1.DataSource = dt;
            grdReport1.DataBind();
        }
        //計算退貨原因總數variable
        int sumCause1 = 0;
        int sumCause2 = 0;
        int sumCause3 = 0;
        int sumCause4 = 0;
        int sumCause5 = 0;
        int sumCause6 = 0;
        //計算銷退金額配置variable
        double sumGood = 0;
        double sumRedo = 0;
        double sumScrap = 0;
        double sumOther = 0;
        double allocatedTotal = 0;
        double sumTotal = 0;
        double doubleTemp = 0;
        //計算良品退貨及不良品退貨variable
        double sumReturnGood = 0;
        double sumReturnBad = 0;
        foreach (GridViewRow row in grdReport1.Rows)
        {
            //計算退貨原因總數
            if (((Label)row.Cells[8].FindControl("lblCause")).Text == "品質異常")
            {
                sumCause1 += 1;
                if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
                {
                    sumReturnBad += doubleTemp;
                }
            }
            else if (((Label)row.Cells[8].FindControl("lblCause")).Text == "客戶訂錯")
            {
                sumCause2 += 1;
                if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
                {
                    sumReturnGood += doubleTemp;
                }
            }
            else if (((Label)row.Cells[8].FindControl("lblCause")).Text == "出錯貨")
            {
                sumCause3 += 1;
                if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
                {
                    sumReturnGood += doubleTemp;
                }
            }
            else if (((Label)row.Cells[8].FindControl("lblCause")).Text == "訂單錯誤")
            {
                sumCause4 += 1;
                if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
                {
                    sumReturnGood += doubleTemp;
                }
            }
            else if (((Label)row.Cells[8].FindControl("lblCause")).Text == "換貨")
            {
                sumCause5 += 1;
                if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
                {
                    sumReturnGood += doubleTemp;
                }
            }
            else if (((Label)row.Cells[8].FindControl("lblCause")).Text == "其他")
            {
                sumCause6 += 1;
                if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
                {
                    sumReturnGood += doubleTemp;
                }
            }
            //計算銷退金額配置
            if (double.TryParse(((Label)row.Cells[15].FindControl("lblGood")).Text, out doubleTemp))
            {
                sumGood += doubleTemp;
            }
            if (double.TryParse(((Label)row.Cells[16].FindControl("lblRedo")).Text, out doubleTemp))
            {
                sumRedo += doubleTemp;
            }
            if (double.TryParse(((Label)row.Cells[17].FindControl("lblScrap")).Text, out doubleTemp))
            {
                sumScrap += doubleTemp;
            }
            if (double.TryParse(((Label)row.Cells[18].FindControl("lblOther")).Text, out doubleTemp))
            {
                sumOther += doubleTemp;
            }
            if (double.TryParse(((Label)row.Cells[14].FindControl("lblTotal")).Text, out doubleTemp))
            {
                sumTotal += doubleTemp;
            }
        }
        //退貨原因display
        lblCauseTotal1.Text = sumCause1.ToString();
        lblCauseTotal2.Text = sumCause2.ToString();
        lblCauseTotal3.Text = sumCause3.ToString();
        lblCauseTotal4.Text = sumCause4.ToString();
        lblCauseTotal5.Text = sumCause5.ToString();
        lblCauseTotal6.Text = sumCause6.ToString();
        lblCauseGrandTotal.Text = (sumCause1 + sumCause2 + sumCause3 + sumCause4 + sumCause5 + sumCause6).ToString();
        //銷退金額配置display
        allocatedTotal = sumGood + sumRedo + sumScrap + sumOther;
        lblGoodTotal.Text = sumGood.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        lblRedoTotal.Text = sumRedo.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        lblScrapTotal.Text = sumScrap.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        lblOtherTotal.Text = sumOther.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        lblAllocatedTotal.Text = allocatedTotal.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        lblGrandTotal.Text = sumTotal.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        if (allocatedTotal == sumTotal)
        {
            lblTotalMatch.Text = "銷退金額配置Okay";
            lblTotalMatch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00c400");
            lblAllocatedTotal.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00c400");
        }
        else
        {
            lblTotalMatch.Text = "已配置金額與銷退總金額不符";
            lblTotalMatch.ForeColor = System.Drawing.Color.Red;
            lblAllocatedTotal.ForeColor = System.Drawing.Color.Red;
        }
        lblReturnGoodTotal.Text = sumReturnGood.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        lblReturnBadTotal.Text = sumReturnBad.ToString("C", CultureInfo.CreateSpecificCulture("zh-TW"));
        //製作圓餅圖 for 退貨原因
        int[] returnY = { Convert.ToInt16(lblCauseTotal1.Text), Convert.ToInt16(lblCauseTotal2.Text), Convert.ToInt16(lblCauseTotal3.Text), Convert.ToInt16(lblCauseTotal4.Text), Convert.ToInt16(lblCauseTotal5.Text), Convert.ToInt16(lblCauseTotal6.Text) };
        string[] returnX = { "品質異常", "客戶訂錯", "出錯貨", "訂單錯誤", "換貨", "其他" };
        chartReturn.Series["Series1"].Points.DataBindXY(returnX, returnY);
        chartReturn.Legends.Add(new Legend("returnLegend"));
        chartReturn.Series["Series1"].Legend = "returnLegend";
        chartReturn.Series["Series1"].IsVisibleInLegend = true;
        chartReturn.Legends["returnLegend"].Docking = Docking.Bottom;
        chartReturn.Legends["returnLegend"].IsTextAutoFit = true;
        chartReturn.Legends["returnLegend"].AutoFitMinFontSize = 14;
        chartReturn.Legends["returnLegend"].MaximumAutoSize = 100;
        chartReturn.Series["Series1"]["PieLabelStyle"] = "Disabled";

        //Get資料for pie chart Return Amount
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            SqlCommand cmdSelect = new SqlCommand("SELECT "
                                                + " COPTI.TI004+N'-'+COPMA.MA002 COMPANY"
                                                + " , SUM(CONVERT(DECIMAL(20,2), COPTJ.TJ033)) RETURN_AMOUNT"
                                                + " FROM COPTI"
                                                + " LEFT JOIN COPMA ON COPTI.TI004=COPMA.MA001"
                                                + " LEFT JOIN COPTJ ON COPTI.TI001=COPTJ.TJ001 AND COPTI.TI002=COPTJ.TJ002"
                                                + " WHERE COPTI.TI034 BETWEEN @StartDate AND @EndDate"
                                                + " GROUP BY COPTI.TI004+N'-'+COPMA.MA002, COPTI.TI034", conn);
            cmdSelect.Parameters.AddWithValue("@StartDate", StartDate);
            cmdSelect.Parameters.AddWithValue("@EndDate", EndDate);
            SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
            dt = new DataTable();
            da.Fill(dt);
        }
        chartReturnAmount.DataSource = dt;
        chartReturnAmount.Series["Series1"].XValueMember = "COMPANY";
        chartReturnAmount.Series["Series1"].YValueMembers = "RETURN_AMOUNT";
        chartReturnAmount.Legends.Add(new Legend("returnAmountLegend"));
        chartReturnAmount.Series["Series1"].Legend = "returnAmountLegend";
        chartReturnAmount.Series["Series1"].IsVisibleInLegend = true;
        chartReturnAmount.Legends["returnAmountLegend"].Docking = Docking.Bottom;
        chartReturnAmount.Legends["returnAmountLegend"].IsTextAutoFit = true;
        chartReturnAmount.Legends["returnAmountLegend"].AutoFitMinFontSize = 14;
        chartReturnAmount.Legends["returnAmountLegend"].MaximumAutoSize = 100;
        chartReturnAmount.Series["Series1"]["PieLabelStyle"] = "Disabled";

        lblCreator.Text = Request.QueryString["ID"];
    }

    private void DoDownload()
    {
        string url = Request.Url.AbsoluteUri;
        var file = WKHtmlToPdf(url);
        if (file != null)
        {
            Response.ContentType = "Application/pdf";
            Response.BinaryWrite(file);
            Response.End();
        }
    }

    public byte[] WKHtmlToPdf(string url)
    {
        string fileName = " - ";
        string wkhtmlDir = "C:\\Program Files\\wkhtmltopdf\\bin\\";
        string wkhtml = "C:\\Program Files\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
        var p = new Process();

        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = wkhtml;
        p.StartInfo.WorkingDirectory = wkhtmlDir;

        string switches = "";
        switches += "--print-media-type ";
        switches += "--margin-top 10mm --margin-bottom 10mm --margin-right 10mm --margin-left 10mm ";
        switches += "--page-size A3 ";
        switches += "--orientation Landscape";
        //switches += "--footer 製表人:" + ViewState["username"].ToString();
        //switches += "--footer maker:";
        p.StartInfo.Arguments = switches + " " + url + " " + fileName;
        p.Start();

        //read output
        byte[] buffer = new byte[32768];
        byte[] file;
        using (var ms = new MemoryStream())
        {
            while (true)
            {
                int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);

                if (read <= 0)
                {
                    break;
                }
                ms.Write(buffer, 0, read);
            }
            file = ms.ToArray();
        }

        // wait or exit
        p.WaitForExit(60000);

        // read the exit code, close process
        int returnCode = p.ExitCode;
        p.Close();

        return returnCode == 0 ? file : null;
    }
    protected void btnConvert_Click(object sender, EventArgs e)
    {
        try
        {
            DoDownload();
        }
        catch (Exception ex)
        {
            
        }
    }
}