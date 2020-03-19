using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Svg;

public partial class main : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    DateTime lastLoginTime = new DateTime();

    #region Announcement Repeater Pagination Variable
    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 5;  //公告每頁顯示數量
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            return ((int)ViewState["CurrentPage"]);
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //test area
        Session["erp_id"] = "0080";
        Session["user_id"] = "0080";

        //if(false)
        if (!((masterPage_HR360_Master)this.Master.Master).CheckAuthentication())        
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        }
        else
        {   
            if (!IsPostBack)
            {
                DataTable dtUserInfo = new DataTable();

                #region 補休、特休計算 variable
                double doubleFirstPartDayOff = 0;
                double doubleSecondPartDayOff = 0;
                double doubleFirstPartDayOffUsed = 0;
                double doubleSecondPartDayOffUsed = 0;
                double doubleFirstPartFinal = 0;
                double doubleSecondPartFinal = 0;
                string strFirstPartDayOff = "";
                string strSecondPartDayOff = "";
                #endregion

                #region 公司公告 variable
                DataTable dtCompanyAnnouncement = new DataTable();
                #endregion

                lastLoginTime = GetLastLoginTime(Session["erp_id"].ToString());

                using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT NAME"
                                                        + " FROM HR360_BI01_A"
                                                        + " WHERE ID=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    lblName.Text = (string)cmdSelect.ExecuteScalar();
                }
                //Get user's Year of Service, and the Month of when the user started                
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    string query = "SELECT YEAR(GETDATE())-SUBSTRING(MV.MV021,1,4) 'YEAR_IN_SERVICE', SUBSTRING(MV.MV021,1,4) 'START_YEAR', SUBSTRING(MV.MV021,5,2) 'START_MONTH', SUBSTRING(MV.MV021,7,2) 'START_DAY'"
                                +" FROM CMSMV MV"
                                +" WHERE MV.MV001=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtUserInfo);
                }
                //Map User's annual leave days from _HR360_ANNUAL_LEAVE_TABLE with data in dtUserInfo
                using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                {
                    if (dtUserInfo.Rows.Count > 0)
                    {
                        conn.Open();
                        string query = "SELECT [" + dtUserInfo.Rows[0]["START_MONTH"].ToString() + "]"
                                    + " FROM _HR360_ANNUAL_LEAVE_TABLE"
                                    + " WHERE YEAR_IN_SERVICE=@YEAR_IN_SERVICE";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        if ((int)dtUserInfo.Rows[0]["YEAR_IN_SERVICE"] < 25)
                        {
                            cmd.Parameters.AddWithValue("@YEAR_IN_SERVICE", dtUserInfo.Rows[0]["YEAR_IN_SERVICE"].ToString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@YEAR_IN_SERVICE", "25");
                        }
                        string tempString = cmd.ExecuteScalar().ToString();
                        string[] tempStringArray;
                        string[] stringSeparators = new string[] { "," };
                        tempStringArray = tempString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                        query = "SELECT TK.TK013"
                            + " FROM NZ.dbo.PALTK TK"
                            + " WHERE TK.TK001=@ID"
                            + " AND TK.TK002=YEAR(GETDATE())";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                        double previousCycleDayOff = Convert.ToDouble(cmd.ExecuteScalar());
                        if (Session["erp_id"].ToString() == "0010")
                        {
                            previousCycleDayOff = previousCycleDayOff / 8.5;
                        }
                        else
                        {
                            previousCycleDayOff = previousCycleDayOff / 8.0;
                        }
                        
                        
                        doubleFirstPartDayOff = Convert.ToDouble(tempStringArray[0]) + previousCycleDayOff;
                        doubleSecondPartDayOff = Convert.ToDouble(tempStringArray[1]);
                    }
                }                
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    //計算剩餘特休
                    if (dtUserInfo.Rows.Count > 0)
                    {
                        //使用PALTL請假明細計算剩餘特休時數因為PALTK自動計算會有誤差
                        //為0010特別做計算，因為0010一天是8.5小時，其他人一天為8小時
                        if (Session["erp_id"].ToString() == "0010")
                        {
                            string query = "SELECT COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)"
                                        + " FROM PALTL"
                                        + " WHERE PALTL.TL001=@ID"
                                        + " AND PALTL.TL002=YEAR(GETDATE())"
                                        + " AND PALTL.TL003 BETWEEN '01' AND @MONTH"
                                        + " AND PALTL.TL004='03'";
                            SqlCommand cmdSelect = new SqlCommand(query, conn);
                            cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                            cmdSelect.Parameters.AddWithValue("@MONTH", (Convert.ToInt16(dtUserInfo.Rows[0]["START_MONTH"].ToString()) - 1).ToString("D2"));
                            doubleFirstPartDayOffUsed = Convert.ToDouble(cmdSelect.ExecuteScalar());
                            doubleFirstPartFinal = doubleFirstPartDayOff * 8.5 - doubleFirstPartDayOffUsed;
                            strFirstPartDayOff = doubleFirstPartFinal.ToString();
                            //lblFirstPartDayOff.Text = cmdSelect.ExecuteScalar().ToString();

                            query = "SELECT COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)"
                                        + " FROM PALTL"
                                        + " WHERE PALTL.TL001=@ID"
                                        + " AND PALTL.TL002=YEAR(GETDATE())"
                                        + " AND PALTL.TL003 BETWEEN @MONTH AND '12'"
                                        + " AND PALTL.TL004='03'";
                            cmdSelect = new SqlCommand(query, conn);
                            cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                            cmdSelect.Parameters.AddWithValue("@MONTH", dtUserInfo.Rows[0]["START_MONTH"].ToString());
                            doubleSecondPartDayOffUsed = Convert.ToDouble(cmdSelect.ExecuteScalar());
                            doubleSecondPartFinal = doubleSecondPartDayOff * 8.5 - doubleSecondPartDayOffUsed;
                            strSecondPartDayOff = doubleSecondPartFinal.ToString();
                        }
                        else
                        {
                            string query = "SELECT COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)"
                                        + " FROM PALTL"
                                        + " WHERE PALTL.TL001=@ID"
                                        + " AND PALTL.TL002=YEAR(GETDATE())"
                                        + " AND PALTL.TL003 BETWEEN '01' AND @MONTH"
                                        + " AND PALTL.TL004='03'";
                            SqlCommand cmdSelect = new SqlCommand(query, conn);
                            cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                            cmdSelect.Parameters.AddWithValue("@MONTH", (Convert.ToInt16(dtUserInfo.Rows[0]["START_MONTH"].ToString()) - 1).ToString("D2"));
                            doubleFirstPartDayOffUsed = Convert.ToDouble(cmdSelect.ExecuteScalar());
                            doubleFirstPartFinal = doubleFirstPartDayOff * 8 - doubleFirstPartDayOffUsed;
                            strFirstPartDayOff = doubleFirstPartFinal.ToString();
                            //lblFirstPartDayOff.Text = cmdSelect.ExecuteScalar().ToString();

                            query = "SELECT COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)"
                                        + " FROM PALTL"
                                        + " WHERE PALTL.TL001=@ID"
                                        + " AND PALTL.TL002=YEAR(GETDATE())"
                                        + " AND PALTL.TL003 BETWEEN @MONTH AND '12'"
                                        + " AND PALTL.TL004='03'";
                            cmdSelect = new SqlCommand(query, conn);
                            cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                            cmdSelect.Parameters.AddWithValue("@MONTH", dtUserInfo.Rows[0]["START_MONTH"].ToString());
                            doubleSecondPartDayOffUsed = Convert.ToDouble(cmdSelect.ExecuteScalar());
                            doubleSecondPartFinal = doubleSecondPartDayOff * 8 - doubleSecondPartDayOffUsed;
                            strSecondPartDayOff = doubleSecondPartFinal.ToString();
                        }
                    }                    
                    Session["firstPartDayOff"] = doubleFirstPartFinal;
                    Session["secondPartDayOff"] = doubleSecondPartFinal;
                    Session["startYear"] = dtUserInfo.Rows[0]["START_YEAR"].ToString();
                    Session["startDate"] = dtUserInfo.Rows[0]["START_MONTH"].ToString() + dtUserInfo.Rows[0]["START_DAY"].ToString();
                    //顯示剩餘特休
                    if (dtUserInfo.Rows.Count > 0)
                    {
                        if (dtUserInfo.Rows[0]["START_MONTH"].ToString() == "01")
                        {
                            lblFirstPartDayOff.Visible = false;
                            lblDayOffMemo.Visible = false;
                        }
                        else
                        {
                            DateTime startDate = DateTime.ParseExact(dtUserInfo.Rows[0]["START_MONTH"].ToString() + "/" + dtUserInfo.Rows[0]["START_DAY"].ToString(), "MM/dd", new CultureInfo("zh-TW"));                            
                            
                            
                            if (DateTime.Today < startDate)
                            {
                                lblDayOffMemo.Visible = false;
                                lblDayOffMemo.Text = "";                                
                            }
                            else
                            {
                                lblDayOffMemo.Visible = true;
                                strFirstPartDayOff = "0";
                                if (doubleFirstPartFinal > 0)
                                {                                    
                                    lblDayOffMemo.Text = "未休完之" + doubleFirstPartFinal.ToString() + "小時併入" + startDate.ToString("MM/dd") + "-12/31之剩餘時數";
                                    doubleSecondPartFinal += doubleFirstPartFinal;
                                    strSecondPartDayOff = doubleSecondPartFinal.ToString();
                                }
                                else if (doubleFirstPartFinal < 0)
                                {
                                    doubleFirstPartFinal *= -1;
                                    lblDayOffMemo.Text = "超休" + doubleFirstPartFinal.ToString() + "小時，於" + startDate.ToString("MM/dd") + "-12/31之特休時數扣除";
                                    doubleSecondPartFinal -= doubleFirstPartFinal;
                                    strSecondPartDayOff = doubleSecondPartFinal.ToString();
                                }
                                else
                                {
                                    lblDayOffMemo.Visible = false;
                                    lblDayOffMemo.Text = "";                                    
                                }
                            }
                            lblFirstPartDayOff.Visible = true;
                            if (Convert.ToInt16(dtUserInfo.Rows[0]["YEAR_IN_SERVICE"].ToString()) == 1 && Convert.ToInt16(dtUserInfo.Rows[0]["START_MONTH"].ToString()) > 6)
                            {
                                lblFirstPartDayOff.Text = startDate.AddMonths(6).ToString("MM/dd") + "-" + startDate.AddDays(-1).ToString("MM/dd") + " 剩餘: " + strFirstPartDayOff + "小時";
                            }
                            else
                            {
                                lblFirstPartDayOff.Text = "01/01-" + startDate.AddDays(-1).ToString("MM/dd") + " 剩餘: " + strFirstPartDayOff + "小時";
                            }
                            lblSecondPartDayOff.Text = startDate.ToString("MM/dd") + "-12/31 剩餘: " + strSecondPartDayOff + "小時";
                        }
                    }
                    else
                    {
                        lblFirstPartDayOff.Visible = false;
                        lblSecondPartDayOff.Visible = true;
                        lblSecondPartDayOff.Text = "N/A";
                    }                    
                    
                    //抓取剩餘補休時數(不需要為小倩(0010)特別做計算，因為使用的單位皆為小時)
                    SqlCommand cmdSelectMakeupDayOff = new SqlCommand("SELECT"
                                                        + " COALESCE(CONVERT(NVARCHAR,(SELECT PALTK.TK005 FROM PALTK WHERE PALTK.TK001=@ID AND PALTK.TK002=YEAR(GETDATE()))"
                                                        + " -COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)), N'N/A')"
                                                        + " FROM PALTL"
                                                        + " WHERE PALTL.TL001=@ID AND PALTL.TL002=YEAR(GETDATE()) AND PALTL.TL004='02'", conn);
                    cmdSelectMakeupDayOff.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    lblMakeupDayOff.Text = (string)cmdSelectMakeupDayOff.ExecuteScalar();
                    Session["makeupDayOff"] = lblMakeupDayOff.Text;
                    //conditional statement for salary adjustment notification
                    SqlCommand cmdSalaryAdj = new SqlCommand("SELECT PALTD.TD001"
                                                        + " FROM PALTD"
                                                        + " WHERE PALTD.TD008=N'Y' AND PALTD.TD001=@ID AND PALTD.TD002<@FIRSTDAY AND PALTD.TD002>@LASTDAY", conn);
                    cmdSalaryAdj.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmdSalaryAdj.Parameters.AddWithValue("@FIRSTDAY", DateTime.Today.AddDays(-4).ToString("yyyyMMdd"));
                    cmdSalaryAdj.Parameters.AddWithValue("@LASTDAY", DateTime.Today.AddMonths(-1).AddDays(-5).ToString("yyyyMMdd"));
                    SqlDataReader reader = cmdSalaryAdj.ExecuteReader();
                    if (reader.HasRows)
                    {
                        salaryAdjNotification.Visible = true;
                    }
                    else
                    {
                        salaryAdjNotification.Visible = false;
                    }
                }
                BindDataTorptCompanyAnnouncement();
            }
        }
    }

    /// <summary>
    /// Returns last login time
    /// if no previous login record, then returns the date 1900-01-01
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private DateTime GetLastLoginTime(string userId)
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = "select src.LoginAttemptTime" +
                " from" +
                " (" +
                " select ROW_NUMBER() over(order by LoginAttemptTime desc) as rowNumber" +
                " , LoginAttemptTime" +
                " from HR360_LoginLog" +
                " where [ID] = @userId" +
                " and LoginSuccessful = '1'" +
                " ) as src" +
                " where rowNumber = 2";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            return cmd.ExecuteScalar() == null ? new DateTime(1900, 01, 01) : DateTime.Parse(cmd.ExecuteScalar().ToString());
        }
    }
    #region Company Announcement Databinding and Repeater Pagination
    private DataTable GetCompanyAnnouncementData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = "SELECT LTRIM(RTRIM(ANNOUNCEMENT.[ID])) 'ID'"
                        + " ,LTRIM(RTRIM(ANNOUNCEMENT.[CREATE_TIME])) 'CREATE_TIME'"
                        + " ,LTRIM(RTRIM(ANNOUNCEMENT.[CREATOR])) 'CREATOR'"
                        + " ,LTRIM(RTRIM(ANNOUNCEMENT.[LAST_EDIT_TIME])) 'LAST_EDIT_TIME'"
                        + " ,LTRIM(RTRIM(MV.MV002)) 'LAST_EDITOR'"
                        + " ,LTRIM(RTRIM(ANNOUNCEMENT.[BODY])) 'BODY'"
                        + " ,ANNOUNCEMENT.[VISIBLE]"
                        + " ,ANNOUNCEMENT.ON_TOP"
                        + " FROM HR360_COMPANYANNOUNCEMENT ANNOUNCEMENT"
                        + " LEFT JOIN NZ.dbo.CMSMV MV ON ANNOUNCEMENT.LAST_EDITOR=MV.MV001"
                        + " WHERE [VISIBLE]=1"
                        + " ORDER BY ANNOUNCEMENT.ON_TOP DESC, ANNOUNCEMENT.[ID] DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }
    private void BindDataTorptCompanyAnnouncement()
    {
        DataTable dt = GetCompanyAnnouncementData();
        _pgsource.DataSource = dt.DefaultView;
        _pgsource.AllowPaging = true;
        //Number of items to be displaed in the Repeater
        _pgsource.PageSize = _pageSize;
        _pgsource.CurrentPageIndex = CurrentPage;
        //Keep the total pages in ViewState
        ViewState["TotalPages"] = _pgsource.PageCount;
        //Ex. 3/10
        lblPage.Text = (CurrentPage + 1) + "/" + _pgsource.PageCount;
        //Enable Control Buttons
        if (!_pgsource.IsFirstPage)
        {
            lbFirst.Enabled = true;
            lbFirst.ForeColor = ColorTranslator.FromHtml("#337ab7");
            lbPrevious.Enabled = true;
            lbPrevious.ForeColor = ColorTranslator.FromHtml("#337ab7");
        }
        else
        {
            lbFirst.Enabled = false;
            lbFirst.ForeColor = Color.Gray;            
            lbPrevious.Enabled = false;
            lbPrevious.ForeColor = Color.Gray;
        }
        if (!_pgsource.IsLastPage)
        {
            lbLast.Enabled = true;
            lbLast.ForeColor = ColorTranslator.FromHtml("#337ab7");
            lbNext.Enabled = true;
            lbNext.ForeColor = ColorTranslator.FromHtml("#337ab7");
        }
        else
        {
            lbLast.Enabled = false;
            lbLast.ForeColor = Color.Gray;
            lbNext.Enabled = false;
            lbNext.ForeColor = Color.Gray;
        }
        //lbFirst.Enabled = !_pgsource.IsFirstPage;
        //lbPrevious.Enabled = !_pgsource.IsFirstPage;
        //lbNext.Enabled = !_pgsource.IsLastPage;
        //lbLast.Enabled = !_pgsource.IsLastPage;

        rptCompanyAnnouncement.DataSource = _pgsource;
        rptCompanyAnnouncement.DataBind();

        
        foreach(RepeaterItem item in rptCompanyAnnouncement.Items)
        {
            //Display "new" announcement indicator if announcement less than 7 days old, or is posted AFTER user's last login
            HtmlGenericControl div = (HtmlGenericControl)item.FindControl("newIcon");
            HiddenField hdnLastEdit = (HiddenField)item.FindControl("hdnLastEdit");

            if(DateTime.Parse(hdnLastEdit.Value) >= lastLoginTime || DateTime.Parse(hdnLastEdit.Value) >= DateTime.Today.AddDays(-7))
            {
                div.Visible = true;
            }
            else
            {
                div.Visible = false;
            }

            //Get attachment for each announcement
            HiddenField hdnAnnouncementId = (HiddenField)item.FindControl("hdnAnnouncementId");
            //string attachmentFilePath = Path.Combine(Application.StartupPath, @"..\..\attachment\company_announcement\" + hdnAnnouncementId.Value + @"\");

        }




        HandlePaging();
    }

    private void HandlePaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");  //starts from 0
        dt.Columns.Add("PageText");  //starts from 1

        _firstIndex = CurrentPage - 2;
        if (CurrentPage > 2)
        {
            _lastIndex = CurrentPage + 2;
        }
        else
        {
            _lastIndex = 4;
        }

        //check last index to see if it's greater than total pages
        if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            _firstIndex = _lastIndex - 4;
        }
        if (_firstIndex < 0)
        {
            _firstIndex = 0;
        }

        //create page number based on the calculation above
        for (int i = _firstIndex; i < _lastIndex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        rptPaging.DataSource = dt;
        rptPaging.DataBind();
    }
    protected void lbFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        BindDataTorptCompanyAnnouncement();
    }
    protected void lbPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        BindDataTorptCompanyAnnouncement();
    }
    protected void lbNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        BindDataTorptCompanyAnnouncement();
    }
    protected void lbLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        BindDataTorptCompanyAnnouncement();
    }
    protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!e.CommandName.Equals("newPage")) return;
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindDataTorptCompanyAnnouncement();
    }
    protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        var lb = (LinkButton)e.Item.FindControl("lbPaging");
        if (lb.CommandArgument != CurrentPage.ToString()) return;
        lb.Enabled = false;
        lb.ForeColor = Color.FromName("#333333");
    }
    #endregion
}