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

public partial class hr360_evaluationForm : System.Web.UI.Page
{
    //每年須手動修改的地方有"edit annually"的字樣，請查詢!!!!!

    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    //Setup basic info for the assessment 
    string year = "";
    int rowCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if session has expired
        if (!((masterPage_HR360_Master)this.Master).CheckAuthentication())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        }
        else        
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT EVAL_YEAR"
                            + " FROM HR360_ASSESSMENTTIME";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            year = dr.GetString(0);
                        }
                    }
                }
            }

            string assessor = Session["erp_id"].ToString().Trim();
            string assessed = "";
            if (!IsPostBack)
            {
                assessed = Session["eval_id"].ToString().Trim();
            }
            else
            {
                assessed = lblEmpID.Text.Trim();
            }

            //test value
            //string assessor = "0001";
            //string assessed = "0001";


            DataTable dtEval = new DataTable();
            //string evaluated = isEvaluated(assessor, assessed);
            dtEval = isEvaluated(assessor, assessed);

            if (dtEval.Rows.Count <= 0)
            {
                lblErrorMessage.Text = "沒有此組合";
            }
            else
            {
                if (dtEval.Rows[0]["ASSESSMENT_DONE"].ToString() == "0")
                {
                    loadCleanForm(assessor, assessed, dtEval.Rows[0]["ASSESS_TYPE"].ToString());
                }
                else
                {
                    loadAssessedForm(assessor, assessed, dtEval.Rows[0]["ASSESS_TYPE"].ToString());
                }
            }
            //if (evaluated == "0")
            //{
            //    loadCleanForm(assessor, assessed);
            //}
            //else if (evaluated == "1")
            //{
            //    loadAssessedForm(assessor, assessed);
            //}
            //else
            //{
            //    lblErrorMessage.Text = evaluated;
            //}
            HtmlGenericControl headerDiv = new HtmlGenericControl();
            headerDiv.TagName = "div";
            headerDiv.Attributes["class"] = "col-xs-1 border";
            Question_Title.Controls.Add(headerDiv);
            HtmlGenericControl headerText = new HtmlGenericControl();
            headerText.TagName = "span";
            headerText.Attributes["class"] = "form-control text-center";
            headerText.InnerText = "#";
            headerDiv.Controls.Add(headerText);
            headerDiv = new HtmlGenericControl();
            headerDiv.TagName = "div";
            headerDiv.Attributes["class"] = "col-xs-2 border";
            Question_Title.Controls.Add(headerDiv);
            headerText = new HtmlGenericControl();
            headerText.TagName = "span";
            headerText.Attributes["class"] = "form-control text-center";
            headerText.InnerText = "分類";
            headerDiv.Controls.Add(headerText);
            headerDiv = new HtmlGenericControl();
            headerDiv.TagName = "div";
            headerDiv.Attributes["class"] = "col-xs-1 border";
            Question_Title.Controls.Add(headerDiv);
            headerText = new HtmlGenericControl();
            headerText.TagName = "span";
            headerText.Attributes["class"] = "form-control text-center";
            headerText.InnerText = "權重";
            headerDiv.Controls.Add(headerText);
            if (dtEval.Rows[0]["ASSESS_TYPE"].ToString() == "1")
            {
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-6 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "問題";
                headerDiv.Controls.Add(headerText);
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "自評分數";
                headerDiv.Controls.Add(headerText);
            }
            else if (dtEval.Rows[0]["ASSESS_TYPE"].ToString() == "2")
            {
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-4 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "問題";
                headerDiv.Controls.Add(headerText);
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "自評分數";
                headerDiv.Controls.Add(headerText);
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "主管評分數";
                headerDiv.Controls.Add(headerText);
            }
            else if (dtEval.Rows[0]["ASSESS_TYPE"].ToString() == "9")
            {
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "問題";
                headerDiv.Controls.Add(headerText);
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "自評分數";
                headerDiv.Controls.Add(headerText);
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "主管評分數";
                headerDiv.Controls.Add(headerText);
                headerDiv = new HtmlGenericControl();
                headerDiv.TagName = "div";
                headerDiv.Attributes["class"] = "col-xs-2 border";
                Question_Title.Controls.Add(headerDiv);
                headerText = new HtmlGenericControl();
                headerText.TagName = "span";
                headerText.Attributes["class"] = "form-control text-center";
                headerText.InnerText = "特評分數";
                headerDiv.Controls.Add(headerText);
            }
        }
    }

    /// <summary>
    /// 查詢這個assessor/assessed組合是否有評核過，回傳1表示有，0表示沒有
    /// </summary>
    /// <returns></returns>
    protected DataTable isEvaluated(string assessor, string assessed)
    {
        DataTable dt = new DataTable();
        //string evaluated = "0";
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT ASSESS_TYPE,ASSESSMENT_DONE"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                        + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                        + " AND ASSESSED_ID=@ASSESSED_ID"
                        + " AND YEAR=@YEAR";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //using (SqlDataReader dr = cmd.ExecuteReader())
            //{
            //    if (!dr.HasRows)
            //    {
            //        dr.Close();
            //        return "沒有此組合";
            //    }
            //    else
            //    {
            //        dr.Close();
            //        evaluated = cmd.ExecuteScalar().ToString();
            //        return evaluated;
            //    }
            //}
        }
        return dt;
    }
    /// <summary>
    /// 讀取乾淨的表單
    /// </summary>
    protected void loadCleanForm(string assessor, string assessed, string assess_type)
    {        
        //被評核員工基本資料
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT CMSMV.MV001,CMSMV.MV002,CMSMJ.MJ003,CMSMV.MV031"
                                            + " FROM CMSMV"
                                            + " LEFT JOIN CMSMJ ON CMSMV.MV006=CMSMJ.MJ001"
                                            + " WHERE CMSMV.MV001=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblEmpID.Text = dr[0].ToString().Trim();
                lblEmpName.Text = dr[1].ToString().Trim();
                lblEmpJob.Text = dr[2].ToString().Trim();
                lblEmpWorkYear.Text = dr[3].ToString().Trim();
            }
        }
        //評核日期
        lblEvalYear.Text = year;
        lblEvalDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT B.NAME"
                                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                        + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A B ON A.ASSESS_TYPE=B.ID"
                                        + " WHERE ASSESSED_ID = @ASSESSED_ID AND ASSESSOR_ID=@ASSESSOR_ID AND YEAR=@YEAR", conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text.Trim());
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            lblEvalType.Text = cmd.ExecuteScalar().ToString();
        }
        //讀取評量問題
        DataTable dtAssessmentQuestion = new DataTable();
        if (assess_type == "1")
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT A.ID 'QUESTION_CATEGORY_ID',A.NAME 'QUESTION_CATEGORY_NAME',A.WEIGHT 'QUESTION_CATEGORY_WEIGHT',B.QUESTION"
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
                                            + " ORDER BY A.ID", conn);
                cmd.Parameters.AddWithValue("@ID", lblEmpID.Text.Trim());
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dtAssessmentQuestion.Load(dr);
                }
            }
        }
        else if(assess_type == "2")
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT [INDEX],QUESTION_CATEGORY_ID,QUESTION_CATEGORY_NAME,QUESTION_CATEGORY_WEIGHT,QUESTION,SCORE 'SELF_SCORE'"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                    + " WHERE ASSESSOR_ID=@ASSESSED_ID"
                    + " AND ASSESSED_ID=@ASSESSED_ID"
                    + " AND ASSESS_YEAR=@ASSESS_YEAR"
                    + " ORDER BY [INDEX]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                dtAssessmentQuestion = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAssessmentQuestion);
            }
        }
        else if (assess_type == "9")
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = ";WITH SUPER_TABLE"
                            + " AS"
                            + " ("
                            + " SELECT [INDEX],SCORE"
                            + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                            + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                            + " AND ASSESSED_ID=@ASSESSED_ID"
                            + " AND ASSESS_YEAR=@ASSESS_YEAR"
                            + " )"
                            + " SELECT [SELF].[INDEX]"
                            + " ,[SELF].QUESTION_CATEGORY_ID"
                            + " ,[SELF].QUESTION_CATEGORY_NAME"
                            + " ,[SELF].QUESTION_CATEGORY_WEIGHT"
                            + " ,[SELF].QUESTION"
                            + " ,[SELF].SCORE 'SELF_SCORE'"
                            + " ,SUPER.SCORE 'SUPER_SCORE'"
                            + " FROM HR360_ASSESSMENTSCORE_SCORE_A [SELF]"
                            + " LEFT JOIN SUPER_TABLE SUPER ON SUPER.[INDEX]=[SELF].[INDEX]"
                            + " WHERE [SELF].ASSESSOR_ID=@ASSESSED_ID"
                            + " AND [SELF].ASSESSED_ID=@ASSESSED_ID"
                            + " AND [SELF].ASSESS_YEAR=@ASSESS_YEAR"
                            + " ORDER BY [INDEX]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                dtAssessmentQuestion = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAssessmentQuestion);
            }
        }
        
        for (int questionRowCount = 0; questionRowCount < dtAssessmentQuestion.Rows.Count; questionRowCount++)
        {
            if (assess_type == "1")
            {                
                //row
                HtmlGenericControl outerDiv = new HtmlGenericControl();
                outerDiv.TagName = "div";
                outerDiv.ID = "questionRow" + (questionRowCount + 1).ToString();
                outerDiv.Attributes["class"] = "row";
                Load_Question.Controls.Add(outerDiv);
                //column 1 題號
                HtmlGenericControl innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_1";
                innerDiv.Attributes["class"] = "col-xs-1 border text-center";
                outerDiv.Controls.Add(innerDiv);
                Label label = new Label();
                label.ID = "lblIndex" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_1";
                label.Text = (questionRowCount + 1).ToString();
                innerDiv.Controls.Add(label);
                //column 2 分類
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_2";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblAssessmentCategory" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_2";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_ID"].ToString() + '_' + dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_NAME"].ToString();
                innerDiv.Controls.Add(label);
                //column 3 權重
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_3";
                innerDiv.Attributes["class"] = "col-xs-1 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblAssessmentCategoryWeight" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_3";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_WEIGHT"].ToString();
                innerDiv.Controls.Add(label);
                //column 4 問題
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_4";
                innerDiv.Attributes["class"] = "col-xs-6 border";
                outerDiv.Controls.Add(innerDiv);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (questionRowCount + 1).ToString();
                txt.CssClass = "form-control no-resize autosize col" + (questionRowCount + 1) + "_4";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                txt.ReadOnly = true;
                txt.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION"].ToString();
                innerDiv.Controls.Add(txt);
                //column 5 分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_5";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                txt = new TextBox();
                txt.ID = "txtAssessmentScore" + (questionRowCount + 1).ToString();
                txt.CssClass = "form-control numbers-only add-number col" + (questionRowCount + 1) + "_5";
                txt.Attributes["placeholder"] = "請打分數";
                innerDiv.Controls.Add(txt);
            }
            else if (assess_type == "2")
            {
                //row
                HtmlGenericControl outerDiv = new HtmlGenericControl();
                outerDiv.TagName = "div";
                outerDiv.ID = "questionRow" + (questionRowCount + 1).ToString();
                outerDiv.Attributes["class"] = "row";
                Load_Question.Controls.Add(outerDiv);
                //column 1 題號
                HtmlGenericControl innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_1";
                innerDiv.Attributes["class"] = "col-xs-1 border text-center";
                outerDiv.Controls.Add(innerDiv);
                Label label = new Label();
                label.ID = "lblIndex" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_1";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["INDEX"].ToString();
                innerDiv.Controls.Add(label);
                //column 2 分類
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_2";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblAssessmentCategory" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_2";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_ID"].ToString() + '_' + dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_NAME"].ToString();
                innerDiv.Controls.Add(label);
                //column 3 權重
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_3";
                innerDiv.Attributes["class"] = "col-xs-1 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblAssessmentCategoryWeight" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_3";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_WEIGHT"].ToString();
                innerDiv.Controls.Add(label);
                //column 4 問題
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_4";
                innerDiv.Attributes["class"] = "col-xs-4 border";
                outerDiv.Controls.Add(innerDiv);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (questionRowCount + 1).ToString();
                txt.CssClass = "form-control no-resize autosize col" + (questionRowCount + 1) + "_4";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                txt.ReadOnly = true;
                txt.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION"].ToString();
                innerDiv.Controls.Add(txt);
                //column 6 自評分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_6";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblSelfAssessmentScore" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_6";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["SELF_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(label);
                //column 5 分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_5";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                txt = new TextBox();
                txt.ID = "txtAssessmentScore" + (questionRowCount + 1).ToString();
                txt.CssClass = "form-control numbers-only add-number col" + (questionRowCount + 1) + "_5";
                txt.Attributes["placeholder"] = "請打分數";
                innerDiv.Controls.Add(txt);
            }
            else if (assess_type == "9")
            {
                //row
                HtmlGenericControl outerDiv = new HtmlGenericControl();
                outerDiv.TagName = "div";
                outerDiv.ID = "questionRow" + (questionRowCount + 1).ToString();
                outerDiv.Attributes["class"] = "row";
                Load_Question.Controls.Add(outerDiv);
                //column 1 題號
                HtmlGenericControl innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_1";
                innerDiv.Attributes["class"] = "col-xs-1 border text-center";
                outerDiv.Controls.Add(innerDiv);
                Label label = new Label();
                label.ID = "lblIndex" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_1";
                label.Text = (questionRowCount + 1).ToString();
                innerDiv.Controls.Add(label);
                //column 2 分類
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_2";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblAssessmentCategory" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_2";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_ID"].ToString() + '_' + dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_NAME"].ToString();
                innerDiv.Controls.Add(label);
                //column 3 權重
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_3";
                innerDiv.Attributes["class"] = "col-xs-1 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblAssessmentCategoryWeight" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control col" + (questionRowCount + 1) + "_3";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION_CATEGORY_WEIGHT"].ToString();
                innerDiv.Controls.Add(label);
                //column 4 問題
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_4";
                innerDiv.Attributes["class"] = "col-xs-2 border";
                outerDiv.Controls.Add(innerDiv);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (questionRowCount + 1).ToString();
                txt.CssClass = "form-control no-resize autosize col" + (questionRowCount + 1) + "_4";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                txt.ReadOnly = true;
                txt.Text = dtAssessmentQuestion.Rows[questionRowCount]["QUESTION"].ToString();
                innerDiv.Controls.Add(txt);
                //column 6 自評分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_6";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblSelfAssessmentScore" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_6";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["SELF_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(label);
                //column 7 主管評分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_7";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblSuperAssessmentScore" + (questionRowCount + 1).ToString();
                label.CssClass = "form-control text-center col" + (questionRowCount + 1) + "_7";
                label.Text = dtAssessmentQuestion.Rows[questionRowCount]["SELF_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(label);
                //column 5 分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_5";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                txt = new TextBox();
                txt.ID = "txtAssessmentScore" + (questionRowCount + 1).ToString();
                txt.CssClass = "form-control numbers-only add-number col" + (questionRowCount + 1) + "_5";
                txt.Attributes["placeholder"] = "請打分數";
                innerDiv.Controls.Add(txt);
            }
        }         
        rowCount = dtAssessmentQuestion.Rows.Count;
        //讀取出勤資料
        //edit annually:假別代號有更改或增加新假別時需更新
        DataTable dtAttendance = new DataTable();
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
                if (!string.IsNullOrWhiteSpace(dtAttendance.Rows[i]["SubTotal"].ToString()))
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
            string query = "SELECT [EXPECTED_WORK_HOUR]"
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
            //lblOnJobPercent.Text = (Math.Floor(100 * 100 * (1 - (dayOffSum / onJobHour))) / 100).ToString();    //2018.07.23 改成小數第二位無條件捨去
        }
        else
        {
            lblExpectedAttendance.Text = "N/A";
            lblActualAttendance.Text = "N/A";
            lblAttendanceScore.Text = "N/A";
        }
        //計算未用完的特/補休
        //using (SqlConnection conn = new SqlConnection(NZconnectionString))
        //{
        //    string query = "";
        //    conn.Open();
        //    if (lblEmpID.Text == "0010")
        //    {
        //        query = "SELECT CONVERT(DECIMAL(16,1),((PALTK.TK003-PALTK.TK004)*8.5)+(PALTK.TK005-PALTK.TK006))"
        //        + " FROM PALTK"
        //        + " WHERE PALTK.TK001=@ID"
        //        + " AND PALTK.TK002=@YEAR";
        //    }
        //    else
        //    {
        //        query = "SELECT CONVERT(DECIMAL(16,1),((PALTK.TK003-PALTK.TK004)*8.0)+(PALTK.TK005-PALTK.TK006))"
        //        + " FROM PALTK"
        //        + " WHERE PALTK.TK001=@ID"
        //        + " AND PALTK.TK002=@YEAR";
        //    }
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@ID", lblEmpID.Text);
        //    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
        //    using (SqlDataReader dr = cmd.ExecuteReader())
        //    {
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                lblDayOffUnused.Text = dr[0].ToString();
        //            }
        //        }
        //        else
        //        {
        //            lblDayOffUnused.Text = "0.0";
        //        }
        //    }
        //}
        //讀取獎懲紀錄
        DataTable dtRnPRecord = new DataTable();
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
                + " order by record.RNPID,record.EventID,record.CreateDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            cmd.Parameters.AddWithValue("@year", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtRnPRecord);
        }
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
        //動態增加自評以外的評語格
        if (lblEvalType.Text != "自評") //判斷非自評
        {
            //讀取自評評語
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT OVERALL_COMMENT"
                + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                + " AND ASSESSED_ID=@ASSESSED_ID"
                + " AND ASSESS_YEAR=@ASSESS_YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Close();
                        txtSelfComment.Text = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        dr.Close();
                        txtSelfComment.Text = "";
                    }
                }
            }
            txtSelfComment.ReadOnly = true; //如非自評，則自評評語不可更改
            txtSelfComment.Attributes["placeholder"] = "";
            //評語 title
            HtmlGenericControl outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "commentRow1";
            outerDiv.Attributes["class"] = "row";
            comment.Controls.Add(outerDiv);
            HtmlGenericControl innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = "commentRow_Title";
            innerDiv.Attributes["class"] = "col-xs-12 subtitle border";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CMSMV.MV002"
                                            + " FROM CMSMV"
                                            + " WHERE CMSMV.MV001=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", assessor);
                innerDiv.InnerText = cmd.ExecuteScalar().ToString() + "評語";
            }
            outerDiv.Controls.Add(innerDiv);
            //評語 textbox
            outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "commentRow2";
            outerDiv.Attributes["class"] = "row";
            comment.Controls.Add(outerDiv);
            innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = "commentRow_Comment";
            innerDiv.Attributes["class"] = "col-xs-12 border";
            outerDiv.Controls.Add(innerDiv);
            TextBox txt = new TextBox();
            txt.ID = "txtCommentRow_Comment";
            txt.CssClass = "form-control no-resize autosize";
            txt.Attributes["placeholder"] = "請寫下" + lblEmpName.Text +"今年度的貢獻、表現、及給予建議";
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Wrap = true;
            innerDiv.Controls.Add(txt);
        }
    }
    /// <summary>
    /// 讀取已經被評過分的表單
    /// </summary>
    /// <param name="assessor"></param>
    /// <param name="assessed"></param>
    protected void loadAssessedForm(string assessor, string assessed, string assess_type)
    {
        DataTable dtSurveyContent = new DataTable();
        string query = "";        
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "SELECT A.ASSESSED_ID,B.MV002,A.ASSESSED_RANK,A.ASSESSED_WORKYEAR,A.ASSESS_YEAR,A.ASSESS_DATE,D.NAME,A.WEIGHTED_SCORE,A.OVERALL_COMMENT,COALESCE(A.RNP_SCORE,0.0) 'RNP_SCORE'"
                + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A A"
                + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A C ON A.ASSESSOR_ID=C.ASSESSOR_ID AND A.ASSESSED_ID=C.ASSESSED_ID AND A.ASSESS_YEAR=C.[YEAR]"
                + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A D ON C.ASSESS_TYPE=D.ID"
                + " WHERE A.ASSESSED_ID=@ASSESSED_ID"
                + " AND A.ASSESSOR_ID=@ASSESSOR_ID"
                + " AND A.ASSESS_YEAR=@ASSESS_YEAR";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtSurveyContent);
        }
        lblEmpID.Text = dtSurveyContent.Rows[0][0].ToString();
        lblEmpName.Text = dtSurveyContent.Rows[0][1].ToString();
        lblEmpJob.Text = dtSurveyContent.Rows[0][2].ToString();
        lblEmpWorkYear.Text = dtSurveyContent.Rows[0][3].ToString();
        lblEvalYear.Text = dtSurveyContent.Rows[0][4].ToString();
        lblEvalDate.Text = dtSurveyContent.Rows[0][5].ToString();
        lblEvalType.Text = dtSurveyContent.Rows[0][6].ToString();
        if (!IsPostBack)
        {
            lblFinalScore.Text = dtSurveyContent.Rows[0][7].ToString();
            hfFinalScore.Value = dtSurveyContent.Rows[0][7].ToString();
        }
        //動態增加自評以外的評語格
        if (lblEvalType.Text != "自評") //判斷非自評
        {
            txtSelfComment.ReadOnly = true; //如非自評，則自評評語不可更改
            txtSelfComment.Attributes["placeholder"] = "";
            //評語 title
            HtmlGenericControl outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "commentRow1";
            outerDiv.Attributes["class"] = "row";
            comment.Controls.Add(outerDiv);
            HtmlGenericControl innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = "commentRow_Title";
            innerDiv.Attributes["class"] = "col-xs-12 subtitle border";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CMSMV.MV002"
                                            + " FROM CMSMV"
                                            + " WHERE CMSMV.MV001=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", assessor);
                innerDiv.InnerText = cmd.ExecuteScalar().ToString() + "評語";
            }
            outerDiv.Controls.Add(innerDiv);
            //評語 textbox
            outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "commentRow2";
            outerDiv.Attributes["class"] = "row";
            comment.Controls.Add(outerDiv);
            innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = "commentRow_Comment";
            innerDiv.Attributes["class"] = "col-xs-12 border";
            outerDiv.Controls.Add(innerDiv);
            TextBox txt = new TextBox();
            txt.ID = "txtCommentRow_Comment";
            txt.CssClass = "form-control no-resize autosize";
            txt.Attributes["placeholder"] = "請寫下" + lblEmpName.Text + "今年度的貢獻、表現、及給予建議";
            txt.Text = dtSurveyContent.Rows[0][8].ToString();
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Wrap = true;
            innerDiv.Controls.Add(txt);
        }
        //讀取自評評語
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                query = "SELECT OVERALL_COMMENT"
                + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                + " AND ASSESSED_ID=@ASSESSED_ID"
                + " AND ASSESS_YEAR=@ASSESS_YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Close();
                        txtSelfComment.Text = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        dr.Close();
                        txtSelfComment.Text = "";
                    }
                }
            }
        }
        
        //讀取出勤資料
        //edit annually:假別代號有更改或增加新假別時需更新
        DataTable dtAttendance = new DataTable();
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
                dayOffValue += Convert.ToDouble(dtAttendance.Rows[i]["SubTotal"]);
            }
        }
        //計算小計
        lblDayOffSum.Text = dayOffSum.ToString("N2");
        lblDayOffValueSum.Text = dayOffValue.ToString("N2");
        //計算出勤率
        //每年須手動修改需出勤時數 edit annually
        double onJobHour = 0;
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
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "select eventCategory.Name 'EventName'"
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
                + " order by record.RNPID,record.EventID,record.CreateDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            cmd.Parameters.AddWithValue("@year", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtRnPRecord);
        }
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
            divRnP2.InnerText = Convert.ToDecimal(dtRnPRecord.Rows[i]["RnPScore"]).ToString("N2");
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
        //load question from HR360_ASSESSMENTSCORE_SCORE_A
        if (assess_type == "1")
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                query = "SELECT [INDEX],QUESTION_CATEGORY_ID,QUESTION_CATEGORY_NAME,QUESTION_CATEGORY_WEIGHT,QUESTION,SCORE 'SELF_SCORE'"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                    + " AND ASSESSED_ID=@ASSESSED_ID"
                    + " AND ASSESS_YEAR=@ASSESS_YEAR"
                    + " ORDER BY [INDEX]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                dtSurveyContent = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSurveyContent);
            }
        }
        else if (assess_type == "2")
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                query = ";WITH SUPER_TABLE"
                    + " AS"
                    + " ("
                    + " SELECT [INDEX],SCORE"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                    + " AND ASSESSED_ID=@ASSESSED_ID"
                    + " AND ASSESS_YEAR=@ASSESS_YEAR"
                    + " )"
                    + " SELECT [SELF].[INDEX]"
                    + " ,[SELF].QUESTION_CATEGORY_ID"
                    + " ,[SELF].QUESTION_CATEGORY_NAME"
                    + " ,[SELF].QUESTION_CATEGORY_WEIGHT"
                    + " ,[SELF].QUESTION"
                    + " ,[SELF].SCORE 'SELF_SCORE'"
                    + " ,SUPER.SCORE 'SUPER_SCORE'"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A [SELF]"
                    + " LEFT JOIN SUPER_TABLE SUPER ON SUPER.[INDEX]=[SELF].[INDEX]"
                    + " WHERE [SELF].ASSESSOR_ID=@ASSESSED_ID"
                    + " AND [SELF].ASSESSED_ID=@ASSESSED_ID"
                    + " AND [SELF].ASSESS_YEAR=@ASSESS_YEAR"
                    + " ORDER BY [INDEX]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                dtSurveyContent = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSurveyContent);
            }
        }
        else if (assess_type == "9")
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                query = ";WITH ASSESS_TABLE"
                    + " AS"
                    + " ("
                    + " SELECT ASSESSOR_ID,ASSESS_TYPE"
                    + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                    + " WHERE [YEAR]=@ASSESS_YEAR"
                    + " AND ASSESSED_ID=@ASSESSED_ID"
                    + " )"
                    + " ,SUPER_TABLE"
                    + " AS"
                    + " ("
                    + " SELECT A.[INDEX],A.SCORE"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A A"
                    + " LEFT JOIN ASSESS_TABLE ASSESS ON ASSESS.ASSESS_TYPE='2'"
                    + " WHERE A.ASSESSOR_ID=ASSESS.ASSESSOR_ID"
                    + " AND A.ASSESSED_ID=@ASSESSED_ID"
                    + " AND A.ASSESS_YEAR=@ASSESS_YEAR"
                    + " ),"
                    + " SPECIAL_TABLE"
                    + " AS"
                    + " ("
                    + " SELECT A.[INDEX],A.SCORE"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A A"
                    + " LEFT JOIN ASSESS_TABLE ASSESS ON ASSESS.ASSESS_TYPE='9'"
                    + " WHERE A.ASSESSOR_ID=ASSESS.ASSESSOR_ID"
                    + " AND A.ASSESSED_ID=@ASSESSED_ID"
                    + " AND A.ASSESS_YEAR=@ASSESS_YEAR"
                    + " )"
                    + " SELECT [SELF].[INDEX]"
                    + " ,[SELF].QUESTION_CATEGORY_ID"
                    + " ,[SELF].QUESTION_CATEGORY_NAME"
                    + " ,[SELF].QUESTION_CATEGORY_WEIGHT"
                    + " ,[SELF].QUESTION"
                    + " ,[SELF].SCORE 'SELF_SCORE'"
                    + " ,SUPER.SCORE 'SUPER_SCORE'"
                    + " ,[SPECIAL].SCORE 'SPECIAL_SCORE'"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A [SELF]"
                    + " LEFT JOIN SUPER_TABLE SUPER ON SUPER.[INDEX]=[SELF].[INDEX]"
                    + " LEFT JOIN SPECIAL_TABLE SPECIAL ON SPECIAL.[INDEX]=[SELF].[INDEX]"
                    + " WHERE [SELF].ASSESSOR_ID=@ASSESSED_ID"
                    + " AND [SELF].ASSESSED_ID=@ASSESSED_ID"
                    + " AND [SELF].ASSESS_YEAR=@ASSESS_YEAR"
                    + " ORDER BY [INDEX]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", year);
                dtSurveyContent = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSurveyContent);
            }
        }
        for (int i = 0; i < dtSurveyContent.Rows.Count; i++)
        {
            //row
            HtmlGenericControl outerDiv = new HtmlGenericControl();
            outerDiv.TagName = "div";
            outerDiv.ID = "questionRow" + (i + 1).ToString();
            outerDiv.Attributes["class"] = "row";
            Load_Question.Controls.Add(outerDiv);
            //column 1 題號
            HtmlGenericControl innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = outerDiv.ID + "_1";
            innerDiv.Attributes["class"] = "col-xs-1 border text-center";
            outerDiv.Controls.Add(innerDiv);
            Label label = new Label();
            label.ID = "lblIndex" + (i + 1).ToString();
            label.CssClass = "form-control col" + (i + 1) + "_1";
            label.Text = dtSurveyContent.Rows[i][0].ToString();
            innerDiv.Controls.Add(label);
            //column 2 分類
            innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = outerDiv.ID + "_2";
            innerDiv.Attributes["class"] = "col-xs-2 border text-center";
            outerDiv.Controls.Add(innerDiv);
            label = new Label();
            label.ID = "lblAssessmentCategory" + (i + 1).ToString();
            label.CssClass = "form-control col" + (i + 1) + "_2";
            label.Text = dtSurveyContent.Rows[i]["QUESTION_CATEGORY_ID"].ToString() + '_' + dtSurveyContent.Rows[i]["QUESTION_CATEGORY_NAME"].ToString();
            innerDiv.Controls.Add(label);
            //column 3 權重
            innerDiv = new HtmlGenericControl();
            innerDiv.TagName = "div";
            innerDiv.ID = outerDiv.ID + "_3";
            innerDiv.Attributes["class"] = "col-xs-1 border text-center";
            outerDiv.Controls.Add(innerDiv);
            label = new Label();
            label.ID = "lblAssessmentCategoryWeight" + (i + 1).ToString();
            label.CssClass = "form-control col" + (i + 1) + "_3";
            label.Text = dtSurveyContent.Rows[i]["QUESTION_CATEGORY_WEIGHT"].ToString();
            innerDiv.Controls.Add(label);
            if (assess_type == "1")
            {
                //column 4 問題
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_4";
                innerDiv.Attributes["class"] = "col-xs-6 border";
                outerDiv.Controls.Add(innerDiv);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (i + 1).ToString();
                txt.CssClass = "form-control no-resize autosize col" + (i + 1) + "_4";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                txt.ReadOnly = true;
                txt.Text = dtSurveyContent.Rows[i]["QUESTION"].ToString();
                innerDiv.Controls.Add(txt);
                //column 5 分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_5";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                txt = new TextBox();
                txt.ID = "txtAssessmentScore" + (i + 1).ToString();
                txt.CssClass = "form-control numbers-only add-number col" + (i + 1) + "_5";
                txt.Attributes["placeholder"] = "請打分數";
                txt.Text = dtSurveyContent.Rows[i]["SELF_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(txt);
            }
            else if (assess_type == "2")
            {
                //column 4 問題
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_4";
                innerDiv.Attributes["class"] = "col-xs-4 border";
                outerDiv.Controls.Add(innerDiv);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (i + 1).ToString();
                txt.CssClass = "form-control no-resize autosize col" + (i + 1) + "_4";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                txt.ReadOnly = true;
                txt.Text = dtSurveyContent.Rows[i]["QUESTION"].ToString();
                innerDiv.Controls.Add(txt);
                //column 6 自評分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_6";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblSelfAssessmentScore" + (i + 1).ToString();
                label.CssClass = "form-control text-center col" + (i + 1) + "_6";
                label.Text = dtSurveyContent.Rows[i]["SELF_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(label);
                //column 5 分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_5";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                txt = new TextBox();
                txt.ID = "txtAssessmentScore" + (i + 1).ToString();
                txt.CssClass = "form-control numbers-only add-number col" + (i + 1) + "_5";
                txt.Attributes["placeholder"] = "請打分數";
                txt.Text = dtSurveyContent.Rows[i]["SUPER_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(txt);
            }
            else if (assess_type == "9")
            {
                //column 4 問題
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_4";
                innerDiv.Attributes["class"] = "col-xs-2 border";
                outerDiv.Controls.Add(innerDiv);
                TextBox txt = new TextBox();
                txt.ID = "txtAssessmentQuestion" + (i + 1).ToString();
                txt.CssClass = "form-control no-resize autosize col" + (i + 1) + "_4";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Wrap = true;
                txt.ReadOnly = true;
                txt.Text = dtSurveyContent.Rows[i]["QUESTION"].ToString();
                innerDiv.Controls.Add(txt);
                //column 6 自評分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_6";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblSelfAssessmentScore" + (i + 1).ToString();
                label.CssClass = "form-control text-center col" + (i + 1) + "_6";
                label.Text = dtSurveyContent.Rows[i]["SELF_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(label);
                //column 7 主管評分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_7";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                label = new Label();
                label.ID = "lblSuperAssessmentScore" + (i + 1).ToString();
                label.CssClass = "form-control text-center col" + (i + 1) + "_7";
                label.Text = dtSurveyContent.Rows[i]["SUPER_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(label);
                //column 5 分數
                innerDiv = new HtmlGenericControl();
                innerDiv.TagName = "div";
                innerDiv.ID = outerDiv.ID + "_5";
                innerDiv.Attributes["class"] = "col-xs-2 border text-center";
                outerDiv.Controls.Add(innerDiv);
                txt = new TextBox();
                txt.ID = "txtAssessmentScore" + (i + 1).ToString();
                txt.CssClass = "form-control numbers-only add-number col" + (i + 1) + "_5";
                txt.Attributes["placeholder"] = "請打分數";
                txt.Text = dtSurveyContent.Rows[i]["SPECIAL_SCORE"].ToString() ?? "未評核";
                innerDiv.Controls.Add(txt);
            }
        }
        rowCount = dtSurveyContent.Rows.Count;
    }
    /// <summary>
    /// submit按鈕觸發事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string assessor = Session["erp_id"].ToString().Trim();
            saveSurveyData(assessor);

            //更新:2017.01.19 PER 吉田，移除特評制度
            //更新:2017.01.20 PER CHRISSY，恢復使用特評制度
            double standard; //特評標準分數的門檻, retrieve from database HR360_ASSESSMENTSCORE_STANDARD
            double d;
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT *"
                            + " FROM HR360_ASSESSMENTSCORE_STANDARD";
                SqlCommand cmd = new SqlCommand(query, conn);
                standard = Convert.ToDouble(cmd.ExecuteScalar().ToString());
            }            
            if (double.TryParse(hfFinalScore.Value, out d))
            {
                if (lblEvalType.Text == "主管評" || lblEvalType.Text == "特評") //自評不需特別assign
                {
                    if (d < standard)
                    {
                        assignSpecialAssessment(assessor);
                    }
                    else
                    {
                        removeSpecialAssessment(assessor);
                    }
                }
            }
            else
            {
                lblErrorMessage.Text = "成績非數字格式";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('資料已送出');window.location='UI05.aspx'", true);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }

    }
    /// <summary>
    /// Saves survey data to SQL DB
    /// dbo.HR360_ASSESSMENTSCORE_ASSESSED_A and dbo.HR36_ASSESSMENTSCORE_SCORE_A
    /// </summary>
    protected void saveSurveyData(string assessor)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query;
                //搜尋dbo.HR360_ASSESSMENTSCORE_ASSESSED_A看有沒有已評分的紀錄
                query = "SELECT *"
                    + " FROM HR360_ASSESSMENTSCORE_ASSESSED_A"
                    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                    + " AND ASSESSED_ID=@ASSESSED_ID"
                    + " AND ASSESS_YEAR=@YEAR";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) //新評分
                    {
                        dr.Close();
                        //寫入 評核大項
                        query = "INSERT INTO HR360_ASSESSMENTSCORE_ASSESSED_A"
                            + " VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER,@ASSESSOR_ID"
                            + " ,@ASSESS_DATE,@ASSESS_YEAR,@ASSESSED_ID,@ASSESSED_RANK,@ASSESSED_WORKYEAR"
                            + " ,@WEIGHTED_SCORE,@ATTENDANCE_SCORE,@RNP_SCORE,@OVERALL_COMMENT)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CREATOR", assessor);
                        cmd.Parameters.AddWithValue("@MODIFIER", assessor);
                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                        cmd.Parameters.AddWithValue("@ASSESS_DATE", lblEvalDate.Text);
                        cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_RANK", lblEmpJob.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_WORKYEAR", lblEmpWorkYear.Text);
                        cmd.Parameters.AddWithValue("@ATTENDANCE_SCORE", lblAttendanceScore.Text);
                        cmd.Parameters.AddWithValue("@RNP_SCORE", lblFinalRnPScore.Text);
                        cmd.Parameters.AddWithValue("@WEIGHTED_SCORE", hfFinalScore.Value.ToString());
                        //評語，自評跟非自評要擷取不同的控制項
                        if (lblEvalType.Text.Trim() == "自評")
                        {
                            //自評
                            cmd.Parameters.AddWithValue("@OVERALL_COMMENT", txtSelfComment.Text.Trim());
                        }
                        else
                        {
                            //非自評
                            cmd.Parameters.AddWithValue("@OVERALL_COMMENT", ((TextBox)comment.FindControl("txtCommentRow_Comment")).Text.Trim());
                        }
                        cmd.ExecuteNonQuery();

                        //寫入 評核細項
                        for (int i = 0; i < rowCount; i++)
                        {
                            query = "INSERT INTO HR360_ASSESSMENTSCORE_SCORE_A"
                                + " VALUES("
                                + " @ASSESSOR_ID,@ASSESS_YEAR,@ASSESSED_ID,@INDEX"
                                + " ,@QUESTION_CATEGORY_ID,@QUESTION_CATEGORY_NAME,"
                                + " @QUESTION_CATEGORY_WEIGHT,@QUESTION,@SCORE"
                                + " )";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                            cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                            cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                            cmd.Parameters.AddWithValue("@INDEX", ((Label)Load_Question.FindControl("lblIndex" + (i + 1).ToString())).Text);
                            cmd.Parameters.AddWithValue("@QUESTION_CATEGORY_ID", ((Label)Load_Question.FindControl("lblAssessmentCategory" + (i + 1).ToString())).Text.Substring(0, 2));
                            cmd.Parameters.AddWithValue("@QUESTION_CATEGORY_NAME", ((Label)Load_Question.FindControl("lblAssessmentCategory" + (i + 1).ToString())).Text.Substring(3));
                            cmd.Parameters.AddWithValue("@QUESTION_CATEGORY_WEIGHT", ((Label)Load_Question.FindControl("lblAssessmentCategoryWeight" + (i + 1).ToString())).Text);
                            cmd.Parameters.AddWithValue("@QUESTION", ((TextBox)Load_Question.FindControl("txtAssessmentQuestion" + (i + 1).ToString())).Text.Trim());
                            cmd.Parameters.AddWithValue("@SCORE", ((TextBox)Load_Question.FindControl("txtAssessmentScore" + (i + 1).ToString())).Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        //因為是新的ENTRY,到HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A的ASSESSMENT_DONE打1表示此評核已完成
                        query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                            + " SET ASSESSMENT_DONE=1"
                            + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND YEAR=@ASSESS_YEAR AND ASSESSED_ID=@ASSESSED_ID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                        cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else //更新舊評分
                    {
                        dr.Close();
                        //寫入 評核大項
                        query = "UPDATE HR360_ASSESSMENTSCORE_ASSESSED_A"
                            + " SET MODIFIEDDATE=GETDATE()"
                            + " ,ASSESS_DATE=@ASSESS_DATE,ASSESSED_RANK=@ASSESSED_RANK,ASSESSED_WORKYEAR=@ASSESSED_WORKYEAR"
                            + " ,WEIGHTED_SCORE=@WEIGHTED_SCORE,RNP_SCORE=@RNP_SCORE,OVERALL_COMMENT=@OVERALL_COMMENT"
                            + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND ASSESS_YEAR=@ASSESS_YEAR AND ASSESSED_ID=@ASSESSED_ID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                        cmd.Parameters.AddWithValue("@ASSESS_DATE", lblEvalDate.Text);
                        cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_RANK", lblEmpJob.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_WORKYEAR", lblEmpWorkYear.Text);
                        cmd.Parameters.AddWithValue("@RNP_SCORE", lblFinalRnPScore.Text);
                        cmd.Parameters.AddWithValue("@WEIGHTED_SCORE", hfFinalScore.Value.ToString());
                        //評語，自評跟非自評要擷取不同的控制項
                        if (lblEvalType.Text.Trim() == "自評")
                        {
                            //自評
                            cmd.Parameters.AddWithValue("@OVERALL_COMMENT", txtSelfComment.Text.Trim());
                        }
                        else
                        {
                            //非自評
                            cmd.Parameters.AddWithValue("@OVERALL_COMMENT", ((TextBox)comment.FindControl("txtCommentRow_Comment")).Text.Trim());
                        }
                        cmd.ExecuteNonQuery();

                        //寫入 評核細項
                        for (int i = 0; i < rowCount; i++)
                        {
                            query = "UPDATE HR360_ASSESSMENTSCORE_SCORE_A"
                                + " SET QUESTION_CATEGORY_ID=@QUESTION_CATEGORY_ID"
                                + " ,QUESTION_CATEGORY_NAME=@QUESTION_CATEGORY_NAME"
                                + " ,QUESTION_CATEGORY_WEIGHT=@QUESTION_CATEGORY_WEIGHT"
                                + " ,QUESTION=@QUESTION,SCORE=@SCORE"
                                + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND ASSESS_YEAR=@ASSESS_YEAR"
                                + " AND ASSESSED_ID=@ASSESSED_ID AND [INDEX]=@INDEX";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                            cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                            cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                            cmd.Parameters.AddWithValue("@INDEX", ((Label)Load_Question.FindControl("lblIndex" + (i + 1).ToString())).Text);
                            cmd.Parameters.AddWithValue("@QUESTION_CATEGORY_ID", ((Label)Load_Question.FindControl("lblAssessmentCategory" + (i + 1).ToString())).Text.Substring(0, 2));
                            cmd.Parameters.AddWithValue("@QUESTION_CATEGORY_NAME", ((Label)Load_Question.FindControl("lblAssessmentCategory" + (i + 1).ToString())).Text.Substring(3));
                            cmd.Parameters.AddWithValue("@QUESTION_CATEGORY_WEIGHT", ((Label)Load_Question.FindControl("lblAssessmentCategoryWeight" + (i + 1).ToString())).Text);
                            cmd.Parameters.AddWithValue("@QUESTION", ((TextBox)Load_Question.FindControl("txtAssessmentQuestion" + (i + 1).ToString())).Text.Trim());
                            cmd.Parameters.AddWithValue("@SCORE", ((TextBox)Load_Question.FindControl("txtAssessmentScore" + (i + 1).ToString())).Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    /// <summary>
    /// assigning 特評 (主管考績未達標，他底下的人員將會由此主管的主管再打一次考績)
    /// </summary>
    protected void assignSpecialAssessment(string assessor)
    {
        try
        {
            //檢查特評是否已經assign過
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                DataTable dtReassignmentList = new DataTable();
                conn.Open();
                string query;
                //搜尋dbo.HR360_ASSESSMENTSCORE_ASSESSED_A，先捉出被低分者評分的清單(不包括自評)
                query = "SELECT ASSESSED_ID"
                    + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                    + " AND YEAR=@YEAR AND ASSESS_TYPE<>'1'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows) //低分者為主管，有需要他評分的人
                    {
                        dtReassignmentList.Load(dr);
                        dr.Close();
                        ////將此主管所負責的評核都變成INACTIVE  //2017.01.17更新:主管評核全部保留，一併作為最後審核的依據
                        //query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                        //    + " SET ACTIVE='0', MODIFIEDDATE=GETDATE(), MODIFIER=@MODIFIER"
                        //    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                        //    + " AND YEAR=@YEAR AND ASSESS_TYPE<>'1'";
                        //cmd = new SqlCommand(query, conn);
                        //cmd.Parameters.AddWithValue("@MODIFIER", assessor);
                        //cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
                        //cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                        //cmd.ExecuteNonQuery();
                        for (int i = 0; i < dtReassignmentList.Rows.Count; i++)
                        {
                            //搜尋看這清單裡面的人是否已被選為特評
                            query = "SELECT ASSESSED_ID"
                                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                                + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND ASSESSED_ID=@ASSESSED_ID"
                                + " AND YEAR=@YEAR AND ASSESS_TYPE='9'";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                            cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
                            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                            using (SqlDataReader dr2 = cmd.ExecuteReader())
                            {
                                if (dr2.HasRows) //已被選為特評，用UPDATE將ACTIVE改成1即可
                                {
                                    dr2.Close();
                                    query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                                        + " SET ACTIVE='1', MODIFIEDDATE=GETDATE(), MODIFIER=@MODIFIER"
                                        + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND ASSESSED_ID=@ASSESSED_ID"
                                        + " AND YEAR=@YEAR";
                                    cmd = new SqlCommand(query, conn);
                                    cmd.Parameters.AddWithValue("@MODIFIER", assessor);
                                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                                    cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
                                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                                    cmd.ExecuteNonQuery();
                                }
                                else //尚未被選為特評，需INSERT
                                {
                                    dr2.Close();
                                    query = "INSERT INTO HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                                        + " VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER"
                                        + " ,@YEAR,@ASSESSOR_ID,@ASSESSED_ID"
                                        + " ,'9','0','1')";
                                    cmd = new SqlCommand(query, conn);
                                    cmd.Parameters.AddWithValue("@CREATOR", assessor);
                                    cmd.Parameters.AddWithValue("@MODIFIER", assessor);
                                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
                                    cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
                                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    /// <summary>
    /// 將特評移除 (主管考績更動後達標，將特評ACTIVE改為0，並將所有達標者所負責的評核設為ACTIVE)
    /// </summary>
    protected void removeSpecialAssessment(string assessor)
    {        
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "";
            //將assessor為達標者的組合皆設為active  //2017.01.17更新:主管評將永遠為ACTIVE，故不需重設ACTIVE
            //query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
            //            + " SET ACTIVE='1'"
            //            + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND YEAR=@YEAR";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
            //cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            //cmd.ExecuteNonQuery();
            //擷取assessor為達標者的清單，之後檢查清單裡的人是否有被設定成為特評對象(不包含自評)
            DataTable dtReassignmentList = new DataTable();
            query = "SELECT ASSESSED_ID"
                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
                + " AND YEAR=@YEAR"
                + " AND ASSESS_TYPE<>'1'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows) //達標者為主管，有需要評核的人
                {
                    dtReassignmentList.Load(dr);
                    dr.Close();
                    //迴圈將清單內的人，如果有被選為特評的組合，設定成為INACTIVE(無論評核者為誰)
                    for (int i = 0; i < dtReassignmentList.Rows.Count; i++)
                    {
                        query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                        + " SET ACTIVE='0'"
                        + " WHERE ASSESSED_ID=@ASSESSED_ID"
                        + " AND ASSESSOR_ID<>@ASSESSOR_ID"
                        + " AND YEAR=@YEAR AND ASSESS_TYPE='9'";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
                        cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
                        cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}