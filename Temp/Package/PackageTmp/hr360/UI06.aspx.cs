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


public partial class hr360_UI06 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            for (int i = DateTime.Today.Year; i > DateTime.Today.Year - 2; i--)
            {
                ddlYear.Items.Add(i.ToString());
            }
            ddlYear.SelectedIndex = 0;
            ddlMonth.SelectedIndex = Convert.ToInt16(DateTime.Today.Month) - 2;
            //using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            //{
            //    conn.Open();
            //    SqlCommand cmdSelect = new SqlCommand("SELECT ERP_ID"
            //                                        +" FROM HR360_BI01_A"
            //                                        +" WHERE [ID]=@ID", conn);
            //    cmdSelect.Parameters.AddWithValue("@ID", Session["user_id"].ToString());
            //    Session["erp_id"] = (string)cmdSelect.ExecuteScalar();            
            //}
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Text = "";
            //DateTime showSlipTime = DateTime(DateTime.Today.Year,DateTime.today)
            if (checkSlipAvailability())
            {

                DataTable main_table = new DataTable();
                DataTable bonus_table = new DataTable();
                DataTable deduction_table = new DataTable();
                DataTable attendance_table = new DataTable();
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    /*main table*/
                    SqlCommand cmdSelect = new SqlCommand(
                        "SELECT PALTI.TI002 發薪年月,CMSMJ.MJ003 職稱,CMSME.ME001 部門代號,CMSME.ME002 部門名稱,PALTI.TI001 員工代號"
                    + " ,CMSMV.MV002 員工名稱,(PALTI.TI023+PALTI.TI024) N'底(本)薪',(PALTI.TI029+PALTI.TI030) N'全勤獎金'"
                    + " ,(PALTI.TI025+PALTI.TI026+PALTI.TI027+PALTI.TI028) N'加班費',(PALTI.TI031+PALTI.TI032) N'請假扣款',PALTI.TI033 N'健保費'"
                    + " ,PALTI.TI034 N'勞保費',PALTI.TI053 N'員工提撥',(PALTI.TI079+PALTI.TI080) N'補充保費'"
                    + " ,(PALTI.TI007+PALTI.TI008+PALTI.TI009+PALTI.TI010+PALTI.TI011+PALTI.TI012+PALTI.TI013+PALTI.TI014+PALTI.TI058+PALTI.TI059+PALTI.TI062+PALTI.TI063+PALTI.TI064+PALTI.TI065+PALTI.TI066+PALTI.TI067+PALTI.TI089+PALTI.TI090+PALTI.TI091+PALTI.TI092+PALTI.TI093+PALTI.TI094+PALTI.TI108+PALTI.TI109+PALTI.TI110+PALTI.TI111+PALTI.TI112+PALTI.TI113+PALTI.TI114+PALTI.TI115+PALTI.TI116+PALTI.TI117+PALTI.TI118+PALTI.TI119+PALTI.TI120+PALTI.TI121+PALTI.TI122+PALTI.TI123+PALTI.TI124+PALTI.TI125+PALTI.TI126+PALTI.TI127+PALTI.TI128+PALTI.TI129+PALTI.TI130+PALTI.TI131) N'加班時數'"
                    + " ,PALTI.TI054 N'公司提繳',PALTI.TI055 N'員工提繳',PALTI.TI056 N'公司累計提繳'"
                    + " ,(PALTI.TI042+PALTI.TI043) N'課稅所得',(PALTI.TI040+PALTI.TI041) N'實發金額',CMSMV.MV036 N'薪轉帳號'"
                    + " FROM PALTI"
                    + " 	LEFT JOIN CMSMV ON PALTI.TI001=CMSMV.MV001"
                    + " 	LEFT JOIN CMSMJ ON CMSMV.MV006=CMSMJ.MJ001"
                    + " 	LEFT JOIN CMSME ON CMSMV.MV004=CMSME.ME001"
                    + " 	LEFT JOIN PALTB ON PALTI.TI001=PALTB.TB001 AND PALTI.TI002=SUBSTRING(PALTB.TB002,1,6)"
                    + " WHERE PALTI.TI002=@DATE AND PALTI.TI001=@ID"
                    + " GROUP BY PALTI.TI002,CMSMJ.MJ003,CMSME.ME001,CMSME.ME002,PALTI.TI001"
                    + " ,CMSMV.MV002,(PALTI.TI023+PALTI.TI024),(PALTI.TI029+PALTI.TI030)"
                    + " ,(PALTI.TI025+PALTI.TI026+PALTI.TI027+PALTI.TI028),(PALTI.TI031+PALTI.TI032),PALTI.TI033"
                    + " ,PALTI.TI034,PALTI.TI053,(PALTI.TI079+PALTI.TI080)"
                    + " ,(PALTI.TI007+PALTI.TI008+PALTI.TI009+PALTI.TI010+PALTI.TI011+PALTI.TI012+PALTI.TI013+PALTI.TI014+PALTI.TI058+PALTI.TI059+PALTI.TI062+PALTI.TI063+PALTI.TI064+PALTI.TI065+PALTI.TI066+PALTI.TI067+PALTI.TI089+PALTI.TI090+PALTI.TI091+PALTI.TI092+PALTI.TI093+PALTI.TI094+PALTI.TI108+PALTI.TI109+PALTI.TI110+PALTI.TI111+PALTI.TI112+PALTI.TI113+PALTI.TI114+PALTI.TI115+PALTI.TI116+PALTI.TI117+PALTI.TI118+PALTI.TI119+PALTI.TI120+PALTI.TI121+PALTI.TI122+PALTI.TI123+PALTI.TI124+PALTI.TI125+PALTI.TI126+PALTI.TI127+PALTI.TI128+PALTI.TI129+PALTI.TI130+PALTI.TI131)"
                    + " ,PALTI.TI054,PALTI.TI055,PALTI.TI056"
                    + " ,(PALTI.TI042+PALTI.TI043),(PALTI.TI040+PALTI.TI041),CMSMV.MV036", conn);
                    cmdSelect.Parameters.AddWithValue("@DATE", ddlYear.SelectedValue + ddlMonth.SelectedValue);
                    cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                    da.Fill(main_table);
                    /*bonus table*/
                    cmdSelect = new SqlCommand(
                        "SELECT PALTJ.TJ004 加項名稱,(PALTJ.TJ006+PALTJ.TJ007) 加項金額"
                    + " FROM PALTJ"
                    + " WHERE PALTJ.TJ005=N'1' AND PALTJ.TJ002=@DATE AND PALTJ.TJ001=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@DATE", ddlYear.SelectedValue + ddlMonth.SelectedValue);
                    cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    da = new SqlDataAdapter(cmdSelect);
                    da.Fill(bonus_table);
                    /*deduction table*/
                    cmdSelect = new SqlCommand(
                        "SELECT PALTJ.TJ004 減項名稱,(PALTJ.TJ006+PALTJ.TJ007) 減項金額"
                    + " FROM PALTJ"
                    + " WHERE PALTJ.TJ005=N'-1' AND PALTJ.TJ002=@DATE AND PALTJ.TJ001=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@DATE", ddlYear.SelectedValue + ddlMonth.SelectedValue);
                    cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    da = new SqlDataAdapter(cmdSelect);
                    da.Fill(deduction_table);
                    /*attendance table*/
                    cmdSelect = new SqlCommand(
                        "SELECT PALTL.TL005 假別名稱,(PALTL.TL006+PALTL.TL007) 請假數量"
                    + " ,CASE PALTL.TL008"
                    + " WHEN '1' THEN N'天'"
                    + " WHEN '2' THEN N'小時'"
                    + " WHEN '4' THEN N'分鐘'"
                    + " ELSE ''"
                    + " END AS 單位"
                    + " FROM PALTL"
                    + " WHERE (PALTL.TL002+RIGHT('00'+ISNULL(PALTL.TL003,''),2))=@DATE AND PALTL.TL001=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@DATE", ddlYear.SelectedValue + ddlMonth.SelectedValue);
                    cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    da = new SqlDataAdapter(cmdSelect);
                    da.Fill(attendance_table);
                }
                if (main_table.Rows.Count != 0)
                {
                    salary_slip.Visible = true;
                    /*fill main table value*/
                    lblYear.Text = main_table.Rows[0][0].ToString().Substring(0, 4);
                    lblMonth.Text = main_table.Rows[0][0].ToString().Substring(4, 2);
                    lblJob.Text = main_table.Rows[0][1].ToString();
                    lblDept_Id.Text = main_table.Rows[0][2].ToString();
                    lblDept_Name.Text = main_table.Rows[0][3].ToString();
                    lblEmp_Id.Text = main_table.Rows[0][4].ToString();
                    lblEmp_Name.Text = main_table.Rows[0][5].ToString();
                    lblBaseSalary.Text = Convert.ToDouble(main_table.Rows[0][6]).ToString("N0");
                    lblAttendanceBonus.Text = Convert.ToDouble(main_table.Rows[0][7]).ToString("N0");
                    lblOTSalary.Text = Convert.ToDouble(main_table.Rows[0][8]).ToString("N0");
                    lblDayOffDeduction.Text = Convert.ToDouble(main_table.Rows[0][9]).ToString("N0");
                    lblHealthCareDeduction.Text = Convert.ToDouble(main_table.Rows[0][10]).ToString("N0");
                    lblLaborRetirementDeduction.Text = Convert.ToDouble(main_table.Rows[0][11]).ToString("N0");
                    lblEmployeeMatch.Text = Convert.ToDouble(main_table.Rows[0][12]).ToString("N0");
                    lblHealthCareDeductionAppend.Text = Convert.ToDouble(main_table.Rows[0][13]).ToString("N0");
                    lblOTTime.Text = Convert.ToDouble(main_table.Rows[0][14]).ToString("N1");
                    lblCompanyMatch.Text = Convert.ToDouble(main_table.Rows[0][15]).ToString("N0");
                    lblEmployeeMatchTotal.Text = Convert.ToDouble(main_table.Rows[0][16]).ToString("N0");
                    lblCompanyMatchTotal.Text = Convert.ToDouble(main_table.Rows[0][17]).ToString("N0");
                    lblTaxable.Text = Convert.ToDouble(main_table.Rows[0][18]).ToString("N0");
                    lblRealSalary.Text = Convert.ToDouble(main_table.Rows[0][19]).ToString("N0");
                    lblAccount.Text = main_table.Rows[0][20].ToString();
                    /*fill bonus value row by row*/
                    int i = 1; //counter
                    double bonusTotal = 0;
                    foreach (DataRow row in bonus_table.Rows)
                    {
                        Label lbl1 = new Label();
                        lbl1.ID = "lblBonusName" + i.ToString();
                        lbl1.Text = row[0].ToString();
                        pnlBonusName.Controls.Add(lbl1);
                        pnlBonusName.Controls.Add(new LiteralControl("<br />"));
                        Label lbl2 = new Label();
                        lbl2.ID = "lblBonusAmount" + i.ToString();
                        lbl2.Text = Convert.ToDouble(row[1]).ToString("N0");
                        pnlBonusAmount.Controls.Add(lbl2);
                        pnlBonusAmount.Controls.Add(new LiteralControl("<br />"));

                        bonusTotal += Convert.ToDouble(row[1].ToString());
                        i++;
                    }
                    lblBonusTotal.Text = (bonusTotal + Convert.ToDouble(lblOTSalary.Text) + Convert.ToDouble(lblAttendanceBonus.Text)).ToString("N2");
                    /*fill deduction value row by row*/
                    int j = 1; //counter
                    double deductionTotal = 0;
                    foreach (DataRow row in deduction_table.Rows)
                    {
                        Label lbl1 = new Label();
                        lbl1.ID = "lblDeductionName" + j.ToString();
                        lbl1.Text = row[0].ToString();
                        pnlDeductionName.Controls.Add(lbl1);
                        pnlDeductionName.Controls.Add(new LiteralControl("<br />"));
                        Label lbl2 = new Label();
                        lbl2.ID = "lblDeductionAmount" + j.ToString();
                        lbl2.Text = Convert.ToDouble(row[1]).ToString("N0");
                        pnlDeductionAmount.Controls.Add(lbl2);
                        pnlDeductionAmount.Controls.Add(new LiteralControl("<br />"));

                        deductionTotal += Convert.ToDouble(row[1].ToString());
                        j++;
                    }
                    lblDeductionTotal.Text = Math.Round(deductionTotal + Convert.ToDouble(lblDayOffDeduction.Text) + Convert.ToDouble(lblHealthCareDeduction.Text) + Convert.ToDouble(lblLaborRetirementDeduction.Text) + Convert.ToDouble(lblEmployeeMatch.Text) + Convert.ToDouble(lblHealthCareDeductionAppend.Text), 2).ToString("N0");
                    lblNominalSalary.Text = Math.Round(Convert.ToDouble(lblBaseSalary.Text) + Convert.ToDouble(lblBonusTotal.Text), 2).ToString("N0");
                    /*fill attendance*/
                    int k = 1; //counter
                    foreach (DataRow row in attendance_table.Rows)
                    {
                        Label lbl1 = new Label();
                        lbl1.ID = "lblAttendanceName" + k.ToString();
                        lbl1.Text = row[0].ToString();
                        pnlAttendanceName.Controls.Add(lbl1);
                        pnlAttendanceName.Controls.Add(new LiteralControl("<br />"));
                        Label lbl2 = new Label();
                        lbl2.ID = "lblAttendanceAmount" + k.ToString();
                        lbl2.Text = Math.Round(Convert.ToDouble(row[1]), 2).ToString() + row[2].ToString();
                        pnlAttendanceTime.Controls.Add(lbl2);
                        pnlAttendanceTime.Controls.Add(new LiteralControl("<br />"));

                        deductionTotal += Convert.ToDouble(row[1].ToString());
                        k++;
                    }
                }
                else
                {
                    salary_slip.Visible = false;
                    lblErrorMessage.Text = "資料尚未進入系統，請稍後查詢";
                }
            }
            else
            {
                salary_slip.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected bool checkSlipAvailability()
    {
        DateTime slipAvailableDate = DateTime.ParseExact(ddlYear.SelectedValue + ddlMonth.SelectedValue + "05170000", "yyyyMMddHHmmss", null);

        if (DateTime.Now > slipAvailableDate.AddYears(1).AddMonths(1))  //2019.01.31 Check implemented per Chrissy
        {
            lblErrorMessage.Text = "此系統僅能查詢一年內薪資單，如需查詢更久以前的，請與人事部聯繫";
            return false;
        }
        else if (DateTime.Now < slipAvailableDate.AddMonths(1))
        {
            lblErrorMessage.Text = "請於次月六號以後再查詢";
            return false;
        }
        else
        {
            return true;
        }
    }
}