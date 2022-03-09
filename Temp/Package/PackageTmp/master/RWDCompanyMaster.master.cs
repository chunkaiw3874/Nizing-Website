using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class master_RWDCompanyMaster : System.Web.UI.MasterPage
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
        AddMenuItem(language, "intro", "日進簡介", "Company");
        AddMenuItem(language, "culture", "企業核心價值與經營理念", "Culture");
        AddMenuItem(language, "history", "歷史歷程", "History");
        AddMenuItem(language, "capability", "生產設備", "Capability");
        AddMenuItem(language, "lab", "實驗室", "Lab");
    }

    protected void AddMenuItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divNavItem = new HtmlGenericControl("div");
        divNavItem.Attributes.Add("class", "nav-item");
        ulMenuList.Controls.Add(divNavItem);
        HtmlGenericControl aNavLink = new HtmlGenericControl("a");
        aNavLink.Attributes.Add("class", "nav-link");
        aNavLink.Attributes.Add("href", "/" + language + "/company/" + id);
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
