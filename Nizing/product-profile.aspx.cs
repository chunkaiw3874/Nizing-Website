using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class product_profile : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;
    public class Product
    {
        public Product()
        {

        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string CategoryID { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }

        public ProductStructuredDataSchema StructuredDataSchema = new ProductStructuredDataSchema();

        public List<string> GetColorList(DataTable dt)
        {
            List<string> colorList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                colorList.Add(dr["Attributes"].ToString().ToLower());
            }
            return colorList;
        }

        public List<Tuple<string, string>> GetTechnicalSpecList(DataTable dt)
        {
            List<Tuple<string, string>> techSpec = new List<Tuple<string, string>>();

            foreach (DataRow dr in dt.Rows)
            {
                techSpec.Add(new Tuple<string, string>(dr["AttributeName"].ToString(), dr["AttributeValue"].ToString()));
            }
            return techSpec;
        }

        public List<string> GetCertificateList(DataTable dt)
        {
            List<string> certificateList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                certificateList.Add(dr["Attributes"].ToString().ToLower());
            }
            return certificateList;
        }
        public class ProductStructuredDataSchema
        {
            public ProductStructuredDataSchema()
            {

            }
            public string Context { get { return "https://schema.org"; } }
            public string Type { get; set; }
            public string Brand_Type { get { return "Brand"; } }
            public string Brand_Name { get; set; }
            public string Logo { get; set; }
            public string ProductID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Material { get; set; }
            public string SKU { get; set; }
            public string URL { get; set; }
            public string Offers_Type { get { return "Offer"; } }
            public string Offers_URL { get; set; }
            public string Offers_PriceCurrency { get; set; }
            public decimal Offers_Price { get; set; }
            public string Offers_ItemCondition { get; set; }
            public string Offers_Availability { get; set; }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.RouteData.DataTokens["language"] != null && Page.RouteData.DataTokens["productID"] != null)
        {
            //string PID = Request.Url.AbsoluteUri.Split('/').Last().Split('.').First().ToUpper();

            string PID = Page.RouteData.DataTokens["productID"].ToString().ToUpper();
            string language = Page.RouteData.DataTokens["language"].ToString().ToLower();

            //#region DUMB PID REWRITE!!
            ////DUMB WAY TO TRANSFORM URL INTO THE ONE I NEED!!!
            //if (PID == "RSGE")
            //{
            //    PID = "RS-GE";
            //}
            //if (PID == "ULSRG")
            //{
            //    PID = "ULSSG";
            //}
            //if (PID == "PFA-FEP-TUBE")
            //{
            //    PID = "FEP-TUBE";
            //}
            //if (PID == "RS-TYPE")
            //{
            //    PID = "R-S-TYPE";
            //}
            //if (PID == "respiration-pipe-heating-wire".ToUpper())
            //{
            //    PID = "MEDICAL-RESPIRATION-PIPE-HEATING-WIRE";
            //}
            //if (PID == "rg178bu-rg179-rg316".ToUpper())
            //{
            //    PID = "RG179";
            //}


            //#endregion

            DataTable dt = FetchProductData(PID, language);
            Response.Redirect("/" + language + "/product/" + dt.Rows[0]["ProductCategoryID"].ToString() + "/" + PID);
        }
        else
        {
            try
            {
                Product product = GetProduct(RouteData.Values["productID"].ToString().Trim(), RouteData.Values["language"].ToString().ToLower().Trim());
                string language = RouteData.Values["language"].ToString().ToLower().Trim();
                Session["language"] = language;

                if (language == "zh")
                {
                    Page.Title = product.Name + " " + product.ID + " - " + "日進電線 " + DateTime.Today.Year.ToString();
                }
                else
                {
                    Page.Title = product.Name + " " + product.ID + " - " + "Nizing Electric Wire and Cable " + DateTime.Today.Year.ToString();
                }
                HtmlMeta metaDesc = new HtmlMeta();
                metaDesc.Name = "description";
                metaDesc.Content = product.Description;
                if (language == "zh")
                {
                    metaDesc.Content += " 購買 " + product.ID + " " + product.Name + " 請盡速與我們聯絡";
                }
                else
                {
                    metaDesc.Content += " Contact us now for your " + product.ID + " " + product.Name;
                }
                MetaTagPlaceholder.Controls.Add(metaDesc);

                //Open Graph Meta Tag
                //Twitter Card Meta Tag
                HtmlMeta OP = new HtmlMeta();
                HtmlMeta TC = new HtmlMeta();
                OP.Attributes.Add("property", "og:type");
                OP.Content = "product";
                MetaTagPlaceholder.Controls.Add(OP);
                OP = new HtmlMeta();
                TC = new HtmlMeta();
                OP.Attributes.Add("property", "og:title");
                TC.Name = "twitter:title";
                if (language == "zh")
                {
                    OP.Content = product.Name + " " + product.ID + " - " + "日進電線 " + DateTime.Today.Year.ToString();
                }
                else
                {
                    OP.Content = product.Name + " " + product.ID + " - " + "Nizing Electric Wire and Cable " + DateTime.Today.Year.ToString();
                }
                TC.Content = OP.Content;
                MetaTagPlaceholder.Controls.Add(OP);
                MetaTagPlaceholder.Controls.Add(TC);
                OP = new HtmlMeta();
                TC = new HtmlMeta();
                OP.Attributes.Add("property", "og:description");
                TC.Name = "twitter:description";
                OP.Content = product.Description;
                TC.Content = OP.Content;
                MetaTagPlaceholder.Controls.Add(OP);
                MetaTagPlaceholder.Controls.Add(TC);
                OP = new HtmlMeta();
                TC = new HtmlMeta();
                OP.Attributes.Add("property", "og:image");
                TC.Name = "twitter:image";
                OP.Content = "http://www.nizing.com.tw" + product.ImageLocation + "display/" + product.ID + "-1.jpg";
                TC.Content = OP.Content;
                MetaTagPlaceholder.Controls.Add(OP);
                MetaTagPlaceholder.Controls.Add(TC);
                OP = new HtmlMeta();
                OP.Attributes.Add("property", "og:url");
                OP.Content = "http://www.nizing.com.tw/" + language + "/product/" + product.Category + "/" + product.ID;
                MetaTagPlaceholder.Controls.Add(OP);
                OP = new HtmlMeta();
                OP.Attributes.Add("property", "og:site_name");
                if (language == "zh")
                {
                    OP.Content = "日進電線";
                }
                else
                {
                    OP.Content = "Nizing Electric Wire and Cable";
                }
                MetaTagPlaceholder.Controls.Add(OP);
                HtmlLink lnk = new HtmlLink();
                lnk.Attributes.Add("rel", "canonical");
                lnk.Href = "http://www.nizing.com.tw/" + language + "/product/" + product.CategoryID + "/" + product.ID;
                MetaTagPlaceholder.Controls.Add(lnk);
                BuildPage(product, language);
            }
            catch
            {
                Response.Redirect(@"/" + RouteData.Values["language"].ToString().ToLower().Trim() + @"/product/" + @"/product-not-found?productID=" + RouteData.Values["productID"].ToString().ToUpper());
            }
        }

    }

    private Product GetProduct(string productID, string language)
    {
        Product p = new Product();

        DataTable dt = new DataTable();
        dt = FetchProductData(productID, language);

        //Stuff Fetched data into Product
        if (dt.Rows.Count > 0)
        {
            p.ID = productID;
            p.Name = dt.Rows[0]["ProductName"].ToString().Trim();
            p.Category = dt.Rows[0]["ProductCategory"].ToString().Trim();
            p.CategoryID = dt.Rows[0]["ProductCategoryID"].ToString().Trim();
            p.Description = dt.Rows[0]["ProductDescription"].ToString().Trim();
            p.ImageLocation = dt.Rows[0]["ImageLocation"].ToString().Trim();
            p.StructuredDataSchema.Type = dt.Rows[0]["LDType"].ToString().Trim();
            p.StructuredDataSchema.Brand_Name = dt.Rows[0]["LDBrandName"].ToString().Trim();
            p.StructuredDataSchema.Logo = dt.Rows[0]["LDLogo"].ToString().Trim();
            p.StructuredDataSchema.ProductID = productID;
            p.StructuredDataSchema.Name = dt.Rows[0]["ProductName"].ToString().Trim();
            p.StructuredDataSchema.Description = dt.Rows[0]["ProductDescription"].ToString().Trim();
            p.StructuredDataSchema.Material = dt.Rows[0]["LDMaterial"].ToString().Trim();
            p.StructuredDataSchema.SKU = dt.Rows[0]["LDSKU"].ToString().Trim();
            p.StructuredDataSchema.URL = dt.Rows[0]["URL"].ToString().Trim();
            p.StructuredDataSchema.Offers_URL = dt.Rows[0]["URL"].ToString().Trim();
            p.StructuredDataSchema.Offers_PriceCurrency = dt.Rows[0]["LDCurrency"].ToString().Trim();
            p.StructuredDataSchema.Offers_Price = Convert.ToDecimal(dt.Rows[0]["LDPrice"].ToString().Trim());
            p.StructuredDataSchema.Offers_ItemCondition = dt.Rows[0]["LDCondition"].ToString().Trim();
            p.StructuredDataSchema.Offers_Availability = dt.Rows[0]["LDAvailability"].ToString().Trim();
        }

        return p;
    }

    private DataTable FetchProductData(string productID, string language)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select p.ID 'ProductID'" +
                " ,p.Category 'ProductCategoryID'" +
                " ,p.ImageLocation 'ImageLocation'" +
                " ,pmc.Name 'ProductName'" +
                " ,case" +
                " when pmc.ContentLanguage = 'zh' then pCategory.zh" +
                " when pmc.ContentLanguage = 'en' then pCategory.en" +
                " end 'ProductCategory'" +
                " ,pmc.[Description] 'ProductDescription'" +
                " ,psds.Context 'LDContext'" +
                " ,psds.[Type] 'LDType'" +
                " ,psds.BrandName 'LDBrandName'" +
                " ,psds.Logo 'LDLogo'" +
                " ,psds.SKU 'LDSKU'" +
                " ,pmc.URL 'URL'" +
                " ,psds.OfferPriceCurrency 'LDCurrency'" +
                " ,psds.OfferPrice 'LDPrice'" +
                " ,psds.OfferCondition 'LDCondition'" +
                " ,psds.OfferAvailability 'LDAvailability'" +
                " from Product p" +
                " left join ProductMultilingualContent pmc on p.ID = pmc.ID" +
                " left join ProductStructuredDataSchema psds on p.ID = psds.ID" +
                " left join ProductCategory pCategory on p.Category=pCategory.ID" +
                " left join ProductMaterial pMat on p.ID=pMat.ID" +
                " where pmc.ContentLanguage = @language" +
                " and p.ID=@productID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@language", language);
            cmd.Parameters.AddWithValue("@productID", productID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            query = "declare" +
                " @productID nvarchar(255)= N'" + productID + "'," +
                " @language nvarchar(10)= '" + language + "';" +
                " declare" +
                " @sql NVARCHAR(MAX) = N''," +
                " @cols NVARCHAR(MAX) = N'';" +
                " select @cols += ', ' + QUOTENAME(name)" +
                " from sys.columns" +
                " where [object_id] = OBJECT_ID('ProductMaterial')" +
                " and name<>'ID';" +
                " select @sql = N'SELECT pMat.[ID],pMat.Materials,pt.' + @language + ' [Name]" +
                " from" +
                " (" +
                " select *" +
                " from ProductMaterial" +
                " unpivot" +
                " (Material for Materials in ('+STUFF(@cols,1,1,'')+')" +
                " ) as up" +
                " where up.Material = 1" +
                " )pMat" +
                " left join ProductTranslation pt on pMat.Materials = pt.ID and pt.Category = ''ProductMaterial''" +
                " where pMat.ID = '''+@productID+''';" +
                " ';" +
                " Exec sp_executesql @sql";

            cmd = new SqlCommand(query, conn);
            da = new SqlDataAdapter(cmd);
            DataTable dtMaterial = new DataTable();
            da.Fill(dtMaterial);
            dt.Columns.Add("LDMaterial");

            for (int i = 0; i < dtMaterial.Rows.Count; i++)
            {
                if (i == 0)
                {
                    dt.Rows[0]["LDMaterial"] = dtMaterial.Rows[i]["Name"].ToString();
                }
                else
                {
                    dt.Rows[0]["LDMaterial"] += "," + dtMaterial.Rows[i]["Name"].ToString();
                }
            }
        }

        return dt;
    }

    private void BuildPage(Product p, string language)
    {
        string imgServerFilePath = @"\\192.168.10.222\Web\Nizing" + p.ImageLocation.Replace('/', '\\');
        string imgWebFilePath = p.ImageLocation;

        string displayImageServerFilePath = imgServerFilePath + @"display\";
        string displayWebFilePath = imgWebFilePath + @"display/";
        List<string> displayImages = GetImageFiles(displayImageServerFilePath);

        #region Build Json-LD
        //Build Json-LD
        ClientScriptManager cs = ClientScript;
        string csName = "json-ld";
        Type csType = this.GetType();

        if (!cs.IsClientScriptBlockRegistered(csType, csName))
        {
            StringBuilder csText = new StringBuilder();
            csText.Append("<script type=\"application/ld+json\">{\n");
            csText.Append("\"@context\": \"" + p.StructuredDataSchema.Context + "\",\n");
            csText.Append("\"@type\": \"" + p.StructuredDataSchema.Type + "\",\n");
            csText.Append("\"brand\":{\n");
            csText.Append("\"@type\":\"" + p.StructuredDataSchema.Brand_Type + "\",\n");
            csText.Append("\"name\":\"" + p.StructuredDataSchema.Brand_Name + "\"\n");
            csText.Append("},\n");
            csText.Append("\"logo\":\"" + p.StructuredDataSchema.Logo + "\",\n");
            csText.Append("\"productID\":\"" + p.StructuredDataSchema.ProductID + "\",\n");
            csText.Append("\"name\":\"" + p.StructuredDataSchema.Name + "\",\n");
            csText.Append("\"description\":\"" + p.StructuredDataSchema.Description + "\",\n");
            csText.Append("\"material\":\"" + p.StructuredDataSchema.Material + "\",\n");
            if (displayImages.Count > 0)
            {
                csText.Append("\"image\":");
                for (int i = 0; i < displayImages.Count; i++)
                {
                    csText.Append("\"" + displayWebFilePath + displayImages[i] + "\",");
                    if (i == displayImages.Count - 1)
                    {
                        csText.Append("\n");
                    }
                }
            }
            csText.Append("\"sku\":\"" + p.StructuredDataSchema.SKU + "\",\n");
            csText.Append("\"url\":\"" + p.StructuredDataSchema.URL + "\",\n");
            csText.Append("\"offers\":{\n");
            csText.Append("\"@type\":\"" + p.StructuredDataSchema.Offers_Type + "\",\n");
            csText.Append("\"url\":\"" + p.StructuredDataSchema.Offers_URL + "\",\n");
            csText.Append("\"priceCurrency\":\"" + p.StructuredDataSchema.Offers_PriceCurrency + "\",\n");
            csText.Append("\"price\":\"" + p.StructuredDataSchema.Offers_Price + "\",\n");
            csText.Append("\"priceValidUntil\":\"" + DateTime.Today.Year + "-12-31\",\n");
            csText.Append("\"itemCondition\":\"" + p.StructuredDataSchema.Offers_ItemCondition + "\",\n");
            csText.Append("\"availability\":\"" + p.StructuredDataSchema.Offers_Availability + "\"\n");
            csText.Append("}\n");
            csText.Append("}</script>");
            cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
        }
        #endregion

        #region Build HTML
        HtmlGenericControl section = new HtmlGenericControl("section");
        section.Attributes["class"] = "display-block";
        //section.Attributes["itemscope"] = "";
        section.Attributes["itemtype"] = p.StructuredDataSchema.Context + "/" + p.StructuredDataSchema.Type;
        productItem.Controls.Add(section);

        HtmlGenericControl article = new HtmlGenericControl("article");
        article.Attributes["class"] = "container";
        section.Controls.Add(article);

        HtmlGenericControl h2 = new HtmlGenericControl("h2");
        h2.Attributes["itemprop"] = "name";
        h2.Attributes["class"] = "title";
        h2.InnerText = p.Name;
        article.Controls.Add(h2);

        h2 = new HtmlGenericControl("h2");
        h2.Attributes["itemprop"] = "productID";
        h2.Attributes["class"] = "subtitle";
        h2.InnerText = p.ID;
        article.Controls.Add(h2);

        HtmlGenericControl divBriefProductInfo = new HtmlGenericControl("div");
        divBriefProductInfo.Attributes["class"] = "content row brief-product-info";
        article.Controls.Add(divBriefProductInfo);

        #region Images
        HtmlGenericControl divProductImageSection = new HtmlGenericControl("div");
        divProductImageSection.Attributes["class"] = "col-lg-7 pl-lg-0  product-image-section";
        divBriefProductInfo.Controls.Add(divProductImageSection);

        HtmlGenericControl divProductImageCarousel = new HtmlGenericControl("div");
        divProductImageCarousel.ID = "product-image-carousel";
        divProductImageCarousel.Attributes["class"] = "carousel slide product-image-carousel";
        divProductImageCarousel.Attributes["data-ride"] = "carousel";
        divProductImageCarousel.Attributes["data-interval"] = "false";
        divProductImageSection.Controls.Add(divProductImageCarousel);

        HtmlGenericControl ol = new HtmlGenericControl("ol");
        ol.Attributes["class"] = "carousel-indicators";
        divProductImageCarousel.Controls.Add(ol);

        #region Load Images

        int indicatorCount = displayImages.Count() == 0 ? 1 : displayImages.Count();
        for (int i = 0; i < indicatorCount; i++)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes["data-target"] = "#" + divProductImageCarousel.ClientID;
            li.Attributes["data-slide-to"] = i.ToString();
            if (i == 0)
            {
                li.Attributes["class"] = "active";
            }
            ol.Controls.Add(li);
        }

        HtmlGenericControl div4 = new HtmlGenericControl("div");
        div4.Attributes["class"] = "carousel-inner";
        divProductImageCarousel.Controls.Add(div4);

        for (int i = 0; i < indicatorCount; i++)
        {
            HtmlGenericControl figure = new HtmlGenericControl("figure");
            if (i == 0)
            {
                figure.Attributes["class"] = "carousel-item product-image active";
            }
            else
            {
                figure.Attributes["class"] = "carousel-item product-image";
            }
            div4.Controls.Add(figure);

            HtmlGenericControl img = new HtmlGenericControl("img");
            img.Attributes["itemprop"] = "image";
            img.Attributes["alt"] = p.Description;
            if (displayImages.Count != 0)
            {
                img.Attributes["src"] = displayWebFilePath + displayImages[i];
            }
            else
            {
                img.Attributes["src"] = "/images/placeholder/product-image-placeholder.png";
            }
            figure.Controls.Add(img);
        }
        #endregion

        if (displayImages.Count > 1)
        {
            HtmlGenericControl anchorCarouselLeftArrow = new HtmlGenericControl("a");
            anchorCarouselLeftArrow.Attributes["class"] = "carousel-control-prev";
            anchorCarouselLeftArrow.Attributes["href"] = "#" + divProductImageCarousel.ClientID;
            anchorCarouselLeftArrow.Attributes["role"] = "button";
            anchorCarouselLeftArrow.Attributes["data-slide"] = "prev";
            divProductImageCarousel.Controls.Add(anchorCarouselLeftArrow);

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes["class"] = "carousel-control-prev-icon";
            span.Attributes["aria-hidden"] = "true";
            anchorCarouselLeftArrow.Controls.Add(span);
            span = new HtmlGenericControl("span");
            span.Attributes["class"] = "sr-only";
            span.InnerText = "Previous";
            anchorCarouselLeftArrow.Controls.Add(span);

            HtmlGenericControl anchorCarouselRightArrow = new HtmlGenericControl("a");
            anchorCarouselRightArrow.Attributes["class"] = "carousel-control-next";
            anchorCarouselRightArrow.Attributes["href"] = "#" + divProductImageCarousel.ClientID;
            anchorCarouselRightArrow.Attributes["role"] = "button";
            anchorCarouselRightArrow.Attributes["data-slide"] = "next";
            divProductImageCarousel.Controls.Add(anchorCarouselRightArrow);
            span = new HtmlGenericControl("span");
            span.Attributes["class"] = "carousel-control-next-icon";
            span.Attributes["aria-hidden"] = "true";
            anchorCarouselRightArrow.Controls.Add(span);
            span = new HtmlGenericControl("span");
            span.Attributes["class"] = "sr-only";
            span.InnerText = "Next";
            anchorCarouselRightArrow.Controls.Add(span);
        }

        #endregion

        #region Color Code
        HtmlGenericControl divColorCodeSection = new HtmlGenericControl("div");
        divColorCodeSection.Attributes["class"] = "color-code-section";
        divProductImageSection.Controls.Add(divColorCodeSection);
        HtmlGenericControl div = new HtmlGenericControl("div");
        div.InnerText = "Color: ";
        divColorCodeSection.Controls.Add(div);
        List<string> ColorList = p.GetColorList(GetProductColorTable(p.ID, language));
        if (ColorList.Count > 0)
        {
            foreach (string s in ColorList)
            {
                div = new HtmlGenericControl("div");
                div.Attributes["class"] = "color-code bg-" + s;
                divColorCodeSection.Controls.Add(div);
            }
        }
        else
        {
            div = new HtmlGenericControl("div");
            if (language == "zh")
            {
                div.InnerText = "客製";
            }
            else
            {
                div.InnerText = "Customize";
            }

            divColorCodeSection.Controls.Add(div);
        }
        #endregion

        #region Text and Certification
        HtmlGenericControl divProductText = new HtmlGenericControl("div");
        divProductText.Attributes["class"] = "col-lg-5 pr-lg-0 product-text";
        divBriefProductInfo.Controls.Add(divProductText);
        #region 應用產業
        HtmlGenericControl divApplicationField = new HtmlGenericControl("div");
        divApplicationField.Attributes["class"] = "text-section application-field";
        divProductText.Controls.Add(divApplicationField);
        div = new HtmlGenericControl("div");
        div.Attributes["class"] = "nizing-blue";
        if (language == "zh")
        {
            div.InnerText = "適用領域";
        }
        else
        {
            div.InnerText = "Application";
        }
        divApplicationField.Controls.Add(div);
        HtmlGenericControl spanApplicationField = new HtmlGenericControl("span");
        spanApplicationField.InnerText = p.Description;
        divApplicationField.Controls.Add(spanApplicationField);
        #endregion
        #region 技術資料
        List<Tuple<string, string>> techSpec = p.GetTechnicalSpecList(GetProductSpecTable(p.ID, language));
        if (techSpec.Count > 0)
        {
            HtmlGenericControl divSimpleSpecField = new HtmlGenericControl("div");
            divSimpleSpecField.Attributes["class"] = "text-section simple-product-spec";
            divProductText.Controls.Add(divSimpleSpecField);
            div = new HtmlGenericControl("div");
            div.Attributes["class"] = "nizing-blue";
            if (language == "zh")
            {
                div.InnerText = "技術資料";
            }
            else
            {
                div.InnerText = "Technical Spec";
            }
            divSimpleSpecField.Controls.Add(div);
            HtmlTable tableSimpleSpecField = new HtmlTable();
            divSimpleSpecField.Controls.Add(tableSimpleSpecField);
            foreach (Tuple<string, string> tuple in techSpec)
            {
                HtmlTableRow tr = new HtmlTableRow();
                tableSimpleSpecField.Controls.Add(tr);
                HtmlTableCell td = new HtmlTableCell();
                td.InnerText = tuple.Item1 + ":";
                tr.Controls.Add(td);
                td = new HtmlTableCell();
                td.InnerText = tuple.Item2;
                tr.Controls.Add(td);
            }
        }
        #endregion
        #region 認證
        List<string> certificateList = p.GetCertificateList(GetProductCertificationTable(p.ID, language));
        if (certificateList.Count > 0)
        {
            HtmlGenericControl divProductCertification = new HtmlGenericControl("div");
            divProductCertification.Attributes["class"] = "row product-certification";
            divProductText.Controls.Add(divProductCertification);
            foreach (string s in certificateList)
            {
                div = new HtmlGenericControl("div");
                div.Attributes["class"] = "col-2";
                divProductCertification.Controls.Add(div);
                HtmlImage img = new HtmlImage();
                img.Src = @"/images/certificate/" + s + @"/" + s + @".png";
                div.Controls.Add(img);
            }
        }
        #endregion
        #endregion

        #region 詳細資料
        string specServerFilePath = imgServerFilePath + @"spec\";
        string specWebFilePath = imgWebFilePath + @"spec/";
        List<string> specImages = GetImageFiles(specServerFilePath);

        if (specImages.Count > 0)
        {
            HtmlGenericControl divFullProductInfo = new HtmlGenericControl("div");
            divFullProductInfo.Attributes["class"] = "content full-product-spec";
            article.Controls.Add(divFullProductInfo);
            foreach (string image in specImages)
            {
                div = new HtmlGenericControl("div");
                divFullProductInfo.Controls.Add(div);
                HtmlAnchor anchorFullProductInfoImage = new HtmlAnchor();
                anchorFullProductInfoImage.HRef = specWebFilePath + image;
                anchorFullProductInfoImage.Target = "_blank";
                div.Controls.Add(anchorFullProductInfoImage);
                HtmlImage imgFullProductInfo = new HtmlImage();
                imgFullProductInfo.Src = specWebFilePath + image;
                imgFullProductInfo.Alt = p.Name + " full spec";
                anchorFullProductInfoImage.Controls.Add(imgFullProductInfo);
            }
        }

        #endregion

        #endregion
    }

    protected DataTable GetProductColorTable(string PID, string language)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "declare" +
                " @tableName nvarchar(255)='ProductColor'," +
            " @productID nvarchar(255)= N'" + PID + "'," +
            " @language nvarchar(10)= '" + language + "';" +
            " declare" +
            " @sql NVARCHAR(MAX) = N''," +
            " @cols NVARCHAR(MAX) = N'';" +
            " select @cols += ', ' + QUOTENAME(name)" +
            " from sys.columns" +
            " where [object_id] = OBJECT_ID(@tableName)" +
            " and name<>'ID';" +
            " select @sql = N'SELECT p.[ID],p.[Attributes],pt.['+@language+'] [AttributeName]" +
            " from" +
            " (" +
            " select *" +
            " from '+@tableName+'" +
            " unpivot" +
            " (Attribute for Attributes in ('+STUFF(@cols,1,1,'')+')" +
            " ) as up" +
            " where up.Attribute = 1" +
            " )p" +
            " left join ProductTranslation pt on p.Attributes = pt.ID and pt.Category = '''+@tableName+'''" +
            " where p.ID = '''+@productID+''';" +
            " ';" +
            " Exec sp_executesql @sql";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        return dt;
    }

    protected DataTable GetProductCertificationTable(string PID, string language)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "declare" +
                " @tableName nvarchar(255)='ProductCertification'," +
            " @productID nvarchar(255)= N'" + PID + "'," +
            " @language nvarchar(10)= '" + language + "';" +
            " declare" +
            " @sql NVARCHAR(MAX) = N''," +
            " @cols NVARCHAR(MAX) = N'';" +
            " select @cols += ', ' + QUOTENAME(name)" +
            " from sys.columns" +
            " where [object_id] = OBJECT_ID(@tableName)" +
            " and name<>'ID';" +
            " select @sql = N'SELECT p.[ID],p.[Attributes],pt.['+@language+'] [AttributeName]" +
            " from" +
            " (" +
            " select *" +
            " from '+@tableName+'" +
            " unpivot" +
            " (Attribute for Attributes in ('+STUFF(@cols,1,1,'')+')" +
            " ) as up" +
            " where up.Attribute = 1" +
            " )p" +
            " left join ProductTranslation pt on p.Attributes = pt.ID and pt.Category = '''+@tableName+'''" +
            " where p.ID = '''+@productID+''';" +
            " ';" +
            " Exec sp_executesql @sql";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        return dt;
    }

    protected DataTable GetProductSpecTable(string PID, string language)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "declare" +
                " @tableName nvarchar(255)='ProductTechnicalSpec'," +
            " @productID nvarchar(255)= N'" + PID + "'," +
            " @language nvarchar(10)= '" + language + "';" +
            " declare" +
            " @sql NVARCHAR(MAX) = N''," +
            " @cols NVARCHAR(MAX) = N'';" +
            " select @cols += ', ' + QUOTENAME(name)" +
            " from sys.columns" +
            " where [object_id] = OBJECT_ID(@tableName)" +
            " and name<>'ID';" +
            " select @sql = N'SELECT p.[ID],p.[Attributes],pt.['+@language+'] [AttributeName],p.[Attribute] [AttributeValue]" +
            " from" +
            " (" +
            " select *" +
            " from '+@tableName+'" +
            " unpivot" +
            " (Attribute for Attributes in ('+STUFF(@cols,1,1,'')+')" +
            " ) as up" +
            " where up.Attribute <> ''''" +
            " and up.Attribute is not null" +
            " )p" +
            " left join ProductTranslation pt on p.Attributes = pt.ID and pt.Category = '''+@tableName+'''" +
            " where p.ID = '''+@productID+''';" +
            " ';" +
            " Exec sp_executesql @sql";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        return dt;
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

