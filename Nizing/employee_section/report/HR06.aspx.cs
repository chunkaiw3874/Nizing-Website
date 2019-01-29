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

public partial class nizing_intranet_HR06 : System.Web.UI.Page
{
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 2016; i < DateTime.Today.Year; i++)
            {
                ddlYear.Items.Add(i.ToString());
                ddlYear.SelectedIndex = ddlYear.Items.Count - 1;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string order = "";
        if (rdoOrderByID.Checked)
        {
            order = "[受評者ID]";
        }
        else
        {
            order = "[考績] DESC";
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            //limitation:此QUERY只能有一個特評
            //更新: 2017.01.20 PER CHRISSY 有特評者使用特評+主管評的平均值
            //更新: 2018.02.08 PER CHRISSY 將出勤成績計算改成100=1、99=0.9、98=0.8...
            string query = ";WITH CTE1"   
                        + " AS"
                        + " ("
                        + " SELECT COALESCE(A.[YEAR],'-') [年度]"
                        + " ,COALESCE(A.ASSESSED_ID,'-') [受評者ID]"
                        + " ,COALESCE(SCORE.WEIGHTED_SCORE,'-') [自評分數]"
                        + " ,COALESCE(MV.MV002,'-') [受評者姓名]"
                        + " ,COALESCE(B.ASSESSOR_ID,'-') [主管ID]"
                        + " ,COALESCE(B.MV002,'-') [主管姓名]"
                        + " ,COALESCE(B.WEIGHTED_SCORE,'-') [主管評分數]"
                        + " ,COALESCE(C.ASSESSOR_ID,'-') [特評者ID]"
                        + " ,COALESCE(C.MV002,'-') [特評者姓名]"
                        + " ,COALESCE(C.WEIGHTED_SCORE,'-') [特評分數]"
                        + " ,COALESCE(SCORE.ATTENDANCE_SCORE,'-') [出勤成績]"
                        + " ,COALESCE(FINAL.FinalScore,0) [考績]"
                        + " ,COALESCE(FINAL.FinalScoreGrade,'-') [考績級別]"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSED_ID=MV.MV001" //姓名
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR" //成績
                        + " LEFT JOIN HR360_AssessmentScore_FinalScore FINAL ON A.ASSESSOR_ID=FINAL.EmpID AND A.[YEAR]=FINAL.AssessYear"
                        + " LEFT JOIN" //主管評清單
                        + " ("
                        + " SELECT A.ASSESSED_ID,A.ASSESSOR_ID,MV.MV002,SCORE.WEIGHTED_SCORE"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSOR_ID=MV.MV001"
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR"
                        + " WHERE A.ACTIVE='1' AND A.ASSESS_TYPE='2'"
                        + " AND A.[YEAR]=@YEAR"
                        + " ) B ON A.ASSESSOR_ID=B.ASSESSED_ID"
                        + " LEFT JOIN" //特評清單
                        + " ("
                        + " SELECT A.ASSESSED_ID,A.ASSESSOR_ID,MV.MV002,SCORE.WEIGHTED_SCORE"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSOR_ID=MV.MV001"
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR"
                        + " WHERE A.ACTIVE='1' AND A.ASSESS_TYPE='9'"
                        + " AND A.[YEAR]=@YEAR"
                        + " ) C ON A.ASSESSOR_ID=C.ASSESSED_ID"
                        + " WHERE A.ACTIVE='1'"
                        + " AND A.ASSESS_TYPE='1'"
                        + " AND A.[YEAR]=@YEAR"
                        + " )"
                        + " SELECT *"
                        + " FROM CTE1"
                        + " ORDER BY " + order;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", ddlYear.SelectedItem.ToString());
            //cmd.Parameters.AddWithValue("@ORDER", order);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvAssessmentScore.DataSource = ds;
            gvAssessmentScore.DataBind();
        }
    }
}