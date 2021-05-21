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
using System.Globalization;

public partial class hr360_mobile_login : System.Web.UI.Page
{
    string NzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string SunrizeConnectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;

    public string defaultERPDbConnectionString;

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
        ////TEST
        //HR360LoggedUser.HR360Id = "0164";
        //HR360LoggedUser.ERPId = "0164";
        //HR360LoggedUser.Company = "NIZING";
        //GetLoggedUserInfo(HR360LoggedUser.ERPId, HR360LoggedUser.Company);
        //Session["user_id"] = HR360LoggedUser.HR360Id;
        //Session["erp_id"] = HR360LoggedUser.ERPId;
        //Session["company"] = HR360LoggedUser.Company;
        //Response.Redirect("main.aspx");

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
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
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
        if (dt.Rows.Count == 0 || SiteUtils.Decrypt(dt.Rows[0]["PASSWORD"].ToString()) != txtPassword.Text)
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
        else if (SiteUtils.Decrypt(dt.Rows[0]["PASSWORD"].ToString()) == txtPassword.Text)
        {
            match = true;
            HR360LoggedUser.HR360Id = dt.Rows[0]["ID"].ToString().Trim();
            HR360LoggedUser.ERPId = dt.Rows[0]["ERP_ID"].ToString().Trim();
            HR360LoggedUser.Company = dt.Rows[0]["COMPANY"].ToString().Trim();

            GetLoggedUserInfo(HR360LoggedUser.ERPId, HR360LoggedUser.Company);
            Session["user_id"] = dt.Rows[0]["ID"].ToString();
            Session["erp_id"] = dt.Rows[0]["ERP_ID"].ToString();
            Session["company"] = dt.Rows[0]["COMPANY"].ToString();
        }
        return match;
    }

    //public void SetlblLoginMessageText(string s)
    //{
    //    lblLoginMessage.Text = s;
    //}

    protected void btnNizingWebsite_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }

    protected void GetLoggedUserInfo(string erpId, string company)
    {
        if (company == "NIZING")
        {
            defaultERPDbConnectionString = NzConnectionString;
        }
        else
        {
            defaultERPDbConnectionString = SunrizeConnectionString;
        }

        using (SqlConnection conn = new SqlConnection(defaultERPDbConnectionString))
        {
            conn.Open();
            string query = "select top 1 MV.MV001 'id'" +
                " ,MV.MV002 'name'" +
                " ,MV.MV004 'dept'" +
                " ,MV.MV007 'sex'" +
                " ,MV.MV021 'startDate'" +
                " from CMSMV MV" +
                " where MV.MV001=@id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", erpId);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                HR360LoggedUser.Name = dt.Rows[0]["name"].ToString().Trim();
                HR360LoggedUser.Dept = dt.Rows[0]["dept"].ToString().Trim();
                HR360LoggedUser.Sex = dt.Rows[0]["sex"].ToString().Trim() == "1" ? "M" : "F";
                HR360LoggedUser.StartDate = DateTime.ParseExact(dt.Rows[0]["startDate"].ToString().Trim(), "yyyyMMdd", null, DateTimeStyles.None);
            }
        }
    }
}