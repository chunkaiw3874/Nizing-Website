using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class hr360_mobile_RewardAndPunishmentSlip : System.Web.UI.Page
{
    string nzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string erp2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string attachmentFilePath = "~/hr360/rewardAndPunishment/slipAttachment/";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDateCreated.Text = DateTime.Today.ToString("yyyyMMdd");
            GetSlipID();
            for (int i = DateTime.Today.Year + 1; i >= 2018; i--)
            {
                ddlEventYear.Items.Add(i.ToString());
            }
            ddlEventYear.SelectedValue = DateTime.Today.Year.ToString();
            using (SqlConnection conn = new SqlConnection(nzConnectionString))
            {
                conn.Open();
                string query = "select MV001 'ID'" +
                    " , case" +
                    " when MV022='' then MV002" +
                    " else MV002 + ' (已離職)'" +
                    " end as 'Name'" +
                    " from CMSMV" +
                    " where MV001<>'0000'" +
                    " and MV001<>'0098'" +
                    " and MV001 not like 'PT%' " +
                    " order by MV001";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ddlEmpID.Items.Add(new ListItem(row["ID"].ToString().Trim() + "-" + row["Name"].ToString(), row["ID"].ToString().Trim()));
                }
            }

            using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
            {
                conn.Open();
                string query = "select UID 'ID'" +
                    " ,Name 'Name'" +
                    " from HR360_RewardAndPenalty_EventCategory" +
                    " order by UID";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ddlEvent.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
                }
            }

            using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
            {
                conn.Open();
                string query = "select UID 'ID'" +
                    " ,Name 'Name'" +
                    " from HR360_RewardAndPenalty_RnPCategory" +
                    " where InUse=1" +
                    " order by UID";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    ddlRewardAndPunishmentCategory.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
                }
            }
            ListAttachment();
        }

        if (ViewState["AttachmentList"] != null)
        {
            GenerateAttachmentListControl((List<Tuple<string, string>>)ViewState["AttachmentList"]);
        }

        //fuAttachment.Enabled = ifRecordExist(lblRewardAndPunishmentSlipID.Text);

        if (fuAttachment.HasFile)
        {
            UploadAttachment();
            ListAttachment();
        }
    }
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        List<Tuple<string, string>> dynamicAttachmentListControls = new List<Tuple<string, string>>();
        foreach (HtmlGenericControl div in divAttachmentList.Controls.OfType<HtmlGenericControl>())
        {
            dynamicAttachmentListControls.Add(new Tuple<string, string>(div.ID, ((HtmlAnchor)div.FindControl("anchor" + div.ID)).InnerText));
        }
        ViewState["AttachmentList"] = dynamicAttachmentListControls;
    }

    protected bool ifRecordExist(string RID)
    {
        if (string.IsNullOrWhiteSpace(RID))
        {
            return false;
        }
        else
        {
            using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
            {
                conn.Open();
                string query = "select top 1 RecordID" +
                    " from HR360_RewardAndPenalty_Record" +
                    " where RecordID=@RID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RID", RID);
                return cmd.ExecuteScalar() == null ? false : true;
            }
        }
    }

    /*file tuple => <controlID, fileName>*/
    protected void GenerateAttachmentListControl(List<Tuple<string, string>> files)
    {
        string fileDirectory = Server.MapPath(attachmentFilePath + lblRewardAndPunishmentSlipID.Text + "/");
        foreach (Tuple<string, string> file in files)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.ID = file.Item1;
            div.Attributes.Add("class", "item");
            divAttachmentList.Controls.Add(div);

            HtmlAnchor btn = new HtmlAnchor();
            btn.ID = "b_t_n" + div.ID;
            btn.Attributes.Add("class", "btn btn-danger btn-sm");
            btn.InnerText = "移除";
            btn.ServerClick += new EventHandler(RemoveAttachment);
            div.Controls.Add(btn);

            HtmlAnchor aShowFile = new HtmlAnchor();
            aShowFile.ID = "anchor" + div.ID;
            aShowFile.Attributes.Add("class", "pl-2");
            aShowFile.HRef = "~/hr360/rewardAndPunishment/slipAttachment/" + lblRewardAndPunishmentSlipID.Text + "/" + file.Item2;
            aShowFile.Target = "_blank";
            aShowFile.InnerText = file.Item2;
            div.Controls.Add(aShowFile);

            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = btn.ClientID;
            trigger.EventName = "Click";
            //upUploadFile.Triggers.Add(trigger);
        }
    }

    protected void txtDateCreated_TextChanged(object sender, EventArgs e)
    {
        GetSlipID();
    }

    protected void GetSlipID()
    {
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "select coalesce(CONVERT(DECIMAL(12,0),MAX(RecordID))+1, @CreateDate + '001')" +
                " from HR360_RewardAndPenalty_Record" +
                " where RecordID like @CreateDate + '%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CreateDate", txtDateCreated.Text);
            Decimal slipID = Convert.ToDecimal(cmd.ExecuteScalar());
            lblRewardAndPunishmentSlipID.Text = slipID.ToString();
        }
    }

    protected void UploadAttachment()
    {
        string fileDirectory = Server.MapPath(attachmentFilePath + lblRewardAndPunishmentSlipID.Text + "/");
        Directory.CreateDirectory(fileDirectory);
        if (fuAttachment.HasFile)
        {
            if (fuAttachment.FileBytes.Length > 52428800)
            {
                AppendSystemMessage("檔案大於50MB，附件上傳失敗", "red");
            }
            else
            {
                foreach (HttpPostedFile file in fuAttachment.PostedFiles)
                {
                    file.SaveAs(fileDirectory + file.FileName);
                }
            }
        }
    }

    protected void ListAttachment()
    {
        string fileDirectory = Server.MapPath(attachmentFilePath + lblRewardAndPunishmentSlipID.Text + "/");
        //lbxAttachment.Items.Clear();
        divAttachmentList.Controls.Clear();
        DirectoryInfo dir = new DirectoryInfo(fileDirectory);
        if (dir.Exists)
        {
            int i = 0;
            List<Tuple<string, string>> files = new List<Tuple<string, string>>();
            foreach (var file in new DirectoryInfo(fileDirectory).GetFiles())
            {
                if (file.Name != "Thumbs.db")
                {
                    files.Add(new Tuple<string, string>(i.ToString(), file.Name));
                    i++;
                }
            }
            GenerateAttachmentListControl(files);
        }
    }


    protected void RemoveAttachment(object sender, EventArgs e)
    {
        HtmlAnchor btn = (HtmlAnchor)sender;
        HtmlGenericControl div = (HtmlGenericControl)btn.Parent;
        AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        trigger.ControlID = btn.ClientID;
        //upUploadFile.Triggers.Remove(trigger);

        string fileDirectory = Server.MapPath(attachmentFilePath + lblRewardAndPunishmentSlipID.Text + "/");
        string fileName = ((HtmlAnchor)div.FindControl("anchor" + div.ID)).InnerText;
        FileInfo file = new FileInfo(fileDirectory + fileName);
        if (file.Exists)
        {
            file.Delete();
        }

        ListAttachment();
    }

    protected bool IsAnyItemSelected(ListBox lbx)
    {
        return !(lbx.SelectedIndex == -1);
    }

    protected void btnClearData_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    protected void ResetForm()
    {
        ClearMessage();
        ckbVerified.Checked = false;
        txtDateCreated.Text = DateTime.Today.ToString("yyyyMMdd");
        GetSlipID();
        ddlEventYear.SelectedValue = DateTime.Today.Year.ToString();
        ddlEmpID.SelectedIndex = 0;
        ddlEvent.SelectedIndex = 0;
        txtEventContent.Text = string.Empty;
        ddlRewardAndPunishmentCategory.SelectedIndex = 0;
        txtRewardAndPunishmentCount.Text = string.Empty;
        txtMemo.Text = string.Empty;
        upUploadFile.Triggers.Clear();

        ListAttachment();
    }

    protected void txtFormSearch_TextChanged(object sender, EventArgs e)
    {
        FetchSlipList(txtFormSearch.Text.Trim());
        upSearchResult.Update();
    }

    protected void FetchSlipList(string s)
    {
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "select rec.RecordID 'RecordID'" +
                " ,mv.MV002 'EmpName'" +
                " ,rec.Year 'Year'" +
                " ,event.Name 'EventName'" +
                " ,rnp.Name 'RnPName'" +
                " ,rec.RNPCount 'count'" +
                " from HR360_RewardAndPenalty_Record rec" +
                " left join NZ.dbo.CMSMV mv on rec.EmpID = mv.MV001" +
                " left join HR360_RewardAndPenalty_EventCategory event on rec.EventID=event.UID" +
                " left join HR360_RewardAndPenalty_RnPCategory rnp on rec.RNPID=rnp.UID" +
                " where rec.RecordID like '%' + @parameter + '%'" +
                " or rec.EmpID like '%' + @parameter + '%'" +
                " or mv.MV002 like '%' + @parameter + '%'" +
                " or rec.EventContent like '%' + @parameter + '%'" +
                " or rec.Memo like '%' + @parameter + '%'" +
                " order by rec.RecordID desc";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@parameter", s);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvResult.DataSource = dt;
            gvResult.DataBind();
        }
    }

    protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        string PID = ((Label)gvResult.SelectedRow.FindControl("lblID")).Text;
        FetchData(PID);
        upForm.Update();
    }

    protected void FetchData(string PID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "select CreateDate" +
                " , RecordID" +
                " , EmpID" +
                " , [Year]" +
                " , EventID" +
                " , EventContent" +
                " , RNPID" +
                " , RNPCount" +
                " , Memo" +
                " , Verified" +
                " from HR360_RewardAndPenalty_Record" +
                " where RecordID = @recordID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@recordID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        if (dt.Rows.Count > 0)
        {
            txtDateCreated.Text = Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString()).ToString("yyyyMMdd");
            lblRewardAndPunishmentSlipID.Text = dt.Rows[0]["RecordID"].ToString();
            ddlEmpID.SelectedValue = dt.Rows[0]["EmpID"].ToString();
            ddlEventYear.SelectedValue = dt.Rows[0]["Year"].ToString();
            ddlEvent.SelectedValue = dt.Rows[0]["EventID"].ToString();
            txtEventContent.Text = dt.Rows[0]["EventContent"].ToString();
            ddlRewardAndPunishmentCategory.SelectedValue = dt.Rows[0]["RNPID"].ToString();
            txtRewardAndPunishmentCount.Text = dt.Rows[0]["RNPCount"].ToString();
            txtMemo.Text = dt.Rows[0]["Memo"].ToString();
            ckbVerified.Checked = (bool)dt.Rows[0]["Verified"];

            ListAttachment();
        }
    }

    protected void btnUploadData_Click(object sender, EventArgs e)
    {
        ClearMessage();
        UploadData(lblRewardAndPunishmentSlipID.Text.Trim());
        AppendSystemMessage("上傳成功", "green");
        ResetForm();
        FetchSlipList(txtFormSearch.Text.Trim());
        upSearchResult.Update();
    }

    protected void UploadData(string RID)
    {
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "update HR360_RewardAndPenalty_Record" +
                " set LastEditor=@user" +
                " ,LastEditDate=GetDate()" +
                " ,EmpID=@EmpID" +
                " ,[Year]=@Year" +
                " ,EventID=@EventID" +
                " ,EventContent=@EventContent" +
                " ,RNPID=@RNPID" +
                " ,RNPCount=@RNPCount" +
                " ,Memo=@Memo" +
                " ,Verified=@Verified" +
                " where RecordID=@RecordID" +
                " if @@ROWCOUNT=0" +
                " insert into HR360_RewardAndPenalty_Record([Creator],[CreateDate],[RecordID],[EmpID],[Year],[EventID],[EventContent],[RNPID],[RNPCount],[Memo],[Verified])" +
                " values (@user,GetDate(),@RecordID,@EmpID,@Year,@EventID,@EventContent,@RNPID,@RNPCount,@Memo,@Verified)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", HR360LoggedUser.HR360Id);
            cmd.Parameters.AddWithValue("@RecordID", RID);
            cmd.Parameters.AddWithValue("@Year", ddlEventYear.SelectedValue);
            cmd.Parameters.AddWithValue("@EmpID", ddlEmpID.SelectedValue);
            cmd.Parameters.AddWithValue("@EventID", ddlEvent.SelectedValue);
            cmd.Parameters.AddWithValue("@EventContent", txtEventContent.Text.Trim());
            cmd.Parameters.AddWithValue("@RNPID", ddlRewardAndPunishmentCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@RNPCount", txtRewardAndPunishmentCount.Text.Trim());
            cmd.Parameters.AddWithValue("@Memo", txtMemo.Text.Trim());
            cmd.Parameters.AddWithValue("@Verified", ckbVerified.Checked);
            cmd.ExecuteNonQuery();
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

    protected void ClearMessage()
    {
        divSystemMessages.Controls.Clear();
    }

    protected void btnDeleteData_Click(object sender, EventArgs e)
    {
        if (!ckbVerified.Checked)
        {
            DeleteData(lblRewardAndPunishmentSlipID.Text);
            string fileDirectory = Server.MapPath(attachmentFilePath + lblRewardAndPunishmentSlipID.Text + "/");
            foreach(FileInfo file in new DirectoryInfo(fileDirectory).GetFiles())
            {
                if(file.Name != "Thumbs.db")
                {
                    file.Delete();
                }
            }
            ResetForm();
            AppendSystemMessage(lblRewardAndPunishmentSlipID.Text + "已刪除", "red");
            FetchSlipList(txtFormSearch.Text.Trim());
            upSearchResult.Update();
        }
        else
        {
            ClearMessage();
            AppendSystemMessage("CC確認執行的單據不可刪除", "red");
        }
    }

    protected void DeleteData(string RID)
    {
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "delete from HR360_RewardAndPenalty_Record" +
                " where RecordID=@RID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@RID", RID);
            cmd.ExecuteNonQuery();
        }
    }
}