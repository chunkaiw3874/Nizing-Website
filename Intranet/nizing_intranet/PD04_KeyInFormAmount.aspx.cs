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
using System.Web.UI.WebControls;

public partial class nizing_intranet_PD04_KeyInFormAmount : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Attributes.Add("readonly", "readonly");
            txtEndDate.Attributes.Add("readonly", "readonly");

            for (int i = DateTime.Now.Year; i > 2013; i--)
            {
                ddlSearchYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                ddlSearchMonth.Items.Add(new ListItem(i.ToString("D2"), i.ToString("D2")));
            }

            ddlSearchYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlSearchMonth.SelectedValue = DateTime.Now.Month.ToString();
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        if (gvResult.Rows.Count > 0)
        {
            Export_Excel();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string[] queryDateRange = new string[2];
        queryDateRange = GetQueryRange();
        string query = "";
        DataTable dt = new DataTable();

        lblQueryRange.Text = DateTime.ParseExact(queryDateRange[0], "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd")
            + '~'
            + DateTime.ParseExact(queryDateRange[1], "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            query = ";with keyInTable" +
                " as" +
                " (" +
                " select '採購單' '單別'" +
                " ,tc.CREATOR '打單人員'" +
                " ,COUNT(*) '單數'" +
                " from PURTC tc" +
                " where tc.TC024 between @start and @end" +
                " group by tc.CREATOR" +
                " union" +
                " select '進貨單'" +
                " ,tg.CREATOR" +
                " ,COUNT(*)" +
                " from PURTG tg" +
                " where tg.TG014 between @start and @end" +
                " group by tg.CREATOR" +
                " )" +
                " select ROW_NUMBER() over(order by coalesce(採購單, 0) + coalesce(進貨單, 0) desc) '#'" +
                " ,ma.MA002 '人員姓名'" +
                " ,coalesce(採購單, 0) '採購單'" +
                " ,coalesce(進貨單, 0) '進貨單'" +
                " ,coalesce(採購單, 0) + coalesce(進貨單, 0) '總數'" +
                " from" +
                " (" +
                " select *" +
                " from keyInTable" +
                " ) src" +
                " pivot" +
                " (sum(單數) for 單別 in ([採購單],[進貨單])) pvt" +
                " left join SMARTDSCSYS.dbo.DSCMA ma on ma.MA001 = pvt.打單人員";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", queryDateRange[0]);
            cmd.Parameters.AddWithValue("@end", queryDateRange[1]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        gvResult.DataSource = dt;
        gvResult.DataBind();
    }

    protected string[] GetQueryRange()
    {
        string[] r = new string[2];
        if (rdoYear.Checked)
        {
            r[0] = ddlSearchYear.SelectedValue.ToString() + "0101";
            r[1] = ddlSearchYear.SelectedValue.ToString() + "1231";
        }
        else if (rdoMonth.Checked)
        {
            r[0] = new DateTime(Convert.ToInt32(ddlSearchYear.SelectedValue)
                , Convert.ToInt32(ddlSearchMonth.SelectedValue)
                , 1).ToString("yyyyMMdd");
            r[1] = new DateTime(Convert.ToInt32(ddlSearchYear.SelectedValue)
                , Convert.ToInt32(ddlSearchMonth.SelectedValue)
                , DateTime.DaysInMonth(Convert.ToInt32(ddlSearchYear.SelectedValue)
                , Convert.ToInt32(ddlSearchMonth.SelectedValue))
                ).ToString("yyyyMMdd");
        }
        else if (rdoCustom.Checked)
        {
            r[0] = txtStartDate.Text;
            r[1] = txtEndDate.Text;
        }

        return r;
    }
    private void Export_Excel()
    {
        string filename = "打單數量報表" + txtStartDate.Text + "-" + txtEndDate.Text;

        string strfileext = ".xls";
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
        HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");

        //Get the HTML for the control.
        gvResult.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //用export_excel必須要有這個override
    }


    protected void gvResult_DataBound(object sender, EventArgs e)
    {
        decimal sumPurchaseForm = 0;
        decimal sumReceiveMaterialForm = 0;
        decimal sumTotal = 0;

        for (int i = 0; i < gvResult.Rows.Count; i++)
        {
            sumPurchaseForm += Convert.ToDecimal(((Label)gvResult.Rows[i].FindControl("lblPurchaseForm")).Text);
            sumReceiveMaterialForm += Convert.ToDecimal(((Label)gvResult.Rows[i].FindControl("lblReceiveMaterialForm")).Text);
            sumTotal += Convert.ToDecimal(((Label)gvResult.Rows[i].FindControl("lblTotal")).Text);
        }

        ((Label)gvResult.FooterRow.FindControl("lblPurchaseFormTotal")).Text = sumPurchaseForm.ToString();
        ((Label)gvResult.FooterRow.FindControl("lblReceiveMaterialFormTotal")).Text = sumReceiveMaterialForm.ToString();
        ((Label)gvResult.FooterRow.FindControl("lblAllTotal")).Text = sumTotal.ToString();
    }
}