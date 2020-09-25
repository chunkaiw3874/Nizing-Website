using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class masterPage_HR360_Child_user : masterPage_HR360_Master
{
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

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
        Response.Redirect("~/hr360/mobile/login.aspx");
    }
    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/hr360/mobile/main.aspx");
    }

    protected void btnAdminPage_Click(object sender, ImageClickEventArgs e)
    {
        if (((DataTable)Session["permission"]).Rows[0]["SUPER_USER"].ToString().ToUpper().Equals("TRUE"))
        {
            Response.Redirect("~/hr360/admin_main.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('無此權限');", true);
        }
    }
}
