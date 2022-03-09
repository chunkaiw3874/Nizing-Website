using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        if(HR360LoggedUser.HR360Id.ToUpper() == "CHRISSY"
            || HR360LoggedUser.HR360Id == "0080")
        {
            BuildAdminMenu();
        }
    }

    protected void BuildAdminMenu()
    {
        AddMenuItem("獎懲單建立作業", "/hr360/mobile/RewardAndPunishmentSlip.aspx");
    }

    protected void AddMenuItem(string text, string url)
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        li.Attributes.Add("class", "nav-item");
        menuList.Controls.Add(li);
        HtmlAnchor a = new HtmlAnchor();
        a.Attributes.Add("class", "nav-link");
        a.HRef = url;
        a.InnerText = text;
        li.Controls.Add(a);
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
