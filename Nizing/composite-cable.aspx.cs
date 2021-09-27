using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class composite_cable : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["language"] = RouteData.Values["language"] == null ? "zh" : RouteData.Values["language"].ToString();

        if (RouteData.Values["language"] == null)
        {
            Response.Redirect("/zh/product/composite-cable");
        }
        string productCategory = Request.Url.ToString().Split('/').Last();
        string language = RouteData.Values["language"].ToString().ToLower();

        if (!IsPostBack)
        {
            DataTable dt = GetCategoryItem(productCategory, language);

            if (dt.Rows.Count > 0)
            {
                PopulateProductListItem(dt);
            }
        }
    }

    protected DataTable GetCategoryItem(string category, string lang)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select p.ID [ID]" +
                " ,p.HotItem [HotItem]" +
                " ,pmc.Name [Name]" +
                " ,pts.Voltage [Voltage]" +
                " ,pts.Temperature [Temperature]" +
                " ,pmc.URL [URL]" +
                " from Product p" +
                " left join ProductTechnicalSpec pts on p.ID = pts.ID" +
                " left join ProductMultilingualContent pmc on p.ID = pmc.ID and pmc.ContentLanguage = @Language" +
                " where Category = @Category " +
                " order by p.[ID]";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Language", lang);
            cmd.Parameters.AddWithValue("@Category", category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    protected void PopulateProductListItem(DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            HtmlGenericControl divCol = new HtmlGenericControl("div");
            divCol.Attributes.Add("class", "col");
            divProductList.Controls.Add(divCol);

            HtmlGenericControl divProductListItem = new HtmlGenericControl("div");
            divProductListItem.Attributes.Add("class", "product-list-item text-white-shadow-black");
            divCol.Controls.Add(divProductListItem);

            HtmlAnchor a = new HtmlAnchor();
            a.HRef = dr["URL"].ToString().Replace("www.nizing.com.tw", "");
            divProductListItem.Controls.Add(a);

            HtmlGenericControl divCard = new HtmlGenericControl("div");
            divCard.Attributes.Add("class", "card");
            a.Controls.Add(divCard);

            if (dr["HotItem"] == DBNull.Value ? false : (bool)dr["HotItem"])
            {
                HtmlGenericControl divHotItem = new HtmlGenericControl("div");
                divHotItem.Attributes.Add("class", "hot-item");
                divCard.Controls.Add(divHotItem);
                HtmlImage img = new HtmlImage();
                img.Src = "/images/product_pic/hot-icon.png";
                divHotItem.Controls.Add(img);
            }

            HtmlGenericControl divCardBody = new HtmlGenericControl("div");
            divCardBody.Attributes.Add("class", "card-body");
            divCard.Controls.Add(divCardBody);

            HtmlGenericControl divCardTitle = new HtmlGenericControl("div");
            divCardTitle.Attributes.Add("class", "card-title");
            divCardTitle.InnerText = dr["Name"].ToString();
            divCardBody.Controls.Add(divCardTitle);

            HtmlGenericControl divCardSubTitle = new HtmlGenericControl("div");
            divCardSubTitle.Attributes.Add("class", "card-title");
            divCardSubTitle.InnerText = dr["ID"].ToString();
            divCardBody.Controls.Add(divCardSubTitle);

            HtmlGenericControl divCardTextWrapper = new HtmlGenericControl("div");
            divCardTextWrapper.Attributes.Add("class", "card-text-wrapper");
            divCardBody.Controls.Add(divCardTextWrapper);

            HtmlGenericControl divCardText = new HtmlGenericControl("div");
            divCardText.Attributes.Add("class", "card-text");
            divCardTextWrapper.Controls.Add(divCardText);

            if (!string.IsNullOrWhiteSpace(dr["Temperature"].ToString()))
            {
                HtmlGenericControl divFirstAttribute = new HtmlGenericControl("div");
                if (RouteData.Values["language"].ToString().ToLower() == "zh")
                {
                    divFirstAttribute.InnerText = "耐溫: " + dr["Temperature"].ToString();
                }
                else
                {
                    divFirstAttribute.InnerText = "Temp: " + dr["Temperature"].ToString();
                }
                divCardText.Controls.Add(divFirstAttribute);
            }

            if (!string.IsNullOrWhiteSpace(dr["Voltage"].ToString()))
            {
                HtmlGenericControl divSecondAttribute = new HtmlGenericControl("div");
                if (RouteData.Values["language"].ToString().ToLower() == "zh")
                {
                    divSecondAttribute.InnerText = "耐壓: " + dr["Voltage"].ToString();
                }
                else
                {
                    divSecondAttribute.InnerText = "Volt: " + dr["Voltage"].ToString();
                }
                divCardText.Controls.Add(divSecondAttribute);
            }
        }
    }
}