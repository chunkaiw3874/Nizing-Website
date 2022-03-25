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

public partial class news : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
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
            PopulateNewsItem();
        }
    }

    protected void PopulateNewsItem()
    {
        DataTable dt = new DataTable();
        dt = GetNewsItem();
        foreach (DataRow row in dt.Rows)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            newslist.Controls.Add(li);
            HtmlAnchor a = new HtmlAnchor();
            a.Attributes["class"] = "d-flex";
            a.HRef = row["newsLink"].ToString();
            a.Target = "_blank";
            li.Controls.Add(a);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerText = row["newsDate"].ToString();
            a.Controls.Add(div);
            div = new HtmlGenericControl("div");
            div.InnerText = row["newsContent"].ToString();
            a.Controls.Add(div);
        }
    }

    protected DataTable GetNewsItem()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select newsId" +
                " ,cast(year(newsDate) as nvarchar(4))+'/'+cast(month(newsDate) as nvarchar(4))+'/'+cast(day(newsDate) as nvarchar(4)) 'newsDate'" +
                " ,newsContent" +
                " ,newsLink" +
                " from News" +
                " where visible=1" +
                " order by News.newsDate desc" +
                " ,newsId";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }
}