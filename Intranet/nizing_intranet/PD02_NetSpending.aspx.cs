using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nizing_intranet_PD02_NetSpending : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for(int i=DateTime.Now.Year; i >= 2013; i--)
            {
                ddlSearchYear.Items.Add(i.ToString());
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string query = "";
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            query = ";with acceptTable" +
                " as" +
                " (" +
                " select TG005 'supplierId'" +
                " ,SUM(coalesce(TG031, 0)) 'acceptAmount'" +
                " from PURTG" +
                " where substring(TG014, 1, 4) = @year" +
                " and TG013 = 'Y'" +
                " group by TG005" +
                " )" +
                " ,rejectionTable" +
                " as" +
                " (" +
                " select TI004 'supplierId'" +
                " ,sum(coalesce(TI028, 0)) 'rejectionAmount'" +
                " from PURTI" +
                " where SUBSTRING(TI014, 1, 4) = @year" +
                " and TI013 = 'Y'" +
                " group by TI004" +
                " )" +
                " ,outsourceAcceptTable" +
                " as" +
                " (" +
                " select TH005 'supplierId'" +
                " ,sum(coalesce(TH031, 0)) 'oursouceAcceptAmount'" +
                " from MOCTH" +
                " where SUBSTRING(TH029, 1, 4) = @year" +
                " and TH023 = 'Y'" +
                " group by TH005" +
                " )" +
                " ,outsourceRejectionTable" +
                " as" +
                " (" +
                " select TK004 'supplierId'" +
                " ,sum(coalesce(TK030, 0)) 'outsourceRejectionAmount'" +
                " from MOCTK" +
                " where SUBSTRING(TK027, 1, 4) = @year" +
                " and TK021 = 'Y'" +
                " group by TK004" +
                " )" +
                " select ROW_NUMBER() over(order by(coalesce(at.acceptAmount, 0) - coalesce(rt.rejectionAmount, 0)) + (coalesce(oat.oursouceAcceptAmount, 0) - coalesce(ort.outsourceRejectionAmount, 0)) desc) 'rank'" +
                " ,ma.MA001 'supplierId'" +
                " ,ma.MA002 'supplierName'" +
                " ,@year 'yr'" +
                " ,convert(decimal(20, 2), (coalesce(at.acceptAmount, 0) - coalesce(rt.rejectionAmount, 0)) + (coalesce(oat.oursouceAcceptAmount, 0) - coalesce(ort.outsourceRejectionAmount, 0))) 'netSpending'" +
                " from PURMA ma" +
                " left" +
                " join acceptTable at on ma.MA001 = at.supplierId" +
                " left join rejectionTable rt on ma.MA001 = rt.supplierId" +
                " left join outsourceAcceptTable oat on ma.MA001 = oat.supplierId" +
                " left join outsourceRejectionTable ort on ma.MA001 = ort.supplierId" +
                " where (coalesce(at.acceptAmount, 0) - coalesce(rt.rejectionAmount, 0)) + (coalesce(oat.oursouceAcceptAmount, 0) - coalesce(ort.outsourceRejectionAmount, 0)) > 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@year", ddlSearchYear.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        gvResult.DataSource = dt;
        gvResult.DataBind();
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        if (gvResult.Rows.Count > 0)
        {
            Export_Excel();
        }
    }

    private void Export_Excel()
    {
        string filename = "廠商進貨金額表" + ddlSearchYear.SelectedItem;
        
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