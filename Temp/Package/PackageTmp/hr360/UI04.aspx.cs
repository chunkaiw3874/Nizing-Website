﻿using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
/*
 如果HR有人事變更，於本頁搜尋HR做更正!!!
 */
/*
 * 2018.11.01 HR:0142
 * 2018.09.27 改版為假單不跨天
 * PS: 搜尋"NEED FIX" for code
 */
public partial class hr360_UI04 : System.Web.UI.Page
{
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    List<dayOffInfo> lstDayOffAppSummary = new List<dayOffInfo>();
    DataTable userInfo = new DataTable();
    string currentHREmployeeID = "0142"; //current //HR code;
    List<string> exceptionList111 = new List<string>(); //三天內請假錯誤例外清單
    List<string> exceptionList202designated = new List<string>(); //剩餘假期不足錯誤例外清單(特休)
    List<string> exceptionList202makeup = new List<string>(); //剩餘假期不足錯誤例外清單(補休)
    List<string> exceptionList107 = new List<string>(); //已當其他人代理人錯誤例外清單
    List<string> exceptionList110 = new List<string>(); //請假年分限本年度例外清單
    List<string> exceptionListHourForProduction = new List<string>();   //例外清單:可用小時計假的線廠人員(阿豪0160)

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
        //Session["user_id"] = "0174";    //test only to avoid error on loading, delete after trial            
        //Session["erp_id"] = "0174";
        //Session["company"] = "NIZING";

        //only use when opening check exception for certain persion
        exceptionList111.Add("0067");
        //exceptionList202designated.Add("0112");
        //exceptionList107.Add("0162");
        exceptionList110.Add("0067");
        //exceptionList202makeup.Add("0067");
        exceptionListHourForProduction.Add("0160"); //阿豪


