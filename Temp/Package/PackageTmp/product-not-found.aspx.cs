using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_not_found : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(RouteData.Values["language"].ToString().Trim() == "zh")
        {
            lblErrorMessage.Text = "產品不存在";
        }
        else
        {
            lblErrorMessage.Text = "Product Not Found";
        }
    }
}