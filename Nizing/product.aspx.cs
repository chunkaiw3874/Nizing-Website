using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cs = ClientScript;
        string csName = "LinkedStructure";
        Type csType = this.GetType();

        if (!cs.IsClientScriptBlockRegistered(csType, csName))
        {
            StringBuilder csText = new StringBuilder();
            csText.Append("<script type=\"application/ld+json\">{\n");
            csText.Append("\"@context\": \"https://schema.org/\",\n");
            csText.Append("\"@type\": \"Product\",\n");
            csText.Append("\"brand\":{\n");
                csText.Append("\"@type\":\"Brand\",\n");
                csText.Append("\"name\":\"Nizing\",\n");
                csText.Append("}\n");
            csText.Append("\"logo\":\"http://www.nizing.com.tw/images/logo/nizing.png\",\n");
            csText.Append("\"name\":\"Wire and Cable\",\n");
            csText.Append("\"description\":\"Wire and cable of high voltage, high chemical resistance, and great performance for industrial machines\",\n");
            csText.Append("\"url\":\"https://www.nizing.com.tw/product.aspx\",\n");
            csText.Append("\"offers\":{\n");
                csText.Append("\"@type\":\"Offer\",\n");
                csText.Append("\"url\":\"https://www.nizing.com.tw/product.aspx\",\n");
                csText.Append("\"priceCurrency\":\"USD\",\n");
                csText.Append("\"price\":\"0.01\",\n");
                csText.Append("\"itemCondition\":\"https://schema.org/NewCondition\",\n");
                csText.Append("\"availability\":\"https://schema.org/InStock\"\n");
                csText.Append("}\n");
            csText.Append("}</script>");
            cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
        }
    }
}