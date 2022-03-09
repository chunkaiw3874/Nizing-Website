﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {   
        HR360Login.Focus();
    }
    protected void HR360Login_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        try
        {
            if (Login_Validation(HR360Login.UserName, HR360Login.Password))
            {
                Read_Permission(HR360Login.UserName);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO HR360_LoginLog ([ID],LoginAttemptTime,LoginSuccessful)"
                                + "VALUES (@ID,GETDATE(),1)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", HR360Login.UserName);
                    cmd.ExecuteNonQuery();

                }
                Response.Redirect("~/hr360/main.aspx");
            }
            else
            {
                
                e.Cancel = true;
            }

        }
        catch
        {

        }

    }
    protected bool Login_Validation(string username, string password)
    {
        bool match = false;

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID], [PASSWORD] FROM [HR360_BI01_A] WHERE [DISABLED] = N'0' AND [ID] = N'" + username.ToUpper().Trim() + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (password == ((masterPage_HR360_Master)this.Master).Decrypt(reader.GetString(1)))
                        {
                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            HR360Login.InstructionText = "";
                            Session["user_id"] = username.ToUpper().Trim();                            
                            Session["validated"] = true;
                            SqlCommand cmdSelect = new SqlCommand("SELECT ERP_ID"
                                                                + " FROM HR360_BI01_A"
                                                                + " WHERE [ID]=@ID", conn);
                            cmdSelect.Parameters.AddWithValue("@ID", Session["user_id"].ToString());
                            Session["erp_id"] = (string)cmdSelect.ExecuteScalar();
                            
                            match = true;
                        }
                        else
                        {
                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                            string query = "INSERT INTO HR360_LoginLog ([ID],LoginAttemptTime,LoginSuccessful)"
                                + "VALUES (@ID,GETDATE(),0)";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ID", username.ToUpper().Trim());
                            cmd.ExecuteNonQuery();
                            lblErrorMessage.Text = "密碼不正確，如忘記密碼，請聯絡管理員";
                            match = false;
                        }
                    }
                }
                else
                {
                    lblErrorMessage.Text = "使用者名稱不存在，請使用員工編號";
                    match = false;
                }
                if(!reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }
        catch
        {
        }
        return match;
    }

    protected void Read_Permission(string userId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT [SUPER_USER]"
                        + " FROM [HR360_BI01_A]"
                        + " WHERE [ID]=@USER_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
//            SqlCommand cmdSearch = new SqlCommand(
//"SELECT [HR360_BI03_A].[ID] CATEGORY_ID, [HR360_BI03_A].[IMAGE_URL] CATEGORY_IMGURL, [HR360_BI03_B].[ID] MODULE_ID, [HR360_BI03_B].[IMAGE_URL] MODULE_IMGURL, [HR360_BI03_B].[URL] MODULE_URL, [HR360_BI01_A].[SUPER_USER], [HR360_BI02_A].[EXECUTE], [HR360_BI02_A].[ADD], [HR360_BI02_A].[SEARCH], [HR360_BI02_A].[EDIT], [HR360_BI02_A].[OUTPUT], [HR360_BI02_A].[DELETE]"
//+ " ,[HR360_BI02_A].[USER_ID]"
//+ " FROM [HR360_BI02_A]"
//+ " LEFT JOIN [HR360_BI01_A] ON [HR360_BI02_A].[USER_ID] = [HR360_BI01_A].[ID]"
//+ " LEFT JOIN [HR360_BI03_B] ON [HR360_BI02_A].[MODULE_ID] = [HR360_BI03_B].[ID]"
//+ " LEFT JOIN [HR360_BI03_A] ON [HR360_BI03_B].[CATEGORY_ID] = [HR360_BI03_A].[ID]"
//+ " WHERE [HR360_BI02_A].[USER_ID] = @USER_ID"
//+ " ORDER BY [HR360_BI03_A].[SEQ_NO], [HR360_BI03_B].[ID]", conn);
            cmd.Parameters.AddWithValue("@USER_ID", userId.ToUpper());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        Session["permission"] = dt;
    }


}