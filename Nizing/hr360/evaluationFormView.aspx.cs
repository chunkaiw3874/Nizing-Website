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
    bool isAssessed = false;
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
                //test 
                //assessed = "0080";
                //year = "2016";
                //Session["erp_id"] = "0080";
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
        string query = "";
        //被評核員工基本資料
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            query = "SELECT CMSMV.MV001,CMSMV.MV002"
                + " FROM CMSMV"
                + " WHERE CMSMV.MV001=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblEmpID.Text = assessed;
                lblEmpName.Text = dr[1].ToString().Trim();
            }
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "SELECT TOP 1 ASSESSED_RANK,ASSESSED_WORKYEAR"
                + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                + " WHERE ASSESSED_ID=@ASSESSED_ID"
                + " AND ASSESS_YEAR=@YEAR";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@YEAR", year);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblEmpJob.Text = dr[0].ToString().Trim();
                        lblEmpWorkYear.Text = dr[1].ToString().Trim();
                        isAssessed = true;
                    }
                }
                else
                {
                    lblEmpJob.Text = "今年尚未評核";
                    lblEmpWorkYear.Text = "今年尚未評核";
                    isAssessed = false;
                }
            }
        }
        //評核年度
        lblEvalYear.Text = year;
        //讀取應評核此人的評核者清單
        DataTable dtAssessorList = new DataTable(); //評核者清單
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            query = "SELECT DISTINCT A.ASSESSOR_ID,C.MV002,B.NAME,A.ASSESS_TYPE,D.OVERALL_COMMENT"
                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A B ON A.ASSESS_TYPE=B.ID"
                + " LEFT JOIN NZ.dbo.CMSMV C ON A.ASSESSOR_ID=C.MV001"
                + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A D ON A.ASSESSOR_ID=D.ASSESSOR_ID AND A.ASSESSED_ID=D.ASSESSED_ID AND A.[YEAR]=D.ASSESS_YEAR"
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
        colCount = dtAssessorList.Rows.Count; //有幾個評核者-出現同樣數目的分數欄
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
            if (dtAssessorList.Rows[i][3].ToString() == "1") //自評評語
            {
                txtSelfComment.Text = dtAssessorList.Rows[i][4].ToString() ?? "未評核";
            }
            else
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
                div.InnerText = dtAssessorList.Rows[i][1].ToString() + "評語";
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
                txt.ID = "txtCommentRow_Comment" + dtAssessorList.Rows[i][0].ToString();
                txt.CssClass = "form-control no-resize autosize";
                txt.ReadOnly = true;
                txt.Text = dtAssessorList.Rows[i][4].ToString() ?? "未評核";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                div.Controls.Add(txt);
            }
        }
        //Chrissy評語欄位
        if (Request.QueryString["ID"] == null)
        {
            if (Session["erp_id"].ToString() == "0007")
            {
                txt0007Comment.ReadOnly = false;
                btnSave0007Comment.Visible = true;
                div0006_comment.Visible = true;
                div0007_comment.Visible = true;                
            }
            else if (Session["erp_id"].ToString() == "0006")
            {
                txt0006Comment.ReadOnly = false;
                btnSave0006Comment.Visible = true;
            }
            else if (Session["erp_id"].ToString() == "0067")
            {
                txt0067Comment.ReadOnly = true;
                btnSave0067Comment.Visible = false;
            }
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
                if (cmd.ExecuteScalar() != null)
                {
                    txt0007Comment.Text = cmd.ExecuteScalar().ToString();
                }
                //load 吉田's comment
                query = "SELECT COMMENT"
                    + " FROM HR360_ASSESSMENTSCORE_ASSESSED_B"
                    + " WHERE ASSESSED_ID=@ASSESSED"
                    + " AND ASSESSOR_ID=@ASSESSOR"
                    + " AND ASSESS_YEAR=@YEAR";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR", "0067");
                cmd.Parameters.AddWithValue("@ASSESSED", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                if (cmd.ExecuteScalar() != null)
                {
                    txt0067Comment.Text = cmd.ExecuteScalar().ToString();
                }
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
                if (cmd.ExecuteScalar() != null)
                {
                    txt0006Comment.Text = cmd.ExecuteScalar().ToString();
                }
            }
        }
        //將問題資料放入datatable內
        //isAssessed變數已儲存這個assessor/assessed/year組合是否已被評核過
        DataTable dtQuestionRecord = new DataTable(); //儲存問題以及(如有)每個問題的評分
        DataTable dtScoreOverallRecord = new DataTable(); //儲存評核者ID、總成績及評語
        if (isAssessed == true)
        {
            //從HR360_ASSESSMENTSCORE類別DB搜尋問題            
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                query = "SELECT ASSESSOR_ID"
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
                    lbl.Text = dtScoreRecord.Rows[questionRowCount][0].ToString();
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
        //讀取出勤資料
        DataTable dtAttendance = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("WITH CTE1"
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
                                        + " ,CONVERT(DECIMAL(16,2),SUM(PALTB.TB007)) 遲到"
                                        + " ,CONVERT(DECIMAL(16,2),SUM(PALTB.TB008)) 早退"
                                        + " FROM PALTB"
                                        + " WHERE PALTB.TB001=@ID AND SUBSTRING(PALTB.TB002,1,4)=@YEAR"
                                        + " GROUP BY PALTB.TB001"
                                        + " ) AS GROUPTABLE"
                                        + " UNPIVOT"
                                        + " ("
                                        + " DAY_OFF_AMOUNT FOR DAY_OFF_TYPE IN (遲到,早退)"
                                        + " ) AS UNPIVOTTABLE"
                                        + " )"
                                        + " SELECT"
                                        + " CASE CTE1.DAY_OFF_ID"
                                        + " WHEN 04 THEN 2"
                                        + " WHEN 05 THEN 2"
                                        + " WHEN 10 THEN 2"
                                        + " WHEN 98 THEN 2"
                                        + " WHEN 99 THEN 2"
                                        + " ELSE 1"
                                        + " END AS DAY_OFF_CATEGORY"
                                        + " , DAY_OFF_ID, DAY_OFF_TYPE"
                                        + " , CASE"
                                        + " 	WHEN CTE1.EMP_ID=0010"
                                        + " 	THEN"
                                        + " 		CASE CTE1.DAY_OFF_UNIT"
                                        + " 		WHEN N'天' THEN CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT*8.5)"
                                        + " 		WHEN N'分' THEN CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT/60.0)"
                                        + " 		ELSE CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)"
                                        + " 		END"
                                        + " 	ELSE"
                                        + " 		CASE CTE1.DAY_OFF_UNIT"
                                        + " 		WHEN N'天' THEN CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT*8.0)"
                                        + " 		WHEN N'分' THEN CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT/60.0)"
                                        + " 		ELSE CONVERT(DECIMAL(16,2),CTE1.DAY_OFF_AMOUNT)"
                                        + " 		END"
                                        + " 	END AS DAY_OFF_AMOUNT"
                                        + " , N'時' AS DAY_OFF_UNIT"
                                        + " FROM CTE1"
                                        + " ORDER BY DAY_OFF_CATEGORY,DAY_OFF_ID", conn);
            cmd.Parameters.AddWithValue("@ID", lblEmpID.Text.Trim());
            cmd.Parameters.AddWithValue("@YEAR", year);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dtAttendance.Load(dr);
            }
        }
        double dayOffSum = 0;  //缺勤小記
        for (int i = 0; i < dtAttendance.Rows.Count; i++)
        {
            Label lblDayOffName = (Label)(Master.FindControl("ContentPlaceHolder1").FindControl("lblDayOffName" + (i + 1).ToString()));
            if (lblDayOffName != null)
            {
                lblDayOffName.Text = dtAttendance.Rows[i]["DAY_OFF_TYPE"].ToString();
            }
            Label lblDayOff = (Label)(Master.FindControl("ContentPlaceHolder1").FindControl("lblDayOff" + (i + 1).ToString()));
            if (lblDayOff != null)
            {
                lblDayOff.Text = dtAttendance.Rows[i]["DAY_OFF_AMOUNT"].ToString();
                if (dtAttendance.Rows[i]["DAY_OFF_CATEGORY"].ToString() == "2")
                {
                    dayOffSum += Convert.ToDouble(dtAttendance.Rows[i][3]);
                }
            }
            Label lblDayOffUnit = (Label)(Master.FindControl("ContentPlaceHolder1").FindControl("lblDayOffUnit" + (i + 1).ToString()));
            if (lblDayOffUnit != null)
            {
                lblDayOffUnit.Text = dtAttendance.Rows[i]["DAY_OFF_UNIT"].ToString();
            }
        }
        //計算小計
        lblDayOffSum.Text = dayOffSum.ToString();
        //計算出勤率
        //每年須手動修改需出勤時數 edit annually
        double onJobHour = 0;
        object checkForNull;
        //if (lblEmpID.Text.Trim() == "0010") //小倩
        //{
        //    onJobHour = 2099.5;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0001" || lblEmpID.Text.Trim() == "0002" || lblEmpID.Text.Trim() == "0004" ||
        //    lblEmpID.Text.Trim() == "0008" || lblEmpID.Text.Trim() == "0009" || lblEmpID.Text.Trim() == "0011" ||
        //    lblEmpID.Text.Trim() == "0012" || lblEmpID.Text.Trim() == "0013" || lblEmpID.Text.Trim() == "0034" ||
        //    lblEmpID.Text.Trim() == "0039" || lblEmpID.Text.Trim() == "0049" || lblEmpID.Text.Trim() == "0057" ||
        //    lblEmpID.Text.Trim() == "0062" || lblEmpID.Text.Trim() == "0066" || lblEmpID.Text.Trim() == "0067" ||
        //    lblEmpID.Text.Trim() == "0079" || lblEmpID.Text.Trim() == "0093" || lblEmpID.Text.Trim() == "0094" ||
        //    lblEmpID.Text.Trim() == "0096") //廠內人員
        //{
        //    onJobHour = 1984;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0005" || lblEmpID.Text.Trim() == "0015" || lblEmpID.Text.Trim() == "0031" ||
        //    lblEmpID.Text.Trim() == "0047" || lblEmpID.Text.Trim() == "0063" || lblEmpID.Text.Trim() == "0074" ||
        //    lblEmpID.Text.Trim() == "0080" || lblEmpID.Text.Trim() == "0085" || lblEmpID.Text.Trim() == "0023" ||
        //    lblEmpID.Text.Trim() == "0124" || lblEmpID.Text.Trim() == "0125") //辦公室人員
        //{
        //    onJobHour = 1976;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0103")    //以下皆為未滿一年人員
        //{
        //    onJobHour = 1616;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0107" || lblEmpID.Text.Trim() == "0108")
        //{
        //    onJobHour = 1472;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0105")
        //{
        //    onJobHour = 1352;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0109")
        //{
        //    onJobHour = 1120;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0112" || lblEmpID.Text.Trim() == "0113")
        //{
        //    onJobHour = 728;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else if (lblEmpID.Text.Trim() == "0114")
        //{
        //    onJobHour = 576;
        //    lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        //}
        //else
        //{
        //    lblOnJobPercent.Text = "N/A";
        //}
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
            onJobHour = Convert.ToDouble(checkForNull);
            lblOnJobPercent.Text = (Math.Floor(100 * 100 * (1 - (dayOffSum / onJobHour))) / 100).ToString();    //2018.07.23 改成小數第二位無條件捨去
            //lblOnJobPercent.Text = (Math.Round(100 * (1 - (dayOffSum / onJobHour)), 2, MidpointRounding.AwayFromZero)).ToString();
        }
        else
        {
            lblOnJobPercent.Text = "N/A";
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            if (lblEmpID.Text == "0010")
            {
                query = "SELECT CONVERT(DECIMAL(16,1),((PALTK.TK003-PALTK.TK004)*8.5)+(PALTK.TK005-PALTK.TK006))"
                + " FROM PALTK"
                + " WHERE PALTK.TK001=@ID"
                + " AND PALTK.TK002=@YEAR";
            }
            else
            {
                query = "SELECT CONVERT(DECIMAL(16,1),((PALTK.TK003-PALTK.TK004)*8.0)+(PALTK.TK005-PALTK.TK006))"
                + " FROM PALTK"
                + " WHERE PALTK.TK001=@ID"
                + " AND PALTK.TK002=@YEAR";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", lblEmpID.Text);
            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            lblDayOffUnused.Text = cmd.ExecuteScalar().ToString();

            if (Request.QueryString["ID"] == null)
            {
                if (Session["erp_id"].ToString() != "0007" && Session["erp_id"].ToString() != "0006")
                {
                    if (string.IsNullOrWhiteSpace(txt0006Comment.Text))
                    {
                        div0006_comment.Visible = false;
                    }
                    else
                    {
                        div0006_comment.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(txt0007Comment.Text))
                    {
                        div0007_comment.Visible = false;
                    }
                    else
                    {
                        div0007_comment.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(txt0067Comment.Text))
                    {
                        div0067_comment.Visible = false;
                    }
                    else
                    {
                        div0067_comment.Visible = true;
                    }
                }
                else
                {

                    div0006_comment.Visible = true;
                    div0007_comment.Visible = true;
                    if (string.IsNullOrWhiteSpace(txt0067Comment.Text))
                    {
                        div0067_comment.Visible = false;
                    }
                    else
                    {
                        div0067_comment.Visible = true;
                    }
                }
            }
        }
    }
    protected void btnSaveComment_Click(object sender, EventArgs e)
    {
        string assessor = "";
        string comment = "";
        if (((Button)sender).ID == "btnSave0067Comment")
        {
            assessor = "0067";
            comment = txt0067Comment.Text.Trim();
        }
        else if (((Button)sender).ID == "btnSave0007Comment")
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
}