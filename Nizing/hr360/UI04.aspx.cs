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
    DataTable userInfo = new DataTable(); 

    public class dayOffInfo
    {
        public string typeID { set; get; }
        public string typeName { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public string unit { set; get; }
        public string amountUsing { set; get; }
        public string restrictedAmountSet { set; get; }
        public string funcSub { set; get; }
        public string reason { set; get; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["erp_id"] = "0094"; //test only to avoid error on loading, delete after trial
            ApplicationSection_Init_Load();
            InProgressSection_Init_Load();
            ApprovalSection_Init_Load();
        }
        else
        {
            ApplicationSection_PostBack_Load();
            InProgressSection_PostBack_Load();
            ApprovalSection_PostBack_Load();
        }

        //hidden field that contains normal work hour per day for current user
        if (Session["erp_id"].ToString() == "0010")  //小倩8.5hr/day
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
        List<string> errorList = new List<string>();
        DateTime result = new DateTime();
        DateTime dayOffStartTime = new DateTime();  //申請開始請假時間
        DateTime dayOffEndTime = new DateTime();  //申請結束請假時間
        DateTime workEndTime = new DateTime();  //請假週期內，每日工作開始時間
        DateTime workStartTime = new DateTime();  //請假週期內，每日工作結束時間
        DateTime breakStartTime = new DateTime();  //請假週期內，每日休息開始時間
        DateTime breakEndTime = new DateTime();  //請假週期內，每日休息結束時間        
        bool test101 = false;
        bool test102 = false;
        bool test103 = false;
        bool test104 = false;
        bool test105 = false;
        bool test106 = false;
        bool test107 = false;
        bool test108 = false;
        bool test204 = false;
        DataTable dtDayOffDaysInfo = new DataTable();
        decimal totalDayOffAmount = 0;     
        
        txtErrorMessage.Text = ""; //reset 錯誤訊息
        if (((List<dayOffInfo>)Session["lstDayOffAppSummary"]).Count != 0)
        {
            lstDayOffAppSummary = (List<dayOffInfo>)Session["lstDayOffAppSummary"];
        }
        fillDayOffApplicationTable(lstDayOffAppSummary);
        if (ddlDayOffType.SelectedValue == "0")  //測試錯誤 101.未選擇假別
        {
            errorList.Add(errorCode(101));
            test101 = false;
        }
        else
        {
            test101 = true;
        }
        if (DateTime.TryParse(txtDatePickerStart.Text.Trim(), out result))  //測試錯誤 102.起始日期輸入錯誤
        {
            dayOffStartTime = result.Date.AddHours(Convert.ToInt16(ddlDayOffStartHour.SelectedValue)).AddMinutes(Convert.ToInt16(ddlDayOffStartMin.SelectedValue));
            test102 = true;
        }
        else
        {
            errorList.Add(errorCode(102));
            test102 = false;
        }
        if (DateTime.TryParse(txtDatePickerEnd.Text.Trim(), out result))  //測試錯誤 103.結束日期輸入錯誤
        {
            dayOffEndTime = result.Date.AddHours(Convert.ToInt16(ddlDayOffEndHour.SelectedValue)).AddMinutes(Convert.ToInt16(ddlDayOffEndMin.SelectedValue));
            test103 = true;
        }
        else
        {
            errorList.Add(errorCode(103));
            test103 = false;
        }
        if (dayOffEndTime < dayOffStartTime)  //測試錯誤 104.結束日期小於開始日期
        {
            errorList.Add(errorCode(104));
            test104 = false;
        }
        else
        {
            test104 = true;
        }
        if (ddlDayOffFuncSub.SelectedValue == "0")  //測試錯誤 105.未選擇代理人
        {
            errorList.Add(errorCode(105));
            test105 = false;
        }
        else
        {
            test105 = true;
        }
        if (test102 && test103 && test104)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))  //測試錯誤 106.代理人有事，不能代理
            {
                conn.Open();
                string query = "SELECT APPLICATION_ID"
                            + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                            //+ " WHERE (APPLICANT_ID=@ID OR FUNCTIONAL_SUBSTITUTE_ID LIKE @ID+'%')"  //2017.03.24 移除代理人只能代理一個人的限制
                            + " WHERE (APPLICANT_ID=@ID)"  //代理人已請假
                            + " AND ((DAYOFF_START_TIME <= @STARTTIME AND DAYOFF_END_TIME > @STARTTIME)"
                            + " OR (DAYOFF_START_TIME < @ENDTIME AND DAYOFF_END_TIME >= @ENDTIME)"
                            + " OR (DAYOFF_START_TIME >= @STARTTIME AND DAYOFF_END_TIME <= @ENDTIME))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ddlDayOffFuncSub.SelectedValue);
                cmd.Parameters.AddWithValue("@STARTTIME", dayOffStartTime);
                cmd.Parameters.AddWithValue("@ENDTIME", dayOffEndTime);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        errorList.Add(errorCode(106));
                        test106 = false;
                    }
                    else
                    {
                        test106 = true;
                    }
                }
            }
        }
        if (ddlDayOffType.SelectedValue == "05" && txtReason.Text.Trim() == "") //測試錯誤 107.請事假未填寫請假原因
        {
            errorList.Add(errorCode(108));
            test108 = false;
        }
        else
        {
            test108 = true;
        }
        if (test101 && test102 && test103 && test104 && test105 && test106 && test107 && test108)  //PASS ALL INPUT TESTS, NEED TO START CALCULATING FOR OTHER ERRORS
        {
            DateTime[] days = GetDatesBetween(dayOffStartTime.Date, dayOffEndTime.Date);
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
                        if ((dtDayOffDaysInfo.Rows.Count == 1 && dayOffStartTime <= breakStartTime && dayOffEndTime <= breakStartTime)
                            || (dtDayOffDaysInfo.Rows.Count == 1 && dayOffStartTime >= breakEndTime && dayOffEndTime >= breakEndTime))  //請假週期只有一天，並且不與休息時間重疊
                        {
                            timeDifference = workEndTime - workStartTime;
                        }
                        else if (dayOffStartTime < breakEndTime)
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

                        if (timeDifference.Hours != 0 || timeDifference.Minutes != 0)
                        {   
                            //判斷假期開始時間是否合理
                            if (hdnOfficeOrProduction.Value == "production"  //線廠人員僅能以上、下午為單位請假
                                || ddlDayOffType.SelectedValue == "06" || ddlDayOffType.SelectedValue=="07" || ddlDayOffType.SelectedValue=="08" || ddlDayOffType.SelectedValue=="09"
                                || ddlDayOffType.SelectedValue == "11")  //婚、喪、陪產、颱風假，無論人員身分，僅能以上、下午為單位請假
                            {
                                if ((!(workStartTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][3].ToString().Substring(0, 2) && workStartTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][3].ToString().Substring(3, 2))     //開始放假時間(hhmm)!=開始上班時間
                                    && !(workStartTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(0, 2) && workStartTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(3, 2))  //開始放假時間(hhmm)!=休息開始時間
                                    && !(workStartTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(0, 2) && workStartTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(3, 2)))  //開始放假時間(hhmm)!=休息結束時間
                                    || (!(workEndTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][4].ToString().Substring(0, 2) && workEndTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][4].ToString().Substring(3, 2))  //結束放假時間(hhmm)!=結束上班時間
                                    && !(workEndTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(0, 2) && workEndTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(3, 2))  //結束放假時間(hhmm)!=休息開始時間
                                    && !(workEndTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(0, 2) && workEndTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(3, 2)))  //結束放假時間(hhmm)!=休息結束時間
                                    )
                                {
                                    errorList.Add(errorCode(206));
                                }
                            }
                        }
                        totalDayOffAmount += (timeDifference.Hours + Convert.ToDecimal(timeDifference.Minutes / 60.0));
                    }
                    else if (i == dtDayOffDaysInfo.Rows.Count - 1 && i != 0)  //last day, and last day and first day are not the same day (dayoff time span is more than 1 day date-wise)
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
                        if (timeDifference.Hours != 0 || timeDifference.Minutes != 0)
                        {
                            //判斷假期開始時間是否合理
                            if (hdnOfficeOrProduction.Value == "production"  //線廠人員僅能以上、下午為單位請假
                                || ddlDayOffType.SelectedValue == "06" || ddlDayOffType.SelectedValue == "07" || ddlDayOffType.SelectedValue == "08" || ddlDayOffType.SelectedValue == "09"
                                || ddlDayOffType.SelectedValue == "11")  //婚、喪、陪產、颱風假，無論人員身分，僅能以上、下午為單位請假
                            {
                                if ((!(workStartTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][3].ToString().Substring(0, 2) && workStartTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][3].ToString().Substring(3, 2))     //開始放假時間(hhmm)!=開始上班時間
                                    && !(workStartTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(0, 2) && workStartTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(3, 2))  //開始放假時間(hhmm)!=休息開始時間
                                    && !(workStartTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(0, 2) && workStartTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(3, 2)))  //開始放假時間(hhmm)!=休息結束時間
                                    || (!(workEndTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][4].ToString().Substring(0, 2) && workEndTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][4].ToString().Substring(3, 2))  //結束放假時間(hhmm)!=結束上班時間
                                    && !(workEndTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(0, 2) && workEndTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][5].ToString().Substring(3, 2))  //結束放假時間(hhmm)!=休息開始時間
                                    && !(workEndTime.Hour.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(0, 2) && workEndTime.Minute.ToString("D2") == dtDayOffDaysInfo.Rows[i][6].ToString().Substring(3, 2)))  //結束放假時間(hhmm)!=休息結束時間
                                    )
                                {
                                    errorList.Add(errorCode(206));
                                }
                            }
                        }
                        totalDayOffAmount += (Convert.ToDecimal(timeDifference.Hours) + Convert.ToDecimal(timeDifference.Minutes / 60.0));
                    }
                    else
                    {
                        totalDayOffAmount += Convert.ToDecimal(dtDayOffDaysInfo.Rows[i][7]);
                    }
                }
            }
            if (hdnDayOffTypeUnit.Value == "天")  //需要考慮一天工作時數非整數的人 (ie. 小倩8.5hr)
            {
                hdnTotalDayOffTime.Value = (totalDayOffAmount / Convert.ToDecimal(hdnNormalWorkHour.Value)).ToString();
                if (Convert.ToDecimal(hdnTotalDayOffTime.Value) * 100 % 50 != 0)  //測試錯誤 203.請假單位與限制不符
                {
                    errorList.Add(errorCode(203));
                }
            }
            else
            {
                hdnTotalDayOffTime.Value = Convert.ToDecimal(totalDayOffAmount).ToString();
                if (Convert.ToDecimal(hdnTotalDayOffTime.Value) * 10 % Convert.ToInt16((Convert.ToDecimal(hdnDayOffTimeRestraint.Value) * 10)) != 0)  //測試錯誤 203.請假單位與限制不符
                {
                    errorList.Add(errorCode(203));
                }
            }
            if (totalDayOffAmount <= 0)  //測試錯誤 201.此請假週期非上班時間，無須請假
            {
                errorList.Add(errorCode(201));
            }
            if (lblDayOffRemainAmount.Text.Trim() != "")  //測試錯誤 202.剩餘假期不足  --如假別無量的限制，則無需執行此測試
            {
                if (totalDayOffAmount > Convert.ToDecimal(lblDayOffRemainAmount.Text))
                {
                    errorList.Add(errorCode(202));
                }
            }
            //需先辨別假別是以天計算還是時計算
            
            for (int i = 0; i < lstDayOffAppSummary.Count && test204 == false; i++) //測試錯誤 204.請假週期已在此次請假清單內
            {
                if ((dayOffStartTime >= lstDayOffAppSummary[i].startTime && dayOffStartTime < lstDayOffAppSummary[i].endTime)
                    || (dayOffEndTime > lstDayOffAppSummary[i].startTime && dayOffEndTime <= lstDayOffAppSummary[i].endTime)
                    || (dayOffStartTime <= lstDayOffAppSummary[i].startTime && dayOffEndTime >= lstDayOffAppSummary[i].endTime))
                {
                    errorList.Add(errorCode(204));
                    test204 = true;
                }
            }
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString)) //測試錯誤 205.請假週期已在DB內
            {
                conn.Open();
                //check for error
                string query = "SELECT APPLICATION_ID"
                    + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                    + " WHERE APPLICANT_ID = @ID"
                    + " AND ((DAYOFF_START_TIME <= @STARTTIME AND DAYOFF_END_TIME > @STARTTIME)"
                    + " OR (DAYOFF_START_TIME < @ENDTIME AND DAYOFF_END_TIME >= @ENDTIME)"
                    + " OR (DAYOFF_START_TIME >= @STARTTIME AND DAYOFF_END_TIME <= @ENDTIME))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                cmd.Parameters.AddWithValue("@STARTTIME", dayOffStartTime);
                cmd.Parameters.AddWithValue("@ENDTIME", dayOffEndTime);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        errorList.Add(errorCode(205));
                    }
                }
            }
        }

        //錯誤訊息集合顯示
        errorList = errorList.OrderBy(d => d).ToList();
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
                    typeID = ddlDayOffType.SelectedValue.Trim(),
                    typeName = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim(),
                    startTime = dayOffStartTime,
                    endTime = dayOffEndTime,
                    unit = hdnDayOffTypeUnit.Value,
                    amountUsing = hdnTotalDayOffTime.Value,
                    restrictedAmountSet = "N",
                    funcSub = ddlDayOffFuncSub.SelectedItem.ToString().Trim(),
                    reason = txtReason.Text.Trim()
                });
            }
            else
            {
                lstDayOffAppSummary.Add(new dayOffInfo
                {
                    typeID = ddlDayOffType.SelectedValue.Trim(),
                    typeName = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim(),
                    startTime = dayOffStartTime,
                    endTime = dayOffEndTime,
                    unit = hdnDayOffTypeUnit.Value,
                    amountUsing = hdnTotalDayOffTime.Value,
                    restrictedAmountSet = "Y",
                    funcSub = ddlDayOffFuncSub.SelectedItem.ToString().Trim(),
                    reason = txtReason.Text.Trim()
                });
            }
            fillDayOffApplicationTable(lstDayOffAppSummary);
            Session["lstDayOffAppSummary"] = lstDayOffAppSummary;
            //re-calculate day off remain display
            if (lblDayOffRemainAmount.Text != "")
            {
                double sumFromList = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue).Sum(x => double.Parse(x.amountUsing));
                lblDayOffRemainAmount.Text = (Convert.ToDouble(hdnDayOffTimeRemainBeforeSubmit.Value) - sumFromList).ToString();
            }
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

            if (dt.Rows.Count > 0)
            {
                DataRow[] row;
                row = dt.Select("ID=" + ddlDayOffType.SelectedValue.ToString());

                //未選擇、婚假、陪產假、產檢假、產假 並非每年都有的假，所以忽略假期天數的限制，由人事檢查
                if (ddlDayOffType.SelectedValue.ToString() == "06" || ddlDayOffType.SelectedValue.ToString() == "09"
                    || ddlDayOffType.SelectedValue.ToString() == "15" || ddlDayOffType.SelectedValue.ToString() == "08")
                {
                    lblDayOffRemainType.Text = "";
                    lblDayOffRemainAmount.Text = "";
                    lblDayOffRemainUnit.Text = "";
                    hdnDayOffTypeUnit.Value = row[0][3].ToString();
                }
                else
                {
                    if (Convert.ToDouble(row[0][1]) > 0)
                    {
                        double sumFromList = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue).Sum(x => double.Parse(x.amountUsing));
                        hdnDayOffTimeRemainBeforeSubmit.Value = (Convert.ToDouble(row[0][1]) - Convert.ToDouble(row[0][2])).ToString();
                        lblDayOffRemainAmount.Text = (Convert.ToDouble(hdnDayOffTimeRemainBeforeSubmit.Value) - sumFromList).ToString();
                        lblDayOffRemainUnit.Text = row[0][3].ToString();
                    }
                    else
                    {
                        lblDayOffRemainType.Text = "";
                        lblDayOffRemainAmount.Text = "";
                        lblDayOffRemainUnit.Text = "";
                    }
                    hdnDayOffTypeUnit.Value = row[0][3].ToString();
                }
            }
        }

    }
    /// <summary>
    /// 錯誤訊息
    /// </summary>
    /// <param name="errorID"></param>
    /// <returns></returns>
    protected string errorCode(int errorID)
    {
        string error = errorID.ToString() + " ";
        if (errorID == 101)
        {
            error +=  "未選擇假別";
        }
        else if (errorID == 102)
        {
            error += "起始日期輸入錯誤(格式範例 2017/03/04)";
        }
        else if (errorID == 103)
        {
            error += "結束日期輸入錯誤(格式範例 2017/04/27)";
        }
        else if (errorID == 104)
        {
            error += "結束日期不可小於起始日期";
        }
        else if (errorID == 105)
        {
            error += "未選擇代理人";
        }
        else if (errorID == 106)
        {
            error += "代理人已經自行請假，請另選代理人";
        }
        else if (errorID == 107)
        {
            error += "已於此時段代理他人，不可請假";
        }
        else if (errorID == 108)
        {
            error += "請事假未填寫請假原因";
        }
        else if (errorID == 201)
        {
            error += "此請假週期非上班時間，無須請假";
        }
        else if (errorID == 202)
        {
            error += "剩餘假期不足";
        }
        else if (errorID == 203)
        {
            //error = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim() + "請假單位為0.5" + hdnDayOffTypeUnit.Value;
            error += "請假總量不符合單位數量";
        }
        else if (errorID == 204)
        {
            error += "此請假期間已與清單內重複，請確認";
        }
        else if (errorID == 205)
        {
            error += "此請假期間已申請，請與人事部確認";
        }
        else if (errorID == 206)
        {
            error += "請假時間不符規定，請與人事部確認";
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

    /// <summary>
    /// fill day off application table
    /// </summary>
    /// <param name="lstDayOffAppSummary"></param>
    protected void fillDayOffApplicationTable(List<dayOffInfo> lstDayOffAppSummary)
    {
        tbAppSummary.Rows.Clear();

        HtmlTableRow newHeaderRow = new HtmlTableRow();
        HtmlTableCell newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "假別";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "開始時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "結束時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假總量";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "代理人";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假原因";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "移除";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        tbAppSummary.Controls.Add(newHeaderRow);
        int listCounter = 0;
        foreach (dayOffInfo info in lstDayOffAppSummary)
        {
            listCounter += 1;
            HtmlTableRow newRow = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.InnerText = info.typeName;
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = info.startTime.ToString("yyyy/MM/dd tt hh:mm");
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = info.endTime.ToString("yyyy/MM/dd tt hh:mm");
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = info.amountUsing.ToString() + info.unit;
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = info.funcSub;
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = info.reason;
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            Button btn = new Button();
            btn.ID = "btnRemoveApp" + listCounter;
            btn.Text = "移除";
            btn.CssClass = "btn btn-danger";
            btn.Click += new EventHandler(btnRemoveApp_Click);
            cell.Controls.Add(btn);
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            tbAppSummary.Rows.Add(newRow);
        }
    }
    /// <summary>
    /// fill day off in-progress table
    /// </summary>
    /// <param name="lstDayOffAppSummary"></param>
    protected void fillInProgressApplicationTable()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT A.APPLICATION_ID,A.DAYOFF_NAME,A.DAYOFF_START_TIME,A.DAYOFF_END_TIME,CONVERT(NVARCHAR(20),A.DAYOFF_TOTAL_TIME)+DAYOFF_TIME_UNIT,MV.MV002,B.NAME"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION A"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_STATUS B ON A.APPLICATION_STATUS_ID=B.ID"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.FUNCTIONAL_SUBSTITUTE_ID=MV.MV001"
                        + " WHERE A.APPLICANT_ID=@APPLICANT"
                        + " AND A.APPLICATION_STATUS_ID<>'06'"
                        + " AND A.APPLICATION_STATUS_ID<>'07'"
                        + " AND A.APPLICATION_STATUS_ID<>'08'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APPLICANT", Session["erp_id"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        tbInProgressSummary.Rows.Clear();

        HtmlTableRow newHeaderRow = new HtmlTableRow();
        HtmlTableCell newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "假單ID";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "假別";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "開始時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "結束時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假總量";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "代理人";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "狀態";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "撤銷申請";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        tbInProgressSummary.Controls.Add(newHeaderRow);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlTableRow newRow = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][0].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][1].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = Convert.ToDateTime(dt.Rows[i][2]).ToString("yyyy/MM/dd tt hh:mm");
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = Convert.ToDateTime(dt.Rows[i][3]).ToString("yyyy/MM/dd tt hh:mm");
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][4].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][5].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][6].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            Button btn = new Button();
            btn.ID = "btnWithdrawApp" + i;
            btn.Text = "撤銷";
            btn.CssClass = "btn btn-danger";
            btn.OnClientClick = "javascript:return confirmWithdrawal();";
            btn.Click += new EventHandler(btnWithdrawApp_Click);
            cell.Controls.Add(btn);
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            tbInProgressSummary.Rows.Add(newRow);
        }
    }
    /// <summary>
    /// fill approval table
    /// </summary>
    protected void fillApprovalTable()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT APP.APPLICATION_ID,APP.APPLICATION_DATE,MV.MV002,APP.DAYOFF_NAME"
                        + " ,APP.DAYOFF_START_TIME,APP.DAYOFF_END_TIME,CONVERT(NVARCHAR(20),APP.DAYOFF_TOTAL_TIME)+APP.DAYOFF_TIME_UNIT"
                        + " ,MV2.MV002"
                        + " ,CASE"
                        + " WHEN APP.REASON='' THEN '無'"
                        + " ELSE '點選查看'"
                        + " END AS REASON"
                        + " ,APP.REASON"
                        + " ,SUBSTRING(ST.NAME,1,5)"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION APP"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_STATUS ST ON '0'+CONVERT(NVARCHAR(20),CONVERT(INT,APP.APPLICATION_STATUS_ID)+1)=ST.ID"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON APP.APPLICANT_ID=MV.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MV2 ON APP.FUNCTIONAL_SUBSTITUTE_ID=MV2.MV001"
                        + " WHERE CONVERT(INT,APP.APPLICATION_STATUS_ID)<7"
                        + " AND APP.NEXT_REVIEWER=@ID"
                        + " ORDER BY APP.APPLICATION_STATUS_ID,APP.APPLICATION_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        tbApprovalPending.Rows.Clear();

        HtmlTableRow newHeaderRow = new HtmlTableRow();
        HtmlTableCell newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "假單ID";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "申請人";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "假別";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "開始時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "結束時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假總量";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "代理人";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假原因";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "簽核階段";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        tbApprovalPending.Controls.Add(newHeaderRow);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlTableRow newRow = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][0].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            //cell = new HtmlTableCell();
            //cell.InnerText = dt.Rows[i][1].ToString();
            //cell.Attributes.Add("style", "text-align:center;");
            //newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][2].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][3].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = Convert.ToDateTime(dt.Rows[i][4]).ToString("yyyy/MM/dd tt hh:mm");
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = Convert.ToDateTime(dt.Rows[i][5]).ToString("yyyy/MM/dd tt hh:mm");
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][6].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][7].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][8].ToString();
            if (cell.InnerText == "無")
            {
                cell.Attributes.Add("style", "text-align:center;");
            }
            else
            {
                cell.Attributes.Add("style", "text-align:center;color:aqua;");
            }            
            cell.Attributes.Add("data-toggle", "popover");
            cell.Attributes.Add("data-placement", "top");
            cell.Attributes.Add("data-content", dt.Rows[i][9].ToString());
            cell.Attributes.Add("data-container", "body");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][10].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            Button btn = new Button();
            btn.ID = "btnApprove" + i;
            btn.Text = "簽核";
            btn.CssClass = "btn btn-success";
            btn.OnClientClick = "javascript:return confirmApprove();";
            btn.Click += new EventHandler(btnApprove_Click);
            cell.Controls.Add(btn);
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            btn = new Button();
            btn.ID = "btnDeny" + i;
            btn.Text = "退回";
            btn.CssClass = "btn btn-danger";
            btn.OnClientClick = "javascript:return confirmDeny();";
            btn.Click += new EventHandler(btnDeny_Click);
            cell.Controls.Add(btn);
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            tbApprovalPending.Rows.Add(newRow);
        }
    }
    /// <summary>
    /// Gets the ID of the post back control.
    /// 
    /// See: http://geekswithblogs.net/mahesh/archive/2006/06/27/83264.aspx
    /// </summary>
    /// <param name = "page">The page.</param>
    /// <returns></returns>
    private string getPostBackControlName()
    {
        Control control = null;
        //first we will check the "__EVENTTARGET" because if post back made by       the controls
        //which used "_doPostBack" function also available in Request.Form collection.
        string ctrlname = Page.Request.Params["__EVENTTARGET"];
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = Page.FindControl(ctrlname);
        }
        // if __EVENTTARGET is null, the control is a button type and we need to
        // iterate over the form collection to find it
        else
        {
            string ctrlStr = String.Empty;
            Control c = null;
            foreach (string ctl in Page.Request.Form)
            {
                //handle ImageButton they having an additional "quasi-property" in their Id which identifies
                //mouse x and y coordinates
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    c = Page.FindControl(ctrlStr);
                }
                else
                {
                    c = Page.FindControl(ctl);
                }
                if (c is System.Web.UI.WebControls.Button ||
                         c is System.Web.UI.WebControls.ImageButton)
                {
                    control = c;
                    break;
                }
            }
        }
        if (control == null)
        {
            return null;
        }
        else
        {
            return control.ID;
        }

    }

    /// <summary>
    /// Remove selected day off application from list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRemoveApp_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string btnID = btn.ID;
        //re-calculate day off remain display        
        if (ddlDayOffType.SelectedValue == lstDayOffAppSummary[Convert.ToInt16(btnID.Substring(12, btnID.Length - 12)) - 1].typeID
            && lstDayOffAppSummary[Convert.ToInt16(btnID.Substring(12, btnID.Length - 12)) - 1].restrictedAmountSet == "Y") /*ONLY do the recalculation if the removed dayoff type 
                                                                                                                             matches the one currently selected AND has restricted
                                                                                                                             amount set up*/
        {
            lstDayOffAppSummary.RemoveAt(Convert.ToInt16(btnID.Substring(12, btnID.Length - 12)) - 1);
            double sumFromList = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue).Sum(x => double.Parse(x.amountUsing));
            lblDayOffRemainAmount.Text = (Convert.ToDouble(hdnDayOffTimeRemainBeforeSubmit.Value) - sumFromList).ToString();
        }
        else
        {
            lstDayOffAppSummary.RemoveAt(Convert.ToInt16(btnID.Substring(12, btnID.Length - 12)) - 1);
        }
        fillDayOffApplicationTable(lstDayOffAppSummary);
    }
    /// <summary>
    /// Withdraw application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWithdrawApp_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string btnID = btn.ID;
        int rowNumber = Convert.ToInt16(btn.ID.Substring(14, btn.ID.Length - 14));
        string withdrawID = tbInProgressSummary.Rows[rowNumber + 1].Cells[0].InnerText;
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID"
                        + " )";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APPLICATION_ID", withdrawID);
            cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
            cmd.Parameters.AddWithValue("@EXECUTOR_ID", Session["erp_id"].ToString());
            cmd.Parameters.AddWithValue("@ACTION_ID", "04");
            cmd.ExecuteNonQuery();
            query = "UPDATE HR360_DAYOFFAPPLICATION_APPLICATION"
                + " SET APPLICATION_STATUS_ID=@STATUS,NEXT_REVIEWER=''"
                + " WHERE APPLICATION_ID=@APPLICATION";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@STATUS", "10");
            cmd.Parameters.AddWithValue("@APPLICATION", withdrawID);
            cmd.ExecuteNonQuery();
        }
        fillInProgressApplicationTable();
    }
    /// <summary>
    /// Approve application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string btnID = btn.ID;
        int rowNumber = Convert.ToInt16(btn.ID.Substring(10, btn.ID.Length - 10));
        string approveID = tbApprovalPending.Rows[rowNumber + 1].Cells[0].InnerText;
        string approveID_status = "";
        string applicantID = "";
        string memberOf = "";
        string nextReviewer = Session["erp_id"].ToString();
        DataTable dtApplicant = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();            
            //get current state of the application
            string query = "SELECT APP.APPLICATION_STATUS_ID,HIER.MEMBEROF,APP.APPLICANT_ID"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION APP"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON APP.APPLICANT_ID=MV.MV001"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MV.MV006=HIER.JOB_ID"
                        + " WHERE APPLICATION_ID=@APP_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", approveID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtApplicant);
        }
        approveID_status = dtApplicant.Rows[0][0].ToString();
        memberOf = dtApplicant.Rows[0][1].ToString();
        applicantID = dtApplicant.Rows[0][2].ToString().Trim();
        do
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                //insert approval trail to DB
                string query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B"
                    + " VALUES(@APP_ID,GETDATE(),@EXE_ID,'02')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@APP_ID", approveID);
                cmd.Parameters.AddWithValue("@EXE_ID", nextReviewer);
                cmd.ExecuteNonQuery();
            }
            //update application status to next stage
            approveID_status = (Convert.ToInt16(approveID_status) + 1).ToString("D2");
            if (approveID_status == "02")  //代理人簽核通過，搜尋第一層簽核人(部門最高負責人 BELOW RANK 7)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    //get applicant's dept
                    string query = "SELECT MV.MV004,HIER.[RANK]"
                                + " FROM NZ.dbo.CMSMV MV"
                                + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MV.MV006=HIER.JOB_ID"
                                + " WHERE MV.MV001=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", applicantID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    //第一層簽核 限制:RANK 2-7、RANK高於申請者RANK、同部門或可替換部門、
                    query = ";WITH REF_DEPT"
                        + " AS"
                        + " ("
                        + " SELECT REF.DEPT_MAIN MAIN,REF.DEPT_REF REF"
                        + " FROM NZ.dbo.CMSMV MV"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_DEPT_REFERENCE REF ON MV.MV004=REF.DEPT_MAIN AND REF.ACTIVE=1"
                        + " WHERE MV.MV001=@ID"
                        + " )"
                        + " SELECT TOP 1 MV.MV001,MV.MV002,MV.MV004,MK.MK001,HIER.[RANK],HIER.MEMBEROF"
                        + " FROM NZ.dbo.CMSMV MV"
                        + " LEFT JOIN NZ.dbo.CMSMK MK ON MV.MV001=MK.MK002"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MK.MK001=HIER.JOB_ID"
                        + " LEFT JOIN REF_DEPT REF ON MV.MV004=REF.MAIN OR MV.MV004=REF.REF"
                        + " WHERE MV.MV022=''"
                        + " AND MV.MV001<>'0000'"
                        + " AND MV.MV001<>'0098'"
                        + " AND MV.MV001<>@ID"
                        + " AND (MV.MV004=@DEPT OR MV.MV004=REF.REF)"
                        + " AND HIER.[RANK] > @RANK"
                        + " AND HIER.[RANK] BETWEEN 2 AND 7"
                        + " AND MV.MV004<>'B-C'"  //SPECIAL RULE FOR 上膠部，因為沒人會電腦，固上膠部請假直接到第二層，由生管口頭詢問上膠主管 (DELETE WHEN SITUATION CHANGES)
                        + " ORDER BY HIER.[RANK] DESC,MV.MV001";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", applicantID);
                    cmd.Parameters.AddWithValue("@DEPT", dt.Rows[0][0].ToString().Trim());
                    cmd.Parameters.AddWithValue("@RANK", dt.Rows[0][1].ToString().Trim());
                    dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        nextReviewer = dt.Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        nextReviewer = "SYSTEM";
                    }
                }
            }
            else if (approveID_status == "03")  //第一層通過，搜尋第二層審核者(廠長/副廠長/生管主任)
            {
                //產線才需要第二層(廠長)簽核，辦公室直接通過
                if (memberOf == "產線")
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        //簽核限制:產線 RANK 4-6
                        string query = "SELECT TOP 1 MV.MV001,MV.MV002,MV.MV004,MK.MK001,MK.MK002,HIER.[RANK],HIER.MEMBEROF"
                                    + " FROM NZ.dbo.CMSMV MV"
                                    + " LEFT JOIN NZ.dbo.CMSMK MK ON MV.MV001=MK.MK002"
                                    + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MK.MK001=HIER.JOB_ID"
                                    + " WHERE MV.MV022=''"
                                    + " AND HIER.MEMBEROF='產線'"
                                    + " AND HIER.[RANK] BETWEEN 4 AND 6"
                                    + " AND MV.MV001<>@ID"
                                    + " ORDER BY HIER.[RANK] DESC";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", applicantID);
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            nextReviewer = dt.Rows[0][0].ToString().Trim();
                        }
                        else
                        {
                            nextReviewer = "SYSTEM";
                        }
                    }
                }
                else
                {
                    nextReviewer = "SYSTEM";
                }
            }
            else if (approveID_status == "04")  //第二層通過，搜尋第三層審核者(人事主任)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    //簽核限制:人事主任 RANK 7
                    string query = "SELECT MV.MV001,MV.MV002,MV.MV004,MK.MK001,MK.MK002,HIER.[RANK],HIER.MEMBEROF"
                                + " FROM NZ.dbo.CMSMV MV"
                                + " LEFT JOIN NZ.dbo.CMSMK MK ON MV.MV001=MK.MK002"
                                + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MK.MK001=HIER.JOB_ID"
                                + " WHERE MV.MV022=''"
                                + " AND MV.MV001<>@ID"
                                + " AND MK.MK001='A20'"
                                + " AND HIER.[RANK]=7";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", applicantID);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        nextReviewer = dt.Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        nextReviewer = "SYSTEM";
                    }
                }
            }
            else if (approveID_status == "05")  //第三層通過，搜尋第四層審核者(副總)
            {
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    //簽核限制:副總 RANK 8
                    string query = "SELECT MV.MV001,MV.MV002,MV.MV004,MK.MK001,MK.MK002,HIER.[RANK],HIER.MEMBEROF"
                                + " FROM NZ.dbo.CMSMV MV"
                                + " LEFT JOIN NZ.dbo.CMSMK MK ON MV.MV001=MK.MK002"
                                + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MK.MK001=HIER.JOB_ID"
                                + " WHERE MV.MV022=''"
                                + " AND MV.MV001<>@ID"
                                + " AND MK.MK001='A03'"
                                + " AND HIER.[RANK]=8";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", applicantID);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        nextReviewer = dt.Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        nextReviewer = "SYSTEM";
                    }
                }
            }
            else if (approveID_status == "06")
            {
                nextReviewer = "";
            }
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                //update application with new status and reviewer
                conn.Open();
                string query = "UPDATE HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " SET APPLICATION_STATUS_ID=@STATUS,NEXT_REVIEWER=@REVIEWER"
                        + " WHERE APPLICATION_ID=@APPLICATION";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@STATUS", approveID_status);
                cmd.Parameters.AddWithValue("@REVIEWER", nextReviewer);
                cmd.Parameters.AddWithValue("@APPLICATION", approveID);
                cmd.ExecuteNonQuery();
            }
            lblTest.Text = approveID_status + " " + nextReviewer;
            System.Threading.Thread.Sleep(1000);    //sleeps for 1 second before continuing so trail records can be ordered by time
        } while (nextReviewer == "SYSTEM" && approveID_status != "06"); //stops when somebody is required to review the application,
                                                                        //or when approval status reached 6, which means the application is approved by everyone necessary
                                                                        //automatic approval should only happen on 1st and 2nd level,
                                                                        //3rd and 4th level should always have reviewer (人事主管/副總)
        fillApprovalTable();
    }
    /// <summary>
    /// Deny application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeny_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string btnID = btn.ID;
        int rowNumber = Convert.ToInt16(btn.ID.Substring(7, btn.ID.Length - 7));
        string denyID = tbApprovalPending.Rows[rowNumber + 1].Cells[0].InnerText;        
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();            
            //insert deny trail to DB
            string query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B"
                        + " VALUES(@APP_ID,GETDATE(),@EXE_ID,'03')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", denyID);
            cmd.Parameters.AddWithValue("@EXE_ID", Session["erp_id"].ToString());
            cmd.ExecuteNonQuery();
            query = "UPDATE HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " SET APPLICATION_STATUS_ID=@STATUS,NEXT_REVIEWER=@REVIEWER"
                        + " WHERE APPLICATION_ID=@APPLICATION";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@STATUS", "08");
            cmd.Parameters.AddWithValue("@REVIEWER", "");
            cmd.Parameters.AddWithValue("@APPLICATION", denyID);
            cmd.ExecuteNonQuery();
        }
        fillApprovalTable();
    }
    /// <summary>
    /// Submit application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAppSubmit_Click(object sender, EventArgs e)
    {
        //assign unique ID (yyyymmdd+流水號) to each application
        string uid = "";
        string query = "";
        foreach (dayOffInfo dayoff in lstDayOffAppSummary)
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                //gerneral unique id
                query = "SELECT MAX(CONVERT(INT,(SUBSTRING(APPLICATION_ID,LEN(APPLICATION_ID)-2,3))))"
                    + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                    + " WHERE APPLICATION_ID LIKE @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", DateTime.Now.ToString("yyyyMMdd") + "%");
                if (cmd.ExecuteScalar() == DBNull.Value)
                {
                    uid = DateTime.Now.ToString("yyyyMMdd") + "001";
                }
                else
                {
                    uid = DateTime.Now.ToString("yyyyMMdd") + (Convert.ToInt16(cmd.ExecuteScalar()) + 1).ToString("D3");
                }

                //insert record with unique id
                try
                {                    
                    query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " VALUES ("
                        + " @APPLICATION_ID,@APPLICATION_DATE,@APPLICANT_ID,@DAYOFF_ID,@DAYOFF_NAME,@DAYOFF_START_TIME,@DAYOFF_END_TIME,@DAYOFF_TOTAL_TIME,@DAYOFF_TIME_UNIT,@FUNC_SUB_ID,'01',@NEXT_REVIEWER,@REASON"
                        + " )";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@APPLICATION_ID", uid);
                    cmd.Parameters.AddWithValue("@APPLICATION_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@APPLICANT_ID", Session["erp_id"].ToString().Trim());
                    cmd.Parameters.AddWithValue("@DAYOFF_ID", dayoff.typeID);
                    cmd.Parameters.AddWithValue("@DAYOFF_NAME", dayoff.typeName);
                    cmd.Parameters.AddWithValue("@DAYOFF_START_TIME", dayoff.startTime);
                    cmd.Parameters.AddWithValue("@DAYOFF_END_TIME", dayoff.endTime);
                    cmd.Parameters.AddWithValue("@DAYOFF_TOTAL_TIME", dayoff.amountUsing);
                    cmd.Parameters.AddWithValue("@DAYOFF_TIME_UNIT", dayoff.unit);
                    cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.funcSub.Substring(0, 4));
                    cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.funcSub.Substring(0, 4));
                    cmd.Parameters.AddWithValue("@REASON", txtReason.Text.Trim());
                    cmd.ExecuteNonQuery();
                    query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID"
                        + " )";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@APPLICATION_ID", uid);
                    cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
                    cmd.Parameters.AddWithValue("@EXECUTOR_ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@ACTION_ID", "01");
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) //ID 重複錯誤
                    {
                        query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " VALUES ("
                        + " @APPLICATION_ID,@APPLICATION_DATE,@APPLICANT_ID,@DAYOFF_ID,@DAYOFF_NAME,@DAYOFF_START_TIME,@DAYOFF_END_TIME,@DAYOFF_TOTAL_TIME,@DAYOFF_TIME_UNIT,@FUNC_SUB_ID,'01',@NEXT_REVIEWER,@REASON"
                        + " )";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@APPLICATION_ID", (Convert.ToInt64(uid) + 1).ToString());
                        cmd.Parameters.AddWithValue("@APPLICATION_DATE", DateTime.Now);
                        cmd.Parameters.AddWithValue("@APPLICANT_ID", Session["erp_id"].ToString().Trim());
                        cmd.Parameters.AddWithValue("@DAYOFF_ID", dayoff.typeID);
                        cmd.Parameters.AddWithValue("@DAYOFF_NAME", dayoff.typeName);
                        cmd.Parameters.AddWithValue("@DAYOFF_START_TIME", dayoff.startTime);
                        cmd.Parameters.AddWithValue("@DAYOFF_END_TIME", dayoff.endTime);
                        cmd.Parameters.AddWithValue("@DAYOFF_TOTAL_TIME", dayoff.amountUsing);
                        cmd.Parameters.AddWithValue("@DAYOFF_TIME_UNIT", dayoff.unit);
                        cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.funcSub);
                        cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.funcSub.Substring(0, 4));
                        cmd.Parameters.AddWithValue("@REASON", txtReason.Text.Trim());
                        cmd.ExecuteNonQuery();
                        query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID"
                        + " )";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@APPLICATION_ID", uid);
                        cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
                        cmd.Parameters.AddWithValue("@EXECUTOR_ID", Session["erp_id"].ToString());
                        cmd.Parameters.AddWithValue("@ACTION_ID", "01");
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                       
                    }
                }
            }

            //
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('申請已送出');", true);
        lstDayOffAppSummary.Clear();
        fillDayOffApplicationTable(lstDayOffAppSummary);
        fillInProgressApplicationTable();
    }
    /// <summary>
    /// Initial loading for div application section
    /// </summary>
    protected void ApplicationSection_Init_Load()
    {
        Session["lstDayOffAppSummary"] = lstDayOffAppSummary;
        hdnIsPostBack.Value = "0";  //variable for determining whether this page is a postback for jquery
        hdnIsDayOffAppVisible.Value = "0";  //variable for determining whether the div DayOffApp is visible
        DataSet ds = new DataSet();
        string query = "";
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            query = "SELECT MV.MV007,MV.MV004,HIER.[RANK]"  //獲取登入者資料 性別、部門別
                + " FROM CMSMV MV"
                + " LEFT JOIN NZ_ERP2.dbo.HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MV.MV006=HIER.JOB_ID"
                + " WHERE MV.MV001=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString().Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(userInfo);
            if (userInfo.Rows[0][0].ToString() == "1")  //性別為男性，不可用產檢假及產假
            {
                query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                    + " FROM PALMC"
                    + " WHERE PALMC.MC001<>'15'" //產檢假
                    + " AND PALMC.MC001<>'08'" //產假
                    + " AND PALMC.MC001<>'10'" //曠職
                    + " ORDER BY PALMC.MC001";
            }
            else //女性無陪產假
            {
                query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                    + " FROM PALMC"
                    + " WHERE PALMC.MC001<>'10'" //曠職
                    + " AND PALMC.MC001<>'09'" //陪產假
                    + " ORDER BY PALMC.MC001";
            }
            cmd = new SqlCommand(query, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Day Off Type");
            //抓取跟登入者同部門及可替代部門的人 (according to DB HR360_DAYOFFAPPLICATION_DEPT_REFERENCE)            
            query = ";WITH REF_DEPT"
                + " AS"
                + " ("
                + " SELECT REF.DEPT_MAIN MAIN,REF.DEPT_REF REF"
                + " FROM CMSMV MV"
                + " LEFT JOIN NZ_ERP2.dbo.HR360_DAYOFFAPPLICATION_DEPT_REFERENCE REF ON MV.MV004=REF.DEPT_MAIN AND REF.ACTIVE=1"
                + " WHERE MV.MV001=@ID"
                + " )"
                + " SELECT DISTINCT LTRIM(RTRIM(MV.MV001))+' '+MV.MV002,MV.MV001"
                + " FROM CMSMV MV"
                + " LEFT JOIN CMSMK MK ON MV.MV001=MK.MK002"
                + " LEFT JOIN REF_DEPT REF ON MV.MV004=REF.MAIN OR MV.MV004=REF.REF"
                + " WHERE MV.MV022=''"
                + " AND MV.MV001<>'0000'" //李小姐
                + " AND MV.MV001<>'0098'" //黃耀南
                + " AND MV.MV001<>@ID"
                + " AND (MV.MV004=@DEPT OR MV.MV004=REF.REF)"
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

        //請假內容header
        HtmlTableRow newHeaderRow = new HtmlTableRow();
        HtmlTableCell newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "假別";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "開始時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "結束時間";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假總量";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "代理人";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "請假原因";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "移除";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        tbAppSummary.Controls.Add(newHeaderRow);
        //還需要代理人是否eligible for代理的篩選條件
        ddlDayOffFuncSub.Items.Add(new ListItem("請選擇代理人", "0"));
        ddlDayOffFuncSub.SelectedIndex = 0;
        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            ddlDayOffFuncSub.Items.Add(new ListItem(ds.Tables[1].Rows[i][0].ToString().Trim(), ds.Tables[1].Rows[i][1].ToString().Trim()));
        }
        //hidden field insertion
        //determine if applicant is within 0.5hr restraint or 4hr restraint (by dept)
        if (userInfo.Rows[0][1].ToString() == "B-C"     //使用者部門為上膠部
            || userInfo.Rows[0][1].ToString() == "B-E"  //絞線包帶部
            || userInfo.Rows[0][1].ToString() == "B-G"  //編織部
            || userInfo.Rows[0][1].ToString() == "B-IC" //倉儲管理科
            || userInfo.Rows[0][1].ToString() == "B-K"  //捲線部
            || userInfo.Rows[0][1].ToString() == "B-P"  //PVC押出部
            || userInfo.Rows[0][1].ToString() == "B-S"  //矽膠部
            || userInfo.Rows[0][1].ToString() == "B-T"  //鐵氟龍部
            )
        {
            hdnDayOffTimeRestraint.Value = "4";
            hdnOfficeOrProduction.Value = "production";
        }
        else
        {
            hdnOfficeOrProduction.Value = "office";
            hdnDayOffTimeRestraint.Value = "0.5";
        }
        hdnEmployeeRank.Value = userInfo.Rows[0][2].ToString();
    }
    /// <summary>
    /// Postback loading for div application section
    /// </summary>
    protected void ApplicationSection_PostBack_Load()
    {
        hdnIsPostBack.Value = "1";
        if (getPostBackControlName() != "btnDayOffAdd")
        {
            if (((List<dayOffInfo>)Session["lstDayOffAppSummary"]).Count != 0)
            {
                lstDayOffAppSummary = (List<dayOffInfo>)Session["lstDayOffAppSummary"];
            }
            fillDayOffApplicationTable(lstDayOffAppSummary);
        }
    }
    /// <summary>
    /// Initial loading for div in-progress section
    /// </summary>
    protected void InProgressSection_Init_Load()
    {        
        fillInProgressApplicationTable();
    }
    /// <summary>
    /// Postback loading for div in-progress section
    /// </summary>
    protected void InProgressSection_PostBack_Load()
    {
        fillInProgressApplicationTable();
    }
    /// <summary>
    /// Initial loading for div approval section
    /// </summary>
    protected void ApprovalSection_Init_Load()
    {
        fillApprovalTable();
    }
    /// <summary>
    /// Postback loading for div approval section
    /// </summary>
    protected void ApprovalSection_PostBack_Load()
    {
        fillApprovalTable();
    }
}