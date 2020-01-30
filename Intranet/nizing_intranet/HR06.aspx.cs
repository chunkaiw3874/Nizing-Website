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
            string query = ";WITH CTE1"
                        + " AS"
                        + " ("
                        + " SELECT A.[YEAR] [年度],A.ASSESSED_ID [受評者ID],SCORE.WEIGHTED_SCORE [自評分數],MV.MV002 [受評者姓名]"
                        + " ,B.ASSESSOR_ID [初評者ID],B.MV002 [初評者姓名],B.WEIGHTED_SCORE [初評分數]"
                        + " ,COALESCE(C.ASSESSOR_ID,'-') [複評者ID],COALESCE(C.MV002,'-') [複評者姓名],COALESCE(C.WEIGHTED_SCORE,'-') [複評分數]"
                        + " ,SCORE.ATTENDANCE_SCORE+'%' [出勤成績]"
                        + " ,CONVERT(DECIMAL(10,2),SCORE.RNP_SCORE) [獎懲分數]"
                        + " ,CONVERT(DECIMAL(10,2),(CONVERT(DECIMAL(10,2),B.WEIGHTED_SCORE)*CONVERT(DECIMAL(10,2),B.scoreWeight)/100.0+CONVERT(DECIMAL(10,2),C.WEIGHTED_SCORE)*CONVERT(DECIMAL(10,2),C.scoreWeight)/100.0)*10*0.8+CONVERT(DECIMAL(10,2),SCORE.ATTENDANCE_SCORE)*0.2+CONVERT(DECIMAL(10,2),SCORE.RNP_SCORE))[考績]"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSED_ID=MV.MV001" //姓名
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR" //成績
                        + " LEFT JOIN" //初評清單
                        + " ("
                        + " SELECT A.ASSESSED_ID,A.ASSESSOR_ID,MV.MV002,SCORE.WEIGHTED_SCORE,WEIGHT.scoreWeight"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSOR_ID=MV.MV001"
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR"
                        + " LEFT JOIN HR360_AssessmentCategory_CategoryWeight WEIGHT ON A.[YEAR]=WEIGHT.assessYear AND A.ASSESS_TYPE=WEIGHT.assessType"
                        + " WHERE A.ACTIVE='1' AND A.ASSESS_TYPE='2'"
                        + " AND A.[YEAR]=@YEAR"
                        + " ) B ON A.ASSESSOR_ID=B.ASSESSED_ID"
                        + " LEFT JOIN" //複評清單
                        + " ("
                        + " SELECT A.ASSESSED_ID,A.ASSESSOR_ID,MV.MV002,SCORE.WEIGHTED_SCORE,WEIGHT.scoreWeight"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.ASSESSOR_ID=MV.MV001"
                        + " LEFT JOIN HR360_ASSESSMENTSCORE_ASSESSED_A SCORE ON A.ASSESSOR_ID=SCORE.ASSESSOR_ID AND A.ASSESSED_ID=SCORE.ASSESSED_ID AND A.[YEAR]=SCORE.ASSESS_YEAR"
                       + " LEFT JOIN HR360_AssessmentCategory_CategoryWeight WEIGHT ON A.[YEAR]=WEIGHT.assessYear AND A.ASSESS_TYPE=WEIGHT.assessType"
                        + " WHERE A.ACTIVE='1' AND A.ASSESS_TYPE='3'"
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
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            gvAssessmentScore.DataSource = ds;
            gvAssessmentScore.DataBind();
        }
    }
}