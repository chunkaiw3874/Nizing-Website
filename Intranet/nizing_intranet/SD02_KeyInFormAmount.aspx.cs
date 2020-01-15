using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
public partial class nizing_intranet_SD02_KeyInFormAmount : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtStartDate.Attributes.Add("readonly", "readonly");
        txtEndDate.Attributes.Add("readonly", "readonly");
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
        string query = "";
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            query = ";with keyInTable" +
            " as" +
            " (" +
            " select '報價單' '單別'" +
            " ,ta.CREATOR '打單人員'" +
            " ,COUNT(*) '單數'" +
            " from COPTA ta" +
            " where ta.TA013 between @start and @end" +
            " group by ta.CREATOR" +
            " union" +
            " select '訂單'" +
            " ,tc.CREATOR" +
            " ,COUNT(*)" +
            " from COPTC tc" +
            " where tc.TC039 between @start and @end" +
            " group by tc.CREATOR" +
            " union" +
            " select '銷貨單'" +
            " ,tg.CREATOR" +
            " ,COUNT(*)" +
            " from COPTG tg" +
            " where tg.TG042 between @start and @end" +
            " group by tg.CREATOR" +
            " )" +
            " select ROW_NUMBER() over(order by coalesce(報價單, 0) + coalesce(訂單, 0) + coalesce(銷貨單, 0) desc) '#'" +
            " ,ma.MA002 '人員姓名'" +
            " ,coalesce(報價單, 0) '報價單'" +
            " ,coalesce(訂單, 0) '訂單'" +
            " ,coalesce(銷貨單, 0) '銷貨單'" +
            " ,coalesce(報價單, 0) + coalesce(訂單, 0) + coalesce(銷貨單, 0) '總數'" +
            " from" +
            " (" +
            " select *" +
            " from keyInTable" +
            " ) src" +
            " pivot" +
            " (sum(單數) for 單別 in ([報價單],[訂單],[銷貨單])) pvt" +
            " left join SMARTDSCSYS.dbo.DSCMA ma on ma.MA001 = pvt.打單人員";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", txtStartDate.Text);
            cmd.Parameters.AddWithValue("@end", txtEndDate.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        gvResult.DataSource = dt;
        gvResult.DataBind();
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

        //先把分頁關掉
        //gvResult.AllowPaging = false;
        //bindgv();

        //Get the HTML for the control.
        gvResult.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();

        //gvResult.AllowPaging = true;
        //bindgv();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //用export_excel必須要有這個override
    }
}