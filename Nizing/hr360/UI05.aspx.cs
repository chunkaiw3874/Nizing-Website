using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class hr360_UI05 : System.Web.UI.Page
{
    string NZConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    //Setup basic info for the assessment 
    string year = "2016"; //edit annually

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!((masterPage_HR360_Master)this.Master).CheckAuthentication())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('連線已逾時，將會回到登入頁面');window.location='login.aspx'", true);
        }
        else
        {
            DateTime evalStart = new DateTime(2017, 1, 1, 19, 0, 0);
            DateTime evalEnd = new DateTime(2017, 1, 1, 17, 30, 0);
            DateTime selfEvalStart = new DateTime();
            DateTime selfEvalEnd = new DateTime();
            DateTime superEvalStart = new DateTime();
            DateTime superEvalEnd = new DateTime();
            divPlaceholder.Visible = false;
            using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            {
                conn.Open();
                string query = "SELECT EVAL_YEAR,EVAL_STARTTIME,EVAL_ENDTIME,EVAL_SELF_STARTTIME, EVAL_SELF_ENDTIME, EVAL_SUPERVISOR_STARTTIME, EVAL_SUPERVISOR_ENDTIME"
                            + " FROM HR360_ASSESSMENTTIME";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            year = dr.GetString(0);
                            evalStart = dr.GetDateTime(1);
                            evalEnd = dr.GetDateTime(2);
                            selfEvalStart = dr.GetDateTime(3);
                            selfEvalEnd = dr.GetDateTime(4);
                            superEvalStart = dr.GetDateTime(5);
                            superEvalEnd = dr.GetDateTime(6);
                        }
                    }
                }
            }
            if (DateTime.Now >= evalStart && DateTime.Now < evalEnd)
            {
                divAssessmentList.Visible = true;
                divAssessmentLookup.Visible = true;
                divBonusLookup.Visible = true;
                if (!IsPostBack)
                {
                    for (int i = 2016; i <= DateTime.Today.Year; i++)
                    {
                        ddlAssessmentYear.Items.Add(i.ToString());
                        ddlBonusYear.Items.Add(i.ToString());
                    }
                }
                //Create table for all three assessment type (自評、主管評、特評)
                DataTable dtEvalSelf = new DataTable();  //自評 table
                DataTable dtEvalBoss = new DataTable();  //主管評 table
                DataTable dtEvalSpecial = new DataTable();  //特評 table
                //Fill tables (未評核人員)
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    //fill 自評 list
                    SqlCommand cmd = new SqlCommand("SELECT ASSESSED_ID,B.MV002 'ASSESSED_NAME'"
                                                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                                + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                                                + " WHERE ASSESSOR_ID=@ID AND [YEAR]=@YEAR AND ASSESS_TYPE=@TYPE"
                                                + " AND ASSESSMENT_DONE<>N'1'"
                                                + " AND ACTIVE='1'"
                                                + " AND B.MV022=''"
                                                + " ORDER BY ASSESSED_ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TYPE", 1);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtEvalSelf.Load(dr);
                    }
                    //fill 主管評 list
                    cmd = new SqlCommand("SELECT ASSESSED_ID,B.MV002 'ASSESSED_NAME'"
                                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                        + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                                        + " WHERE ASSESSOR_ID=@ID AND [YEAR]=@YEAR AND ASSESS_TYPE=@TYPE"
                                        + " AND ASSESSMENT_DONE<>N'1'"
                                        + " AND ACTIVE='1'"
                                        + " AND B.MV022=''"
                                        + " ORDER BY ASSESSED_ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TYPE", 2);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtEvalBoss.Load(dr);
                    }
                    //fill 特評 list
                    cmd = new SqlCommand("SELECT ASSESSED_ID,B.MV002 'ASSESSED_NAME'"
                                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                        + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                                        + " WHERE ASSESSOR_ID=@ID AND [YEAR]=@YEAR AND ASSESS_TYPE=@TYPE"
                                        + " AND ASSESSMENT_DONE<>N'1'"
                                        + " AND ACTIVE='1'"
                                        + " AND B.MV022=''"
                                        + " ORDER BY ASSESSED_ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TYPE", 9);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtEvalSpecial.Load(dr);
                    }
                }
                int rowNumber = Math.Max(dtEvalBoss.Rows.Count, Math.Max(dtEvalSelf.Rows.Count, dtEvalSpecial.Rows.Count)); //number of rows for the table display
                for (int i = 0; i < rowNumber; i++)
                {
                    //寫入動態table
                    //insert row into table
                    HtmlGenericControl tr = new HtmlGenericControl();
                    tr.TagName = "tr";
                    tr.ID = "tr1_" + (i + 1).ToString();
                    tbFirstAssessmentBody.Controls.Add(tr);
                    //insert first column into row (自評)
                    HtmlGenericControl td = new HtmlGenericControl();
                    td.TagName = "td";
                    td.ID = tr.ID.ToString() + "_1";
                    td.Attributes["class"] = "text-center";
                    tr.Controls.Add(td);
                    //判斷dtEvalSelf裡面有沒有東西
                    if (dtEvalSelf != null && dtEvalSelf.Rows.Count > i)
                    {
                        if (DateTime.Now >= selfEvalStart && DateTime.Now < selfEvalEnd)
                        {
                            //insert control into 自評 column
                            LinkButton lb = new LinkButton();
                            lb.ID = dtEvalSelf.Rows[i][0].ToString();
                            lb.Text = dtEvalSelf.Rows[i][1].ToString();
                            lb.Click += new EventHandler(lb_Click);
                            td.Controls.Add(lb);
                        }
                        else
                        {
                            //insert non-clickable item
                            Label lbl = new Label();
                            lbl.ID = dtEvalSelf.Rows[i][0].ToString();
                            lbl.Text = dtEvalSelf.Rows[i][1].ToString();
                            td.Controls.Add(lbl);
                        }
                    }
                    //insert second column into row (主管評)
                    td = new HtmlGenericControl();
                    td.TagName = "td";
                    td.ID = tr.ID.ToString() + "_2";
                    td.Attributes["class"] = "text-center";
                    tr.Controls.Add(td);
                    //判斷dtEvalBoss裡面有沒有東西
                    if (dtEvalBoss != null && dtEvalBoss.Rows.Count > i)
                    {
                        if (DateTime.Now >= superEvalStart && DateTime.Now < superEvalEnd)
                        {
                            //insert control into 主管評 column
                            LinkButton lb = new LinkButton();
                            lb.ID = dtEvalBoss.Rows[i][0].ToString();
                            lb.Text = dtEvalBoss.Rows[i][1].ToString();
                            lb.Click += new EventHandler(lb_Click);
                            td.Controls.Add(lb);
                        }
                        else
                        {
                            Label lbl = new Label();
                            lbl.ID = dtEvalBoss.Rows[i][0].ToString();
                            lbl.Text = dtEvalBoss.Rows[i][1].ToString();
                            td.Controls.Add(lbl);
                        }
                    }
                    //insert first column into row (特評)
                    td = new HtmlGenericControl();
                    td.TagName = "td";
                    td.ID = tr.ID.ToString() + "_3";
                    td.Attributes["class"] = "text-center";
                    tr.Controls.Add(td);
                    //判斷dtEvalSpecial裡面有沒有東西
                    if (dtEvalSpecial != null && dtEvalSpecial.Rows.Count > i)
                    {
                        if (DateTime.Now >= superEvalStart && DateTime.Now < superEvalEnd)
                        {
                            //insert control into 特評 column
                            LinkButton lb = new LinkButton();
                            lb.ID = dtEvalSpecial.Rows[i][0].ToString();
                            lb.Text = dtEvalSpecial.Rows[i][1].ToString();
                            lb.Click += new EventHandler(lb_Click);
                            td.Controls.Add(lb);
                        }
                        else
                        {
                            Label lbl = new Label();
                            lbl.ID = dtEvalSpecial.Rows[i][0].ToString();
                            lbl.Text = dtEvalSpecial.Rows[i][1].ToString();
                            td.Controls.Add(lbl);
                        }
                    }
                }
                //Fill tables (已評核人員)
                dtEvalSelf = new DataTable();  //new 自評 table 
                dtEvalBoss = new DataTable();  //new 主管評 table
                dtEvalSpecial = new DataTable();  //new 特評 table
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    //fill 自評 list
                    SqlCommand cmd = new SqlCommand("SELECT ASSESSED_ID,B.MV002 'ASSESSED_NAME'"
                                                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                                + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                                                + " WHERE ASSESSOR_ID=@ID AND [YEAR]=@YEAR AND ASSESS_TYPE=@TYPE"
                                                + " AND ASSESSMENT_DONE=N'1'"
                                                + " AND ACTIVE='1'"
                                                + " AND B.MV022=''"
                                                + " ORDER BY ASSESSED_ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TYPE", 1);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtEvalSelf.Load(dr);
                    }
                    //fill 主管評 list
                    cmd = new SqlCommand("SELECT ASSESSED_ID,B.MV002 'ASSESSED_NAME'"
                                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                        + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                                        + " WHERE ASSESSOR_ID=@ID AND [YEAR]=@YEAR AND ASSESS_TYPE=@TYPE"
                                        + " AND ASSESSMENT_DONE=N'1'"
                                        + " AND ACTIVE='1'"
                                        + " AND B.MV022=''"
                                        + " ORDER BY ASSESSED_ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TYPE", 2);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtEvalBoss.Load(dr);
                    }
                    //fill 特評 list
                    cmd = new SqlCommand("SELECT ASSESSED_ID,B.MV002 'ASSESSED_NAME'"
                                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                                        + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                                        + " WHERE ASSESSOR_ID=@ID AND [YEAR]=@YEAR AND ASSESS_TYPE=@TYPE"
                                        + " AND ASSESSMENT_DONE=N'1'"
                                        + " AND ACTIVE='1'"
                                        + " AND B.MV022=''"
                                        + " ORDER BY ASSESSED_ID", conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    cmd.Parameters.AddWithValue("@YEAR", year);
                    cmd.Parameters.AddWithValue("@TYPE", 9);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dtEvalSpecial.Load(dr);
                    }
                }
                rowNumber = Math.Max(dtEvalBoss.Rows.Count, Math.Max(dtEvalSelf.Rows.Count, dtEvalSpecial.Rows.Count)); //number of rows for the table display
                for (int i = 0; i < rowNumber; i++)
                {
                    //寫入動態table
                    //insert row into table
                    HtmlGenericControl tr = new HtmlGenericControl();
                    tr.TagName = "tr";
                    tr.ID = "tr2_" + (i + 1).ToString();
                    tbAssessmentEditBody.Controls.Add(tr);
                    //insert first column (自評)
                    HtmlGenericControl td = new HtmlGenericControl();
                    td.TagName = "td";
                    td.ID = tr.ID.ToString() + "_1";
                    td.Attributes["class"] = "text-center";
                    tr.Controls.Add(td);
                    //判斷dtEvalSelf裡面有沒有東西
                    if (dtEvalSelf != null && dtEvalSelf.Rows.Count > i)
                    {
                        if (DateTime.Now >= selfEvalStart && DateTime.Now < selfEvalEnd)
                        {
                            //insert control into 自評 column
                            LinkButton lb = new LinkButton();
                            lb.ID = dtEvalSelf.Rows[i][0].ToString().Trim();
                            lb.Text = dtEvalSelf.Rows[i][1].ToString().Trim();
                            lb.Click += new EventHandler(lb_Click);
                            td.Controls.Add(lb);
                        }
                        else
                        {
                            Label lbl = new Label();
                            lbl.ID = dtEvalSelf.Rows[i][0].ToString();
                            lbl.Text = dtEvalSelf.Rows[i][1].ToString();
                            td.Controls.Add(lbl);
                        }
                    }
                    //insert second column (主管評)
                    td = new HtmlGenericControl();
                    td.TagName = "td";
                    td.ID = tr.ID.ToString() + "_2";
                    td.Attributes["class"] = "text-center";
                    tr.Controls.Add(td);
                    //判斷dtEvalBoss裡面有沒有東西
                    if (dtEvalBoss != null && dtEvalBoss.Rows.Count > i)
                    {
                        if (DateTime.Now >= superEvalStart && DateTime.Now < superEvalEnd)
                        {
                            //insert control into 主管評 column
                            LinkButton lb = new LinkButton();
                            lb.ID = dtEvalBoss.Rows[i][0].ToString().Trim();
                            lb.Text = dtEvalBoss.Rows[i][1].ToString().Trim();
                            lb.Click += new EventHandler(lb_Click);
                            td.Controls.Add(lb);
                        }
                        else
                        {
                            Label lbl = new Label();
                            lbl.ID = dtEvalBoss.Rows[i][0].ToString();
                            lbl.Text = dtEvalBoss.Rows[i][1].ToString();
                            td.Controls.Add(lbl);
                        }
                    }
                    //insert third column (特評)
                    td = new HtmlGenericControl();
                    td.TagName = "td";
                    td.ID = tr.ID.ToString() + "_3";
                    td.Attributes["class"] = "text-center";
                    tr.Controls.Add(td);
                    //判斷dtEvalSpecial裡面有沒有東西
                    if (dtEvalSpecial != null && dtEvalSpecial.Rows.Count > i)
                    {
                        if (DateTime.Now >= superEvalStart && DateTime.Now < superEvalEnd)
                        {
                            //insert control into 特評 column
                            LinkButton lb = new LinkButton();
                            lb.ID = dtEvalSpecial.Rows[i][0].ToString().Trim();
                            lb.Text = dtEvalSpecial.Rows[i][1].ToString().Trim();
                            lb.Click += new EventHandler(lb_Click);
                            td.Controls.Add(lb);
                        }
                        else
                        {
                            Label lbl = new Label();
                            lbl.ID = dtEvalSpecial.Rows[i][0].ToString();
                            lbl.Text = dtEvalSpecial.Rows[i][1].ToString();
                            td.Controls.Add(lbl);
                        }
                    }
                }
            }
            else
            {
                divAssessmentList.Visible = false;
                divAssessmentLookup.Visible = true;
                divBonusLookup.Visible = true;
                if (!IsPostBack)
                {
                    for (int i = 2016; i <= DateTime.Today.Year; i++)
                    {
                        ddlAssessmentYear.Items.Add(i.ToString());
                        ddlBonusYear.Items.Add(i.ToString());
                    }
                }
            }
            if (!IsPostBack)
            {
                //讀取有權限才能看的清單
                using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT *"
                                + " FROM HR360_ASSESSMENTPRIVILEDGE"
                                + " WHERE [ERP_ID]=@ID"
                                + " AND [VIEW]='1'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            divAdminViewList.Visible = true;
                            loadAdminEvalList();
                        }
                        else
                        {
                            divAdminViewList.Visible = false;
                        }
                    }
                }
            }
            //edit set lookup to non visible before evaluation is complete
            //divPlaceholder.Visible = true;
            //divAssessmentLookup.Visible = false;
            //divBonusLookup.Visible = false;
        }
    }
    /// <summary>
    /// 讀取只有特定人有權限看的評核表清單
    /// </summary>
    protected void loadAdminEvalList()
    {
        try
        {
            for (int i = 2016; i < DateTime.Today.Year; i++)
            {
                ddlViewYear.Items.Add(i.ToString());
                ddlViewYear2.Items.Add(i.ToString());
            }
            populateAdminViewList(ddlAdminViewList, ddlViewYear.SelectedItem.Text);
            populateAdminViewList(ddlAdminViewList2, ddlViewYear2.SelectedItem.Text);
            //using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
            //{
            //    conn.Open();
            //    string query = "SELECT DISTINCT A.ASSESSED_ID + ' ' + B.MV002,A.ASSESSED_ID"
            //                + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
            //                + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
            //                + " WHERE A.ASSESS_TYPE='1'"
            //                + " AND YEAR=@YEAR"
            //                + " ORDER BY A.ASSESSED_ID";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@YEAR", ddlViewYear2.SelectedItem.Text);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(dtViewList2);
            //}

            //for (int i = 0; i < dtViewList.Rows.Count; i++)
            //{
            //    ddlAdminViewList.Items.Add(new ListItem(dtViewList.Rows[i][0].ToString(), dtViewList.Rows[i][1].ToString()));
            //    ddlAdminViewList2.Items.Add(new ListItem(dtViewList2.Rows[i][0].ToString(), dtViewList2.Rows[i][1].ToString()));
            //}
        }
        catch
        {

        }
    }
    protected void lb_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        Session["eval_id"] = lb.ID;
        ScriptManager.RegisterStartupScript(this, GetType(), "open_form", "window.open('/hr360/evaluationForm.aspx');", true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["view_year"] = ddlViewYear.SelectedValue.ToString().Trim();
        Session["view_id"] = ddlAdminViewList.SelectedValue.ToString().Trim();
        ScriptManager.RegisterStartupScript(this, GetType(), "open_form", "window.open('/hr360/evaluationFormView.aspx');", true);
    }
    protected void btnSearch2_Click(object sender, EventArgs e)
    {
        Session["view_year"] = ddlViewYear2.SelectedValue.ToString().Trim();
        Session["view_id"] = ddlAdminViewList2.SelectedValue.ToString().Trim();
        ScriptManager.RegisterStartupScript(this, GetType(), "open_form", "window.open('/hr360/evaluationBonus.aspx');", true);
    }
    protected void btnAssessmentSearch_Click(object sender, EventArgs e)
    {
        Session["view_year"] = ddlAssessmentYear.SelectedValue.ToString().Trim();
        ScriptManager.RegisterStartupScript(this, GetType(), "open_form", "window.open('/hr360/evaluationFormViewUser.aspx');", true);
    }
    protected void btnBonusSearch_Click(object sender, EventArgs e)
    {
        Session["view_year"] = ddlBonusYear.SelectedValue.ToString().Trim();
        ScriptManager.RegisterStartupScript(this, GetType(), "open_form", "window.open('/hr360/evaluationBonusView.aspx');", true);
    }
    protected void populateAdminViewList(DropDownList ddlTarget, string year)
    {
        ddlTarget.Items.Clear();
        DataTable dtViewList = new DataTable();
        using (SqlConnection conn = new SqlConnection(ERP2ConnectionString))
        {
            conn.Open();
            string query = "SELECT DISTINCT A.ASSESSED_ID + ' ' + B.MV002,A.ASSESSED_ID"
                        + " FROM HR360_ASSESSMENTPERSONNEL_ASSIGNMENT_A A"
                        + " LEFT JOIN NZ.dbo.CMSMV B ON A.ASSESSED_ID=B.MV001"
                        + " WHERE A.ASSESS_TYPE='1'"
                        + " AND YEAR=@YEAR"
                        + " ORDER BY A.ASSESSED_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YEAR", year);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtViewList);
        }
        for (int i = 0; i < dtViewList.Rows.Count; i++)
        {
            ddlTarget.Items.Add(new ListItem(dtViewList.Rows[i][0].ToString(), dtViewList.Rows[i][1].ToString()));
        }

    }
    protected void ddlViewYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["ddlViewYearSelection"] = ddlViewYear.SelectedIndex;
        populateAdminViewList(ddlAdminViewList, ddlViewYear.SelectedItem.Text);
    }
    protected void ddlViewYear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["ddlViewYear2Selection"] = ddlViewYear2.SelectedIndex;
        populateAdminViewList(ddlAdminViewList2, ddlViewYear2.SelectedItem.Text);
    }
}