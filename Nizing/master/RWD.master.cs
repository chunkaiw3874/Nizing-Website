using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class master_RWD : System.Web.UI.MasterPage
{
    string websiteConnection = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["language"] = "zh";
            BuildMenu(ViewState["language"] == null ? "zh" : ViewState["language"].ToString());
        }
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
                a.Attributes.Add("href", row.Field<string>("Link"));
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
                    a.Attributes.Add("href", row1.Field<string>("Link"));
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
                a.Attributes["href"] = row.Field<string>("Link");
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


    protected void ChangeLanguage(object sender, EventArgs e)
    {
        string senderId = ((LinkButton)sender).ClientID;
        if (ViewState["language"] == null || senderId == "lnkToMandarin")
        {
            ViewState["language"] = "zh";
        }
        else if (senderId == "lnkToEnglish")
        {
            ViewState["language"] = "en";
        }
        if (ViewState["language"].ToString() == "en")
        {
            Response.Redirect("~\\" + ViewState["language"].ToString() + "\\default.aspx");
        }
        else
        {
            Response.Redirect("~\\default.aspx");
        }
        BuildMenu(ViewState["language"].ToString());
    }
}
