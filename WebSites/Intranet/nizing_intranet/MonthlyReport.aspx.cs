using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MonthlyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlYear.SelectedValue = DateTime.Today.Year.ToString();
        ddlMonth.SelectedValue = DateTime.Today.AddMonths(-1).Month.ToString();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {

    }
}