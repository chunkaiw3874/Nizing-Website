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

public partial class hr360_evaluationFormViewUser : System.Web.UI.Page
{
    //每年須手動修改的地方有"edit annually"的字樣，請查詢!!!!!

    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    //Setup basic info for the assessment     
    int rowCount = 0;
    int colCount = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        string assessed = "";
        string year = "";
        //////test info
        //Session["erp_id"] = "0133";
        //Session["view_year"] = "2021";
        ////////////////////////////

        if (!IsPostBack)
        {
            assessed = Session["erp_id"].ToString().Trim();
            year = Session["view_year"].ToString().Trim();
        }
        else
        {
            assessed = lblEmpID.Text.Trim();
            year = lblEvalYear.Text.Trim();
        }
        loadSurvey(year, assessed, isAssessed(year, assessed));
    }
    protected void loadSurvey(string year, string assessed, bool isAssessed)
    {
        string query = "";
        //被評核員工基本資料
        DataTable dtAssessedInfo = new DataTable();
        dtAssessedInfo = GetAssessedInfo(year, assessed);
        if (dtAssessedInfo.Rows.Count == 0)
        {
            lblEmpID.Text = assessed;
            lblEmpName.Text = "未評核";
            lblEmpJob.Text = "未評核";
            lblEmpWorkYear.Text = "未評核";
            lblEvalYear.Text = year;
        }
        else
        {
            lblEmpID.Text = assessed;
            lblEmpName.Text = dtAssessedInfo.Rows[0]["assessedName"].ToString().Trim();
            lblEmpJob.Text = dtAssessedInfo.Rows[0]["assessedRank"].ToString().Trim();
            lblEmpWorkYear.Text = dtAssessedInfo.Rows[0]["assessedWorkyear"].ToString().Trim();
            lblEvalYear.Text = year;
        }

        //讀取應評核此人的評核者清單
        DataTable dtAssessorData = new DataTable(); //評核者清單
        dtAssessorData = GetAssessorData(year, assessed);

        //置入標題於QuestionTitleRow
        CreateQuestionTitleRow();

        //讀取問題題目及各題評分
        DataTable dtQuestionData = new DataTable();
        dtQuestionData = GetQuestionData(year, assessed);

        //製作評核問題欄位於divQuestionBodyRow
        CreateQuestionBodyRow(dtQuestionData);
        //讀取最終評核成績
        DataTable dtQuestionnaireScore = new DataTable();
        dtQuestionnaireScore = GetWeightedScore(year, assessed);
        //製作評核問題最終成績欄位於finalScoreRow
        CreateFinalScoreRow(dtQuestionnaireScore);

        //2022.01.21: 加入特評，評核計算方式變更
        if (Convert.ToInt32(year) >= 2021)
        {
            //get assessors, assessment types, weighted scores, if the score is below standard
            DataTable dtAssessorScoreData = GetAssessorScoresAndWeight(Convert.ToInt32(year), assessed);

            //calculate the weight of each assessment types
            double selfEvalWeight = (dtAssessorScoreData.Select("assessType=1")).Count() > 0 ? Convert.ToDouble(dtAssessorScoreData.Select("assessType=1")[0]["scoreWeight"].ToString()) : 0;
            double numberOfSupervisors = (dtAssessorScoreData.Select("assessType=2")).Count();
            double numberOfQualifiedSupervisors = (dtAssessorScoreData.Select("assessType=2 and isQualified=1")).Count();
            double supervisorEvalWeight = (dtAssessorScoreData.Select("assessType=2")).Count() > 0 ? Convert.ToDouble(dtAssessorScoreData.Select("assessType=2")[0]["scoreWeight"].ToString()) * numberOfQualifiedSupervisors / numberOfSupervisors : 0;
            double finalEvalWeight = (dtAssessorScoreData.Select("assessType=3")).Count() > 0 ? Convert.ToDouble(dtAssessorScoreData.Select("assessType=3")[0]["scoreWeight"].ToString()) : 0;
            double specialEvalWeight = (dtAssessorScoreData.Select("assessType=3 and isQualified=0")).Count() > 0 ?
                (Convert.ToDouble(dtAssessorScoreData.Select("assessType=2")[0]["scoreWeight"].ToString()) * (numberOfSupervisors - numberOfQualifiedSupervisors) / numberOfSupervisors)
                + Convert.ToDouble(dtAssessorScoreData.Select("assessType=3")[0]["scoreWeight"].ToString()) : (Convert.ToDouble(dtAssessorScoreData.Select("assessType=2")[0]["scoreWeight"].ToString()) * (numberOfSupervisors - numberOfQualifiedSupervisors) / numberOfSupervisors);
            //get qualify assessor's score for each questions
            //calculate each question's weighted scores
            DataTable dtQuestionWeightedScore = new DataTable();
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                query = ";with selfEvalScore" +
                    " as" +
                    " (" +
                    " select [INDEX]" +
                    " , QUESTION_CATEGORY_WEIGHT" +
                    " , coalesce(cast(SCORE as decimal(5,2)), 0) * " + selfEvalWeight.ToString() + " 'weightedScore'" +
                    " from HR360_ASSESSMENTSCORE_SCORE_A" +
                    " where ASSESS_YEAR = @year" +
                    " and ASSESSED_ID = @assessedId" +
                    " and ASSESSOR_ID = @assessorIdSelf" +
                    " )" +
                    " ,supervisorEvalScore" +
                    " as" +
                    " (" +
                    " select [INDEX]" +
                    " , coalesce(cast(SCORE as decimal(5,2)), 0) * " + supervisorEvalWeight.ToString() + " 'weightedScore'" +
                    " from HR360_ASSESSMENTSCORE_SCORE_A" +
                    " where ASSESS_YEAR = @year" +
                    " and ASSESSED_ID = @assessedId" +
                    " and ASSESSOR_ID = @assessorIdSupervisor" +
                    " )" +
                    " ,finalEvalScore" +
                    " as" +
                    " (" +
                    " select [INDEX]" +
                    " , coalesce(cast(SCORE as decimal(5,2)), 0) * " + finalEvalWeight.ToString() + " 'weightedScore'" +
                    " from HR360_ASSESSMENTSCORE_SCORE_A" +
                    " where ASSESS_YEAR = @year" +
                    " and ASSESSED_ID = @assessedId" +
                    " and ASSESSOR_ID = @assessorIdFinal" +
                    " )" +
                    " ,specialEvalScore" +
                    " as" +
                    " (" +
                    " select ASSESSOR_ID" +
                    " ,[INDEX]" +
                    " , coalesce(cast(SCORE as decimal(5,2)), 0) * " + specialEvalWeight.ToString() + " 'weightedScore'" +
                    " from HR360_ASSESSMENTSCORE_SCORE_A" +
                    " where ASSESS_YEAR = @year" +
                    " and ASSESSED_ID = @assessedId" +
                    " and ASSESSOR_ID = @assessorIdSpecial" +
                    " )" +
                    " select ses.[INDEX] 'questionIndex'" +
                    " ,ses.QUESTION_CATEGORY_WEIGHT 'questionWeight'" +
                    " ,cast((coalesce(ses.weightedScore, 0) + coalesce(superes.weightedScore, 0) + coalesce(fes.weightedScore, 0) + coalesce(speciales.weightedScore, 0)) / 100.0 as decimal(4, 2)) 'questionWeightedScore'" +
                    " from selfEvalScore ses" +
                    " left join supervisorEvalScore superes on ses.[INDEX] = superes.[INDEX]" +
                    " left join finalEvalScore fes on ses.[INDEX] = fes.[INDEX]" +
                    " left join specialEvalScore speciales on ses.[INDEX] = speciales.[INDEX]" +
                    " order by ses.[INDEX]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@assessedId", assessed);
                cmd.Parameters.AddWithValue("@assessorIdSelf", (dtAssessorScoreData.Select("assessType=1")).Count() > 0 ? dtAssessorScoreData.Select("assessType=1")[0]["assessorId"].ToString() : "");
                cmd.Parameters.AddWithValue("@assessorIdSupervisor", (dtAssessorScoreData.Select("assessType=2")).Count() > 0 ? dtAssessorScoreData.Select("assessType=2")[0]["assessorId"].ToString() : "");
                cmd.Parameters.AddWithValue("@assessorIdFinal", (dtAssessorScoreData.Select("assessType=3")).Count() > 0 ? dtAssessorScoreData.Select("assessType=3")[0]["assessorId"].ToString() : "");
                cmd.Parameters.AddWithValue("@assessorIdSpecial", (dtAssessorScoreData.Select("assessType=9")).Count() > 0 ? dtAssessorScoreData.Select("assessType=9")[0]["assessorId"].ToString() : "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtQuestionWeightedScore);
            }
            //calculate final score
            double finalScore = 0;
            double totalScoreWeight = 0;
            double accumulatedWeightedScore = 0;
            for (int i = 0; i < dtQuestionWeightedScore.Rows.Count; i++)
            {
                DataRow dr = dtQuestionWeightedScore.Rows[i];
                Label lbl = (Label)divQuestionBodyRow.FindControl("lblAssessmentScore" + (i+1).ToString());
                lbl.Text = dr["questionWeightedScore"].ToString();
                totalScoreWeight += Convert.ToDouble(dr["questionWeight"].ToString());
                accumulatedWeightedScore += Convert.ToDouble(dr["questionWeightedScore"].ToString()) * Convert.ToDouble(dr["questionWeight"].ToString());
            }
            finalScore = Math.Round(accumulatedWeightedScore / totalScoreWeight, 2);
        }


        //讀取出勤資料
        DataTable dtAttendance = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(";WITH CTE1" +
                " AS" +
                " (" +
                " SELECT PALTL.TL001 EMP_ID" +
                " , PALMC.MC001 DAY_OFF_ID" +
                " , PALMC.MC002 DAY_OFF_TYPE" +
                " , COALESCE(SUM(PALTL.TL006 + PALTL.TL007), 0) DAY_OFF_AMOUNT" +
                " , CASE PALMC.MC004" +
                " WHEN 1 THEN N'天'" +
                " WHEN 2 THEN N'時'" +
                " WHEN 3 THEN N'次'" +
                " WHEN 4 THEN N'分'" +
                " END AS DAY_OFF_UNIT" +
                " FROM PALMC" +
                " LEFT OUTER JOIN PALTL ON PALMC.MC001 = PALTL.TL004 AND PALTL.TL002 = @YEAR AND PALTL.TL001 = @ID" +
                " WHERE PALMC.MC001 <> '21'" +
                " GROUP BY PALTL.TL001, PALMC.MC001, PALMC.MC002, PALMC.MC004" +
                " UNION" +
                " SELECT" +
                " UNPIVOTTABLE.EMP_ID" +
                " , CASE UNPIVOTTABLE.DAY_OFF_TYPE" +
                " WHEN N'遲到' THEN N'98'" +
                " WHEN N'早退' THEN N'99'" +
                " END AS DAY_OFF_ID" +
                " , UNPIVOTTABLE.DAY_OFF_TYPE, UNPIVOTTABLE.DAY_OFF_AMOUNT, N'時' AS DAY_OFF_UNIT" +
                " FROM" +
                " (" +
                " SELECT PALTB.TB001 EMP_ID" +
                " , CONVERT(DECIMAL(16, 2), SUM(PALTB.TB007)) / 60.0 遲到" +
                " , CONVERT(DECIMAL(16, 2), SUM(PALTB.TB008)) / 60.0 早退" +
                " FROM PALTB" +
                " WHERE PALTB.TB001 = @ID AND SUBSTRING(PALTB.TB002, 1, 4) = @YEAR" +
                " GROUP BY PALTB.TB001" +
                " ) AS GROUPTABLE" +
                " UNPIVOT" +
                " (" +
                " DAY_OFF_AMOUNT FOR DAY_OFF_TYPE IN(遲到, 早退)" +
                " ) AS UNPIVOTTABLE" +
                " )," +
                " DAYOFF_SUMMARY" +
                " AS" +
                " (" +
                " SELECT CASE CTE1.DAY_OFF_ID" +
                " WHEN 04 THEN 2" +
                " WHEN 05 THEN 2 " +
                " WHEN 10 THEN 2" +
                " WHEN 98 THEN 2" +
                " WHEN 99 THEN 2" +
                " ELSE 1" +
                " END AS DAY_OFF_CATEGORY" +
                " , DAY_OFF_ID, DAY_OFF_TYPE" +
                " , CASE CTE1.DAY_OFF_UNIT" +
                " WHEN N'天' THEN CONVERT(DECIMAL(16, 2), CONVERT(DECIMAL(16, 2), CTE1.DAY_OFF_AMOUNT) * 8.0)" +
                " WHEN N'分' THEN CONVERT(DECIMAL(16, 2), CONVERT(DECIMAL(16, 2), CTE1.DAY_OFF_AMOUNT) / 60.0)" +
                " ELSE CONVERT(DECIMAL(16, 2), CTE1.DAY_OFF_AMOUNT)" +
                " END AS DAY_OFF_AMOUNT" +
                " , N'時' AS DAY_OFF_UNIT" +
                " FROM CTE1" +
                " )" +
                " SELECT Summary.DAY_OFF_CATEGORY" +
                " , Summary.DAY_OFF_ID" +
                " , Summary.DAY_OFF_TYPE" +
                " , Summary.DAY_OFF_AMOUNT" +
                " , Case Summary.DAY_OFF_ID" +
                " When '02' THEN CONVERT(DECIMAL(16, 1), (TK.TK005 - TK.TK006))" +
                " When '03' Then CONVERT(DECIMAL(16, 1), TK.TK003) - (SELECT SUM(TF008)" +
                " FROM PALTF" +
                " WHERE TF001 = @ID" +
                " AND TF002 LIKE @YEAR + '%'" +
                " AND TF004 = '03')" +
                " Else 0" +
                " END AS DAY_OFF_TOTAL" +
                " ,Summary.DAY_OFF_UNIT" +
                " ,COALESCE(Value.[Value], null) 'Value'" +
                " ,N'分' 'ValueUnit'" +
                " ,COALESCE(Convert(decimal(16, 2), Summary.DAY_OFF_AMOUNT * Value.[Value]), null) 'Subtotal'" +
                " FROM DAYOFF_SUMMARY Summary" +
                " LEFT JOIN NZ_ERP2.dbo.HR360_Attendance_CategoryValue Value on Summary.DAY_OFF_ID = Value.[UID] and Value.[Year]= @YEAR" +
                " LEFT JOIN PALTK TK ON TK.TK001 = @ID AND TK.TK002 = @YEAR" +
                " ORDER BY DAY_OFF_CATEGORY,DAY_OFF_ID", conn);
            cmd.Parameters.AddWithValue("@ID", lblEmpID.Text.Trim());
            cmd.Parameters.AddWithValue("@YEAR", year);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dtAttendance.Load(dr);
            }
        }
        double dayOffSum = 0;  //缺勤小記
        double dayOffValue = 0; //出勤分數
        for (int i = 0; i < dtAttendance.Rows.Count; i++)
        {
            HtmlGenericControl attendanceDiv1 = new HtmlGenericControl("div");
            attendanceDiv1.Attributes["class"] = "row";
            attendanceRecord.Controls.Add(attendanceDiv1);
            HtmlGenericControl attendanceDiv2 = new HtmlGenericControl("div");
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                attendanceDiv2.Attributes["style"] = "text-align:center; background-color:yellow;";
            }
            else
            {
                attendanceDiv2.Attributes["style"] = "text-align:center";
            }
            attendanceDiv2.Attributes["class"] = "col-xs-2 border";
            attendanceDiv2.InnerText = dtAttendance.Rows[i]["DAY_OFF_TYPE"].ToString() ?? "";
            attendanceDiv1.Controls.Add(attendanceDiv2);
            attendanceDiv2 = new HtmlGenericControl("div");
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                attendanceDiv2.Attributes["style"] = "text-align:center; background-color:yellow;";
                attendanceDiv2.InnerHtml = "<span style=\"color:red\">" + dtAttendance.Rows[i]["DAY_OFF_AMOUNT"].ToString() ?? "" + "</span>;";
            }
            else
            {
                attendanceDiv2.Attributes["style"] = "text-align:center";
                attendanceDiv2.InnerHtml = dtAttendance.Rows[i]["DAY_OFF_AMOUNT"].ToString() ?? "";
            }
            attendanceDiv2.Attributes["class"] = "col-xs-2 border";

            attendanceDiv1.Controls.Add(attendanceDiv2);
            attendanceDiv2 = new HtmlGenericControl("div");
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                attendanceDiv2.Attributes["style"] = "text-align:center; background-color:yellow;";
            }
            else
            {
                attendanceDiv2.Attributes["style"] = "text-align:center";
            }
            attendanceDiv2.Attributes["class"] = "col-xs-2 border";
            attendanceDiv2.InnerText = dtAttendance.Rows[i]["DAY_OFF_TOTAL"].ToString() ?? "";
            attendanceDiv1.Controls.Add(attendanceDiv2);
            attendanceDiv2 = new HtmlGenericControl("div");
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                attendanceDiv2.Attributes["style"] = "text-align:center; background-color:yellow;";
            }
            else
            {
                attendanceDiv2.Attributes["style"] = "text-align:center";
            }
            attendanceDiv2.Attributes["class"] = "col-xs-2 border";
            attendanceDiv2.InnerText = dtAttendance.Rows[i]["Value"].ToString() ?? "";
            attendanceDiv1.Controls.Add(attendanceDiv2);
            attendanceDiv2 = new HtmlGenericControl("div");
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                attendanceDiv2.Attributes["style"] = "text-align:center; background-color:yellow;";
            }
            else
            {
                attendanceDiv2.Attributes["style"] = "text-align:center";
            }
            attendanceDiv2.Attributes["class"] = "col-xs-2 border";
            attendanceDiv2.InnerText = dtAttendance.Rows[i]["ValueUnit"].ToString() ?? "";
            attendanceDiv1.Controls.Add(attendanceDiv2);
            attendanceDiv2 = new HtmlGenericControl("div");
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                attendanceDiv2.Attributes["style"] = "text-align:right; background-color:yellow;";
            }
            else
            {
                attendanceDiv2.Attributes["style"] = "text-align:right";
            }
            attendanceDiv2.Attributes["class"] = "col-xs-2 border";
            attendanceDiv2.InnerText = dtAttendance.Rows[i]["Subtotal"].ToString() ?? "";
            attendanceDiv1.Controls.Add(attendanceDiv2);
            if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
            {
                dayOffSum += Convert.ToDouble(dtAttendance.Rows[i]["DAY_OFF_AMOUNT"]);
                if (!String.IsNullOrWhiteSpace(dtAttendance.Rows[i]["SubTotal"].ToString()))
                {
                    dayOffValue += Convert.ToDouble(dtAttendance.Rows[i]["SubTotal"]);
                }
            }
        }
        //計算小計
        lblDayOffSum.Text = dayOffSum.ToString("N2");
        lblDayOffValueSum.Text = dayOffValue.ToString("N2");
        //計算出勤率
        //每年須手動修改需出勤時數 edit annually
        object checkForNull;
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "SELECT [EXPECTED_WORK_HOUR]"
                + " FROM EMPLOYEE_EXPECTED_WORKHOUR"
                + " WHERE [YEAR]=@YEAR"
                + " AND [EMP_ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            cmd.Parameters.AddWithValue("@ID", lblEmpID.Text);
            checkForNull = cmd.ExecuteScalar();
        }
        if (checkForNull != null)
        {
            lblExpectedAttendance.Text = Convert.ToDouble(checkForNull).ToString("N2");
            lblActualAttendance.Text = (Convert.ToDouble(checkForNull) - dayOffSum).ToString("N2");
            lblAttendanceScore.Text = (100 + dayOffValue).ToString("N2");
            lblAttendanceFailure.Text = (((Convert.ToDouble(checkForNull) - dayOffSum) / Convert.ToDouble(checkForNull)) * 100).ToString("N2") + "%";
            //lblOnJobPercent.Text = (Math.Floor(100 * 100 * (1 - (dayOffSum / onJobHour))) / 100).ToString();    //2018.07.23 改成小數第二位無條件捨去
        }
        else
        {
            lblExpectedAttendance.Text = "N/A";
            lblActualAttendance.Text = "N/A";
            lblAttendanceScore.Text = "N/A";
        }


        //讀取獎懲紀錄
        DataTable dtRnPRecord = new DataTable();
        dtRnPRecord = GetRnPData(year, assessed);

        decimal rnpSum = 0;

        for (int i = 0; i < dtRnPRecord.Rows.Count; i++)
        {
            HtmlGenericControl divRnP1 = new HtmlGenericControl("div");
            divRnP1.Attributes["class"] = "row";
            RnPRecord.Controls.Add(divRnP1);
            HtmlGenericControl divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = (i + 1).ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = dtRnPRecord.Rows[i]["EventName"].ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-3 border";
            divRnP1.Controls.Add(divRnP2);
            TextBox txt = new TextBox();
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Enabled = false;
            txt.CssClass = "autosize rnp-textbox";
            txt.Text = dtRnPRecord.Rows[i]["EventContent"].ToString();
            divRnP2.Controls.Add(txt);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = dtRnPRecord.Rows[i]["CategoryName"].ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = dtRnPRecord.Rows[i]["RnPCount"].ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = dtRnPRecord.Rows[i]["RnPUnit"].ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = Convert.ToDecimal(dtRnPRecord.Rows[i]["RnPScore"].ToString()).ToString("N2");
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = dtRnPRecord.Rows[i]["RnPScoreUnit"].ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP2.Attributes["style"] = "text-align:center;";
            divRnP2.InnerText = dtRnPRecord.Rows[i]["Verified"].ToString();
            divRnP1.Controls.Add(divRnP2);
            divRnP2 = new HtmlGenericControl("div");
            divRnP2.Attributes["class"] = "col-xs-1 border";
            divRnP1.Controls.Add(divRnP2);
            txt = new TextBox();
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Enabled = false;
            txt.CssClass = "autosize rnp-textbox";
            txt.Text = dtRnPRecord.Rows[i]["Memo"].ToString();
            divRnP2.Controls.Add(txt);
            if ((bool)dtRnPRecord.Rows[i]["VerifiedID"])
            {
                rnpSum += Convert.ToDecimal(dtRnPRecord.Rows[i]["RnPScore"].ToString());
            }
        }
        lblFinalRnPScore.Text = rnpSum.ToString("N2");



        //////comments~
        //for (int i = 0; i < dtAssessorList.Rows.Count; i++)
        //{            
        //    //add comment row with respective 評分者名字
        //    if (dtAssessorList.Rows[i][3].ToString() == "1") //自評評語
        //    {
        //        txtSelfComment.Text = dtAssessorList.Rows[i][4].ToString() ?? "未評核";
        //    }
        //    else
        //    {
        //        //評語 title
        //        HtmlGenericControl outerDiv = new HtmlGenericControl();
        //        outerDiv.TagName = "div";
        //        outerDiv.ID = "commentRowTitle" + (i + 1).ToString();
        //        outerDiv.Attributes["class"] = "row";
        //        comment.Controls.Add(outerDiv);
        //        div = new HtmlGenericControl();
        //        div.TagName = "div";
        //        div.ID = outerDiv.ID + "_1";
        //        div.Attributes["class"] = "col-xs-12 subtitle border";
        //        div.InnerText = /*dtAssessorList.Rows[i][1].ToString() +*/ "評語"; //2017.03.01 將第二層評語改為匿名制
        //        outerDiv.Controls.Add(div);
        //        //評語 textbox
        //        outerDiv = new HtmlGenericControl();
        //        outerDiv.TagName = "div";
        //        outerDiv.ID = "commentRowBody" + (i + 1).ToString();
        //        outerDiv.Attributes["class"] = "row";
        //        comment.Controls.Add(outerDiv);
        //        div = new HtmlGenericControl();
        //        div.TagName = "div";
        //        div.ID = outerDiv.ID + "_1";
        //        div.Attributes["class"] = "col-xs-12 border";
        //        outerDiv.Controls.Add(div);
        //        TextBox txt = new TextBox();
        //        txt.ID = "txtCommentRow_Comment" + dtAssessorList.Rows[i][0].ToString();
        //        txt.CssClass = "form-control no-resize autosize";
        //        txt.ReadOnly = true;
        //        txt.Text = dtAssessorList.Rows[i][4].ToString() ?? "未評核";
        //        txt.TextMode = TextBoxMode.MultiLine;
        //        txt.Wrap = true;
        //        div.Controls.Add(txt);
        //    }
        //}        
        //if (!IsPostBack)
        //{
        //    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        //    {
        //        conn.Open();
        //        //load Chrissy's Comment
        //        query = "SELECT COMMENT"
        //            + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
        //            + " WHERE ASSESSED_ID=@ASSESSED"
        //            + " AND ASSESSOR_ID=@ASSESSOR"
        //            + " AND ASSESS_YEAR=@YEAR";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@ASSESSOR", "0007");
        //        cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
        //        cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
        //        if (cmd.ExecuteScalar() != null)
        //        {
        //            txt0007Comment.Text = cmd.ExecuteScalar().ToString();
        //        }
        //        //load 吉田's comment
        //        query = "SELECT COMMENT"
        //            + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
        //            + " WHERE ASSESSED_ID=@ASSESSED"
        //            + " AND ASSESSOR_ID=@ASSESSOR"
        //            + " AND ASSESS_YEAR=@YEAR";
        //        cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@ASSESSOR", "0067");
        //        cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
        //        cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
        //        if (cmd.ExecuteScalar() != null)
        //        {
        //            txt0067Comment.Text = cmd.ExecuteScalar().ToString();
        //        }
        //        //load Kelven's Comment
        //        query = "SELECT COMMENT"
        //            + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
        //            + " WHERE ASSESSED_ID=@ASSESSED"
        //            + " AND ASSESSOR_ID=@ASSESSOR"
        //            + " AND ASSESS_YEAR=@YEAR";
        //        cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@ASSESSOR", "0006");
        //        cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
        //        cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
        //        if (cmd.ExecuteScalar() != null)
        //        {
        //            txt0006Comment.Text = cmd.ExecuteScalar().ToString();
        //        }
        //    }
        //}
        ///////////////////////////////////////
        //if (string.IsNullOrWhiteSpace(txt0006Comment.Text))
        //{
        //    div0006_comment.Visible = false;
        //}
        //else
        //{
        //    div0006_comment.Visible = true;
        //}
        //if (string.IsNullOrWhiteSpace(txt0007Comment.Text))
        //{
        //    div0007_comment.Visible = false;
        //}
        //else
        //{
        //    div0007_comment.Visible = true;
        //}
        //if (string.IsNullOrWhiteSpace(txt0067Comment.Text))
        //{
        //    div0067_comment.Visible = false;
        //}
        //else
        //{
        //    div0067_comment.Visible = true;
        //}
        #region 評語
        //擷取特別評語擁有者清單
        List<string> assessorsWithOwnCommentSection = new List<string>();
        assessorsWithOwnCommentSection = GetSpecialCommentator(year);

        //評語欄位包含被評核者、評核主管、核決主管、及特別評語擁有者，duplicate commentator are to be removed
        //Combining commentators to a single list
        List<string> commentatorList = dtAssessorData.AsEnumerable().Select(x => x["ASSESSOR_ID"].ToString()).ToList();
        foreach (string s in assessorsWithOwnCommentSection)
        {
            if (!commentatorList.Contains(s))
            {
                commentatorList.Add(s);
            }
        }

        //製作評語欄位於comment
        DataTable dtComment = new DataTable();
        dtComment = GetCommentData(commentatorList, year, assessed);
        CreateCommentRow(commentatorList, assessorsWithOwnCommentSection, dtComment);
        #endregion
    }

    private bool isAssessed(string year, string assessed)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select ASSESSMENT_DONE" +
                " from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A" +
                " where [YEAR]=@year" +
                " and [ASSESSED_ID]=@assessedId" +
                " and [ASSESSMENT_DONE]=@assessmentDone" +
                " and [ACTIVE]=@active";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            cmd.Parameters.AddWithValue("@assessmentDone", '1');
            cmd.Parameters.AddWithValue("@active", "1");
            return cmd.ExecuteScalar() == null ? false : Convert.ToBoolean(Convert.ToInt32(cmd.ExecuteScalar().ToString()));
        }
    }

    private DataTable GetAssessedInfo(string year, string assessed)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select top 1 ASSESSED.ASSESSED_ID 'assessedId'" +
                " ,MV.MV002 'assessedName'" +
                " ,ASSESSED.ASSESSED_RANK 'assessedRank'" +
                " ,ASSESSED.ASSESSED_WORKYEAR 'assessedWorkyear'" +
                " ,ASSESSED.ASSESS_YEAR 'assessYear'" +
                " from HR360_ASSESSMENTSCORE_ASSESSED_A ASSESSED" +
                " left join  NZ.dbo.CMSMV MV on ASSESSED.ASSESSED_ID=MV.MV001" +
                " where ASSESSED.ASSESSED_ID=@assessedId" +
                " and ASSESSED.ASSESS_YEAR=@assessYear";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            cmd.Parameters.AddWithValue("@assessYear", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private DataTable GetAssessorData(string year, string assessed)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            string query = "SELECT DISTINCT A.ASSESSOR_ID" +
                    ",C.MV002 'ASSESSOR_NAME'" +
                    ",B.NAME 'TYPE_NAME'" +
                    ",A.ASSESS_TYPE 'ASSESS_TYPE'" +
                    ",A.ASSESSOR_ORDER" +
                    ",D.OVERALL_COMMENT" +
                    ",E.assessorSupervisorAmount" +
                    ",E.assessorFinalizerAmount"
                    + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                    + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A B ON A.ASSESS_TYPE=B.ID"
                    + " LEFT JOIN NZ.dbo.CMSMV C ON A.ASSESSOR_ID=C.MV001"
                    + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A D ON A.ASSESSOR_ID=D.ASSESSOR_ID AND A.ASSESSED_ID=D.ASSESSED_ID AND A.[YEAR]=D.ASSESS_YEAR"
                    + " LEFT JOIN HR360_AssessmentPersonnel_Assignment_B E ON A.ASSESSED_ID=E.assessedID and A.[YEAR]=E.assessYear"
                    + " WHERE A.ASSESSED_ID=@ASSESSED_ID"
                    + " AND A.[YEAR]=@YEAR"
                    + " AND A.[ACTIVE]='1'"
                    + " ORDER BY A.ASSESS_TYPE,A.ASSESSOR_ORDER";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    private DataTable GetQuestionData(string year, string assessed)
    {
        DataTable dt = new DataTable();
        string query = "";

        if (Convert.ToInt32(year) > 2018)
        {
            query = ";with score" +
                " as" +
                " (" +
                " SELECT score.[INDEX]" +
                " ,score.QUESTION_CATEGORY_ID" +
                " ,score.QUESTION_CATEGORY_NAME" +
                " ,score.QUESTION_CATEGORY_WEIGHT" +
                " ,score.QUESTION" +
                " ,[weight].scoreWeight" +
                " ,AVG(CONVERT(DECIMAL(4,2),score.SCORE)) SCORE" +
                " FROM HR360_ASSESSMENTSCORE_SCORE_A score" +
                " left join HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A assignment on score.ASSESS_YEAR=assignment.[YEAR] and score.ASSESSOR_ID= assignment.ASSESSOR_ID and score.ASSESSED_ID= assignment.ASSESSED_ID" +
                " left join HR360_AssessmentCategory_CategoryWeight[weight] on assignment.ASSESS_TYPE=[weight].assessType" +
                " WHERE assignment.ASSESS_TYPE= '2'" +
                " and score.ASSESSED_ID= @assessedId" +
                " AND score.ASSESS_YEAR= @assessYear" +
                " GROUP BY score.[INDEX]" +
                " , score.QUESTION_CATEGORY_ID" +
                " , score.QUESTION_CATEGORY_NAME" +
                " , score.QUESTION_CATEGORY_WEIGHT" +
                " , score.QUESTION" +
                " , weight.scoreWeight" +
                " union all" +
                " SELECT score.[INDEX]" +
                " , score.QUESTION_CATEGORY_ID" +
                " , score.QUESTION_CATEGORY_NAME" +
                " , score.QUESTION_CATEGORY_WEIGHT" +
                " , score.QUESTION" +
                " , [weight].scoreWeight" +
                " , score.SCORE" +
                " FROM HR360_ASSESSMENTSCORE_SCORE_A score" +
                " left join HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A assignment on score.ASSESS_YEAR= assignment.[YEAR] and score.ASSESSOR_ID= assignment.ASSESSOR_ID and score.ASSESSED_ID= assignment.ASSESSED_ID" +
                " left join HR360_AssessmentCategory_CategoryWeight[weight] on assignment.ASSESS_TYPE=[weight].assessType" +
                " WHERE assignment.ASSESS_TYPE<>'2'" +
                " and score.ASSESS_YEAR= @assessYear" +
                " AND score.ASSESSED_ID= @assessedId" +
                " )" +
                " select[INDEX]" +
                " ,QUESTION_CATEGORY_ID" +
                " ,QUESTION_CATEGORY_NAME" +
                " ,QUESTION_CATEGORY_WEIGHT" +
                " ,QUESTION" +
                " ,convert(decimal(4,2),SUM(convert(decimal(4,2),SCORE)*convert(decimal(4,2),scoreWeight)/100)) 'weightedScore'" +
                " from score" +
                " group by[INDEX]" +
                " , QUESTION_CATEGORY_ID" +
                " , QUESTION_CATEGORY_NAME" +
                " , QUESTION_CATEGORY_WEIGHT" +
                " , QUESTION" +
                " ORDER BY[INDEX]";
        }
        else
        {
            query = "SELECT [INDEX]" +
                " ,QUESTION_CATEGORY_ID" +
                " ,QUESTION_CATEGORY_NAME" +
                " ,QUESTION_CATEGORY_WEIGHT" +
                " ,QUESTION" +
                " ,coalesce(convert(decimal(4, 2), sum(convert(decimal(4, 2), SCORE)) / convert(decimal(4, 2), (select COUNT(*) from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A where [YEAR] = @assessYear and ASSESSED_ID = @assessedId and ACTIVE = '1'))), '') 'weightedScore'" +
                " FROM HR360_ASSESSMENTSCORE_SCORE_A" +
                " WHERE ASSESSED_ID = @assessedId" +
                " AND ASSESS_YEAR = @assessYear" +
                " group by[INDEX]" +
                " , QUESTION_CATEGORY_ID" +
                " , QUESTION_CATEGORY_NAME" +
                " , QUESTION_CATEGORY_WEIGHT" +
                " , QUESTION" +
                " order by[INDEX]";
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            cmd.Parameters.AddWithValue("@assessYear", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    //2021之前使用
    private DataTable GetWeightedScore(string year, string assessed)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select EvaluationScore" +
                " from HR360_AssessmentScore_FinalScore" +
                " where AssessYear=@assessYear" +
                " and EmpID=@assessedId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessYear", year);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private void CreateQuestionTitleRow()
    {
        //column 1 題號
        HtmlGenericControl div = new HtmlGenericControl();
        div.TagName = "div";
        div.ID = "QuestionTitleRow_1";
        div.Attributes["class"] = "col-xs-1 border";
        divQuestionTitleRow.Controls.Add(div);
        Label lbl = new Label();
        lbl.CssClass = "form-control text-center";
        lbl.Text = "#";
        div.Controls.Add(lbl);
        //column 2 分類
        div = new HtmlGenericControl();
        div.TagName = "div";
        div.ID = "QuestionTitleRow_2";
        div.Attributes["class"] = "col-xs-2 border";
        divQuestionTitleRow.Controls.Add(div);
        lbl = new Label();
        lbl.CssClass = "form-control text-center";
        lbl.Text = "分類";
        div.Controls.Add(lbl);
        //column 3 權重
        div = new HtmlGenericControl();
        div.TagName = "div";
        div.ID = "QuestionTitleRow_3";
        div.Attributes["class"] = "col-xs-1 border";
        divQuestionTitleRow.Controls.Add(div);
        lbl = new Label();
        lbl.CssClass = "form-control text-center";
        lbl.Text = "權重";
        div.Controls.Add(lbl);
        //column 4 問題
        div = new HtmlGenericControl();
        div.TagName = "div";
        div.ID = "QuestionTitleRow_4";
        div.Attributes["class"] = "border col-xs-" + (8 - 1 * colCount).ToString();
        divQuestionTitleRow.Controls.Add(div);
        lbl = new Label();
        lbl.CssClass = "form-control text-center";
        lbl.Text = "問題";
        div.Controls.Add(lbl);
        //column 5 核定分數
        div = new HtmlGenericControl();
        div.TagName = "div";
        div.ID = "QuestionTitleRow_5";
        div.Attributes["class"] = "border col-xs-1";
        divQuestionTitleRow.Controls.Add(div);
        lbl = new Label();
        lbl.CssClass = "form-control text-center";
        lbl.Text = "核定";
        div.Controls.Add(lbl);
    }

    private DataTable GetRnPData(string year, string assessed)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select eventCategory.Name 'EventName'"
                + " ,record.[EventContent] 'EventContent'"
                + " ,rnpCategory.Name 'CategoryName'"
                + " ,record.RNPCount 'RnPCount'"
                + " ,rnpCategory.[Unit] 'RnPUnit'"
                + " ,record.RNPCount * value.Value 'RnPScore'"
                + " ,'分' 'RnPScoreUnit'"
                + " ,record.Verified 'VerifiedID'"
                + " ,case record.Verified"
                + " when 1 then '已核准'"
                + " else '未核准'"
                + " end as 'Verified'"
                + " ,coalesce(record.Memo,'') 'Memo'"
                + " from HR360_RewardAndPenalty_Record record"
                + " left join HR360_RewardAndPenalty_RnPCategory rnpCategory on record.RNPID=rnpCategory.[UID]"
                + " left join HR360_RewardAndPenalty_RnPValueSetting value on rnpCategory.[UID]=value.[UID] and value.[Year]=@year"
                + " left join HR360_RewardAndPenalty_Category category on rnpCategory.Category=category.[UID]"
                + " left join HR360_RewardAndPenalty_EventCategory eventCategory on record.EventID=eventCategory.[UID]"
                + " where record.EmpID=@ID"
                + " and record.[Year]=@year"
                + " and record.[Verified]=1"
                + " order by record.RNPID,record.EventID,record.CreateDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            cmd.Parameters.AddWithValue("@year", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    private List<string> GetSpecialCommentator(string year)
    {
        List<string> s = new List<string>();

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select commentatorId" +
                " from HR360_AssessmentPersonnel_SpecialCommentator" +
                " where assessYear=@assessYear" +
                " order by importance desc";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessYear", year);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    s.Add(dr.GetString(0));
                }
            }
        }

        return s;
    }

    private DataTable GetCommentData(List<string> commentatorList, string year, string assessed)
    {
        DataTable dt = new DataTable();
        string condition = "";
        if (commentatorList.Count > 0)
        {
            for (int i = 0; i < commentatorList.Count; i++)
            {
                if (i == 0)
                {
                    condition = " mv.MV001='" + commentatorList[i] + "'";
                }
                else
                {
                    condition += " or mv.MV001='" + commentatorList[i] + "'";
                }
            }
        }
        else
        {
            condition = " 1<>1"; //since there's no commentator, no result shuld be returned
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = ";with comment" +
                " as" +
                " (" +
                " select ASSESSOR_ID" +
                " ,OVERALL_COMMENT 'COMMENT'" +
                " from HR360_ASSESSMENTSCORE_ASSESSED_A" +
                " where ASSESS_YEAR = @assessYear" +
                " and ASSESSED_ID = @assessed" +
                " and OVERALL_COMMENT is not null" +
                " union" +
                " select ASSESSOR_ID" +
                " ,COMMENT" +
                " from HR360_ASSESSMENTSCORE_ASSESSED_B" +
                " WHERE ASSESS_YEAR = @assessYear" +
                " and ASSESSED_ID = @assessed" +
                " and COMMENT is not null" +
                " )" +
                " select LTRIM(RTRIM(mv.MV001)) 'ASSESSOR_ID'" +
                " ,mv.MV002 'ASSESSOR_NAME'" +
                " ,cmt.COMMENT" +
                " from comment cmt" +
                " right join NZ.dbo.CMSMV mv on mv.MV001 = cmt.ASSESSOR_ID" +
                " where " +
                condition;

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessYear", year);
            cmd.Parameters.AddWithValue("@assessed", assessed);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private void CreateQuestionBodyRow(DataTable dtQuestionData)
    {
        for (int i = 0; i < dtQuestionData.Rows.Count; i++)
        {
            HtmlGenericControl outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "questionRow" + (i + 1).ToString();
            outerDiv.Attributes["class"] = "row";
            divQuestionBodyRow.Controls.Add(outerDiv);
            //column 1 題號
            HtmlGenericControl div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = outerDiv.ID + "_1";
            div.Attributes["class"] = "col-xs-1 border";
            outerDiv.Controls.Add(div);
            Label lbl = new Label();
            lbl.ID = "lblIndex" + (i + 1).ToString();
            lbl.CssClass = "form-control text-center col" + (i + 1) + "_1";
            lbl.Text = dtQuestionData.Rows[i]["INDEX"].ToString();
            div.Controls.Add(lbl);
            //column 2 分類
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = outerDiv.ID + "_2";
            div.Attributes["class"] = "col-xs-2 border";
            outerDiv.Controls.Add(div);
            lbl = new Label();
            lbl.ID = "lblAssessmentCategory" + (i + 1).ToString();
            lbl.CssClass = "form-control text-center col" + (i + 1) + "_2";
            lbl.Text = dtQuestionData.Rows[i]["QUESTION_CATEGORY_ID"].ToString() + "_" + dtQuestionData.Rows[i]["QUESTION_CATEGORY_NAME"].ToString();
            div.Controls.Add(lbl);
            //column 3 權重
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = outerDiv.ID + "_3";
            div.Attributes["class"] = "col-xs-1 border";
            outerDiv.Controls.Add(div);
            lbl = new Label();
            lbl.ID = "lblAssessmentCategoryWeight" + (i + 1).ToString();
            lbl.CssClass = "form-control text-center col" + (i + 1) + "_3";
            lbl.Text = dtQuestionData.Rows[i]["QUESTION_CATEGORY_WEIGHT"].ToString();
            div.Controls.Add(lbl);
            //column 4 問題
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = outerDiv.ID + "_4";
            div.Attributes["class"] = "border col-xs-" + (8 - 1 * colCount).ToString();
            outerDiv.Controls.Add(div);
            TextBox txt = new TextBox();
            txt.ID = "txtAssessmentQuestion" + (i + 1).ToString();
            txt.ReadOnly = true;
            txt.TextMode = TextBoxMode.MultiLine;
            txt.CssClass = "form-control no-resize autosize max-height col" + (i + 1) + "_4";
            txt.Text = dtQuestionData.Rows[i]["QUESTION"].ToString();
            div.Controls.Add(txt);
            //column 5 分數
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = outerDiv.ID + "_5";
            div.Attributes["class"] = "border col-xs-1";
            outerDiv.Controls.Add(div);
            lbl = new Label();
            lbl.ID = "lblAssessmentScore" + (i + 1).ToString();
            lbl.CssClass = "form-control text-center col" + (i + 1) + "_5";
            lbl.Text = dtQuestionData.Rows[i]["weightedScore"].ToString();
            div.Controls.Add(lbl);
        }
    }

    private void CreateFinalScoreRow(DataTable dtWeightedScore)
    {
        //置入各評核者所打的最終分數
        HtmlGenericControl div = new HtmlGenericControl();
        div.TagName = "div";
        div.Attributes["class"] = "border col-xs-10";
        finalScoreRow.Controls.Add(div);
        Label lbl = new Label();
        lbl.CssClass = "form-control text-right text-color-green";
        lbl.Text = "小記";
        div.Controls.Add(lbl);

        div = new HtmlGenericControl();
        div.TagName = "div";
        div.ID = "finalScoreRow_1";
        div.Attributes["class"] = "border col-xs-2";
        finalScoreRow.Controls.Add(div);
        lbl = new Label();
        lbl.CssClass = "form-control text-center text-color-green";
        lbl.Text = dtWeightedScore.Rows.Count <= 0 ? "未評核" : dtWeightedScore.Rows[0]["EvaluationScore"].ToString();
        div.Controls.Add(lbl);
    }

    private void CreateCommentRow(List<string> commentatorList, List<string> specialCommentator, DataTable dtComments)
    {
        for (int i = 0; i < commentatorList.Count; i++)
        {
            var commentatorData = dtComments.AsEnumerable().Where(x => x.Field<string>("ASSESSOR_ID") == commentatorList[i]).FirstOrDefault();
            string commentatorName = commentatorData["ASSESSOR_NAME"].ToString();
            string commentatorContent = commentatorData["COMMENT"].ToString();


            HtmlGenericControl outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "commentRow" + commentatorList[i];
            comment.Controls.Add(outerDiv);
            HtmlGenericControl rowDiv = new HtmlGenericControl();
            rowDiv.TagName = "div";
            rowDiv.Attributes["class"] = "row";
            outerDiv.Controls.Add(rowDiv);
            HtmlGenericControl titleDiv = new HtmlGenericControl();
            titleDiv.TagName = "div";
            titleDiv.Attributes["class"] = "col-xs-12 subtitle border";
            titleDiv.InnerText = commentatorName.ToString() + "建議事項";
            rowDiv.Controls.Add(titleDiv);
            rowDiv = new HtmlGenericControl();
            rowDiv.TagName = "div";
            rowDiv.Attributes["class"] = "row";
            outerDiv.Controls.Add(rowDiv);
            HtmlGenericControl bodyDiv = new HtmlGenericControl();
            bodyDiv.TagName = "div";
            bodyDiv.Attributes["class"] = "col-xs-12 border";
            rowDiv.Controls.Add(bodyDiv);
            HtmlGenericControl controlDiv = new HtmlGenericControl();
            controlDiv.TagName = "div";
            bodyDiv.Controls.Add(controlDiv);
            TextBox txt = new TextBox();
            txt.ID = "txtComment" + commentatorList[i];
            txt.CssClass = "form-control no-resize autosize";
            txt.ReadOnly = true;
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Wrap = true;
            txt.Text = commentatorContent == null ? "" : commentatorContent.ToString();
            controlDiv.Controls.Add(txt);
        }
    }

    protected DataTable GetAssessorScoresAndWeight(int assessYear, string assessedId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = ";WITH SCORE_TABLE" +
                " AS" +
                " (" +
                " SELECT A.ASSESSED_ID[受評者ID]" +
                " , cast(coalesce(B.WEIGHTED_SCORE, cast(0 as decimal(4, 2))) as decimal(4, 2))[自評分數]" +
                " , (SELECT coalesce(scoreWeight, 0)" +
                " from HR360_AssessmentCategory_CategoryWeight" +
                " where assessYear = @YEAR" +
                " and assessType = '1') '自評權重'" +
                " ,cast(coalesce(C.WEIGHTED_SCORE, cast(0 as decimal(4, 2))) as decimal(4, 2))[主管評分數]" +
                " ,(SELECT coalesce(scoreWeight, 0)" +
                " from HR360_AssessmentCategory_CategoryWeight" +
                " where assessYear = @YEAR" +
                " and assessType = '2') '主管評權重'" +
                " ,(select ASSESSOR_ID" +
                " from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A C1" +
                " where C1.[YEAR]= @YEAR" +
                " and C1.ASSESSED_ID = A.ASSESSED_ID" +
                " and C1.ASSESS_TYPE = '3') '核決主管ID'" +
                " ,cast(coalesce(D.WEIGHTED_SCORE, cast(0 as decimal(4, 2))) as decimal(4, 2))[核決主管評分數]" +
                " ,(SELECT coalesce(scoreWeight, 0)" +
                " from HR360_AssessmentCategory_CategoryWeight" +
                " where assessYear = @YEAR" +
                " and assessType = '3') '核決主管評權重'" +
                " ,cast(coalesce(E.WEIGHTED_SCORE, cast(0 as decimal(4, 2))) as decimal(4, 2))特評分數" +
                " ,cast(coalesce(SCORE.ATTENDANCE_SCORE, cast(0 as decimal(5, 2))) as decimal(5, 2))[出勤成績]" +
                " ,cast(coalesce(SCORE.RNP_SCORE, cast(0 as decimal(5, 2))) as decimal(5, 2))[獎懲成績]" +
                " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSED_ID = MV.MV001" +
                " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID = SCORE.ASSESSOR_ID AND A.ASSESSED_ID = SCORE.ASSESSED_ID AND A.[YEAR]= SCORE.ASSESS_YEAR" +
                " LEFT JOIN" +
                " (" +
                " SELECT A.ASSESSED_ID, SCORE.WEIGHTED_SCORE 'WEIGHTED_SCORE'" +
                " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID = SCORE.ASSESSOR_ID AND A.ASSESSED_ID = SCORE.ASSESSED_ID AND A.[YEAR]= SCORE.ASSESS_YEAR" +
                " WHERE A.ACTIVE = '1' AND A.ASSESS_TYPE = '1'" +
                " AND A.[YEAR]= @YEAR" +
                " ) B ON A.ASSESSOR_ID = B.ASSESSED_ID" +
                " LEFT JOIN" +
                " (" +
                " SELECT A.ASSESSED_ID, AVG(CONVERT(DECIMAL(5,2),SCORE.WEIGHTED_SCORE)) 'WEIGHTED_SCORE'" +
                " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID = SCORE.ASSESSOR_ID AND A.ASSESSED_ID = SCORE.ASSESSED_ID AND A.[YEAR]= SCORE.ASSESS_YEAR" +
                " WHERE A.ACTIVE = '1' AND A.ASSESS_TYPE = '2'" +
                " AND A.[YEAR]= @YEAR" +
                " GROUP BY A.ASSESSED_ID" +
                " ) C ON A.ASSESSOR_ID = C.ASSESSED_ID" +
                " LEFT JOIN" +
                " (" +
                " SELECT A.ASSESSED_ID, SCORE.WEIGHTED_SCORE" +
                " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID= SCORE.ASSESSOR_ID AND A.ASSESSED_ID= SCORE.ASSESSED_ID AND A.[YEAR]= SCORE.ASSESS_YEAR" +
                " WHERE A.ACTIVE= '1' AND A.ASSESS_TYPE= '3'" +
                " AND A.[YEAR]= @YEAR" +
                " ) D ON A.ASSESSOR_ID = D.ASSESSED_ID" +
                " LEFT JOIN" +
                " (" +
                " SELECT A.ASSESSED_ID, SCORE.WEIGHTED_SCORE" +
                " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A" +
                " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID= SCORE.ASSESSOR_ID AND A.ASSESSED_ID= SCORE.ASSESSED_ID AND A.[YEAR]= SCORE.ASSESS_YEAR" +
                " WHERE A.ACTIVE= '1' AND A.ASSESS_TYPE= '9'" +
                " AND A.[YEAR]= @YEAR" +
                " ) E ON A.ASSESSOR_ID = E.ASSESSED_ID" +
                " WHERE A.ACTIVE = '1'" +
                " AND A.ASSESS_TYPE = '1'" +
                " AND A.[YEAR]= @YEAR" +
                " )" +
                " ,finalScore" +
                " as" +
                " (" +
                " SELECT st.受評者ID[empId]" +
                " ,cast(((st.自評分數 * st.自評權重 / 10.0) + (st.主管評分數 * st.主管評權重 / 10.0) + (st.核決主管評分數 * st.核決主管評權重 / 10.0)) * 0.8 + st.出勤成績 * 0.2 + st.獎懲成績 as decimal(5, 2)) 'finalScore'" +
                " FROM SCORE_TABLE st" +
                " union" +
                " select '0006', 100" +     //0006跟0007因為不需要經過評核，故手動加入
                " union" +
                " select '0007', 100" +
                " )" +
                " select fs.empId 'assessorId'" +
                " ,fs.finalScore 'score'" +
                " ,assignment.ASSESS_TYPE 'assessType'" +
                " ,cw.scoreWeight" +
                " ,case" +
                " when fs.finalScore < (SELECT COALESCE(SCORE_STANDARD, 0)" +
                " FROM HR360_ASSESSMENTSCORE_STANDARD" +
                " where[YEAR] = (SELECT" +
                " MAX([YEAR])" +
                " FROM HR360_ASSESSMENTSCORE_STANDARD" +
                " WHERE[YEAR] <= @YEAR))" +
                " then 0" +
                " else 1" +
                " end as 'isQualified'" +
                " from finalScore fs" +
                " left join HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A assignment" +
                " on fs.empId = assignment.ASSESSOR_ID" +
                " and assignment.[YEAR]= @YEAR" +
                " left join HR360_AssessmentCategory_CategoryWeight cw on assignment.ASSESS_TYPE = cw.assessType and assignment.[YEAR]= cw.assessYear" +
                " where assignment.ASSESSED_ID = @assessedId" +
                " and assignment.ACTIVE = '1'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", assessYear);
            cmd.Parameters.AddWithValue("@assessedId", assessedId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }
}