        if (Session["user_id"].ToString().ToUpper().Trim() != "ADMIN")  //admin doesnt have the proper erp information and will crash the system
        {
            if (!IsPostBack)
            {
                ApplicationSection_Init_Load();
                InProgressSection_Init_Load();
                ApprovalSection_Init_Load();
                SearchSection_Init_Load();
            }
            else
            {
                ApplicationSection_PostBack_Load();
                InProgressSection_PostBack_Load();
                ApprovalSection_PostBack_Load();
            }

            //hidden field that contains normal work hour per day for current user
            hdnNormalWorkHour.Value = "8";
            Page.LoadComplete += new EventHandler(Page_LoadComplete);
        }

    }

    void Page_LoadComplete(object sender, EventArgs e)
    {
        btnSearchSubmit_Click(sender, e);   //does search automatically everytime page finishes loading
    }


    //#region Test Area!!!!!!!!!! Test Methods ONLY!!!!!!
    ////Test for Different ID
    //protected void btnTestName_Click(object sender, EventArgs e)
    //{
    //    Session["erp_id"] = txtTestName.Text.Trim();
    //    lblTest.Text = "測試帳號" + txtTestName.Text.Trim();
    //}
    ////Test for simple email construction
    //protected void btnTestEmail_Click(object sender, EventArgs e)
    //{
    //    // create the email message
    //    string from = "chrissy@nizing.com.tw";
    //    string to = "kevin@nizing.com.tw";
    //    string subject = "test for smtp speed";
    //    string body = "How fast is this email sent?";
    //    MailMessage completeMessage = new MailMessage(from, to, subject, body);

    //    Thread email = new Thread(delegate(){
    //        SendEmail(to, from, subject, body);
    //    });
    //    email.IsBackground = true;
    //    email.Start();
    //    //// create smtp client at mail server location
    //    //SmtpClient client = new SmtpClient("mail.nizing.com.tw");

    //    //// add credentials
    //    //client.UseDefaultCredentials = true;

    //    //try
    //    //{
    //    //    // send message
    //    //    client.Send(completeMessage);
    //    //}
    //    //catch (Exception)
    //    //{
    //    //    throw;
    //    //}
    //}    
    //#endregion

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
        bool needFunctionalSubstitute = true; //Flag for if functional substitute is needed
        bool dayOffUnderHalfHour = false;   //Flag for if dayoff is under half an hour
        bool typhoonDay = false;    //Flag for if the entire duration of the day off is typhoon day
        bool test101 = false;
        bool test102 = false;
        bool test103 = false;
        bool test104 = false;
        //bool test105 = false;
        //bool test106 = false;
        //bool test107 = false;
        bool test108 = false;
        bool test110 = false;
        bool test111 = false;
        bool test112 = false;
        bool test204 = false;
        DataTable dtDayOffDaysInfo = new DataTable();
        decimal totalDayOffAmount = 0;

        txtErrorMessage.Text = ""; //reset 錯誤訊息

        if (ddlDayOffType.SelectedValue == "11" || ckbTyphoonDayNoSub.Checked)  //檢查是否為颱風假申請
        {
            typhoonDay = true;
        }
        else
        {
            typhoonDay = false;
        }

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
        //if (dayOffEndTime < dayOffStartTime)  //測試錯誤 104.結束日期小於開始日期
        //{
        //    errorList.Add(errorCode(104));
        //    test104 = false;
        //}
        //else
        //{
        //    test104 = true;
        //}
        if (txtDatePickerStart.Text != txtDatePickerEnd.Text)  //測試錯誤 104.假單不可跨天
        {
            if (ddlDayOffEndHour.SelectedValue != "00" || ddlDayOffEndMin.SelectedValue != "00" || DateTime.Parse(txtDatePickerEnd.Text).Date != DateTime.Parse(txtDatePickerStart.Text).Date.AddDays(1))
            {
                errorList.Add(errorCode(104));
                test104 = false;
            }
        }
        else
        {
            test104 = true;
        }
        if (ddlDayOffType.SelectedValue == "05" && txtReason.Text.Trim() == "") //測試錯誤 108.請事假未填寫請假原因
        {
            errorList.Add(errorCode(108));
            test108 = false;
        }
        else
        {
            test108 = true;
        }
        if (DateTime.ParseExact(txtDatePickerStart.Text, "yyyy/MM/dd", new CultureInfo("zh-TW")).Year != DateTime.Today.Year
            && !exceptionList110.Contains(Session["erp_id"].ToString()))  //測試錯誤 110.僅能請本年度的假
        {
            errorList.Add(errorCode(110));
            test110 = false;
        }
        else
        {
            test110 = true;
        }

        if (DateTime.ParseExact(txtDatePickerStart.Text, "yyyy/MM/dd", new CultureInfo("zh-TW")) < DateTime.Today.AddDays(-3))    //測試錯誤 111.請假日期不得小於三日前
        {
            if (exceptionList111.Contains(Session["erp_id"].ToString().Trim()))
            {
                test111 = true;
            }
            else
            {
                errorList.Add(errorCode(111, "請假日期不得早於" + DateTime.Today.AddDays(-3).ToString("d", new CultureInfo("zh-TW"))));
                test111 = false;
            }
        }
        else
        {
            test111 = true;
        }

        if (test101 && test102 && test103 && test104 && test108 && test110 && test111)  //PASS ALL INPUT TESTS (except for functional substitute), NEED TO START CALCULATING FOR OTHER ERRORS
        {
            //DateTime[] days = GetDatesBetween(dayOffStartTime.Date, dayOffEndTime.Date);
            //for (int i = 0; i < days.Length; i++)
            //{
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                string query = "SELECT MP.MP004 '日期',MP.MP005 '放假'," + "MB.MB0" + (Convert.ToInt16(dayOffStartTime.Day.ToString()) + 2).ToString("D2") + " '班別',CONVERT(TIME,STUFF(MK.MK003,3,0,':')) '上班時間',CONVERT(TIME,STUFF(MK.MK004,3,0,':'))  '下班時間'"
                        + " ,CONVERT(TIME,STUFF(MK.MK009,3,0,':')) '休息開始時間',CONVERT(TIME,STUFF(MK.MK010,3,0,':')) '休息結束時間'"
                        + " ,CASE"
                        + " WHEN MK.MK003>MK.MK004 THEN 24.0-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,'00:00'),CONVERT(TIME,STUFF('1700', 3, 0, ':')))/60.0)+CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,'00:00'),CONVERT(TIME,STUFF('0100',3,0,':')))/60.0)-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK009, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK010, 3, 0, ':')))/60.0)"
                        + " ELSE CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK003, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK004, 3, 0, ':')))/60.0)-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK009, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK010, 3, 0, ':')))/60.0)"
                        + " END '工作時數'"
                        + " ,CASE"
                        + " WHEN MK.MK003>MK.MK004 THEN '1'"
                        + " ELSE '0'"
                        + " END '跨天'"
                        + " FROM AMSMB MB"
                        + " LEFT JOIN CMSMP MP ON MP.MP001='3' AND MP.MP004=@YYYYMMDD AND MP.MP003=" + "MB.MB0" + (Convert.ToInt16(dayOffStartTime.Day.ToString()) + 2).ToString("D2")
                        + " LEFT JOIN PALMK MK ON MB.MB0" + (Convert.ToInt16(dayOffStartTime.Day.ToString()) + 2).ToString("D2") + "=MK.MK001"
                        + " WHERE MB.MB001=@ID"
                        + " AND MB.MB002=@YYYYMM";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YYYYMMDD", dayOffStartTime.Date.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                cmd.Parameters.AddWithValue("@YYYYMM", dayOffStartTime.Date.ToString("yyyyMM"));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dtDayOffDaysInfo.Load(dr);
                }
                //fill in null cells with desired data
                if (dtDayOffDaysInfo.Rows.Count != 0)
                {
                    if (String.IsNullOrWhiteSpace(dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][0].ToString()))
                    {
                        dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][0] = dayOffStartTime.Date.ToString("yyyyMMdd");
                    }
                    if (String.IsNullOrWhiteSpace(dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][1].ToString()))
                    {
                        dtDayOffDaysInfo.Rows[dtDayOffDaysInfo.Rows.Count - 1][1] = "3";
                    }
                }
                else
                {
                    errorList.Add(errorCode(207));  //Error 207:人員班別尚未建立
                }
            }
            //}
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
                            if (hdnOfficeOrProduction.Value == "production" && !typhoonDay && !exceptionListHourForProduction.Contains(Session["erp_id"].ToString()))  //除非是颱風假，線廠人員僅能以上、下午為單位請假                                
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
                            if (hdnOfficeOrProduction.Value == "production" && !typhoonDay && !exceptionListHourForProduction.Contains(Session["erp_id"].ToString()))  //除非是颱風假，線廠人員僅能以上、下午為單位請假                                
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

            if (!IsDataTableEmpty(dtDayOffDaysInfo))
            {
                if (dtDayOffDaysInfo.Rows[0]["跨天"].ToString() == "1")   //測試錯誤 109.請假時間非上班時間，請確認
                {
                    if (dayOffStartTime < DateTime.Parse(DateTime.ParseExact(dtDayOffDaysInfo.Rows[0]["日期"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd") + " " + dtDayOffDaysInfo.Rows[0]["上班時間"].ToString()))
                    {
                        errorList.Add(errorCode(999));
                    }
                }
                else
                {
                    if (dayOffStartTime < DateTime.Parse(DateTime.ParseExact(dtDayOffDaysInfo.Rows[0]["日期"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd") + " " + dtDayOffDaysInfo.Rows[0]["上班時間"].ToString())
                        || dayOffStartTime > DateTime.Parse(DateTime.ParseExact(dtDayOffDaysInfo.Rows[0]["日期"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd") + " " + dtDayOffDaysInfo.Rows[0]["下班時間"].ToString())
                        || dayOffEndTime < DateTime.Parse(DateTime.ParseExact(dtDayOffDaysInfo.Rows[0]["日期"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd") + " " + dtDayOffDaysInfo.Rows[0]["上班時間"].ToString())
                        || dayOffEndTime > DateTime.Parse(DateTime.ParseExact(dtDayOffDaysInfo.Rows[0]["日期"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd") + " " + dtDayOffDaysInfo.Rows[0]["下班時間"].ToString()))
                    {
                        errorList.Add(errorCode(109));
                    }
                }
            }
            //是否需要代理人條件整理
            if (totalDayOffAmount > (decimal)0.5)   //請假是否超過半小時
            {
                dayOffUnderHalfHour = false;
            }
            else
            {
                dayOffUnderHalfHour = true;
            }

            if (dayOffUnderHalfHour //2018.06.13 如果請假時間超過半小時，才需要做代理人測試
                || typhoonDay   //2018.07.12 颱風假不需要代理人
                )
            {
                needFunctionalSubstitute = false;
            }
            else
            {
                needFunctionalSubstitute = true;
            }

            if (needFunctionalSubstitute)
            {
                if (ddlDayOffFuncSub.SelectedValue == "0")  //測試錯誤 105.未選擇代理人
                {
                    errorList.Add(errorCode(105));
                    //test105 = false;
                }
                else
                {
                    //test105 = true;
                }
                if (test102 && test103 && test104)
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))  //測試錯誤 106.代理人有事，不能代理
                    {
                        conn.Open();
                        string query = "SELECT APPLICATION_ID"
                                    + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                                    //+ " WHERE (APPLICANT_ID=@ID OR FUNCTIONAL_SUBSTITUTE_ID=@ID)"  //2017.03.24 移除代理人只能代理一個人的限制
                                    + " WHERE (APPLICANT_ID=@ID)"  //代理人已請假
                                    + " AND APPLICATION_STATUS_ID <> '98'"
                                    + " AND APPLICATION_STATUS_ID <> '99'"
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
                                //test106 = false;
                            }
                            else
                            {
                                //test106 = true;
                            }
                        }
                    }
                }
                if (test102 && test103 && test104)
                {
                    if (!exceptionList107.Contains(Session["erp_id"].ToString().Trim()))
                    {
                        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))  //測試錯誤 107.申請人於此時段已代理他人，不可請假
                        {
                            conn.Open();
                            string query = "SELECT APPLICATION_ID"
                                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                                        + " WHERE (FUNCTIONAL_SUBSTITUTE_ID=@ID)"  //自己已經是其他人的代理人                            
                                        + " AND APPLICATION_STATUS_ID <> '98'"
                                        + " AND APPLICATION_STATUS_ID <> '99'"
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
                                    errorList.Add(errorCode(107));
                                    //test107 = false;
                                }
                                else
                                {
                                    //test107 = true;
                                }
                            }
                        }
                    }
                }
            }
            //else
            //{
            //    test105 = true;
            //    test106 = true;
            //    test107 = true;
            //}
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
                if (typhoonDay)    //颱風假則任何人都可以0.5小時請假
                {
                    if (Convert.ToDecimal(hdnTotalDayOffTime.Value) * 10 % Convert.ToInt16((Convert.ToDecimal(0.5) * 10)) != 0)  //測試錯誤 203.請假單位與限制不符
                    {
                        errorList.Add(errorCode(203));
                    }
                }
                else
                {
                    if (Convert.ToDecimal(hdnTotalDayOffTime.Value) * 10 % Convert.ToInt16((Convert.ToDecimal(hdnDayOffTimeRestraint.Value) * 10)) != 0)  //測試錯誤 203.請假單位與限制不符
                    {
                        errorList.Add(errorCode(203));
                    }
                }
            }
            if (totalDayOffAmount <= 0)  //測試錯誤 201.請假時數為0，請確認
            {
                errorList.Add(errorCode(201));
            }


            if (lblDayOffRemainAmount.Text.Trim() != "" || ddlDayOffType.SelectedValue == "02" || ddlDayOffType.SelectedValue == "03")  //測試錯誤 202.剩餘假期不足  --如假別無量的限制，則無需執行此測試
            {
                decimal r;
                decimal totalDayOffRemain;
                if (ddlDayOffType.SelectedValue == "02")  //補休(02)用此判斷
                {
                    r = 0;
                    for (int i = 0; i < tbAppSummary.Rows.Count - 1; i++)
                    {
                        if (tbAppSummary.Rows[i].Cells[0].InnerText == "補休")
                        {
                            string usedAmount = tbAppSummary.Rows[i].Cells[3].ToString().Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2);
                            r += decimal.Parse(usedAmount);
                        }
                    }
                    for (int i = 0; i < tbInProgressSummary.Rows.Count - 1; i++)
                    {
                        if (tbInProgressSummary.Rows[i].Cells[1].InnerText == "補休" && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
                        {
                            string usedAmount = tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2);
                            r += decimal.Parse(usedAmount);
                        }
                    }
                    //totalDayOffRemain = decimal.Parse(Session["makeupDayOff"].ToString()) - r;
                    totalDayOffRemain = decimal.Parse(lblDayOffRemainAmount.Text) - r;
                    if (totalDayOffAmount > totalDayOffRemain && !exceptionList202makeup.Contains(Session["erp_id"].ToString().Trim()))
                    {
                        errorList.Add(errorCode(202, "於請假日期，補休時數僅剩餘" + totalDayOffRemain.ToString() + "小時"));
                    }
                }
                else if (ddlDayOffType.SelectedValue == "03" && !IsDataTableEmpty(dtDayOffDaysInfo))  //特休(03)用此判斷 依據請假日期會有2種可能
                {
                    if (exceptionList202designated.Contains(Session["erp_id"].ToString().Trim()))
                    {

                    }
                    else
                    {
                        r = 0;
                        DateTime dayOffStartDate = DateTime.ParseExact(dtDayOffDaysInfo.Rows[0]["日期"].ToString(), "yyyyMMdd", null);
                        DateTime startWorkDate = DateTime.ParseExact(Session["startYear"].ToString() + Session["startDate"].ToString(), "yyyyMMdd", null);
                        DateTime relevantWorkDate = DateTime.ParseExact(dayOffStartDate.Year.ToString() + Session["startDate"].ToString(), "yyyyMMdd", null);
                        /*
                         * 兩種可能性的計算方式                    
                         */
                        if (dayOffStartDate >= startWorkDate.AddMonths(6))  //確認請假同仁已任職滿六個月
                        {
                            //2021年因疫情關係，讓同仁可預支假期，不分上下年度
                            /* Scenario 1
                             * 請假月日為到職月日之前
                             */
                            if (dayOffStartDate < relevantWorkDate)
                            {
                                for (int i = 1; i < tbAppSummary.Rows.Count; i++)
                                {
                                    if (tbAppSummary.Rows[i].Cells[0].InnerText == "特休" && DateTime.Parse(tbAppSummary.Rows[i].Cells[1].InnerText) < relevantWorkDate)
                                    {
                                        string usedAmount = tbAppSummary.Rows[i].Cells[3].InnerText.Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2);
                                        r += decimal.Parse(usedAmount);
                                    }
                                }
                                for (int i = 1; i < tbInProgressSummary.Rows.Count; i++)
                                {
                                    if (tbInProgressSummary.Rows[i].Cells[1].InnerText == "特休" && DateTime.Parse(tbInProgressSummary.Rows[i].Cells[2].InnerText) < relevantWorkDate && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
                                    {
                                        string usedAmount = tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2);
                                        r += decimal.Parse(usedAmount);
                                    }
                                }
                                totalDayOffRemain = decimal.Parse(Session["firstPartDayOff"].ToString()) - r;
                                if (totalDayOffAmount > totalDayOffRemain)
                                {
                                    errorList.Add(errorCode(202, "於請假日期，特休時數僅剩餘" + totalDayOffRemain.ToString() + "小時"));
                                }
                            }
                            /* Scenario 2
                             * 請假月日為到職月日之後
                             */
                            else if (dayOffStartDate >= relevantWorkDate)
                            {

                                //2021疫情請假特例，讓同仁可預支假期，不分上下年度--2022恢復正常
                                for (int i = 1; i < tbAppSummary.Rows.Count; i++)
                                {
                                    if (tbAppSummary.Rows[i].Cells[0].InnerText == "特休")
                                    {
                                        string usedAmount = tbAppSummary.Rows[i].Cells[3].InnerText.Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2);
                                        r += decimal.Parse(usedAmount);
                                    }
                                }
                                for (int i = 1; i < tbInProgressSummary.Rows.Count; i++)
                                {
                                    if (tbInProgressSummary.Rows[i].Cells[1].InnerText == "特休" && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
                                    {
                                        string usedAmount = tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2);
                                        r += decimal.Parse(usedAmount);
                                    }
                                }
                                totalDayOffRemain = decimal.Parse(Session["firstPartDayOff"].ToString()) + decimal.Parse(Session["secondPartDayOff"].ToString()) - r;
                                if (totalDayOffAmount > totalDayOffRemain)
                                {
                                    errorList.Add(errorCode(202, "今年特休時數僅剩餘" + totalDayOffRemain.ToString() + "小時"));
                                }
                            }
                        }
                        else
                        {
                            errorList.Add(errorCode(202, "於請假日期尚未任職滿六個月，故無特休"));
                        }
                    }
                }
                else if (totalDayOffAmount > (Decimal.TryParse(lblDayOffRemainAmount.Text, out r) ? Convert.ToDecimal(lblDayOffRemainAmount.Text) : 0))
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
                    + " AND APPLICATION_STATUS_ID<>'98'"
                    + " AND APPLICATION_STATUS_ID<>'99'"
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

            if (ddlDayOffType.SelectedValue == "08" && totalDayOffAmount != Convert.ToDecimal(hdnNormalWorkHour.Value)) //208. 產假須為整天
            {
                errorList.Add(errorCode(208));
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
            if (ckbTyphoonDayNoSub.Checked)
            {
                string temp = "PS.颱風假期間";
                if (string.IsNullOrWhiteSpace(txtReason.Text.Trim()))
                {
                    txtReason.Text += temp;
                }
                else
                {
                    txtReason.Text += Environment.NewLine + temp;
                }
            }
            if (lblDayOffRemainAmount.Text == "" && needFunctionalSubstitute)
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
            else if (lblDayOffRemainAmount.Text != "" && needFunctionalSubstitute)
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
            else if (lblDayOffRemainAmount.Text == "" && !needFunctionalSubstitute)
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
                    funcSub = "N/A",
                    reason = txtReason.Text.Trim()
                });
            }
            else if (lblDayOffRemainAmount.Text != "" && !needFunctionalSubstitute)
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
                    funcSub = "N/A",
                    reason = txtReason.Text.Trim()
                });
            }
            fillDayOffApplicationTable(lstDayOffAppSummary);
            Session["lstDayOffAppSummary"] = lstDayOffAppSummary;
            //re-calculate day off remain display
            if (lblDayOffRemainAmount.Text != "")
            {
                //decimal sumFromList = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue).Sum(x => double.Parse(x.amountUsing));
                //decimal sumFromList = GetDayOffTimeInApp(DateTime.Parse(txtDatePickerStart.Text).Year, DateTime.Parse(txtDatePickerStart.Text).Month);
                //lblDayOffRemainAmount.Text = (Convert.ToDecimal(hdnDayOffTimeRemainBeforeSubmit.Value) - sumFromList).ToString();
                CheckRemainingDayOffTime();
            }
            txtReason.Text = string.Empty;
            ckbTyphoonDayNoSub.Checked = false;
        }
    }
    /// <summary>
    /// 選擇假別改變，如有設定，會讀取該假別剩餘時數
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDayOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRemainingDayOffTime();
    }
    /// <summary>
    /// 日期改變也須檢查假別剩餘時數
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtDatePickerStart_TextChanged(object sender, EventArgs e)
    {
        CheckRemainingDayOffTime();
    }
    protected void CheckRemainingDayOffTime()
    {
        //顯示選擇假別剩餘時數            
        //未選擇、婚假、喪假、陪產假、產檢假、產假、安胎假、颱風假 並非每年都有的假，所以忽略假期天數的限制，由人事檢查
        //2017.09.04 將特休也排到不須檢查剩餘量，因為新制(每年分成兩分，有不同天數的假)計算很困難
        //Error 202 條件
        if (ddlDayOffType.SelectedValue.ToString() == "0"
            || ddlDayOffType.SelectedValue.ToString() == "03"
            || ddlDayOffType.SelectedValue.ToString() == "06"
            || ddlDayOffType.SelectedValue.ToString() == "07"
            || ddlDayOffType.SelectedValue.ToString() == "08"
            || ddlDayOffType.SelectedValue.ToString() == "09"
            || ddlDayOffType.SelectedValue.ToString() == "11"
            || ddlDayOffType.SelectedValue.ToString() == "12"
            || ddlDayOffType.SelectedValue.ToString() == "14"
            || ddlDayOffType.SelectedValue.ToString() == "15"
            || ddlDayOffType.SelectedValue.ToString() == "19")
        {
            lblDayOffRemainType.Text = "";
            lblDayOffRemainAmount.Text = "";
            lblDayOffRemainUnit.Text = "";
            DataTable dt = new DataTable();
            dt = GetDayOffTypeInfo(ddlDayOffType.SelectedValue);
            SetDayOffUnit(dt);
        }
        else
        {
            try
            {
                //DataTable dt = new DataTable();
                //string query = "";

                //using (SqlConnection conn = new SqlConnection(NZconnectionString))
                //{
                //    /*JOIN APPLICATION DB, AND SUBTRACT OFF THE AMOUNT PRESENT IN ALL ACTIVE APPLICATIONS*/
                //    conn.Open();
                //    query = ";WITH INPROGRESS_APP"
                //        + " AS"
                //        + " ("
                //        + " SELECT APP.APPLICANT_ID 'APPLICANT_ID',YEAR(APP.DAYOFF_START_TIME) 'YEAR',APP.DAYOFF_ID 'DAYOFF_ID',CONVERT(DECIMAL(5,2),COALESCE(SUM(APP.DAYOFF_TOTAL_TIME),0)) 'TOTAL_DAYOFF_TIME'"
                //        + " ,CASE APP.DAYOFF_ID"
                //        + " WHEN '02' THEN '小時'"
                //        + " WHEN '03' THEN '小時'"
                //        + " ELSE CASE MC.MC004"
                //        + " 	WHEN '1' THEN '天'"
                //        + " 	WHEN '2' THEN '小時'"
                //        + " 	END"
                //        + " END 'UNIT'"
                //        + " FROM NZ_ERP2.dbo.HR360_DAYOFFAPPLICATION_APPLICATION APP"
                //        + " LEFT JOIN PALMC MC ON APP.DAYOFF_ID=MC.MC001"
                //        + " WHERE APP.APPLICANT_ID=@ID"
                //        + " AND YEAR(APP.DAYOFF_START_TIME)=@YEAR"
                //        + " AND APP.APPLICATION_STATUS_ID<>'07'"
                //        + " AND APP.APPLICATION_STATUS_ID<>'98'"
                //        + " AND APP.APPLICATION_STATUS_ID<>'08'"
                //        + " GROUP BY APP.APPLICANT_ID,YEAR(APP.DAYOFF_START_TIME),APP.DAYOFF_ID,MC.MC004"
                //        + " )"
                //        + " SELECT '02' 'ID'"
                //        + " ,CONVERT(DECIMAL(5,2),TK.TK005) 'YEARLY_ALLOWED_AMOUNT'"
                //        + " ,CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)) 'YEARLY_AMOUNT_USED'"
                //        + " ,COALESCE(APP.TOTAL_DAYOFF_TIME,0) 'IN_PROGRESS_AMOUNT'"
                //        + " ,'小時' 'TIME_UNIT'"
                //        + " FROM PALTK TK"
                //        + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='02'"
                //        + " LEFT JOIN INPROGRESS_APP APP ON APP.DAYOFF_ID='02'"
                //        + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                //        + " GROUP BY TK.TK005,APP.TOTAL_DAYOFF_TIME"
                //        + " UNION"
                //        + " SELECT '03' 'ID',CONVERT(DECIMAL(5,2),TK.TK003*8),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0))"
                //        + " ,COALESCE(APP.TOTAL_DAYOFF_TIME,0),'小時'"
                //        + " FROM PALTK TK"
                //        + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='03'"
                //        + " LEFT JOIN INPROGRESS_APP APP ON APP.DAYOFF_ID='03'"
                //        + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                //        + " GROUP BY TK.TK003,APP.TOTAL_DAYOFF_TIME"
                //        + " UNION"
                //        + " SELECT MC.MC001 'ID',CONVERT(DECIMAL(5,2),MC.MC007),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0))"
                //        + " ,COALESCE(APP.TOTAL_DAYOFF_TIME,0)"
                //        + " ,CASE MC.MC004"
                //        + " WHEN '1' THEN '天'"
                //        + " WHEN '2' THEN '小時'"
                //        + " END"
                //        + " FROM PALMC MC"
                //        + " LEFT JOIN PALTL TL ON TL.TL001=@ID AND TL.TL002=@YEAR AND TL.TL004=MC.MC001"
                //        + " LEFT JOIN INPROGRESS_APP APP ON MC.MC001=APP.DAYOFF_ID"
                //        + " WHERE MC.MC001<>'02' AND MC.MC001<>'03'"
                //        + " GROUP BY MC.MC001,MC.MC007,MC.MC004,APP.TOTAL_DAYOFF_TIME";
                //    SqlCommand cmd = new SqlCommand(query, conn);
                //    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString().Trim());
                //    cmd.Parameters.AddWithValue("@YEAR", DateTime.Now.Year.ToString().Trim());
                //    //cmd.Parameters.AddWithValue("@YEAR", txtDatePickerStart.Text.Substring(0,4));
                //    using (SqlDataReader dr = cmd.ExecuteReader())
                //    {
                //        if (dr.HasRows)
                //        {
                //            dt.Load(dr);
                //        }
                //    }
                //}
                //if (dt.Rows.Count > 0)
                //{
                //    DisplayRemainingDayOffTime(dt, Int16.Parse(txtDatePickerStart.Text.Substring(0, 4)), Int16.Parse(txtDatePickerStart.Text.Substring(5, 2)));
                //}
                DataTable dt = new DataTable();
                dt = GetDayOffTypeInfo(ddlDayOffType.SelectedValue);
                SetDayOffUnit(dt);

                if (dt.Rows[0]["DAY_OFF_ACCUMULATION_PERIOD"].ToString() == "1")
                {
                    lblDayOffRemainAmount.Text = (GetDayOffRemainingQuota(dt, DateTime.Parse(txtDatePickerStart.Text).Year, DateTime.Parse(txtDatePickerStart.Text).Month)
                        - GetDayOffTimeInProgress(DateTime.Parse(txtDatePickerStart.Text).Year, DateTime.Parse(txtDatePickerStart.Text).Month)
                        - GetDayOffTimeInApp(DateTime.Parse(txtDatePickerStart.Text).Year, DateTime.Parse(txtDatePickerStart.Text).Month)).ToString();
                }
                else
                {
                    lblDayOffRemainAmount.Text = (GetDayOffRemainingQuota(dt, DateTime.Parse(txtDatePickerStart.Text).Year)
                        - GetDayOffTimeInProgress(DateTime.Parse(txtDatePickerStart.Text).Year)
                        - GetDayOffTimeInApp(DateTime.Parse(txtDatePickerStart.Text).Year)).ToString();
                }
                lblDayOffRemainType.Text = dt.Rows[0]["NAME"].ToString() + "剩餘";
                lblDayOffRemainUnit.Text = hdnDayOffTypeUnit.Value;

            }
            catch
            {

            }
        }
    }

    protected DataTable GetDayOffTypeInfo(string dayOffID)
    {
        DataTable dt = new DataTable();
        string query = "SELECT MC001 'ID'"
                    + " ,MC002 'NAME'"
                    + " ,MC004 'DAY_OFF_UNIT'"
                    + " ,MC005 'DAY_OFF_ACCUMULATION_PERIOD'"
                    + " ,MC007 'ANNUAL_QUOTA'"
                    + " ,MC017 'MONTHLY_QUOTA'"
                    + " FROM PALMC"
                    + " WHERE MC001=@ID";
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", dayOffID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }
    protected void SetDayOffUnit(DataTable dt)
    {
        if (dt.Rows[0]["DAY_OFF_UNIT"].ToString().Trim() == "1")
        {
            hdnDayOffTypeUnit.Value = " 天";
        }
        else
        {
            hdnDayOffTypeUnit.Value = "小時";
        }
    }
    protected decimal GetDayOffRemainingQuota(DataTable dt, int year, int month = 0)
    {
        decimal r = 0;
        string query = "";
        if (month == 0)
        {
            if (dt.Rows[0]["ID"].ToString().Trim() == "02")
            {
                query = "SELECT CONVERT(DECIMAL(5,2),TK.TK005)-CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)) 'AMOUNT_LEFT'"
                        + " FROM PALTK TK"
                        + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='02'"
                        + " WHERE TK.TK001=@ApplicantID"
                        + " AND TK.TK002=@Year"
                        + " GROUP BY TK.TK005";
            }
            else
            {
                query = " SELECT CONVERT(DECIMAL(5,2),MC.MC007)-CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0))"
                        + " FROM PALMC MC"
                        + " LEFT JOIN PALTL TL ON TL.TL001=@ApplicantID AND TL.TL002=@Year AND TL.TL004=MC.MC001"
                        + " WHERE MC.MC001=@DayOffID"
                        + " GROUP BY MC.MC001,MC.MC007,MC.MC004";
            }
        }
        else
        {
            query = "SELECT CONVERT(DECIMAL(5,2),MC.MC017)-CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)) 'AMOUNT_LEFT'"
                + " FROM PALMC MC"
                + " LEFT JOIN PALTL TL ON TL.TL001=@ApplicantID AND TL.TL002=@Year AND TL.TL003=@Month AND TL.TL004=MC.MC001"
                + " WHERE MC.MC001=@DayOffID"
                + " GROUP BY MC.MC001,MC.MC017,MC.MC004";
        }
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicantID", Session["erp_id"].ToString());
            cmd.Parameters.AddWithValue("@DayOffID", dt.Rows[0]["ID"].ToString());
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month.ToString("D2"));
            r = cmd.ExecuteScalar() == null ? 0 : Convert.ToDecimal(cmd.ExecuteScalar());
        }
        return r;
    }
    protected decimal GetDayOffTimeInProgress(int year, int month = 0)
    {
        decimal r = 0;
        string query = "SELECT CONVERT(DECIMAL(5,2),COALESCE(SUM(APP.DAYOFF_TOTAL_TIME),0)) 'TOTAL_DAYOFF_TIME'"
                    + " FROM HR360_DAYOFFAPPLICATION_APPLICATION APP";
        string where = " WHERE APP.APPLICATION_STATUS_ID<>'07'"
                    + " AND APP.APPLICATION_STATUS_ID<>'98'"
                    + " AND APP.APPLICATION_STATUS_ID<>'99'"
                    + " AND APP.APPLICANT_ID=@ApplicantID"
                    + " AND APP.DAYOFF_ID=@DayOffID"
                    + " AND YEAR(APP.DAYOFF_START_TIME)=@Year";
        if (month != 0)
        {
            where += " AND MONTH(APP.DAYOFF_START_TIME)=@Month";
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query + where, conn);
            cmd.Parameters.AddWithValue("@ApplicantID", Session["erp_id"].ToString());
            cmd.Parameters.AddWithValue("@DayOffID", ddlDayOffType.SelectedValue);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month.ToString("D2"));
            r = cmd.ExecuteScalar() == null ? Convert.ToDecimal(cmd.ExecuteScalar()) : 0;
        }

        return r;
    }
    protected decimal GetDayOffTimeInApp(int year, int month = 0)
    {
        decimal r = 0;
        if (month == 0)
        {
            r = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue && x.startTime.Year == year).Sum(x => decimal.Parse(x.amountUsing));
        }
        else
        {
            r = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue && x.startTime.Year == year && x.startTime.Month == month).Sum(x => decimal.Parse(x.amountUsing));
        }

        return r;
    }
    //protected void DisplayRemainingDayOffTime(DataTable dt, int year, int month)
    //{
    //    DataRow[] row;
    //    row = dt.Select("ID=" + ddlDayOffType.SelectedValue.ToString());

    //    //未選擇、婚假、喪假、陪產假、產檢假、產假、安胎假 並非每年都有的假，所以忽略假期天數的限制，由人事檢查
    //    //2017.09.04 將特休也排到不須檢查剩餘量，因為新制(每年分成兩分，有不同天數的假)計算很困難
    //    if (row.Any())
    //    {
    //        if (ddlDayOffType.SelectedValue.ToString() == "03"
    //            || ddlDayOffType.SelectedValue.ToString() == "06"
    //            || ddlDayOffType.SelectedValue.ToString() == "07"
    //            || ddlDayOffType.SelectedValue.ToString() == "08"
    //            || ddlDayOffType.SelectedValue.ToString() == "09"
    //            || ddlDayOffType.SelectedValue.ToString() == "15"
    //            || ddlDayOffType.SelectedValue.ToString() == "19")
    //        {
    //            lblDayOffRemainType.Text = "";
    //            lblDayOffRemainAmount.Text = "";
    //            lblDayOffRemainUnit.Text = "";
    //            hdnDayOffTypeUnit.Value = row[0][4].ToString();
    //        }
    //        else
    //        {
    //            if (Convert.ToDouble(row[0][1]) > 0)
    //            {
    //                //decimal yearSumFromList = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue).Sum(x => double.Parse(x.amountUsing));
    //                decimal yearSumFromList = GetDayOffTimeInApp(DateTime.Parse(txtDatePickerStart.Text).Year, DateTime.Parse(txtDatePickerStart.Text).Month);

    //                hdnDayOffTimeRemainBeforeSubmit.Value = (Convert.ToDecimal(row[0]["YEARLY_ALLOWED_AMOUNT"]) - Convert.ToDecimal(row[0]["YEARLY_AMOUNT_USED"]) - Convert.ToDecimal(row[0]["IN_PROGRESS_AMOUNT"])).ToString();
    //                lblDayOffRemainType.Text = ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3).Trim() + "剩餘";
    //                lblDayOffRemainAmount.Text = (Convert.ToDecimal(hdnDayOffTimeRemainBeforeSubmit.Value) - yearSumFromList).ToString();
    //                lblDayOffRemainUnit.Text = row[0][4].ToString();
    //            }
    //            else
    //            {
    //                lblDayOffRemainType.Text = "";
    //                lblDayOffRemainAmount.Text = "";
    //                lblDayOffRemainUnit.Text = "";
    //            }
    //            hdnDayOffTypeUnit.Value = row[0][4].ToString();
    //        }
    //    }
    //    else
    //    {
    //        lblDayOffRemainType.Text = "";
    //        lblDayOffRemainAmount.Text = "N/A";
    //        lblDayOffRemainUnit.Text = "";
    //    }
    //}
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
            error += "未選擇假別";
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
            error += "假單不可跨天";
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
            error += "你已於此時段代理他人，不可請假";
        }
        else if (errorID == 108)
        {
            error += "請事假未填寫請假原因";
        }
        else if (errorID == 109)
        {
            error += "請假時間非上班時間，請確認";
        }
        else if (errorID == 110)
        {
            error += "請假年份僅限於本年度，請與人事部確認";
        }
        else if (errorID == 111)
        {
            error += "補單超過三天期限(含今日)";
        }
        else if (errorID == 201)
        {
            error += "請假時數為0，請確認";
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
        else if (errorID == 207)
        {
            error += "班別尚未建立，請與人事部確認";
        }
        else if (errorID == 208)
        {
            error += "產假需為整天";
        }
        else if (errorID == 999)
        {
            error += "班別為跨天班，需人工請假";
        }
        return error;
    }
    protected string errorCode(int errorID, string s)
    {
        string error = errorCode(errorID) + " (" + s + ")";
        return error;
    }
    protected bool IsDataTableEmpty(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
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
            string query = ";WITH CTE"
                        + " AS"
                        + " ("
                        + " SELECT A.APPLICATION_ID"
                        + " ,A.DAYOFF_NAME"
                        + " ,A.DAYOFF_START_TIME"
                        + " ,A.DAYOFF_END_TIME"
                        + " ,CONVERT(NVARCHAR(20),A.DAYOFF_TOTAL_TIME)+DAYOFF_TIME_UNIT 'DAYOFF_TOTAL_TIME'"
                        + " ,COALESCE(MV.MV002,'N/A') 'FUNC_SUB'"
                        + " ,B.NAME"
                        + " ,A.NEXT_REVIEWER+' '+MV2.MV002 'NEXT_REVIEWER'"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION A"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_STATUS B ON A.APPLICATION_STATUS_ID=B.ID"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON A.FUNCTIONAL_SUBSTITUTE_ID=MV.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MV2 ON A.NEXT_REVIEWER=MV2.MV001"
                        + " WHERE A.APPLICANT_ID=@APPLICANT"
                        + " AND A.APPLICATION_STATUS_ID<>'07'"
                        + " AND A.APPLICATION_STATUS_ID<>'98'"
                        + " AND A.APPLICATION_STATUS_ID<>'99'"
                        + " )"
                        + " SELECT *, CASE"
                        + " WHEN EXISTS"
                        + " ("
                        + " SELECT *"
                        + " FROM NZ.dbo.PALTF TF"
                        + " WHERE TF.TF001=@APPLICANT"
                        + " AND TF.TF002=CONVERT(NVARCHAR(8),CTE.DAYOFF_START_TIME,112)"
                        + " AND TF.TF008=CONVERT(NVARCHAR(3),CTE.DAYOFF_TOTAL_TIME)" +
                        " AND TF.TF005=REPLACE(CONVERT(NVARCHAR(5),CTE.DAYOFF_START_TIME,108),':','')"
                        + " )"
                        + " THEN '已登入'"
                        + " ELSE '未登入'"
                        + " END AS 'ERP狀態'"
                        + " FROM CTE"
                        + " ORDER BY APPLICATION_ID";
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
        newHeaderCell.InnerText = "下個簽核者";
        newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        newHeaderRow.Controls.Add(newHeaderCell);
        newHeaderCell = new HtmlTableCell("th");
        newHeaderCell.InnerText = "ERP狀態";
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
            cell.InnerText = dt.Rows[i][7].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = dt.Rows[i][8].ToString();
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
            string query = ";WITH CTE"
                        + " AS"
                        + " ("
                        + " SELECT APP.APPLICATION_ID,APP.APPLICANT_ID,MV.MV002,APP.DAYOFF_NAME"
                        + " ,APP.DAYOFF_START_TIME,APP.DAYOFF_END_TIME,CONVERT(NVARCHAR(20),APP.DAYOFF_TOTAL_TIME)+APP.DAYOFF_TIME_UNIT 'DAYOFF_TOTAL_TIME'"
                        + " ,COALESCE(MV2.MV002,'N/A') 'FUNCTIONAL_SUBSTITUTE'"
                        + " ,CASE"
                        + " WHEN APP.REASON='' THEN '無'"
                        + " ELSE '查看原因'"
                        + " END AS 'HAS_REASON'"
                        + " ,APP.REASON"
                        + " ,SUBSTRING(ST.NAME,1,5) 'APP_STATUS'"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION APP"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_STATUS ST ON APP.APPLICATION_STATUS_ID=ST.ID"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON APP.APPLICANT_ID=MV.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MV2 ON APP.FUNCTIONAL_SUBSTITUTE_ID=MV2.MV001"
                        + " WHERE CONVERT(INT,APP.APPLICATION_STATUS_ID)<7"
                        + " AND APP.NEXT_REVIEWER=@ID"
                        + " )"
                        + " SELECT *, CASE"
                        + " WHEN EXISTS"
                        + " ("
                        + " 	SELECT *"
                        + " 	FROM NZ.dbo.PALTF TF"
                        + " 	WHERE TF.TF001=CTE.APPLICANT_ID"
                        + " 	AND TF.TF002=CONVERT(NVARCHAR(8),CTE.DAYOFF_START_TIME,112)"
                        + " 	AND TF.TF008=CONVERT(NVARCHAR(3),CTE.DAYOFF_TOTAL_TIME)" +
                        " AND TF.TF005=REPLACE(CONVERT(NVARCHAR(5),CTE.DAYOFF_START_TIME,108),':','')"
                        + " )"
                        + " THEN '已登入'"
                        + " ELSE '未登入'"
                        + " END AS 'ERP狀態'"
                        + " FROM CTE"
                        + " ORDER BY CTE.APP_STATUS,CTE.APPLICATION_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        int count = tbApprovalPending.Rows.Count;
        for (int i = 1; i < count; i++)
        {
            tbApprovalPending.Rows.RemoveAt(1);
        }
        //tbApprovalPending.Rows.Clear();

        //HtmlTableRow newHeaderRow = new HtmlTableRow();
        //newHeaderRow.Attributes.Add("style", "background-color:lightblue; color:white;");
        //HtmlTableCell newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "假單ID";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "申請人ID";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "申請人";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "假別";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "開始時間";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "結束時間";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "請假總量";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "代理人";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "請假原因";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "簽核階段";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "ERP狀態";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //Button btn = new Button();
        ////btn.ID = "btnApprove" + i;
        //btn.Text = "簽核";
        //btn.CssClass = "btn btn-success";
        //btn.OnClientClick = "javascript:return confirmApprove();";
        //btn.Click += new EventHandler(btnApprove_Click);
        //newHeaderCell.Controls.Add(btn);
        //newHeaderCell.Attributes.Add("style", "text-align:center;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //newHeaderCell = new HtmlTableCell("th");
        //newHeaderCell.InnerText = "";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //tbApprovalPending.Controls.Add(newHeaderRow);
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
                cell.Attributes.Add("style", "text-align:center;color:aqua; cursor:pointer;");
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
            cell.InnerText = dt.Rows[i][11].ToString();
            cell.Attributes.Add("style", "text-align:center;");
            newRow.Controls.Add(cell);
            //cell = new HtmlTableCell();
            //Button btn = new Button();
            //btn.ID = "btnApprove" + i;
            //btn.Text = "簽核";
            //btn.CssClass = "btn btn-success";
            //btn.OnClientClick = "javascript:return confirmApprove();";
            ////btn.Click += new EventHandler(btnApprove_Click);
            //cell.Controls.Add(btn);
            //cell.Attributes.Add("style", "text-align:center;");
            //newRow.Controls.Add(cell);
            cell = new HtmlTableCell();
            Button btn = new Button();
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
            //double sumFromList = lstDayOffAppSummary.Where(x => x.typeID == ddlDayOffType.SelectedValue).Sum(x => double.Parse(x.amountUsing));
            //decimal sumFromList = GetDayOffTimeInApp(DateTime.Parse(txtDatePickerStart.Text).Year, DateTime.Parse(txtDatePickerStart.Text).Month);
            //lblDayOffRemainAmount.Text = (Convert.ToDecimal(hdnDayOffTimeRemainBeforeSubmit.Value) - sumFromList).ToString();
            CheckRemainingDayOffTime();
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
            string query = "SELECT APPLICATION_STATUS_ID" +
                " FROM HR360_DAYOFFAPPLICATION_APPLICATION" +
                " WHERE APPLICATION_ID=@APP_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", withdrawID);
            string appStatusId = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();

            query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B (APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,STATUS_ID)"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID, @STATUS_ID"
                        + " )";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APPLICATION_ID", withdrawID);
            cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
            cmd.Parameters.AddWithValue("@EXECUTOR_ID", Session["erp_id"].ToString());
            cmd.Parameters.AddWithValue("@ACTION_ID", "04");
            cmd.Parameters.AddWithValue("@STATUS_ID", (Convert.ToInt16(appStatusId) + 1).ToString("D2"));
            cmd.ExecuteNonQuery();
            query = "UPDATE HR360_DAYOFFAPPLICATION_APPLICATION"
                + " SET APPLICATION_STATUS_ID=@STATUS,NEXT_REVIEWER=''"
                + " WHERE APPLICATION_ID=@APPLICATION";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@STATUS", "98");
            cmd.Parameters.AddWithValue("@APPLICATION", withdrawID);
            cmd.ExecuteNonQuery();
        }
        SendEmailNotification(withdrawID, 2);
        fillInProgressApplicationTable();
    }
    /// <summary>
    /// Approve application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string nextReviewer;
        string erpId = Session["erp_id"].ToString();
        string[] list = hdnApprovalPendingSelection.Value.ToString().Split(',');
        if (list.Count() > 0)
        {
            foreach (string s in list)
            {
                string approveID = s;
                string approveID_status = "";
                string applicantID = "";
                string memberOf = "";
                DataTable dtApplicant = new DataTable();
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    //get current state of the application
                    string query = "SELECT APP.APPLICATION_STATUS_ID,HIER.MEMBEROF,APP.APPLICANT_ID,APP.FUNCTIONAL_SUBSTITUTE_ID"
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
                if (dtApplicant.Rows[0]["FUNCTIONAL_SUBSTITUTE_ID"].ToString() == "N/A" && approveID_status == "02")
                {
                    nextReviewer = "SYSTEM";
                }
                else
                {
                    nextReviewer = erpId;
                }

                do
                {
                    using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                    {
                        conn.Open();
                        //insert approval trail to DB
                        string query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B (APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,STATUS_ID)"
                                    + " VALUES(@APP_ID,GETDATE(),@EXE_ID,'02',@STATUS_ID)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@APP_ID", approveID);
                        cmd.Parameters.AddWithValue("@EXE_ID", nextReviewer);
                        cmd.Parameters.AddWithValue("@STATUS_ID", approveID_status);
                        cmd.ExecuteNonQuery();
                    }
                    //update application status to next stage
                    if (Convert.ToInt16(approveID_status) < 7)
                    {
                        approveID_status = (Convert.ToInt16(approveID_status) + 1).ToString("D2");
                    }
                    if (approveID_status == "03")  //代理人簽核通過，搜尋第一層簽核人(部門最高負責人 BELOW RANK 7)
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
                            //第一層簽核 限制:RANK 2-7、RANK高於申請者RANK、同部門或可替換部門
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
                                + " AND MV.MV004<>'B-C'"  //SPECIAL RULE FOR 上膠部，因為沒人會電腦，故上膠部請假直接到第二層，由生管口頭詢問上膠主管 (DELETE WHEN SITUATION CHANGES)
                                + " AND MV.MV004<>'A-SD'"   //KELVEN不需要簽核，業務部主管簽核由SYSTEM直接過 (DELETE WHEN SITUATION CHANGES)
                                + " ORDER BY HIER.[RANK] DESC" +
                                " ,case" +  //當有相通的部門時，如果兩個部門有同rank的主管，則會優先選擇與請假者同部門的主管
                                " when MV.MV004 = @DEPT then 1" +
                                " else 2" +
                                " end" +
                                " ,MV.MV001";
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
                    else if (approveID_status == "04")  //第一層通過，搜尋第二層審核者(廠長/副廠長/生管主任)
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
                    else if (approveID_status == "05")  //第二層通過，搜尋第三層審核者(人事主任)
                    {
                        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                        {
                            conn.Open();
                            //簽核限制:人事主任 RANK 7 //HR(2018.10.08 HR:NONE)
                            string query = "SELECT MV.MV001,MV.MV002,MV.MV004,MK.MK001,MK.MK002,HIER.[RANK],HIER.MEMBEROF"
                                        + " FROM NZ.dbo.CMSMV MV"
                                        + " LEFT JOIN NZ.dbo.CMSMK MK ON MV.MV001=MK.MK002"
                                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPROVAL_HIERARCHY HIER ON MK.MK001=HIER.JOB_ID"
                                        + " WHERE MV.MV022=''"
                                        + " AND MV.MV001<>@ID"
                                        //+ " AND MK.MK001='A20'"           
                                        //+ " AND HIER.[RANK]=7";
                                        + " AND MV.MV001='" + currentHREmployeeID + "'" //HR NEED FIX: 如無人事主任(A20)，則指定人事專員審核
                                        + " AND MK.MK001='A21'";
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
                    else if (approveID_status == "06")  //第三層通過，搜尋第四層審核者(副總)
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
                    else if (approveID_status == "07")
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
                    System.Threading.Thread.Sleep(1000);    //sleeps for 1 second before continuing so trail records can be ordered by time
                } while (nextReviewer == "SYSTEM" && Convert.ToInt16(approveID_status) < 7); //stops when somebody is required to review the application,
                //or when approval status reached 7, which means the application is approved by everyone necessary
                //automatic approval should only happen on 1st and 2nd level,
                //3rd and 4th level should always have reviewer (人事主管/副總)
                if (approveID_status != "07")
                {
                    SendEmailNotification(approveID, 1);
                }
                else
                {
                    SendEmailNotification(approveID, 4);
                }
            }

            //fill table after selection iteration is done, or it'll mess up the table row selection
            fillApprovalTable();
        }
        else
        {

        }
    }
    /// <summary>
    /// Deny application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeny_Click(object sender, EventArgs e)
    {
        Control btn = (Control)sender;
        //Button btn = (Button)sender;
        string btnID = btn.ID;
        string denyID = "";
        //退回可以在簽核過程產生，或於簽核結束後，由ADM或HR因特殊原因產生-兩者得到denyID的過程不同
        if (btnID == "btnSearch_Deny")  //簽核結束後，經由查詢功能產生的退回
        {
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            denyID = ((Label)row.Cells[0].FindControl("lblAppId")).Text;
        }
        else
        {
            int rowNumber = Convert.ToInt16(btn.ID.Substring(7, btn.ID.Length - 7));
            denyID = tbApprovalPending.Rows[rowNumber + 1].Cells[0].InnerText;
        }
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT APPLICATION_STATUS_ID" +
                " FROM HR360_DAYOFFAPPLICATION_APPLICATION" +
                " WHERE APPLICATION_ID=@APP_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", denyID);
            string appStatusId = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();

            //insert deny trail to DB
            query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B(APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,MEMO,STATUS_ID)"
                        + " VALUES(@APP_ID,GETDATE(),@EXE_ID,'03',@MEMO,@STATUS_ID)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", denyID);
            cmd.Parameters.AddWithValue("@EXE_ID", Session["erp_id"].ToString());
            cmd.Parameters.AddWithValue("@MEMO", hdnDenyReason.Value);
            cmd.Parameters.AddWithValue("@STATUS_ID", (Convert.ToInt16(appStatusId) + 1).ToString("D2"));
            cmd.ExecuteNonQuery();
            query = "UPDATE HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " SET APPLICATION_STATUS_ID=@STATUS,NEXT_REVIEWER=@REVIEWER"
                        + " WHERE APPLICATION_ID=@APPLICATION";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@STATUS", "98");
            cmd.Parameters.AddWithValue("@REVIEWER", "");
            cmd.Parameters.AddWithValue("@APPLICATION", denyID);
            cmd.ExecuteNonQuery();
        }
        SendEmailNotification(denyID, 3);
        if (btnID == "btnSearch_Deny")
        {
            btnSearchSubmit_Click(sender, e);
        }
        fillInProgressApplicationTable();
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
        string query;
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
                        + " @APPLICATION_ID,@APPLICATION_DATE,@APPLICANT_ID,@DAYOFF_ID,@DAYOFF_NAME,@DAYOFF_START_TIME,@DAYOFF_END_TIME,@DAYOFF_TOTAL_TIME,@DAYOFF_TIME_UNIT,@FUNC_SUB_ID,@STATUS_ID,@NEXT_REVIEWER,@REASON"
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
                    cmd.Parameters.AddWithValue("@STATUS_ID", "02");
                    if (dayoff.funcSub == "N/A")
                    {
                        cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.funcSub);
                        cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.funcSub);
                    }
                    else
                    {
                        int pos = 2;    //get the index of the first char after the first 2 chars that is not number (正式員工編碼為xxxx, PT員工編碼為PTxxxx, 需要用此方法抓出完整員編)
                        while (Char.IsNumber(dayoff.funcSub[pos]))
                        {
                            ++pos;
                        }
                        cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.funcSub.Substring(0, pos));
                        cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.funcSub.Substring(0, pos));
                    }
                    cmd.Parameters.AddWithValue("@REASON", dayoff.reason);
                    cmd.ExecuteNonQuery();
                    query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B (APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,STATUS_ID)"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID, @STATUS_ID"
                        + " )";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@APPLICATION_ID", uid);
                    cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
                    cmd.Parameters.AddWithValue("@EXECUTOR_ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@ACTION_ID", "01");
                    cmd.Parameters.AddWithValue("@STATUS_ID", "01");
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) //ID 重複錯誤
                    {
                        query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " VALUES ("
                        + " @APPLICATION_ID,@APPLICATION_DATE,@APPLICANT_ID,@DAYOFF_ID,@DAYOFF_NAME,@DAYOFF_START_TIME,@DAYOFF_END_TIME,@DAYOFF_TOTAL_TIME,@DAYOFF_TIME_UNIT,@FUNC_SUB_ID,@STATUS_ID,@NEXT_REVIEWER,@REASON"
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
                        cmd.Parameters.AddWithValue("@STATUS_ID", "02");
                        if (dayoff.funcSub == "N/A")
                        {
                            cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.funcSub);
                            cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.funcSub);
                        }
                        else
                        {
                            int pos = 2;    //get the index of the first char after the first 2 chars that is not number (正式員工編碼為xxxx, PT員工編碼為PTxxxx, 需要用此方法抓出完整員編)
                            while (Char.IsNumber(dayoff.funcSub[pos]))
                            {
                                ++pos;
                            }
                            cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.funcSub.Substring(0, pos));
                            cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.funcSub.Substring(0, pos));
                        }
                        cmd.Parameters.AddWithValue("@REASON", dayoff.reason);
                        cmd.ExecuteNonQuery();
                        query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B (APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,STATUS_ID)"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID, @STATUS_ID"
                        + " )";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@APPLICATION_ID", uid);
                        cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
                        cmd.Parameters.AddWithValue("@EXECUTOR_ID", Session["erp_id"].ToString());
                        cmd.Parameters.AddWithValue("@ACTION_ID", "01");
                        cmd.Parameters.AddWithValue("@STATUS_ID", "01");
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {

                    }
                }
            }
            if (dayoff.funcSub == "N/A")    //此單不需要代理人，可直接執行代理人APPROVE
            {
                hdnApprovalPendingSelection.Value = string.Empty;
                hdnApprovalPendingSelection.Value = uid;
                btnApprove_Click(sender, e);
            }
            else
            {
                SendEmailNotification(uid, 1);
            }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('申請已送出');", true);
        lstDayOffAppSummary.Clear();
        fillDayOffApplicationTable(lstDayOffAppSummary);
        fillInProgressApplicationTable();
    }
    /// <summary>
    /// Initial loading for div search section
    /// </summary>
    protected void SearchSection_Init_Load()
    {
        hdnIsSearchFieldVisible.Value = "1";
        string nonAdminCondition = "";
        if (Session["erp_id"].ToString() != currentHREmployeeID      //HR
            && Session["erp_id"].ToString() != "0015"   //小榆
            && Session["erp_id"].ToString() != "0080"
            && Session["erp_id"].ToString() != "0006"
            && Session["erp_id"].ToString() != "0007") //管理部跟HR可以查詢全部人的歷史資料
        {
            nonAdminCondition = " AND MV.MV001=@ID";
        }
        else
        {
            nonAdminCondition = "";
        }
        string query = "SELECT MV.MV001+' '+MV.MV002 'display',MV.MV001 'value','0' 'list_order'"
                    + " FROM CMSMV MV"
                    + " WHERE MV.MV022=''"
                    + " AND MV.MV001<>'0000'"
                    + " AND MV.MV001<>'0006'"
                    + " AND MV.MV001<>'0007'"
                    + " AND MV.MV001<>'0098'"  //這些人不會請假
                    + nonAdminCondition
                    //以下為離職員工query
                    + " UNION"
                    + " SELECT MV.MV001+' '+MV.MV002+'(已離職)' 'display',MV.MV001 'value','1' 'list_order'"
                    + " FROM CMSMV MV"
                    + " WHERE MV.MV022<>''"
                    + " AND MV.MV001<>'0000'"
                    + " AND MV.MV001<>'0006'"
                    + " AND MV.MV001<>'0007'"
                    + " AND MV.MV001<>'0098'"
                    + nonAdminCondition;


        using (SqlConnection conn = new SqlConnection(NZconnectionString))  //FILL ddlSearch_Parameter_ApplicantID
        {
            conn.Open();
            query += " ORDER BY 'list_order','value'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ddlSearch_Parameter_ApplicantID.DataTextField = "display";
            ddlSearch_Parameter_ApplicantID.DataValueField = "value";
            ddlSearch_Parameter_ApplicantID.DataSource = dt;
            ddlSearch_Parameter_ApplicantID.DataBind();
        }
        if (!(Session["erp_id"].ToString() != currentHREmployeeID  //HR
            && Session["erp_id"].ToString() != "0015"   //小榆
            && Session["erp_id"].ToString() != "0080"
            && Session["erp_id"].ToString() != "0006"
            && Session["erp_id"].ToString() != "0007")) //管理部跟HR可以查詢全部人的歷史資料
        {
            ddlSearch_Parameter_ApplicantID.Items.Insert(0, new ListItem("全部人員", "ALL"));
            ddlSearch_Parameter_ApplicantID.Enabled = true;
        }
        else
        {
            ddlSearch_Parameter_ApplicantID.Enabled = false;
        }
        ddlSearch_Parameter_ApplicantID.SelectedIndex = 0;
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            query = "SELECT ID 'value', NAME 'display'"
                + " FROM HR360_DAYOFFAPPLICATION_APPLICATION_STATUS"
                + " ORDER BY ID";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ddlSearch_Parameter_ApplicationStatus.DataTextField = "display";
            ddlSearch_Parameter_ApplicationStatus.DataValueField = "value";
            ddlSearch_Parameter_ApplicationStatus.DataSource = dt;
            ddlSearch_Parameter_ApplicationStatus.DataBind();
        }
        ddlSearch_Parameter_ApplicationStatus.Items.Insert(0, new ListItem("全部", "ALL"));
        ddlSearch_Parameter_ApplicationStatus.SelectedIndex = 0;
    }
    /// <summary>
    /// Initial loading for div application section
    /// </summary>
    protected void ApplicationSection_Init_Load()
    {
        Session["lstDayOffAppSummary"] = lstDayOffAppSummary;
        hdnIsPostBack.Value = "0";  //variable for determining whether this page is a postback for jquery
        hdnIsDayOffAppVisible.Value = "0";  //variable for determining whether the div DayOffApp is visible
        //txtMessage.Text = "*假單不得跨天"
        //    + Environment.NewLine + "*請假半小時無須代理人"
        //    + Environment.NewLine + "*休假最小單位為:辦公室0.5小時;製造部門0.5天"
        //    + Environment.NewLine + "*請假前須確認當天工作進度已安排人員支援，且有代理人簽名"
        //    + Environment.NewLine + "*請事假、病假過多者，會影響到年終獎金之發放"
        //    + Environment.NewLine + "*未經主管核簽及人事核准，假單不生效";
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
            if (userInfo.Rows[0][0].ToString() == "1")  //性別為男性
            {
                query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                    + " FROM PALMC"
                    + " WHERE PALMC.MC001<>'08'" //產假
                    + " AND PALMC.MC001<>'16'" //生理假
                    + " AND PALMC.MC001<>'19'" //安胎假
                    + " AND PALMC.MC001<>'10'" //曠職
                    + " AND PALMC.MC001<>'18'" //育嬰留停
                    + " AND PALMC.MC001<>'21'" //遲到(HR將會移除此選項)
                    + " ORDER BY PALMC.MC001";
            }
            else //女性無陪產假
            {
                query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                    + " FROM PALMC"
                    + " WHERE PALMC.MC001<>'09'" //陪產假
                    + " AND PALMC.MC001<>'10'" //曠職
                    + " AND PALMC.MC001<>'18'" //育嬰留停
                    + " AND PALMC.MC001<>'21'" //遲到(HR將會移除此選項)
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
        if (ds.Tables[1].Rows.Count == 0)   //此人沒代理人，用小K
        {
            ddlDayOffFuncSub.Items.Add(new ListItem("0080 王君凱", "0080"));
        }
        else
        {
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                ddlDayOffFuncSub.Items.Add(new ListItem(ds.Tables[1].Rows[i][0].ToString().Trim(), ds.Tables[1].Rows[i][1].ToString().Trim()));
            }
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
            if (!exceptionListHourForProduction.Contains(Session["erp_id"].ToString()))
            {
                hdnDayOffTimeRestraint.Value = "4";
                hdnOfficeOrProduction.Value = "production";
            }
            else
            {
                hdnDayOffTimeRestraint.Value = "0.5";
                hdnOfficeOrProduction.Value = "production";
            }
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
    /// <summary>
    /// Send out email to people who need to be notified after certain action
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="appStatus"></param>
    /// <param name="recipientId"></param>
    protected void SendEmailNotification(string appId, int appStatus)
    {
        //Get recipient ID depending on status
        List<string> recipientId = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = ";WITH TRAIL"
                        + " AS"
                        + " ("
                        + " SELECT B.APPLICATION_ID 'APPLICATION_ID',B.EXECUTOR_ID 'EXECUTOR_ID',B.ACTION_ID 'ACTION_ID',B.MEMO 'ACTION_MEMO'"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B B"
                        + " INNER JOIN (SELECT APPLICATION_ID,MAX(ACTION_TIME) ACTION_TIME FROM HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B GROUP BY APPLICATION_ID) C ON B.APPLICATION_ID=C.APPLICATION_ID AND B.ACTION_TIME=C.ACTION_TIME"
                        + " )"
                        + " SELECT APP.APPLICATION_ID"
                        + " ,APP.DAYOFF_NAME"
                        + " ,APP.APPLICATION_DATE"
                        + " ,APP.APPLICANT_ID"
                        + " ,MV.MV002 'APPLICANT_NAME'"
                        + " ,APP.DAYOFF_START_TIME"
                        + " ,APP.DAYOFF_END_TIME"
                        + " ,COALESCE(APP.NEXT_REVIEWER,'') 'NEXT_REVIEWER'"
                        + " ,COALESCE(MV2.MV002,'') 'REVIEWER_NAME'"
                        + " ,APP.FUNCTIONAL_SUBSTITUTE_ID"
                        + " ,MV3.MV002 'FUNC_SUB_NAME'"
                        + " ,APP.APPLICATION_STATUS_ID"
                        + " ,[STATUS].NAME 'STATUS_NAME'"
                        + " ,TRAIL.EXECUTOR_ID"
                        + " ,COALESCE(MV4.MV002,'SYSTEM') 'EXECUTOR_NAME'"
                        + " ,TRAIL.ACTION_ID"
                        + " ,TRAIL_A.NAME 'ACTION_NAME'"
                        + " ,COALESCE(TRAIL.ACTION_MEMO,'') 'ACTION_MEMO'"
                        + " ,COALESCE(APP.REASON,'') 'REASON'"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION APP"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON APP.APPLICANT_ID=MV.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MV2 ON APP.NEXT_REVIEWER=MV2.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MV3 ON APP.FUNCTIONAL_SUBSTITUTE_ID=MV3.MV001"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_STATUS [STATUS] ON APP.APPLICATION_STATUS_ID=[STATUS].ID"
                        + " LEFT JOIN TRAIL ON APP.APPLICATION_ID=TRAIL.APPLICATION_ID"
                        + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_A TRAIL_A ON TRAIL.ACTION_ID=TRAIL_A.ID"
                        + " LEFT JOIN NZ.dbo.CMSMV MV4 ON TRAIL.EXECUTOR_ID=MV4.MV001"
                        + " WHERE APP.APPLICATION_ID=@APP_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", appId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        recipientId.Add(currentHREmployeeID);    //HR
        recipientId.Add("0080");    //Kevin for the sake of testing mail delivery function
        //status 1:新申請/一般簽核通過(HR&下個簽核者) 2:申請撤銷(HR&代理人) 3:申請退回(HR&申請人&代理人) 4:最後一層簽核通過(HR&申請人&代理人)
        switch (appStatus)
        {
            case 1:
                recipientId.Add(dt.Rows[0]["NEXT_REVIEWER"].ToString());
                break;
            case 2:
                //recipientId.Add(dt.Rows[0]["NEXT_REVIEWER"].ToString());
                if (dt.Rows[0]["FUNCTIONAL_SUBSTITUTE_ID"].ToString() != "N/A")
                {
                    recipientId.Add(dt.Rows[0]["FUNCTIONAL_SUBSTITUTE_ID"].ToString());
                }
                break;
            case 3:
            case 4:
                recipientId.Add(dt.Rows[0]["APPLICANT_ID"].ToString());
                if (dt.Rows[0]["FUNCTIONAL_SUBSTITUTE_ID"].ToString() != "N/A")
                {
                    recipientId.Add(dt.Rows[0]["FUNCTIONAL_SUBSTITUTE_ID"].ToString());
                }
                break;
            default:
                break;
        }
        //Organize list in recipientId
        recipientId.Distinct();
        int chrissyIndex = recipientId.IndexOf("0007");
        if (chrissyIndex != -1)
        {
            recipientId.RemoveAt(chrissyIndex);
        }
        //Get Email address of all recipients
        List<string> recipientEmailList = new List<string>();
        foreach (string recipient in recipientId)
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                string query = "SELECT COALESCE(MV.MV020,'')"
                            + " FROM CMSMV MV"
                            + " WHERE MV.MV001=@RECIPIENT_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RECIPIENT_ID", recipient);

                if (cmd.ExecuteScalar() != null && !string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()))
                {
                    recipientEmailList.Add(cmd.ExecuteScalar().ToString());
                }
            }
        }
        //拼湊收件人郵箱
        string to = "";
        for (int i = 0; i < recipientEmailList.Count; i++)
        {
            to += recipientEmailList[i];
            if (i != recipientEmailList.Count - 1)
            {
                to += ",";
            }
        }
        string from = "Administrator@nizing.com.tw";
        //主旨depends on appStatus
        //status 1:新申請/一般簽核通過 2:申請撤銷(BY申請者) 3:申請退回(BY簽核者) 4:最後一層簽核通過(副總)        
        string subject = "假單" + dt.Rows[0]["APPLICATION_ID"].ToString() + ":";
        switch (appStatus)
        {
            case 1:
                subject += dt.Rows[0]["APPLICANT_NAME"].ToString() + "請" + dt.Rows[0]["DAYOFF_NAME"].ToString() + "，待" + dt.Rows[0]["REVIEWER_NAME"].ToString() + "簽核";
                break;
            case 2:
                subject += dt.Rows[0]["APPLICANT_NAME"].ToString() + "撤銷申請";
                break;
            case 3:
                subject += dt.Rows[0]["EXECUTOR_NAME"].ToString() + "退回申請";
                break;
            case 4:
                subject += dt.Rows[0]["APPLICANT_NAME"].ToString() + "請" + dt.Rows[0]["DAYOFF_NAME"].ToString() + "，由" + dt.Rows[0]["FUNC_SUB_NAME"].ToString() + "代理，簽核通過";
                break;
            default:
                break;
        }

        //內文
        string body = "請假單號: " + dt.Rows[0]["APPLICATION_ID"].ToString() + "\n";
        body += "申請時間: " + dt.Rows[0]["APPLICATION_DATE"].ToString() + "\n";
        body += "開始時間: " + dt.Rows[0]["DAYOFF_START_TIME"].ToString() + "\n";
        body += "結束時間: " + dt.Rows[0]["DAYOFF_END_TIME"].ToString() + "\n";
        body += "請假原因: " + dt.Rows[0]["REASON"].ToString() + "\n";
        body += "簽核狀態: " + dt.Rows[0]["STATUS_NAME"].ToString() + "\n";
        body += "最後動作執行者: " + dt.Rows[0]["EXECUTOR_NAME"].ToString() + "\n";
        body += "最後動作備註: " + dt.Rows[0]["ACTION_MEMO"].ToString() + "\n";
        body += "下個簽核者: " + dt.Rows[0]["REVIEWER_NAME"].ToString() + "\n\n";
        body += "請登入 http://www.nizing.com.tw/hr360/login.aspx > \"我要請假\" 確認細節";


        // create the email message
        MailMessage completeMessage = new MailMessage(from, to, subject, body);

        Thread email = new Thread(delegate ()
                {
                    SendEmail(to, from, subject, body);
                });
        email.IsBackground = true;
        email.Start();
    }

    private void SendEmail(string to, string from, string subject, string body)
    {
        using (MailMessage mm = new MailMessage(from, to))
        {
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            client.Host = "192.168.10.239";
            client.UseDefaultCredentials = true;
            client.Send(mm);
        }
    }
    /// <summary>
    /// Perform application search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchSubmit_Click(object sender, EventArgs e)
    {
        DateTime startTime = new DateTime();
        DateTime endTime = new DateTime();
        DataTable dt = new DataTable();
        string query = "";
        string condition = "";
        string order = "";

        if (!DateTime.TryParse(txtSearch_Parameter_StartDate.Text, out startTime))
        {
            startTime = new DateTime(2010, 1, 1);
        }
        if (!DateTime.TryParse(txtSearch_Parameter_EndDate.Text, out endTime))
        {
            endTime = new DateTime(9000, 12, 31);
        }
        else
        {
            endTime = endTime.AddDays(1);
        }
        query = ";WITH APP_LAST_ACTION_TIME"
            + " AS"
            + " ("
            + " SELECT APPLICATION_ID,MAX(ACTION_TIME) 'LAST_ACTION_TIME'"
            + " FROM HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B"
            + " GROUP BY APPLICATION_ID"
            + " )"
            + " , CTE"
            + " AS ("
            + " SELECT DISTINCT APP.APPLICATION_ID"
            + " ,APP.APPLICANT_ID"
            + " ,APP.APPLICATION_DATE"
            + " ,[LAST_ACTION].LAST_ACTION_TIME"
            + " ,MV.MV002 'APPLICANT_NAME'"
            + " ,APP.DAYOFF_NAME"
            + " ,APP.DAYOFF_START_TIME"
            + " ,APP.DAYOFF_END_TIME"
            + " ,CONVERT(NVARCHAR(20),APP.DAYOFF_TOTAL_TIME)+DAYOFF_TIME_UNIT 'DAYOFF_TOTAL_TIME'"
            + " ,COALESCE(MV2.MV002,'N/A') 'FUNC_SUB_NAME'"
            + " ,APP.REASON"
            + " ,[STATUS].NAME 'STATUS'"
            + " ,COALESCE(MV3.MV002,'N/A') 'NEXT_REVIEWER'"
            + " FROM HR360_DAYOFFAPPLICATION_APPLICATION APP"
            + " LEFT JOIN NZ.dbo.CMSMV MV ON APP.APPLICANT_ID=MV.MV001"
            + " LEFT JOIN NZ.dbo.CMSMV MV2 ON APP.FUNCTIONAL_SUBSTITUTE_ID=MV2.MV001"
            + " LEFT JOIN NZ.dbo.CMSMV MV3 ON APP.NEXT_REVIEWER=MV3.MV001"
            + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_STATUS [STATUS] ON APP.APPLICATION_STATUS_ID=[STATUS].ID"
            + " LEFT JOIN HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B [TRAIL] ON APP.APPLICATION_ID = [TRAIL].APPLICATION_ID"
            + " LEFT JOIN APP_LAST_ACTION_TIME [LAST_ACTION] ON APP.APPLICATION_ID = LAST_ACTION.APPLICATION_ID";
        if (!String.IsNullOrWhiteSpace(txtSearch_Parameter_StartDate.Text) && String.IsNullOrWhiteSpace(txtSearch_Parameter_EndDate.Text))
        {
            condition = " WHERE APP.DAYOFF_START_TIME >= @STARTTIME";
        }
        else if (!String.IsNullOrWhiteSpace(txtSearch_Parameter_EndDate.Text) && String.IsNullOrWhiteSpace(txtSearch_Parameter_StartDate.Text))
        {
            condition = " WHERE APP.DAYOFF_START_TIME <= @ENDTIME";
        }
        else if (!String.IsNullOrWhiteSpace(txtSearch_Parameter_StartDate.Text) && !String.IsNullOrWhiteSpace(txtSearch_Parameter_EndDate.Text))
        {
            condition = " WHERE APP.DAYOFF_START_TIME BETWEEN @STARTTIME AND @ENDTIME";
        }
        else if (String.IsNullOrWhiteSpace(txtSearch_Parameter_StartDate.Text) && String.IsNullOrWhiteSpace(txtSearch_Parameter_EndDate.Text))
        {
            condition = "";
        }
        if (String.IsNullOrWhiteSpace(txtSearch_Parameter_StartDate.Text) && String.IsNullOrWhiteSpace(txtSearch_Parameter_EndDate.Text))
        {
            if (ddlSearch_Parameter_ApplicantID.SelectedValue != "ALL")
            {
                condition += " WHERE APP.APPLICANT_ID=@APPLICANT_ID";
            }
        }
        else
        {
            if (ddlSearch_Parameter_ApplicantID.SelectedValue != "ALL")
            {
                condition += " AND APP.APPLICANT_ID=@APPLICANT_ID";
            }
        }
        if (String.IsNullOrWhiteSpace(txtSearch_Parameter_StartDate.Text) && String.IsNullOrWhiteSpace(txtSearch_Parameter_EndDate.Text) && ddlSearch_Parameter_ApplicantID.SelectedValue == "ALL")
        {
            if (ddlSearch_Parameter_ApplicationStatus.SelectedValue != "ALL")
            {
                condition += " WHERE APP.APPLICATION_STATUS_ID=@STATUS_ID";
            }
        }
        else
        {
            if (ddlSearch_Parameter_ApplicationStatus.SelectedValue != "ALL")
            {
                condition += " AND APP.APPLICATION_STATUS_ID=@STATUS_ID";
            }
        }
        query += condition;
        query += " )"
                + " SELECT *, CASE"
                + " WHEN EXISTS"
                + " ("
                + " 	SELECT *"
                + " 	FROM NZ.dbo.PALTF TF"
                + " 	WHERE TF.TF001=CTE.APPLICANT_ID"
                + " 	AND TF.TF002=CONVERT(NVARCHAR(8),CTE.DAYOFF_START_TIME,112)"
                + " 	AND TF.TF008=CONVERT(NVARCHAR(3),CTE.DAYOFF_TOTAL_TIME)" +
                " AND TF.TF005=REPLACE(CONVERT(NVARCHAR(5),CTE.DAYOFF_START_TIME,108),':','')"
                + " )"
                + " THEN '已登入'"
                + " ELSE '未登入'"
                + " END AS 'ERP_STATUS'"
                + " FROM CTE";
        order = " ORDER BY APPLICATION_ID DESC";
        query += order;
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@STARTTIME", startTime);
            cmd.Parameters.AddWithValue("@ENDTIME", endTime);
            cmd.Parameters.AddWithValue("@APPLICANT_ID", ddlSearch_Parameter_ApplicantID.SelectedValue);
            cmd.Parameters.AddWithValue("@STATUS_ID", ddlSearch_Parameter_ApplicationStatus.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        if (dt.Rows.Count > 0)
        {
            DataView dv = dt.DefaultView;
            if (this.ViewState["SortExpression"] != null)
            {
                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());
            }
        }
        gvSearchResult.DataSource = dt;
        gvSearchResult.DataBind();

        //看報告
        try
        {
            if (Session["erp_id"].ToString() != "0007"      //Chrissy
                && Session["erp_id"].ToString() != "0080"   //Kevin
                && Session["erp_id"].ToString() != "0015"   //小榆
                && Session["erp_id"].ToString() != currentHREmployeeID   //HR
                )
            {
                gvSearchResult.Columns[13].Visible = false;
            }
        }
        catch
        {
            Server.Transfer("~/hr360/no_permission.aspx"); //session expires and value stored in session value disappears
        }
    }
    /// <summary>
    /// Disable "退回" button for rows whose status is "退回" or "撤銷"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btn = (LinkButton)e.Row.Cells[12].FindControl("btnSearch_Deny");
            if (
                ((Label)e.Row.Cells[9].FindControl("lblAppStatus")).Text == "退回"
                || ((Label)e.Row.Cells[9].FindControl("lblAppStatus")).Text == "撤銷"
                )
            {
                btn.Attributes.Remove("href");
                btn.CssClass = "btn disabled";
                btn.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
                btn.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";
                if (btn.Enabled != false)
                {
                    btn.Enabled = false;
                }

                if (btn.OnClientClick != null)
                {
                    btn.OnClientClick = null;
                }
            }
            ((Label)e.Row.Cells[4].FindControl("lblDayoffStartTime")).Text = (DateTime.Parse(((Label)e.Row.Cells[4].FindControl("lblDayoffStartTime")).Text)).ToString("yyyy/MM/dd HH:mm");
            ((Label)e.Row.Cells[5].FindControl("lblDayoffEndTime")).Text = (DateTime.Parse(((Label)e.Row.Cells[5].FindControl("lblDayoffEndTime")).Text)).ToString("yyyy/MM/dd HH:mm");
            ((Label)e.Row.Cells[10].FindControl("lblApplicationTime")).Text = (DateTime.Parse(((Label)e.Row.Cells[10].FindControl("lblApplicationTime")).Text)).ToString("yyyy/MM/dd HH:mm");
            ((Label)e.Row.Cells[11].FindControl("lblLastActionTime")).Text = (DateTime.Parse(((Label)e.Row.Cells[11].FindControl("lblLastActionTime")).Text)).ToString("yyyy/MM/dd HH:mm");

            //Get Application Trail Information
            string appId = ((Label)e.Row.Cells[0].FindControl("lblAppId")).Text;
            GridView gv = (GridView)e.Row.FindControl("gvAppTrail");
            gv.DataSource = GetApplicationTrail(appId);
            gv.DataBind();
        }
    }
    protected void gvSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearchResult.PageIndex = e.NewPageIndex;
        btnSearchSubmit_Click(sender, e);
    }

    protected void gvSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sort"))
        {
            if (ViewState["SortExpression"] != null)
            {
                if (this.ViewState["SortExpression"].ToString() == e.CommandArgument.ToString())
                {
                    if (ViewState["SortOrder"].ToString() == "ASC")
                    {
                        ViewState["SortOrder"] = "DESC";
                    }
                    else
                    {
                        ViewState["SortOrder"] = "ASC";
                    }
                }
                else
                {
                    ViewState["SortOrder"] = "ASC";
                    ViewState["SortExpression"] = e.CommandArgument.ToString();
                }
            }
            else
            {
                ViewState["SortExpression"] = e.CommandArgument.ToString();
                ViewState["SortOrder"] = "ASC";
            }
        }
        btnSearchSubmit_Click(sender, e);
    }

    private DataTable GetApplicationTrail(string s)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();

            string query = "select TrailB.APPLICATION_ID, TrailB.ACTION_TIME, actionAppStatus.NAME 'STATUS', TrailB.EXECUTOR_ID, TrailA.NAME, TrailB.MEMO" +
                " from HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B TrailB" +
                " left join HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_A TrailA on TrailB.ACTION_ID = TrailA.ID" +
                " left join HR360_DAYOFFAPPLICATION_APPLICATION_STATUS actionAppStatus on TrailB.STATUS_ID = actionAppStatus.ID" +
                " where TrailB.APPLICATION_ID = @appId" +
                " order by TrailB.ACTION_TIME";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@appId", s);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

}