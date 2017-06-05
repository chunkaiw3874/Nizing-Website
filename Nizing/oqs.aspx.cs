using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.Browser.Type.ToUpper().Contains("INTERNETEXPLORER"))
        {
            TextBox1.Text = "browser isn't IE";
            iframe1.Attributes.Clear();
        }
    }
}