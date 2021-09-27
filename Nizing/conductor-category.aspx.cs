using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
<<<<<<< HEAD
using System.Web.UI.HtmlControls;
=======
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
using System.Web.UI.WebControls;

public partial class conductor_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
<<<<<<< HEAD
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
        AddMenuItem(language, "silver", "純銀系列", "Silver");
    }

    protected void AddMenuItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col conductor-list-wrapper");
        divMenuList.Controls.Add(divCol);
        HtmlGenericControl figureListItem = new HtmlGenericControl("div");
        figureListItem.Attributes.Add("class", "conductor-list-item move");
        divCol.Controls.Add(figureListItem);
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = "/" + language + "/material/conductor/" + id;
        a.Attributes.Add("class", "card-link");
        figureListItem.Controls.Add(a);
        HtmlGenericControl picture = new HtmlGenericControl("picture");
        a.Controls.Add(picture);
        HtmlSource imgsrc = new HtmlSource();
        imgsrc.Attributes.Add("srcset", "/images/material/conductor/" + id + "/menu/big-menu.webp");
        imgsrc.Attributes.Add("type", "image/webp");
        picture.Controls.Add(imgsrc);
        HtmlImage img = new HtmlImage();
        img.Attributes.Add("class", "shadow");
        img.Src = "/images/material/conductor/" + id + "/menu/big-menu.png";
        img.Alt = zhText + " " + enText;
        img.Attributes.Add("onerror", "onerror=null; this.src='/images/placeholder/product-image-placeholder.png'");
        picture.Controls.Add(img);
=======

>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
    }
}