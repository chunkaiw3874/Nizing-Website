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

public partial class teflon_wire : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["language"] = RouteData.Values["language"] == null ? "zh" : RouteData.Values["language"].ToString();

        if (RouteData.Values["language"] == null)
        {
            Response.Redirect("/zh/product/teflon-wire");
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
                " , pts.Voltage [Voltage]" +
                " ,pts.Temperature [Temperature]" +
                " ,pmc.URL [URL]" +
                " ,pa.attribute [Attribute]" +
                " from Product p" +
                " left join ProductTechnicalSpec pts on p.ID = pts.ID" +
                " left join ProductMultilingualContent pmc on p.ID = pmc.ID and pmc.ContentLanguage = @Language" +
                " left join ProductAttribute pa on p.ID = pa.ID" +
                " where Category = @Category " +
                " and(pa.attribute = 'multiCore'" +
                " or pa.attribute = 'singleCore')" +
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
        DataRow[] singleCoreRows = dt.Select("Attribute='singleCore'");
        DataRow[] multiCoreRows = dt.Select("Attribute='multiCore'");

        HtmlGenericControl divBgWrapper = new HtmlGenericControl("div");
        divBgWrapper.ID = "singleCore";
        divBgWrapper.Attributes.Add("class", "container-fluid bg-wrapper single-core");
        divProductCategory.Controls.Add(divBgWrapper);
        HtmlGenericControl divContent = new HtmlGenericControl("div");
        divContent.Attributes.Add("class", "content container");
        divBgWrapper.Controls.Add(divContent);
        HtmlGenericControl divProductListTitle = new HtmlGenericControl("div");
        divProductListTitle.Attributes.Add("class", "product-list-title");
        divProductListTitle.InnerText = "鐵氟龍單芯線";
        divContent.Controls.Add(divProductListTitle);
        HtmlGenericControl divProductList = new HtmlGenericControl("div");
        divProductList.Attributes.Add("class", "row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list");
        divContent.Controls.Add(divProductList);

        btnSingleCore.Attributes.Add("href", HttpContext.Current.Request.Url.AbsoluteUri + "#" + divBgWrapper.ClientID);


        foreach (DataRow dr in singleCoreRows)
        {
            HtmlGenericControl divCol = new HtmlGenericControl("div");
            divCol.Attributes.Add("class", "col");
            divProductList.Controls.Add(divCol);

            HtmlGenericControl divProductListItem = new HtmlGenericControl("div");
            divProductListItem.Attributes.Add("class", "product-list-item");
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
            divCardSubTitle.InnerText = dr["ID"].ToString().ToUpper();
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

        divBgWrapper = new HtmlGenericControl("div");
        divBgWrapper.ID = "multiCore";
        divBgWrapper.Attributes.Add("class", "container-fluid bg-wrapper multi-core");
        divProductCategory.Controls.Add(divBgWrapper);

        divContent = new HtmlGenericControl("div");
        divContent.Attributes.Add("class", "content container");
        divBgWrapper.Controls.Add(divContent);

        divProductListTitle = new HtmlGenericControl("div");
        divProductListTitle.Attributes.Add("class", "product-list-title");
        divProductListTitle.InnerText = "鐵氟龍多芯線";
        divContent.Controls.Add(divProductListTitle);

        divProductList = new HtmlGenericControl("div");
        divProductList.Attributes.Add("class", "row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list");
        divContent.Controls.Add(divProductList);
        foreach (DataRow dr in multiCoreRows)
        {
            HtmlGenericControl divCol = new HtmlGenericControl("div");
            divCol.Attributes.Add("class", "col");
            divProductList.Controls.Add(divCol);

            HtmlGenericControl divProductListItem = new HtmlGenericControl("div");
            divProductListItem.Attributes.Add("class", "product-list-item");
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
            divCardSubTitle.InnerText = dr["ID"].ToString().ToUpper();
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

        btnMultiCore.Attributes.Add("href", HttpContext.Current.Request.Url.AbsoluteUri+ "#" + divBgWrapper.ClientID);
    }
}