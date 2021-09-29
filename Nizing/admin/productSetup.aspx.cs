using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class admin_productSetup : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Initialize();
        }
        //fill up 產品認證 清單
        GenerateCertficateList();

        //fill up 產品顏色 清單
        GenerateColorList();
        //lblMessage.Text = ((HtmlInputCheckBox)divColorList.FindControl("Black")).Checked.ToString();
        if (ViewState["DynamicSpecList"] != null)
        {
            GenerateProductSpecControl((List<Tuple<string, string>>)ViewState["DynamicSpecList"]);
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        List<Tuple<string, string>> dynamicSpecControls = new List<Tuple<string, string>>();
        foreach (HtmlGenericControl div in divSpecList.Controls.OfType<HtmlGenericControl>())
        {
            dynamicSpecControls.Add(new Tuple<string, string>(div.ID, ((LiteralControl)div.FindControl("span" + div.ID)).Text));
        }
        ViewState["DynamicSpecList"] = dynamicSpecControls;

    }

    protected void Initialize()
    {

        DataTable dt = new DataTable();

        //fill up 產品分類 dropdown
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select [ID],zh" +
                " from ProductCategory" +
                " order by [ID]";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlProductCategory.Items.Add(new ListItem(dt.Rows[i]["zh"].ToString(), dt.Rows[i]["ID"].ToString()));
        }

        ddlProductCategory.SelectedValue = "silicone-fiberglass-wire";

        //fill up 產品材料 清單
        GenerateAllMaterialList();

        //fill up 應用產業清單
        GenerateAllApplicationList();
    }

    protected void GenerateCertficateList()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select pt.[ID]" +
                " , pt.zh [Name]" +
                " from INFORMATION_SCHEMA.COLUMNS col" +
                " left join ProductTranslation pt on col.COLUMN_NAME = pt.ID" +
                " where col.TABLE_NAME = 'ProductCertification'" +
                " and pt.Category = 'ProductCertification'" +
                " and col.COLUMN_NAME <> 'ID'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlGenericControl divCheckboxWrapper = new HtmlGenericControl("div");
            divCheckboxWrapper.ID = "divCertificationList" + dt.Rows[i]["ID"].ToString();
            divCheckboxWrapper.Attributes.Add("class", "col");
            divCertificationList.Controls.Add(divCheckboxWrapper);

            HtmlInputCheckBox ckx = new HtmlInputCheckBox();
            ckx.ID = dt.Rows[i]["ID"].ToString();
            divCheckboxWrapper.Controls.Add(ckx);

            HtmlGenericControl label = new HtmlGenericControl("label");
            label.Attributes.Add("for", ckx.ClientID);
            label.InnerText = dt.Rows[i]["Name"].ToString();
            divCheckboxWrapper.Controls.Add(label);
        }
    }

    protected void GenerateColorList()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select pt.[ID]" +
                " , pt.zh [Name]" +
                " from INFORMATION_SCHEMA.COLUMNS col" +
                " left join ProductTranslation pt on col.COLUMN_NAME = pt.ID" +
                " where col.TABLE_NAME = 'ProductColor'" +
                " and pt.Category = 'ProductColor'" +
                " and col.COLUMN_NAME <> 'ID'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlGenericControl divCheckboxWrapper = new HtmlGenericControl("div");
            divCheckboxWrapper.ID = "divColorList" + dt.Rows[i]["ID"].ToString();
            divCheckboxWrapper.Attributes.Add("class", "col");
            divColorList.Controls.Add(divCheckboxWrapper);

            HtmlInputCheckBox ckx = new HtmlInputCheckBox();
            ckx.ID = dt.Rows[i]["ID"].ToString();
            divCheckboxWrapper.Controls.Add(ckx);

            HtmlGenericControl label = new HtmlGenericControl("label");
            label.Attributes.Add("for", ckx.ClientID);
            label.Attributes.Add("class", "bg-as-text-color");
            label.Attributes.Add("style", "background-image: var(--nizing-" + dt.Rows[i]["ID"].ToString().ToLower() + ");" +
                "background-color: var(--nizing-" + dt.Rows[i]["ID"].ToString().ToLower() + ");");
            label.InnerText = dt.Rows[i]["Name"].ToString();
            divCheckboxWrapper.Controls.Add(label);
        }
    }

    protected void GenerateAllMaterialList()
    {
        lbxAllMaterialList.Items.Clear();

        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select pt.[ID]" +
                " , pt.zh+'-'+pt.en [Name]" +
                " from INFORMATION_SCHEMA.COLUMNS col" +
                " left join ProductTranslation pt on col.COLUMN_NAME = pt.ID" +
                " where col.TABLE_NAME = 'ProductMaterial'" +
                " and pt.Category = 'ProductMaterial'" +
                " and col.COLUMN_NAME <> 'ID'" +
                " order by pt.[ID]";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        foreach (DataRow row in dt.Rows)
        {
            lbxAllMaterialList.Items.Add(new ListItem(row["Name"].ToString().Trim(), row["ID"].ToString().Trim()));
        }
        SortMaterialList();
    }
    protected void UpdateAllMaterialList()
    {
        GenerateAllMaterialList();
        foreach (ListItem item in lbxProductMaterialList.Items)
        {
            if (lbxAllMaterialList.Items.Contains(item))
            {
                lbxAllMaterialList.Items.Remove(item);
            }
        }
        SortMaterialList();
    }

    protected void GenerateAllApplicationList()
    {
        lbxAllApplicationList.Items.Clear();

        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select [ID]" +
                " ,zh [Name]" +
                " from ApplicationCategory" +
                " order by [ID]";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        foreach (DataRow row in dt.Rows)
        {
            lbxAllApplicationList.Items.Add(new ListItem(row["Name"].ToString().Trim(), row["ID"].ToString().Trim()));
        }
        SortApplicationList();
    }

    protected void UpdateAllApplicationList()
    {
        GenerateAllApplicationList();
        foreach (ListItem item in lbxProductApplicationList.Items)
        {
            if (lbxAllApplicationList.Items.Contains(item))
            {
                lbxAllApplicationList.Items.Remove(item);
            }
        }
        SortApplicationList();
    }

    protected void GenerateAllSpecList()
    {
        lbxAllTechnicalSpecList.Items.Clear();

        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select pt.[ID]" +
                " , pt.zh [Name]" +
                " from INFORMATION_SCHEMA.COLUMNS col" +
                " left join ProductTranslation pt on col.COLUMN_NAME = pt.ID" +
                " where col.TABLE_NAME = 'ProductTechnicalSpec'" +
                " and pt.Category = 'ProductTechnicalSpec'" +
                " and col.COLUMN_NAME <> 'ID'" +
                " order by pt.[ID]";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        foreach (DataRow row in dt.Rows)
        {
            lbxAllTechnicalSpecList.Items.Add(new ListItem(row["Name"].ToString().Trim(), row["ID"].ToString().Trim()));
        }
    }
    protected void UpdateAllSpecList()
    {
        foreach (HtmlGenericControl div in divSpecList.Controls.OfType<HtmlGenericControl>())
        {
            ListItem item = lbxAllTechnicalSpecList.Items.FindByValue(div.ID);
            if (item != null)
            {
                lbxAllTechnicalSpecList.Items.Remove(item);
            }
        }
    }

    protected void GenerateProductSpecControl(List<Tuple<string, string>> SpecList)
    {
        foreach (Tuple<string, string> ID in SpecList)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = ID.Item1;
            div.Attributes.Add("class", "item");
            divSpecList.Controls.Add(div);

            LiteralControl span = new LiteralControl();
            span.ID = "span" + ID.Item1;
            span.Text = ID.Item2;
            div.Controls.Add(span);

            HtmlInputText txt = new HtmlInputText();
            txt.ID = "txt" + ID.Item1;
            txt.Attributes.Add("class", "txt");
            div.Controls.Add(txt);

            HtmlAnchor btn = new HtmlAnchor();
            btn.ID = "btn" + div.ID;
            btn.Attributes.Add("class", "btn btn-danger btn-sm");
            btn.InnerText = "移除";
            btn.ServerClick += new EventHandler(RemoveItemSpecFromList);
            div.Controls.Add(btn);

            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = btn.ClientID;
            trigger.EventName = "Click";
            upProductTechnicalSpec.Triggers.Add(trigger);
        }
    }

    protected void SortListBox(ListBox lbx)
    {
        List<ListItem> list = new List<ListItem>();
        foreach (ListItem l in lbx.Items)
        {
            list.Add(l);
        }
        list.Sort((x, y) => x.Value.CompareTo(y.Value));
        lbx.Items.Clear();
        foreach (ListItem l in list)
        {
            lbx.Items.Add(l);
        }
    }

    protected void ClearMaterialSelection()
    {
        lbxAllMaterialList.ClearSelection();
        lbxProductMaterialList.ClearSelection();
    }

    protected void ClearApplicationSelection()
    {
        lbxAllApplicationList.ClearSelection();
        lbxProductApplicationList.ClearSelection();
    }

    protected void SortMaterialList()
    {
        SortListBox(lbxAllMaterialList);
        SortListBox(lbxProductMaterialList);
    }

    protected void SortApplicationList()
    {
        SortListBox(lbxAllApplicationList);
        SortListBox(lbxProductApplicationList);
    }
    private void ShowModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('show');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

    private void CloseModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('hide');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

    protected void btnAddMaterial_Click(object sender, EventArgs e)
    {
        int[] selectedIndices = lbxAllMaterialList.GetSelectedIndices();
        foreach (int i in selectedIndices)
        {
            if (!lbxProductMaterialList.Items.Contains(lbxAllMaterialList.Items[i]))
            {
                lbxProductMaterialList.Items.Add(lbxAllMaterialList.Items[i]);
            }
        }

        for (int i = lbxAllMaterialList.Items.Count - 1; i >= 0; i--)
        {
            if (selectedIndices.Contains(i))
            {
                lbxAllMaterialList.Items.RemoveAt(i);
            }
        }

        SortMaterialList();
        ClearMaterialSelection();
    }

    protected void btnRemoveMaterial_Click(object sender, EventArgs e)
    {
        int[] selectedIndices = lbxProductMaterialList.GetSelectedIndices();
        foreach (int i in lbxProductMaterialList.GetSelectedIndices())
        {
            if (!lbxAllMaterialList.Items.Contains(lbxProductMaterialList.Items[i]))
            {
                lbxAllMaterialList.Items.Add(lbxProductMaterialList.Items[i]);
            }
        }
        for (int i = lbxProductMaterialList.Items.Count - 1; i >= 0; i--)
        {
            if (selectedIndices.Contains(i))
            {
                lbxProductMaterialList.Items.RemoveAt(i);
            }
        }

        SortMaterialList();
        ClearMaterialSelection();
    }

    protected void btnFetchData_Click(object sender, EventArgs e)
    {

    }

    protected void FetchData(string PID)
    {
        bool ProductExists = false;
        DataTable dt = new DataTable();

        //Fetch 產品ID, 產品分類,HotItem
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();

            string query = "select [ID]" +
                " ,[Category]" +
                " ,[HotItem]" +
                " from Product" +
                " where [ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }

        lblProductID.Text = PID;

        if (dt.Rows.Count > 0)
        {
            ProductExists = true;
            ddlProductCategory.SelectedValue = dt.Rows[0]["Category"].ToString();
            ckxHotItem.Checked = dt.Rows[0]["HotItem"] == DBNull.Value ? false : (bool)dt.Rows[0]["HotItem"];
        }

        if (ProductExists)
        {
            ClearMessages();
            DeleteButton(true);
            #region Fetch 名稱,產品說明
            //Fetch 名稱,產品說明
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();

                string query = "select [ContentLanguage]" +
                    " ,[Name]" +
                    " ,[Description]" +
                    " from ProductMultilingualContent" +
                    " where [ID]=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", PID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                DataRow[] drChinese = dt.Select("ContentLanguage='zh'");
                DataRow[] drEnglish = dt.Select("ContentLanguage='en'");

                if (drChinese.Count() > 0)
                {
                    txtProductChineseName.Text = drChinese[0]["Name"].ToString().Trim();
                    txtProductChineseDescription.Text = drChinese[0]["Description"].ToString().Trim();
                }

                if (drEnglish.Count() > 0)
                {
                    txtProductEnglishName.Text = drEnglish[0]["Name"].ToString().Trim();
                    txtProductEnglishDescription.Text = drEnglish[0]["Description"].ToString().Trim();
                }
            }
            #endregion

            #region Fetch Colors
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();

                string query = "declare" +
                    " @tableName nvarchar(255)='ProductColor'," +
                " @productID nvarchar(255)= N'" + PID + "'," +
                " @language nvarchar(10)= 'en';" +
                " declare" +
                " @sql NVARCHAR(MAX) = N''," +
                " @cols NVARCHAR(MAX) = N'';" +
                " select @cols += ', ' + QUOTENAME(name)" +
                " from sys.columns" +
                " where [object_id] = OBJECT_ID(@tableName)" +
                " and name<>'ID';" +
                " select @sql = N'SELECT p.[ID],p.Colors" +
                " from" +
                " (" +
                " select *" +
                " from '+@tableName+'" +
                " unpivot" +
                " (Color for Colors in ('+STUFF(@cols,1,1,'')+')" +
                " ) as up" +
                " where up.Color = 1" +
                " )p" +
                " left join ProductTranslation pt on p.Colors = pt.ID and pt.Category = '''+@tableName+'''" +
                " where p.ID = '''+@productID+''';" +
                " ';" +
                " Exec sp_executesql @sql";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                ClearColors();
                foreach (DataRow dr in dt.Rows)
                {
                    ((HtmlInputCheckBox)divColorList.FindControl(dr["Colors"].ToString().Trim())).Checked = true;
                }
            }
            #endregion

            #region Fetch Certification
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();

                string query = "declare" +
                    " @tableName nvarchar(255)='ProductCertification'," +
                " @productID nvarchar(255)= N'" + PID + "'," +
                " @language nvarchar(10)= 'en';" +
                " declare" +
                " @sql NVARCHAR(MAX) = N''," +
                " @cols NVARCHAR(MAX) = N'';" +
                " select @cols += ', ' + QUOTENAME(name)" +
                " from sys.columns" +
                " where [object_id] = OBJECT_ID(@tableName)" +
                " and name<>'ID';" +
                " select @sql = N'SELECT p.[ID],p.Certificates [Header]" +
                " from" +
                " (" +
                " select *" +
                " from '+@tableName+'" +
                " unpivot" +
                " (Certificate for Certificates in ('+STUFF(@cols,1,1,'')+')" +
                " ) as up" +
                " where up.Certificate = 1" +
                " )p" +
                " left join ProductTranslation pt on p.Certificates = pt.ID and pt.Category = '''+@tableName+'''" +
                " where p.ID = '''+@productID+''';" +
                " ';" +
                " Exec sp_executesql @sql";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                ClearCertificates();
                foreach (DataRow dr in dt.Rows)
                {
                    ((HtmlInputCheckBox)divColorList.FindControl(dr["Header"].ToString().Trim())).Checked = true;
                }
            }
            #endregion

            #region Fetch Materials
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();

                string query = "declare" +
                    " @tableName nvarchar(255)='ProductMaterial'," +
                " @productID nvarchar(255)= N'" + PID + "'," +
                " @language nvarchar(10)= 'zh';" +
                " declare" +
                " @sql NVARCHAR(MAX) = N''," +
                " @cols NVARCHAR(MAX) = N'';" +
                " select @cols += ', ' + QUOTENAME(name)" +
                " from sys.columns" +
                " where [object_id] = OBJECT_ID(@tableName)" +
                " and name<>'ID';" +
                " select @sql = N'SELECT p.[ID],p.Materials [Header],pt.'+@language+'+''-''+pt.en [Name]" +
                " from" +
                " (" +
                " select *" +
                " from '+@tableName+'" +
                " unpivot" +
                " (Material for Materials in ('+STUFF(@cols,1,1,'')+')" +
                " ) as up" +
                " where up.Material = 1" +
                " )p" +
                " left join ProductTranslation pt on p.Materials = pt.ID and pt.Category = '''+@tableName+'''" +
                " where p.ID = '''+@productID+''';" +
                " ';" +
                " Exec sp_executesql @sql";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            lbxProductMaterialList.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                lbxProductMaterialList.Items.Add(new ListItem(row["Name"].ToString().Trim(), row["Header"].ToString().Trim()));
            }

            UpdateAllMaterialList();
            SortMaterialList();

            #endregion

            #region Fetch Spec
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();

                string query = "declare" +
                    " @tableName nvarchar(255)='ProductTechnicalSpec'," +
                " @productID nvarchar(255)= N'" + PID + "'," +
                " @language nvarchar(10)= 'zh';" +
                " declare" +
                " @sql NVARCHAR(MAX) = N''," +
                " @cols NVARCHAR(MAX) = N'';" +
                " select @cols += ', ' + QUOTENAME(name)" +
                " from sys.columns" +
                " where [object_id] = OBJECT_ID(@tableName)" +
                " and name<>'ID';" +
                " select @sql = N'SELECT p.[ID],p.Specs [Header],p.Spec [Value],pt.'+@language+' [Name]" +
                " from" +
                " (" +
                " select *" +
                " from '+@tableName+'" +
                " unpivot" +
                " (Spec for Specs in ('+STUFF(@cols,1,1,'')+')" +
                " ) as up" +
                " where up.Spec <> ''''" +
                " and up.Spec is not null" +
                " )p" +
                " left join ProductTranslation pt on p.Specs = pt.ID and pt.Category = '''+@tableName+'''" +
                " where p.ID = '''+@productID+''';" +
                " ';" +
                " Exec sp_executesql @sql";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            ClearSpecList();
            List<Tuple<string, string>> specList = new List<Tuple<string, string>>();
            foreach (DataRow dr in dt.Rows)
            {
                specList.Add(new Tuple<string, string>(dr["Header"].ToString(), dr["Name"].ToString()));
            }
            GenerateProductSpecControl(specList);
            foreach (DataRow dr in dt.Rows)
            {
                ((HtmlInputText)divSpecList.FindControl("txt" + dr["Header"].ToString())).Value = dr["Value"].ToString();
            }
            #endregion

            #region Fetch Application
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();

                string query = "select pa.ApplicationID [ID]" +
                    " ,app.zh [Name]" +
                    " from ProductApplication pa" +
                    " left join ApplicationCategory app on pa.ApplicationID=app.ID" +
                    " where pa.ProductID=@PID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }

            lbxProductApplicationList.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                lbxProductApplicationList.Items.Add(new ListItem(row["Name"].ToString().Trim(), row["ID"].ToString().Trim()));
            }

            UpdateAllApplicationList();
            SortApplicationList();
            #endregion

            lblMessage.Text = "產品已存在，進行編輯";
        }
        else
        {
            DeleteButton(false);
            ResetForm();
            lblProductID.Text = PID;
            lblMessage.Text = "新增產品";
        }
    }

    protected void ClearColors()
    {
        foreach (HtmlGenericControl div in divColorList.Controls)
        {
            foreach (HtmlInputCheckBox cbx in div.Controls.OfType<HtmlInputCheckBox>())
            {
                cbx.Checked = false;
            }
        }
    }

    protected void ClearCertificates()
    {
        foreach (HtmlGenericControl div in divCertificationList.Controls)
        {
            foreach (HtmlInputCheckBox cbx in div.Controls.OfType<HtmlInputCheckBox>())
            {
                cbx.Checked = false;
            }
        }
    }

    protected void ClearMaterialList()
    {
        GenerateAllMaterialList();
        lbxProductMaterialList.Items.Clear();
    }
    protected void ClearApplicationList()
    {
        GenerateAllApplicationList();
        lbxProductApplicationList.Items.Clear();
    }
    protected void ClearSpecList()
    {
        divSpecList.Controls.Clear();
    }
    protected void ClearMessages()
    {
        lblMessage.Text = string.Empty;
        foreach (LiteralControl span in divSystemMessages.Controls.OfType<LiteralControl>())
        {
            divSystemMessages.Controls.Remove(span);
        }
    }
    protected void btnClearData_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    protected void ResetForm()
    {
        btnAddProduct.Enabled = false;
        lblProductID.Text = string.Empty;
        ckxHotItem.Checked = false;
        txtProductChineseName.Text = string.Empty;
        txtProductChineseDescription.Text = string.Empty;
        txtProductEnglishName.Text = string.Empty;
        txtProductEnglishDescription.Text = string.Empty;
        ddlProductCategory.SelectedValue = "silicone-fiberglass-wire";
        ClearMessages();
        ClearColors();
        ClearCertificates();
        ClearMaterialList();
        ClearSpecList();
        ClearApplicationList();
        ClearUpdatePanelsDynamicTriggers();
    }

    protected void ClearUpdatePanelsDynamicTriggers()
    {
        upProductTechnicalSpec.Triggers.Clear();
    }

    protected void DeleteButton(bool enable)
    {
        if (enable)
        {
            btnDeleteData.Enabled = true;
            btnDeleteData.CssClass = "btn text-white bg-red";
        }
        else
        {
            btnDeleteData.Enabled = false;
            btnDeleteData.CssClass = "btn text-white bg-red disabled";
        }
    }

    protected void btnUploadData_Click(object sender, EventArgs e)
    {
        /*
         * 上傳資料需要fill九個table
         * Product (ID, Category, ImageLocation)
         * ProductCertification (ID, ISO9001, ROHS, REACH, UL, CUL, VDE, PSE, CCC)
         * ProductColor(ID, White, Black, Red, Yellow, Blue, Green, Brown, YellowGreen, WhiteRed, WhiteBlue, WhiteBlack)
         * ProductMaterial(ID, ...)
         * ProductMultilingualContent(ID, ContentLanguage, Name, Description, URL)
         * ProductStructuredDataSchema(ID, Context, Type, BrandName, Logo, SKU, OfferPriceCurrency, OfferCondition, OfferAvailability)
         * ProductTechnicalSpec(ID,...)
         * ProductApplication(ProductID, ApplicationID)
         */
        ClearMessages();
        List<string> errorList = ErrorCheck();
        if (errorList.Count == 0)
        {
            #region Upload Product
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                string query = "update Product" +
                    " set Category=@Category" +
                    " ,ImageLocation=@ImageLocation" +
                    " ,HotItem=@HotItem" +
                    " where [ID]=@PID" +
                    " if @@ROWCOUNT=0" +
                    " insert into Product ([ID],[Category],[ImageLocation],[HotItem])" +
                    " values (@PID,@Category,@ImageLocation,@HotItem)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.Parameters.AddWithValue("@Category", ddlProductCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@ImageLocation", "/images/product/"
                    + ddlProductCategory.SelectedValue + "/" + lblProductID.Text + "/");
                cmd.Parameters.AddWithValue("@HotItem", ckxHotItem.Checked);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Upload ProductCertification
            List<Tuple<string, int>> pCertList = new List<Tuple<string, int>>();
            foreach (HtmlGenericControl div in divCertificationList.Controls.OfType<HtmlGenericControl>())
            {
                string columnID = div.ID.Replace("divCertificationList", "");
                HtmlInputCheckBox cbx = (HtmlInputCheckBox)div.FindControl(columnID);
                if (cbx.Checked)
                {
                    pCertList.Add(new Tuple<string, int>(cbx.ID, 1));
                }
                else
                {
                    pCertList.Add(new Tuple<string, int>(cbx.ID, 0));
                }
            }
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                string dynamicUpdateQueryColumns = "";
                for (int i = 0; i < pCertList.Count; i++)
                {
                    if (i == 0)
                    {
                        dynamicUpdateQueryColumns = " set " + pCertList[i].Item1 + "=" + pCertList[i].Item2;
                    }
                    else
                    {
                        dynamicUpdateQueryColumns += " , " + pCertList[i].Item1 + "=" + pCertList[i].Item2;
                    }
                }

                string dynamicInsertQueryColumns = "";
                for (int i = 0; i < pCertList.Count; i++)
                {
                    dynamicInsertQueryColumns += " ,[" + pCertList[i].Item1 + "] ";
                }

                string dynamicInsertQueryValues = "";
                for (int i = 0; i < pCertList.Count; i++)
                {
                    dynamicInsertQueryValues += " ," + pCertList[i].Item2.ToString();
                }
                string query = "update ProductCertification" +
                    dynamicUpdateQueryColumns +
                    " where [ID]=@PID" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductCertification ([ID] " + dynamicInsertQueryColumns + ")" +
                    " values (@PID " + dynamicInsertQueryValues + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Upload ProductColor
            List<Tuple<string, int>> pColorList = new List<Tuple<string, int>>();
            foreach (HtmlGenericControl div in divColorList.Controls.OfType<HtmlGenericControl>())
            {
                string columnID = div.ID.Replace("divColorList", "");
                HtmlInputCheckBox cbx = (HtmlInputCheckBox)div.FindControl(columnID);
                if (cbx.Checked)
                {
                    pColorList.Add(new Tuple<string, int>(cbx.ID, 1));
                }
                else
                {
                    pColorList.Add(new Tuple<string, int>(cbx.ID, 0));
                }
            }
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                string dynamicUpdateQueryColumns = "";
                for (int i = 0; i < pColorList.Count; i++)
                {
                    if (i == 0)
                    {
                        dynamicUpdateQueryColumns = " set " + pColorList[i].Item1 + "=" + pColorList[i].Item2;
                    }
                    else
                    {
                        dynamicUpdateQueryColumns += " , " + pColorList[i].Item1 + "=" + pColorList[i].Item2;
                    }
                }

                string dynamicInsertQueryColumns = "";
                for (int i = 0; i < pColorList.Count; i++)
                {
                    dynamicInsertQueryColumns += " ,[" + pColorList[i].Item1 + "] ";
                }

                string dynamicInsertQueryValues = "";
                for (int i = 0; i < pColorList.Count; i++)
                {
                    dynamicInsertQueryValues += " ," + pColorList[i].Item2.ToString();
                }
                string query = "update ProductColor" +
                    dynamicUpdateQueryColumns +
                    " where [ID]=@PID" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductColor ([ID] " + dynamicInsertQueryColumns + ")" +
                    " values (@PID " + dynamicInsertQueryValues + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Upload ProductMaterial
            List<Tuple<string, int>> pMatList = new List<Tuple<string, int>>();
            foreach (ListItem item in lbxProductMaterialList.Items)
            {
                pMatList.Add(new Tuple<string, int>(item.Value, 1));
            }
            foreach (ListItem item in lbxAllMaterialList.Items)
            {
                pMatList.Add(new Tuple<string, int>(item.Value, 0));
            }

            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                string dynamicUpdateQueryColumns = "";
                for (int i = 0; i < pMatList.Count; i++)
                {
                    if (i == 0)
                    {
                        dynamicUpdateQueryColumns = " set " + pMatList[i].Item1 + "=" + pMatList[i].Item2;
                    }
                    else
                    {
                        dynamicUpdateQueryColumns += " , " + pMatList[i].Item1 + "=" + pMatList[i].Item2;
                    }
                }

                string dynamicInsertQueryColumns = "";
                for (int i = 0; i < pMatList.Count; i++)
                {
                    dynamicInsertQueryColumns += " ,[" + pMatList[i].Item1 + "] ";
                }

                string dynamicInsertQueryValues = "";
                for (int i = 0; i < pMatList.Count; i++)
                {
                    dynamicInsertQueryValues += " ," + pMatList[i].Item2.ToString();
                }
                string query = "update ProductMaterial" +
                    dynamicUpdateQueryColumns +
                    " where [ID]=@PID" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductMaterial ([ID] " + dynamicInsertQueryColumns + ")" +
                    " values (@PID " + dynamicInsertQueryValues + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Upload ProductMultilingualContent
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                //insert/update for zh language
                string query = "update ProductMultilingualContent" +
                    " set [Name]=@Name" +
                    " ,Description=@Description" +
                    " ,URL=@Url" +
                    " where [ID]=@PID" +
                    " and [ContentLanguage]=@language" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductMultilingualContent ([ID],[ContentLanguage],[Name],[Description],[URL])" +
                    " values (@PID,@language,@Name,@Description,@Url)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.Parameters.AddWithValue("@language", "zh");
                cmd.Parameters.AddWithValue("@Name", txtProductChineseName.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtProductChineseDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Url", "www.nizing.com.tw/zh/product/" + ddlProductCategory.SelectedValue + "/" + lblProductID.Text);
                cmd.ExecuteNonQuery();

                //insert/update for en language
                query = "update ProductMultilingualContent" +
                    " set [Name]=@Name" +
                    " ,Description=@Description" +
                    " ,URL=@Url" +
                    " where [ID]=@PID" +
                    " and [ContentLanguage]=@language" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductMultilingualContent ([ID],[ContentLanguage],[Name],[Description],[URL])" +
                    " values (@PID,@language,@Name,@Description,@Url)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.Parameters.AddWithValue("@language", "en");
                cmd.Parameters.AddWithValue("@Name", txtProductEnglishName.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtProductEnglishDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Url", "www.nizing.com.tw/en/product/" + ddlProductCategory.SelectedValue + "/" + lblProductID.Text);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Upload ProductStructuredDataSchema
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                //insert/update for zh language
                string query = "update ProductStructuredDataSchema" +
                    " set [Context]=@Context" +
                    " ,Type=@Type" +
                    " ,BrandName=@BrandName" +
                    " ,Logo=@Logo" +
                    " ,SKU=@Sku" +
                    " ,OfferPriceCurrency=@OfferPriceCurrency" +
                    " ,OfferPrice=@OfferPrice" +
                    " ,OfferCondition=@OfferCondition" +
                    " ,OfferAvailability=@OfferAvailability" +
                    " where [ID]=@PID" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductStructuredDataSchema ([ID],[Context],[Type],[BrandName],[Logo]" +
                    " ,[SKU],[OfferPriceCurrency],[OfferPrice],[OfferCondition],[OfferAvailability])" +
                    " values (@PID,@Context,@Type,@BrandName,@Logo,@Sku,@OfferPriceCurrency" +
                    " ,@OfferPrice,@OfferCondition,@OfferAvailability)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.Parameters.AddWithValue("@Context", "https://schema.org/");
                cmd.Parameters.AddWithValue("@Type", "Product");
                cmd.Parameters.AddWithValue("@BrandName", "Nizing");
                cmd.Parameters.AddWithValue("@Logo", "http://www.nizing.com.tw/images/logo/nizing.png");
                cmd.Parameters.AddWithValue("@Sku", "1000000 Meters");
                cmd.Parameters.AddWithValue("@OfferPriceCurrency", "USD");
                cmd.Parameters.AddWithValue("@OfferPrice", 0.01);
                cmd.Parameters.AddWithValue("@OfferCondition", "https://schema.org/NewCondition");
                cmd.Parameters.AddWithValue("@OfferAvailability", "https://schema.org/InStock");
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Upload ProductTechnicalSpec
            List<Tuple<string, string>> pSpecList = new List<Tuple<string, string>>();
            foreach (HtmlGenericControl div in divSpecList.Controls.OfType<HtmlGenericControl>())
            {
                string specID = div.ID;
                string specValue = ((HtmlInputText)div.FindControl("txt" + specID)).Value.Trim();
                pSpecList.Add(new Tuple<string, string>(specID, specValue));
            }
            //update AllSpecList to remove the items in the ProductList from AllSpecList
            GenerateAllSpecList();
            UpdateAllSpecList();
            foreach (ListItem item in lbxAllTechnicalSpecList.Items)
            {
                string specID = item.Value;
                string specValue = "";
                pSpecList.Add(new Tuple<string, string>(specID, specValue));
            }

            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                string dynamicUpdateQueryColumns = "";
                for (int i = 0; i < pSpecList.Count; i++)
                {
                    if (i == 0)
                    {
                        dynamicUpdateQueryColumns = " set " + pSpecList[i].Item1 + "='" + pSpecList[i].Item2 + "'";
                    }
                    else
                    {
                        dynamicUpdateQueryColumns += " , " + pSpecList[i].Item1 + "='" + pSpecList[i].Item2 + "'";
                    }
                }

                string dynamicInsertQueryColumns = "";
                for (int i = 0; i < pSpecList.Count; i++)
                {
                    dynamicInsertQueryColumns += " ,[" + pSpecList[i].Item1 + "] ";
                }

                string dynamicInsertQueryValues = "";
                for (int i = 0; i < pSpecList.Count; i++)
                {
                    dynamicInsertQueryValues += " ,'" + pSpecList[i].Item2 + "'";
                }
                string query = "update ProductTechnicalSpec" +
                    dynamicUpdateQueryColumns +
                    " where [ID]=@PID" +
                    " if @@ROWCOUNT=0" +
                    " insert into ProductTechnicalSpec ([ID] " + dynamicInsertQueryColumns + ")" +
                    " values (@PID " + dynamicInsertQueryValues + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.ExecuteNonQuery();
            }
            #endregion            

            #region Upload ProductApplication
            using (SqlConnection conn = new SqlConnection(webConnectionString))
            {
                conn.Open();
                string query = "delete from ProductApplication" +
                    " where ProductID=@PID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                cmd.ExecuteNonQuery();
                foreach(ListItem item in lbxProductApplicationList.Items)
                {
                    query = "insert into ProductApplication" +
                        " values (@PID, @AID)";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
                    cmd.Parameters.AddWithValue("@AID", item.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            #endregion
            AppendSystemMessage("產品 " + lblProductID.Text + " 上傳成功", "green");
            DeleteButton(true);

        }
        else
        {
            for (int i = 0; i < errorList.Count; i++)
            {
                AppendSystemMessage(errorList[i], "red");
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="textColor">
    /// green
    /// red
    /// </param>
    protected void AppendSystemMessage(string text, string textColor)
    {
        HtmlGenericControl span = new HtmlGenericControl("span");
        span.InnerText = text;
        if (textColor == "green")
        {
            span.Attributes.Add("class", "text-success d-block");
        }
        else if (textColor == "red")
        {
            span.Attributes.Add("class", "text-danger d-block");
        }
        divSystemMessages.Controls.Add(span);
    }

    protected List<string> ErrorCheck()
    {
        List<string> errors = new List<string>();

        if (string.IsNullOrWhiteSpace(lblProductID.Text)
            || string.IsNullOrWhiteSpace(txtProductChineseName.Text)
            || string.IsNullOrWhiteSpace(txtProductEnglishName.Text))
        {
            errors.Add("必要欄位尚未完成(產品ID/中文名稱/英文名稱)");
        }

        return errors;
    }
    protected void btnDeleteData_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "delete from Product" +
                                    " where ID = @PID" +
                                    " delete from ProductCertification" +
                                    " where ID = @PID" +
                                    " delete from ProductColor" +
                                    " where ID = @PID" +
                                    " delete from ProductMaterial" +
                                    " where ID = @PID" +
                                    " delete from ProductMultilingualContent" +
                                    " where ID = @PID" +
                                    " delete from ProductStructuredDataSchema" +
                                    " where ID = @PID" +
                                    " delete from ProductTechnicalSpec" +
                                    " where ID = @PID" +
                                    " delete from ProductApplication" +
                                    " where ProductID = @PID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PID", lblProductID.Text);
            cmd.ExecuteNonQuery();
        }

        AppendSystemMessage(lblProductID.Text + "已刪除", "red");
        ResetForm();
        DeleteButton(false);
    }

    protected void btnShowSpecList_Click(object sender, EventArgs e)
    {
        GenerateAllSpecList();
        UpdateAllSpecList();
        ShowModal("SpecListModal");
    }

    protected void btnAddSpec_Click(object sender, EventArgs e)
    {
        List<Tuple<string, string>> specList = new List<Tuple<string, string>>();
        foreach (int i in lbxAllTechnicalSpecList.GetSelectedIndices())
        {
            specList.Add(new Tuple<string, string>(lbxAllTechnicalSpecList.Items[i].Value, lbxAllTechnicalSpecList.Items[i].Text));
        }
        GenerateProductSpecControl(specList);
        CloseModal("SpecListModal");
        lbxAllTechnicalSpecList.ClearSelection();
    }

    protected void RemoveItemSpecFromList(object sender, EventArgs e)
    {
        HtmlAnchor btn = (HtmlAnchor)sender;
        string ID = btn.ID.Replace("btn", "");
        AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        trigger.ControlID = btn.ClientID;
        upProductTechnicalSpec.Triggers.Remove(trigger);
        divSpecList.Controls.Remove(divSpecList.FindControl(ID));
    }

    [WebMethod]
    public static string GetProductID(string ID)
    {
        string webConnectionString = ConfigurationManager.ConnectionStrings["WebsiteConnectionString"].ConnectionString;

        DataTable dt = new DataTable();
        //List<string> ProductIDList = new List<string>();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select top 10 [ID]" +
                " from Product" +
                " where [ID] like @SearchProductID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SearchProductID", "%" + ID + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    ProductIDList.Add(dr["ID"].ToString());
            //}

            //var jsonsetting = new JsonSerializerSettings();
            //jsonsetting.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            return JsonConvert.SerializeObject(dt);
        }
    }

    protected void btnCopyData_Click(object sender, EventArgs e)
    {
        ClearMessages();
        if (string.IsNullOrWhiteSpace(lblProductID.Text))
        {
            AppendSystemMessage("產品ID不可為空白", "red");
        }
        else
        {
            ShowModal("CopyDataModal");
        }
    }

    protected bool ifProductExists(string PID)
    {
        bool exists = false;

        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select [ID]" +
                " from Product" +
                " where [ID]=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", PID.ToLower());
            exists = cmd.ExecuteScalar() == null ? false : true;
        }

        return exists;
    }

    protected void btnCopyToProduct_Click(object sender, EventArgs e)
    {
        string PID = txtCopyToProductID.Text.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(PID))
        {
            AppendSystemMessage("複製的產品ID不可為空白", "red");
        }
        else if (lblProductID.Text == PID)
        {
            AppendSystemMessage("產品ID一樣", "red");
        }
        else
        {
            if (ifProductExists(PID))
            {
                AppendSystemMessage("產品已存在，上傳後現在顯示的資料將會覆蓋舊資料", "green");
            }
            else
            {
                AppendSystemMessage("產品不存在，可上傳新增", "green");
            }
            lblProductID.Text = PID;
        }

        CloseModal("CopyDataModal");
    }

    protected void txtProductIDSearch_TextChanged(object sender, EventArgs e)
    {
        FetchProductList(txtProductIDSearch.Text.Trim());
        upSearchResult.Update();
    }

    protected void FetchProductList(string parameter)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select p.ID [ID]" +
                " , pmc.Name [Name]" +
                " ,pCat.zh [Category]" +
                " from Product p" +
                " left join ProductCategory pCat on p.Category = pCat.ID" +
                " left join ProductMultilingualContent pmc on p.ID = pmc.ID and pmc.ContentLanguage = 'zh'" +
                " where p.ID like '%' + @parameter + '%'" +
                " or pmc.Name like '%' + @parameter + '%'" +
                " or pCat.zh like '%' + @parameter + '%'" +
                " order by p.ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@parameter", parameter);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        gvResult.DataSource = dt;
        gvResult.DataBind();

        if (dt.Rows.Count > 0)
        {
            btnAddProduct.Enabled = false;
        }
        else
        {
            btnAddProduct.Enabled = true;
        }
    }

    protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessages();
        string PID = ((Label)gvResult.SelectedRow.FindControl("lblID")).Text;
        FetchData(PID);
        upSetupForm.Update();
    }


    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        ClearMessages();
        FetchData(txtProductIDSearch.Text.Trim().ToLower());
    }

    protected void btnAddApplication_Click(object sender, EventArgs e)
    {
        int[] selectedIndices = lbxAllApplicationList.GetSelectedIndices();
        foreach (int i in selectedIndices)
        {
            if (!lbxProductApplicationList.Items.Contains(lbxAllApplicationList.Items[i]))
            {
                lbxProductApplicationList.Items.Add(lbxAllApplicationList.Items[i]);
            }
        }

        for (int i = lbxAllApplicationList.Items.Count - 1; i >= 0; i--)
        {
            if (selectedIndices.Contains(i))
            {
                lbxAllApplicationList.Items.RemoveAt(i);
            }
        }

        SortApplicationList();
        ClearApplicationSelection();
    }

    protected void btnRemoveApplication_Click(object sender, EventArgs e)
    {
        int[] selectedIndices = lbxProductApplicationList.GetSelectedIndices();
        foreach (int i in lbxProductApplicationList.GetSelectedIndices())
        {
            if (!lbxAllApplicationList.Items.Contains(lbxProductApplicationList.Items[i]))
            {
                lbxAllApplicationList.Items.Add(lbxProductApplicationList.Items[i]);
            }
        }
        for (int i = lbxProductApplicationList.Items.Count - 1; i >= 0; i--)
        {
            if (selectedIndices.Contains(i))
            {
                lbxProductApplicationList.Items.RemoveAt(i);
            }
        }

        SortApplicationList();
        ClearApplicationSelection();
    }
}

