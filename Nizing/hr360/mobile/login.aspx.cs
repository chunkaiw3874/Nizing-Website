using System;
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
            ddlCompany.Items.Add(new ListItem("日進電線", "NIZING"));
            ddlCompany.Items.Add(new ListItem("日出國際", "SUNRIZE"));
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
        string companyCondition = "";
        if(username.ToUpper() != "ADMIN")
        {
            companyCondition = " and COMPANY=@company";
        }
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "SELECT [PASSWORD],[DISABLED],[ID],[ERP_ID],[COMPANY]"
                        + " FROM HR360_BI01_A"
                        + " WHERE [ID]=@ID"
                        + companyCondition;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", username.ToUpper());
            cmd.Parameters.AddWithValue("@company", ddlCompany.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        if (dt.Rows.Count == 0 || Utils.Decrypt(dt.Rows[0]["PASSWORD"].ToString()) != txtPassword.Text)
        {
            lblLoginMessage.Text = "帳號或密碼錯誤，請重新輸入";
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
        else if (Utils.Decrypt(dt.Rows[0]["PASSWORD"].ToString()) == txtPassword.Text)
        {
            match = true;
            Session["user_id"] = dt.Rows[0]["ID"].ToString();
            Session["erp_id"] = dt.Rows[0]["ERP_ID"].ToString();
            Session["company"] = dt.Rows[0]["COMPANY"].ToString();
        }
        return match;
    }

    public void SetlblLoginMessageText(string s)
    {
        lblLoginMessage.Text = s;
    }

    protected void btnNizingWebsite_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}