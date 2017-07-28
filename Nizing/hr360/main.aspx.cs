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
        //if (!((masterPage_HR360_Master)this.Master.Master).CheckAuthentication())
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        //}
        //else
        //{
            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(ERP2connectionString))
                {
                    conn.Open();
                    SqlCommand cmdSelect = new SqlCommand("SELECT NAME"
                                                        + " FROM HR360_BI01_A"
                                                        + " WHERE ID=@ID", conn);
                    cmdSelect.Parameters.AddWithValue("@ID", Session["user_id"].ToString());
                    lblName.Text = (string)cmdSelect.ExecuteScalar();
                }
                using (SqlConnection conn = new SqlConnection(NZconnectionString))
                {
                    conn.Open();
                    //使用PALTL請假明細計算剩餘特休時數因為PALTK自動計算會有誤差
                    //為0010特別做計算，因為0010一天是8.5小時，其他人一天為8小時
                    if (Session["erp_id"].ToString() == "0010")
                    {
                        SqlCommand cmdSelect = new SqlCommand("SELECT"
                                                        + " CONVERT(NVARCHAR,(SELECT PALTK.TK003*8.5 FROM PALTK WHERE PALTK.TK001=@ID AND PALTK.TK002=YEAR(GETDATE()))"
                                                        + " -COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0))"
                                                        + " FROM PALTL"
                                                        + " WHERE PALTL.TL001=@ID AND PALTL.TL002=YEAR(GETDATE()) AND PALTL.TL004='03'", conn);
                        cmdSelect.Parameters.AddWithValue("@ID", Session["user_id"].ToString());
                        lblDayOff.Text = (string)cmdSelect.ExecuteScalar();
                    }
                    else
                    {
                        SqlCommand cmdSelect = new SqlCommand("SELECT"
                                                        + " COALESCE(CONVERT(NVARCHAR,(SELECT PALTK.TK003*8 FROM PALTK WHERE PALTK.TK001=@ID AND PALTK.TK002=YEAR(GETDATE()))"
                                                        + " -COALESCE(SUM(COALESCE(PALTL.TL006,0))+SUM(COALESCE(PALTL.TL007,0)),0)), N'N/A')"
                                                        + " FROM PALTL"
                                                        + " WHERE PALTL.TL001=@ID AND PALTL.TL002=YEAR(GETDATE()) AND PALTL.TL004='03'", conn);
                        cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                        lblDayOff.Text = (string)cmdSelect.ExecuteScalar();
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