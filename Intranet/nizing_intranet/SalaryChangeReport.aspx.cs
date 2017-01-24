using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalaryChangeReport : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Label4.Text = cldBeginDate.SelectedDate.ToString("yyyyMMdd");
    }

    private string GetQuery()
    {
        string query = "";

        if (ddlPersonnel.SelectedItem.Value.ToString().ToUpper() == "ALL")
        {
            query = "SELECT ROUND(CAST(DATEDIFF(DAY, MV021, TD002) AS FLOAT)/365,2) 年資, MV001 員工代號, MV002 員工姓名, MJ003 職務名稱, TD002 異動日期, TD007 異動項目, TD004 項目異動前金額, TD005-TD004 異動金額, TD006 備註, TD005 項目異動後金額" +
                    " FROM PALTD TD" +
                        " LEFT JOIN CMSMV MV ON MV001 = TD001" +
                        " LEFT JOIN CMSMJ MJ ON MV006 = MJ001" +
                        " LEFT JOIN PALMB MB ON TD007 = MB002" +
                        " LEFT JOIN PALMF MF ON MV001 = MF001 AND MB001 = MF002" +
                    " WHERE MV022 LIKE N'' AND TD002 >= " + txtStartDate.Text + " AND TD002 <= " + txtEndDate.Text +
                    " GROUP BY MV021, MV031, MV001, MV002, MJ003, TD002, TD006, TD007, TD004, MF003, TD005, MV033, MF002, TD003, TD001" +
                    " ORDER BY MV001 ASC";
        }
        else
        {
            query = "SELECT ROUND(CAST(DATEDIFF(DAY, MV021, TD002) AS FLOAT)/365,2) 年資, MV001 員工代號, MV002 員工姓名, MJ003 職務名稱, TD002 異動日期, TD007 異動項目, TD004 項目異動前金額, TD005-TD004 異動金額, TD006 備註, TD005 項目異動後金額" +
                    " FROM PALTD TD" +
                        " LEFT JOIN CMSMV MV ON MV001 = TD001" +
                        " LEFT JOIN CMSMJ MJ ON MV006 = MJ001" +
                        " LEFT JOIN PALMB MB ON TD007 = MB002" +
                        " LEFT JOIN PALMF MF ON MV001 = MF001 AND MB001 = MF002" +
                    " WHERE MV022 LIKE N'' AND TD002 >= " + txtStartDate.Text + " AND TD002 <= " + txtEndDate.Text +
                        " AND MV001 = " + ddlPersonnel.SelectedItem.Value.ToString() +
                    " GROUP BY MV021, MV031, MV001, MV002, MJ003, TD002, TD006, TD007, TD004, MF003, TD005, MV033, MF002, TD003, TD001" +
                    " ORDER BY MV001 ASC";
        }
        return query;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtStartDate.Text.ToString()) || String.IsNullOrEmpty(txtEndDate.Text.ToString()))
        {
            lblDateError.Text = "請選擇起始及結束查詢日期";
        }
        else if (Convert.ToInt32(txtStartDate.Text) > Convert.ToInt32(txtEndDate.Text))
        {
            lblDateError.Text = "結束日期不可小於起始日期";
        }
        else
        {
            lblDateError.Text = "";
            lblRange.Text = "查詢期間: " + txtStartDate.Text + " ~ " + txtEndDate.Text;
            SqlSearch(GetQuery());
        }
    }

    private void SqlSearch(string query)
    {        
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grdReport.DataSource = ds;
            grdReport.DataBind();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        string excelFileName = "SalaryChangeReport" + txtStartDate.Text + "~" + txtEndDate.Text + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        grdReport.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
    }
}