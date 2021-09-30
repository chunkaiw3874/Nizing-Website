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

public partial class product : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClientScriptManager cs = ClientScript;
            string csName = "LinkedStructure";
            Type csType = this.GetType();
            if (!cs.IsClientScriptBlockRegistered(csType, csName))
            {
                StringBuilder csText = new StringBuilder();
                csText.Append("<script type=\"application/ld+json\">{\n");
                csText.Append("\"@context\": \"https://schema.org/\",\n");
                csText.Append("\"@type\": \"Product\",\n");
                csText.Append("\"brand\":{\n");
                csText.Append("\"@type\":\"Brand\",\n");
                csText.Append("\"name\":\"Nizing\"\n");
                csText.Append("},\n");
                csText.Append("\"logo\":\"http://www.nizing.com.tw/images/logo/nizing.png\",\n");
                csText.Append("\"name\":\"Wire and Cable\",\n");
                csText.Append("\"description\":\"Wire and cable of high voltage, high chemical resistance, and great performance for industrial machines\",\n");
                csText.Append("\"url\":\"http://www.nizing.com.tw/zh/product\",\n");
                csText.Append("\"offers\":{\n");
                csText.Append("\"@type\":\"Offer\",\n");
                csText.Append("\"url\":\"https://www.nizing.com.tw/zh/product\",\n");
                csText.Append("\"priceCurrency\":\"USD\",\n");
                csText.Append("\"price\":\"0.01\",\n");
                csText.Append("\"itemCondition\":\"https://schema.org/NewCondition\",\n");
                csText.Append("\"availability\":\"https://schema.org/InStock\"\n");
                csText.Append("}\n");
                csText.Append("}</script>");
                cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
            }

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
        DataTable dt = FetchMenuData();
        foreach (DataRow dr in dt.Rows)
        {
            AddItem(language, dr["ID"].ToString(), dr["zh"].ToString(), dr["en"].ToString());
        }
    }
    protected void AddItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col");
        divItemList.Controls.Add(divCol);
        HtmlGenericControl figureProductCategoryItem = new HtmlGenericControl("figure");
        figureProductCategoryItem.Attributes.Add("class", "product-category-item move");
        divCol.Controls.Add(figureProductCategoryItem);
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = "/" + language + "/product/" + id;
        figureProductCategoryItem.Controls.Add(a);
        HtmlGenericControl divImageSection = new HtmlGenericControl("div");
        divImageSection.Attributes.Add("class", "image-section");
        a.Controls.Add(divImageSection);
        HtmlGenericControl picture = new HtmlGenericControl("picture");
        divImageSection.Controls.Add(picture);
        HtmlSource pictureSource = new HtmlSource();
        pictureSource.Attributes.Add("srcset", "/images/product/" + id + "/menu/big-menu.webp");
        pictureSource.Attributes.Add("type", "image/webp");
        picture.Controls.Add(pictureSource);
        HtmlImage img = new HtmlImage();
        img.Src = "/images/product/" + id + "/menu/big-menu.png";
        img.Alt = zhText + " " + enText;
        img.Attributes.Add("onerror", "onerror=null; this.src='/images/placeholder/product-image-placeholder.png'");
        picture.Controls.Add(img);
        HtmlGenericControl divTextSection = new HtmlGenericControl("div");
        divTextSection.Attributes.Add("class", "text-section");
        figureProductCategoryItem.Controls.Add(divTextSection);
        HtmlGenericControl figcaption = new HtmlGenericControl("figcaption");
        figcaption.Attributes.Add("class", "title");
        figcaption.InnerText = zhText;
        divTextSection.Controls.Add(figcaption);
        figcaption = new HtmlGenericControl("figcaption");
        figcaption.Attributes.Add("class", "subtitle");
        figcaption.InnerText = enText;
        divTextSection.Controls.Add(figcaption);
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
                " from ProductCategory" +
                " where [ID] <> 'other'" +
                " order by OrderOfAppearance";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }
}