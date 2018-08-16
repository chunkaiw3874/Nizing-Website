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

public partial class nizing_intranet_HR10 : System.Web.UI.Page
{
    string stoneaxConnectionString = ConfigurationManager.ConnectionStrings["StoneaxConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dtAll = ds.Tables.Add();
        DateTime searchStartTime = new DateTime();
        DateTime searchEndTime = new DateTime();
        DateTime result = new DateTime();
        List<string> userIndex = new List<string>();

        if (DateTime.TryParse(txtDatePickerStart.Text.Trim(), out result))
        {
            searchStartTime = result;
        }
        if (DateTime.TryParse(txtDatePickerEnd.Text.Trim(), out result))
        {
            searchEndTime = result;
        }
        using (SqlConnection conn = new SqlConnection(stoneaxConnectionString))
        {
            conn.Open();
            string query = "CREATE TABLE #WORKTIMERECORD(RecordDate NVARCHAR(10), UserIndex Nvarchar(10), UserName Nvarchar(10), FirstRecordTime time, LastRecordTime time)"
                        + " DECLARE @CURRENTUSERINDEX NVARCHAR(10)"
                        + " DECLARE USERINDEX_CURSOR CURSOR FOR"
                        + " SELECT DISTINCT(UserIndex)"
                        + " FROM Record"
                        + " WHERE RecordTime >= @STARTDATE AND RecordTime < @ENDDATE"
                        + " ORDER BY UserIndex"
                        + " WHILE (@STARTDATE < @ENDDATE)"
                        + " BEGIN"
                        + " 	OPEN USERINDEX_CURSOR"
                        + " 	FETCH NEXT FROM USERINDEX_CURSOR"
                        + " 	INTO @CURRENTUSERINDEX"
                        + " 	WHILE @@FETCH_STATUS=0"
                        + " 	BEGIN"
                        + " 		INSERT INTO #WORKTIMERECORD"
                        + " 		SELECT DISTINCT CONVERT(NVARCHAR(10),RecordTime,111), UserIndex, UserName"
                        + " 		, (SELECT MIN(CAST(RecordTime AS Time)) FROM Record"
                        + " 		WHERE UserIndex=@CURRENTUSERINDEX"
                        + " 		AND CAST(RecordTime AS DATE) >= @STARTDATE"
                        + " 		AND CAST(RecordTime AS DATE) < DATEADD(DAY,1,@STARTDATE))"
                        + " 		,(SELECT MAX(CAST(RecordTime AS Time)) FROM Record"
                        + " 		WHERE UserIndex=@CURRENTUSERINDEX"
                        + " 		AND CAST(RecordTime AS DATE) >= @STARTDATE"
                        + " 		AND CAST(RecordTime AS DATE) < DATEADD(DAY,1,@STARTDATE))"
                        + " 		FROM Record"
                        + " 		WHERE UserIndex=@CURRENTUSERINDEX"
                        + " 		AND CAST(RecordTime AS DATE) >= @STARTDATE"
                        + " 		AND CAST(RecordTime AS DATE) < DATEADD(DAY,1,@STARTDATE)"
                        + " 		GROUP BY RecordTime,UserIndex,UserName,EventTypeIndex"
                        + " 		FETCH NEXT FROM USERINDEX_CURSOR"
                        + " 		INTO @CURRENTUSERINDEX"
                        + " 	END"
                        + " 	CLOSE USERINDEX_CURSOR	"
                        + " 	SET @STARTDATE=DATEADD(DAY,1,@STARTDATE)"
                        + " END"
                        + " SELECT *"
                        + " FROM #WORKTIMERECORD"
                        + " ORDER BY UserIndex,RecordDate";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@STARTDATE", searchStartTime);
            cmd.Parameters.AddWithValue("@ENDDATE", searchEndTime.AddDays(1));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables[0]);
        }
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            userIndex.Add(row["UserIndex"])
        }
        gvResult.DataSource = ds.Tables[0];
        
        gvResult.DataBind();
    }
}