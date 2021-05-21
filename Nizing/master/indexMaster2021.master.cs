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

public partial class master_indexMaster2021 : System.Web.UI.MasterPage
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

        //tier 0 menu
        dsMenu.Tables.Add(dtMenu.AsEnumerable()
                          .Where(t => t.Field<string>("parent") == "root")
                          .OrderBy(p => p.Field<int>("position"))
                          .CopyToDataTable());
        //dsMenu.Tables[0].TableName = 0.ToString();
        int i = 1;
        foreach (DataRow row in dsMenu.Tables[0].Rows)
        {
            bool hasChildNode = hasChild(dtMenu, row.Field<string>("id"));
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "nav-item dropdown mr-3");
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("class", "nav-link text-white");
            if (language == "en")
            {
                a.InnerText = row.Field<string>("altName");
            }
            else
            {
                a.InnerText = row.Field<string>("name");
            }
            li.Controls.Add(a);
            divNavContentList.Controls.Add(li);
            if (hasChildNode)
            {
                a.Attributes.Add("class", "nav-link dropdown-toggle text-white");
                a.Attributes.Add("role", "button");
                a.Attributes.Add("data-toggle", "dropdown");
                a.Attributes.Remove("href");
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                ul.Attributes.Add("class", "dropdown-menu");
                li.Controls.Add(ul);

                //tier 1 menu
                dsMenu.Tables.Add(dtMenu.AsEnumerable()
                          .Where(t => t.Field<string>("parent") == row["id"].ToString())
                          .OrderBy(p => p.Field<int>("position"))
                          .CopyToDataTable());
                //dsMenu.Tables[i].TableName = i.ToString();
                foreach (DataRow row1 in dsMenu.Tables[i].Rows)
                {
                    li = new HtmlGenericControl("li");
                    ul.Controls.Add(li);
                    a = new HtmlGenericControl("a");
                    a.Attributes.Add("class", "dropdown-item");
                    a.Attributes.Add("href", row1.Field<string>("link"));
                    if (language == "en")
                    {
                        a.InnerText = row1.Field<string>("altName");
                    }
                    else
                    {
                        a.InnerText = row1.Field<string>("name");
                    }
                    li.Controls.Add(a);
                }
                i++;
            }
            else
            {
                a.Attributes["href"] = row.Field<string>("link");
            }
        }
    }
    private DataTable GetMenuInformation()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(websiteConnection))
        {
            conn.Open();
            string query = "select id" +
                " ,name" +
                " ,altName" +
                " ,parent" +
                " ,tier" +
                " ,position" +
                " ,link" +
                " from Menu" +
                " where target=@target" +
                " order by tier" +
                " ,position" +
                " ,altName";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("target", "website");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }

    private bool hasChild(DataTable srcTable, string parentNode)
    {
        return srcTable.AsEnumerable().Any(r => r.Field<string>("parent") == parentNode);
    }

    protected void ChangeLanguage(object sender, EventArgs e)
    {
        string senderId = ((LinkButton)sender).ClientID;
        if (senderId == "lnkToMandarin")
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
