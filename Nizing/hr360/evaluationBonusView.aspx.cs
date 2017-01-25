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

public partial class hr360_evaluationBonusView : System.Web.UI.Page
{
    //每年須手動修改的地方有"edit annually"的字樣，請查詢!!!!!

    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        string assessed = Session["erp_id"].ToString();
        string year = Session["view_year"].ToString();

        loadForm(assessed, year);
    }

    protected void loadForm(string assessed, string year)
    {
        string query = "";
        DataTable dt = new DataTable();

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
            lblAssessmentBonus.Text = dt.Rows[0][2].ToString().Trim();
            lblAssessmentMemo.Text = dt.Rows[0][3].ToString().Trim();
            lblUnusedDayOffBonus.Text = dt.Rows[0][4].ToString().Trim();
            lblUnusedDayOffMemo.Text = dt.Rows[0][5].ToString().Trim();
            lblAttendanceBonus.Text = dt.Rows[0][6].ToString().Trim();
            lblAttendanceMemo.Text = dt.Rows[0][7].ToString().Trim();
            lblRnPBonus.Text = dt.Rows[0][8].ToString().Trim();
            lblRnPMemo.Text = dt.Rows[0][9].ToString().Trim();
            lblOtherBonus.Text = dt.Rows[0][10].ToString().Trim();
            lblOtherBonusMemo.Text = dt.Rows[0][11].ToString().Trim();
            lblOtherDeduction.Text = dt.Rows[0][12].ToString().Trim();
            lblOtherDeductionMemo.Text = dt.Rows[0][13].ToString().Trim();
            calculateTotal();
        }

        imgBonusAttachment.ImageUrl = "~/hr360/image/assessment/" + year + "/" + year + "-" + assessed + ".jpg";
        imgBonusAttachment.Attributes["onerror"] = "this.style.visibility='hidden'";
    }
    protected void calculateTotal()
    {
        double assessmentBonus;
        double unusedDayOffBonus;
        double attendanceBonus;
        double rnpBonus;
        double otherBonus;
        double otherDeduction;

        if (double.TryParse(lblAssessmentBonus.Text, out assessmentBonus) && double.TryParse(lblUnusedDayOffBonus.Text, out unusedDayOffBonus) && double.TryParse(lblAttendanceBonus.Text, out attendanceBonus)
            && double.TryParse(lblRnPBonus.Text, out rnpBonus) && double.TryParse(lblOtherBonus.Text, out otherBonus) && double.TryParse(lblOtherDeduction.Text, out otherDeduction))
        {
            lblFinalBonus.Text = (assessmentBonus + unusedDayOffBonus + attendanceBonus + rnpBonus + otherBonus - otherDeduction).ToString();
        }
        else
        {
            lblFinalBonus.Text = "*錯誤的數字格式";
        }
    }
}