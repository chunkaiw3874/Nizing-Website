using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RouteData.Values["language"] == null || Session["language"] == null)
        {
            Session["language"] = "zh";
            Response.Redirect("/" + Session["language"].ToString());
        }

        //if (Session["language"].ToString() != RouteData.Values["language"].ToString())
        //{
        string language = RouteData.Values["language"].ToString();
        Session["language"] = language;
        //}

        if (!IsPostBack)
        {
            BuildProductMenu(language);
        }

        DisplayNewsList();
    }

    protected void BuildProductMenu(string language)
    {
        DataTable dt = FetchProductMenuData();
        foreach (DataRow dr in dt.Rows)
        {
            AddProductItem(language, dr["ID"].ToString(), dr["zh"].ToString(), dr["en"].ToString());
        }
    }
    protected void AddProductItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col reveal animate__animated");
        divProductItemList.Controls.Add(divCol);
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

    protected DataTable FetchProductMenuData()
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
    private void DisplayNewsList()
    {
        DataTable newListTable = new DataTable();
        newListTable = GetNewsList();

        if (newListTable.Rows.Count > 0)
        {
            BuildNewsListOnFrontEnd(newListTable);
        }
    }

    private DataTable GetNewsList()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select top 3 newsId" +
                " , newsDate" +
                " , newsTitle" +
                " , newsContent" +
                " , newsLink" +
                " from News" +
                " where visible = 1" +
                " order by newsDate desc";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }

    private void BuildNewsListOnFrontEnd(DataTable dt)
    {
        string imgServerFilePath = @"\\192.168.10.222\Web\Nizing\attachment\news\";
        string imgWebFilePath = @"/attachment/news/";

        foreach (DataRow row in dt.Rows)
        {
            HtmlAnchor a = new HtmlAnchor();
            a.ServerClick += new EventHandler(showNews);
            a.ID = row["newsId"].ToString();
            newsContent.Controls.Add(a);

            HtmlGenericControl hiddenField = new HtmlGenericControl("input");
            hiddenField.Attributes["type"] = "hidden";
            hiddenField.ID = a.ID + "_NewsLink";
            hiddenField.Attributes["value"] = row["newsLink"].ToString();
            a.Controls.Add(hiddenField);

            HtmlGenericControl div1 = new HtmlGenericControl("article");
            div1.Attributes["class"] = "card mb-2 pb-md-2 w-100";
            a.Controls.Add(div1);

            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div2.Attributes["class"] = "row no-gutters";
            div1.Controls.Add(div2);

            HtmlGenericControl div3 = new HtmlGenericControl("div");
            div3.Attributes["class"] = "col-md-4";
            div2.Controls.Add(div3);

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes["class"] = "card-img mx-auto d-block";
            List<string> imgList = new List<string>();
            imgList = GetImageFiles(imgServerFilePath + row["newsId"].ToString());
            if (imgList.Count > 0)
            {
                img.Attributes["src"] = imgWebFilePath + row["newsId"].ToString() + @"/" + imgList[0];
            }
            else
            {
                img.Attributes["src"] = "/images/placeholder/product-image-placeholder.png";
            }
            div3.Controls.Add(img);

            div3 = new HtmlGenericControl("div");
            div3.Attributes["class"] = "col-md-8";
            div2.Controls.Add(div3);

            HtmlGenericControl div4 = new HtmlGenericControl("div");
            div4.Attributes["class"] = "card-body pt-2 pb-0 h-100 d-flex flex-column justify-content-between text-shadow";
            div3.Controls.Add(div4);

            HtmlGenericControl div5 = new HtmlGenericControl("div");
            div4.Controls.Add(div5);

            HtmlGenericControl div6 = new HtmlGenericControl("div");
            div6.ID = a.ID + "_NewsTitle";
            div6.Attributes["class"] = "card-title text-md-left text-center h5";
            div6.InnerText = row["newsTitle"].ToString();
            div5.Controls.Add(div6);

            div6 = new HtmlGenericControl("div");
            div6.ID = a.ID + "_NewsContent";
            div6.Attributes["class"] = "card-text";
            div6.InnerText = row["newsContent"].ToString();
            div5.Controls.Add(div6);

            HtmlGenericControl time = new HtmlGenericControl("time");
            time.ID = a.ID + "_NewsDate";
            time.Attributes["class"] = "news-date";
            time.Attributes["datetime"] = row["newsDate"].ToString();
            time.InnerText = Convert.ToDateTime(row["newsDate"]).ToString("yyyy/MM/dd");
            div4.Controls.Add(time);

        }
    }

    private List<string> GetImageFiles(string filePath)
    {
        List<string> imgFiles = new List<string>();
        if (Directory.Exists(filePath))
        {
            foreach (string file in Directory.GetFiles(filePath))
            {
                if (Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".png")
                {
                    imgFiles.Add(Path.GetFileName(file));
                }
            }
        }

        return imgFiles;
    }

    private void ShowModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('show');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

    protected void showNews(object sender, EventArgs e)
    {
        string imgServerFilePath = @"\\192.168.10.222\Web\Nizing\attachment\news\";
        string imgWebFilePath = @"attachment/news/";
        List<string> images = new List<string>();

        HtmlAnchor news = (HtmlAnchor)sender;
        HtmlGenericControl newsTitle = (HtmlGenericControl)news.FindControl(news.ID + "_NewsTitle");
        HtmlGenericControl newsContent = (HtmlGenericControl)news.FindControl(news.ID + "_NewsContent");
        HtmlGenericControl newsDate = (HtmlGenericControl)news.FindControl(news.ID + "_NewsDate");
        HtmlGenericControl newsLink = (HtmlGenericControl)news.FindControl(news.ID + "_NewsLink");

        newsModalTitle.Text = newsTitle.InnerText;
        newsModalContent.Text = newsContent.InnerText;
        if (!string.IsNullOrWhiteSpace(newsLink.Attributes["value"].ToString()))
        {
            newsModalLink.HRef = newsLink.Attributes["value"].ToString();
            newsModalLink.InnerText = "...更多";
        }
        newsModalDate.Text = newsDate.InnerText;

        images = GetImageFiles(imgServerFilePath + news.ID);
        foreach (string fileName in images)
        {
            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes["src"] = imgWebFilePath + news.ID + @"/" + fileName;
            newsModalImageSection.Controls.Add(img);
        }
        ShowModal("newsModal");
    }
}