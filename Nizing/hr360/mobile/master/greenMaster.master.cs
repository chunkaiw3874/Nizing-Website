using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_mobile_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!CheckAuthentication())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');", true);
            Response.Redirect("login.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public bool CheckAuthentication()
    {
        //if (Session["user_id"] == null)
        //{            
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}
        if (Session.Keys.Count == 0)
        {
            return false;
        }
        else
        {
            foreach (string key in Session.Keys)
            {
                if (Session[key] == null)
                {
                    return false;
                }
            }
        }

        return true;
    }

    protected void Logout()
    {
        Session["user_id"] = null;
        Session["erp_id"] = null;
        Session["company"] = null;
        Response.Redirect("login.aspx");
    }
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
}
