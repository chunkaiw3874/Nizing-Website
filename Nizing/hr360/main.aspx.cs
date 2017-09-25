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

public partial class main : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["erp_id"] = "0067";
        //if (!((masterPage_HR360_Master)this.Master.Master).CheckAuthentication())
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        //}
        //else
        //{            
            if (!IsPostBack)
            {
                DataTable dtUserInfo = new DataTable();
                double doubleFirstPartDayOff = 0;
                double doubleSecondPartDayOff = 0;
                double doubleFirstPartDayOffUsed = 0;
                double doubleSecondPartDayOffUsed = 0;
                double doubleFirstPartFinal = 0;
                double doubleSecondPartFinal = 0;
                string strFirstPartDayOff = "";
                string strSecondPartDayOff = "";

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
                    string query = "SELECT YEAR(GETDATE())-SUBSTRING(MV.MV021,1,4) 'YEAR_IN_SERVICE', SUBSTRING(MV.MV021,5,2) 'START_MONTH', SUBSTRING(MV.MV021,7,2) 'START_DAY'"
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
                        cmd.Parameters.AddWithValue("@YEAR_IN_SERVICE", dtUserInfo.Rows[0]["YEAR_IN_SERVICE"].ToString());
                        string tempString = cmd.ExecuteScalar().ToString();
                        string[] tempStringArray;
                        string[] stringSeparators = new string[] { "," };
                        tempStringArray = tempString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        doubleFirstPartDayOff = Convert.ToDouble(tempStringArray[0]);
                        doubleSecondPartDayOff = Convert.ToDouble(tempStringArray[1]);
                    }
                }                
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    if (dtUserInfo.Rows.Count > 0)
                    {
                        //使用PALTL請假明細計算剩餘特休時數因為PALTK自動計算會有誤差
                        //為0010特別做計算，因為0010一天是8.5小時，其他人一天為8小時
                        if (Session["erp_id"].ToString() == "0010")
                        {
                            //Old way, uses ERP data for Annual Leave amount, obsolete since 2017.09.04 after government changed method to 歷年制
                            //SqlCommand cmdSelect = new SqlCommand("SELECT"
                            //                                + " CONVERT(NVARCHAR,(SELECT PALTK.TK003*8.5 FROM PALTK WHERE PALTK.TK001=@ID AND PALTK.TK002=YEAR(GETDATE()))"
                            //                                + " -COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0))"
                            //                                + " FROM PALTL"
                            //                                + " WHERE PALTL.TL001=@ID AND PALTL.TL002=YEAR(GETDATE()) AND PALTL.TL004='03'", conn);
                            //Comment part is the new way, replace the old way above
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
                            //strSecondPartDayOff = doubleSecondPartFinal.ToString();
                        }
                        else
                        {
                            //Old way, uses ERP data for Annual Leave amount, obsolete since 2017.09.04 after government changed method to 歷年制
                            //SqlCommand cmdSelect = new SqlCommand("SELECT"
                            //                                + " COALESCE(CONVERT(NVARCHAR,(SELECT PALTK.TK003*8 FROM PALTK WHERE PALTK.TK001=@ID AND PALTK.TK002=YEAR(GETDATE()))"
                            //                                + " -COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)), N'N/A')"
                            //                                + " FROM PALTL"
                            //                                + " WHERE PALTL.TL001=@ID AND PALTL.TL002=YEAR(GETDATE()) AND PALTL.TL004='03'", conn);
                            //Comment part is the new way, replace the old way above
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
                            lblFirstPartDayOff.Text = cmdSelect.ExecuteScalar().ToString();

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
                    //Comment out with old way, uncomment with new way
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
                                lblFirstPartDayOff.Visible = true;
                                lblFirstPartDayOff.Text = "01/01-" + startDate.AddDays(-1).ToString("MM/dd") + " 剩餘: " + strFirstPartDayOff + "小時";                                                            
                            }
                            lblSecondPartDayOff.Text = startDate.ToString("MM/dd") + "-12/31 剩餘: " + strSecondPartDayOff;
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
            }
        //}
    }
}