﻿using System;
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

public partial class hr360_UI04 : System.Web.UI.Page
{
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["erp_id"] = "0010"; //test only to avoid error on loading, delete after trial


            hdnIsPostBack.Value = "0";  //variable for determining whether this page is a postback for jquery
            hdnIsDayOffAppVisible.Value = "0";  //variable for determining whether the div DayOffApp is visible
            DataTable dt = new DataTable();
            DataTable userInfo = new DataTable();
            string query = "";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                query = "SELECT MV.MV007"  //獲取登入者性別
                    + " FROM CMSMV MV"
                    + " WHERE MV001=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString().Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(userInfo);
                if (userInfo.Rows[0][0].ToString() == "1")  //性別為男性，不可用產檢假
                {
                    query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                        + " FROM PALMC"
                        + " WHERE PALMC.MC001<>'15'"
                        + " ORDER BY PALMC.MC001";
                }
                else
                {
                    query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                        + " FROM PALMC"
                        + " ORDER BY PALMC.MC001";
                }
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);                
            }
            ddlDayOffType.Items.Add(new ListItem("請選擇假別", "0"));
            ddlDayOffType.SelectedIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlDayOffType.Items.Add(new ListItem(dt.Rows[i][0].ToString().Trim(), dt.Rows[i][1].ToString().Trim()));
            }
            for (int i = 0; i < 24; i++)
            {
                ddlDayOffStartHour.Items.Add(i.ToString("D2"));
                ddlDayOffStartHour.SelectedIndex = 8;
                ddlDayOffEndHour.Items.Add(i.ToString("D2"));
                ddlDayOffEndHour.SelectedIndex = 8;
            }
            for (int i = 0; i < 60; i += 30)
            {
                ddlDayOffStartMin.Items.Add(i.ToString("D2"));
                ddlDayOffEndMin.Items.Add(i.ToString("D2"));
            }
        }
        else
        {
            hdnIsPostBack.Value = "1";
        }
    }
    protected void btnDayOffAdd_Click(object sender, ImageClickEventArgs e)
    {
        //lblTest.Text = ((ImageButton)sender).ID + " clicked";
        List<string> errorList = new List<string>();
        DateTime result = new DateTime();
        DateTime dayOffStartTime = new DateTime();
        DateTime dayOffEndTime = new DateTime();
        txtErrorMessage.Text = ""; //reset 錯誤訊息

        if (ddlDayOffType.SelectedValue == "0")  //測試錯誤 1.未選擇假別
        {
            errorList.Add(errorCode(1));
        }
        if (DateTime.TryParse(txtDatePickerStart.Text.Trim(), out result))  //測試錯誤 2.起始日期輸入錯誤
        {
            dayOffStartTime = result.Date.AddHours(Convert.ToInt16(ddlDayOffStartHour.SelectedValue)).AddMinutes(Convert.ToInt16(ddlDayOffStartMin.SelectedValue));
        }
        else
        {
            errorList.Add(errorCode(2));
        }
        if (DateTime.TryParse(txtDatePickerEnd.Text.Trim(), out result))  //測試錯誤 3.結束日期輸入錯誤
        {
            dayOffEndTime = result.Date.AddHours(Convert.ToInt16(ddlDayOffEndHour.SelectedValue)).AddMinutes(Convert.ToInt16(ddlDayOffEndMin.SelectedValue));
        }
        else
        {
            errorList.Add(errorCode(3));
        }
        if (dayOffEndTime < dayOffStartTime)  //測試錯誤 4.結束日期小於開始日期
        {
            errorList.Add(errorCode(4));
        }
        if (lblDayOffRemainAmount.Text.Trim() != "")  //測試錯誤 5.剩餘假期不足
        {
            if (DateTime.TryParse(txtDatePickerStart.Text.Trim(), out result) && DateTime.TryParse(txtDatePickerEnd.Text.Trim(), out result))
            {

            }

        }
        //lblTest.Text = dayOffStartTime.ToString("yyyyMMdd");

        //錯誤訊息集合顯示
        for (int i = 0; i < errorList.Count; i++)
        {
            if (i == 0)
            {
                txtErrorMessage.Text = errorList[i];
            }
            else
            {
                txtErrorMessage.Text += Environment.NewLine + errorList[i];
            }
        }
    }
    /// <summary>
    /// 選擇假別改變
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDayOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ///顯示選擇假別剩餘時數
        if (ddlDayOffType.SelectedValue.ToString() == "0")
        {
            lblDayOffRemainType.Text = "";
            lblDayOffRemainAmount.Text = "";
            lblDayOffRemainUnit.Text = "";
        }
        else
        {
            DataTable dt = new DataTable();
            string query = "";
            string dayOffHourById = "";
            lblDayOffRemainType.Text = "本年度" + ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3) + "剩餘";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                if (Session["erp_id"].ToString().Trim() == "0010")
                {
                    dayOffHourById = "8.5";
                }
                else
                {
                    dayOffHourById = "8";
                }
                query = "SELECT '02' 'ID',CONVERT(DECIMAL(5,2),TK.TK005),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)),'小時'"
                    + " FROM PALTK TK"
                    + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='02'"
                    + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                    + " GROUP BY TK.TK005"
                    + " UNION"
                    + " SELECT '03' 'ID',CONVERT(DECIMAL(5,2),TK.TK003*" + dayOffHourById + "),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)),'小時'"
                    + " FROM PALTK TK"
                    + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='03'"
                    + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                    + " GROUP BY TK.TK003"
                    + " UNION"
                    + " SELECT MC.MC001 'ID',CONVERT(DECIMAL(5,2),MC.MC007),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0))"
                    + " ,CASE MC.MC004"
                    + " WHEN '1' THEN '天'"
                    + " WHEN '2' THEN '小時'"
                    + " END"
                    + " FROM PALMC MC"
                    + " LEFT JOIN PALTL TL ON TL.TL001=@ID AND TL.TL002=@YEAR AND TL.TL004=MC.MC001"
                    + " WHERE MC.MC001<>'02' AND MC.MC001<>'03'"
                    + " GROUP BY MC.MC001,MC.MC007,MC.MC004";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString().Trim());
                cmd.Parameters.AddWithValue("@YEAR", DateTime.Now.Year.ToString().Trim());
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
            }
            DataRow[] row;
            if (dt.Rows.Count > 0)
            {
                row = dt.Select("ID=" + ddlDayOffType.SelectedValue.ToString());

                if (Convert.ToDouble(row[0][1]) > 0)
                {
                    lblDayOffRemainAmount.Text = (Convert.ToDouble(row[0][1]) - Convert.ToDouble(row[0][2])).ToString();
                    lblDayOffRemainUnit.Text = row[0][3].ToString();
                }
                else
                {
                    lblDayOffRemainType.Text = "";
                    lblDayOffRemainAmount.Text = "";
                    lblDayOffRemainUnit.Text = "";
                }
            }
        }
        
    }

    protected string errorCode(int errorID)
    {
        string error = "";
        if (errorID == 1)
        {
            error = "未選擇假別";
        }
        else if (errorID == 2)
        {
            error = "起始日期輸入錯誤(格式範例 2017/03/04)";
        }
        else if (errorID == 3)
        {
            error = "結束日期輸入錯誤(格式範例 2017/04/27)";
        }
        else if (errorID == 4)
        {
            error = "結束日期不可小於起始日期";
        }
        return error;
    }

    /// <summary>
    /// Parse a range of date into individual dates
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    protected DateTime[] GetDatesBetween(DateTime startDate, DateTime endDate)
    {
        List<DateTime> allDates = new List<DateTime>();
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            allDates.Add(date);
        return allDates.ToArray();
    }

    /// <summary>
    /// test only for different IDs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTestName_Click(object sender, EventArgs e)
    {
        Session["erp_id"] = txtTestName.Text.Trim();
        lblTest.Text = "測試帳號" + txtTestName.Text.Trim();
    }
}