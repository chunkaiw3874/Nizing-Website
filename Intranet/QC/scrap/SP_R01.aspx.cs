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


public partial class QC_scrap_SP_R01 : System.Web.UI.Page
{
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > -20; i--)
            {
                ddlStartYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                ddlEndYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlStartYear.SelectedValue = DateTime.Today.Year.ToString();
            ddlEndYear.SelectedValue = DateTime.Today.Year.ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string[] query = getQuery();
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand(query[0], conn);
                cmdSelect.ExecuteNonQuery();
                cmdSelect = new SqlCommand(query[1], conn);
                cmdSelect.ExecuteNonQuery();
                cmdSelect = new SqlCommand(query[2], conn);
                cmdSelect.ExecuteNonQuery();
                cmdSelect = new SqlCommand(query[3], conn);
                cmdSelect.ExecuteNonQuery();
                cmdSelect = new SqlCommand(query[4], conn);
                cmdSelect.ExecuteNonQuery();
                cmdSelect = new SqlCommand(query[5], conn);
                cmdSelect.ExecuteNonQuery();
                cmdSelect = new SqlCommand(query[6], conn);
                cmdSelect.Parameters.AddWithValue("@START", ddlStartYear.SelectedValue);
                cmdSelect.Parameters.AddWithValue("@END", ddlEndYear.SelectedValue);
                if (ddlDept.SelectedValue != "all")
                {
                    cmdSelect.Parameters.AddWithValue("@DEPT_NAME", ddlDept.SelectedItem.Text);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grdResult.DataSource = dt;
                grdResult.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected string[] getQuery()
    {
        string[] query = new string[7];
        string condition = "";
        if (ddlDept.SelectedValue != "all")
        {
            condition = " AND DEPT_NAME=@DEPT_NAME";
        }
        query[0] = "SELECT DISTINCT CONVERT(DATE, RECYCLE_DATE) [DATE]" + System.Environment.NewLine
            + " INTO #LAST_SALE_DATE" + System.Environment.NewLine
            + " FROM SCRAP_SP02_A";
        query[1] = " INSERT INTO #LAST_SALE_DATE" + System.Environment.NewLine
            + " VALUES (CONVERT(DATE, N'2012-10-08'))";
        query[2] = " SELECT " + System.Environment.NewLine
            + " ROW_NUMBER() OVER (ORDER BY [DATE]) AS [RANK]," + System.Environment.NewLine
            + " [DATE] AS [LAST_SALE_DATE], (SELECT MIN([DATE]) FROM #LAST_SALE_DATE WHERE [DATE]>C1.[DATE]) [THIS_SALE_DATE]" + System.Environment.NewLine
            + " , CASE" + System.Environment.NewLine
            + " WHEN DATEDIFF(MONTH, [DATE], (SELECT MIN([DATE]) FROM #LAST_SALE_DATE WHERE [DATE]>C1.[DATE])) <= 0 THEN 1" + System.Environment.NewLine
            + " ELSE DATEDIFF(MONTH, [DATE], (SELECT MIN([DATE]) FROM #LAST_SALE_DATE WHERE [DATE]>C1.[DATE]))" + System.Environment.NewLine
            + " END AS DATE_DIFF" + System.Environment.NewLine
            + " INTO #DATE_DIFF_TABLE" + System.Environment.NewLine
            + " FROM #LAST_SALE_DATE C1";
        query[3] = " SELECT" + System.Environment.NewLine
            + " SCRAP_SP02_A.RECYCLE_DATE [SALE_DATE]" + System.Environment.NewLine
            + " , DATEPART(YEAR, DATEADD(MONTH,-(#DATE_DIFF_TABLE.DATE_DIFF),SCRAP_SP02_A.RECYCLE_DATE)) YR" + System.Environment.NewLine
            + " , DATEPART(MONTH, DATEADD(MONTH,-(#DATE_DIFF_TABLE.DATE_DIFF),SCRAP_SP02_A.RECYCLE_DATE)) MN" + System.Environment.NewLine
            + " , SCRAP_SP02_A.DEPARTMENT_NAME [DEPT_NAME]" + System.Environment.NewLine
            + " , SCRAP_SP02_A.[TYPE_NAME] [TYPE_NAME]"
            + " , CONVERT(DECIMAL(10,2), (SCRAP_SP02_A.AMOUNT/#DATE_DIFF_TABLE.DATE_DIFF)) AVERAGE" + System.Environment.NewLine
            + " , #DATE_DIFF_TABLE.DATE_DIFF [DIFF]" + System.Environment.NewLine
            + " INTO #ORIGINAL_SALE_RECORD" + System.Environment.NewLine
            + " FROM SCRAP_SP02_A" + System.Environment.NewLine
            + " LEFT JOIN #DATE_DIFF_TABLE ON CONVERT(DATE, SCRAP_SP02_A.RECYCLE_DATE)=#DATE_DIFF_TABLE.THIS_SALE_DATE" + System.Environment.NewLine;
        query[4] = " CREATE TABLE #FINAL_SALE_RECORD" + System.Environment.NewLine
            + " (" + System.Environment.NewLine
            + " SALE_DATE DATE," + System.Environment.NewLine
            + " DEPT_NAME NVARCHAR(50)," + System.Environment.NewLine
            + " [TYPE_NAME] NVARCHAR(50),"
            + " AVERAGE FLOAT" + System.Environment.NewLine
            + " )";
        query[5] = " DECLARE @SALE_DATE DATE, @DEPT_NAME NVARCHAR(50), @TYPE_NAME NVARCHAR(50), @AVG FLOAT, @DIFF INT" + System.Environment.NewLine
            + " DECLARE TABLE_INSERT_CURSOR CURSOR FOR" + System.Environment.NewLine
            + " SELECT SALE_DATE, DEPT_NAME, [TYPE_NAME], AVERAGE, DIFF FROM #ORIGINAL_SALE_RECORD" + System.Environment.NewLine
            + " OPEN TABLE_INSERT_CURSOR" + System.Environment.NewLine
            + " FETCH NEXT FROM TABLE_INSERT_CURSOR INTO @SALE_DATE,@DEPT_NAME,@TYPE_NAME,@AVG,@DIFF" + System.Environment.NewLine
            + " WHILE @@FETCH_STATUS=0" + System.Environment.NewLine
            + " BEGIN" + System.Environment.NewLine
            + " 	DECLARE @COUNT INT=1;" + System.Environment.NewLine
            + " 	WHILE @COUNT < @DIFF+1" + System.Environment.NewLine
            + " 	BEGIN" + System.Environment.NewLine
                    + " INSERT INTO #FINAL_SALE_RECORD" + System.Environment.NewLine
                    + " VALUES (DATEADD(MONTH,-@COUNT,@SALE_DATE),@DEPT_NAME,@TYPE_NAME,@AVG)" + System.Environment.NewLine
                    + " SET @COUNT=@COUNT+1;" + System.Environment.NewLine
                + " END" + System.Environment.NewLine
            + " FETCH NEXT FROM TABLE_INSERT_CURSOR INTO @SALE_DATE,@DEPT_NAME,@TYPE_NAME,@AVG,@DIFF" + System.Environment.NewLine
            + " END" + System.Environment.NewLine
            + " CLOSE TABLE_INSERT_CURSOR" + System.Environment.NewLine
            + " DEALLOCATE TABLE_INSERT_CURSOR";
        query[6] = " SELECT *" + System.Environment.NewLine
        + " FROM" + System.Environment.NewLine
        + " (SELECT DATEPART(YEAR,SALE_DATE) YR, DATEPART(MONTH,SALE_DATE) MN, DEPT_NAME, [TYPE_NAME], AVERAGE" + System.Environment.NewLine
        + " FROM #FINAL_SALE_RECORD" + System.Environment.NewLine
        + " ) AS S" + System.Environment.NewLine
        + " PIVOT" + System.Environment.NewLine
        + " (SUM(AVERAGE) FOR MN IN ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]))" + System.Environment.NewLine
        + " AS PIVOTTABLE" + System.Environment.NewLine
        + " WHERE YR BETWEEN @START AND @END" + condition + System.Environment.NewLine
        + " ORDER BY YR, [TYPE_NAME], DEPT_NAME";
        return query;
    }
    protected void grdResult_RowDataBound(object sender, GridViewRowEventArgs e)
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
            ((Label)e.Row.FindControl("lbl16")).Text = Math.Round((jan + feb + mar + apr + may + june + july + aug + sep + oct + nov + dec) / 12, 2).ToString();

        }
    }
}