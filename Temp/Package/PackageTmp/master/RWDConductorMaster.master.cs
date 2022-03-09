using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class master_RWDConductorMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["language"] == null)
            {
                Session["language"] = "zh";
            }
            BuildMenu(Session["language"].ToString());
        }
    }

    protected void BuildMenu(string language)
    {
        AddMenuItem(language, "copper", "純銅系列", "Copper");
        AddMenuItem(language, "silver-copper-alloy", "銀銅合金", "Silver-Copper Alloy");
        AddMenuItem(language, "tin-copper-alloy", "錫銅合金", "Tin-Copper Alloy");
        AddMenuItem(language, "nickel-copper-alloy", "鎳銅合金", "Nickel-Copper Alloy");
        AddMenuItem(language, "silver", "純銀及銀合金", "Silver");
    }

    protected void AddMenuItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divNavItem = new HtmlGenericControl("div");
        divNavItem.Attributes.Add("class", "nav-item");
        ulMenuList.Controls.Add(divNavItem);
        HtmlGenericControl aNavLink = new HtmlGenericControl("a");
        aNavLink.Attributes.Add("class", "nav-link");
        aNavLink.Attributes.Add("href", "/" + language + "/material/conductor/" + id);
        if (language == "zh")
        {
            aNavLink.InnerText = zhText;
        }
        else
        {
            aNavLink.InnerText = enText;
        }
        divNavItem.Controls.Add(aNavLink);
    }
}
