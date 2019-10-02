using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class oqs_quotation_list : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string Erp2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string OQSconnectionString = ConfigurationManager.ConnectionStrings["OQSConnectionString"].ConnectionString;

    List<string> adm = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {            
        //Setup Adm list
        adm.Add("chrissy");
        adm.Add("kevin");
        
        if (!IsPostBack)
        {


            //Set up "系列" 的下拉式選單
            DataTable dt = new DataTable();
            dt = GetCategoryList();
            ddlCategory.DataSource = dt;
            ddlCategory.DataValueField = "Value";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("全部", "all"));
            ddlCategory.Items.Insert(1, new ListItem("其他", "other"));

            //獲取最新成本價格
            //int subtractMonth = 0;
            DateTime lastUpdateTime = new DateTime();
            dt = new DataTable();
            try
            {
                //do
                //{
                //    subtractMonth--;
                //    dt = new DataTable();
                //    lastUpdateTime = DateTime.Today.AddMonths(subtractMonth);
                //    dt = GetQuotationList(lastUpdateTime);
                //} while (dt.Rows.Count == 0);
                lastUpdateTime = GetLastUpdateTime();
                dt = GetQuotationList(lastUpdateTime);

                BindGridviewToDatatable(gvQuotationList, dt);

                lblQuotationRefreshTime.Text = lastUpdateTime.ToString("yyyy/MM");//dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            //Format gvQuotationList based on user's access level
            string id = getId();
            Session["ID"] = id;
            FormatHeader(Session["ID"].ToString());
            
            //Retrieve Percentage Information from DB
            dt = new DataTable();
            dt = GetPercentageInformation();
            if (dt.Rows.Count > 0)
            {
                //Save Retrieved Information to Session variable as original record
                Session["QuotationRefreshTime"] = Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");
                Session["interimInternalCost"] = dt.Rows[0]["InternalCostPercentage"].ToString();
                Session["interimQuotationA"] = dt.Rows[0]["QuotationAPercentage"].ToString();
                Session["interimQuotationB"] = dt.Rows[0]["QuotationBPercentage"].ToString();
                Session["interimQuotationC"] = dt.Rows[0]["QuotationCPercentage"].ToString();
                Session["interimQuotationD"] = dt.Rows[0]["QuotationDPercentage"].ToString();
            }
            SaveInterimSessionValueToResetSessionValue();

            //Display Retrieved Value
            DisplayInterimSessionValueInHeaderInput();

            //Calculate content
            CalculateInternalCost();
            CalculateTotalCost();
            CalculateQuotation();            
        }
        else
        {
            
        }

        
    }


    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        //int subtractMonth = 0;
        //do
        //{
        //    subtractMonth--;
        //    dt = new DataTable();
        //    dt = GetQuotationList(DateTime.Today.AddMonths(subtractMonth));
        //} while (dt.Rows.Count == 0);
        dt = GetQuotationList(GetLastUpdateTime());

        BindGridviewToDatatable(gvQuotationList, dt);
        DisplayInterimSessionValueInHeaderInput();
        CalculateInternalCost();
        CalculateTotalCost();
        CalculateQuotation();
        FormatHeader(Session["ID"].ToString());
    }

    protected void FormatHeader(string id)
    {
        if (!adm.Contains(id.ToLower()))
        {
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).ReadOnly = true;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).CssClass = "readonly";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).ReadOnly = true;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).CssClass = "readonly";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).ReadOnly = true;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).CssClass = "readonly";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).ReadOnly = true;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).CssClass = "readonly";
            for (int i = 0; i < gvQuotationList.Columns.Count; i++)
            {
                if (gvQuotationList.Columns[i].HeaderText == "單位成本"
                    || gvQuotationList.Columns[i].HeaderText == "管銷費用"
                    || gvQuotationList.Columns[i].HeaderText == "總成本")
                {
                    gvQuotationList.Columns[i].Visible = false;
                }
            }
            btnSave.CssClass = "hidden";
            btnReset.CssClass = "hidden";
        }
        else
        {
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).ReadOnly = false;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).CssClass = "edit";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).ReadOnly = false;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).CssClass = "edit";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).ReadOnly = false;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).CssClass = "edit";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).ReadOnly = false;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).CssClass = "edit";
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).ReadOnly = false;
            ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).CssClass = "edit";

        }
    }
    /// <summary>
    /// Retrieve 系列 清單
    /// </summary>
    /// <returns></returns>
    protected DataTable GetCategoryList()
    {
        DataTable category = new DataTable();
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "SELECT DISTINCT MA.MA002 'Value',MA003 'Name'"
                        + " FROM INVMA MA"
                        + " LEFT JOIN INVMB MB ON MA.MA002=MB.MB007"
                        + " WHERE MB.MB029='OQS'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(category);
        }

        return category;
    }

    private DateTime GetLastUpdateTime()
    {
        DateTime time = new DateTime();

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "SELECT MA.MA019+'-'+MA.MA018+'-01'"
                        + " FROM CMSMA MA";
            SqlCommand cmd = new SqlCommand(query, conn);
            time = Convert.ToDateTime(cmd.ExecuteScalar().ToString());
        }

        return time;
    }

    /// <summary>
    /// Retrieve 牌價表 清單
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    protected DataTable GetQuotationList(DateTime date)
    {
        DataTable dt = new DataTable();
        string condition = "";
        if (ddlCategory.SelectedValue.ToLower() == "all")
        {
            condition = "";
        }
        else if (ddlCategory.SelectedValue == "other")
        {
            condition = " AND MB.MB007 = ''";
        }
        else
        {
            condition = " AND MB.MB007=@Category";
        }

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = "SELECT TOP 100 MA.MA003 'Category'"
                        + " ,MB.MB001 'ProductID'"
                        + " ,MB.MB002 'ProductName'"
                        + " ,COALESCE(MB.MB073, 0) 'PackageSize'"
                        + " ,COALESCE(LB.LB010, 0) 'UnitProductionCost'"
                        + " ,LB.LB002"
                        + " FROM INVMB MB"
                        + " LEFT JOIN INVMA MA ON MB.MB007=MA.MA002"
                        + " LEFT JOIN INVLB LB ON MB.MB001=LB.LB001"
                        + " WHERE MB.MB029='OQS'"
                        + " AND LB.LB002=@YearMonth"
                        + condition
                        + " ORDER BY Category,LB.LB010,MB.MB001";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@YearMonth", date.Year.ToString()+date.Month.ToString("D2"));
            cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        return dt;
    }
    /// <summary>
    /// Retrieve 管銷費用及報價百分比資訊
    /// </summary>
    protected DataTable GetPercentageInformation()
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(OQSconnectionString))
        {
            conn.Open();
            string query = "SELECT TOP 1 [CreateDate]"
                          + " ,[Creator]"
                          + " ,[InternalCostPercentage]"
                          + " ,[QuotationAPercentage]"
                          + " ,[QuotationBPercentage]"
                          + " ,[QuotationCPercentage]"
                          + " ,[QuotationDPercentage]"
                          + " FROM [MonthlyPercentageForQuotationList]"
                          + " ORDER BY [CreateDate] DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }

        return dt;
    }
    /// <summary>
    /// Binding GV and DT
    /// </summary>
    /// <param name="gv"></param>
    /// <param name="dt"></param>
    protected void BindGridviewToDatatable(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    /// <summary>
    /// Get User roles
    /// </summary>
    /// <returns></returns>
    protected List<string> getRoles()
    {
        List<string> role = new List<string>();
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        foreach (IdentityReference SIDRef in identity.Groups)
        {
            SecurityIdentifier sid = (SecurityIdentifier)SIDRef.Translate(typeof(SecurityIdentifier));
            NTAccount account = (NTAccount)SIDRef.Translate(typeof(NTAccount));
            role.Add(account.Value);
        }
        return role;
    }
    /// <summary>
    /// Get User ID
    /// </summary>
    /// <returns></returns>
    protected string getId()
    {
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        string[] name = identity.Name.Split('\\');
        return name[1];
    }

    /// <summary>
    /// Get the ID of the control that caused postback
    /// </summary>
    /// <returns></returns>
    private string getPostBackControlName()
    {
        Control control = null;
        //first we will check the "__EVENTTARGET" because if post back made by       the controls
        //which used "_doPostBack" function also available in Request.Form collection.
        string ctrlname = Page.Request.Params["__EVENTTARGET"];
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = Page.FindControl(ctrlname);
        }
        // if __EVENTTARGET is null, the control is a button type and we need to
        // iterate over the form collection to find it
        else
        {
            string ctrlStr = String.Empty;
            Control c = null;
            foreach (string ctl in Page.Request.Form)
            {
                //handle ImageButton they having an additional "quasi-property" in their Id which identifies
                //mouse x and y coordinates
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    c = Page.FindControl(ctrlStr);
                }
                else
                {
                    c = Page.FindControl(ctl);
                }
                if (c is System.Web.UI.WebControls.Button ||
                         c is System.Web.UI.WebControls.ImageButton)
                {
                    control = c;
                    break;
                }
            }
        }
        if (control == null)
        {
            return null;
        }
        else
        {
            return control.ID;
        }

    }
    /// <summary>
    /// Calculate Internal Cost based on the value in txtInternalCostPercent and lblUnitProductionCost
    /// </summary>
    protected void CalculateInternalCost()
    {
        decimal percent;
        decimal unitCost;
        if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).Text.Trim(), out percent))
        {
            foreach (GridViewRow row in gvQuotationList.Rows)
            {
                if (decimal.TryParse(((Label)row.FindControl("lblUnitProductionCost")).Text, out unitCost))
                {
                    ((Label)row.FindControl("lblInternalCost")).Text = (unitCost * percent / 100).ToString("0.00");
                }
                else
                {
                    ((Label)row.FindControl("lblInternalCost")).Text = "N/A";
                }
            }
            //hdnInternalCostPercent.Value = percent.ToString();
        }
        else
        {
            foreach (GridViewRow row in gvQuotationList.Rows)
            {
                ((Label)row.FindControl("lblInternalCost")).Text = "N/A";
            }
            //hdnInternalCostPercent.Value = "N/A";
        }

        
    }

    protected void CalculateTotalCost()
    {
        decimal unitCost;
        decimal internalCost;

        foreach (GridViewRow row in gvQuotationList.Rows)
        {
            if(decimal.TryParse(((Label)row.FindControl("lblUnitProductionCost")).Text, out unitCost)
                && decimal.TryParse(((Label)row.FindControl("lblInternalCost")).Text, out internalCost))
            {
                ((Label)row.FindControl("lblTotalCost")).Text = (unitCost + internalCost).ToString("0.00");
            }
            else
            {
                ((Label)row.FindControl("lblTotalCost")).Text = "N/A";
            }
        }

    }


    /// <summary>
    /// Verify ALL decimal inputs in header row
    /// </summary>
    /// <returns></returns>
    protected bool VerifyHeaderRowDecimalInputValidity()
    {
        decimal internalCost;
        decimal quoteA;
        decimal quoteB;
        decimal quoteC;
        decimal quoteD;
        if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).Text, out internalCost)
            && decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).Text, out quoteA)
            && decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).Text, out quoteB)
            && decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).Text, out quoteC)
            && decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).Text, out quoteD)
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// verify decimal inputs in controls that caused the postback upon changing input
    /// </summary>
    /// <param name="postbackControlID"></param>
    /// <returns></returns>
    protected bool VerifyHeaderRowDecimalInputValidity(string postbackControlID)
    {
        decimal output;
        Control ctrl = gvQuotationList.HeaderRow.FindControl(postbackControlID);
        return (Decimal.TryParse(((TextBox)ctrl).Text.Trim(), out output));
    }

    /// <summary>
    /// calculate ALL quotation column values
    /// </summary>
    protected void CalculateQuotation()
    {
        CalculateQuotation("txtInternalCostPercent");
        CalculateQuotation("txtQuotationAPercent");
        CalculateQuotation("txtQuotationBPercent");
        CalculateQuotation("txtQuotationCPercent");
        CalculateQuotation("txtQuotationDPercent");
    }
    /// <summary>
    /// calculate only values of the column whose header caused the postback
    /// </summary>
    /// <param name="postbackControlID"></param>
    protected void CalculateQuotation(string postbackControlID)
    {
        decimal totalCost;
        decimal percent;

        if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl(postbackControlID)).Text, out percent))
        {
            foreach (GridViewRow row in gvQuotationList.Rows)
            {
                if (decimal.TryParse(((Label)row.FindControl("lblTotalCost")).Text, out totalCost))
                {
                    switch (postbackControlID)
                    {
                        case "txtInternalCostPercent":
                            if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).Text, out percent))
                            {
                                ((Label)row.FindControl("lblQuotationA")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            }
                            else
                            {
                                ((Label)row.FindControl("lblQuotationA")).Text = "N/A";
                            }
                            if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).Text, out percent))
                            {
                                ((Label)row.FindControl("lblQuotationB")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            }
                            else
                            {
                                ((Label)row.FindControl("lblQuotationB")).Text = "N/A";
                            }
                            if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).Text, out percent))
                            {
                                ((Label)row.FindControl("lblQuotationC")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            }
                            else
                            {
                                ((Label)row.FindControl("lblQuotationC")).Text = "N/A";
                            }
                            if (decimal.TryParse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).Text, out percent))
                            {
                                ((Label)row.FindControl("lblQuotationD")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            }
                            else
                            {
                                ((Label)row.FindControl("lblQuotationD")).Text = "N/A";
                            }
                            break;
                        case "txtQuotationAPercent":
                            ((Label)row.FindControl("lblQuotationA")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            break;
                        case "txtQuotationBPercent":
                            ((Label)row.FindControl("lblQuotationB")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            break;
                        case "txtQuotationCPercent":
                            ((Label)row.FindControl("lblQuotationC")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            break;
                        case "txtQuotationDPercent":
                            ((Label)row.FindControl("lblQuotationD")).Text = (totalCost * (1 + (percent / 100))).ToString("0.00");
                            break;
                    }
                }
                else
                {
                    ((Label)row.FindControl("lblQuotationA")).Text = "N/A";
                    ((Label)row.FindControl("lblQuotationB")).Text = "N/A";
                    ((Label)row.FindControl("lblQuotationC")).Text = "N/A";
                    ((Label)row.FindControl("lblQuotationD")).Text = "N/A";
                }
            }
        }
        else
        {
            switch (postbackControlID)
            {
                case "txtInternalCostPercent":
                    foreach (GridViewRow row in gvQuotationList.Rows)
                    {
                        ((Label)row.FindControl("lblQuotationA")).Text = "N/A";
                        ((Label)row.FindControl("lblQuotationB")).Text = "N/A";
                        ((Label)row.FindControl("lblQuotationC")).Text = "N/A";
                        ((Label)row.FindControl("lblQuotationD")).Text = "N/A";
                    }
                    break;
                case "txtQuotationAPercent":
                    foreach (GridViewRow row in gvQuotationList.Rows)
                    {
                        ((Label)row.FindControl("lblQuotationA")).Text = "N/A";
                    }
                    break;
                case "txtQuotationBPercent":
                    foreach (GridViewRow row in gvQuotationList.Rows)
                    {
                        ((Label)row.FindControl("lblQuotationB")).Text = "N/A";
                    }
                    break;
                case "txtQuotationCPercent":
                    foreach (GridViewRow row in gvQuotationList.Rows)
                    {
                        ((Label)row.FindControl("lblQuotationC")).Text = "N/A";
                    }
                    break;
                case "txtQuotationDPercent":
                    foreach (GridViewRow row in gvQuotationList.Rows)
                    {
                        ((Label)row.FindControl("lblQuotationD")).Text = "N/A";
                    }
                    break;
            }
        }
    }
    protected void FormatInputToTwoDecimal(string postbackControlID)
    {
        if (VerifyHeaderRowDecimalInputValidity(postbackControlID))
        {
            Control ctrl = gvQuotationList.HeaderRow.FindControl(postbackControlID);
            ((TextBox)ctrl).Text = (Convert.ToDecimal(((TextBox)ctrl).Text)).ToString("0.00");
        }
        else
        {
            
            ShowAlert("數字格式輸入錯誤，請檢察");
        }
    }

    protected void DisplayResultWithInternalCostChange(object sender, EventArgs e)
    {
        if (VerifyHeaderRowDecimalInputValidity(getPostBackControlName()))
        {
            CalculateInternalCost();
            CalculateTotalCost();
            CalculateQuotation(getPostBackControlName());
            FormatInputToTwoDecimal(getPostBackControlName());
            SaveGvHeaderValueToInterimSession(getPostBackControlName());
        }
        else
        {
            ResetHeaderInput(getPostBackControlName());
            ShowAlert("數字輸入格式錯誤，請確認");
        }
    }
    protected void DisplayResultWithQuotationChange(object sender, EventArgs e)
    {
        if (VerifyHeaderRowDecimalInputValidity(getPostBackControlName()))
        {
            CalculateQuotation(getPostBackControlName());
            FormatInputToTwoDecimal(getPostBackControlName());
            SaveGvHeaderValueToInterimSession(getPostBackControlName());
        }
        else
        {
            ResetHeaderInput(getPostBackControlName());
            ShowAlert("數字輸入格式錯誤，請確認");
        }
    }

    protected void DisplayInterimSessionValueInHeaderInput()
    {
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).Text = Session["interimInternalCost"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).Text = Session["interimQuotationA"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).Text = Session["interimQuotationB"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).Text = Session["interimQuotationC"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).Text = Session["interimQuotationD"].ToString();
    }

    /// <summary>
    /// Should happen after every save, resetting the reset value to the value last saved
    /// </summary>
    protected void SaveInterimSessionValueToResetSessionValue()
    {
        Session["InternalCostPercentageResetValue"] = Session["interimInternalCost"];
        Session["QuotationAPercentageResetValue"] = Session["interimQuotationA"];
        Session["QuotationBPercentageResetValue"] = Session["interimQuotationB"];
        Session["QuotationCPercentageResetValue"] = Session["interimQuotationC"];
        Session["QuotationDPercentageResetValue"] = Session["interimQuotationD"];
    }
    /// <summary>
    /// Save all gv header value to interim session variable
    /// </summary>
    protected void SaveGvHeaderValueToInterimSession()
    {
        Session["interimInternalCost"] = ((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).Text.Trim();
        Session["interimQuotationA"] = ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).Text.Trim();
        Session["interimQuotationB"] = ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).Text.Trim();
        Session["interimQuotationC"] = ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).Text.Trim();
        Session["interimQuotationD"] = ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).Text.Trim();
    }
    /// <summary>
    /// saves value to interim session variable based on postbackcontrol
    /// </summary>
    /// <param name="postbackControlID"></param>
    protected void SaveGvHeaderValueToInterimSession(string postbackControlID)
    {
        Control ctrl = gvQuotationList.HeaderRow.FindControl(postbackControlID);
                
        switch (postbackControlID)
        {
            case "txtInternalCostPercent":
                Session["interimInternalCost"] = ((TextBox)ctrl).Text.Trim();
                break;
            case "txtQuotationAPercent":
                Session["interimQuotationA"] = ((TextBox)ctrl).Text.Trim();
                break;
            case "txtQuotationBPercent":
                Session["interimQuotationB"] = ((TextBox)ctrl).Text.Trim();
                break;
            case "txtQuotationCPercent":
                Session["interimQuotationC"] = ((TextBox)ctrl).Text.Trim();
                break;
            case "txtQuotationDPercent":
                Session["interimQuotationD"] = ((TextBox)ctrl).Text.Trim();
                break;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SavePercentageInformation();
    }
    protected void SavePercentageInformation()
    {
        //check input validity        
        if (VerifyHeaderRowDecimalInputValidity())
        {
            decimal internalCost = decimal.Parse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).Text.Trim());
            decimal quoteA = decimal.Parse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).Text.Trim());
            decimal quoteB = decimal.Parse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).Text.Trim());
            decimal quoteC = decimal.Parse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).Text.Trim());
            decimal quoteD = decimal.Parse(((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).Text.Trim());
            using (SqlConnection conn = new SqlConnection(OQSconnectionString))
            {
                conn.Open();
                string query = "Insert into [MonthlyPercentageForQuotationList]"
                            + " ("
                            + " [CreateDate]"
                            + " ,[Creator]"
                            + " ,[InternalCostPercentage]"
                            + " ,[QuotationAPercentage]"
                            + " ,[QuotationBPercentage]"
                            + " ,[QuotationCPercentage]"
                            + " ,[QuotationDPercentage]"
                            + " )"
                            + " values"
                            + " ("
                            + " GETDATE()"
                            + " ,@Creator"
                            + " ,@InternalCostPercentage"
                            + " ,@QuotationAPercentage"
                            + " ,@QuotationBPercentage"
                            + " ,@QuotationCPercentage"
                            + " ,@QuotationDPercentage"
                            + " )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Creator", Session["ID"].ToString());
                cmd.Parameters.AddWithValue("@InternalCostPercentage", internalCost);
                cmd.Parameters.AddWithValue("@QuotationAPercentage", quoteA);
                cmd.Parameters.AddWithValue("@QuotationBPercentage", quoteB);
                cmd.Parameters.AddWithValue("@QuotationCPercentage", quoteC);
                cmd.Parameters.AddWithValue("@QuotationDPercentage", quoteD);
                cmd.ExecuteNonQuery();
            }
            SaveInterimSessionValueToResetSessionValue();
            ShowAlert("資料已儲存");
        }
        else
        {
            ShowAlert("數字格式輸入錯誤，請檢察");
        }


    }

    protected void ShowAlert(string s)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + s + "');", true);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetHeaderInput();
        CalculateInternalCost();
        CalculateTotalCost();
        CalculateQuotation();
    }

    protected void ResetHeaderInput()
    {
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtInternalCostPercent")).Text = Session["InternalCostPercentageResetValue"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationAPercent")).Text = Session["QuotationAPercentageResetValue"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationBPercent")).Text = Session["QuotationBPercentageResetValue"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationCPercent")).Text = Session["QuotationCPercentageResetValue"].ToString();
        ((TextBox)gvQuotationList.HeaderRow.FindControl("txtQuotationDPercent")).Text = Session["QuotationDPercentageResetValue"].ToString();
    }

    protected void ResetHeaderInput(string postbackControlID)
    {
        Control ctrl = gvQuotationList.HeaderRow.FindControl(postbackControlID);
        switch (postbackControlID)
        {
            case "txtInternalCostPercent":
                ((TextBox)ctrl).Text = Session["InternalCostPercentageResetValue"].ToString();
                break;
            case "txtQuotationAPercent":
                ((TextBox)ctrl).Text = Session["QuotationAPercentageResetValue"].ToString();
                break;
            case "txtQuotationBPercent":
                ((TextBox)ctrl).Text = Session["QuotationBPercentageResetValue"].ToString();
                break;
            case "txtQuotationCPercent":
                ((TextBox)ctrl).Text = Session["QuotationCPercentageResetValue"].ToString();
                break;
            case "txtQuotationDPercent":
                ((TextBox)ctrl).Text = Session["QuotationDPercentageResetValue"].ToString();
                break;
        }
    }
}