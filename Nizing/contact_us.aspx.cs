using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact_us : System.Web.UI.Page
{
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
        }
    }
}