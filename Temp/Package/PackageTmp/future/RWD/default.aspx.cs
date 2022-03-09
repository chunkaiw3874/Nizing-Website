﻿using System;
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
        DisplayNewsList();
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
        string imgWebFilePath = @"attachment/news/";

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

            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes["class"] = "card mb-3 w-100";
            a.Controls.Add(div1);

            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div2.Attributes["class"] = "row no-gutters";
            div1.Controls.Add(div2);

            HtmlGenericControl div3 = new HtmlGenericControl("div");
            div3.Attributes["class"] = "col-md-4";
            div2.Controls.Add(div3);

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes["class"] = "card-img img-thumbnail mx-auto d-block";
            List<string> imgList = new List<string>();
            imgList = GetImageFiles(imgServerFilePath + row["newsId"].ToString());
            if (imgList.Count > 0)
            {
                img.Attributes["src"] = imgWebFilePath+ row["newsId"].ToString()+@"/"+ imgList[0];
            }
            else
            {
                img.Attributes["src"] = "https://via.placeholder.com/200";
            }
            div3.Controls.Add(img);

            div3 = new HtmlGenericControl("div");
            div3.Attributes["class"] = "col-md-8";
            div2.Controls.Add(div3);

            HtmlGenericControl div4 = new HtmlGenericControl("div");
            div4.Attributes["class"] = "card-body pt-2";
            div3.Controls.Add(div4);

            HtmlGenericControl div5 = new HtmlGenericControl("div");
            div5.ID = a.ID + "_NewsTitle";
            div5.Attributes["class"] = "card-title text-md-left text-center h5";            
            div5.InnerText = row["newsTitle"].ToString();
            div4.Controls.Add(div5);

            div5 = new HtmlGenericControl("div");
            div5.ID = a.ID + "_NewsContent";
            div5.Attributes["class"] = "card-text";
            div5.InnerText = row["newsContent"].ToString();
            div4.Controls.Add(div5);

            div5 = new HtmlGenericControl("div");
            div5.ID = a.ID + "_NewsDate";
            div5.Attributes["class"] = "text-muted text-right";
            div5.InnerText = Convert.ToDateTime(row["newsDate"]).ToString("yyyy/MM/dd");
            div4.Controls.Add(div5);

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
        HtmlGenericControl newsTitle = (HtmlGenericControl) news.FindControl(news.ID + "_NewsTitle");
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
        foreach(string fileName in images)
        {
            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes["class"] = "img img-thumbnail";
            img.Attributes["src"] = imgWebFilePath + news.ID + @"/" + fileName;
            newsModalImageSection.Controls.Add(img);
        }
        ShowModal("newsModal");
    }
}