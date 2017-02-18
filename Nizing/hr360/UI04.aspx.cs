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

public partial class hr360_UI04 : System.Web.UI.Page
{
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    List<dayOffInfo> lstDayOffAppSummary = new List<dayOffInfo>();

    public class dayOffInfo
    {
        public string typeName { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public string unit { set; get; }
        public string amountUsing { set; get; }
        public string amountRemain { set; get; }
        public string funcSub { set; get; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["erp_id"] = "0011"; //test only to avoid error on loading, delete after trial

            hdnIsPostBack.Value = "0";  //variable for determining whether this page is a postback for jquery
            hdnIsDayOffAppVisible.Value = "0";  //variable for determining whether the div DayOffApp is visible
            DataSet ds = new DataSet();
            DataTable userInfo = new DataTable();
            string query = "";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                query = "SELECT MV.MV007,MV004"  //獲取登入者資料
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
                        + " AND PALMC.MC001<>'08'"
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
                da.Fill(ds, "Day Off Type");
                //抓取跟登入者同部門的人
                query = "SELECT MV.MV001+' '+MV002,MV001"
                    + " FROM CMSMV MV"
                    + " WHERE MV.MV004=@DEPT"
                    + " AND MV.MV001<>@ID"
                    + " AND MV.MV022=''"
                    + " ORDER BY MV.MV001";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DEPT", userInfo.Rows[0][1].ToString().Trim());
                cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString().Trim());
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Functional Substitute");
            }
            ddlDayOffType.Items.Add(new ListItem("請選擇假別", "0"));
            ddlDayOffType.SelectedIndex = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlDayOffType.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString().Trim(), ds.Tables[0].Rows[i][1].ToString().Trim()));
            }
            for (int i = 0; i < 24; i++)
            {
                ddlDayOffStartHour.Items.Add(i.ToString("D2"));
                ddlDayOffStartHour.SelectedIndex = 8;
                ddlDayOffEndHour.Items.Add(i.ToString("D2"));
                ddlDayOffEndHour.SelectedIndex = 17;
            }
            for (int i = 0; i < 60; i += 30)
            {
                ddlDayOffStartMin.Items.Add(i.ToString("D2"));
                ddlDayOffEndMin.Items.Add(i.ToString("D2"));
            }
            //還需要代理人是否eligible for代理的篩選條件
            ddlDayOffFuncSub.Items.Add(new ListItem("請選擇代理人", "0"));
            ddlDayOffFuncSub.SelectedIndex = 0;
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                ddlDayOffFuncSub.Items.Add(new ListItem(ds.Tables[1].Rows[i][0].ToString().Trim(), ds.Tables[1].Rows[i][1].ToString().Trim()));
            }
        }
        else
        {
            hdnIsPostBack.Value = "1";
        }

        if (Session["erp_id"] == "0010")  //hidden field that contains normal work hour per day for current user
        {
            hdnNormalWorkHour.Value = "8.5";
        }
        else
        {
            hdnNormalWorkHour.Value = "8";
        }
    }

    protected void btnDayOffAdd_Click(object sender, ImageClickEventArgs e)
    {
        //lblTest.Text = ((ImageButton)sender).ID + " clicked";
        List<string> errorList = new List<string>();
        DateTime result = new DateTime();
        DateTime dayOffStartTime = new DateTime();
        DateTime dayOffEndTime = new DateTime();
        Boolean test1 = false;
        Boolean test2 = false;
        Boolean test3 = false;
        Boolean test4 = false;
        Boolean test8 = false;
        DataTable dtDayOffDaysInfo = new DataTable();
        decimal totalDayOffAmount = 0;

        txtErrorMessage.Text = ""; //reset 錯誤訊息

        if (ddlDayOffType.SelectedValue == "0")  //測試錯誤 1.未選擇假別
        {
            errorList.Add(errorCode(1));
            test1 = false;
        }
        else
        {
            test1 = true;
        }
        if (DateTime.TryParse(txtDatePickerStart.Text.Trim(), out result))  //測試錯誤 2.起始日期輸入錯誤
        {
            dayOffStartTime = result.Date.AddHours(Convert.ToInt16(ddlDayOffStartHour.SelectedValue)).AddMinutes(Convert.ToInt16(ddlDayOffStartMin.SelectedValue));
            test2 = true;
        }
        else
        {
            errorList.Add(errorCode(2));
            test2 = false;
        }
        if (DateTime.TryParse(txtDatePickerEnd.Text.Trim(), out result))  //測試錯誤 3.結束日期輸入錯誤
        {
            dayOffEndTime = result.Date.AddHours(Convert.ToInt16(ddlDayOffEndHour.SelectedValue)).AddMinutes(Convert.ToInt16(ddlDayOffEndMin.SelectedValue));
            test3 = true;
        }
        else
        {
            errorList.Add(errorCode(3));
            test3 = false;
        }
        if (dayOffEndTime < dayOffStartTime)  //測試錯誤 4.結束日期小於開始日期
        {
            errorList.Add(errorCode(4));
            test4 = false;
        }
        else
        {
            test4 = true;
        }
        if (ddlDayOffFuncSub.SelectedValue == "0")  //測試錯誤 8.未選擇代理人
        {
            errorList.Add(errorCode(8));
            test8 = false;
        }
        else
        {
            test8 = true;
        }
        if (test1 && test2 && test3 && test4 && test8)  //PASS ALL INPUT TESTS, NEED TO START CALCULATING FOR OTHER ERRORS
        {
            DateTime[] days = GetDatesBetween(dayOffStartTime, dayOffEndTime);
            for (int i = 0; i < days.Length; i++)
            {
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    string query = "SELECT MP.MP004 '日期',MP.MP005 '放假'," + "MB.MB0" + (Convert.ToInt16(days[i].Day.ToString()) + 2).ToString("D2") + " '班別',CONVERT(TIME,STUFF(MK.MK003,3,0,':')) '上班時間',CONVERT(TIME,STUFF(MK.MK004,3,0,':'))  '下班時間'"
                            + " ,CONVERT(TIME,STUFF(MK.MK009,3,0,':')) '休息開始時間',CONVERT(TIME,STUFF(MK.MK010,3,0,':')) '休息結束時間'"
                            + " ,CASE"
                            + " WHEN MK.MK003>MK.MK004 THEN 24.0-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,'00:00'),CONVERT(TIME,STUFF('1700', 3, 0, ':')))/60.0)+CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,'00:00'),CONVERT(TIME,STUFF('0100',3,0,':')))/60.0)-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK009, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK010, 3, 0, ':')))/60.0)"
                            + " ELSE CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK003, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK004, 3, 0, ':')))/60.0)-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK009, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK010, 3, 0, ':')))/60.0)"
                            + " END '工作時數'"
                            + " FROM AMSMB MB"
                            + " LEFT JOIN CMSMP MP ON MP.MP001='3' AND MP.MP004=@YYYYMMDD AND MP.MP003=" + "MB.MB0" + (Convert.ToInt16(days[i].Day.ToString()) + 2).ToString("D2")
                            + " LEFT JOIN PALMK MK ON MB.MB007=MK.MK001"
                            + " WHERE MB.MB001=@ID"
                            + " AND MB.MB002=@YYYYMM";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@SHIFT", "MB.MB0" + (Convert.ToInt16(days[i].Day.ToString()) + 2).ToString("D2"));
                    cmd.Parameters.AddWithValue("@YYYYMMDD", days[i].ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YYYYMM", days[i].ToString("yyyyMM"));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtDayOffDaysInfo.Load(dr);
                    }
                    //fill in null cells with desired data
                    if (dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][0].ToString() == "")
                    {
                        dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][0] = days[i].ToString("yyyyMMdd");
                    }
                    if (dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][1].ToString() == "")
                    {
                        dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][1] = "3";
                    }
                }
            }
            for (int i = 0; i < dtDayOffDaysInfo.Rows.Count; i++)  //calculating total hours of dayoff
            {
                if (dtDayOffDaysInfo.Rows[i][1].ToString() == "3")  //3 is working day
                {
                    TimeSpan timeDifference = new TimeSpan();
                    DateTime workEndTime = new DateTime();
                    DateTime workStartTime = new DateTime();
                    DateTime breakStartTime = new DateTime();
                    DateTime breakEndTime = new DateTime();
                    workStartTime = new DateTime(Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(0, 4)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(4, 2)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(6, 2)));
                    workStartTime = workStartTime.AddHours(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][3].ToString().Substring(0, 2))).AddMinutes(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][3].ToString().Substring(3, 2)));
                    breakStartTime = new DateTime(Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(0, 4)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(4, 2)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(6, 2)));
                    breakStartTime = breakStartTime.AddHours(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][5].ToString().Substring(0, 2))).AddMinutes(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][5].ToString().Substring(3, 2)));
                    breakEndTime = new DateTime(Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(0, 4)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(4, 2)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(6, 2)));
                    breakEndTime = breakEndTime.AddHours(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][6].ToString().Substring(0, 2))).AddMinutes(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][6].ToString().Substring(3, 2)));

                    if (Convert.ToDateTime(dtDayOffDaysInfo.Rows[i][4].ToString()) < Convert.ToDateTime(dtDayOffDaysInfo.Rows[i][3].ToString()))  //班別持續至次日
                    {
                        workEndTime = new DateTime(Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(0, 4)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(4, 2)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(6, 2)));
                        workEndTime = workEndTime.AddDays(1).AddHours(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][4].ToString().Substring(0, 2))).AddMinutes(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][4].ToString().Substring(3, 2)));
                    }
                    else
                    {
                        workEndTime = new DateTime(Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(0, 4)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(4, 2)), Convert.ToInt16(dtDayOffDaysInfo.Rows[i][0].ToString().Substring(6, 2)));
                        workEndTime = workEndTime.AddHours(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][4].ToString().Substring(0, 2))).AddMinutes(Convert.ToDouble(dtDayOffDaysInfo.Rows[i][4].ToString().Substring(3, 2)));
                    }

                    if (i == 0)  //first day and last day require special calculation for partial days
                    {
                        if (dtDayOffDaysInfo.Rows.Count == 1)
                        {
                            if (dayOffEndTime < workEndTime)
                            {
                                workEndTime = dayOffEndTime;
                            }
                        }
                        if (dayOffStartTime > workStartTime)
                        {
                            workStartTime = dayOffStartTime;
                        }
                        if (dayOffStartTime < breakEndTime)
                        {
                            TimeSpan temp = breakEndTime - dayOffStartTime;
                            if (temp.Hours > 0)
                            {
                                timeDifference = (workEndTime - workStartTime).Subtract(TimeSpan.FromHours((breakEndTime - breakStartTime).Hours));
                            }
                            else
                            {
                                timeDifference = (workEndTime - workStartTime).Subtract(TimeSpan.FromMinutes(temp.Minutes));
                            }
                        }
                        else
                        {
                            timeDifference = workEndTime - workStartTime;
                        }
                        totalDayOffAmount += (timeDifference.Hours + Convert.ToDecimal(timeDifference.Minutes / 60.0));
                    }
                    else if (i == dtDayOffDaysInfo.Rows.Count - 1 && i != 0)  //last day, and last day and first day are not the same day (ie day off time span is within 1 day)
                    {
                        if (dayOffEndTime < workEndTime)
                        {
                            workEndTime = dayOffEndTime;
                        }
                        if (dayOffEndTime > breakStartTime)
                        {
                            TimeSpan temp = dayOffEndTime - breakStartTime;
                            if (temp.Hours > 0)
                            {
                                timeDifference = (workEndTime - workStartTime).Subtract(TimeSpan.FromHours((breakEndTime - breakStartTime).Hours));
                            }
                            else
                            {
                                timeDifference = (workEndTime - workStartTime).Subtract(TimeSpan.FromMinutes(temp.Minutes));
                            }
                        }
                        else
                        {
                            timeDifference = workEndTime - workStartTime;
                        }
                        totalDayOffAmount += (timeDifference.Hours + Convert.ToDecimal(timeDifference.Minutes / 60.0));
                    }
                    else
                    {
                        totalDayOffAmount += Convert.ToDecimal(dtDayOffDaysInfo.Rows[i][7]);
                    }
                }
            }
            if (hdnDayOffTypeUnit.Value == "天")
            {
                hdnTotalDayOffTime.Value = (totalDayOffAmount / Convert.ToDecimal(hdnNormalWorkHour.Value)).ToString();
            }
            else
            {
                hdnTotalDayOffTime.Value = totalDayOffAmount.ToString();
            }
            lblTest.Text = hdnTotalDayOffTime.Value + hdnDayOffTypeUnit.Value;
            if (totalDayOffAmount <= 0)  //測試錯誤 5.請假週期的須請假總時數為0，無須請假
            {
                errorList.Add(errorCode(5));
            }
            if (lblDayOffRemainAmount.Text.Trim() != "")  //測試錯誤 6.剩餘假期不足  --如假別無量的限制，則無需執行此測試
            {
                if (totalDayOffAmount > Convert.ToDecimal(lblDayOffRemainAmount.Text))
                {
                    errorList.Add(errorCode(6));
                }
            }
            if (Convert.ToDecimal(hdnTotalDayOffTime.Value) * 10 % 5 != 0)  //測試錯誤 7.請假單位為0.5
            {
                errorList.Add(errorCode(7));
            }
        }

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

        if (errorList.Count == 0) //都沒有錯誤，可執行之後的步驟
        {
            if (lblDayOffRemainAmount.Text == "")
            {
                lstDayOffAppSummary.Add(new dayOffInfo
                {
                    typeName = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim()
                    ,
                    startTime = dayOffStartTime
                    ,
                    endTime = dayOffEndTime
                    ,
                    unit = hdnDayOffTypeUnit.Value
                    ,
                    amountUsing = hdnTotalDayOffTime.Value + hdnDayOffTypeUnit.Value
                    ,
                    amountRemain = "N/A"
                    ,
                    funcSub = ddlDayOffFuncSub.SelectedItem.ToString().Trim()
                });


            }
            lstDayOffAppSummary.Add(new dayOffInfo
            {
                typeName = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim()
                ,
                startTime = dayOffStartTime
                ,
                endTime = dayOffEndTime
                ,
                unit = hdnDayOffTypeUnit.Value
                ,
                amountUsing = hdnTotalDayOffTime.Value + hdnDayOffTypeUnit.Value
                ,
                amountRemain = (Convert.ToDecimal(lblDayOffRemainAmount.Text) - Convert.ToDecimal(hdnTotalDayOffTime.Value)).ToString() + hdnDayOffTypeUnit.Value
                ,
                funcSub = ddlDayOffFuncSub.SelectedItem.ToString().Trim()
            });
            lblTest.Text = "no errors! v^.^v";
        }
    }
    /// <summary>
    /// 選擇假別改變，如有設定，會讀取該假別剩餘時數
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDayOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //顯示選擇假別剩餘時數            
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
            lblDayOffRemainType.Text = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim() + "剩餘";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                query = "SELECT '02' 'ID',CONVERT(DECIMAL(5,2),TK.TK005),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)),'小時'"
                    + " FROM PALTK TK"
                    + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='02'"
                    + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                    + " GROUP BY TK.TK005"
                    + " UNION"
                    + " SELECT '03' 'ID',CONVERT(DECIMAL(5,2),TK.TK003*" + hdnNormalWorkHour.Value + "),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)),'小時'"
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

                //未選擇、婚假、陪產假、產檢假、產假 並非每年都有的假，所以忽略假期天數的限制，由人事檢查
                if (ddlDayOffType.SelectedValue.ToString() == "06" || ddlDayOffType.SelectedValue.ToString() == "09"
                    || ddlDayOffType.SelectedValue.ToString() == "15" || ddlDayOffType.SelectedValue.ToString() == "08")
                {
                    lblDayOffRemainType.Text = "";
                    lblDayOffRemainAmount.Text = "";
                    lblDayOffRemainUnit.Text = "";
                    if (Convert.ToDouble(row[0][1]) > 0)
                    {
                        hdnDayOffTypeUnit.Value = row[0][3].ToString();
                    }
                }
                else
                {
                    if (Convert.ToDouble(row[0][1]) > 0)
                    {
                        lblDayOffRemainAmount.Text = (Convert.ToDouble(row[0][1]) - Convert.ToDouble(row[0][2])).ToString();
                        lblDayOffRemainUnit.Text = row[0][3].ToString();
                        hdnDayOffTypeUnit.Value = row[0][3].ToString();
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
        else if (errorID == 5)
        {
            error = "此請假週期非上班時間，無須請假";
        }
        else if (errorID == 6)
        {
            error = "剩餘假期不足";
        }
        else if (errorID == 7)
        {
            error = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim() + "請假單位為0.5" + hdnDayOffTypeUnit.Value;
        }
        else if (errorID == 8)
        {
            error = "未選擇代理人";
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
        {
            allDates.Add(date);
        }
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