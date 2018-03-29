﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_mobile_login : System.Web.UI.Page
{
    string erp2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["user_id"] = null;
            Session["erp_id"] = null;
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblLoginMessage.Text = "";
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (isValid(txtUsername.Text, txtPassword.Text))
        {
            lblLoginMessage.Text = "成功登入";
            lblLoginMessage.ForeColor = Color.Green;
            Response.Redirect("main.aspx");            
        }
    }

    protected bool isValid(string username, string password)
    {
        bool match = false;
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "SELECT [PASSWORD],[DISABLED],[ID],[ERP_ID]"
                        + " FROM HR360_BI01_A"
                        + " WHERE [ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", txtUsername.Text.ToUpper());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        if (dt.Rows.Count == 0)
        {
            lblLoginMessage.Text = "帳號錯誤，請輸入正確帳號";
            txtPassword.Text = "";
            lblLoginMessage.ForeColor = Color.Red;
            txtUsername.Focus();
            match = false;
        }
        else if (dt.Rows[0]["DISABLED"].ToString() == "1")
        {
            lblLoginMessage.Text = "帳號已被停用，請聯絡管理員";
            txtPassword.Text = "";
            lblLoginMessage.ForeColor = Color.Red;
            txtUsername.Focus();
            match = false;
        }
        else if (Decrypt(dt.Rows[0]["PASSWORD"].ToString()) != txtPassword.Text)
        {
            lblLoginMessage.Text = "密碼不正確";
            txtPassword.Text = "";
            lblLoginMessage.ForeColor = Color.Red;
            txtUsername.Focus();
            match = false;
        }
        else if (Decrypt(dt.Rows[0]["PASSWORD"].ToString()) == txtPassword.Text)
        {
            match = true;
            Session["user_id"] = dt.Rows[0]["ID"].ToString();
            Session["erp_id"] = dt.Rows[0]["ERP_ID"].ToString();
        }
        return match;
    }
    public string Decrypt(string cipherText)
    {
        string EncryptionKey = "IMTHEBOSS999";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}