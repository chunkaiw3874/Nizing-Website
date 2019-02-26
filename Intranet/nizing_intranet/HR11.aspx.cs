﻿using NPOI.HSSF.UserModel;
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

public partial class nizing_intranet_HR11 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = DateTime.Today.Year; i >= 2016; i--)
            {
                ddlYear.Items.Add(i.ToString());
            }
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtGetEmployeeDailyWorkHour = new DataTable();
        GetEmployeeDailyWorkHour(ddlYear.SelectedItem.Text);
    }

    protected DataTable GetEmployeeDailyWorkHour(string year)
    {
        DataTable dt = new DataTable();
        DataTable dtEmployeeList = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "Select LTRIM(RTRIM(MV.MV001))"
+ " From NZ.dbo.CMSMV MV"
+ " WHERE (MV.MV001 NOT LIKE 'PT%'"
+ " AND MV.MV001<>'0000'"
+ " AND MV.MV001<>'0006'"
+ " AND MV.MV001<>'0007'"
+ " AND MV.MV001<>'0098'"
+ " AND ((MV.MV021<=@YEAR+'1231' AND MV.MV022='')"
+ " OR (MV.MV021<=@YEAR+'1231' AND MV.MV022>@YEAR+'1231')))";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtEmployeeList);
        }
        dt.Columns.Add("年份");
        dt.Columns.Add("員工編號");
        dt.Columns.Add("員工姓名");
        dt.Columns.Add("應出勤時數");
        
        for (int i = 0; i < dtEmployeeList.Rows.Count; i++)
        {
            string query = ";WITH WORK_DURATION"
+ " AS"
+ " ("
+ " SELECT MK.MK001 'SHIFT_TYPE',"
+ " CASE"
+ " WHEN MK.MK004 < MK.MK003 THEN"
+ "     CASE"
+ "     WHEN LEN(CAST((CAST(MK.MK004 AS INT)+2400- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(4))) < 3 THEN     "
+ "     LEFT(RIGHT('0000'+CAST((CAST(MK.MK004 AS INT)+2400- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(3)),3),LEN(RIGHT('0000'+CAST((CAST(MK.MK004 AS INT)+2400- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(3)),3))-2)"
+ " 	+':'"
+ " 	+RIGHT(RIGHT('0000'+CAST((CAST(MK.MK004 AS INT)+2400- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(3)),3),2)"
+ "     ELSE"
+ "     LEFT(CAST((CAST(MK.MK004 AS INT)+2400-CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(4)),LEN(CAST((CAST(MK.MK004 AS INT)+2400-CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(4)))-2)"
+ " 	+':'"
+ " 	+RIGHT(CAST((CAST(MK.MK004 AS INT)+2400-CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS VARCHAR(4)),2)"
+ "     END "
+ " ELSE"
+ "     CASE"
+ "     WHEN LEN(CAST((CAST(MK.MK004 AS INT)- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(4))) < 3 THEN    "
+ "     LEFT(RIGHT('0000'+CAST((CAST(MK.MK004 AS INT)- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(3)),3),LEN(RIGHT('0000'+CAST((CAST(MK.MK004 AS INT)- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(3)),3))-2)"
+ " 	+':'"
+ " 	+RIGHT(RIGHT('0000'+CAST((CAST(MK.MK004 AS INT)- CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(3)),3),2)"
+ "     ELSE"
+ " 	CAST(LEFT(CAST((CAST(MK.MK004 AS INT)-CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(4)),LEN(CAST((CAST(MK.MK004 AS INT)-CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS NVARCHAR(4)))-2)"
+ " 	+':'"
+ " 	+RIGHT(CAST((CAST(MK.MK004 AS INT)-CAST(MK.MK003 AS INT))-(CAST(MK010 AS INT)-CAST(MK009 AS INT)) AS VARCHAR(4)),2) AS TIME)"
+ " 	END"
+ " END 'FULL_DAY_WORK_DURATION'"
+ " FROM PALMK MK"
+ " )"
+ " , SHIFT_DURATION"
+ " AS"
+ " ("
+ " SELECT SHIFT_TYPE,CAST(DATEPART(HOUR,FULL_DAY_WORK_DURATION)+DATEPART(MINUTE,FULL_DAY_WORK_DURATION)/60.0 AS DECIMAL(4,2)) '工作時數'"
+ " FROM WORK_DURATION"
+ " )"
+ " SELECT MB.MB001,MV.MV002,MB.MB002"
+ " , CASE "
+ "     WHEN ISDATE(MB.MB002+'01')=1 AND (MB.MB002+'01')>=MV.MV021 THEN"
+ " 	    CASE MP01.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD01.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數01'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'02')=1 AND (MB.MB002+'02')>=MV.MV021 THEN"
+ " 	    CASE MP02.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD02.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數02'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'03')=1 AND (MB.MB002+'03')>=MV.MV021 THEN"
+ " 	    CASE MP03.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD03.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數03'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'04')=1 AND (MB.MB002+'04')>=MV.MV021 THEN"
+ " 	    CASE MP04.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD04.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數04'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'05')=1 AND (MB.MB002+'05')>=MV.MV021 THEN"
+ " 	    CASE MP05.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD05.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數05'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'06')=1 AND (MB.MB002+'06')>=MV.MV021 THEN"
+ " 	    CASE MP06.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD06.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數06'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'07')=1 AND (MB.MB002+'07')>=MV.MV021 THEN"
+ " 	    CASE MP07.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD07.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數07'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'08')=1 AND (MB.MB002+'08')>=MV.MV021 THEN"
+ " 	    CASE MP08.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD08.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數08'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'09')=1 AND (MB.MB002+'09')>=MV.MV021 THEN"
+ " 	    CASE MP09.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD09.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數09'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'10')=1 AND (MB.MB002+'10')>=MV.MV021 THEN"
+ " 	    CASE MP10.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD10.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數10'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'11')=1 AND (MB.MB002+'11')>=MV.MV021 THEN"
+ " 	    CASE MP11.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD11.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數11'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'12')=1 AND (MB.MB002+'12')>=MV.MV021 THEN"
+ " 	    CASE MP12.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD12.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數12'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'13')=1 AND (MB.MB002+'13')>=MV.MV021 THEN"
+ " 	    CASE MP13.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD13.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數13'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'14')=1 AND (MB.MB002+'14')>=MV.MV021 THEN"
+ " 	    CASE MP14.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD14.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數14'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'15')=1 AND (MB.MB002+'15')>=MV.MV021 THEN"
+ " 	    CASE MP15.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD15.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數15'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'16')=1 AND (MB.MB002+'16')>=MV.MV021 THEN"
+ " 	    CASE MP16.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD16.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數16'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'17')=1 AND (MB.MB002+'17')>=MV.MV021 THEN"
+ " 	    CASE MP17.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD17.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數17'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'18')=1 AND (MB.MB002+'18')>=MV.MV021 THEN"
+ " 	    CASE MP18.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD18.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數18'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'19')=1 AND (MB.MB002+'19')>=MV.MV021 THEN"
+ " 	    CASE MP19.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD19.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數19'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'20')=1 AND (MB.MB002+'20')>=MV.MV021 THEN"
+ " 	    CASE MP20.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD20.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數20'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'21')=1 AND (MB.MB002+'21')>=MV.MV021 THEN"
+ " 	    CASE MP21.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD21.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數21'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'22')=1 AND (MB.MB002+'22')>=MV.MV021 THEN"
+ " 	    CASE MP22.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD22.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數22'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'23')=1 AND (MB.MB002+'23')>=MV.MV021 THEN"
+ " 	    CASE MP23.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD23.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數23'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'24')=1 AND (MB.MB002+'24')>=MV.MV021 THEN"
+ " 	    CASE MP24.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD24.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數24'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'25')=1 AND (MB.MB002+'25')>=MV.MV021 THEN"
+ " 	    CASE MP25.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD25.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數25'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'26')=1 AND (MB.MB002+'26')>=MV.MV021 THEN"
+ " 	    CASE MP26.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD26.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數26'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'27')=1 AND (MB.MB002+'27')>=MV.MV021 THEN"
+ " 	    CASE MP27.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD27.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數27'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'28')=1 AND (MB.MB002+'28')>=MV.MV021 THEN"
+ " 	    CASE MP28.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD28.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數28'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'29')=1 AND (MB.MB002+'29')>=MV.MV021 THEN"
+ " 	    CASE MP29.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD29.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數29'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'30')=1 AND (MB.MB002+'30')>=MV.MV021 THEN"
+ " 	    CASE MP30.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD30.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數30'"
+ " ,CASE "
+ "     WHEN ISDATE(MB.MB002+'31')=1 AND (MB.MB002+'31')>=MV.MV021 THEN"
+ " 	    CASE MP31.MP005"
+ " 		WHEN 1 THEN 0"
+ " 		ELSE SD31.工作時數"
+ " 		END"
+ " 	ELSE 0"
+ " END AS '工作時數31'"
+ " FROM AMSMB MB"
+ " LEFT JOIN CMSMV MV ON MB.MB001=MV.MV001"
+ " LEFT JOIN CMSMP MP01 ON MP01.MP004=MB.MB002+'01' AND MB.MB003=MP01.MP003"
+ " LEFT JOIN SHIFT_DURATION SD01 ON MB.MB003=SD01.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP02 ON MP02.MP004=MB.MB002+'02' AND MB.MB003=MP02.MP003"
+ " LEFT JOIN SHIFT_DURATION SD02 ON MB.MB003=SD02.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP03 ON MP03.MP004=MB.MB002+'03' AND MB.MB003=MP03.MP003"
+ " LEFT JOIN SHIFT_DURATION SD03 ON MB.MB003=SD03.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP04 ON MP04.MP004=MB.MB002+'04' AND MB.MB003=MP04.MP003"
+ " LEFT JOIN SHIFT_DURATION SD04 ON MB.MB003=SD04.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP05 ON MP05.MP004=MB.MB002+'05' AND MB.MB003=MP05.MP003"
+ " LEFT JOIN SHIFT_DURATION SD05 ON MB.MB003=SD05.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP06 ON MP06.MP004=MB.MB002+'06' AND MB.MB003=MP06.MP003"
+ " LEFT JOIN SHIFT_DURATION SD06 ON MB.MB003=SD06.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP07 ON MP07.MP004=MB.MB002+'07' AND MB.MB003=MP07.MP003"
+ " LEFT JOIN SHIFT_DURATION SD07 ON MB.MB003=SD07.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP08 ON MP08.MP004=MB.MB002+'08' AND MB.MB003=MP08.MP003"
+ " LEFT JOIN SHIFT_DURATION SD08 ON MB.MB003=SD08.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP09 ON MP09.MP004=MB.MB002+'09' AND MB.MB003=MP09.MP003"
+ " LEFT JOIN SHIFT_DURATION SD09 ON MB.MB003=SD09.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP10 ON MP10.MP004=MB.MB002+'10' AND MB.MB003=MP10.MP003"
+ " LEFT JOIN SHIFT_DURATION SD10 ON MB.MB003=SD10.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP11 ON MP11.MP004=MB.MB002+'11' AND MB.MB003=MP11.MP003"
+ " LEFT JOIN SHIFT_DURATION SD11 ON MB.MB003=SD11.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP12 ON MP12.MP004=MB.MB002+'12' AND MB.MB003=MP12.MP003"
+ " LEFT JOIN SHIFT_DURATION SD12 ON MB.MB003=SD12.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP13 ON MP13.MP004=MB.MB002+'13' AND MB.MB003=MP13.MP003"
+ " LEFT JOIN SHIFT_DURATION SD13 ON MB.MB003=SD13.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP14 ON MP14.MP004=MB.MB002+'14' AND MB.MB003=MP14.MP003"
+ " LEFT JOIN SHIFT_DURATION SD14 ON MB.MB003=SD14.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP15 ON MP15.MP004=MB.MB002+'15' AND MB.MB003=MP15.MP003"
+ " LEFT JOIN SHIFT_DURATION SD15 ON MB.MB003=SD15.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP16 ON MP16.MP004=MB.MB002+'16' AND MB.MB003=MP16.MP003"
+ " LEFT JOIN SHIFT_DURATION SD16 ON MB.MB003=SD16.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP17 ON MP17.MP004=MB.MB002+'17' AND MB.MB003=MP17.MP003"
+ " LEFT JOIN SHIFT_DURATION SD17 ON MB.MB003=SD17.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP18 ON MP18.MP004=MB.MB002+'18' AND MB.MB003=MP18.MP003"
+ " LEFT JOIN SHIFT_DURATION SD18 ON MB.MB003=SD18.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP19 ON MP19.MP004=MB.MB002+'19' AND MB.MB003=MP19.MP003"
+ " LEFT JOIN SHIFT_DURATION SD19 ON MB.MB003=SD19.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP20 ON MP20.MP004=MB.MB002+'20' AND MB.MB003=MP20.MP003"
+ " LEFT JOIN SHIFT_DURATION SD20 ON MB.MB003=SD20.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP21 ON MP21.MP004=MB.MB002+'21' AND MB.MB003=MP21.MP003"
+ " LEFT JOIN SHIFT_DURATION SD21 ON MB.MB003=SD21.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP22 ON MP22.MP004=MB.MB002+'22' AND MB.MB003=MP22.MP003"
+ " LEFT JOIN SHIFT_DURATION SD22 ON MB.MB003=SD22.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP23 ON MP23.MP004=MB.MB002+'23' AND MB.MB003=MP23.MP003"
+ " LEFT JOIN SHIFT_DURATION SD23 ON MB.MB003=SD23.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP24 ON MP24.MP004=MB.MB002+'24' AND MB.MB003=MP24.MP003"
+ " LEFT JOIN SHIFT_DURATION SD24 ON MB.MB003=SD24.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP25 ON MP25.MP004=MB.MB002+'25' AND MB.MB003=MP25.MP003"
+ " LEFT JOIN SHIFT_DURATION SD25 ON MB.MB003=SD25.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP26 ON MP26.MP004=MB.MB002+'26' AND MB.MB003=MP26.MP003"
+ " LEFT JOIN SHIFT_DURATION SD26 ON MB.MB003=SD26.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP27 ON MP27.MP004=MB.MB002+'27' AND MB.MB003=MP27.MP003"
+ " LEFT JOIN SHIFT_DURATION SD27 ON MB.MB003=SD27.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP28 ON MP28.MP004=MB.MB002+'28' AND MB.MB003=MP28.MP003"
+ " LEFT JOIN SHIFT_DURATION SD28 ON MB.MB003=SD28.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP29 ON MP29.MP004=MB.MB002+'29' AND MB.MB003=MP29.MP003"
+ " LEFT JOIN SHIFT_DURATION SD29 ON MB.MB003=SD29.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP30 ON MP30.MP004=MB.MB002+'30' AND MB.MB003=MP30.MP003"
+ " LEFT JOIN SHIFT_DURATION SD30 ON MB.MB003=SD30.SHIFT_TYPE"
+ " LEFT JOIN CMSMP MP31 ON MP31.MP004=MB.MB002+'31' AND MB.MB003=MP31.MP003"
+ " LEFT JOIN SHIFT_DURATION SD31 ON MB.MB003=SD31.SHIFT_TYPE"
+ " WHERE MB.MB002 BETWEEN @YEAR+@BEGINMONTH AND @YEAR+@ENDMONTH"
+ " AND MB.MB001=@EMPLOYEEID"
+ " ORDER BY MB.MB002";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {

            }
        }

        return dt;
    }
}