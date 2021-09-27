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

public partial class master_RWDApplicationMaster : System.Web.UI.MasterPage
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        DataTable dt = FetchMenuData();
        foreach (DataRow dr in dt.Rows)
        {
            AddMenuItem(language, dr["ID"].ToString(), dr["zh"].ToString(), dr["en"].ToString());
        }
    }
    protected void AddMenuItem(string language, string id, string zhText, string enText)
    {
        HtmlGenericControl a = new HtmlGenericControl("a");
        a.Attributes.Add("href", "/" + language + "/application/" + id);
        divMenuItemList.Controls.Add(a);
        HtmlImage img = new HtmlImage();
        img.Attributes.Add("class", "mx-auto");
        img.Alt = zhText + " " + enText;
        img.Src = "/images/application/" + id + "/menu/small-menu.svg";
        img.Attributes.Add("onerror", "onerror=null; this.src='/images/placeholder/product-image-placeholder.png'");
        a.Controls.Add(img);
        HtmlGenericControl p = new HtmlGenericControl("p");
        p.Attributes.Add("class", "card-text");
        if (language == "zh")
        {
            p.InnerText = zhText;
        }
        else
        {
            p.InnerText = enText;
        }
        a.Controls.Add(p);
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
