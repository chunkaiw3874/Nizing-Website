using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class QC_QC02 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    string StartDate;
    string EndDate;
    string ReportMethod;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                for (int i = -4; i < 1; i++)
                {
                    ddlYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                }
                ddlYear.SelectedValue = DateTime.Today.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Today.Month.ToString("D2");
                rdoMonth.Checked = true;                
            }          
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void R1_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoYear.Checked == true)
        {
            ddlMonth.Enabled = false;
            ddlMonth.Visible = false;
        }
        else
        {
            ddlMonth.Enabled = true;
            ddlMonth.Visible = true;
        }
    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (rdoYear.Checked)
            {
                ReportMethod = "Year";
            }
            else
            {
                ReportMethod = "Month";
            }
            string[] name = HttpContext.Current.User.Identity.Name.Split('\\');
            Response.Redirect("QC02_Report.aspx?Method=" + ReportMethod + "&Year=" + ddlYear.SelectedValue + "&Month=" + ddlMonth.SelectedValue + "&ID=" + name[1]);
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
}