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

            DataTable dt = new DataTable();
            dt = GetDept();
            foreach (DataRow dr in dt.Rows)
            {
                ddlDept.Items.Add(new ListItem(dr["name"].ToString().Trim(), dr["id"].ToString().Trim()));
            }
            ddlDept.SelectedValue = "all";

            dt = GetEmployees();
            foreach (DataRow dr in dt.Rows)
            {
                ddlEmployee.Items.Add(new ListItem(dr["name"].ToString().Trim(), dr["id"].ToString().Trim()));
            }
            ddlEmployee.SelectedValue = "all";
        }
    }

    protected DataTable GetDept()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "select MD001 'id'" +
                " ,MD002 'name'" +
                " from CMSMD" +
                " where MD001='C'" +
                " or MD001='D'" +
                " or MD001='E'" +
                " or MD001='G'" +
                " or MD001='K'" +
                " or MD001='P'" +
                " or MD001='S'" +
                " or MD001='SM'" +
                " or MD001='T'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    protected DataTable GetEmployees()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "select MV.MV001 'id'" +
                " ,ltrim(rtrim(MV.MV001))+' ' + ltrim(rtrim(MV.MV002)) 'name'" +
                " from CMSMV MV" +
                " where MV.MV004 like 'B-%'" +
                " and MV.MV004 <> 'B-IC'" +
                " and MV.MV004 <> 'B-PC'" +
                " and MV.MV004 <> 'B-QC'" +
                " and MV.MV004 <> 'B-STR'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
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
            if (rdoSearchByDept.Checked)    //部門月報表
            {
                if (ddlDept.SelectedValue.ToString() == "all") //全部部門月報表
                {
                    query = "WITH PROD"
                                + " AS"
                                + " ("
                                + " SELECT SUBSTRING(TF.TF003, 1, 4) YR" +
                                " , SUBSTRING(TF.TF003, 5, 2) MN" +
                                " , TF.TF011 PROD_LINE" +
                                " , SUM(TG.TG011) TOTAL" +
                                " , CASE TF.TF011"
                                + " WHEN N'C' THEN N'B-C'"
                                + " WHEN N'D' THEN N'B-G'"
                                + " WHEN N'G' THEN N'B-G'"
                                + " WHEN N'E' THEN N'B-E'"
                                + " WHEN N'K' THEN N'B-K'"
                                + " WHEN N'P' THEN N'B-P'"
                                + " WHEN N'RD' THEN N'A-RD'"
                                + " WHEN N'S' THEN N'B-S'"
                                + " WHEN N'SM' THEN N'B-S'"
                                + " WHEN N'T' THEN N'B-T'"
                                + " END AS DEPT"
                                + " FROM MOCTG TG"
                                + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                                + " WHERE TF.TF003 BETWEEN @startDate AND @endDate"
                                + " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                                " , SUBSTRING(TF.TF003,5,2)" +
                                " , TF.TF011"
                                + " )"
                                + " SELECT PROD.YR 年, PROD.MN 月, PROD.PROD_LINE 生產線別, CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能"
                                + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8) + CONVERT(DECIMAL(10,2),SUM(TB.TB027))),'0.00'), N'-') 正常時數"
                                + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039))),'0.00'), N'-') 加班時數"
                                + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039))),'0.00'), N'-') 總工作時數"
                                + " , COALESCE(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2), PROD.TOTAL/NULLIF(((SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)),0))), N'未到當月底無法計算') 當月效率"
                                + " FROM PALTB TB"
                                + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                                + " WHERE TB.TB002 BETWEEN @startDate AND @endDate" +
                                " AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR AND SUBSTRING(TB.TB002,5,2) = PROD.MN"
                                + " GROUP BY PROD.YR, PROD.MN, PROD.PROD_LINE, PROD.TOTAL"
                                + " ORDER BY PROD.PROD_LINE" +
                                ", PROD.YR" +
                                ", PROD.MN";

                }
                else //指定部門月報表
                {
                    query = "WITH PROD"
                                + " AS"
                                + " ("
                                + " SELECT SUBSTRING(TF.TF003, 1, 4) YR" +
                                " , SUBSTRING(TF.TF003, 5, 2) MN" +
                                " , TF.TF011 PROD_LINE" +
                                " , SUM(TG.TG011) TOTAL" +
                                " , CASE TF.TF011"
                                + " WHEN N'C' THEN N'B-C'"
                                + " WHEN N'D' THEN N'B-G'"
                                + " WHEN N'E' THEN N'B-E'"
                                + " WHEN N'G' THEN N'B-G'"
                                + " WHEN N'K' THEN N'B-K'"
                                + " WHEN N'P' THEN N'B-P'"
                                + " WHEN N'RD' THEN N'A-RD'"
                                + " WHEN N'S' THEN N'B-S'"
                                + " WHEN N'SM' THEN N'B-S'"
                                + " WHEN N'T' THEN N'B-T'"
                                + " END AS DEPT"
                                + " FROM MOCTG TG"
                                + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                                + " WHERE TF.TF011= @dept" +
                                " AND TF.TF003 BETWEEN @startDate AND @endDate"
                                + " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                                " , SUBSTRING(TF.TF003,5,2)" +
                                " , TF.TF011"
                                + " )"
                                + " SELECT PROD.YR 年, PROD.MN 月, PROD.PROD_LINE 生產線別, CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能"
                                + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8) + CONVERT(DECIMAL(10,2),SUM(TB.TB027))),'0.00'), N'-') 正常時數"
                                + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039))),'0.00'), N'-') 加班時數"
                                + " , COALESCE(NULLIF(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039))),'0.00'), N'-') 總工作時數"
                                + " , COALESCE(CONVERT(NVARCHAR(20),CONVERT(DECIMAL(10,2), PROD.TOTAL/NULLIF(((SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)),0))), N'未到當月底無法計算') 當月效率"
                                + " FROM PALTB TB"
                                + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                                + " WHERE TB.TB003 = PROD.DEPT" +
                                " AND TB.TB002 BETWEEN @startDate AND @endDate" +
                                " AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR" +
                                " AND SUBSTRING(TB.TB002,5,2) = PROD.MN"
                                + " GROUP BY PROD.YR, PROD.MN, PROD.PROD_LINE, PROD.TOTAL"
                                + " ORDER BY PROD.PROD_LINE" +
                                ", PROD.YR" +
                                ", PROD.MN";
                }
            }
            else  //人員月報表
            {
                if (ddlEmployee.SelectedValue.ToString() == "all")    //全部人員月報表
                {
                    query = "WITH productionData" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TF.TF003, 1, 4)[year]" +
                        " , SUBSTRING(TF.TF003, 5, 2)[month]" +
                        " , TF.TF200 employeeId" +
                        " , TF.TF011 productionLine" +
                        " , CONVERT(DECIMAL(10, 2), SUM(COALESCE(TG.TG011, 0))) totalProduction" +
                        " , CASE TF.TF011" +
                        " WHEN N'C' THEN N'B-C'" +
                        " WHEN N'D' THEN N'B-G'" +
                        " WHEN N'E' THEN N'B-E'" +
                        " WHEN N'G' THEN N'B-G'" +
                        " WHEN N'K' THEN N'B-K'" +
                        " WHEN N'P' THEN N'B-P'" +
                        " WHEN N'RD' THEN N'A-RD'" +
                        " WHEN N'S' THEN N'B-S'" +
                        " WHEN N'SM' THEN N'B-S'" +
                        " WHEN N'T' THEN N'B-T'" +
                        " END AS productionDepartment" +
                        " FROM MOCTF TF" +
                        " LEFT JOIN MOCTG TG ON TF.TF001 = TG.TG001 and TF.TF002 = TG.TG002" +
                        " WHERE TF.TF003 BETWEEN @startDate AND @endDate" +
                        " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                        " , SUBSTRING(TF.TF003, 5, 2)" +
                        " , TF.TF011" +
                        " , TF.TF200" +
                        " ), employeeWorkHour" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TB.TB002, 1, 4)[year]" +
                        " , SUBSTRING(TB.TB002, 5, 2)[month]" +
                        " , LTRIM(RTRIM(MV.MV001)) 'employeeId'" +
                        " , TB.TB003 'employeeDept'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB005) * 8 + CONVERT(DECIMAL(10, 2), SUM(TB.TB027))) 'normalWorkingHour'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB010) + SUM(TB.TB011) + SUM(TB.TB012) + SUM(TB.TB013) + SUM(TB.TB018) + SUM(TB.TB019) + SUM(TB.TB020) + SUM(TB.TB029) + SUM(TB.TB030) + SUM(TB.TB031) + SUM(TB.TB032) + SUM(TB.TB033) + SUM(TB.TB034) + SUM(TB.TB035) + SUM(TB.TB036) + SUM(TB.TB037) + SUM(TB.TB038) + SUM(TB.TB039)) 'overtimeHour'" +
                        " FROM PALTB TB" +
                        " RIGHT JOIN CMSMV MV ON TB.TB001 = MV.MV001 AND TB.TB002 BETWEEN @startDate AND @endDate" +
                        " WHERE MV.MV021 <= @startDate" +
                        " AND(MV.MV022 >= @startDate" +
                        " OR MV.MV022 = '')" +
                        " AND(TB.TB003 = 'B-C'" +
                        " OR TB.TB003 = 'B-E'" +
                        " OR TB.TB003 = 'B-G'" +
                        " OR TB.TB003 = 'B-K'" +
                        " OR TB.TB003 = 'B-P'" +
                        " OR TB.TB003 = 'B-S'" +
                        " OR TB.TB003 = 'B-T')" +
                        " GROUP BY SUBSTRING(TB.TB002, 1, 4)" +
                        " , SUBSTRING(TB.TB002, 5, 2)" +
                        " , MV.MV001" +
                        " , TB.TB003" +
                        " )" +
                        " select ewh.[year] '年份'" +
                        " ,ewh.[month] '月份'" +
                        " ,ewh.employeeId '員工代號'" +
                        " ,pd.productionLine '生產線別'" +
                        " ,ewh.employeeDept '所屬部門'" +
                        " ,pd.totalProduction '產能'" +
                        " ,ewh.normalWorkingHour '正常時數'" +
                        " ,ewh.overtimeHour '加班時數'" +
                        " ,coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0) '總時數'" +
                        " ,convert(decimal(10, 2), coalesce(coalesce(pd.totalProduction, 0) / nullif((coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0)), 0), 0)) '生產效能'" +
                        " from employeeWorkHour ewh" +
                        " left join productionData pd on ewh.employeeId = pd.employeeId and ewh.employeeDept = pd.productionDepartment and ewh.[year]=pd.[year] and ewh.[month]=pd.[month]" +
                        " order by ewh.employeeId" +
                        " ,ewh.[year]" +
                        " ,ewh.[month]" +
                        " ,ewh.employeeDept" +
                        " ,pd.productionLine";
                }
                else  //指定人員月報表
                {
                    query = "WITH productionData" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TF.TF003, 1, 4)[year]" +
                        " , SUBSTRING(TF.TF003, 5, 2)[month]" +
                        " , TF.TF200 employeeId" +
                        " , TF.TF011 productionLine" +
                        " , CONVERT(DECIMAL(10, 2), SUM(COALESCE(TG.TG011, 0))) totalProduction" +
                        " , CASE TF.TF011" +
                        " WHEN N'C' THEN N'B-C'" +
                        " WHEN N'D' THEN N'B-G'" +
                        " WHEN N'E' THEN N'B-E'" +
                        " WHEN N'G' THEN N'B-G'" +
                        " WHEN N'K' THEN N'B-K'" +
                        " WHEN N'P' THEN N'B-P'" +
                        " WHEN N'RD' THEN N'A-RD'" +
                        " WHEN N'S' THEN N'B-S'" +
                        " WHEN N'SM' THEN N'B-S'" +
                        " WHEN N'T' THEN N'B-T'" +
                        " END AS productionDepartment" +
                        " FROM MOCTF TF" +
                        " LEFT JOIN MOCTG TG ON TF.TF001 = TG.TG001 and TF.TF002 = TG.TG002" +
                        " WHERE TF.TF003 BETWEEN @startDate AND @endDate" +
                        " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                        " , SUBSTRING(TF.TF003, 5, 2)" +
                        " , TF.TF011" +
                        " , TF.TF200" +
                        " ), employeeWorkHour" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TB.TB002, 1, 4)[year]" +
                        " , SUBSTRING(TB.TB002, 5, 2)[month]" +
                        " , LTRIM(RTRIM(MV.MV001)) 'employeeId'" +
                        " , TB.TB003 'employeeDept'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB005) * 8 + CONVERT(DECIMAL(10, 2), SUM(TB.TB027))) 'normalWorkingHour'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB010) + SUM(TB.TB011) + SUM(TB.TB012) + SUM(TB.TB013) + SUM(TB.TB018) + SUM(TB.TB019) + SUM(TB.TB020) + SUM(TB.TB029) + SUM(TB.TB030) + SUM(TB.TB031) + SUM(TB.TB032) + SUM(TB.TB033) + SUM(TB.TB034) + SUM(TB.TB035) + SUM(TB.TB036) + SUM(TB.TB037) + SUM(TB.TB038) + SUM(TB.TB039)) 'overtimeHour'" +
                        " FROM PALTB TB" +
                        " RIGHT JOIN CMSMV MV ON TB.TB001 = MV.MV001 AND TB.TB002 BETWEEN @startDate AND @endDate" +
                        " WHERE MV.MV021 <= @startDate" +
                        " AND(MV.MV022 >= @startDate" +
                        " OR MV.MV022 = '')" +
                        " AND(TB.TB003 = 'B-C'" +
                        " OR TB.TB003 = 'B-E'" +
                        " OR TB.TB003 = 'B-G'" +
                        " OR TB.TB003 = 'B-K'" +
                        " OR TB.TB003 = 'B-P'" +
                        " OR TB.TB003 = 'B-S'" +
                        " OR TB.TB003 = 'B-T')" +
                        " GROUP BY SUBSTRING(TB.TB002, 1, 4)" +
                        " , SUBSTRING(TB.TB002, 5, 2)" +
                        " , MV.MV001" +
                        " , TB.TB003" +
                        " )" +
                        " select ewh.[year] '年份'" +
                        " ,ewh.[month] '月份'" +
                        " ,ewh.employeeId '員工代號'" +
                        " ,pd.productionLine '生產線別'" +
                        " ,ewh.employeeDept '所屬部門'" +
                        " ,pd.totalProduction '產能'" +
                        " ,ewh.normalWorkingHour '正常時數'" +
                        " ,ewh.overtimeHour '加班時數'" +
                        " ,coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0) '總時數'" +
                        " ,convert(decimal(10, 2), coalesce(coalesce(pd.totalProduction, 0) / nullif((coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0)), 0), 0)) '生產效能'" +
                        " from employeeWorkHour ewh" +
                        " left join productionData pd on ewh.employeeId = pd.employeeId and ewh.employeeDept = pd.productionDepartment and ewh.[year]=pd.[year] and ewh.[month]=pd.[month]" +
                        " where ewh.employeeId=@employeeId" +
                        " order by ewh.employeeId" +
                        " ,ewh.[year]" +
                        " ,ewh.[month]" +
                        " ,ewh.employeeDept" +
                        " ,pd.productionLine";
                }

                lblRange.Text = "查詢期間: " + ddlEmployee.SelectedItem.Text + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "~" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + rdoMonth.Text;
                fileName = ddlEmployee.SelectedItem.Text + "ProductionEfficiencyMonthlyReport" + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "~" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue;
            }
        }
        else //年報表
        {
            if (rdoSearchByDept.Checked)    //部門年報表
            {
                if (ddlDept.SelectedValue.ToString() == "all") //全部部門年報表
                {
                    query = "WITH PROD"
                                + " AS"
                                + " ("
                                + " SELECT SUBSTRING(TF.TF003, 1, 4) YR" +
                                " , TF.TF011 PROD_LINE" +
                                " , SUM(TG.TG011) TOTAL" +
                                " , CASE TF.TF011"
                                + " WHEN N'C' THEN N'B-C'"
                                + " WHEN N'D' THEN N'B-G'"
                                + " WHEN N'G' THEN N'B-G'"
                                + " WHEN N'E' THEN N'B-E'"
                                + " WHEN N'K' THEN N'B-K'"
                                + " WHEN N'P' THEN N'B-P'"
                                + " WHEN N'RD' THEN N'A-RD'"
                                + " WHEN N'S' THEN N'B-S'"
                                + " WHEN N'SM' THEN N'B-S'"
                                + " WHEN N'T' THEN N'B-T'"
                                + " END AS DEPT"
                                + " FROM MOCTG TG"
                                + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                                + " WHERE TF.TF003 BETWEEN @startDate AND @endDate"
                                + " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                                " , TF.TF011"
                                + " )"
                                + " SELECT PROD.YR 年, PROD.PROD_LINE 生產線別" +
                                " , CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能" +
                                " , CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8 + CONVERT(DECIMAL(10,2),SUM(TB.TB027))) 正常時數" +
                                " , CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)) 加班時數" +
                                " , CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)) 總工作時數" +
                                " , COALESCE(CONVERT(NVARCHAR(20),(PROD.TOTAL/NULLIF(CONVERT(DECIMAL(20,2), SUM(TB.TB005)*8+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)),0))),N'未到本年度年底') 當年效率"
                                + " FROM PALTB TB"
                                + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                                + " WHERE TB.TB002 BETWEEN @startDate AND @endDate" +
                                " AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR"
                                + " GROUP BY PROD.YR, PROD.PROD_LINE, PROD.TOTAL"
                                + " ORDER BY PROD.PROD_LINE" +
                                ", PROD.YR";
                }
                else //指定部門年報表
                {
                    query = "WITH PROD"
                                + " AS"
                                + " ("
                                + " SELECT SUBSTRING(TF.TF003, 1, 4) YR" +
                                " , TF.TF011 PROD_LINE" +
                                " , SUM(TG.TG011) TOTAL" +
                                " , CASE TF.TF011"
                                + " WHEN N'C' THEN N'B-C'"
                                + " WHEN N'D' THEN N'B-G'"
                                + " WHEN N'G' THEN N'B-G'"
                                + " WHEN N'E' THEN N'B-E'"
                                + " WHEN N'K' THEN N'B-K'"
                                + " WHEN N'P' THEN N'B-P'"
                                + " WHEN N'RD' THEN N'A-RD'"
                                + " WHEN N'S' THEN N'B-S'"
                                + " WHEN N'SM' THEN N'B-S'"
                                + " WHEN N'T' THEN N'B-T'"
                                + " END AS DEPT"
                                + " FROM MOCTG TG"
                                + " LEFT JOIN MOCTF TF ON TG.TG002 = TF.TF002"
                                + " WHERE TF.TF011 = @dept" +
                                " AND TF.TF003 BETWEEN @startDate AND @endDate"
                                + " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                                " , TF.TF011"
                                + " )"
                                + " SELECT PROD.YR 年, PROD.PROD_LINE 生產線別" +
                                " , CONVERT(DECIMAL(10,2),PROD.TOTAL) 產能" +
                                " , CONVERT(DECIMAL(10,2),SUM(TB.TB005)*8 + CONVERT(DECIMAL(10,2),SUM(TB.TB027))) 正常時數" +
                                " , CONVERT(DECIMAL(10,2),SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)) 加班時數" +
                                ", CONVERT(DECIMAL(10,2),(SUM(TB.TB005)*8)+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)) 總工作時數" +
                                ", COALESCE(CONVERT(NVARCHAR(20),(PROD.TOTAL/NULLIF(CONVERT(DECIMAL(20,2), SUM(TB.TB005)*8+SUM(TB.TB027)+SUM(TB.TB010)+SUM(TB.TB011)+SUM(TB.TB012)+SUM(TB.TB013)+SUM(TB.TB018)+SUM(TB.TB019)+SUM(TB.TB020)+SUM(TB.TB029)+SUM(TB.TB030)+SUM(TB.TB031)+SUM(TB.TB032)+SUM(TB.TB033)+SUM(TB.TB034)+SUM(TB.TB035)+SUM(TB.TB036)+SUM(TB.TB037)+SUM(TB.TB038)+SUM(TB.TB039)),0))),N'未到本年度年底') 當年效率"
                                + " FROM PALTB TB"
                                + " LEFT JOIN PROD ON TB.TB003 = PROD.DEPT"
                                + " WHERE TB.TB003 = PROD.DEPT" +
                                " AND TB.TB002 BETWEEN @startDate AND @endDate" +
                                " AND SUBSTRING(TB.TB002, 1, 4) = PROD.YR"
                                + " GROUP BY PROD.YR, PROD.PROD_LINE, PROD.TOTAL"
                                + " ORDER BY PROD.PROD_LINE" +
                                ", PROD.YR";
                }
                lblRange.Text = "查詢期間: " + ddlDept.SelectedItem.Text + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue + rdoYear.Text;
                fileName = ddlDept.SelectedItem.Text + "ProductionEfficiencyAnnualReport" + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue;
            }
            else
            {
                if (ddlEmployee.SelectedValue.ToString() == "all")    //全部人員年報表
                {
                    query = "WITH productionData" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TF.TF003, 1, 4)[year]" +
                        " , TF.TF200 employeeId" +
                        " , TF.TF011 productionLine" +
                        " , CONVERT(DECIMAL(10, 2), SUM(COALESCE(TG.TG011, 0))) totalProduction" +
                        " , CASE TF.TF011" +
                        " WHEN N'C' THEN N'B-C'" +
                        " WHEN N'D' THEN N'B-G'" +
                        " WHEN N'E' THEN N'B-E'" +
                        " WHEN N'G' THEN N'B-G'" +
                        " WHEN N'K' THEN N'B-K'" +
                        " WHEN N'P' THEN N'B-P'" +
                        " WHEN N'RD' THEN N'A-RD'" +
                        " WHEN N'S' THEN N'B-S'" +
                        " WHEN N'SM' THEN N'B-S'" +
                        " WHEN N'T' THEN N'B-T'" +
                        " END AS productionDepartment" +
                        " FROM MOCTF TF" +
                        " LEFT JOIN MOCTG TG ON TF.TF001 = TG.TG001 and TF.TF002 = TG.TG002" +
                        " WHERE TF.TF003 BETWEEN '20210101' AND '20211231'" +
                        " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                        " , TF.TF011" +
                        " , TF.TF200" +
                        " ), employeeWorkHour" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TB.TB002, 1, 4)[year]" +
                        " , LTRIM(RTRIM(MV.MV001)) 'employeeId'" +
                        " , TB.TB003 'employeeDept'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB005) * 8 + CONVERT(DECIMAL(10, 2), SUM(TB.TB027))) 'normalWorkingHour'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB010) + SUM(TB.TB011) + SUM(TB.TB012) + SUM(TB.TB013) + SUM(TB.TB018) + SUM(TB.TB019) + SUM(TB.TB020) + SUM(TB.TB029) + SUM(TB.TB030) + SUM(TB.TB031) + SUM(TB.TB032) + SUM(TB.TB033) + SUM(TB.TB034) + SUM(TB.TB035) + SUM(TB.TB036) + SUM(TB.TB037) + SUM(TB.TB038) + SUM(TB.TB039)) 'overtimeHour'" +
                        " FROM PALTB TB" +
                        " RIGHT JOIN CMSMV MV ON TB.TB001 = MV.MV001 AND TB.TB002 BETWEEN '20210101' AND '20211231'" +
                        " WHERE MV.MV021 <= '20210101'" +
                        " AND(MV.MV022 >= '20210101'" +
                        " OR MV.MV022 = '')" +
                        " AND(TB.TB003 = 'B-C'" +
                        " OR TB.TB003 = 'B-E'" +
                        " OR TB.TB003 = 'B-G'" +
                        " OR TB.TB003 = 'B-K'" +
                        " OR TB.TB003 = 'B-P'" +
                        " OR TB.TB003 = 'B-S'" +
                        " OR TB.TB003 = 'B-T')" +
                        " GROUP BY SUBSTRING(TB.TB002, 1, 4)" +
                        " , MV.MV001" +
                        " , TB.TB003" +
                        " )" +
                        " select ewh.[year] '年份'" +
                        " ,ewh.employeeId '員工代號'" +
                        " ,pd.productionLine '生產線別'" +
                        " ,ewh.employeeDept '所屬部門'" +
                        " ,pd.totalProduction '產能'" +
                        " ,ewh.normalWorkingHour '正常時數'" +
                        " ,ewh.overtimeHour '加班時數'" +
                        " ,coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0) '總時數'" +
                        " ,convert(decimal(10, 2), coalesce(coalesce(pd.totalProduction, 0) / nullif((coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0)), 0), 0)) '生產效能'" +
                        " from employeeWorkHour ewh" +
                        " left join productionData pd on ewh.employeeId = pd.employeeId and pd.productionDepartment = ewh.employeeDept and ewh.[year]= pd.[year]" +
                        " order by ewh.employeeId" +
                        " ,ewh.[year]" +
                        " ,ewh.employeeDept" +
                        " ,pd.productionLine";
                }
                else  //指定人員年報表
                {
                    query = "WITH productionData" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TF.TF003, 1, 4)[year]" +
                        " , TF.TF200 employeeId" +
                        " , TF.TF011 productionLine" +
                        " , CONVERT(DECIMAL(10, 2), SUM(COALESCE(TG.TG011, 0))) totalProduction" +
                        " , CASE TF.TF011" +
                        " WHEN N'C' THEN N'B-C'" +
                        " WHEN N'D' THEN N'B-G'" +
                        " WHEN N'E' THEN N'B-E'" +
                        " WHEN N'G' THEN N'B-G'" +
                        " WHEN N'K' THEN N'B-K'" +
                        " WHEN N'P' THEN N'B-P'" +
                        " WHEN N'RD' THEN N'A-RD'" +
                        " WHEN N'S' THEN N'B-S'" +
                        " WHEN N'SM' THEN N'B-S'" +
                        " WHEN N'T' THEN N'B-T'" +
                        " END AS productionDepartment" +
                        " FROM MOCTF TF" +
                        " LEFT JOIN MOCTG TG ON TF.TF001 = TG.TG001 and TF.TF002 = TG.TG002" +
                        " WHERE TF.TF003 BETWEEN '20210101' AND '20211231'" +
                        " GROUP BY SUBSTRING(TF.TF003, 1, 4)" +
                        " , TF.TF011" +
                        " , TF.TF200" +
                        " ), employeeWorkHour" +
                        " AS" +
                        " (" +
                        " SELECT SUBSTRING(TB.TB002, 1, 4)[year]" +
                        " , LTRIM(RTRIM(MV.MV001)) 'employeeId'" +
                        " , TB.TB003 'employeeDept'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB005) * 8 + CONVERT(DECIMAL(10, 2), SUM(TB.TB027))) 'normalWorkingHour'" +
                        " , CONVERT(DECIMAL(10, 2), SUM(TB.TB010) + SUM(TB.TB011) + SUM(TB.TB012) + SUM(TB.TB013) + SUM(TB.TB018) + SUM(TB.TB019) + SUM(TB.TB020) + SUM(TB.TB029) + SUM(TB.TB030) + SUM(TB.TB031) + SUM(TB.TB032) + SUM(TB.TB033) + SUM(TB.TB034) + SUM(TB.TB035) + SUM(TB.TB036) + SUM(TB.TB037) + SUM(TB.TB038) + SUM(TB.TB039)) 'overtimeHour'" +
                        " FROM PALTB TB" +
                        " RIGHT JOIN CMSMV MV ON TB.TB001 = MV.MV001 AND TB.TB002 BETWEEN '20210101' AND '20211231'" +
                        " WHERE MV.MV021 <= '20210101'" +
                        " AND(MV.MV022 >= '20210101'" +
                        " OR MV.MV022 = '')" +
                        " AND(TB.TB003 = 'B-C'" +
                        " OR TB.TB003 = 'B-E'" +
                        " OR TB.TB003 = 'B-G'" +
                        " OR TB.TB003 = 'B-K'" +
                        " OR TB.TB003 = 'B-P'" +
                        " OR TB.TB003 = 'B-S'" +
                        " OR TB.TB003 = 'B-T')" +
                        " GROUP BY SUBSTRING(TB.TB002, 1, 4)" +
                        " , MV.MV001" +
                        " , TB.TB003" +
                        " )" +
                        " select ewh.[year] '年份'" +
                        " ,ewh.employeeId '員工代號'" +
                        " ,pd.productionLine '生產線別'" +
                        " ,ewh.employeeDept '所屬部門'" +
                        " ,pd.totalProduction '產能'" +
                        " ,ewh.normalWorkingHour '正常時數'" +
                        " ,ewh.overtimeHour '加班時數'" +
                        " ,coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0) '總時數'" +
                        " ,convert(decimal(10, 2), coalesce(coalesce(pd.totalProduction, 0) / nullif((coalesce(ewh.normalWorkingHour, 0) + coalesce(ewh.overtimeHour, 0)), 0), 0)) '生產效能'" +
                        " from employeeWorkHour ewh" +
                        " left join productionData pd on ewh.employeeId = pd.employeeId and pd.productionDepartment = ewh.employeeDept and ewh.[year]= pd.[year]" +
                        " where ewh.employeeId=@employeeId" +
                        " order by ewh.employeeId" +
                        " ,ewh.[year]" +
                        " ,ewh.employeeDept" +
                        " ,pd.productionLine";
                }

                lblRange.Text = "查詢期間: " + ddlEmployee.SelectedItem.Text + ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "~" + ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + rdoYear.Text;
                fileName = ddlEmployee.SelectedItem.Text + "ProductionEfficiencyAnnualReport" + ddlStartYear.SelectedValue + "~" + ddlEndYear.SelectedValue;
            }
        }
        return query;
    }

    private void SqlSearch(string query)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dept", ddlDept.SelectedValue);
            cmd.Parameters.AddWithValue("@employeeId", ddlEmployee.SelectedValue);
            if (rdoMonth.Checked)
            {
                cmd.Parameters.AddWithValue("@startDate", ddlStartYear.SelectedValue + ddlStartMonth.SelectedValue + "01");
                cmd.Parameters.AddWithValue("@endDate", ddlEndYear.SelectedValue + ddlEndMonth.SelectedValue + "31");
            }
            else
            {
                cmd.Parameters.AddWithValue("@startDate", ddlStartYear.SelectedValue + "0101");
                cmd.Parameters.AddWithValue("@endDate", ddlEndYear.SelectedValue + "1231");
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdReport.DataSource = dt;
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
        string strfileext = ".xls";
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + strfileext);
        HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

        //Get the HTML for the control.
        grdReport.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //用export_excel必須要有這個override
    }
}