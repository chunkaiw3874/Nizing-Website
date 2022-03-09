using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class material : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RouteData.Values["language"] != null)
            {
                string language = RouteData.Values["language"].ToString();
                Session["language"] = language;
            }

            if (Session["language"] == null)
            {
                Session["language"] = "zh";
            }
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
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col material-list-wrapper");
        divMenuList.Controls.Add(divCol);
        HtmlGenericControl figureListItem = new HtmlGenericControl("div");
        figureListItem.Attributes.Add("class", "material-list-item move");
        divCol.Controls.Add(figureListItem);
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = "/" + language + "/material/" + id;
        a.Attributes.Add("class", "card-link");
        figureListItem.Controls.Add(a);
        HtmlGenericControl picture = new HtmlGenericControl("picture");
        a.Controls.Add(picture);
        HtmlSource imgsrc = new HtmlSource();
        imgsrc.Attributes.Add("srcset", "/images/material/" + id + "/menu/big-menu.webp");
        imgsrc.Attributes.Add("type", "image/webp");
        picture.Controls.Add(imgsrc);
        HtmlImage img = new HtmlImage();
        img.Attributes.Add("class", "shadow");
        img.Src = "/images/material/" + id + "/menu/big-menu.png";
        img.Alt = zhText + " " + enText;
        img.Attributes.Add("onerror", "onerror=null; this.src='/images/placeholder/product-image-placeholder.png'");
        picture.Controls.Add(img);
    }
}