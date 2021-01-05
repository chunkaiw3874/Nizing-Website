using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * 限制: 單據流水號:001-999 (一天最多999張)
 */
public partial class hr360_mobile_GoOutForm : System.Web.UI.Page
{
    string SunrizeConnectionString = ConfigurationManager.ConnectionStrings["SunrizeConnectionString"].ConnectionString;
    string NzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string defaultConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string company = Session["company"].ToString();
            if (company == "NIZING")
            {
                defaultConnectionString = NzConnectionString;
            }
            else
            {
                defaultConnectionString = SunrizeConnectionString;
            }
            lblUserName.Text = Session["name"].ToString();
            for (double i = 0.5; i <= 12; i = i + 0.5)
            {
                ddlReservationDuration.Items.Add(i.ToString("0.0"));
            }
            LoadReservationList(Session["erp_id"].ToString(), company);
            LoadInProgressList(Session["erp_id"].ToString(), company);
            //divInProgress.Visible = false;
        }
    }

    protected void btnAddReservation_Click(object sender, EventArgs e)
    {
        lblReservationFormTitle.Text = "新增預約單";
        txtEstimatedStartTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        hdnReservationId.Value = GetReservationId();
        ddlReservationDuration.SelectedIndex = 0;
        txtReservationDestination.Text = string.Empty;
        foreach (ListItem item in cblGoOutFor.Items)
        {
            item.Selected = false;
        }
        txtReservationMemo.Text = string.Empty;

        ShowModal("ReservationForm");
    }

    private string GetReservationId()
    {
        string uid;
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            string defaultUid = DateTime.Parse(txtEstimatedStartTime.Text).ToString("yyyyMMdd") + "001";
            conn.Open();
            string query = "select max(FormId)" +
                " from GoOutForm" +
                " where FormId >= @uid ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", defaultUid);
            uid = cmd.ExecuteScalar() == DBNull.Value ? defaultUid : (Convert.ToInt64(cmd.ExecuteScalar().ToString()) + 1).ToString();
        }
        return uid;
    }

    protected void btnSaveReservationForm_Click(object sender, EventArgs e)
    {
        if (!CheckReservationFormInput())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('送出失敗，請檢察單據內容');", true);
            ShowModal("ReservationForm");
        }
        else
        {
            SaveReservationForm();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('送出成功');", true);
        }
        LoadReservationList(Session["erp_id"].ToString(), Session["company"].ToString());
        LoadInProgressList(Session["erp_id"].ToString(), Session["company"].ToString());
    }

    private bool CheckReservationFormInput()
    {
        int errorCount = 0;
        if (string.IsNullOrWhiteSpace(txtEstimatedStartTime.Text.Trim()))
        {
            errorCount++;
        }

        if (errorCount > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ShowModal(string modalId)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#" + modalId + "').modal('show');");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "initModal", sb.ToString(), false);
    }

    private void SaveReservationForm()
    {
        //Reconstruct company and destination selections into desired format
        char[] delimiter = { ',', '，', '、' };
        string[] destinationArray = txtReservationDestination.Text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        string destination = "";
        for (int i = 0; i < destinationArray.Length; i++)
        {
            if (i == 0)
            {
                destination += destinationArray[0];
            }
            else
            {
                destination += "," + destinationArray[i];
            }
        }
        string company = "";
        for (int i = 0; i < cblGoOutFor.Items.Count; i++)
        {
            if (cblGoOutFor.Items[i].Selected)
            {
                if (string.IsNullOrEmpty(company))
                {
                    company = cblGoOutFor.Items[i].Value;
                }
                else
                {
                    company += "," + cblGoOutFor.Items[i].Value;
                }
            }
        }

        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "update GoOutForm" +
                " set EditorId=@userId" +
                " ,EditorCompany=@userCompany" +
                " ,EditTime=getdate()" +
                " ,EstimateStartTime=@estimateStartTime" +
                " ,EstimateTimeUsed=@estimateTimeUsed" +
                " ,Destination=@destination" +
                " ,ForWhichCompany=@forWhichCompany" +
                " ,Memo=@memo" +
                " where FormId=@formId" +
                " and UserId=@userId" +
                " and UserCompany=@userCompany" +
                " if @@ROWCOUNT=0" +
                " insert into GoOutForm(EditorId,EditorCompany,EditTime,FormId,UserId,UserCompany,EstimateStartTime,EstimateTimeUsed,Destination,ForWhichCompany,Memo,Status)" +
                " values (@userId,@userCompany,getdate(),@formId,@userId,@userCompany,@estimateStartTime,@estimateTimeUsed,@destination,@forWhichCompany,@memo,@status)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@formId", hdnReservationId.Value);
            cmd.Parameters.AddWithValue("@userId", Session["erp_id"].ToString());
            cmd.Parameters.AddWithValue("@userCompany", Session["company"].ToString());
            cmd.Parameters.AddWithValue("@estimateStartTime", txtEstimatedStartTime.Text);
            cmd.Parameters.AddWithValue("@estimateTimeUsed", ddlReservationDuration.Text);
            cmd.Parameters.AddWithValue("@destination", destination);
            cmd.Parameters.AddWithValue("@forWhichCompany", company);
            cmd.Parameters.AddWithValue("@memo", txtReservationMemo.Text.Trim());
            cmd.Parameters.AddWithValue("@status", 1);
            try
            {
                txtEstimatedStartTime.ReadOnly = false;
                cmd.ExecuteNonQuery();
                txtEstimatedStartTime.ReadOnly = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //ID 重複錯誤
                {
                    cmd.Parameters.RemoveAt("@formId");
                    cmd.Parameters.AddWithValue("@formId", GetReservationId());
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

    protected void btnCancelReservation_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
        ((GridView)row.NamingContainer).SelectedIndex = row.RowIndex;

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('reservation cancelled');", true);
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();

            string query = "update GoOutForm" +
                " set Status=@status" +
                " where FormId=@formId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@formId", ((Label)gvReservationList.SelectedRow.FindControl("lblScheduleFormId")).Text);
            cmd.Parameters.AddWithValue("@status", 99);

            cmd.ExecuteNonQuery();
        }

        LoadReservationList(Session["erp_id"].ToString(), Session["company"].ToString());
    }

    protected void btnEditReservation_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
        GridView gv = (GridView)row.NamingContainer;
        gv.SelectedIndex = row.RowIndex;

        lblReservationFormTitle.Text = "更新預約單";
        hdnReservationId.Value = ((Label)gv.SelectedRow.FindControl("lblScheduleFormId")).Text;
        txtEstimatedStartTime.Text = (DateTime.Parse(((HiddenField)gv.SelectedRow.FindControl("hdnScheduledStartTime")).Value)).ToString("yyyy/MM/dd HH:mm");
        ddlReservationDuration.SelectedValue = ((Label)gv.SelectedRow.FindControl("lblScheduleTimeUsed")).Text;
        txtReservationDestination.Text = ((Label)gv.SelectedRow.FindControl("lblScheduledDestination")).Text;
        txtReservationMemo.Text = ((TextBox)gv.SelectedRow.FindControl("txtScheduleMemo")).Text;

        string[] company = ((Label)gv.SelectedRow.FindControl("lblScheduleForWhichCompany")).Text.Split(',');

        foreach (ListItem item in cblGoOutFor.Items)
        {
            item.Selected = false;
            if (company.Contains(item.Value))
            {
                item.Selected = true;
            }
        }
        if (gv.ID == "gvReservationList")
        {

        }
        ShowModal("ReservationForm");
    }

    private void LoadReservationList(string userId, string company)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select form.*, sCode.Name 'StatusName'" +
                " from GoOutForm form" +
                " left join GoOutForm_StatusCode sCode on form.Status=sCode.Code" +
                " where form.UserId=@userId" +
                " and form.UserCompany=@userCompany" +
                " and form.Status<@status" +
                " order by Status desc" +
                " ,EstimateStartTime";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@userCompany", company);
            cmd.Parameters.AddWithValue("@status", 3);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            BindGridview(gvReservationList, dt);
        }
    }

    private void LoadReservationList()
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select form.FormId" +
                " ,form.UserId" +
                " ,coalesce(nzMV.MV002, szMV.MV002) 'UserName'" +
                " ,form.EstimateStartTime" +
                " ,form.EstimateTimeUsed" +
                " ,form.ActualStartTime" +
                " ,form.Destination" +
                " ,form.ForWhichCompany" +
                " ,form.Memo" +
                " ,form.[Status] 'StatusCode'" +
                " ,code.Name 'Status'" +
                " from GoOutForm form" +
                " left join GoOutForm_StatusCode code on form.[Status] = code.Code" +
                " left join SUNRIZE.dbo.CMSMV szMV on form.UserId = szMV.MV001 and form.UserCompany = 'SUNRIZE'" +
                " left join NZ.dbo.CMSMV nzMV on form.UserId = nzMV.MV001 and form.UserCompany = 'NIZING'" +
                " where form.Status<@status" +
                " order by form.Status desc" +
                " ,form.EstimateStartTime" +
                " ,form.UserId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", 3);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            BindGridview(gvActiveFormList, dt);
        }
    }

    private void LoadInProgressList(string userId, string company)
    {
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "select form.*, sCode.Name 'StatusName'" +
                " from GoOutForm form" +
                " left join GoOutForm_StatusCode sCode on form.Status=sCode.Code" +
                " where form.UserId=@userId" +
                " and form.UserCompany=@userCompany" +
                " and form.Status=@status" +
                " order by Status desc" +
                " ,EstimateStartTime";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@userCompany", company);
            cmd.Parameters.AddWithValue("@status", 2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            BindGridview(gvInProgressList, dt);
        }

        if (gvInProgressList.Rows.Count > 0)
        {
            divInProgress.Visible = true;
        }
        else
        {
            divInProgress.Visible = false;
        }
    }

    private void BindGridview(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void btnStartTrip_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
        GridView gv = (GridView)row.NamingContainer;
        gv.SelectedIndex = row.RowIndex;


        string formId = ((Label)gv.SelectedRow.FindControl("lblScheduleFormId")).Text;

        //update record: record actual start time and set status
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "update GoOutForm" +
                " set ActualStartTime=@actualStartTime" +
                " ,Status=@status" +
                " where FormId=@formId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@actualStartTime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.Parameters.AddWithValue("@formId", formId);
            cmd.ExecuteNonQuery();
        }
        LoadReservationList(Session["erp_id"].ToString(), Session["company"].ToString());
        LoadInProgressList(Session["erp_id"].ToString(), Session["company"].ToString());
    }

    protected void gvReservationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Change background color based on status
            if (((HiddenField)e.Row.FindControl("hdnScheduleStatusCode")).Value == "2")
            {
                e.Row.BackColor = Color.Aquamarine;
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.BorderColor = Color.Aquamarine;
                }
                ((LinkButton)e.Row.FindControl("btnCancelReservation")).Enabled = false;
                ((LinkButton)e.Row.FindControl("btnCancelReservation")).OnClientClick = null;
            }
            else
            {
                ((LinkButton)e.Row.FindControl("btnCancelReservation")).Enabled = true;
                ((LinkButton)e.Row.FindControl("btnCancelReservation")).OnClientClick = "javascript: return confirmChoice('確定取消預約單?');";
            }
        }
    }

    protected void gvReservationList_PreRender(object sender, EventArgs e)
    {
        if (gvReservationList.Rows.Count > 0)
        {
            if (((HiddenField)gvReservationList.Rows[0].FindControl("hdnScheduleStatusCode")).Value == "2")
            {
                foreach (GridViewRow row in gvReservationList.Rows)
                {
                    ((LinkButton)row.FindControl("btnStartTrip")).Enabled = false;
                    ((LinkButton)row.FindControl("btnStartTrip")).OnClientClick = null;
                }
            }
            else
            {
                foreach (GridViewRow row in gvReservationList.Rows)
                {
                    ((LinkButton)row.FindControl("btnStartTrip")).Enabled = true;
                    ((LinkButton)row.FindControl("btnStartTrip")).OnClientClick = "javascript: return confirmChoice('確定出發?');";
                }
            }
        }
    }

    protected void btnEndTrip_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
        GridView gv = (GridView)row.NamingContainer;
        gv.SelectedIndex = row.RowIndex;


        string formId = ((Label)gv.SelectedRow.FindControl("lblScheduleFormId")).Text;

        //update record: record actual end time and set status
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "update GoOutForm" +
                " set ActualEndTime=@actualEndTime" +
                " ,Status=@status" +
                " where FormId=@formId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@actualEndTime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@status", 3);
            cmd.Parameters.AddWithValue("@formId", formId);
            cmd.ExecuteNonQuery();
        }
        LoadReservationList(Session["erp_id"].ToString(), Session["company"].ToString());
        LoadInProgressList(Session["erp_id"].ToString(), Session["company"].ToString());
    }

    protected void tmrTripDuration_Tick(object sender, EventArgs e)
    {
        if (gvInProgressList.Rows.Count > 0)
        {
            foreach (GridViewRow row in gvInProgressList.Rows)
            {
                DateTime startTime = Convert.ToDateTime(((HiddenField)row.FindControl("hdnTripStartTime")).Value);
                TimeSpan span = DateTime.Now - startTime;
                ((Label)row.FindControl("lblTripDuration")).Text = span.ToString(@"hh\:mm\:ss");
            }
        }
    }

    protected void btnDisplayFormDetail_Click(object sender, EventArgs e)
    {
        int[] columnsToBeHidden = { 1 };
        ShowGridViewDetail(gvReservationList, columnsToBeHidden, true);
        btnDisplayFormDetail.Visible = false;
        btnHideFormDetail.Visible = true;
    }

    private void ShowGridViewDetail(GridView gv, int[] columnIndex, bool show)
    {
        if (show)
        {
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (columnIndex.Contains(i))
                {
                    gv.Columns[i].Visible = false;
                }
                else
                {
                    gv.Columns[i].Visible = true;
                    gv.Columns[i].HeaderStyle.CssClass = "text-nowrap";
                    gv.Columns[i].ItemStyle.CssClass = "text-nowrap";
                }
            }
        }
        else
        {
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (columnIndex.Contains(i))
                {
                    gv.Columns[i].Visible = true;
                    gv.Columns[i].HeaderStyle.CssClass = "";
                    gv.Columns[i].ItemStyle.CssClass = "";
                }
                else
                {
                    gv.Columns[i].Visible = false;
                }
            }
        }
    }

    protected void btnHideFormDetail_Click(object sender, EventArgs e)
    {
        int[] columnsToBeVisible = { 0, 2, 3, 5, 8, 9, 10, 11 };
        ShowGridViewDetail(gvReservationList, columnsToBeVisible, false);
        btnDisplayFormDetail.Visible = true;
        btnHideFormDetail.Visible = false;
    }

    protected void btnViewAllActiveReservation_Click(object sender, EventArgs e)
    {
        LoadReservationList();
        ShowModal("ActiveFormList");
    }

    protected void gvActiveFormList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Change background color based on status
            if (((HiddenField)e.Row.FindControl("hdnActiveFormListStatusCode")).Value == "2")
            {
                e.Row.BackColor = Color.Aquamarine;
                foreach (TableCell cell in e.Row.Cells)
                {
                    cell.BorderColor = Color.Aquamarine;
                }
            }
        }
    }

    protected void btnActiveFormListDisplayFormDetail_Click(object sender, EventArgs e)
    {
        //int[] hiddenColumns = { };
        //ShowGridViewDetail(gvActiveFormList, hiddenColumns, true);
        //btnActiveFormListDisplayFormDetail.Visible = false;
        //btnActiveFormListHideFormDetail.Visible = true;
    }

    protected void btnActiveFormListHideFormDetail_Click(object sender, EventArgs e)
    {
        //int[] visibleColumns = { 1, 2, 3, 4, 5 };
        //ShowGridViewDetail(gvActiveFormList, visibleColumns, false);
        //btnActiveFormListDisplayFormDetail.Visible = true;
        //btnActiveFormListHideFormDetail.Visible = false;
    }

    protected void btnManualEndTrip_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
        GridView gv = (GridView)row.NamingContainer;
        gv.SelectedIndex = row.RowIndex;

        hdnManualEndTripFormId.Value = ((Label)gv.SelectedRow.FindControl("lblScheduleFormId")).Text;
        txtManualEndTripBegin.Text = ((HiddenField)gv.SelectedRow.FindControl("hdnScheduledStartTime")).Value;
        double timeUsed = Convert.ToDouble(((Label)gv.SelectedRow.FindControl("lblScheduleTimeUsed")).Text);
        txtManualEndTripEnd.Text = (DateTime.Parse(txtManualEndTripBegin.Text).AddHours(timeUsed)).ToString("yyyy/MM/dd HH:mm");

        ShowModal("ManualEndTripForm");
    }

    protected void btnManualEndTripSubmit_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtManualEndTripBegin.Text) > DateTime.Parse(txtManualEndTripEnd.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('回程時間不可小於出發時間');", true);
            ShowModal("ManualEndTripForm");
        }
        else
        {
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "update GoOutForm" +
                    " set EditorId=@userId" +
                    " ,EditorCompany=@userCompany" +
                    " ,EditTime=getdate()" +
                    " ,ActualStartTime=@actualStartTime" +
                    " ,ActualEndTime=@actualEndTime" +
                    " ,[Status]=@status" +
                    " where FormId=@formId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", Session["erp_id"].ToString());
                cmd.Parameters.AddWithValue("@userCompany", Session["company"].ToString());
                cmd.Parameters.AddWithValue("@actualStartTime", txtManualEndTripBegin.Text);
                cmd.Parameters.AddWithValue("@actualEndTime", txtManualEndTripEnd.Text);
                cmd.Parameters.AddWithValue("@status", 98);
                cmd.Parameters.AddWithValue("@formId", hdnManualEndTripFormId.Value);

                cmd.ExecuteNonQuery();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + hdnManualEndTripFormId.Value + "指定結案完成');", true);
            LoadInProgressList(Session["erp_id"].ToString(), Session["company"].ToString());
            LoadReservationList(Session["erp_id"].ToString(), Session["company"].ToString());

        }
    }
}
