using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class product_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("body");

        HtmlGenericControl span = new HtmlGenericControl("span");
        span.InnerText = "test span";
        productItem.Controls.Add(span);
        
        
    }
}