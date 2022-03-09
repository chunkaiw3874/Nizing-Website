using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class hr360_evaluationBonus : System.Web.UI.Page
{
    //每年須手動修改的地方有"edit annually"的字樣，請查詢!!!!!

    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        string assessed = "";
        string year = "";
        if (!IsPostBack)
        {
            assessed = Session["view_id"].ToString().Trim();
            year = Session["view_year"].ToString().Trim();
        }
        else
        {
            assessed = lblEmpID.Text.Trim();
            year = lblEvalYear.Text.Trim();
        }
        if (!IsPostBack)
        {
            loadForm(assessed, year, sender);
        }

    }

    protected void loadForm(string assessed, string year, object sender)
    {
        string query = "";
        DataTable dt = new DataTable();
        lblEmpID.Text = assessed;
        lblEvalYear.Text = year;
        //被評核員工基本資料
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            query = "SELECT CMSMV.MV002"
                + " FROM CMSMV"
                + " WHERE CMSMV.MV001=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblEmpName.Text = dr[0].ToString().Trim();
            }
        }
        //detemin if this id already have record in DB
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "SELECT *"
                + " FROM HR360_ASSESSMENTBONUS_BONUS_A"
                + " WHERE ASSESSED_ID=@ASSESSED_ID"
                + " AND ASSESS_YEAR=@YEAR";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        if (dt.Rows.Count > 0) //has record
        {
            txtAssessmentBonus.Text = dt.Rows[0][2].ToString().Trim();
            txtAssessmentMemo.Text = dt.Rows[0][3].ToString().Trim();
            txtUnusedDayOffBonus.Text = dt.Rows[0][4].ToString().Trim();
            txtUnusedDayOffMemo.Text = dt.Rows[0][5].ToString().Trim();
            txtAttendanceBonus.Text = dt.Rows[0][6].ToString().Trim();
            txtAttendanceMemo.Text = dt.Rows[0][7].ToString().Trim();
            txtRnPBonus.Text = dt.Rows[0][8].ToString().Trim();
            txtRnPMemo.Text = dt.Rows[0][9].ToString().Trim();
            txtOtherBonus.Text = (Convert.ToDouble(dt.Rows[0][10].ToString())+Convert.ToDouble(dt.Rows[0][12].ToString())).ToString();
            txtOtherBonusMemo.Text = dt.Rows[0][11].ToString().Trim();
            //txtOtherDeduction.Text = dt.Rows[0][12].ToString().Trim();
            //txtOtherDeductionMemo.Text = dt.Rows[0][13].ToString().Trim();
            calculateTotal();
        }

        imgBonusAttachment.ImageUrl = "~/hr360/image/assessment/" + year + "/" + year + "-" + assessed + ".jpg";
        imgBonusAttachment.Attributes["onerror"] = "this.style.visibility='hidden'";
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        calculateTotal();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblFinalBonus.Text == "*錯誤的數字格式")
            {

            }
            else
            {
                bool hasRecord = false;
                string query = "";

                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    query = "SELECT ASSESSED_ID"
                        + " FROM HR360_ASSESSMENTBONUS_BONUS_A"
                        + " WHERE ASSESSED_ID=@ID"
                        + " AND ASSESS_YEAR=@YEAR";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        hasRecord = true;
                    }
                    else
                    {
                        hasRecord = false;
                    }
                    dr.Close();
                    if (hasRecord)
                    {
                        query = "UPDATE HR360_ASSESSMENTBONUS_BONUS_A"
                            + " SET ASSESSMENT_BONUS=@ASSESSMENT_BONUS"
                            + " ,ASSESSMENT_MEMO=@ASSESSMENT_MEMO"
                            + " ,UNUSEDDAYOFF_BONUS=@UNUSEDDAYOFF_BONUS"
                            + " ,UNUSEDDAYOFF_MEMO=@UNUSEDDAYOFF_MEMO"
                            + " ,ATTENDANCE_BONUS=@ATTENDANCE_BONUS"
                            + " ,ATTENDANCE_MEMO=@ATTENDANCE_MEMO"
                            + " ,RNP_BONUS=@RNP_BONUS"
                            + " ,RNP_MEMO=@RNP_MEMO"
                            + " ,OTHER_BONUS=@OTHER_BONUS"
                            + " ,OTHER_BONUS_MEMO=@OTHER_BONUS_MEMO" //
                            //+ " ,OTHER_DEDUCTION=@OTHER_DEDUCTION"
                            //+ " ,OTHER_DEDUCTION_MEMO=@OTHER_DEDUCTION_MEMO"//
                            + " WHERE ASSESSED_ID=@ID"
                            + " AND ASSESS_YEAR=@YEAR";
                    }
                    else
                    {
                        query = "INSERT INTO HR360_ASSESSMENTBONUS_BONUS_A"
                            + " VALUES"
                            + " (@ID,@YEAR,@ASSESSMENT_BONUS,@ASSESSMENT_MEMO,@UNUSEDDAYOFF_BONUS,@UNUSEDDAYOFF_MEMO,@ATTENDANCE_BONUS,@ATTENDANCE_MEMO,@RNP_BONUS,@RNP_MEMO"
                            + " ,@OTHER_BONUS,@OTHER_BONUS_MEMO,0,'')";
                    }
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    cmd.Parameters.AddWithValue("@ASSESSMENT_BONUS", txtAssessmentBonus.Text.Trim());
                    cmd.Parameters.AddWithValue("@ASSESSMENT_MEMO", txtAssessmentMemo.Text.Trim());
                    cmd.Parameters.AddWithValue("@UNUSEDDAYOFF_BONUS", txtUnusedDayOffBonus.Text.Trim());
                    cmd.Parameters.AddWithValue("@UNUSEDDAYOFF_MEMO", txtUnusedDayOffMemo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ATTENDANCE_BONUS", txtAttendanceBonus.Text.Trim());
                    cmd.Parameters.AddWithValue("@ATTENDANCE_MEMO", txtAttendanceMemo.Text.Trim());
                    cmd.Parameters.AddWithValue("@RNP_BONUS", txtRnPBonus.Text.Trim());
                    cmd.Parameters.AddWithValue("@RNP_MEMO", txtRnPMemo.Text.Trim());
                    cmd.Parameters.AddWithValue("@OTHER_BONUS", txtOtherBonus.Text.Trim());
                    cmd.Parameters.AddWithValue("@OTHER_BONUS_MEMO", txtOtherBonusMemo.Text.Trim());
                    //cmd.Parameters.AddWithValue("@OTHER_DEDUCTION", txtOtherDeduction.Text.Trim());
                    //cmd.Parameters.AddWithValue("@OTHER_DEDUCTION_MEMO", txtOtherDeductionMemo.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch
        {
            lblFinalBonus.Text = "*錯誤的數字格式";
        }
    }
    protected void calculateTotal()
    {
        double assessmentBonus;
        double unusedDayOffBonus;
        double attendanceBonus;
        double rnpBonus;
        double otherBonus;
        //double otherDeduction;

        if (double.TryParse(txtAssessmentBonus.Text, out assessmentBonus) && double.TryParse(txtUnusedDayOffBonus.Text, out unusedDayOffBonus) && double.TryParse(txtAttendanceBonus.Text, out attendanceBonus)
            &&double.TryParse(txtRnPBonus.Text, out rnpBonus) && double.TryParse(txtOtherBonus.Text, out otherBonus))
        {
            lblFinalBonus.Text = (assessmentBonus + unusedDayOffBonus + attendanceBonus + rnpBonus + otherBonus).ToString();
        }
        else
        {
            lblFinalBonus.Text = "*錯誤的數字格式";
        }
    }
}