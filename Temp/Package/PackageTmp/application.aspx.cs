using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class application : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
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
        if (!IsPostBack)
        {
            BuildMenu(Session["language"].ToString());
        }
    }

    protected void BuildMenu(string language)
    {
        DataTable dt = FetchMenuData();
        foreach (DataRow dr in dt.Rows)
        {
            AddItem(language, dr["ID"].ToString(), dr["zh"].ToString(), dr["en"].ToString());
        }
    }
    protected void AddItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col application-category-item");
        divItemList.Controls.Add(divCol);
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = "/" + language + "/application/" + id;
        divCol.Controls.Add(a);
        HtmlGenericControl figureOverlayParent = new HtmlGenericControl("figure");
        figureOverlayParent.Attributes.Add("class", "overlay-parent shadow move");
        a.Controls.Add(figureOverlayParent);
        HtmlGenericControl picture = new HtmlGenericControl("picture");
        figureOverlayParent.Controls.Add(picture);
        HtmlSource imgsrc = new HtmlSource();
        imgsrc.Attributes.Add("srcset", "/images/application/" + id + "/menu/big-menu.webp");
        imgsrc.Attributes.Add("type", "image/webp");
        picture.Controls.Add(imgsrc);
        HtmlImage img = new HtmlImage();
        img.Src = "/images/application/" + id + "/menu/big-menu.jpg";
        img.Alt = zhText + " " + enText;
        img.Attributes.Add("onerror", "onerror=null; this.src='/images/placeholder/product-image-placeholder.png'");
        picture.Controls.Add(img);
        HtmlGenericControl divOverlay = new HtmlGenericControl("div");
        divOverlay.Attributes.Add("class", "overlay");
        figureOverlayParent.Controls.Add(divOverlay);
        HtmlGenericControl figcaption = new HtmlGenericControl("figcaption");
        figcaption.Attributes.Add("class", "title dark-background text-glow");
        if (language == "zh")
        {
            figcaption.InnerText = zhText;
        }
        else
        {
            figcaption.InnerText = enText;
        }
        divOverlay.Controls.Add(figcaption);



        HtmlGenericControl divImageSection = new HtmlGenericControl("div");
        divImageSection.Attributes.Add("class", "image-section");
        a.Controls.Add(divImageSection);






        HtmlGenericControl divTextSection = new HtmlGenericControl("div");
        divTextSection.Attributes.Add("class", "text-section");
        figureOverlayParent.Controls.Add(divTextSection);

    }

    protected DataTable FetchMenuData()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select [ID]" +
                " , [zh]" +
                " , [en]" +
                " from ApplicationCategory" +
                " order by OrderOfAppearance";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }
}