using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_productSetupAddCategory : System.Web.UI.Page
{
    string webConnectionString = ConfigurationManager.ConnectionStrings["AdminWebsiteConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCategory.Items.Add(new ListItem("顏色", "ProductColor"));
            ddlCategory.Items.Add(new ListItem("材料", "ProductMaterial"));
            ddlCategory.Items.Add(new ListItem("認證", "ProductCertification"));
            ddlCategory.Items.Add(new ListItem("規格", "ProductTechnicalSpec"));
        }
    }

    protected void btnFetchData_Click(object sender, EventArgs e)
    {
        ResetForm();
        FetchData(txtIDSearch.Text.Trim(), ddlCategory.SelectedValue);
    }

    protected void FetchData(string ID, string Category)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "select pt.[ID]" +
                " , pt.Category [Category]" +
                " , pt.zh [zh]" +
                " , pt.en [en]" +
                " from INFORMATION_SCHEMA.COLUMNS col" +
                " left join ProductTranslation pt on col.COLUMN_NAME = pt.ID" +
                " where col.TABLE_NAME = @tableName" +
                " and pt.Category = @tableName" +
                " and col.COLUMN_NAME <> 'ID'" +
                " and col.COLUMN_NAME=@ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tableName", Category);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        if (dt.Rows.Count > 0)
        {
            lblID.Text = dt.Rows[0]["ID"].ToString();
            lblCategory.Text = dt.Rows[0]["Category"].ToString();
            txtChineseName.Text = dt.Rows[0]["zh"].ToString();
            txtEnglishName.Text = dt.Rows[0]["en"].ToString();

            AppendSystemMessage("此ID已存在，可進行編輯", "green");
        }
        else
        {
            lblID.Text = txtIDSearch.Text.Trim();
            lblCategory.Text = ddlCategory.SelectedValue;

            AppendSystemMessage("此ID不存在，可新增", "green");
        }
    }

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

    protected void ClearMessages()
    {
        foreach (LiteralControl span in divSystemMessages.Controls.OfType<LiteralControl>())
        {
            divSystemMessages.Controls.Remove(span);
        }
    }

    protected void ResetForm()
    {
        lblID.Text = string.Empty;
        lblCategory.Text = string.Empty;
        txtChineseName.Text = string.Empty;
        txtEnglishName.Text = string.Empty;
        ClearMessages();
    }

    protected void btnClearData_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    protected void btnUploadData_Click(object sender, EventArgs e)
    {
        ClearMessages();
        if (string.IsNullOrWhiteSpace(lblID.Text)
            || string.IsNullOrWhiteSpace(lblCategory.Text)
            || string.IsNullOrWhiteSpace(txtChineseName.Text.Trim())
            || string.IsNullOrWhiteSpace(txtEnglishName.Text.Trim()))
        {
            AppendSystemMessage("資料不完整，請檢察", "red");
        }
        else
        {
            UploadData();

            AppendSystemMessage(lblCategory.Text + ": " + lblID.Text + " 上傳完成", "green");
        }
    }

    protected void UploadData()
    {
        string ID = lblID.Text;
        string table = lblCategory.Text;
        string chineseName = txtChineseName.Text.Trim();
        string englishName = txtEnglishName.Text.Trim();
        string column_type = "bit";
        if (table == "ProductTechnicalSpec")
        {
            column_type = "nvarchar(255)";
        }

        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "update ProductTranslation" +
                " set [zh] = @ChineseName" +
                ", en = @EnglishName" +
                " where[ID] = @ID" +
                " and Category = @table" +
                " if @@ROWCOUNT = 0" +
                " begin" +
                " insert into ProductTranslation([ID],[Category],[zh],[en])" +
                " values(@ID, @table, @ChineseName, @EnglishName)" +
                " alter table " + table +
                " add " + ID + " " + column_type +
                " end";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@table", table);
            cmd.Parameters.AddWithValue("@ChineseName", chineseName);
            cmd.Parameters.AddWithValue("@EnglishName", englishName);
            cmd.ExecuteNonQuery();
        }
    }

    protected void btnDeleteData_Click(object sender, EventArgs e)
    {
        string ID = lblID.Text;
        string category = lblCategory.Text;
        using (SqlConnection conn = new SqlConnection(webConnectionString))
        {
            conn.Open();
            string query = "delete from ProductTranslation" +
                " where ID=@ID" +
                " and Category=@Category" +
                " if exists(select 1" +
                " from INFORMATION_SCHEMA.COLUMNS" +
                " where TABLE_NAME=@Category" +
                " and COLUMN_NAME=@ID" +
                " and TABLE_SCHEMA='dbo')" +
                " Begin" +
                " alter table " + category +
                " drop column " + ID +
                " end";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.ExecuteNonQuery();
        }
        AppendSystemMessage(lblCategory.Text + ": " + lblID.Text + " 刪除完成", "red");
        ResetForm();
    }
}