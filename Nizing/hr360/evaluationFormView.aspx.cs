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

public partial class hr360_evaluationFormView : System.Web.UI.Page
{
    //每年須手動修改的地方有"edit annually"的字樣，請查詢!!!!!

    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    //Setup basic info for the assessment     
    int rowCount = 0;
    int colCount = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string assessed = "";
        string year = "";

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                year = Request.QueryString["year"];
                assessed = Request.QueryString["ID"];
            }
            else
            {
                assessed = Session["view_id"].ToString().Trim();
                year = Session["view_year"].ToString().Trim();

                /////////test 
                //assessed = "0142";
                //year = "2019";
                //Session["erp_id"] = "0007";
                ////////////////////////////
            }
        }
        else
        {
            assessed = lblEmpID.Text.Trim();
            year = lblEvalYear.Text.Trim();
        }
        loadSurvey(year, assessed);
    }
    protected void loadSurvey(string year, string assessed)
    {
        #region 基本資料
        //顯示被評核者基本資料
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
        #endregion

        #region 評核問題及成績
        //讀取應評核此人的評核者清單
        DataTable dtAssessorData = new DataTable(); //評核者清單
        dtAssessorData = GetAssessorData(year, assessed);

        //計算評核者所需column數量
        if (Convert.ToInt32(year) < 2019)    //2019年前採用1自評+1主管評(+特評)、2019年後採用1自評+n主管評+1核決主管評
        {
            colCount = dtAssessorData.Rows.Count; //有幾個評核者-出現同樣數目的分數欄
        }
        else
        {
            colCount = Convert.ToInt32(dtAssessorData.Rows[0]["assessorSupervisorAmount"].ToString()) == 0 ? 2 : 3; //主管評呈現方式採用平均值，自評及核決主管評皆為固定一位，所以不是2就是3
        }
            
        //製作評核問題標題欄位於divQuestionTitleRow
        CreateQuestionTitleRow(dtAssessorData, colCount);

        //讀取問題題目及各題評分
        DataTable dtQuestionData = new DataTable();
        dtQuestionData = GetQuestionData(dtAssessorData, year, assessed, isAssessed(year, assessed));
        //製作評核問題欄位於divQuestionBodyRow
        CreateQuestionBodyRow(dtQuestionData, dtAssessorData, colCount);

        //讀取評核問題最終成績
        DataTable dtQuestionnaireScore = new DataTable();
        dtQuestionnaireScore = GetWeightedScore(dtAssessorData, year, assessed);
        //製作評核問題最終成績欄位於finalScoreRow
        CreateFinalScoreRow(dtQuestionnaireScore, colCount);
        #endregion

        #region 出勤
        //讀取出勤紀錄
        DataTable dtAttendance = new DataTable();
        dtAttendance = GetAttendanceData(year, assessed);

        double dayOffSum = 0;  //缺勤小記
        double dayOffValue = 0; //出勤分數

        //製作出勤動態div
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
                if (!string.IsNullOrWhiteSpace(dtAttendance.Rows[i]["SubTotal"].ToString()))
                {
                    dayOffValue += Convert.ToDouble(dtAttendance.Rows[i]["SubTotal"]);
                }
            }
        }

        //計算小計
        lblDayOffSum.Text = dayOffSum.ToString("N2");
        lblDayOffValueSum.Text = dayOffValue.ToString("N2");

        //計算及顯示出勤率
        double expectedWorkHour = 0;

        expectedWorkHour = GetWorkHourData(year, assessed);

        if (expectedWorkHour != 0)
        {
            lblExpectedAttendance.Text = expectedWorkHour.ToString("N2");
            lblActualAttendance.Text = (expectedWorkHour - dayOffSum).ToString("N2");
            lblAttendanceScore.Text = (100 + dayOffValue).ToString("N2");
            lblAttendanceFailure.Text = (((expectedWorkHour - dayOffSum) / expectedWorkHour)*100 - 100).ToString("N2") + "%";
            //lblOnJobPercent.Text = (Math.Floor(100 * 100 * (1 - (dayOffSum / onJobHour))) / 100).ToString();    //2018.07.23 改成小數第二位無條件捨去
        }
        else
        {
            lblExpectedAttendance.Text = "N/A";
            lblActualAttendance.Text = "N/A";
            lblAttendanceScore.Text = "N/A";
        }
        #endregion

        #region 獎懲
        //讀取獎懲紀錄
        DataTable dtRnPRecord = new DataTable();
        dtRnPRecord = GetRnPData(year, assessed);

        decimal rnpSum = 0;

        //動態增加獎懲DIV於RnPRecord
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
            divRnP2.InnerText = dtRnPRecord.Rows[i]["RnPScore"].ToString();
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
        #endregion

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


    protected void btnSaveComment_Click(object sender, EventArgs e)
    {
        string assessor = Session["erp_id"].ToString();

        string comments = ((TextBox)comment.FindControl("txtComment" + Session["erp_id"].ToString().Trim())).Text;

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "UPDATE HR360_ASSESSMENTSCORE_ASSESSED_B" +
                        " SET COMMENT=@COMMENT" +
                        " ,MODIFIEDDATE=GETDATE()" +
                        " ,MODIFIER=@ASSESSOR" +
                        " WHERE ASSESSED_ID=@ASSESSED" +
                        " AND ASSESSOR_ID=@ASSESSOR" +
                        " AND ASSESS_YEAR=@YEAR" +
                        " IF @@ROWCOUNT = 0" +
                        " INSERT INTO HR360_ASSESSMENTSCORE_ASSESSED_B" +
                        " VALUES" +
                        " (GETDATE(),@ASSESSOR,GETDATE(),@ASSESSOR,@ASSESSOR,@ASSESSED,@YEAR,@COMMENT)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSOR", assessor);
            cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            cmd.Parameters.AddWithValue("@COMMENT", comments);
            cmd.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// 檢查年分、評核者、被評核者的組合是否有被評核過
    /// </summary>
    /// <param name="year"></param>
    /// <param name="assessor"></param>
    /// <param name="assessed"></param>
    /// <returns></returns>
    private bool isAssessed(string year, string assessor, string assessed)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select ASSESSMENT_DONE" +
                " from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A" +
                " where [YEAR]=@year" +
                " and [ASSESSOR_ID]=@assessorId" +
                " and [ASSESSED_ID]=@assessedId" +
                " and [ACTIVE]=@active";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@assessorId", assessor);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            cmd.Parameters.AddWithValue("@active", "1");
            return cmd.ExecuteScalar() == null ? false : Convert.ToBoolean(cmd.ExecuteScalar().ToString());
        }
    }

    /// <summary>
    /// 簡易檢查被評核者在該年分中是否有被評核過
    /// </summary>
    /// <param name="year"></param>
    /// <param name="assessed"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 讀取被評者資料
    /// </summary>
    /// <param name="year"></param>
    /// <param name="assessed"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 讀取評核者清單
    /// </summary>
    /// <param name="year"></param>
    /// <param name="assessed"></param>
    /// <returns></returns>
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


    /// <summary>
    /// 製作評核表單頭資料
    /// </summary>
    /// <param name="dtAssessorData"></param>
    private void CreateQuestionTitleRow(DataTable dtAssessorData, int colCount)
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

        for (int i = 0; i < colCount; i++)
        {
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = "QuestionTitleRow_" + (5 + i).ToString();
            div.Attributes["class"] = "border col-xs-1";
            divQuestionTitleRow.Controls.Add(div);
            //add 評分 column for respective asesssor type
            TextBox txt = new TextBox();
            txt.CssClass = "form-control text-center autosize no-resize lowmargin";
            txt.TextMode = TextBoxMode.MultiLine;

            string name = "";
            if (i == 0) //自評column
            {
                name = "";
                foreach (DataRow row in dtAssessorData.Rows)
                {
                    if (row["ASSESS_TYPE"].ToString() == "1")
                    {
                        name = row["ASSESSOR_NAME"].ToString();
                    }
                }
                txt.Text = "自評" + Environment.NewLine + name;
            }
            else if (i == colCount - 1) //核決主管評column (last column)
            {
                name = "";
                foreach (DataRow row in dtAssessorData.Rows)
                {
                    if (row["ASSESS_TYPE"].ToString() == "3")
                    {
                        name = row["ASSESSOR_NAME"].ToString();
                    }
                }
                txt.Text = "複評" + Environment.NewLine + name;
            }
            else
            {
                name = "";
                foreach (DataRow row in dtAssessorData.Rows)
                {
                    if (row["ASSESS_TYPE"].ToString() == "2")
                    {
                        name += row["ASSESSOR_NAME"].ToString() + " ";
                    }
                }
                txt.Text = "初評" + Environment.NewLine + name;
            }
            div.Controls.Add(txt);
        }
    }


    private void CreateQuestionBodyRow(DataTable dtQuestionData, DataTable dtAssessorData, int colCount)
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
            for (int j = 0; j < colCount; j++)
            {
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = outerDiv.ID + "_" + (5 + j).ToString();
                div.Attributes["class"] = "border col-xs-1";
                outerDiv.Controls.Add(div);
                lbl = new Label();
                lbl.ID = "lblAssessmentScore" + (i + 1).ToString() + (j + 1).ToString();
                lbl.CssClass = "form-control text-center col" + (i + 1) + "_" + (5 + j).ToString();

                if (dtQuestionData.Columns.Count <= 5)  //col數量低於5，表示沒有讀取到任何已評分的資料，表示此人尚未被任何人評核過
                {
                    lbl.Text = "未評核";
                }
                else
                {
                    List<string> assessorList = new List<string>();

                    foreach (DataRow row in dtAssessorData.Rows)
                    {
                        assessorList.Add(row["ASSESSOR_ID"].ToString());
                    }

                    if (j == 0) //自評成績column (1st column)
                    {
                        lbl.Text = dtQuestionData.Rows[i][dtAssessorData.Rows[j]["ASSESSOR_ID"].ToString()].ToString();
                    }
                    else if (j == colCount - 1) //核決主管評成績column (last column)
                    {
                        lbl.Text = dtQuestionData.Rows[i][dtAssessorData.Rows[dtAssessorData.Rows.Count - 1]["ASSESSOR_ID"].ToString()].ToString();
                    }
                    else
                    {
                        //將除了自評(1st)及核決主管評(last)以外的成績加總計算平均
                        decimal score = 0;
                        for (int k = 7; k < dtQuestionData.Columns.Count - 1; k++)
                        {
                            decimal r = 0;
                            if (decimal.TryParse(dtQuestionData.Rows[i][k].ToString(), out r))
                            {
                                score += r;
                            }
                        }
                        score /= (dtQuestionData.Columns.Count - 8);    //包含問題col、自評成績col、核決主管評成績col在內，dtQuestionData總共固定col數量為8，其餘皆是主管評成績，須作平均計算

                        lbl.Text = score.ToString("0.0");
                    }
                }
                div.Controls.Add(lbl);
            }
        }
    }

    private void CreateFinalScoreRow(DataTable dtWeightedScore, int colCount)
    {
        //置入各評核者所打的最終分數
        HtmlGenericControl div = new HtmlGenericControl();
        div.TagName = "div";
        div.Attributes["class"] = "border col-xs-" + (12 - 1 * colCount).ToString();
        finalScoreRow.Controls.Add(div);
        Label lbl = new Label();
        lbl.CssClass = "form-control text-right text-color-green";
        lbl.Text = "小記";
        div.Controls.Add(lbl);


        for (int i = 0; i < colCount; i++)
        {
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = "finalScoreRow_" + i.ToString();
            div.Attributes["class"] = "border col-xs-1";
            finalScoreRow.Controls.Add(div);
            lbl = new Label();
            lbl.CssClass = "form-control text-center text-color-green";

            if (dtWeightedScore.Rows.Count > 0)
            {
                if (i == 0)
                {
                    lbl.Text = dtWeightedScore.Rows[0][i + 1].ToString();
                }
                else if (i == colCount - 1)
                {
                    lbl.Text = dtWeightedScore.Rows[0][dtWeightedScore.Columns.Count - 1].ToString();
                }
                else
                {

                    //將除了自評(1st)及核決主管評(last)以外的成績加總計算平均
                    decimal score = 0;
                    bool assessed = false;
                    for (int j = 2; j < dtWeightedScore.Columns.Count - 1; j++)
                    {
                        decimal r = 0;
                        if (decimal.TryParse(dtWeightedScore.Rows[0][j].ToString(), out r))
                        {
                            score += r;
                            assessed = true;
                        }
                    }
                    score /= (dtWeightedScore.Columns.Count - 3);    //包含assessed_id col、自評成績col、核決主管評成績col在內，dtWeightedScore總共固定col數量為3，其餘皆是主管評成績，須作平均計算


                    lbl.Text = assessed == false ? "未評核" : score.ToString("0.00");

                }
            }
            else
            {
                lbl.Text = "未評核";
            }

            div.Controls.Add(lbl);
        }
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
            if (Request.QueryString["ID"] == null)  //沒有querystring表示是由hr360進入，非日進後台
            {
                if (specialCommentator.Contains(Session["erp_id"].ToString()) && Session["erp_id"].ToString() == commentatorList[i])
                {
                    txt.ReadOnly = false;
                }
                else
                {
                    txt.ReadOnly = true;
                }
            }
            else
            {
                txt.ReadOnly = true;
            }
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Wrap = true;
            txt.Text = commentatorContent == null ? "" : commentatorContent.ToString();
            controlDiv.Controls.Add(txt);
            if (Request.QueryString["ID"] == null)
            {
                if (specialCommentator.Contains(Session["erp_id"].ToString()) && Session["erp_id"].ToString() == commentatorList[i])
                {
                    controlDiv = new HtmlGenericControl();
                    controlDiv.TagName = "div";
                    controlDiv.Attributes["style"] = "float: right";
                    bodyDiv.Controls.Add(controlDiv);
                    Button btn = new Button();
                    btn.ID = "btnSaveComment" + commentatorList[i];
                    btn.CssClass = "btn btn-success";
                    btn.Text = "儲存";
                    btn.Click += new EventHandler(btnSaveComment_Click);
                    btn.Visible = true;
                    controlDiv.Controls.Add(btn);
                }
            }
        }        
    }

    //讀取出勤資料
    private DataTable GetAttendanceData(string year, string assessed)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(";WITH CTE1"
+ " AS"
+ " ("
+ " SELECT PALTL.TL001 EMP_ID"
+ " ,PALMC.MC001 DAY_OFF_ID"
+ " ,PALMC.MC002 DAY_OFF_TYPE"
+ " ,COALESCE(SUM(PALTL.TL006+PALTL.TL007),0) DAY_OFF_AMOUNT"
+ " ,CASE PALMC.MC004"
+ " WHEN 1 THEN N'天'"
+ " WHEN 2 THEN N'時'"
+ " WHEN 3 THEN N'次'"
+ " WHEN 4 THEN N'分'"
+ " END AS DAY_OFF_UNIT"
+ " FROM PALMC"
+ " LEFT OUTER JOIN PALTL ON PALMC.MC001=PALTL.TL004 AND PALTL.TL002=@YEAR AND PALTL.TL001=@ID"
+ " GROUP BY PALTL.TL001,PALMC.MC001,PALMC.MC002,PALMC.MC004"
+ " UNION"
+ " SELECT"
+ " UNPIVOTTABLE.EMP_ID"
+ " ,CASE UNPIVOTTABLE.DAY_OFF_TYPE"
+ " WHEN N'遲到' THEN N'98'"
+ " WHEN N'早退' THEN N'99'"
+ " END AS DAY_OFF_ID"
+ " ,UNPIVOTTABLE.DAY_OFF_TYPE,UNPIVOTTABLE.DAY_OFF_AMOUNT,N'分' AS DAY_OFF_UNIT"
+ " FROM"
+ " ("
+ " SELECT PALTB.TB001 EMP_ID"
+ " ,CONVERT(DECIMAL(16,2),SUM(PALTB.TB007))/60.0 遲到"
+ " ,CONVERT(DECIMAL(16,2),SUM(PALTB.TB008))/60.0 早退"
+ " FROM PALTB"
+ " WHERE PALTB.TB001=@ID AND SUBSTRING(PALTB.TB002,1,4)=@YEAR"
+ " GROUP BY PALTB.TB001"
+ " ) AS GROUPTABLE"
+ " UNPIVOT"
+ " ("
+ " DAY_OFF_AMOUNT FOR DAY_OFF_TYPE IN (遲到,早退)"
+ " ) AS UNPIVOTTABLE"
+ " ),"
+ " DAYOFF_SUMMARY"
+ " AS"
+ " ("
+ " SELECT CASE CTE1.DAY_OFF_ID"
+ " WHEN 04 THEN 2"
+ " WHEN 05 THEN 2"
+ " WHEN 10 THEN 2"
+ " WHEN 98 THEN 2"
+ " WHEN 99 THEN 2"
+ " ELSE 1"
+ " END AS DAY_OFF_CATEGORY"
+ " , DAY_OFF_ID, DAY_OFF_TYPE"
+ " , CASE CTE1.DAY_OFF_UNIT"
+ " WHEN N'天' THEN CONVERT(DECIMAL(16,2),CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)*8.0)"
+ " WHEN N'分' THEN CONVERT(DECIMAL(16,2),CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)/60.0)"
+ " ELSE CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)"
+ " END AS DAY_OFF_AMOUNT"
+ " , N'時' AS DAY_OFF_UNIT"
+ " FROM CTE1"
+ " )"
+ " SELECT Summary.DAY_OFF_CATEGORY"
+ " ,Summary.DAY_OFF_ID"
+ " ,Summary.DAY_OFF_TYPE"
+ " ,Summary.DAY_OFF_AMOUNT"
+ " ,Case Summary.DAY_OFF_ID"
+ " When '02' THEN CONVERT(DECIMAL(16,1),(TK.TK005-TK.TK006))"
+ " When '03' Then CONVERT(DECIMAL(16,1),TK.TK003)-(SELECT SUM(TF008)"
+ " FROM PALTF"
+ " WHERE TF001=@ID"
+ " AND TF002 LIKE @YEAR+'%'"
+ " AND TF004='03')"
+ " Else 0"
+ " END AS DAY_OFF_TOTAL"
+ " ,Summary.DAY_OFF_UNIT"
+ " ,COALESCE(Value.[Value],null) 'Value'"
+ " ,N'分' 'ValueUnit'"
+ " ,COALESCE(Convert(decimal(16,2),Summary.DAY_OFF_AMOUNT*Value.[Value]),null) 'Subtotal'"
+ " FROM DAYOFF_SUMMARY Summary"
+ " LEFT JOIN NZ_ERP2.dbo.HR360_Attendance_CategoryValue Value on Summary.DAY_OFF_ID=Value.[UID] and Value.[Year]=@YEAR"
+ " LEFT JOIN PALTK TK ON TK.TK001=@ID AND TK.TK002=@YEAR"
+ " ORDER BY DAY_OFF_CATEGORY,DAY_OFF_ID", conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            cmd.Parameters.AddWithValue("@YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    //讀取工作時數資料
    private double GetWorkHourData(string year, string assessed)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT [EXPECTED_WORK_HOUR]"
                + " FROM EMPLOYEE_EXPECTED_WORKHOUR"
                + " WHERE [YEAR]=@YEAR"
                + " AND [EMP_ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", year);
            cmd.Parameters.AddWithValue("@ID", assessed);
            return cmd.ExecuteScalar() == null ? 0 : Convert.ToDouble(cmd.ExecuteScalar().ToString());
        }
    }

    //讀取獎懲紀錄
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

    //讀取題庫資料
    private DataTable GetQuestionData(DataTable dtAssessorData, string year, string assessed, bool isAssessed)
    {
        DataTable dt = new DataTable();
        string query = "";
        string coalesceColumns = "";
        string pivotCol = "";

        if (isAssessed)
        {
            for (int i = 0; i < dtAssessorData.Rows.Count; i++)
            {
                coalesceColumns += ",coalesce([" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "],'未評核') [" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "]";
                if (i == 0)
                {
                    pivotCol = "[" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "]";
                }
                else
                {
                    pivotCol += ",[" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "]";
                }
            }

            query = "select [INDEX]" +
                ",[QUESTION_CATEGORY_ID]" +
                ",[QUESTION_CATEGORY_NAME]" +
                ",[QUESTION_CATEGORY_WEIGHT]" +
                ",[QUESTION]" +
                ",[YEAR]" +
                coalesceColumns +
                " from" +
                " (" +
                " select score.[INDEX]" +
                " , score.[QUESTION_CATEGORY_ID]" +
                " , score.[QUESTION_CATEGORY_NAME]" +
                " , score.[QUESTION_CATEGORY_WEIGHT]" +
                " , score.[QUESTION]" +
                " , score.[SCORE]" +
                " , assignment.YEAR" +
                " , assignment.[ASSESSOR_ID]" +
                " from HR360_ASSESSMENTSCORE_SCORE_A score" +
                " right join HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A assignment on score.ASSESSED_ID = assignment.ASSESSED_ID and score.ASSESSOR_ID = assignment.ASSESSOR_ID and score.ASSESS_YEAR = assignment.YEAR" +
                " where assignment.ASSESSED_ID = @assessedId" +
                " and assignment.YEAR = @assessYear" +
                " ) as src" +
                " pivot" +
                " (" +
                " max(SCORE)" +
                " for ASSESSOR_ID in ( " + 
                pivotCol + 
                " )" +
                " ) pvt" +
                " where QUESTION is not null" +
                " order by[INDEX]";
        }
        else
        {
            //load completely new questions from 題庫            
            query = "SELECT DISTINCT DENSE_RANK() OVER(ORDER BY A.ID) AS [INDEX]" +
                " ,A.ID 'QUESTION_CATEGORY_ID'" +
                " ,A.NAME 'QUESTION_CATEGORY_NAME'" +
                " ,A.WEIGHT 'QUESTION_CATEGORY_WEIGHT'" +
                " ,B.QUESTION" +
                " FROM HR360_ASSESSMENTQUESTION_QUESTION_A B" +
                " LEFT JOIN HR360_ASSESSMENTQUESTION_CATEGORY_A A ON B.CATEGORY_ID = A.ID" +
                " LEFT JOIN HR360_ASSESSMENTQUESTION_ASSIGNMENT_A C ON B.ID = C.QUESTION_ID" +
                " WHERE" +
                " B.IN_USE = '1'" +
                " AND" +
                " (" +
                " B.USE_BY_ALL = '1'" +
                " OR" +
                " C.DEPT IN(SELECT CMSMV.MV004" +
                " FROM NZ.dbo.CMSMV" +
                " LEFT JOIN NZ.dbo.CMSMK ON CMSMV.MV001 = CMSMK.MK002" +
                " WHERE CMSMV.MV001 = @assessedId)" +
                " OR" +
                " C.EMP_ID IN(SELECT CMSMV.MV001" +
                " FROM NZ.dbo.CMSMV" +
                " LEFT JOIN NZ.dbo.CMSMK ON CMSMV.MV001 = CMSMK.MK002" +
                " WHERE CMSMV.MV001 = @assessedId)" +
                " )" +
                " ORDER BY A.ID";
        }

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            //cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@assessYear", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }


    private DataTable GetWeightedScore(DataTable dtAssessorData, string year, string assessed)
    {
        DataTable dt = new DataTable();
        string coalesceColumns = "";
        string pivotCol = "";

        for (int i = 0; i < dtAssessorData.Rows.Count; i++)
        {
            coalesceColumns += ",coalesce([" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "],'未評核') [" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "]";
            if (i == 0)
            {
                pivotCol = "[" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "]";
            }
            else
            {
                pivotCol += ",[" + dtAssessorData.Rows[i]["ASSESSOR_ID"].ToString() + "]";
            }
        }

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select ASSESSED_ID" +
                coalesceColumns +
                " from" +
                " (" +
                " select score.ASSESSED_ID" +
                " , coalesce(score.WEIGHTED_SCORE, '0.0') 'WEIGHTED_SCORE'" +
                " , score.ASSESSOR_ID" +
                " from HR360_ASSESSMENTSCORE_ASSESSED_A score" +
                " right join HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A assignment on score.ASSESS_YEAR = assignment.[YEAR] and score.ASSESSED_ID = assignment.ASSESSED_ID and score.ASSESSOR_ID = assignment.ASSESSOR_ID" +
                " where assignment.[YEAR] = @assessYear" +
                " and assignment.ASSESSED_ID = @assessedId" +
                " ) as src" +
                " pivot" +
                " (max(WEIGHTED_SCORE)" +
                " for ASSESSOR_ID in ( " + 
                pivotCol +
                " )" +
                " ) as pvt" +
                " where ASSESSED_ID is not null";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assessYear", year);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
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
        if(commentatorList.Count > 0)
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
}