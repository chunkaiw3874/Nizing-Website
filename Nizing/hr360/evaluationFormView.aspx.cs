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
    bool isAssesseda = false;
    List<string> assessorsWithOwnCommentSection = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        string assessed = "";
        string year = "";
        assessorsWithOwnCommentSection.Add("0006");
        assessorsWithOwnCommentSection.Add("0007");
        //assessorsWithOwnCommentSection.Add("0067");

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                year = Request.QueryString["year"];
                assessed = Request.QueryString["ID"];
            }
            else
            {
                //assessed = Session["view_id"].ToString().Trim();
                //year = Session["view_year"].ToString().Trim();
                //test 
                assessed = "0096";
                year = "2017";
                Session["erp_id"] = "0067";
            }
        }
        else
        {
            assessed = lblEmpID.Text.Trim();
            year = lblEvalYear.Text.Trim();
        }
        loadSurvey(assessed, year);
    }
    protected void loadSurvey(string assessed, string year)
    {
        if (Convert.ToInt32(year) < 2019)
        {
            string query = "";
            //讀取應評核此人的評核者清單
            DataTable dtAssessorList = new DataTable(); //評核者清單
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                query = "SELECT DISTINCT A.ASSESSOR_ID" +
                    ",C.MV002 'ASSESSOR_NAME'" +
                    ",B.NAME 'TYPE_NAME'" +
                    ",A.ASSESS_TYPE" +
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
                    + " ORDER BY A.ASSESS_TYPE";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                cmd.Parameters.AddWithValue("@YEAR", year);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAssessorList);
            }

            //計算評核者所需column數量
            if (Convert.ToInt32(year) < 2019)    //2019年前採用1自評+1主管評(+特評)、2019年後採用1自評+n主管評+1核決主管評
            {
                colCount = dtAssessorList.Rows.Count; //有幾個評核者-出現同樣數目的分數欄
            }
            else
            {
                colCount = Convert.ToInt32(dtAssessorList.Rows[0]["assessorSupervisorAmount"].ToString()) == 0 ? 2 : 3; //主管評呈現方式採用平均值，自評及核決主管評皆為固定一位，所以不是2就是3
            }

            //擷取評核者清單
            List<string> assessorList = new List<string>();
            foreach (DataRow row in dtAssessorList.Rows)
            {
                assessorList.Add(row["ASSESSOR_ID"].ToString());
            }



            //置入標題於QuestionTitleRow
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
            div.Attributes["class"] = "border col-xs-" + (8 - 2 * dtAssessorList.Rows.Count).ToString();
            divQuestionTitleRow.Controls.Add(div);
            lbl = new Label();
            lbl.CssClass = "form-control text-center";
            lbl.Text = "問題";
            div.Controls.Add(lbl);

            for (int i = 0; i < dtAssessorList.Rows.Count; i++)
            {
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = "QuestionTitleRow_" + (5 + i).ToString();
                div.Attributes["class"] = "border col-xs-2";
                divQuestionTitleRow.Controls.Add(div);
                //add 評分 column with respective 評分者名字
                TextBox txt = new TextBox();
                txt.CssClass = "form-control text-center autosize no-resize";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Text = dtAssessorList.Rows[i][1].ToString() + "評分" + Environment.NewLine
                        + "(" + dtAssessorList.Rows[i][2] + ")";
                div.Controls.Add(txt);
                //add comment row with respective 評分者名字
                if (dtAssessorList.Rows[i]["ASSESS_TYPE"].ToString() == "1") //自評評語
                {
                    txtSelfComment.Text = dtAssessorList.Rows[i]["OVERALL_COMMENT"].ToString() ?? "未評核";
                }
                else
                {
                    if (!assessorsWithOwnCommentSection.Contains(dtAssessorList.Rows[i]["ASSESSOR_ID"].ToString()))
                    {
                        //評語 title
                        HtmlGenericControl outerDiv = new HtmlGenericControl();
                        outerDiv.TagName = "div";
                        outerDiv.ID = "commentRowTitle" + (i + 1).ToString();
                        outerDiv.Attributes["class"] = "row";
                        comment.Controls.Add(outerDiv);
                        div = new HtmlGenericControl();
                        div.TagName = "div";
                        div.ID = outerDiv.ID + "_1";
                        div.Attributes["class"] = "col-xs-12 subtitle border";
                        div.InnerText = dtAssessorList.Rows[i]["ASSESSOR_NAME"].ToString() + "評語";
                        outerDiv.Controls.Add(div);
                        //評語 textbox
                        outerDiv = new HtmlGenericControl();
                        outerDiv.TagName = "div";
                        outerDiv.ID = "commentRowBody" + (i + 1).ToString();
                        outerDiv.Attributes["class"] = "row";
                        comment.Controls.Add(outerDiv);
                        div = new HtmlGenericControl();
                        div.TagName = "div";
                        div.ID = outerDiv.ID + "_1";
                        div.Attributes["class"] = "col-xs-12 border";
                        outerDiv.Controls.Add(div);
                        txt = new TextBox();
                        txt.ID = "txtCommentRow_Comment" + dtAssessorList.Rows[i]["ASSESSOR_ID"].ToString();
                        txt.CssClass = "form-control no-resize autosize";
                        txt.ReadOnly = true;
                        txt.Text = dtAssessorList.Rows[i]["OVERALL_COMMENT"].ToString() ?? "未評核";
                        txt.TextMode = TextBoxMode.MultiLine;
                        txt.Wrap = true;
                        div.Controls.Add(txt);
                    }
                }
            }

            //有獨立評語欄位者的欄位設定 (0006、0007、0067)
            if (Request.QueryString["ID"] == null || assessorsWithOwnCommentSection.Contains(Request.QueryString["ID"]))
            {
                if (Session["erp_id"].ToString() == "0007")
                {
                    txt0007Comment.ReadOnly = false;
                    btnSave0007Comment.Visible = true;
                    div0006_comment.Visible = true;
                    div0007_comment.Visible = true;
                    //div0067_comment.Visible = true;
                }
                else if (Session["erp_id"].ToString() == "0006")
                {
                    txt0006Comment.ReadOnly = false;
                    btnSave0006Comment.Visible = true;
                    div0006_comment.Visible = true;
                }
                //else if (Session["erp_id"].ToString() == "0067")
                //{
                //    txt0067Comment.ReadOnly = true;
                //    btnSave0067Comment.Visible = false;
                //    div0067_comment.Visible = true;
                //}
            }

            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();

                    //load Chrissy's Comment
                    query = "SELECT COMMENT"
                        + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
                        + " WHERE ASSESSED_ID=@ASSESSED"
                        + " AND ASSESSOR_ID=@ASSESSOR"
                        + " AND ASSESS_YEAR=@YEAR";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ASSESSOR", "0007");
                    cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    txt0007Comment.Text = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();

                    //load 吉田's comment
                    //query = "SELECT COMMENT"
                    //    + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
                    //    + " WHERE ASSESSED_ID=@ASSESSED"
                    //    + " AND ASSESSOR_ID=@ASSESSOR"
                    //    + " AND ASSESS_YEAR=@YEAR";
                    //cmd = new SqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@ASSESSOR", "0067");
                    //cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
                    //cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    //txt0067Comment.Text = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();

                    //load Kelven's Comment
                    query = "SELECT COMMENT"
                        + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
                        + " WHERE ASSESSED_ID=@ASSESSED"
                        + " AND ASSESSOR_ID=@ASSESSOR"
                        + " AND ASSESS_YEAR=@YEAR";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ASSESSOR", "0006");
                    cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    txt0006Comment.Text = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
                }
            }

            //將問題資料放入datatable內
            //isAssessed變數已儲存這個assessor/assessed/year組合是否已被評核過
            DataTable dtQuestionRecord = new DataTable(); //儲存問題以及(如有)每個問題的評分
            DataTable dtScoreOverallRecord = new DataTable(); //儲存評核者ID、總成績及評語
            if (isAssessed(year, assessed) == true)
            {
                //從HR360_ASSESSMENTSCORE類別DB搜尋問題            
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    query = "SELECT ASSESSOR_ID,COALESCE(RNP_SCORE,0.0) 'RNP_SCORE'"
                        + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                        + " WHERE ASSESS_YEAR=@ASSESS_YEAR"
                        + " AND ASSESSED_ID=@ASSESSED_ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                    cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtScoreOverallRecord);
                    query = "SELECT QUESTION_CATEGORY_ID,QUESTION_CATEGORY_NAME,QUESTION_CATEGORY_WEIGHT,QUESTION,[INDEX]"
                        + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                        + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                        + " AND ASSESS_YEAR=@ASSESS_YEAR"
                        + " AND ASSESSED_ID=@ASSESSED_ID"
                        + " ORDER BY [INDEX]";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", dtScoreOverallRecord.Rows[0][0].ToString().Trim());
                    cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                    cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                    da = new SqlDataAdapter(cmd);
                    dtQuestionRecord = new DataTable();
                    da.Fill(dtQuestionRecord);
                }
            }
            else //此人尚未被評核過，問題從HR360_ASSESSMENTQUESTION_QUESTION_A讀取
            {
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    query = "SELECT DISTINCT A.ID,A.NAME,A.WEIGHT,B.QUESTION"
                        + " FROM NZ_ERP2.dbo.HR360_ASSESSMENTQUESTION_QUESTION_A B"
                        + " LEFT JOIN NZ_ERP2.dbo.HR360_ASSESSMENTQUESTION_CATEGORY_A A ON B.CATEGORY_ID=A.ID"
                        + " LEFT JOIN NZ_ERP2.dbo.HR360_ASSESSMENTQUESTION_ASSIGNMENT_A C ON B.ID=C.QUESTION_ID"
                        + " WHERE"
                        + " B.IN_USE='1'"
                        + " AND"
                        + " ("
                        + " B.USE_BY_ALL='1'"
                        + " OR"
                        + " C.DEPT IN (SELECT CMSMV.MV004"
                        + " FROM CMSMV"
                        + " LEFT JOIN CMSMK ON CMSMV.MV001=CMSMK.MK002"
                        + " WHERE CMSMV.MV001=@ID)"
                        + " OR"
                        + " C.EMP_ID IN (SELECT CMSMV.MV001"
                        + " FROM CMSMV"
                        + " LEFT JOIN CMSMK ON CMSMV.MV001=CMSMK.MK002"
                        + " WHERE CMSMV.MV001=@ID)"
                        + " )"
                        + " ORDER BY ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", assessed);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtQuestionRecord = new DataTable();
                    da.Fill(dtQuestionRecord);
                }
            }
            //置入QuestionBodyRow資料
            //製作動態div
            for (int questionRowCount = 0; questionRowCount < dtQuestionRecord.Rows.Count; questionRowCount++)
            {
                HtmlGenericControl outerDiv = new HtmlGenericControl();
                outerDiv.TagName = "div";
                outerDiv.ID = "questionRow" + (questionRowCount + 1).ToString();
                outerDiv.Attributes["class"] = "row";
                divQuestionBodyRow.Controls.Add(outerDiv);
                //column 1 題號
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = outerDiv.ID + "_1";
                div.Attributes["class"] = "col-xs-1 border";
                outerDiv.Controls.Add(div);
                lbl = new Label();
                lbl.ID = "lblIndex" + (questionRowCount + 1).ToString();
                lbl.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_1";
                if (dtScoreOverallRecord.Rows.Count > 0)
                {
                    lbl.Text = dtQuestionRecord.Rows[questionRowCount][4].ToString();
                }
                else
                {
                    lbl.Text = (questionRowCount + 1).ToString();
                }
                div.Controls.Add(lbl);
                //column 2 分類
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = outerDiv.ID + "_2";
                div.Attributes["class"] = "col-xs-2 border";
                outerDiv.Controls.Add(div);
                lbl = new Label();
                lbl.ID = "lblAssessmentCategory" + (questionRowCount + 1).ToString();
                lbl.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_2";
                lbl.Text = dtQuestionRecord.Rows[questionRowCount][0].ToString() + "_" + dtQuestionRecord.Rows[questionRowCount][1].ToString();
                div.Controls.Add(lbl);
                //column 3 權重
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = outerDiv.ID + "_3";
                div.Attributes["class"] = "col-xs-1 border";
                outerDiv.Controls.Add(div);
                lbl = new Label();
                lbl.ID = "lblAssessmentCategoryWeight" + (questionRowCount + 1).ToString();
                lbl.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_3";
                lbl.Text = dtQuestionRecord.Rows[questionRowCount][2].ToString();
                div.Controls.Add(lbl);
                //column 4 問題
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = outerDiv.ID + "_4";
                div.Attributes["class"] = "border col-xs-" + (8 - 2 * dtAssessorList.Rows.Count).ToString();
                outerDiv.Controls.Add(div);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (questionRowCount + 1).ToString();
                txt.ReadOnly = true;
                txt.TextMode = TextBoxMode.MultiLine;
                txt.CssClass = "form-control no-resize autosize max-height col" + (questionRowCount + 1) + "_4";
                txt.Text = dtQuestionRecord.Rows[questionRowCount][3].ToString();
                div.Controls.Add(txt);
                //column 5 分數
                for (int i = 0; i < dtAssessorList.Rows.Count; i++)
                {
                    div = new HtmlGenericControl();
                    div.TagName = "div";
                    div.ID = outerDiv.ID + "_" + (5 + i).ToString();
                    div.Attributes["class"] = "border col-xs-2";
                    outerDiv.Controls.Add(div);
                    lbl = new Label();
                    lbl.ID = "lblAssessmentScore" + (questionRowCount + 1).ToString() + (i + 1).ToString();
                    lbl.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_" + (5 + i).ToString();
                    DataTable dtScoreRecord = new DataTable();
                    //讀取分數
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        query = "SELECT SCORE"
                            + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                            + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                            + " AND ASSESS_YEAR=@ASSESS_YEAR"
                            + " AND ASSESSED_ID=@ASSESSED_ID"
                            + " ORDER BY [INDEX]";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", dtAssessorList.Rows[i][0].ToString());
                        cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                        cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtScoreRecord);
                    }
                    if (dtScoreRecord.Rows.Count == 0)
                    {
                        lbl.Text = "未評核";
                    }
                    else
                    {
                        lbl.Text = dtScoreRecord.Rows[questionRowCount]["SCORE"].ToString();
                    }
                    div.Controls.Add(lbl);
                }
            }
            //置入各評核者所打的最終分數
            div = new HtmlGenericControl();
            div.TagName = "div";
            div.Attributes["class"] = "border col-xs-" + (12 - 2 * dtAssessorList.Rows.Count).ToString();
            finalScoreRow.Controls.Add(div);
            lbl = new Label();
            lbl.CssClass = "form-control text-right text-color-green";
            lbl.Text = "小記";
            div.Controls.Add(lbl);


            for (int i = 0; i < dtAssessorList.Rows.Count; i++)
            {
                div = new HtmlGenericControl();
                div.TagName = "div";
                div.ID = "finalScoreRow_" + (i + 1).ToString();
                div.Attributes["class"] = "border col-xs-2";
                finalScoreRow.Controls.Add(div);
                lbl = new Label();
                lbl.CssClass = "form-control text-center text-color-green";
                DataTable dtFinalScoreRecord = new DataTable();
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    query = "SELECT WEIGHTED_SCORE,OVERALL_COMMENT"
                        + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                        + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                        + " AND ASSESS_YEAR=@ASSESS_YEAR"
                        + " AND ASSESSED_ID=@ASSESSED_ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", dtAssessorList.Rows[i][0].ToString());
                    cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                    cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtFinalScoreRecord);
                }
                if (dtFinalScoreRecord.Rows.Count == 0)
                {
                    lbl.Text = "未評核";
                }
                else
                {
                    lbl.Text = dtFinalScoreRecord.Rows[0][0].ToString();
                }
                div.Controls.Add(lbl);
            }
        }
        else
        {

        }

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

        expectedWorkHour = GetWorkHourData(year, lblEmpID.Text);

        if (expectedWorkHour != 0)
        {
            lblExpectedAttendance.Text = expectedWorkHour.ToString("N2");
            lblActualAttendance.Text = (expectedWorkHour - dayOffSum).ToString("N2");
            lblAttendanceScore.Text = (100 + dayOffValue).ToString("N2");
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

        //動態增加獎懲DIV
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
    }
    protected void btnSaveComment_Click(object sender, EventArgs e)
    {
        string assessor = "";
        string comment = "";
        //if (((Button)sender).ID == "btnSave0067Comment")
        //{
        //    assessor = "0067";
        //    comment = txt0067Comment.Text.Trim();
        //}
        if (((Button)sender).ID == "btnSave0007Comment")
        {
            assessor = "0007";
            comment = txt0007Comment.Text.Trim();
        }
        else if (((Button)sender).ID == "btnSave0006Comment")
        {
            assessor = "0006";
            comment = txt0006Comment.Text.Trim();
        }

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT COMMENT"
                        + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
                        + " WHERE ASSESSED_ID=@ASSESSED"
                        + " AND ASSESSOR_ID=@ASSESSOR"
                        + " AND ASSESS_YEAR=@YEAR";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSOR", assessor);
            cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows) //此人的CHRISSY評語需要用UPDATE的方式更新
                {
                    dr.Close();
                    query = "UPDATE HR360_ASSESSMENTSCORE_ASSESSED_B"
                        + " SET COMMENT=@COMMENT,MODIFIEDDATE=GETDATE(),MODIFIER=@MODIFIER"
                        + " WHERE ASSESSED_ID=@ASSESSED"
                        + " AND ASSESSOR_ID=@ASSESSOR"
                        + " AND ASSESS_YEAR=@YEAR";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MODIFIER", Session["erp_id"].ToString().Trim());
                    cmd.Parameters.AddWithValue("@ASSESSOR", assessor);
                    cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    cmd.Parameters.AddWithValue("@COMMENT", comment);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    dr.Close();
                    query = "INSERT INTO HR360_ASSESSMENTSCORE_ASSESSED_B"
                        + " VALUES"
                        + " (GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@ASSESSOR,@ASSESSED,@YEAR,@COMMENT)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CREATOR", Session["erp_id"].ToString().Trim());
                    cmd.Parameters.AddWithValue("@MODIFIER", Session["erp_id"].ToString().Trim());
                    cmd.Parameters.AddWithValue("@ASSESSOR", assessor);
                    cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                    cmd.Parameters.AddWithValue("@COMMENT", comment);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    private bool isAssessed(string year, string assessor, string assessed)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select ASSESSMENT_DONE" +
                " from HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A" +
                " where [YEAR]=@year" +
                " and [ASSESSOR_ID]=@assessorId" +
                " and [ASSESSED_ID]=@assessedId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@assessorId", assessor);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            return cmd.ExecuteScalar() == null ? false : Convert.ToBoolean(cmd.ExecuteScalar().ToString());
        }
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
                " and [ASSESSMENT_DONE]=@assessmentDone";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@assessedId", assessed);
            cmd.Parameters.AddWithValue("@assessmentDone", '1');
            return cmd.ExecuteScalar() == null ? false : true;
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
+ " , CASE"
+ " WHEN CTE1.EMP_ID='0010'"
+ " THEN"
+ " CASE CTE1.DAY_OFF_UNIT"
+ " WHEN N'天' THEN CONVERT(DECIMAL(16,2),CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)*8.5)"
+ " WHEN N'分' THEN CONVERT(DECIMAL(16,2),CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)/60.0)"
+ " ELSE CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)"
+ " END"
+ " ELSE"
+ " CASE CTE1.DAY_OFF_UNIT"
+ " WHEN N'天' THEN CONVERT(DECIMAL(16,2),CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)*8.0)"
+ " WHEN N'分' THEN CONVERT(DECIMAL(16,2),CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)/60.0)"
+ " ELSE CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)"
+ " END"
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
+ " When '03' Then"
+ " CASE"
+ " WHEN @ID='0010' THEN CONVERT(DECIMAL(16,1),TK.TK003)*8.5-(SELECT SUM(TF008)"
+ " FROM PALTF"
+ " WHERE TF001=@ID"
+ " AND TF002 LIKE @YEAR+'%'"
+ " AND TF004='03')"
+ " ELSE CONVERT(DECIMAL(16,1),TK.TK003)*8.0-(SELECT SUM(TF008)"
+ " FROM PALTF"
+ " WHERE TF001=@ID"
+ " AND TF002 LIKE @YEAR+'%'"
+ " AND TF004='03')"
+ " End"
+ " Else 0"
+ " END AS DAY_OFF_TOTAL"
+ " ,Summary.DAY_OFF_UNIT"
+ " ,COALESCE(Value.[Value],null) 'Value'"
+ " ,N'分' 'ValueUnit'"
+ " ,COALESCE(Convert(decimal(4,2),Summary.DAY_OFF_AMOUNT*Value.[Value]),null) 'Subtotal'"
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

    //讀取評語
    private string LoadComment(string year, string assessor, string assessed, List<string>assessorsWithOwnCommentSection)
    {
        if (assessorsWithOwnCommentSection.Contains(assessor))
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT COMMENT"
                + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                + " AND ASSESSED_ID=@ASSESSED_ID"
                + " AND ASSESS_YEAR=@ASSESS_YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                return cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
            }
        }
        else
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT OVERALL_COMMENT"
                + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                + " AND ASSESSED_ID=@ASSESSED_ID"
                + " AND ASSESS_YEAR=@ASSESS_YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                return cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
            }
        }
    }

    //讀取題庫資料
    private DataTable GetQuestionData(string year, string assessor, string assessed, bool isAssessed)
    {
        DataTable dt = new DataTable();
        string query = "";
        if (isAssessed)
        {
            query = "SELECT [INDEX]" +
                    ",QUESTION_CATEGORY_ID" +
                    ",QUESTION_CATEGORY_NAME" +
                    ",QUESTION_CATEGORY_WEIGHT" +
                    ",QUESTION" +
                    ",SCORE 'SELF_SCORE'"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                    + " AND ASSESSED_ID=@ASSESSED_ID"
                    + " AND ASSESS_YEAR=@ASSESS_YEAR"
                    + " ORDER BY [INDEX]";            
        }
        else
        {
             //load completely new questions from 題庫            
            query = "SELECT DISTINCT DENSE_RANK() OVER(ORDER BY A.ID) AS [INDEX]" +
                " ,A.ID 'QUESTION_CATEGORY_ID'" +
                " ,A.NAME 'QUESTION_CATEGORY_NAME'" +
                " ,A.WEIGHT 'QUESTION_CATEGORY_WEIGHT'" +
                " ,B.QUESTION"
                + " FROM NZ_ERP2.dbo.HR360_ASSESSMENTQUESTION_QUESTION_A B"
                + " LEFT JOIN NZ_ERP2.dbo.HR360_ASSESSMENTQUESTION_CATEGORY_A A ON B.CATEGORY_ID=A.ID"
                + " LEFT JOIN NZ_ERP2.dbo.HR360_ASSESSMENTQUESTION_ASSIGNMENT_A C ON B.ID=C.QUESTION_ID"
                + " WHERE"
                + " B.IN_USE='1'"
                + " AND"
                + " ("
                + " B.USE_BY_ALL='1'"
                + " OR"
                + " C.DEPT IN (SELECT CMSMV.MV004"
                + " FROM CMSMV"
                + " LEFT JOIN CMSMK ON CMSMV.MV001=CMSMK.MK002"
                + " WHERE CMSMV.MV001=@ASSESSED_ID)"
                + " OR"
                + " C.EMP_ID IN (SELECT CMSMV.MV001"
                + " FROM CMSMV"
                + " LEFT JOIN CMSMK ON CMSMV.MV001=CMSMK.MK002"
                + " WHERE CMSMV.MV001=@ASSESSED_ID)"
                + " )"
                + " ORDER BY A.ID";            
        }

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private string GetIndividualQuestionScore(string year, string assessor, string assessed)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT SCORE"
                + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                + " AND ASSESS_YEAR=@ASSESS_YEAR"
                + " AND ASSESSED_ID=@ASSESSED_ID"
                + " ORDER BY [INDEX]";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return cmd.ExecuteScalar() == null ? "未評核" : cmd.ExecuteScalar().ToString();
        }
    }

    private string GetWeightedQuestionScore(string year, string assessor, string assessed)
    {
        return "";
    }
}