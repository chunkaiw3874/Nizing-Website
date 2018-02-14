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
                        + " SELECT A.[YEAR] [年度],A.ASSESSED_ID [受評者ID],SCORE.WEIGHTED_SCORE [自評分數],MV.MV002 [受評者姓名]"
                        + " ,B.ASSESSOR_ID [主管ID],B.MV002 [主管姓名],B.WEIGHTED_SCORE [主管評分數]"
                        + " ,COALESCE(C.ASSESSOR_ID,'-') [特評者ID],COALESCE(C.MV002,'-') [特評者姓名],COALESCE(C.WEIGHTED_SCORE,'-') [特評分數]"
                        + " ,SCORE.ATTENDANCE_SCORE+'%' [出勤成績]"
                        + " ,CASE "
                        + " WHEN C.WEIGHTED_SCORE IS NULL THEN"
                        + "     CASE"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=100 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(100*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<100 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=99 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(90*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<99 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=98 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(80*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<98 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=97 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(70*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<97 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=96 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(60*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<96 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=95 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(50*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<95 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=94 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(40*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<94 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=93 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(30*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<93 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=92 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(20*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<92 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=91 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(10*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<91 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),B.WEIGHTED_SCORE)*10*0.9)+(0*0.1))"                        
                        + "     END"
                        + " ELSE"
                        + "     CASE"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=100 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(100*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<100 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=99 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(90*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<99 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=98 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(80*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<98 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=97 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(70*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<97 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=96 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(60*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<96 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=95 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(50*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<95 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=94 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(40*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<94 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=93 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(30*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<93 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=92 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(20*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<92 AND CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)>=91 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(10*0.1))"
                        + "     WHEN CONVERT(DECIMAL(16,2),SCORE.ATTENDANCE_SCORE)<91 THEN CONVERT(DECIMAL(16,2),(CONVERT(DECIMAL(16,2),C.WEIGHTED_SCORE)*10*0.9)+(0*0.1))"
                        + "     END"
                        + " END AS [考績]"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSED_ID=MV.MV001" //姓名
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR" //成績
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
                        + " ,CASE"
                        + " WHEN [考績] >= 90 THEN '甲'"
                        + " WHEN [考績] >= 80 AND [考績] < 90 THEN '乙'"
                        + " WHEN [考績] >= 70 AND [考績] < 80 THEN '丙'"
                        + " WHEN [考績] < 70 THEN '丁'"
                        + " ELSE 'N/A'"
                        + " END AS [考績級別]"
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