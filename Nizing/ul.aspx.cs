using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ul : System.Web.UI.Page
{
    string imgPath = "/images/certificate/ul/img/";
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

        string specServerFilePath = @"\\192.168.10.222\Web\Nizing" + imgPath.Replace('/', '\\');
        string specWebFilePath = imgPath;
        List<string> specImages = GetImageFiles(specServerFilePath);

        if (specImages.Count > 0)
        {
            foreach (string image in specImages)
            {
                HtmlGenericControl divWrapper = new HtmlGenericControl("div");
                divWrapper.Attributes["class"] = "col my-2 px-2";
                certImg.Controls.Add(divWrapper);
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes["class"] = "border h-100";
                divWrapper.Controls.Add(div);
                HtmlAnchor anchorFullProductInfoImage = new HtmlAnchor();
                anchorFullProductInfoImage.HRef = specWebFilePath + image;
                anchorFullProductInfoImage.Target = "_blank";
                div.Controls.Add(anchorFullProductInfoImage);
                HtmlImage imgFullProductInfo = new HtmlImage();
                imgFullProductInfo.Src = specWebFilePath + image;
                anchorFullProductInfoImage.Controls.Add(imgFullProductInfo);
            }
        }
    }

    private List<string> GetImageFiles(string filePath)
    {
        List<string> imgFiles = new List<string>();
        if (Directory.Exists(filePath))
        {
            foreach (string file in Directory.GetFiles(filePath))
            {
                if (Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".svg")
                {
                    imgFiles.Add(Path.GetFileName(file));
                }
            }
        }
        return imgFiles;
    }

}