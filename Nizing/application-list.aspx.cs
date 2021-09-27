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


public partial class application_list : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["language"] = RouteData.Values["language"] == null ? "zh" : RouteData.Values["language"].ToString();
        string language = Session["language"].ToString();

        string application = RouteData.Values["application"].ToString();

        if (!IsPostBack)
        {
            BuildMenu(language, application);
        }
    }

    protected void BuildMenu(string language, string application)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select pa.ProductID [PID]" +
                " ,pmc.[Name]" +
                " ,pmc.[Description]" +
                " from ProductApplication pa" +
                " left join ProductMultilingualContent pmc on pa.ProductID = pmc.ID" +
                " where pmc.ContentLanguage = @language" +
                " and pa.ApplicationID = @AID" +
                " order by pa.ProductID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@language", language);
            cmd.Parameters.AddWithValue("@AID", application);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        foreach (DataRow dr in dt.Rows)
        {
            BuildMenuItem(application, dr["PID"].ToString(), dr["Description"].ToString(), dr["Name"].ToString(), "~/" + language + "/application/" + application + "/");
        }
    }

    protected void BuildMenuItem(string application, string PID, string title, string subtitle, string url)
    {
        HtmlGenericControl divCol = new HtmlGenericControl("div");
        divCol.Attributes.Add("class", "col");
        divApplicationItemList.Controls.Add(divCol);
        HtmlGenericControl divItem = new HtmlGenericControl("div");
        divItem.Attributes.Add("class", "item");
        divCol.Controls.Add(divItem);
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = url + PID.ToLower();
        divItem.Controls.Add(a);
        HtmlGenericControl divImageSection = new HtmlGenericControl("div");
        divImageSection.Attributes.Add("class", "image-section");
        a.Controls.Add(divImageSection);
        HtmlGenericControl picture = new HtmlGenericControl("picture");
        divImageSection.Controls.Add(picture);
        HtmlSource src = new HtmlSource();
        src.Attributes.Add("srcset", "/images/application/" + application + "/" + PID + "/menu/" + PID + ".webp");
        src.Attributes.Add("type", "image/webp");
        picture.Controls.Add(src);
        HtmlImage img = new HtmlImage();
        img.Src = "/images/application/" + application + "/" + PID + "/menu/" + PID + ".jpg";
        img.Alt = title;
        picture.Controls.Add(img);
        HtmlGenericControl divTextSection = new HtmlGenericControl("div");
        divTextSection.Attributes.Add("class", "text-section");
        divItem.Controls.Add(divTextSection);
        HtmlGenericControl divTitle = new HtmlGenericControl("div");
        divTitle.Attributes.Add("class", "title text-left");
        divTitle.InnerText = title;
        divTextSection.Controls.Add(divTitle);
        HtmlGenericControl divSubtitle = new HtmlGenericControl("div");
        divSubtitle.Attributes.Add("class", "subtitle text-left");
        divSubtitle.InnerText = subtitle;
        divTextSection.Controls.Add(divSubtitle);
    }
    //<div class="col">
    //   <div class="newest-item">
    //     <a href = "" >
    //       < div class="image-section">
    //         <picture>
    //           <source srcset = "/images/product/new-item/fighter-jet-temperature-control-cable.webp" type="image/webp">
    //           <img src = "/images/product/new-item/fighter-jet-temperature-control-cable.jpg"
    //           alt="戰鬥機溫控線 Fighter Jet Temperature Control Cable">
    //         </picture>
    //       </div>
    //     </a>
    //     <div class="text-section">
    //       <div class="title text-left">戰鬥機溫控線</div>
    //       <div class="subtitle text-left">日本軍規配線</div>
    //     </div>
    //   </div>
    // </div>
}