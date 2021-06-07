using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ul1007 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Header.Title = "test title";
        //MetaKeywords = "test keywords";        
        ClientScriptManager cs = ClientScript;
        string csName = "LinkedStructure";
        Type csType = this.GetType();

        if (!cs.IsClientScriptBlockRegistered(csType, csName))
        {
            //StringBuilder csText = new StringBuilder();
            //csText.Append("<script type=\"application/ld+json\">{");
            //csText.Append("\"@context\": \"https://schema.org\",");
            //csText.Append("\"@type\": \"QAPage\"");
            //csText.Append("}</script>");
            //cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
        }
    }
}