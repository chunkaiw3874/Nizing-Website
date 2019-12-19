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
    DataTable dtAssessmentQuestion = new DataTable();    
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if session has expired
        if (!((masterPage_HR360_Master)this.Master).CheckAuthentication())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        }
        else        
        {
            string year = "";
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT EVAL_YEAR" +
                            " FROM HR360_ASSESSMENTTIME" +
                            " where EVAL_YEAR = (select MIN(EVAL_YEAR) from HR360_ASSESSMENTTIME where EVAL_DONE = 0)";
                SqlCommand cmd = new SqlCommand(query, conn);
                year = cmd.ExecuteScalar().ToString() ?? "2016";
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

            /////////////////test value
            //assessor = "0001";
            //assessed = "0006";
            ///////////////////////////

            DataTable dtEval = new DataTable();
            //string evaluated = isEvaluated(assessor, assessed);
            dtEval = LoadEvaluationData(year, assessor, assessed);

            if (dtEval.Rows.Count == 0)
            {
                lblErrorMessage.Text = "沒有此組合";
            }
            else
            {
                bool isAssessed = Convert.ToBoolean(Convert.ToInt32(dtEval.Rows[0]["ASSESSMENT_DONE"].ToString()));

                LoadForm(year, assessor, assessed, dtEval.Rows[0]["ASSESS_TYPE"].ToString(), isAssessed);
            }

            //依照assess type動態製作表格問題欄位標題
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
            else if (dtEval.Rows[0]["ASSESS_TYPE"].ToString() == "3")
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
                headerText.InnerText = "核決主管分數";
                headerDiv.Controls.Add(headerText);
            }
        }
    }

    
    
    /// <summary>
    /// 讀取assessor/assessed組合評核狀況
    /// </summary>
    /// <returns></returns>
    protected DataTable LoadEvaluationData(string year, string assessor, string assessed)
    {
        DataTable dt = new DataTable();
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
        }
        return dt;
    }
    

    /// <summary>
    /// 設定及顯示表單資料
    /// </summary>
    /// <param name="year"></param>
    /// <param name="assessor"></param>
    /// <param name="assessed"></param>
    /// <param name="assessType"></param>
    /// <param name="isAssessed"></param>
    protected void LoadForm(string year, string assessor, string assessed, string assessType, bool isAssessed)
    {
        //依照是否已評核過的條件，讀取被評核員工資料及日期
        if (isAssessed)
        {
            DataTable dtSurveyContent = new DataTable();
            dtSurveyContent = GetAssessedData(year, assessor, assessed);

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
        }
        else
        {
            DataTable dt = new DataTable();

            //被評核員工基本資料
            dt = LoadAssessedPersonnelInfo(assessed);
            lblEmpID.Text = dt.Rows[0]["id"].ToString().Trim();
            lblEmpName.Text = dt.Rows[0]["name"].ToString().Trim();
            lblEmpJob.Text = dt.Rows[0]["job"].ToString().Trim();
            lblEmpWorkYear.Text = dt.Rows[0]["workYear"].ToString().Trim();

            //評核日期
            lblEvalYear.Text = year;
            lblEvalDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            lblEvalType.Text = LoadAssessDateInfo(year, assessor, assessed);
            
        }

        //讀取評量問題
        dtAssessmentQuestion = new DataTable();
        dtAssessmentQuestion = GetQuestionData(year, assessor, assessed, assessType, isAssessed);

        //製作問題動態div
        for (int i = 0; i < dtAssessmentQuestion.Rows.Count; i++)
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
            label.Text = dtAssessmentQuestion.Rows[i]["INDEX"].ToString();
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
            label.Text = dtAssessmentQuestion.Rows[i]["QUESTION_CATEGORY_ID"].ToString() + '_' + dtAssessmentQuestion.Rows[i]["QUESTION_CATEGORY_NAME"].ToString();
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
            label.Text = dtAssessmentQuestion.Rows[i]["QUESTION_CATEGORY_WEIGHT"].ToString();
            innerDiv.Controls.Add(label);
            if (assessType == "1")
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
                txt.Text = dtAssessmentQuestion.Rows[i]["QUESTION"].ToString();
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
                if (isAssessed)
                {
                    txt.Text = dtAssessmentQuestion.Rows[i]["SELF_SCORE"].ToString();
                }
                else
                {
                    txt.Text = "";
                    txt.Attributes["placeholder"] = "請打分數";
                }
                innerDiv.Controls.Add(txt);
            }
            else if (assessType == "2")
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
                txt.Text = dtAssessmentQuestion.Rows[i]["QUESTION"].ToString();
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
                label.Text = dtAssessmentQuestion.Rows[i]["SELF_SCORE"].ToString() ?? "未評核";
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
                if (isAssessed)
                {
                    txt.Text = dtAssessmentQuestion.Rows[i]["SUPER_SCORE"].ToString();
                }
                else
                {
                    txt.Text = "";
                    txt.Attributes["placeholder"] = "請打分數";
                }
                innerDiv.Controls.Add(txt);
            }
            else if (assessType == "3")
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
                txt.Text = dtAssessmentQuestion.Rows[i]["QUESTION"].ToString();
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
                label.Text = dtAssessmentQuestion.Rows[i]["SELF_SCORE"].ToString() ?? "未評核";
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
                label.Text = dtAssessmentQuestion.Rows[i]["SUPER_SCORE"].ToString() ?? "未評核";
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
                if(isAssessed)
                {
                    txt.Text = dtAssessmentQuestion.Rows[i]["FINAL_SCORE"].ToString();
                }
                else
                {
                    txt.Text = "";
                    txt.Attributes["placeholder"] = "請打分數";
                }
                innerDiv.Controls.Add(txt);
            }
        }

        //rowCount = dtAssessmentQuestion.Rows.Count;

        //讀取出勤資料
        //edit annually:假別代號有更改或增加新假別時需更新
        DataTable dtAttendance = new DataTable();
        dtAttendance = GetAttendanceData(year, lblEmpID.Text.Trim());

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

        //擷取特別評語擁有者清單
        List<string> assessorsWithOwnCommentSection = new List<string>();
        assessorsWithOwnCommentSection = GetSpecialCommentator(year);

        //讀取自評評語
        if (!IsPostBack)
        {
            txtSelfComment.Text = LoadComment(year, assessed, assessed, assessorsWithOwnCommentSection);
        }

        //動態增加自評以外的評語格
        if (assessType != "1") //判斷非自評
        {
            txtSelfComment.ReadOnly = true; //非自評，自評評語不可更改
            txtSelfComment.Attributes["placeholder"] = "";

            //動態製作非自評評與欄位
            //title
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

            //textbox
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
            txt.Text = LoadComment(year, assessor, assessed, assessorsWithOwnCommentSection);
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Wrap = true;
            innerDiv.Controls.Add(txt);
        }
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
            saveSurveyData();

            //更新:2017.01.19 PER 吉田，移除特評制度
            //更新:2017.01.20 PER CHRISSY，恢復使用特評制度
            //更新:2019.11 停止使用特評
            //double standard; //特評標準分數的門檻, retrieve from database HR360_ASSESSMENTSCORE_STANDARD
            double d;
            //using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //{
            //    conn.Open();
            //    string query = "SELECT *"
            //                + " FROM HR360_ASSESSMENTSCORE_STANDARD";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    standard = Convert.ToDouble(cmd.ExecuteScalar().ToString());
            //}            
            if (double.TryParse(hfFinalScore.Value, out d))
            {
                //if (lblEvalType.Text == "主管評" || lblEvalType.Text == "特評") //自評不需特別assign
                //{
                //    if (d < standard)
                //    {
                //        assignSpecialAssessment(assessor);
                //    }
                //    else
                //    {
                //        removeSpecialAssessment(assessor);
                //    }
                //}
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
    protected void saveSurveyData()
    {
        try
        {
            //擷取特別評語擁有者清單
            List<string> assessorsWithOwnCommentSection = new List<string>();
            assessorsWithOwnCommentSection = GetSpecialCommentator(lblEvalYear.Text);

            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query;

                //寫入 評核大項
                if (assessorsWithOwnCommentSection.Contains(Session["erp_id"].ToString().Trim()) && lblEvalType.Text.Trim() != "自評")
                {
                    query = "UPDATE HR360_ASSESSMENTSCORE_ASSESSED_A" +
                        " SET MODIFIEDDATE=@DATE" +
                        " ,MODIFIER=@USER" +
                        " ,ASSESS_DATE=@ASSESS_DATE" +
                        " ,ASSESSED_RANK=@ASSESSED_RANK" +
                        " ,ASSESSED_WORKYEAR=@ASSESSED_WORKYEAR" +
                        " ,WEIGHTED_SCORE=@WEIGHTED_SCORE" +
                        " ,ATTENDANCE_SCORE=@ATTENDANCE_SCORE" +
                        " ,RNP_SCORE=@RNP_SCORE" +
                        " WHERE ASSESSOR_ID=@USER" +
                        " AND ASSESS_YEAR=@ASSESS_YEAR" +
                        " AND ASSESSED_ID=@ASSESSED_ID" +
                        " IF @@ROWCOUNT=0" +
                        " INSERT INTO HR360_ASSESSMENTSCORE_ASSESSED_A(CREATEDATE,CREATOR,MODIFIEDDATE,MODIFIER,ASSESSOR_ID,ASSESS_DATE,ASSESS_YEAR,ASSESSED_ID,ASSESSED_RANK,ASSESSED_WORKYEAR,WEIGHTED_SCORE,ATTENDANCE_SCORE,RNP_SCORE)" +
                        " VALUES (@DATE" +
                        " ,@USER" +
                        " ,@DATE" +
                        " ,@USER" +
                        " ,@USER" +
                        " ,@ASSESS_DATE" +
                        " ,@ASSESS_YEAR" +
                        " ,@ASSESSED_ID" +
                        " ,@ASSESSED_RANK" +
                        " ,@ASSESSED_WORKYEAR" +
                        " ,@WEIGHTED_SCORE" +
                        " ,@ATTENDANCE_SCORE" +
                        " ,@RNP_SCORE)";
                }
                else
                {
                    query = "UPDATE HR360_ASSESSMENTSCORE_ASSESSED_A" +
                        " SET MODIFIEDDATE=@DATE" +
                        " ,MODIFIER=@USER" +
                        " ,ASSESS_DATE=@ASSESS_DATE" +
                        " ,ASSESSED_RANK=@ASSESSED_RANK" +
                        " ,ASSESSED_WORKYEAR=@ASSESSED_WORKYEAR" +
                        " ,WEIGHTED_SCORE=@WEIGHTED_SCORE" +
                        " ,ATTENDANCE_SCORE=@ATTENDANCE_SCORE" +
                        " ,RNP_SCORE=@RNP_SCORE" +
                        " ,OVERALL_COMMENT=@OVERALL_COMMENT" +
                        " WHERE ASSESSOR_ID=@USER" +
                        " AND ASSESS_YEAR=@ASSESS_YEAR" +
                        " AND ASSESSED_ID=@ASSESSED_ID" +
                        " IF @@ROWCOUNT=0" +
                        " INSERT INTO HR360_ASSESSMENTSCORE_ASSESSED_A" +
                        " VALUES (@DATE" +
                        " ,@USER" +
                        " ,@DATE" +
                        " ,@USER" +
                        " ,@USER" +
                        " ,@ASSESS_DATE" +
                        " ,@ASSESS_YEAR" +
                        " ,@ASSESSED_ID" +
                        " ,@ASSESSED_RANK" +
                        " ,@ASSESSED_WORKYEAR" +
                        " ,@WEIGHTED_SCORE" +
                        " ,@ATTENDANCE_SCORE" +
                        " ,@RNP_SCORE" +
                        " ,@OVERALL_COMMENT)";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@USER", Session["erp_id"].ToString().Trim());
                cmd.Parameters.AddWithValue("@ASSESS_DATE", lblEvalDate.Text);
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.Parameters.AddWithValue("@ASSESSED_RANK", lblEmpJob.Text);
                cmd.Parameters.AddWithValue("@ASSESSED_WORKYEAR", lblEmpWorkYear.Text);
                cmd.Parameters.AddWithValue("@ATTENDANCE_SCORE", lblAttendanceScore.Text);
                cmd.Parameters.AddWithValue("@RNP_SCORE", lblFinalRnPScore.Text);
                cmd.Parameters.AddWithValue("@WEIGHTED_SCORE", hfFinalScore.Value.ToString());
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

                //寫入 有獨立評語欄位者的評語
                if (assessorsWithOwnCommentSection.Contains(Session["erp_id"].ToString().Trim()) && lblEvalType.Text.Trim() != "自評")
                {
                    query = "UPDATE HR360_ASSESSMENTSCORE_ASSESSED_B" +
                        " SET MODIFIEDDATE=@DATE" +
                        " ,MODIFIER=@USER" +
                        " ,COMMENT=@COMMENT" +
                        " WHERE ASSESSOR_ID=@USER" +
                        " AND ASSESSED_ID=@ASSESSED_ID" +
                        " AND ASSESS_YEAR=@ASSESS_YEAR" +
                        " IF @@ROWCOUNT=0" +
                        " INSERT INTO HR360_ASSESSMENTSCORE_ASSESSED_B" +
                        " VALUES(" +
                        " @DATE" +
                        " ,@USER" +
                        " ,@DATE" +
                        " ,@USER" +
                        " ,@USER" +
                        " ,@ASSESSED_ID" +
                        " ,@ASSESS_YEAR" +
                        " ,@COMMENT)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@USER", Session["erp_id"].ToString().Trim());
                    cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                    cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                    cmd.Parameters.AddWithValue("@COMMENT", ((TextBox)comment.FindControl("txtCommentRow_Comment")).Text.Trim());
                }

                //寫入 評核細項
                for (int i = 0; i < dtAssessmentQuestion.Rows.Count; i++)
                {
                    query = "UPDATE HR360_ASSESSMENTSCORE_SCORE_A" +
                        " SET QUESTION_CATEGORY_ID=@QUESTION_CATEGORY_ID" +
                        " ,QUESTION_CATEGORY_NAME=@QUESTION_CATEGORY_NAME" +
                        " ,QUESTION_CATEGORY_WEIGHT=@QUESTION_CATEGORY_WEIGHT" +
                        " ,QUESTION=@QUESTION" +
                        " ,SCORE=@SCORE" +
                        " WHERE ASSESSOR_ID=@ASSESSOR_ID " +
                        " AND ASSESS_YEAR=@ASSESS_YEAR" +
                        " AND ASSESSED_ID=@ASSESSED_ID " +
                        " AND [INDEX]=@INDEX" +
                        " IF @@ROWCOUNT=0" +
                        " INSERT INTO HR360_ASSESSMENTSCORE_SCORE_A" +
                        " VALUES(" +
                        " @ASSESSOR_ID" +
                        " ,@ASSESS_YEAR" +
                        " ,@ASSESSED_ID" +
                        " ,@INDEX" +
                        " ,@QUESTION_CATEGORY_ID" +
                        " ,@QUESTION_CATEGORY_NAME" +
                        " ,@QUESTION_CATEGORY_WEIGHT" +
                        " ,@QUESTION" +
                        ", @SCORE)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", Session["erp_id"].ToString().Trim());
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

                //到HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A的ASSESSMENT_DONE打1表示此評核已完成
                query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
                            + " SET ASSESSMENT_DONE=1"
                            + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND YEAR=@ASSESS_YEAR AND ASSESSED_ID=@ASSESSED_ID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ASSESSOR_ID", Session["erp_id"].ToString().Trim());
                cmd.Parameters.AddWithValue("@ASSESS_YEAR", lblEvalYear.Text);
                cmd.Parameters.AddWithValue("@ASSESSED_ID", lblEmpID.Text);
                cmd.ExecuteNonQuery();                
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    ///// <summary>
    ///// assigning 特評 (主管考績未達標，他底下的人員將會由此主管的主管再打一次考績)
    ///// </summary>
    //protected void assignSpecialAssessment(string assessor)
    //{
    //    try
    //    {
    //        //檢查特評是否已經assign過
    //        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //        {
    //            DataTable dtReassignmentList = new DataTable();
    //            conn.Open();
    //            string query;
    //            //搜尋dbo.HR360_ASSESSMENTSCORE_ASSESSED_A，先捉出被低分者評分的清單(不包括自評)
    //            query = "SELECT ASSESSED_ID"
    //                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //                + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
    //                + " AND YEAR=@YEAR AND ASSESS_TYPE<>'1'";
    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
    //            cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //            using (SqlDataReader dr = cmd.ExecuteReader())
    //            {
    //                if (dr.HasRows) //低分者為主管，有需要他評分的人
    //                {
    //                    dtReassignmentList.Load(dr);
    //                    dr.Close();
    //                    ////將此主管所負責的評核都變成INACTIVE  //2017.01.17更新:主管評核全部保留，一併作為最後審核的依據
    //                    //query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //                    //    + " SET ACTIVE='0', MODIFIEDDATE=GETDATE(), MODIFIER=@MODIFIER"
    //                    //    + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
    //                    //    + " AND YEAR=@YEAR AND ASSESS_TYPE<>'1'";
    //                    //cmd = new SqlCommand(query, conn);
    //                    //cmd.Parameters.AddWithValue("@MODIFIER", assessor);
    //                    //cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
    //                    //cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //                    //cmd.ExecuteNonQuery();
    //                    for (int i = 0; i < dtReassignmentList.Rows.Count; i++)
    //                    {
    //                        //搜尋看這清單裡面的人是否已被選為特評
    //                        query = "SELECT ASSESSED_ID"
    //                            + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //                            + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND ASSESSED_ID=@ASSESSED_ID"
    //                            + " AND YEAR=@YEAR AND ASSESS_TYPE='9'";
    //                        cmd = new SqlCommand(query, conn);
    //                        cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
    //                        cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
    //                        cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //                        using (SqlDataReader dr2 = cmd.ExecuteReader())
    //                        {
    //                            if (dr2.HasRows) //已被選為特評，用UPDATE將ACTIVE改成1即可
    //                            {
    //                                dr2.Close();
    //                                query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //                                    + " SET ACTIVE='1', MODIFIEDDATE=GETDATE(), MODIFIER=@MODIFIER"
    //                                    + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND ASSESSED_ID=@ASSESSED_ID"
    //                                    + " AND YEAR=@YEAR";
    //                                cmd = new SqlCommand(query, conn);
    //                                cmd.Parameters.AddWithValue("@MODIFIER", assessor);
    //                                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
    //                                cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
    //                                cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //                                cmd.ExecuteNonQuery();
    //                            }
    //                            else //尚未被選為特評，需INSERT
    //                            {
    //                                dr2.Close();
    //                                query = "INSERT INTO HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //                                    + " VALUES (GETDATE(),@CREATOR,GETDATE(),@MODIFIER"
    //                                    + " ,@YEAR,@ASSESSOR_ID,@ASSESSED_ID"
    //                                    + " ,'9','0','1')";
    //                                cmd = new SqlCommand(query, conn);
    //                                cmd.Parameters.AddWithValue("@CREATOR", assessor);
    //                                cmd.Parameters.AddWithValue("@MODIFIER", assessor);
    //                                cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
    //                                cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
    //                                cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //                                cmd.ExecuteNonQuery();
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblErrorMessage.Text = ex.ToString();
    //    }
    //}
    ///// <summary>
    ///// 將特評移除 (主管考績更動後達標，將特評ACTIVE改為0，並將所有達標者所負責的評核設為ACTIVE)
    ///// </summary>
    //protected void removeSpecialAssessment(string assessor)
    //{        
    //    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
    //    {
    //        conn.Open();
    //        string query = "";
    //        //將assessor為達標者的組合皆設為active  //2017.01.17更新:主管評將永遠為ACTIVE，故不需重設ACTIVE
    //        //query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //        //            + " SET ACTIVE='1'"
    //        //            + " WHERE ASSESSOR_ID=@ASSESSOR_ID AND YEAR=@YEAR";
    //        //SqlCommand cmd = new SqlCommand(query, conn);
    //        //cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
    //        //cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //        //cmd.ExecuteNonQuery();
    //        //擷取assessor為達標者的清單，之後檢查清單裡的人是否有被設定成為特評對象(不包含自評)
    //        DataTable dtReassignmentList = new DataTable();
    //        query = "SELECT ASSESSED_ID"
    //            + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //            + " WHERE ASSESSOR_ID=@ASSESSOR_ID"
    //            + " AND YEAR=@YEAR"
    //            + " AND ASSESS_TYPE<>'1'";
    //        SqlCommand cmd = new SqlCommand(query, conn);
    //        cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
    //        cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //        using (SqlDataReader dr = cmd.ExecuteReader())
    //        {
    //            if (dr.HasRows) //達標者為主管，有需要評核的人
    //            {
    //                dtReassignmentList.Load(dr);
    //                dr.Close();
    //                //迴圈將清單內的人，如果有被選為特評的組合，設定成為INACTIVE(無論評核者為誰)
    //                for (int i = 0; i < dtReassignmentList.Rows.Count; i++)
    //                {
    //                    query = "UPDATE HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A"
    //                    + " SET ACTIVE='0'"
    //                    + " WHERE ASSESSED_ID=@ASSESSED_ID"
    //                    + " AND ASSESSOR_ID<>@ASSESSOR_ID"
    //                    + " AND YEAR=@YEAR AND ASSESS_TYPE='9'";
    //                    cmd = new SqlCommand(query, conn);
    //                    cmd.Parameters.AddWithValue("@ASSESSOR_ID", lblEmpID.Text);
    //                    cmd.Parameters.AddWithValue("@ASSESSED_ID", dtReassignmentList.Rows[i][0].ToString());
    //                    cmd.Parameters.AddWithValue("@YEAR", lblEvalYear.Text);
    //                    cmd.ExecuteNonQuery();
    //                }
    //            }
    //        }
    //    }
    //}

    //讀取基本資料
    private DataTable LoadAssessedPersonnelInfo(string assessed)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT CMSMV.MV001 'id',CMSMV.MV002 'name',CMSMJ.MJ003 'job',CMSMV.MV031 'workYear'"
                                            + " FROM CMSMV"
                                            + " LEFT JOIN CMSMJ ON CMSMV.MV006=CMSMJ.MJ001"
                                            + " WHERE CMSMV.MV001=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", assessed);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    //讀取日期資料
    private string LoadAssessDateInfo(string year, string assessor, string assessed)
    {        
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT B.NAME"
                                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                        + " LEFT JOIN HR360_ASSESSMENTPERSONNEL_TYPE_A B ON A.ASSESS_TYPE=B.ID"
                                        + " WHERE ASSESSED_ID = @ASSESSED_ID AND ASSESSOR_ID=@ASSESSOR_ID AND YEAR=@YEAR", conn);
            cmd.Parameters.AddWithValue("@ASSESSED_ID", assessed);
            cmd.Parameters.AddWithValue("@ASSESSOR_ID", assessor);
            cmd.Parameters.AddWithValue("@YEAR", year);
            return cmd.ExecuteScalar().ToString();
        }
    }

    //讀取題庫資料
    private DataTable GetQuestionData(string year, string assessor, string assessed, string assessType, bool isAssessed)
    {
        DataTable dt = new DataTable();
        string query = "";
        if (isAssessed)
        {
            if (assessType == "1")
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
            else if (assessType == "2")
            {
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
            }
            else if (assessType == "3")
            {
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
                    + " SELECT A.[INDEX],AVG(CONVERT(DECIMAL,A.SCORE)) SCORE"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A A"
                    + " LEFT JOIN ASSESS_TABLE ASSESS ON ASSESS.ASSESS_TYPE='2'"
                    + " WHERE A.ASSESSOR_ID=ASSESS.ASSESSOR_ID"
                    + " AND A.ASSESSED_ID=@ASSESSED_ID"
                    + " AND A.ASSESS_YEAR=@ASSESS_YEAR"
                    + " GROUP BY A.[INDEX]"
                    + " ),"
                    + " FINALIZER_TABLE"
                    + " AS"
                    + " ("
                    + " SELECT A.[INDEX],A.SCORE"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A A"
                    + " LEFT JOIN ASSESS_TABLE ASSESS ON ASSESS.ASSESS_TYPE='3'"
                    + " WHERE A.ASSESSOR_ID=ASSESS.ASSESSOR_ID"
                    + " AND A.ASSESSED_ID=@ASSESSED_ID"
                    + " AND A.ASSESS_YEAR=@ASSESS_YEAR"
                    + " )"
                    + " SELECT [SELF].[INDEX]"
                    + " ,[SELF].QUESTION_CATEGORY_ID"
                    + " ,[SELF].QUESTION_CATEGORY_NAME"
                    + " ,[SELF].QUESTION_CATEGORY_WEIGHT"
                    + " ,[SELF].QUESTION"
                    + " ,CONVERT(DECIMAL(3,1),[SELF].SCORE) 'SELF_SCORE'"
                    + " ,CONVERT(DECIMAL(3,1),SUPER.SCORE) 'SUPER_SCORE'"
                    + " ,CONVERT(DECIMAL(3,1),[FINAL].SCORE) 'FINAL_SCORE'"
                    + " FROM HR360_ASSESSMENTSCORE_SCORE_A [SELF]"
                    + " LEFT JOIN SUPER_TABLE SUPER ON SUPER.[INDEX]=[SELF].[INDEX]"
                    + " LEFT JOIN FINALIZER_TABLE FINAL ON FINAL.[INDEX]=[SELF].[INDEX]"
                    + " WHERE [SELF].ASSESSOR_ID=@ASSESSED_ID"
                    + " AND [SELF].ASSESSED_ID=@ASSESSED_ID"
                    + " AND [SELF].ASSESS_YEAR=@ASSESS_YEAR"
                    + " ORDER BY [INDEX]";
            }
        }
        else
        {
            if (assessType == "1") //load completely new questions from 題庫
            {
                query = "SELECT DISTINCT DENSE_RANK() OVER(ORDER BY A.ID) AS [INDEX]" +
                    " ,A.ID 'QUESTION_CATEGORY_ID'" +
                    " ,A.NAME 'QUESTION_CATEGORY_NAME'" +
                    " ,A.WEIGHT 'QUESTION_CATEGORY_WEIGHT'" +
                    " ,B.QUESTION"
                    + " FROM HR360_ASSESSMENTQUESTION_QUESTION_A B"
                    + " LEFT JOIN HR360_ASSESSMENTQUESTION_CATEGORY_A A ON B.CATEGORY_ID=A.ID"
                    + " LEFT JOIN HR360_ASSESSMENTQUESTION_ASSIGNMENT_A C ON B.ID=C.QUESTION_ID"
                    + " WHERE"
                    + " B.IN_USE='1'"
                    + " AND"
                    + " ("
                    + " B.USE_BY_ALL='1'"
                    + " OR"
                    + " C.DEPT IN (SELECT CMSMV.MV004"
                    + " FROM NZ.dbo.CMSMV"
                    + " LEFT JOIN NZ.dbo.CMSMK ON CMSMV.MV001=CMSMK.MK002"
                    + " WHERE CMSMV.MV001=@ASSESSED_ID)"
                    + " OR"
                    + " C.EMP_ID IN (SELECT CMSMV.MV001"
                    + " FROM NZ.dbo.CMSMV"
                    + " LEFT JOIN NZ.dbo.CMSMK ON CMSMV.MV001=CMSMK.MK002"
                    + " WHERE CMSMV.MV001=@ASSESSED_ID)"
                    + " )"
                    + " ORDER BY A.ID";                
            }
            else if (assessType == "2") //load questions saved from 自評
            {
                query = "SELECT [INDEX],QUESTION_CATEGORY_ID,QUESTION_CATEGORY_NAME,QUESTION_CATEGORY_WEIGHT,QUESTION,SCORE 'SELF_SCORE'"
                        + " FROM HR360_ASSESSMENTSCORE_SCORE_A"
                        + " WHERE ASSESSOR_ID=@ASSESSED_ID"
                        + " AND ASSESSED_ID=@ASSESSED_ID"
                        + " AND ASSESS_YEAR=@ASSESS_YEAR"
                        + " ORDER BY [INDEX]";
            }
            else if (assessType == "3")
            {
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
            }
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

    //讀取評語資料
    private string LoadComment(string year, string assessor, string assessed, List<string> assessorsWithOwnCommentSection)
    {
        if (assessorsWithOwnCommentSection.Contains(assessor) && assessor != assessed)
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

    //讀取評核歷史資料
    private DataTable GetAssessedData(string year, string assessor, string assessed)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT A.ASSESSED_ID" +
                ",B.MV002" +
                ",A.ASSESSED_RANK" +
                ",A.ASSESSED_WORKYEAR" +
                ",A.ASSESS_YEAR" +
                ",A.ASSESS_DATE" +
                ",D.NAME" +
                ",A.WEIGHTED_SCORE" +
                ",A.OVERALL_COMMENT" +
                ",COALESCE(A.RNP_SCORE,0.0) 'RNP_SCORE'"
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
}