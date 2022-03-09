using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class thermoplastic_elastomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["language"] = RouteData.Values["language"] == null ? "zh" : RouteData.Values["language"].ToString();

        if (RouteData.Values["language"] == null)
        {
            Response.Redirect("/zh/material/thermoplastic-elastomer");
        }
    }
}