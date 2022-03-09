using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_user_report_salary_change_notification : System.Web.UI.Page
{
    string erp2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string nzconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string structureTabQuery = "SELECT PALTD.TD001"
                                    + " ,COALESCE(CMSMV.MV002, '') MV002"
                                    + " ,COALESCE(CMSMV.MV021, '') MV021"
                                    + " ,COALESCE(YEAR(GETDATE())-YEAR(CMSMV.MV008), '') AGE"
                                    + " ,COALESCE(CMSMV.MV031, '') MV031"
                                    + " ,COALESCE(CMSMJ.MJ003, '') MJ003"
                                    + " ,COALESCE(CMSMV.MV005, '') MV005"
                                    + " ,COALESCE(CMSME.ME002, '') ME002"
                                    + " ,PALTD.TD003"
                                    + " ,CASE PALTD.TD003"
                                    + " 	WHEN N'0001' THEN N'底薪'"
                                    + " 	ELSE PALMB.MB002"
                                    + " END AS MB002"
                                    + " ,CONVERT(DECIMAL(10,2), PALTD.TD004) TD004"
                                    + " ,CONVERT(DECIMAL(10,2),PALTD.TD005) TD005"
                                    + " ,COALESCE(PALTD.TD006,N'') COMMENT"
                                    + " FROM PALTD"
                                    + " LEFT JOIN CMSMV ON PALTD.TD001=CMSMV.MV001"
                                    + " LEFT JOIN CMSMJ ON CMSMV.MV006=CMSMJ.MJ001"
                                    + " LEFT JOIN CMSME ON CMSMV.MV004=CMSME.ME001"
                                    + " LEFT JOIN PALMB ON PALTD.TD003=PALMB.MB001"
                                    + " WHERE PALTD.TD001=@ID AND PALTD.TD008=N'Y' AND PALTD.TD002<@FIRSTDAY AND PALTD.TD002>@LASTDAY"
                                    + " ORDER BY PALTD.TD003";
            DataTable structureTabTable = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(nzconnectionString))
                {
                    conn.Open();
                    SqlCommand cmdStructureTab = new SqlCommand(structureTabQuery, conn);
                    cmdStructureTab.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmdStructureTab.Parameters.AddWithValue("@FIRSTDAY", DateTime.Today.AddDays(-4).ToString("yyyyMMdd"));
                    cmdStructureTab.Parameters.AddWithValue("@LASTDAY", DateTime.Today.AddMonths(-1).AddDays(-5).ToString("yyyyMMdd"));
                    SqlDataAdapter da = new SqlDataAdapter(cmdStructureTab);
                    da.Fill(structureTabTable);
                    grdStructure.DataSource = structureTabTable;
                    grdStructure.DataBind();
                }
                lblY.Text = DateTime.Today.Year.ToString();
                lblM.Text = DateTime.Today.Month.ToString("D2");
                lblMF001.Text = structureTabTable.Rows[0][0].ToString();
                lblMV002.Text = structureTabTable.Rows[0][1].ToString();
                //lblAge.Text = structureTabTable.Rows[0][3].ToString();
                lblMJ003.Text = structureTabTable.Rows[0][5].ToString();
                lblME002.Text = structureTabTable.Rows[0][7].ToString();
                lblLastYear.Text = DateTime.Today.AddYears(-1).Year.ToString();
                //lblGrade.Text = "";
                lblMV021.Text = structureTabTable.Rows[0][2].ToString();
                lblMV031.Text = structureTabTable.Rows[0][4].ToString();
                lblMV005.Text = structureTabTable.Rows[0][6].ToString();
            }
            catch
            {

            }
        }
    }
}