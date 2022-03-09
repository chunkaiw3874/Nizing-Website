using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class master_RWDMaterialMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BuildMenu(Session["language"].ToString());
        }
    }

    protected void BuildMenu(string language)
    {
        AddMenuItem(language, "conductor", "導體系列", "Conductor");
        AddMenuItem(language, "silicone", "矽膠原料", "Silicone");
        AddMenuItem(language, "teflon", "鐵氟龍材料", "Teflon");
        AddMenuItem(language, "plastic", "塑膠原料", "Plastic");
        AddMenuItem(language, "twinning", "編織纏繞材料", "Twinning");
        AddMenuItem(language, "thermoplastic-elastomer", "熱可塑性彈性體", "TPE");
    }

    protected void AddMenuItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divNavItem = new HtmlGenericControl("div");
        divNavItem.Attributes.Add("class", "nav-item");
        ulMenuList.Controls.Add(divNavItem);
        HtmlGenericControl aNavLink = new HtmlGenericControl("a");
        aNavLink.Attributes.Add("class", "nav-link");
        aNavLink.Attributes.Add("href", "/" + language + "/material/" + id);
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
