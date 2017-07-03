using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class masterPage_HR360_Child_user : System.Web.UI.MasterPage
{
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string userId = (string)Session["user_id"];
            //bool validation = (bool)(Session["validated"]);
            //DateTime start = new DateTime(2017, 1, 13, 19, 0, 0);
            //DateTime end = new DateTime(2017, 1, 19, 17, 30, 0);
            //if (IsPostBack)
            //{
            //    if (userId != "CHRISSY" && userId != "KELVEN" && userId != "0067" && userId != "0080")  //此ID任何時候皆可看評核表
            //    {
            //        if (DateTime.Now >= start && DateTime.Now < end) //set access window - this page has 2 places need to change for access windows
            //        {
            //            //imgbtnUI05.PostBackUrl = "~/hr360/UI05.aspx";
            //        }
            //        else
            //        {
            //            imgbtnUI05.PostBackUrl = "";
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('開放評核時間為" + start.ToString() + "至" + end.ToString() + "');", true);
            //        }
            //    }
            //}
            //else
            //{
            //    if (userId != "CHRISSY" && userId != "KELVEN" && userId != "0067" && userId != "0080")  //此ID任何時候皆可看評核表
            //    {
            //        if (DateTime.Now >= start && DateTime.Now < end) //set access window - this page has 2 places need to change for access windows
            //        {
            //            imgbtnUI05.PostBackUrl = "~/hr360/UI05.aspx";
            //        }
            //        else
            //        {
            //            imgbtnUI05.PostBackUrl = "";                        
            //        }
            //    }
            //}
        }
        catch
        {
            Server.Transfer("~/hr360/no_permission.aspx"); //session expires and value stored in session value disappears
        }
    }
    //calling encrypting method from parent master
    public string Encrypt(string clearText)
    {
        return ((masterPage_HR360_Master)this.Master).Encrypt(clearText);
    }
    public string Decrypt(string cipherText)
    {
        return ((masterPage_HR360_Master)this.Master).Decrypt(cipherText);
    }
    protected string GetUserName(string strIn)
    {
        string name = "";
        using (SqlConnection conn = new SqlConnection(NZConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT CMSMV.MV002 FROM CMSMV WHERE CMSMV.MV001 = N'" + strIn + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            else
            {
                name = "此使用者不存在";
            }
        }
        return name;
    }
    protected void btnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/hr360/login.aspx");
    }
    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/hr360/main.aspx");
    }

    protected void btnAdminPage_Click(object sender, ImageClickEventArgs e)
    {
        if (((DataTable)Session["permission"]).Rows[0]["SUPER_USER"].ToString().Trim() == "1")
        {
            Response.Redirect("~/hr360/admin_main.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('無此權限');", true);
        }
    }
}
