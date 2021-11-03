using System;
using System.Collections.Generic;
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
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    //List<DayOff> lstDayOffAppSummary = new List<DayOff>();    
    string HREmpId = "0142"; //current HR code;
    double employeeWorkHour = 8;    //員工正常工作時數
    List<string> exceptionList111 = new List<string>(); //三天內請假錯誤例外清單
    List<string> exceptionList202designated = new List<string>(); //剩餘假期不足錯誤例外清單(特休)
    List<string> exceptionList202makeup = new List<string>(); //剩餘假期不足錯誤例外清單(補休)
    List<string> exceptionList107 = new List<string>(); //已當其他人代理人錯誤例外清單
    List<string> exceptionList110 = new List<string>(); //請假年分限本年度例外清單
    List<string> exceptionListHourForProduction = new List<string>();   //例外清單:可用小時計假的線廠人員(阿豪0160)

    [Serializable()]
    public class DayOff
    {
        public DayOffType dayOffType { set; get; }
        public DateTime startTime { set; get; }
        public DateTime endTime { set; get; }
        public double dayOffTimespan { set; get; }
        public Tuple<string, string> functionalSubstitute { set; get; }
        public string reason { set; get; }
        public bool isTyphoonDayChecked { set; get; }
        public bool isTyphoonDay()
        {
            return dayOffType.id == "11" || isTyphoonDayChecked;
        }
        //不需要代理人條件
        //2018.06.13 請假半小時
        //2018.07.12 颱風假
        public bool needFunctionalSubstitute()
        {
            return !(dayOffTimespan <= 0.5 || isTyphoonDay());
        }
    }

    [Serializable()]
    public class DayOffType
    {
        public string id { set; get; }
        public string name { set; get; }
        public string dayOffUnit { set; get; }        //1:天 2:小時
        public string accumulationTimespanUnit { set; get; }    //1:月 2:年
        public double monthlyAllowance { set; get; }    //每月允許數量
        public double annualAllowance { set; get; }     //每年允許數量
    }

    public class DayOffDay
    {
        public DateTime date { set; get; }
        public int dayOffSetting { set; get; }  //1:休全天 2:休半天 3:不休
        public string workshift { set; get; }   //班別
        public DateTime workBeginTime { set; get; }
        public DateTime workEndTime { set; get; }
        public DateTime breakBeginTime { set; get; }
        public DateTime breakEndTime { set; get; }
        public double workTimespan()    //上班時數
        {
            return (workEndTime - workBeginTime).TotalHours;
        }
        public bool isWorkshiftEndNextDay()   //班別是否跨天
        {
            return workBeginTime > workEndTime;
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        List<DayOff> dayOff = new List<DayOff>();
        int i = 0;
        foreach (HtmlGenericControl div in divApplicationFormList.Controls.OfType<HtmlGenericControl>())
        {
            string dayOffTypeId = ((HtmlInputHidden)div.FindControl("dayOffTypeId_" + i.ToString())).Value;
            string[] dayOffTime = ((HtmlGenericControl)div.FindControl("dayOffTime_" + i.ToString())).InnerText.Split('~');
            DateTime startTime = Convert.ToDateTime(((HtmlGenericControl)div.FindControl("dayOffDate_" + i.ToString())).InnerText + " " + dayOffTime[0]);
            DateTime endTime = Convert.ToDateTime(((HtmlGenericControl)div.FindControl("dayOffDate_" + i.ToString())).InnerText + " " + dayOffTime[1]);
            DayOffDay dayOffDayInfo = GetDayOffDayInfo(startTime);
            double dayOffTimeSpan = GetApplicationDayOffHours(dayOffDayInfo, startTime, endTime);
            Tuple<string, string> functionalSubstitute = Tuple.Create(((HtmlInputHidden)div.FindControl("functionalSubstituteId_" + i.ToString())).Value, ((HtmlGenericControl)div.FindControl("functionalSubstituteName_" + i.ToString())).InnerText);
            string reason = ((HtmlGenericControl)div.FindControl("txtReason_" + i.ToString())).InnerText;
            bool isTyphoonDayChecked = Convert.ToBoolean(((HtmlInputHidden)div.FindControl("isTyphoonDayChecked_" + i.ToString())).Value);
            dayOff.Add(new DayOff
            {
                dayOffType = GetDayOffTypeInfo(dayOffTypeId),
                startTime = startTime,
                endTime = endTime,
                dayOffTimespan = dayOffTimeSpan,
                functionalSubstitute = functionalSubstitute,
                reason = reason,
                isTyphoonDayChecked = isTyphoonDayChecked
            });
            i++;
        }
        ViewState["lstDayOffAppSummary"] = dayOff;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //HR360LoggedUser.HR360Id = "0023";    //test only to avoid error on loading, delete after trial            
        //HR360LoggedUser.ERPId = "0023";
        //HR360LoggedUser.Company = "NIZING";
        //only use when opening check exception for certain persion
        //exceptionList111.Add("0067");
        //exceptionList202designated.Add("0112");
        //exceptionList107.Add("0162");
        //exceptionList110.Add("0067");
        //exceptionList202makeup.Add("0067");
        exceptionListHourForProduction.Add("0160"); //阿豪


        if (HR360LoggedUser.HR360Id.ToUpper().Trim() != "ADMIN")  //admin doesnt have the proper erp information and will crash the system
        {
            if (!IsPostBack)
            {
                ApplicationSection_Init_Load();
                InProgressSection_Init_Load();
                ApprovalSection_Init_Load();
                SearchSection_Init_Load();
                SearchDayOffRecords();
            }
            else
            {
                //ApplicationSection_PostBack_Load();
                InProgressSection_PostBack_Load();
                ApprovalSection_PostBack_Load();
            }

            if (ViewState["lstDayOffAppSummary"] != null)
            {
                fillDayOffApplicationTable((List<DayOff>)ViewState["lstDayOffAppSummary"]);
            }
            //Page.LoadComplete += new EventHandler(Page_LoadComplete);
        }

    }

    void Page_LoadComplete(object sender, EventArgs e)
    {
        //btnSearchSubmit_Click(sender, e);   //does search automatically everytime page finishes loading
    }


    //#region Test Area!!!!!!!!!! Test Methods ONLY!!!!!!
    ////Test for Different ID
    //protected void btnTestName_Click(object sender, EventArgs e)
    //{
    //    HR360LoggedUser.ERPId = txtTestName.Text.Trim();
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

    private List<Tuple<int, string>> ValidateSubmission(ref DayOffType dayOffTypeInfo, ref DayOffDay dayOffDayInfo, ref DayOff dayOffApplicationInfo, DateTime dayOffStartTime, DateTime dayOffEndTime)
    {
        List<Tuple<int, string>> errorList = new List<Tuple<int, string>>();
        List<DayOff> lstDayOffAppSummary = (List<DayOff>)ViewState["lstDayOffAppSummary"] == null ? new List<DayOff>() : (List<DayOff>)ViewState["lstDayOffAppSummary"];
        //Perform Input Checks (No DB Data)
        foreach (Tuple<int, string> error in PerformNoDBInputCheck(dayOffStartTime))
        {
            errorList.Add(error);
        }

        //開始檢查需要使用資料庫檢查的資料
        if (errorList.Count == 0)
        {
            dayOffTypeInfo = GetDayOffTypeInfo(ddlDayOffType.SelectedValue);
            dayOffDayInfo = GetDayOffDayInfo(dayOffStartTime);
            dayOffApplicationInfo = GetDayOffApplicationInfo(dayOffTypeInfo, dayOffDayInfo, dayOffStartTime, dayOffEndTime);

            if (dayOffDayInfo.date != null)
            {
                //測試請假時段合理性
                if (dayOffDayInfo.workTimespan() > 0)
                {
                    //測試假單是否跨天
                    if (dayOffDayInfo.isWorkshiftEndNextDay())
                    {
                        errorList.Add(errorCode(999));
                    }
                    else
                    {
                        //測試錯誤 109.請假時間非上班時間，請確認
                        if (dayOffStartTime < dayOffDayInfo.workBeginTime
                            || dayOffStartTime > dayOffDayInfo.workEndTime
                            || dayOffEndTime < dayOffDayInfo.workBeginTime
                            || dayOffEndTime > dayOffDayInfo.workEndTime)
                        {
                            errorList.Add(errorCode(109));
                        }
                    }

                    //颱風假任何人都可以0.5小時請假
                    if (dayOffApplicationInfo.isTyphoonDay())
                    {
                        //測試錯誤 203.請假時數不是基本請假時數的倍數(0.5hr)，表示請假時數不合規定
                        if (dayOffApplicationInfo.dayOffTimespan % 0.5 != 0)
                        {
                            errorList.Add(errorCode(203));
                        }
                    }
                    //非颱風假，線廠人員僅能下列四種時段請假
                    //上班 - 休息開始時間
                    //上班 - 休息結束時間
                    //休息開始時間 - 下班
                    //休息結束時間 - 下班
                    else
                    {
                        if (!exceptionListHourForProduction.Contains(HR360LoggedUser.ERPId)
                                    && hdnOfficeOrProduction.Value == "production")
                        {
                            if (!((dayOffApplicationInfo.startTime == dayOffDayInfo.workBeginTime
                                && (dayOffApplicationInfo.endTime == dayOffDayInfo.breakBeginTime
                                || dayOffApplicationInfo.endTime == dayOffDayInfo.breakEndTime))
                                ||
                                (dayOffApplicationInfo.startTime == dayOffDayInfo.breakBeginTime
                                || dayOffApplicationInfo.startTime == dayOffDayInfo.breakEndTime)
                                && dayOffApplicationInfo.endTime == dayOffDayInfo.workEndTime))
                            {
                                errorList.Add(errorCode(206));
                            }
                        }
                    }
                }
                else
                {
                    //測試錯誤 201.請假時數為0，請確認
                    errorList.Add(errorCode(201));
                }
            }
            else
            {
                errorList.Add(errorCode(207));  //Error 207:人員班別尚未建立
            }

            //測試代理人條件
            if (dayOffApplicationInfo.needFunctionalSubstitute())
            {
                //測試錯誤 106.代理人有事，不能代理
                if (!isFunctionalSubstituteAvailable(ddlDayOffFuncSub.SelectedValue, dayOffStartTime, dayOffEndTime))
                {
                    errorList.Add(errorCode(107));
                }

                //測試錯誤 107.申請人於此時段已代理他人，不可請假
                if (!exceptionList107.Contains(HR360LoggedUser.ERPId))
                {
                    if (!amIFreeForDayOff(HR360LoggedUser.ERPId, dayOffStartTime, dayOffEndTime))
                    {
                        errorList.Add(errorCode(107));
                    }
                }
            }

            //測試錯誤 202.剩餘假期不足  --如假別無量的限制，則無需執行此測試
            //特休及補休數量因人而異
            if (dayOffTypeInfo.monthlyAllowance > 0
                || dayOffTypeInfo.annualAllowance > 0
                || ddlDayOffType.SelectedValue == "02"
                || ddlDayOffType.SelectedValue == "03")
            {
                //double r;
                //double totalDayOffRemain;
                //補休(02)用此判斷
                if (ddlDayOffType.SelectedValue == "02")
                {
                    double remainingMakeupHours = GetMakeUpDayOffHours(HR360LoggedUser.ERPId, dayOffApplicationInfo.startTime.Year);
                    if (dayOffApplicationInfo.dayOffTimespan > remainingMakeupHours && !exceptionList202makeup.Contains(HR360LoggedUser.ERPId))
                    {
                        errorList.Add(errorCode(202, "補休時數剩餘" + remainingMakeupHours.ToString() + "小時"));
                    }
                }
                //特休(03)用此判斷 依據請假日期會有2種可能
                else if (ddlDayOffType.SelectedValue == "03")
                {
                    if (!exceptionList202designated.Contains(HR360LoggedUser.ERPId.Trim()))
                    {
                        /*
                         * 兩種可能性的計算方式                    
                         * 2021.10.25: 因COVID，請假不分上下年度
                         */
                        if (dayOffApplicationInfo.startTime >= HR360LoggedUser.StartDate.AddMonths(6))  //確認請假同仁已任職滿六個月
                        {
                            double[] remainingAnnualLeaveHours = GetAnnualLeaveHours(HR360LoggedUser.ERPId, HR360LoggedUser.StartDate, dayOffStartTime);
                            double annualLeaveHours = remainingAnnualLeaveHours[0] + remainingAnnualLeaveHours[1];
                            if (dayOffApplicationInfo.dayOffTimespan > annualLeaveHours)
                            {
                                errorList.Add(errorCode(202, "特休時數剩餘" + annualLeaveHours.ToString() + "小時"));
                            }
                        }
                        else
                        {
                            errorList.Add(errorCode(202, "於請假日期尚未任職滿六個月，故無特休"));
                        }
                    }
                }
                else if (dayOffTypeInfo.monthlyAllowance > 0 || dayOffTypeInfo.annualAllowance > 0)
                {
                    //計算非特休或補休的剩餘時數
                    double remainingHours = GetRamainingDayOffHours(dayOffTypeInfo, HR360LoggedUser.ERPId, dayOffStartTime);
                    errorList.Add(errorCode(202));
                }
            }

            //測試錯誤 204.請假週期已在此次請假清單內
            for (int i = 0; i < lstDayOffAppSummary.Count && !errorList.Any(a => a.Item1 == 204); i++)
            {
                if ((dayOffStartTime >= lstDayOffAppSummary[i].startTime && dayOffStartTime < lstDayOffAppSummary[i].endTime)
                    || (dayOffEndTime > lstDayOffAppSummary[i].startTime && dayOffEndTime <= lstDayOffAppSummary[i].endTime)
                    || (dayOffStartTime <= lstDayOffAppSummary[i].startTime && dayOffEndTime >= lstDayOffAppSummary[i].endTime))
                {
                    errorList.Add(errorCode(204));
                }
            }

            //測試錯誤 205.請假週期已在DB內
            if (isDayOffTimeInDatabase(HR360LoggedUser.ERPId, dayOffApplicationInfo))
            {
                errorList.Add(errorCode(205));
            }

            //208. 產假須為整天
            if (dayOffTypeInfo.id == "08" && dayOffApplicationInfo.dayOffTimespan != 8)
            {
                errorList.Add(errorCode(208));
            }
        }

        return errorList;
    }
    protected void btnDayOffAdd_Click(object sender, EventArgs e)
    {
        DateTime dayOffStartTime = Convert.ToDateTime(txtDayOffBeginDateTime.Text);  //申請開始請假時間
        DateTime dayOffEndTime = Convert.ToDateTime(dayOffStartTime.ToString("yyyy/MM/dd") + " " + txtDayOffEndTime.Text);  //申請結束請假時間
        DayOff dayOffApplicationInfo = new DayOff();
        DayOffDay dayOffDayInfo = new DayOffDay();
        DayOffType dayOffTypeInfo = new DayOffType();
        List<DayOff> lstDayOffAppSummary = (List<DayOff>)ViewState["lstDayOffAppSummary"] == null ? new List<DayOff>() : (List<DayOff>)ViewState["lstDayOffAppSummary"];

        List<Tuple<int, string>> errorList = ValidateSubmission(ref dayOffTypeInfo, ref dayOffDayInfo, ref dayOffApplicationInfo, dayOffStartTime, dayOffEndTime);

        divSystemMessage.Controls.Clear();

        //錯誤訊息集合顯示
        errorList = errorList.OrderBy(d => d).ToList();
        foreach (Tuple<int, string> error in errorList)
        {
            AppendSystemMessage(error.Item1.ToString() + " " + error.Item2, "error");
        }

        if (errorList.Count == 0) //都沒有錯誤，可執行之後的步驟
        {
            lblTest.Text = "application submitted";
            //將申請單資料依照申請內容正規化
            if (dayOffApplicationInfo.isTyphoonDay())
            {
                string temp = "PS.颱風假期間";
                if (string.IsNullOrWhiteSpace(dayOffApplicationInfo.reason))
                {
                    dayOffApplicationInfo.reason = temp;
                }
                else
                {
                    dayOffApplicationInfo.reason = dayOffApplicationInfo.reason.Trim() + Environment.NewLine + temp;
                }
            }
            if (!dayOffApplicationInfo.needFunctionalSubstitute())
            {
                dayOffApplicationInfo.functionalSubstitute = Tuple.Create("N/A", "N/A");
            }

            //將申請單加入此次的申請清單
            lstDayOffAppSummary.Add(dayOffApplicationInfo);

            fillDayOffApplicationTable(lstDayOffAppSummary);

            resetApplicationForm();
            upApplicationForm.Update();
        }
    }

    protected void resetApplicationForm()
    {
        ddlDayOffType.SelectedValue = "03";
        txtDayOffBeginDateTime.Text = string.Empty;
        txtDayOffEndTime.Text = string.Empty;
        ddlDayOffFuncSub.SelectedIndex = 0;
        ckbTyphoonDayNoSub.Checked = false;
        txtReason.Text = string.Empty;
    }

    protected List<Tuple<int, string>> PerformNoDBInputCheck(DateTime dayOffBegin)
    {
        List<Tuple<int, string>> errors = new List<Tuple<int, string>>();
        //測試錯誤 108.請事假未填寫請假原因
        if (ddlDayOffType.SelectedValue == "05" && txtReason.Text.Trim() == "")
        {
            errors.Add(errorCode(108));
        }

        //測試錯誤 110.僅能請本年度的假
        if (dayOffBegin.Year != DateTime.Today.Year
            && !exceptionList110.Contains(HR360LoggedUser.ERPId))
        {
            errors.Add(errorCode(110));
        }

        //測試錯誤 111.請假日期不得小於三日前
        if (dayOffBegin < DateTime.Today.AddDays(-3))
        {
            if (!exceptionList111.Contains(HR360LoggedUser.ERPId))
            {
                errors.Add(errorCode(111, "請假日期不得早於" + DateTime.Today.AddDays(-3).ToString("d", new CultureInfo("zh-TW"))));
            }
        }
        return errors;
    }

    protected DayOffType GetDayOffTypeInfo(string dayOffTypeId)
    {
        DayOffType dayoff = new DayOffType();
        DataTable dt = new DataTable();
        string query = "SELECT MC001 'id'"
                    + " ,MC002 'name'"
                    + " ,MC004 'dayOffUnit'"
                    + " ,MC005 'accumulationTimespanUnit'"
                    + " ,MC007 'annualAllowance'"
                    + " ,MC017 'monthlyAllowance'"
                    + " FROM PALMC"
                    + " WHERE MC001=@ID";
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", dayOffTypeId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        if (dt.Rows.Count > 0)
        {
            dayoff.id = dayOffTypeId;
            dayoff.name = dt.Rows[0]["Name"].ToString().Trim();
            dayoff.dayOffUnit = dt.Rows[0]["dayOffUnit"].ToString() == "1" ? "天" : "小時";
            dayoff.accumulationTimespanUnit = dt.Rows[0]["accumulationTimespanUnit"].ToString() == "1" ? "月" : "年";
            dayoff.monthlyAllowance = Convert.ToDouble(dt.Rows[0]["monthlyAllowance"].ToString());
            dayoff.annualAllowance = Convert.ToDouble(dt.Rows[0]["annualAllowance"].ToString());
        }
        return dayoff;
    }

    protected DayOffDay GetDayOffDayInfo(DateTime dayOffDate)
    {
        DayOffDay dayoff = new DayOffDay();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            //AMSMB:員工班別
            //CMSMP:行事曆細項
            //PALMK:班別資料設定作業
            string query = "SELECT MP.MP004 '日期'" +
                " ,MP.MP005 '放假別'" +
                " ,MB.MB0" + (Convert.ToInt16(dayOffDate.Day.ToString()) + 2).ToString("D2") + " '班別'" +
                " ,MK.MK003 '上班時間'" +
                " ,MK.MK004 '下班時間'" +
                " ,MK.MK009 '休息開始時間'" +
                " ,MK.MK010 '休息結束時間'" +
                " ,CASE" +
                " WHEN MK.MK003>MK.MK004 THEN 24.0-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,'00:00'),CONVERT(TIME,STUFF('1700', 3, 0, ':')))/60.0)+CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,'00:00'),CONVERT(TIME,STUFF('0100',3,0,':')))/60.0)-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK009, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK010, 3, 0, ':')))/60.0)" +
                " ELSE CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK003, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK004, 3, 0, ':')))/60.0)-CONVERT(DECIMAL(5,2),DATEDIFF(MINUTE,CONVERT(TIME,STUFF(MK.MK009, 3, 0, ':')),CONVERT(TIME,STUFF(MK.MK010, 3, 0, ':')))/60.0)" +
                " END '工作時數'" +
                " ,CASE" +
                " WHEN MK.MK003>MK.MK004 THEN '1'" +
                " ELSE '0'" +
                " END '跨天'" +
                " FROM AMSMB MB" +
                " LEFT JOIN CMSMP MP ON MP.MP001='3' AND MP.MP004=@YYYYMMDD AND MP.MP003=" + "MB.MB0" + (Convert.ToInt16(dayOffDate.Day.ToString()) + 2).ToString("D2") +
                " LEFT JOIN PALMK MK ON MB.MB0" + (Convert.ToInt16(dayOffDate.Day.ToString()) + 2).ToString("D2") + "=MK.MK001" +
                " WHERE MB.MB001=@ID" +
                " AND MB.MB002=@YYYYMM";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YYYYMMDD", dayOffDate.Date.ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
            cmd.Parameters.AddWithValue("@YYYYMM", dayOffDate.Date.ToString("yyyyMM"));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        if (dt.Rows.Count > 0)
        {
            dayoff.date = String.IsNullOrWhiteSpace(dt.Rows[dt.Rows.Count - 1]["日期"].ToString()) ? dayOffDate.Date : DateTime.ParseExact(dt.Rows[0]["日期"].ToString(), "yyyyMMdd", null);
            dayoff.dayOffSetting = String.IsNullOrWhiteSpace(dt.Rows[dt.Rows.Count - 1]["放假別"].ToString()) ? 3 : Convert.ToInt16(dt.Rows[0]["放假別"].ToString());
            dayoff.workshift = dt.Rows[0]["班別"].ToString();
            dayoff.workBeginTime = dayoff.date.Date + new TimeSpan(Convert.ToInt16(dt.Rows[0]["上班時間"].ToString().Substring(0, 2)), Convert.ToInt16(dt.Rows[0]["上班時間"].ToString().Substring(2, 2)), 0);
            dayoff.workEndTime = dayoff.date.Date + new TimeSpan(Convert.ToInt16(dt.Rows[0]["下班時間"].ToString().Substring(0, 2)), Convert.ToInt16(dt.Rows[0]["下班時間"].ToString().Substring(2, 2)), 0);
            if (dayoff.workBeginTime > dayoff.workEndTime)
            {
                dayoff.workEndTime = dayoff.workEndTime.AddDays(1);
            }
            dayoff.breakBeginTime = dayoff.date.Date + new TimeSpan(Convert.ToInt16(dt.Rows[0]["休息開始時間"].ToString().Substring(0, 2)), Convert.ToInt16(dt.Rows[0]["休息開始時間"].ToString().Substring(2, 2)), 0);
            dayoff.breakEndTime = dayoff.date.Date + new TimeSpan(Convert.ToInt16(dt.Rows[0]["休息結束時間"].ToString().Substring(0, 2)), Convert.ToInt16(dt.Rows[0]["休息結束時間"].ToString().Substring(2, 2)), 0);
            if (dayoff.breakBeginTime > dayoff.breakEndTime)
            {
                dayoff.breakEndTime = dayoff.breakEndTime.AddDays(1);
            }
        }
        return dayoff;
    }

    protected DayOff GetDayOffApplicationInfo(DayOffType dayOffType, DayOffDay dayOffDay, DateTime dayOffStart, DateTime dayOffEnd)
    {
        DayOff dayoff = new DayOff();
        dayoff.dayOffType = dayOffType;
        dayoff.startTime = dayOffStart;
        dayoff.endTime = dayOffEnd;
        dayoff.dayOffTimespan = GetApplicationDayOffHours(dayOffDay, dayoff.startTime, dayoff.endTime);
        dayoff.functionalSubstitute = Tuple.Create(ddlDayOffFuncSub.SelectedValue, ddlDayOffFuncSub.SelectedItem.Text);
        dayoff.reason = txtReason.Text.Trim();
        dayoff.isTyphoonDayChecked = ckbTyphoonDayNoSub.Checked;
        return dayoff;
    }

    //計算請假時數
    //回傳小數兩位數的double值
    protected double GetApplicationDayOffHours(DayOffDay dayOffDay, DateTime dayOffBegin, DateTime dayOffEnd)
    {
        double dayOffHours = 0;
        if (dayOffDay.dayOffSetting == 3)  //3是上班日，才會需要請假
        {
            if ((dayOffBegin <= dayOffDay.breakBeginTime
                && dayOffEnd <= dayOffDay.breakBeginTime)
                || (dayOffBegin >= dayOffDay.breakEndTime
                && dayOffEnd >= dayOffDay.breakEndTime))  //請假時間不與休息時間重疊
            {
                dayOffHours = Math.Round((dayOffEnd - dayOffBegin).TotalHours, 2);
            }
            else if (dayOffBegin < dayOffDay.breakBeginTime
                && dayOffEnd < dayOffDay.breakEndTime)
            {
                dayOffHours = Math.Round((dayOffEnd - dayOffBegin).TotalHours, 2) - Math.Round((dayOffEnd - dayOffDay.breakBeginTime).TotalHours, 2);
            }
            else if (dayOffBegin > dayOffDay.breakBeginTime
                && dayOffEnd > dayOffDay.breakEndTime)
            {
                dayOffHours = Math.Round((dayOffEnd - dayOffBegin).TotalHours, 2) - Math.Round((dayOffDay.breakEndTime - dayOffBegin).TotalHours, 2);
            }
            else if (dayOffBegin < dayOffDay.breakBeginTime
                 && dayOffEnd > dayOffDay.breakEndTime)
            {
                dayOffHours = Math.Round((dayOffEnd - dayOffBegin).TotalHours, 2) - Math.Round((dayOffDay.breakEndTime - dayOffDay.breakBeginTime).TotalHours, 2);
            }
            else if (dayOffBegin >= dayOffDay.breakBeginTime
                && dayOffEnd <= dayOffDay.breakEndTime)
            {
                dayOffHours = 0;
            }
        }
        return dayOffHours;
    }

    protected bool isFunctionalSubstituteAvailable(string functionalSubId, DateTime dayOffBegin, DateTime dayOffEnd)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT APPLICATION_ID"
                        + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                        + " WHERE (APPLICANT_ID=@ID)"  //代理人已請假
                        + " AND APPLICATION_STATUS_ID <> '98'"
                        + " AND APPLICATION_STATUS_ID <> '99'"
                        + " AND ((DAYOFF_START_TIME <= @STARTTIME AND DAYOFF_END_TIME > @STARTTIME)"
                        + " OR (DAYOFF_START_TIME < @ENDTIME AND DAYOFF_END_TIME >= @ENDTIME)"
                        + " OR (DAYOFF_START_TIME >= @STARTTIME AND DAYOFF_END_TIME <= @ENDTIME))";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", functionalSubId);
            cmd.Parameters.AddWithValue("@STARTTIME", dayOffBegin);
            cmd.Parameters.AddWithValue("@ENDTIME", dayOffEnd);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }

    protected bool amIFreeForDayOff(string empId, DateTime dayOffBegin, DateTime dayOffEnd)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
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
            cmd.Parameters.AddWithValue("@ID", empId);
            cmd.Parameters.AddWithValue("@STARTTIME", dayOffBegin);
            cmd.Parameters.AddWithValue("@ENDTIME", dayOffEnd);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }

    /// <summary>
    /// 計算剩餘補休時數
    /// </summary>
    /// <param name="erpId"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    protected double GetMakeUpDayOffHours(string erpId, int year)
    {
        double totalMakeupHours;
        double makeupHoursSpent; //ERP內已經有資料的時數
        double makeupHoursLocked = 0;    //尚未輸入ERP，但在跑流程的時數
        //ERP內補休時數
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            string query = "select coalesce(TK005, 0)" +
                " from PALTK" +
                " where TK001=@id" +
                " and TK002=@year";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", erpId);
            cmd.Parameters.AddWithValue("@year", year);
            totalMakeupHours = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToDouble(cmd.ExecuteScalar());

            query = "SELECT sum(coalesce(TL006,0))+sum(coalesce(TL007,0))" +
                " FROM PALTL" +
                " where TL002 = @year" +
                " and TL001 = @id" +
                " and TL004 = @dayoffType";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", erpId);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@dayoffType", "02");
            makeupHoursSpent = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToDouble(cmd.ExecuteScalar());
        }
        //此次申請假單清單所使用的補休時數
        int divApplicationFormListCounter = 0;  //dynamic control counter
        foreach (HtmlGenericControl div in divApplicationFormList.Controls.OfType<HtmlGenericControl>())
        {
            string dayOffTypeId = ((HtmlInputHidden)div.FindControl("dayOffTypeId_" + divApplicationFormListCounter.ToString())).Value;
            if (dayOffTypeId == "02")
            {
                makeupHoursLocked += double.Parse(((HtmlInputHidden)div.FindControl("dayOffTimeSpan_" + divApplicationFormListCounter.ToString())).Value);
            }
            divApplicationFormListCounter++;
        }
        //for (int i = 0; i < tbAppSummary.Rows.Count - 1; i++)
        //{
        //    if (tbAppSummary.Rows[i].Cells[0].InnerText == "補休")
        //    {
        //        string usedAmount = tbAppSummary.Rows[i].Cells[3].ToString().Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2);
        //        makeupHoursLocked += double.Parse(usedAmount);
        //    }
        //}

        //正在跑流程的假單所使用的補休時數
        for (int i = 0; i < tbInProgressSummary.Rows.Count - 1; i++)
        {
            if (tbInProgressSummary.Rows[i].Cells[1].InnerText == "補休"
                && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
            {
                string usedAmount = tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2);
                makeupHoursLocked += double.Parse(usedAmount);
            }
        }
        return totalMakeupHours - makeupHoursSpent - makeupHoursLocked;
    }

    /// <summary>
    /// 特休分上下部分，請假時需依照請假日期使用相應的特休時數
    /// 2021.10.25 因COVID關係，上下部分假期合併使用
    /// </summary>
    /// <param name="dayOffApplication"></param>
    /// <param name="erpId"></param>
    /// <param name="empStartDate"></param>
    /// <returns></returns>
    protected double[] GetAnnualLeaveHours(string erpId, DateTime empStartDate, DateTime dayOffStartDate)
    {
        double[] totalHour = new double[2];
        double[] hoursSpent = new double[2];
        double[] hoursLocked = new double[] { 0, 0 };
        double[] remainingHours = new double[2];
        //任職年資大於25年則以25年計算(因為特休時數到頂)
        double yearInService = dayOffStartDate.Year - empStartDate.Year > 25 ? 25 : dayOffStartDate.Year - empStartDate.Year;
        //請假日年份+到職月份
        DateTime annualLeaveCutoffDate = new DateTime(dayOffStartDate.Year
            , empStartDate.Month
            , 1);

        //特休時數依照員工到職月份分成兩部分
        //切割方式記錄於dbo.NZ_ERP2._HR360_ANNUAL_LEAVE_TABLE
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();

            //Get特休總時數
            string query = "SELECT [" + HR360LoggedUser.StartDate.Month.ToString("D2") + "]"
                        + " FROM _HR360_ANNUAL_LEAVE_TABLE"
                        + " WHERE YEAR_IN_SERVICE=@YEAR_IN_SERVICE";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR_IN_SERVICE", yearInService);
            string tempString = cmd.ExecuteScalar().ToString();
            string[] tempStringArray;
            string[] stringSeparators = new string[] { "," };
            tempStringArray = tempString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            totalHour[0] = Convert.ToDouble(tempStringArray[0]) * employeeWorkHour;
            totalHour[1] = Convert.ToDouble(tempStringArray[1]) * employeeWorkHour;
        }
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            //Get ERP有資料已使用的特休時數
            //上半部分
            string query = "select sum(coalesce(TL006,0))+sum(coalesce(TL007,0))" +
                " from PALTL" +
                " where TL002 = @year" +
                " and TL003 < @month" +
                " and TL001 = @id" +
                " and TL004 = @dayoffType";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", erpId);
            cmd.Parameters.AddWithValue("@year", empStartDate.Year);
            cmd.Parameters.AddWithValue("@month", empStartDate.Month.ToString("D2"));
            cmd.Parameters.AddWithValue("@dayoffType", "03");
            hoursSpent[0] = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToDouble(cmd.ExecuteScalar());
            //下半部分
            query = "select sum(coalesce(TL006,0))+sum(coalesce(TL007,0))" +
                " from PALTL" +
                " where TL002 = @year" +
                " and TL003 >= @month" +
                " and TL001 = @id" +
                " and TL004 = @dayoffType";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", erpId);
            cmd.Parameters.AddWithValue("@year", empStartDate.Year);
            cmd.Parameters.AddWithValue("@month", empStartDate.Month.ToString("D2"));
            cmd.Parameters.AddWithValue("@dayoffType", "03");
            hoursSpent[1] = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToDouble(cmd.ExecuteScalar());
        }

        //Get 未進ERP但正在跑流程的資料
        //上半部分
        int divApplicationFormListCounter1 = 0;  //dynamic control counter
        foreach (HtmlGenericControl div in divApplicationFormList.Controls.OfType<HtmlGenericControl>())
        {
            string dayOffTypeId = ((HtmlInputHidden)div.FindControl("dayOffTypeId_" + divApplicationFormListCounter1.ToString())).Value;
            string[] dayOffTime = ((HtmlGenericControl)div.FindControl("dayOffTime_" + divApplicationFormListCounter1.ToString())).InnerText.Split('~');
            DateTime startTime = Convert.ToDateTime(((HtmlGenericControl)div.FindControl("dayOffDate_" + divApplicationFormListCounter1.ToString())).InnerText + " " + dayOffTime[0]);
            if (dayOffTypeId == "03"
                && startTime < annualLeaveCutoffDate)
            {
                hoursLocked[0] += double.Parse(((HtmlInputHidden)div.FindControl("dayOffTimeSpan_" + divApplicationFormListCounter1.ToString())).Value);
            }
            divApplicationFormListCounter1++;
        }
        //for (int i = 1; i < tbAppSummary.Rows.Count; i++)
        //{
        //    if (tbAppSummary.Rows[i].Cells[0].InnerText == "特休"
        //        && DateTime.Parse(tbAppSummary.Rows[i].Cells[1].InnerText) < annualLeaveCutoffDate)
        //    {
        //        string usedAmount = tbAppSummary.Rows[i].Cells[3].InnerText.Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2);
        //        hoursLocked[0] += double.Parse(usedAmount);
        //    }
        //}
        for (int i = 1; i < tbInProgressSummary.Rows.Count; i++)
        {
            if (tbInProgressSummary.Rows[i].Cells[1].InnerText == "特休"
                && DateTime.Parse(tbInProgressSummary.Rows[i].Cells[2].InnerText) < annualLeaveCutoffDate
                && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
            {
                string usedAmount = tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2);
                hoursLocked[0] += double.Parse(usedAmount);
            }
        }
        //下半部分
        int divApplicationFormListCounter2 = 0;  //dynamic control counter
        foreach (HtmlGenericControl div in divApplicationFormList.Controls.OfType<HtmlGenericControl>())
        {
            string dayOffTypeId = ((HtmlInputHidden)div.FindControl("dayOffTypeId_" + divApplicationFormListCounter2.ToString())).Value;
            string[] dayOffTime = ((HtmlGenericControl)div.FindControl("dayOffTime_" + divApplicationFormListCounter2.ToString())).InnerText.Split('~');
            DateTime startTime = Convert.ToDateTime(((HtmlGenericControl)div.FindControl("dayOffDate_" + divApplicationFormListCounter2.ToString())).InnerText + " " + dayOffTime[0]);
            if (dayOffTypeId == "03"
                && startTime >= annualLeaveCutoffDate)
            {
                hoursLocked[1] += double.Parse(((HtmlInputHidden)div.FindControl("dayOffTimeSpan_" + divApplicationFormListCounter2.ToString())).Value);
            }
            divApplicationFormListCounter2++;
        }
        //for (int i = 1; i < tbAppSummary.Rows.Count; i++)
        //{
        //    if (tbAppSummary.Rows[i].Cells[0].InnerText == "特休")
        //    {
        //        string usedAmount = tbAppSummary.Rows[i].Cells[3].InnerText.Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2);
        //        hoursLocked[1] += double.Parse(usedAmount);
        //    }
        //}
        for (int i = 1; i < tbInProgressSummary.Rows.Count; i++)
        {
            if (tbInProgressSummary.Rows[i].Cells[1].InnerText == "特休" && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
            {
                string usedAmount = tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2);
                hoursLocked[1] += double.Parse(usedAmount);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            remainingHours[i] = totalHour[i] - hoursSpent[i] - hoursLocked[i];
        }

        return remainingHours;
    }

    /// <summary>
    /// 計算有時數限制假別的剩餘時數
    /// </summary>
    /// <param name="dayOffType"></param>
    /// <returns></returns>
    protected double GetRamainingDayOffHours(DayOffType dayOffType, string erpId, DateTime dayOffDate)
    {
        double hoursSpent; //ERP內已經有資料的時數
        double hoursLocked = 0;    //尚未輸入ERP，但在跑流程的時數
        string query = "SELECT sum(coalesce(TL006,0))+sum(coalesce(TL007,0))" +
                " FROM PALTL" +
                " where TL002 = @year" +
                " and TL001 = @id" +
                " and TL004 = @dayoffType";
        //有每月限制的檢查，查詢條件要包含月份
        //2021.10.25 目前沒有假別同時有每月限制以及每年限制低於 (每月限制*12)
        if (dayOffType.monthlyAllowance > 0)
        {
            query += " and TL003 = @month";
        }
        //ERP內補休時數
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", erpId);
            cmd.Parameters.AddWithValue("@year", dayOffDate.Year);
            cmd.Parameters.AddWithValue("@dayoffType", dayOffType.id);
            cmd.Parameters.AddWithValue("@month", dayOffDate.Month.ToString("D2"));
            hoursSpent = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToDouble(cmd.ExecuteScalar());
        }

        //此次申請假單清單所使用的補休時數
        int divApplicationFormListCounter = 0;
        foreach (HtmlGenericControl div in divApplicationFormList.Controls.OfType<HtmlGenericControl>())
        {
            string applicationDayOffId = ((HtmlInputHidden)div.FindControl("dayOffTypeId_" + divApplicationFormListCounter.ToString())).Value;
            DateTime applicationDayOffDate = Convert.ToDateTime(((HtmlGenericControl)div.FindControl("dayOffDate_" + divApplicationFormListCounter.ToString())).InnerText);
            if (applicationDayOffId == dayOffType.id)
            {
                if(dayOffType.monthlyAllowance > 0)
                {
                    if(applicationDayOffDate.Month == dayOffDate.Month)
                    {
                        hoursLocked += double.Parse(((HtmlInputHidden)div.FindControl("dayOffTimeSpan_" + divApplicationFormListCounter.ToString())).Value);
                    }
                }
                else
                {
                    hoursLocked += double.Parse(((HtmlInputHidden)div.FindControl("dayOffTimeSpan_" + divApplicationFormListCounter.ToString())).Value);
                }
            }
        }
        //for (int i = 0; i < divApplicationFormList.Controls.Count; i++)
        //{
        //    double usedAmount = 0;
        //    if (tbAppSummary.Rows[i].Cells[0].InnerText == dayOffType.name)
        //    {
        //        if (dayOffType.monthlyAllowance > 0)
        //        {
        //            if (DateTime.Parse(tbAppSummary.Rows[i].Cells[1].InnerText).Month == dayOffDate.Month)
        //            {
        //                usedAmount = double.Parse(tbAppSummary.Rows[i].Cells[3].ToString().Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2));
        //            }
        //        }
        //        else
        //        {
        //            usedAmount = double.Parse(tbAppSummary.Rows[i].Cells[3].ToString().Substring(0, tbAppSummary.Rows[i].Cells[3].InnerText.Length - 2));
        //        }
        //        hoursLocked += usedAmount;
        //    }
        //}
        //正在跑流程的假單所使用的補休時數
        for (int i = 0; i < tbInProgressSummary.Rows.Count - 1; i++)
        {
            double usedAmount = 0;
            if (tbInProgressSummary.Rows[i].Cells[1].InnerText == dayOffType.name
                && tbInProgressSummary.Rows[i].Cells[8].InnerText == "未登入")
            {
                if (dayOffType.monthlyAllowance > 0)
                {
                    if (DateTime.Parse(tbInProgressSummary.Rows[i].Cells[2].InnerText).Month == dayOffDate.Month)
                    {
                        usedAmount = double.Parse(tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2));
                    }
                }
                else
                {
                    usedAmount = double.Parse(tbInProgressSummary.Rows[i].Cells[4].InnerText.Substring(0, tbInProgressSummary.Rows[i].Cells[4].InnerText.Length - 2));
                }

                hoursLocked += usedAmount;
            }
        }

        if (dayOffType.monthlyAllowance > 0)
        {
            return dayOffType.monthlyAllowance - hoursSpent - hoursLocked;
        }
        else
        {
            return dayOffType.annualAllowance - hoursSpent - hoursLocked;
        }
    }

    protected void displayRemainingDayOffHours(string erpId, DayOffType dayOffType, DateTime dayOffDate)
    {
        double remainingHours;
        double[] remainingHoursArray = new double[2];
        if (dayOffType.id == "02")
        {
            remainingHours = GetMakeUpDayOffHours(erpId, dayOffDate.Year);
        }
        else if (dayOffType.id == "03")
        {
            remainingHoursArray = GetAnnualLeaveHours(erpId, HR360LoggedUser.StartDate, dayOffDate);
            remainingHours = remainingHoursArray[0] + remainingHoursArray[1];
        }
        else
        {
            remainingHours = GetRamainingDayOffHours(dayOffType, erpId, dayOffDate);
        }
        lblDayOffRemaining.Text = dayOffType.name + "剩餘" + remainingHours.ToString() + dayOffType.dayOffUnit;
    }

    /// <summary>
    /// 測試錯誤 205.請假週期已在DB內
    /// </summary>
    /// <param name="erpId"></param>
    /// <param name="dayOffApplication"></param>
    /// <returns></returns>
    protected bool isDayOffTimeInDatabase(string erpId, DayOff dayOffApplication)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT APPLICATION_ID"
                + " FROM HR360_DAYOFFAPPLICATION_APPLICATION"
                + " WHERE APPLICANT_ID = @ID"
                + " AND APPLICATION_STATUS_ID<>'98'"
                + " AND APPLICATION_STATUS_ID<>'99'"
                + " AND ((DAYOFF_START_TIME <= @STARTTIME AND DAYOFF_END_TIME > @STARTTIME)"
                + " OR (DAYOFF_START_TIME < @ENDTIME AND DAYOFF_END_TIME >= @ENDTIME)"
                + " OR (DAYOFF_START_TIME >= @STARTTIME AND DAYOFF_END_TIME <= @ENDTIME))";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
            cmd.Parameters.AddWithValue("@STARTTIME", dayOffApplication.startTime);
            cmd.Parameters.AddWithValue("@ENDTIME", dayOffApplication.endTime);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                return dr.HasRows;
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
        updateRemainingDayOffHours(HR360LoggedUser.ERPId, Convert.ToDateTime(txtDayOffBeginDateTime.Text));
        upApplicationForm.Update();
        ShowModal("ApplicationForm");
    }

    /// <summary>
    /// 日期改變也須檢查假別剩餘時數
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtDayOffDate_TextChanged(object sender, EventArgs e)
    {
        updateRemainingDayOffHours(HR360LoggedUser.ERPId, Convert.ToDateTime(txtDayOffBeginDateTime.Text));
        upApplicationForm.Update();
        ShowModal("ApplicationForm");
    }

    /// <summary>
    /// 錯誤訊息
    /// </summary>
    /// <param name="errorID"></param>
    /// <returns></returns>
    protected Tuple<int, string> errorCode(int errorID)
    {
        Tuple<int, string> error;
        if (errorID == 106)
        {
            error = Tuple.Create(errorID, "代理人已經自行請假，請另選代理人");
        }
        else if (errorID == 107)
        {
            error = Tuple.Create(errorID, "你已於此時段代理他人，不可請假");
        }
        else if (errorID == 108)
        {
            error = Tuple.Create(errorID, "請事假未填寫請假原因");
        }
        else if (errorID == 109)
        {
            error = Tuple.Create(errorID, "請假時間非上班時間，請確認");
        }
        else if (errorID == 110)
        {
            error = Tuple.Create(errorID, "請假年份僅限於本年度，請與人事部確認");
        }
        else if (errorID == 111)
        {
            error = Tuple.Create(errorID, "補單超過三天期限(含今日)");
        }
        else if (errorID == 201)
        {
            error = Tuple.Create(errorID, "請假時數為0，請確認");
        }
        else if (errorID == 202)
        {
            error = Tuple.Create(errorID, "剩餘假期不足");
        }
        else if (errorID == 203)
        {
            error = Tuple.Create(errorID, "請假總量不符合單位數量");
        }
        else if (errorID == 204)
        {
            error = Tuple.Create(errorID, "此請假期間已與清單內重複，請確認");
        }
        else if (errorID == 205)
        {
            error = Tuple.Create(errorID, "此請假期間已申請，請與人事部確認");
        }
        else if (errorID == 206)
        {
            error = Tuple.Create(errorID, "請假時間不符規定，請與人事部確認");
        }
        else if (errorID == 207)
        {
            error = Tuple.Create(errorID, "班別尚未建立，請與人事部確認");
        }
        else if (errorID == 208)
        {
            error = Tuple.Create(errorID, "產假需為整天");
        }
        else if (errorID == 999)
        {
            error = Tuple.Create(errorID, "班別為跨天班，需人工請假");
        }
        else
        {
            error = Tuple.Create(0, "沒有錯誤");
        }
        return error;
    }
    protected Tuple<int, string> errorCode(int errorID, string s)
    {
        Tuple<int, string> error = Tuple.Create(errorID, s);
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
    /// fill day off application table
    /// </summary>
    /// <param name="lstDayOffAppSummary"></param>
    protected void fillDayOffApplicationTable(List<DayOff> lstDayOffAppSummary)
    {
        divApplicationFormList.Controls.Clear();

        for (int i = 0; i < lstDayOffAppSummary.Count; i++)
        {
            HtmlGenericControl divCol = new HtmlGenericControl("div");
            divCol.Attributes.Add("class", "col");
            divApplicationFormList.Controls.Add(divCol);
            HtmlGenericControl divApplicationFormListItem = new HtmlGenericControl("div");
            divApplicationFormListItem.ID = "applicationFormListItem_" + i.ToString();
            divApplicationFormListItem.Attributes.Add("class", "application-form-list-item");
            divCol.Controls.Add(divApplicationFormListItem);
            buildApplicationFormListItem_labels(i, "假別", lstDayOffAppSummary[i].dayOffType.name, divApplicationFormListItem, "dayOffTypeName");
            buildApplicationFormListItem_labels(i, "日期", lstDayOffAppSummary[i].startTime.Date.ToString("yyyy/MM/dd"), divApplicationFormListItem, "dayOffDate");
            buildApplicationFormListItem_labels(i, "時間", lstDayOffAppSummary[i].startTime.ToString("HH:mm") + "~" + lstDayOffAppSummary[i].endTime.ToString("HH:mm"), divApplicationFormListItem, "dayOffTime");
            buildApplicationFormListItem_labels(i, "代理", lstDayOffAppSummary[i].functionalSubstitute.Item2, divApplicationFormListItem, "functionalSubstituteName");

            HtmlGenericControl divInputGroup = new HtmlGenericControl("div");
            divInputGroup.Attributes.Add("class", "input-group");
            divApplicationFormListItem.Controls.Add(divInputGroup);

            HtmlGenericControl txtReason = new HtmlGenericControl("textarea");
            txtReason.ID = "txtReason_" + i.ToString();
            txtReason.Attributes.Add("class", "form-control");
            txtReason.Attributes.Add("readonly", "");
            txtReason.InnerText = lstDayOffAppSummary[i].reason;
            divInputGroup.Controls.Add(txtReason);

            divInputGroup = new HtmlGenericControl("div");
            divInputGroup.Attributes.Add("class", "input-group");
            divApplicationFormListItem.Controls.Add(divInputGroup);

            Button btnRemoveApplication = new Button();
            btnRemoveApplication.ID = "btnRemoveApplication_" + i.ToString();
            btnRemoveApplication.Attributes.Add("class", "btn btn-danger w-100");
            btnRemoveApplication.Text = "移除";
            btnRemoveApplication.Click += new EventHandler(btnRemoveApp_Click);
            divInputGroup.Controls.Add(btnRemoveApplication);

            HtmlInputHidden hdnDayOffTypeId = new HtmlInputHidden();
            hdnDayOffTypeId.ID = "dayOffTypeId_" + i.ToString();
            hdnDayOffTypeId.Value = lstDayOffAppSummary[i].dayOffType.id;
            divApplicationFormListItem.Controls.Add(hdnDayOffTypeId);
            HtmlInputHidden hdnDayOffTimeSpan = new HtmlInputHidden();
            hdnDayOffTimeSpan.ID = "dayOffTimeSpan_" + i.ToString();
            hdnDayOffTimeSpan.Value = lstDayOffAppSummary[i].dayOffTimespan.ToString();
            divApplicationFormListItem.Controls.Add(hdnDayOffTimeSpan);
            HtmlInputHidden hdnFunctionSubstituteId = new HtmlInputHidden();
            hdnFunctionSubstituteId.ID = "functionalSubstituteId_" + i.ToString();
            hdnFunctionSubstituteId.Value = lstDayOffAppSummary[i].functionalSubstitute.Item1;
            divApplicationFormListItem.Controls.Add(hdnFunctionSubstituteId);
            HtmlInputHidden hdnIsTyphoonDayChecked = new HtmlInputHidden();
            hdnIsTyphoonDayChecked.ID = "isTyphoonDayChecked_" + i.ToString();
            hdnIsTyphoonDayChecked.Value = lstDayOffAppSummary[i].isTyphoonDayChecked.ToString();
            divApplicationFormListItem.Controls.Add(hdnIsTyphoonDayChecked);
        }
    }

    protected void buildApplicationFormListItem_labels(int positionInList, string titleText, string contentText, HtmlGenericControl parentControl, string controlId)
    {
        HtmlGenericControl divInputGroup = new HtmlGenericControl("div");
        divInputGroup.Attributes.Add("class", "input-group");
        parentControl.Controls.Add(divInputGroup);
        HtmlGenericControl divInputGroupPrepend = new HtmlGenericControl("div");
        divInputGroupPrepend.Attributes.Add("class", "input-group-prepend");
        divInputGroup.Controls.Add(divInputGroupPrepend);
        HtmlGenericControl lblInputGroupText = new HtmlGenericControl("label");
        lblInputGroupText.Attributes.Add("class", "input-group-text");
        lblInputGroupText.InnerText = titleText;
        divInputGroupPrepend.Controls.Add(lblInputGroupText);
        HtmlGenericControl lblFormControl = new HtmlGenericControl("label");
        lblFormControl.ID = controlId + "_" + positionInList.ToString();
        lblFormControl.Attributes.Add("class", "form-control");
        lblFormControl.InnerText = contentText;
        divInputGroup.Controls.Add(lblFormControl);
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
            cmd.Parameters.AddWithValue("@APPLICANT", HR360LoggedUser.ERPId);
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
            cmd.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
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
        List<DayOff> lstDayOffAppSummary = (List<DayOff>)ViewState["lstDayOffAppSummary"] == null ? new List<DayOff>() : (List<DayOff>)ViewState["lstDayOffAppSummary"];
        Button btn = (Button)sender;
        string btnID = btn.ID;
        lstDayOffAppSummary.RemoveAt(Convert.ToInt16(btnID.Substring(21, btnID.Length - 21)));
        fillDayOffApplicationTable(lstDayOffAppSummary);
        upApplicationList.Update();
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
            string appStatusId = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? "" : cmd.ExecuteScalar().ToString();

            query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B (APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,STATUS_ID)"
                        + " VALUES ("
                        + " @APPLICATION_ID, @ACTION_TIME, @EXECUTOR_ID, @ACTION_ID, @STATUS_ID"
                        + " )";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APPLICATION_ID", withdrawID);
            cmd.Parameters.AddWithValue("@ACTION_TIME", DateTime.Now);
            cmd.Parameters.AddWithValue("@EXECUTOR_ID", HR360LoggedUser.ERPId);
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
        //string erpId = HR360LoggedUser.ERPId;
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
                    nextReviewer = HR360LoggedUser.ERPId;
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
                                        + " AND MV.MV001='" + HREmpId + "'" //HR NEED FIX: 如無人事主任(A20)，則指定人事專員審核
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
            string appStatusId = cmd.ExecuteScalar() == null || cmd.ExecuteScalar() == DBNull.Value ? "" : cmd.ExecuteScalar().ToString();

            //insert deny trail to DB
            query = "INSERT INTO HR360_DAYOFFAPPLICATION_APPLICATION_TRAIL_B(APPLICATION_ID,ACTION_TIME,EXECUTOR_ID,ACTION_ID,MEMO,STATUS_ID)"
                        + " VALUES(@APP_ID,GETDATE(),@EXE_ID,'03',@MEMO,@STATUS_ID)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@APP_ID", denyID);
            cmd.Parameters.AddWithValue("@EXE_ID", HR360LoggedUser.ERPId);
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
        List<DayOff> lstDayOffAppSummary = (List<DayOff>)ViewState["lstDayOffAppSummary"] == null ? new List<DayOff>() : (List<DayOff>)ViewState["lstDayOffAppSummary"]; ;
        string uid = "";
        string query;
        foreach (DayOff dayoff in lstDayOffAppSummary)
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
                    cmd.Parameters.AddWithValue("@APPLICANT_ID", HR360LoggedUser.ERPId.Trim());
                    cmd.Parameters.AddWithValue("@DAYOFF_ID", dayoff.dayOffType.id);
                    cmd.Parameters.AddWithValue("@DAYOFF_NAME", dayoff.dayOffType.name);
                    cmd.Parameters.AddWithValue("@DAYOFF_START_TIME", dayoff.startTime);
                    cmd.Parameters.AddWithValue("@DAYOFF_END_TIME", dayoff.endTime);
                    cmd.Parameters.AddWithValue("@DAYOFF_TOTAL_TIME", dayoff.dayOffTimespan);
                    cmd.Parameters.AddWithValue("@DAYOFF_TIME_UNIT", dayoff.dayOffType.dayOffUnit);
                    cmd.Parameters.AddWithValue("@STATUS_ID", "02");
                    if (dayoff.functionalSubstitute.Item1 == "N/A")
                    {
                        cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.functionalSubstitute);
                        cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.functionalSubstitute);
                    }
                    else
                    {
                        int pos = 2;    //get the index of the first char after the first 2 chars that is not number (正式員工編碼為xxxx, PT員工編碼為PTxxxx, 需要用此方法抓出完整員編)
                        while (Char.IsNumber(dayoff.functionalSubstitute.Item1[pos]))
                        {
                            ++pos;
                        }
                        cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.functionalSubstitute.Item1.Substring(0, pos));
                        cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.functionalSubstitute.Item1.Substring(0, pos));
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
                    cmd.Parameters.AddWithValue("@EXECUTOR_ID", HR360LoggedUser.ERPId);
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
                        cmd.Parameters.AddWithValue("@APPLICANT_ID", HR360LoggedUser.ERPId.Trim());
                        cmd.Parameters.AddWithValue("@DAYOFF_ID", dayoff.dayOffType.id);
                        cmd.Parameters.AddWithValue("@DAYOFF_NAME", dayoff.dayOffType.name);
                        cmd.Parameters.AddWithValue("@DAYOFF_START_TIME", dayoff.startTime);
                        cmd.Parameters.AddWithValue("@DAYOFF_END_TIME", dayoff.endTime);
                        cmd.Parameters.AddWithValue("@DAYOFF_TOTAL_TIME", dayoff.dayOffTimespan);
                        cmd.Parameters.AddWithValue("@DAYOFF_TIME_UNIT", dayoff.dayOffType.dayOffUnit);
                        cmd.Parameters.AddWithValue("@STATUS_ID", "02");
                        if (dayoff.functionalSubstitute.Item1 == "N/A")
                        {
                            cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.functionalSubstitute);
                            cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.functionalSubstitute);
                        }
                        else
                        {
                            int pos = 2;    //get the index of the first char after the first 2 chars that is not number (正式員工編碼為xxxx, PT員工編碼為PTxxxx, 需要用此方法抓出完整員編)
                            while (Char.IsNumber(dayoff.functionalSubstitute.Item1[pos]))
                            {
                                ++pos;
                            }
                            cmd.Parameters.AddWithValue("@FUNC_SUB_ID", dayoff.functionalSubstitute.Item1.Substring(0, pos));
                            cmd.Parameters.AddWithValue("@NEXT_REVIEWER", dayoff.functionalSubstitute.Item1.Substring(0, pos));
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
                        cmd.Parameters.AddWithValue("@EXECUTOR_ID", HR360LoggedUser.ERPId);
                        cmd.Parameters.AddWithValue("@ACTION_ID", "01");
                        cmd.Parameters.AddWithValue("@STATUS_ID", "01");
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {

                    }
                }
            }
            if (dayoff.functionalSubstitute.Item1 == "N/A")    //此單不需要代理人，可直接執行代理人APPROVE
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
        //hdnIsSearchFieldVisible.Value = "1";
        string nonAdminCondition = "";
        if (HR360LoggedUser.ERPId != HREmpId      //HR
            && HR360LoggedUser.ERPId != "0015"   //小榆
            && HR360LoggedUser.ERPId != "0080"
            && HR360LoggedUser.ERPId != "0006"
            && HR360LoggedUser.ERPId != "0007") //管理部跟HR可以查詢全部人的歷史資料
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


        using (SqlConnection conn = new SqlConnection(NZConnectionString))  //FILL ddlSearch_Parameter_ApplicantID
        {
            conn.Open();
            query += " ORDER BY 'list_order','value'";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ddlSearch_Parameter_ApplicantID.DataTextField = "display";
            ddlSearch_Parameter_ApplicantID.DataValueField = "value";
            ddlSearch_Parameter_ApplicantID.DataSource = dt;
            ddlSearch_Parameter_ApplicantID.DataBind();
        }
        if (!(HR360LoggedUser.ERPId != HREmpId  //HR
            && HR360LoggedUser.ERPId != "0015"   //小榆
            && HR360LoggedUser.ERPId != "0080"
            && HR360LoggedUser.ERPId != "0006"
            && HR360LoggedUser.ERPId != "0007")) //管理部跟HR可以查詢全部人的歷史資料
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
        //ViewState["lstDayOffAppSummary"] = lstDayOffAppSummary;
        hdnIsPostBack.Value = "1";  //variable for determining whether this page is a postback for jquery
        //hdnIsDayOffAppVisible.Value = "0";  //variable for determining whether the div DayOffApp is visible
        DataTable dt = GetUserDayOffTypes(HR360LoggedUser.Sex);
        FillDropDownListContent(ddlDayOffType, dt);
        ddlDayOffType.SelectedValue = "03";

        //抓取跟登入者同部門及可替代部門的人 (according to DB HR360_DAYOFFAPPLICATION_DEPT_REFERENCE)            
        dt = GetUserFunctionalSub(HR360LoggedUser.ERPId, HR360LoggedUser.Dept);
        FillDropDownListContent(ddlDayOffFuncSub, dt);
        if (ddlDayOffFuncSub.Items.Count == 0)   //如使用者沒代理人，用小K
        {
            ddlDayOffFuncSub.Items.Add(new ListItem("0080 王君凱", "0080"));
        }
        ddlDayOffFuncSub.SelectedIndex = 0;

        /*2021.10.01 更改請假內容顯示，改成一張假單一個Card，適合RWD顯示*/
        //請假內容header
        //HtmlTableRow newHeaderRow = new HtmlTableRow();
        //HtmlTableCell newHeaderCell = new HtmlTableCell("th");
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
        //newHeaderCell.InnerText = "移除";
        //newHeaderCell.Attributes.Add("style", "text-align:center;font-weight:bold;");
        //newHeaderRow.Controls.Add(newHeaderCell);
        //tbAppSummary.Controls.Add(newHeaderRow);

        //hidden field insertion
        //determine if applicant is within 0.5hr restraint or 4hr restraint (by dept)
        if (HR360LoggedUser.Dept == "B-C"     //使用者部門為上膠部
            || HR360LoggedUser.Dept == "B-E"  //絞線包帶部
            || HR360LoggedUser.Dept == "B-G"  //編織部
            || HR360LoggedUser.Dept == "B-IC" //倉儲管理科
            || HR360LoggedUser.Dept == "B-K"  //捲線部
            || HR360LoggedUser.Dept == "B-P"  //PVC押出部
            || HR360LoggedUser.Dept == "B-S"  //矽膠部
            || HR360LoggedUser.Dept == "B-T"  //鐵氟龍部
            )
        {
            if (!exceptionListHourForProduction.Contains(HR360LoggedUser.ERPId))
            {
                hdnOfficeOrProduction.Value = "production";
            }
            else
            {
                hdnOfficeOrProduction.Value = "production";
            }
        }
        else
        {
            hdnOfficeOrProduction.Value = "office";
        }
    }


    protected DataTable GetUserDayOffTypes(string sex)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            string query = "";

            if (sex == "M")  //性別為男性
            {
                query = "SELECT PALMC.MC002 'text'" +
                    " ,PALMC.MC001 'value'" +
                    " FROM PALMC" +
                    " WHERE PALMC.MC001<>'08'" +    //產假
                    " AND PALMC.MC001<>'16'" +  //生理假
                    " AND PALMC.MC001<>'19'" +  //安胎假
                    " AND PALMC.MC001<>'10'" +  //曠職
                    " AND PALMC.MC001<>'18'" +  //育嬰留停
                    " AND PALMC.MC001<>'21'" + //遲到
                    " ORDER BY PALMC.MC001";
            }
            else //女性無陪產假
            {
                query = "SELECT PALMC.MC002 'text'" +
                    " ,PALMC.MC001 'value'" +
                    " FROM PALMC" +
                    " WHERE PALMC.MC001<>'09'" +    //陪產假
                    " AND PALMC.MC001<>'10'" +  //曠職
                    " AND PALMC.MC001<>'18'" +  //育嬰留停
                    " AND PALMC.MC001<>'21'" + //遲到
                    " ORDER BY PALMC.MC001";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    protected DataTable GetUserFunctionalSub(string empID, string empDept)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            string query = ";WITH REF_DEPT" +
            " AS" +
            " (" +
            " SELECT REF.DEPT_MAIN MAIN,REF.DEPT_REF REF" +
            " FROM CMSMV MV" +
            " LEFT JOIN NZ_ERP2.dbo.HR360_DAYOFFAPPLICATION_DEPT_REFERENCE REF ON MV.MV004=REF.DEPT_MAIN AND REF.ACTIVE=1" +
            " WHERE MV.MV001=@ID" +
            " )" +
            " SELECT DISTINCT LTRIM(RTRIM(MV.MV001))+' '+MV.MV002 'text'" +
            " ,MV.MV001 'value'" +
            " FROM CMSMV MV" +
            " LEFT JOIN CMSMK MK ON MV.MV001=MK.MK002" +
            " LEFT JOIN REF_DEPT REF ON MV.MV004=REF.MAIN OR MV.MV004=REF.REF" +
            " WHERE MV.MV022=''" +
            " AND MV.MV001<>'0000'" +    //李小姐
            " AND MV.MV001<>'0098'" +    //黃耀南
            " AND MV.MV001<>@ID" +
            " AND (MV.MV004=@DEPT OR MV.MV004=REF.REF)" +
            " ORDER BY MV.MV001";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DEPT", empDept);
            cmd.Parameters.AddWithValue("@ID", empID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    /// <summary>
    /// Fill in content for DropDownList with DataTable
    /// DataTable must have columns "text" and "value"
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="dt"></param>
    protected void FillDropDownListContent(DropDownList ddl, DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            ddl.Items.Add(new ListItem(dr["text"].ToString().Trim(), dr["value"].ToString().Trim()));
        }
    }

    /// <summary>
    /// Postback loading for div application section
    /// </summary>
    protected void ApplicationSection_PostBack_Load()
    {
        List<DayOff> lstDayOffAppSummary = (List<DayOff>)ViewState["lstDayOffAppSummary"] == null ? new List<DayOff>() : (List<DayOff>)ViewState["lstDayOffAppSummary"];
        hdnIsPostBack.Value = "1";
        if (getPostBackControlName() != "btnDayOffAdd")
        {
            if (ViewState["lstDayOffAppSummary"] != null)
            {
                lstDayOffAppSummary = (List<DayOff>)ViewState["lstDayOffAppSummary"];
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
        recipientId.Add(HREmpId);    //HR
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
            using (SqlConnection conn = new SqlConnection(NZConnectionString))
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
        SearchDayOffRecords();
    }

    protected void SearchDayOffRecords()
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

        //人事退回權限
        try
        {
            if (HR360LoggedUser.ERPId != "0007"      //Chrissy
                && HR360LoggedUser.ERPId != "0080"   //Kevin
                && HR360LoggedUser.ERPId != "0015"   //小榆
                && HR360LoggedUser.ERPId != HREmpId   //HR
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

    /*
     below are RWD version added methods     
     */
    private void ShowModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('show');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "initModal", sb.ToString(), false);
    }

    private void CloseModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "closeModal", sb.ToString(), false);
    }

    protected void btnAddApplicationForm_Click(object sender, EventArgs e)
    {
        lblApplicationFormTitle.Text = "新增假單";
        btnDayOffAdd.Text = "新增";
        txtDayOffBeginDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        txtDayOffEndTime.Text = DateTime.Now.AddMinutes(30).ToString("HH:mm");
        updateRemainingDayOffHours(HR360LoggedUser.ERPId, Convert.ToDateTime(txtDayOffBeginDateTime.Text));
        ShowModal("ApplicationForm");
    }

    protected void updateRemainingDayOffHours(string erpId, DateTime dayOffBegin)
    {
        DayOffType dayOffType = GetDayOffTypeInfo(ddlDayOffType.SelectedValue);
        if (dayOffType.id == "02"
            || dayOffType.id == "03"
            || dayOffType.monthlyAllowance > 0
            || dayOffType.annualAllowance > 0)
        {
            displayRemainingDayOffHours(HR360LoggedUser.ERPId, dayOffType, dayOffBegin);
        }
        else
        {
            lblDayOffRemaining.Text = string.Empty;
        }
    }

    protected void AppendSystemMessage(string text, string textCondition)
    {
        HtmlGenericControl span = new HtmlGenericControl("span");
        if (textCondition == "error")
        {
            span.Attributes.Add("style", "color:red");
        }
        span.InnerText = text;
        divSystemMessage.Controls.Add(span);
    }
}