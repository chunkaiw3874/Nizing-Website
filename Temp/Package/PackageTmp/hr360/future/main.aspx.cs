using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class hr360_mobile_main : System.Web.UI.Page
{
    //need to figure out how to call non-static method in static method for jquery to call static webmethod which contains non-static method

    string NzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string SunrizeConnectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;

    public DataTable dtAnnouncementData = new DataTable();
    public string jsonAnnouncementData;
    public byte[] blob;
    public string defaultERPDbConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HR360LoggedUser.Company == "NIZING")
        {
            defaultERPDbConnectionString = NzConnectionString;
        }
        else
        {
            defaultERPDbConnectionString = SunrizeConnectionString;
        }

        LoadNewsFromDB();
        jsonAnnouncementData = ConvertDtToString(dtAnnouncementData);
        LoadBlob();

        //DataTable dtUserInfo = new DataTable();
        double doubleFirstPartDayOff = 0;
        double doubleSecondPartDayOff = 0;
        double doubleFirstPartDayOffUsed = 0;
        double doubleSecondPartDayOffUsed = 0;
        double doubleFirstPartFinal = 0;
        double doubleSecondPartFinal = 0;
        string strFirstPartDayOff = "";
        string strSecondPartDayOff = "";

        lblName.Text = HR360LoggedUser.Name;
        Session["name"] = lblName.Text;
        //using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        //{
        //    conn.Open();
        //    SqlCommand cmdSelect = new SqlCommand("SELECT NAME"
        //                                        + " FROM HR360_BI01_A"
        //                                        + " WHERE ID=@ID" +
        //                                        " and COMPANY=@COMPANY", conn);
        //    try
        //    {
        //        cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
        //        cmdSelect.Parameters.AddWithValue("@COMPANY", Session["company"].ToString());
        //    }
        //    catch
        //    {

        //        Response.Redirect("login.aspx");
        //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        //    }
            
            
            
        //}
        //Get user's Year of Service, and the Month of when the user started                
        //using (SqlConnection conn = new SqlConnection(defaultERPDbConnectionString))
        //{
        //    conn.Open();
        //    string query = "SELECT YEAR(GETDATE())-SUBSTRING(MV.MV021,1,4) 'YEAR_IN_SERVICE'" +
        //        " , SUBSTRING(MV.MV021,1,4) 'START_YEAR'" +
        //        " , SUBSTRING(MV.MV021,5,2) 'START_MONTH'" +
        //        " , SUBSTRING(MV.MV021,7,2) 'START_DAY'"
        //                + " FROM CMSMV MV"
        //                + " WHERE MV.MV001=@ID";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dtUserInfo);
        //}
        //Map User's annual leave days from _HR360_ANNUAL_LEAVE_TABLE with data in dtUserInfo
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            if (!String.IsNullOrWhiteSpace(HR360LoggedUser.ERPId))
            {
                conn.Open();
                string query = "SELECT [" + HR360LoggedUser.StartDate.Month.ToString("D2") + "]"
                            + " FROM _HR360_ANNUAL_LEAVE_TABLE"
                            + " WHERE YEAR_IN_SERVICE=@YEAR_IN_SERVICE";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@YEAR_IN_SERVICE",
                    DateTime.Today.Year - HR360LoggedUser.StartDate.Year < 25 ?
                    DateTime.Today.Year - HR360LoggedUser.StartDate.Year : 25);
                string tempString = cmd.ExecuteScalar().ToString();
                string[] tempStringArray;
                string[] stringSeparators = new string[] { "," };
                tempStringArray = tempString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                doubleFirstPartDayOff = Convert.ToDouble(tempStringArray[0]);
                doubleSecondPartDayOff = Convert.ToDouble(tempStringArray[1]);
            }
        }
        using (SqlConnection conn = new SqlConnection(defaultERPDbConnectionString))
        {
            conn.Open();
            if (!String.IsNullOrWhiteSpace(HR360LoggedUser.ERPId))
            {
                //使用PALTL請假明細計算剩餘特休時數因為PALTK自動計算會有誤差
                string query = "SELECT COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)"
                            + " FROM PALTL"
                            + " WHERE PALTL.TL001=@ID"
                            + " AND PALTL.TL002=YEAR(GETDATE())"
                            + " AND PALTL.TL003 BETWEEN '01' AND @MONTH"
                            + " AND PALTL.TL004='03'";
                SqlCommand cmdSelect = new SqlCommand(query, conn);
                cmdSelect.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
                cmdSelect.Parameters.AddWithValue("@MONTH", HR360LoggedUser.StartDate.AddMonths(-1).Month.ToString("D2"));
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
                cmdSelect.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
                cmdSelect.Parameters.AddWithValue("@MONTH", HR360LoggedUser.StartDate.Month.ToString("D2"));
                doubleSecondPartDayOffUsed = Convert.ToDouble(cmdSelect.ExecuteScalar());
                doubleSecondPartFinal = doubleSecondPartDayOff * 8 - doubleSecondPartDayOffUsed;
                strSecondPartDayOff = doubleSecondPartFinal.ToString();
            }
            //Comment out with old way, uncomment with new way
            if (!String.IsNullOrWhiteSpace(HR360LoggedUser.ERPId))
            {
                if (HR360LoggedUser.StartDate.Month.ToString("D2") == "01")
                {
                    lblFirstPartDayOff.Visible = false;
                    lblDayOffMemo.Visible = false;
                }
                else
                {
                    if (DateTime.Today < new DateTime(DateTime.Today.Year, HR360LoggedUser.StartDate.Month, HR360LoggedUser.StartDate.Day))
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
                            lblDayOffMemo.Text = "上半季未休完之" + doubleFirstPartFinal.ToString() + "小時併入" + HR360LoggedUser.StartDate.ToString("MM/dd") + "-12/31之剩餘時數";
                            doubleSecondPartFinal += doubleFirstPartFinal;
                            strSecondPartDayOff = doubleSecondPartFinal.ToString();
                        }
                        else if (doubleFirstPartFinal < 0)
                        {
                            doubleFirstPartFinal *= -1;
                            lblDayOffMemo.Text = "超休" + doubleFirstPartFinal.ToString() + "小時，於" + HR360LoggedUser.StartDate.ToString("MM/dd") + "-12/31之特休時數扣除";
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
                    lblFirstPartDayOff.Text = "01/01-" + HR360LoggedUser.StartDate.AddDays(-1).ToString("MM/dd") + " 剩餘: " + strFirstPartDayOff + "小時";
                    lblSecondPartDayOff.Text = HR360LoggedUser.StartDate.ToString("MM/dd") + "-12/31 剩餘: " + strSecondPartDayOff + "小時";
                }
            }
            else
            {
                lblFirstPartDayOff.Visible = false;
                lblSecondPartDayOff.Visible = true;
                lblSecondPartDayOff.Text = "N/A";
            }

            Session["firstPartDayOff"] = doubleFirstPartFinal;
            Session["secondPartDayOff"] = doubleSecondPartFinal;
            Session["startYear"] = HR360LoggedUser.StartDate.Year;
            Session["startDate"] = HR360LoggedUser.StartDate.Month.ToString("D2") + HR360LoggedUser.StartDate.Day.ToString("D2");
            //Session["startYear"] = dtUserInfo.Rows[0]["START_YEAR"].ToString();
            //Session["startDate"] = dtUserInfo.Rows[0]["START_MONTH"].ToString() + dtUserInfo.Rows[0]["START_DAY"].ToString();

            //抓取剩餘補休時數(不需要為小倩(0010)特別做計算，因為使用的單位皆為小時)
            SqlCommand cmdSelectMakeupDayOff = new SqlCommand("SELECT"
                                                + " COALESCE(CONVERT(NVARCHAR,(SELECT PALTK.TK005 FROM PALTK WHERE PALTK.TK001=@ID AND PALTK.TK002=YEAR(GETDATE()))"
                                                + " -COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)), N'N/A')"
                                                + " FROM PALTL"
                                                + " WHERE PALTL.TL001=@ID AND PALTL.TL002=YEAR(GETDATE()) AND PALTL.TL004='02'", conn);
            cmdSelectMakeupDayOff.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
            lblMakeupDayOff.Text = cmdSelectMakeupDayOff.ExecuteScalar().ToString() == "N/A" ?
                "" :
                "剩餘: " + (Convert.ToDecimal(cmdSelectMakeupDayOff.ExecuteScalar())).ToString("0.00") + "小時";

            //調薪通知
            SqlCommand cmdSalaryAdj = new SqlCommand("SELECT PALTD.TD001"
                                                        + " FROM PALTD"
                                                        + " WHERE PALTD.TD008=N'Y' AND PALTD.TD001=@ID AND PALTD.TD002<@FIRSTDAY AND PALTD.TD002>@LASTDAY", conn);
            cmdSalaryAdj.Parameters.AddWithValue("@ID", HR360LoggedUser.ERPId);
            cmdSalaryAdj.Parameters.AddWithValue("@FIRSTDAY", DateTime.Today.AddDays(-4).ToString("yyyyMMdd"));
            cmdSalaryAdj.Parameters.AddWithValue("@LASTDAY", DateTime.Today.AddMonths(-1).AddDays(-5).ToString("yyyyMMdd"));
            SqlDataReader reader = cmdSalaryAdj.ExecuteReader();
            if (reader.HasRows)
            {
                hlSalaryNotification.Visible = true;
            }
            else
            {
                hlSalaryNotification.Visible = false;
            }
        }
    }
    private void LoadBlob()
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT [DATA] FROM HR360_FILE_STORAGE";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            blob = (byte[])cmd.ExecuteScalar();
            //SqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //Response.BinaryWrite((byte[])dr["DATA"]);
        }

    }
    private DataTable LoadNewsFromDB()
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT ROW_NUMBER() OVER (ORDER BY [CREATE_TIME] DESC, [ID] DESC) [ROW]"
                        + " ,ANNOUNCE.[ID]"
                        + " ,ANNOUNCE.[CREATE_TIME]"
                        + " ,ANNOUNCE.[CREATOR]"
                        + " ,MVCREATOR.MV002 [CREATOR_NAME]"
                        + " ,ANNOUNCE.[LAST_EDIT_TIME]"
                        + " ,ANNOUNCE.[LAST_EDITOR]"
                        + " ,MVEDITOR.MV002 [EDITOR_NAME]"
                        + " ,ANNOUNCE.[BODY]"
                        + " FROM HR360_COMPANYANNOUNCEMENT ANNOUNCE"
                        + " LEFT JOIN NZ.dbo.CMSMV MVCREATOR ON ANNOUNCE.[CREATOR] = MVCREATOR.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MVEDITOR ON ANNOUNCE.LAST_EDITOR = MVEDITOR.MV001";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtAnnouncementData);
        }
        return dtAnnouncementData;
    }
    private string ConvertDtToString(DataTable dt)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        DateTime result;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                if (DateTime.TryParse(dr[col].ToString(), out result))
                {
                    row.Add(col.ColumnName, result.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    row.Add(col.ColumnName, dr[col]);
                }

            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }
    private DataTable LoadDayoffFromDB()
    {
        DataTable dt = new DataTable();

        return dt;
    }
}