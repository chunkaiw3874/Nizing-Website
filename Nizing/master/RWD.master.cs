using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class master_RWD : System.Web.UI.MasterPage
{
    string websiteConnection = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //if(Request.Url.AbsoluteUri == "http://www.nizing.com.tw/zh"
        //    | Request.Url.AbsoluteUri == "http://www.nizing.com.tw/"
        //    | Request.Url.AbsoluteUri == "http://localhost:50429/zh")
        //{
        //    Session["language"] = "zh";
        //}
        //else if (Request.Url.AbsoluteUri == "http://www.nizing.com.tw/en"
        //| Request.Url.AbsoluteUri == "http://localhost:50429/en")
        //{
        //    Session["language"] = "en";
        //}

        //if (Session["language"] == null)
        //{
        //    Session["language"] = "zh";
        //}            
        logoAnchor.HRef = "\\" + Session["language"].ToString();
        BuildMenu(Session["language"].ToString());
        BuildFooterMenu(Session["language"].ToString());
        //}
    }

    private void BuildMenu(string language)
    {
        DataTable dtMenu = new DataTable();

        dtMenu = GetMenuInformation();
        DataSet dsMenu = new DataSet();

        //Tier 0 menu
        dsMenu.Tables.Add(dtMenu.AsEnumerable()
                          .Where(t => t.Field<string>("Parent") == "root")
                          .OrderBy(p => p.Field<int>("Position"))
                          .CopyToDataTable());
        //dsMenu.Tables[0].TableName = 0.ToString();
        int i = 1;
        foreach (DataRow row in dsMenu.Tables[0].Rows)
        {
            bool hasChildNode = hasChild(dtMenu, row.Field<string>("ID"));
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "nav-item dropdown");
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("class", "nav-link");
            if (language == "en")
            {
                a.InnerText = row.Field<string>("AltName");
            }
            else
            {
                a.InnerText = row.Field<string>("Name");
            }
            li.Controls.Add(a);
            divNavContentList.Controls.Add(li);


            //if (hasChildNode) //2021.06.29 Chrissy said no submenu
            if (0 == 1)
            {
                a.Attributes.Add("class", "nav-link has-child");
                a.Attributes.Add("role", "button");
                //a.Attributes.Add("data-toggle", "dropdown");
                //a.Attributes.Remove("href");
                a.Attributes.Add("href", "/" + Session["language"].ToString() + row.Field<string>("Link").Replace(".aspx", ""));
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                ul.Attributes.Add("class", "dropdown-menu");
                li.Controls.Add(ul);

                //Tier 1 menu
                dsMenu.Tables.Add(dtMenu.AsEnumerable()
                          .Where(t => t.Field<string>("Parent") == row["ID"].ToString())
                          .OrderBy(p => p.Field<int>("Position"))
                          .CopyToDataTable());
                //dsMenu.Tables[i].TableName = i.ToString();
                foreach (DataRow row1 in dsMenu.Tables[i].Rows)
                {
                    li = new HtmlGenericControl("li");
                    ul.Controls.Add(li);
                    a = new HtmlGenericControl("a");
                    a.Attributes.Add("class", "dropdown-item");
                    a.Attributes.Add("href", "/" + Session["language"].ToString() + row1.Field<string>("Link").Replace(".aspx", ""));
                    if (language == "en")
                    {
                        a.InnerText = row1.Field<string>("AltName");
                    }
                    else
                    {
                        a.InnerText = row1.Field<string>("Name");
                    }
                    li.Controls.Add(a);
                }
                i++;
            }
            else
            {
                a.Attributes["href"] = "/" + Session["language"].ToString() + row.Field<string>("Link").Replace(".aspx", "");
            }
        }
    }

    private DataTable GetMenuInformation()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(websiteConnection))
        {
            conn.Open();
            string query = "select ID" +
                " ,Name" +
                " ,AltName" +
                " ,Parent" +
                " ,Tier" +
                " ,Position" +
                " ,Link" +
                " from Menu" +
                " where Target=@target" +
                " order by Tier" +
                " ,Position" +
                " ,AltName";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@target", "website");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    private bool hasChild(DataTable srcTable, string parentNode)
    {
        return srcTable.AsEnumerable().Any(r => r.Field<string>("Parent") == parentNode);
    }

    protected void BuildFooterMenu(string language)
    {
        HtmlGenericControl ulListGroup = AddFooterMenuItem(language, "關於日進", "Nizing");
        AddFooterMenuSubItem(ulListGroup, language, "企業核心價值與經營理念", "Culture", "/" + language + "/company/culture");
        AddFooterMenuSubItem(ulListGroup, language, "經營團隊", "Team", "/" + language + "#");
        AddFooterMenuSubItem(ulListGroup, language, "企業社會責任: SA8000", "SA8000", "/" + language + "#");
        AddFooterMenuSubItem(ulListGroup, language, "品質政策", "Quality Policy", "/" + language + "#");
        AddFooterMenuSubItem(ulListGroup, language, "無衝突金屬聲明", "Non-Conflict Metal Declaration", "/" + language + "/declaration/conflict-free-mineral-declaration");
        AddFooterMenuSubItem(ulListGroup, language, "合作廠商", "Associates", "/" + language + "/associates");
        ulListGroup = AddFooterMenuItem(language, "產品中心", "Product Center");
        AddFooterMenuSubItem(ulListGroup, language, "產品總覽", "Product Category", "/" + language + "/product");
        AddFooterMenuSubItem(ulListGroup, language, "應用產業", "Application Category", "/" + language + "/application");
        ulListGroup = AddFooterMenuItem(language, "相關連結", "Link");
        AddFooterMenuSubItem(ulListGroup, language, "銅價", "Copper Price", "https://finance.sina.com.cn/futures/quotes/CAD.shtml", "_blank");
        AddFooterMenuSubItem(ulListGroup, language, "UL", "UL", "https://taiwan.ul.com/", "_blank");
        AddFooterMenuSubItem(ulListGroup, language, "VDE", "VDE", "https://www.vde.com/en", "_blank");
        AddFooterMenuSubItem(ulListGroup, language, "網站導覽", "Sitemap", "/" + language + "/sitemap");
        ulListGroup = AddFooterMenuItem(language, "聯繫我們", "Contact Us");
        AddFooterMenuSubItem(ulListGroup, language, "人才招募", "Recruit", "https://www.104.com.tw/company/12vkr1cg", "_blank");
        AddFooterMenuSubItem(ulListGroup, language, "地址: 新北市三重區光復路二段87巷10-12號", "ADD: No.10-12, Ln.87, Sec.2, Guanfu Road, Sanchong Dist., New Taipei City, Taiwan 24158", "https://www.google.com/maps/place/%E6%97%A5%E9%80%B2%E9%9B%BB%E7%B7%9A%E8%82%A1%E4%BB%BD%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8/@25.0587124,121.4718232,17z/data=!4m12!1m6!3m5!1s0x3442a7e768a1d123:0x1b3b1220987a8188!2z5pel6YCy6Zu757ea6IKh5Lu95pyJ6ZmQ5YWs5Y-4!8m2!3d25.0587076!4d121.4740119!3m4!1s0x3442a7e768a1d123:0x1b3b1220987a8188!8m2!3d25.0587076!4d121.4740119", "_blank");
        AddFooterMenuSubItem(ulListGroup, language, "電話: +886-2-2999-9181", "TEL: +886-2-2999-9181", "tel:+886229999181");
        AddFooterMenuSubItem(ulListGroup, language, "傳真: +886-2-2999-9771", "FAX: +886-2-2999-9771", "/" + language + "#");
        HtmlGenericControl liListGroupItem = new HtmlGenericControl("li");
        liListGroupItem.Attributes.Add("class", "list-group-item");
        ulListGroup.Controls.Add(liListGroupItem);
        HtmlAnchor aCardLink = new HtmlAnchor();
        aCardLink.Attributes.Add("class", "card-link img");
        aCardLink.HRef = "https://www.facebook.com/NIZING.ELECTRIC/";
        aCardLink.Target = "_blank";
        aCardLink.InnerHtml = "<i class=\"fab fa-facebook - square\"></i>";
        liListGroupItem.Controls.Add(aCardLink);
    }

    protected HtmlGenericControl AddFooterMenuItem(string language, string zhText, string enText)
    {
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col col-px-0");
        divFooterMenuList.Controls.Add(divCol);
        HtmlGenericControl divCard = new HtmlGenericControl("div");
        divCard.Attributes.Add("class", "card");
        divCol.Controls.Add(divCard);
        HtmlGenericControl divTitleWrapper = new HtmlGenericControl("div");
        divTitleWrapper.Attributes.Add("class", "title-wrapper");
        divCard.Controls.Add(divTitleWrapper);
        HtmlGenericControl divCardTitle = new HtmlGenericControl("div");
        divCardTitle.Attributes.Add("class", "h2 card-title");
        if (language == "zh")
        {
            divCardTitle.InnerText = zhText;
        }
        else
        {
            divCardTitle.InnerText = enText;
        }
        divTitleWrapper.Controls.Add(divCardTitle);
        HtmlGenericControl navCardBody = new HtmlGenericControl("nav");
        navCardBody.Attributes.Add("class", "card-body");
        divCard.Controls.Add(navCardBody);
        HtmlGenericControl ulListGroup = new HtmlGenericControl("ul");
        ulListGroup.Attributes.Add("class", "list-group list-group-flush");
        navCardBody.Controls.Add(ulListGroup);

        return ulListGroup;
    }

    protected void AddFooterMenuSubItem(HtmlGenericControl ul, string language, string zhText, string enText, string url, string urlTarget = "")
    {
        HtmlGenericControl liListGroupItem = new HtmlGenericControl("li");
        liListGroupItem.Attributes.Add("class", "list-group-item");
        ul.Controls.Add(liListGroupItem);
        HtmlAnchor aCardLink = new HtmlAnchor();
        aCardLink.Attributes.Add("class", "card-link");
        aCardLink.HRef = url;
        aCardLink.Target = urlTarget;
        if (language == "zh")
        {
            aCardLink.InnerHtml = zhText;
        }
        else
        {
            aCardLink.InnerHtml = enText;
        }
        liListGroupItem.Controls.Add(aCardLink);
    }

    protected void ChangeLanguage(object sender, EventArgs e)
    {
        string newLanguage = ((LinkButton)sender).ClientID;
        Session["language"] = newLanguage;
        string url = Request.Url.AbsolutePath;
        string[] urlSections = url.Split('/');
        string newUrl = "";

        for (int i = 1; i < urlSections.Length; i++)
        {
            if (i == 1)
            {
                newUrl += "/" + newLanguage;
            }
            else
            {
                newUrl += "/" + urlSections[i];
            }
        }

        Response.Redirect("~" + newUrl);

        BuildMenu(newLanguage);
    }
}
