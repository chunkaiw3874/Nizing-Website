using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionControlReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnExport.Enabled = false;
        if (!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlBeginYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                ddlEndYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlBeginYear.SelectedIndex = 0;
            ddlEndMonth.SelectedIndex = 0;
            ddlBeginMonth.SelectedIndex = Convert.ToInt16(DateTime.Today.Month) - 1;
            ddlEndMonth.SelectedIndex = Convert.ToInt16(DateTime.Today.Month) - 1;
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        if (grdReport.Rows.Count == 0)
        {
            btnExport.Enabled = false;
        }
        else
        {
            btnExport.Enabled = true;
            lblRange.Text += " 共<span style=\"color:#FF0000;\">" + Convert.ToString(grdReport.Rows.Count) + "</span>筆資料";
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        GenerateReport();
    }

    protected void GenerateReport()
    {
        try
        {
            if (ddlBeginMonth.SelectedItem.Text == "01")
            {
                Begin.Value = Convert.ToString(Convert.ToInt32(ddlBeginYear.SelectedItem.Value)-1) + ddlBeginMonth.SelectedItem.Value;
            }
            else
            {
                Begin.Value = ddlBeginYear.SelectedItem.Value + ddlBeginMonth.SelectedItem.Value;
            }

            End.Value = ddlEndYear.SelectedItem.Value + ddlEndMonth.SelectedItem.Value;
            
            if (ddlBeginYear.SelectedItem.Value == "0" || ddlBeginMonth.SelectedItem.Value == "0" || ddlEndYear.SelectedItem.Value == "0" || ddlEndMonth.SelectedItem.Value == "0")
            {
                Begin.Value = "0";
                End.Value = "0";
                lblStatus.CssClass = "error-message";
                lblStatus.Text = "請正確選擇起始與結束年月";
                lblRange.Text = "";
            }
            else if (Convert.ToInt32(End.Value) < Convert.ToInt32(Begin.Value))
            {
                Begin.Value = "0";
                End.Value = "0";
                lblStatus.CssClass = "error-message";
                lblStatus.Text = "起始時間不可大於結束時間";
                lblRange.Text = "";
            }
            else
            {
                lblStatus.Text = "";

                if (ddlBeginMonth.SelectedItem.Text == "01")
                {
                    lblRange.Text = Convert.ToString(Convert.ToInt32(ddlBeginYear.SelectedItem.Value) - 1)
                                + ddlBeginMonth.SelectedItem.Value + "至"
                                + ddlEndYear.SelectedItem.Value 
                                + ddlEndMonth.SelectedItem.Value;
                }
                else
                {
                    lblRange.Text = ddlBeginYear.SelectedItem.Value
                                    + ddlBeginMonth.SelectedItem.Value + "至"
                                    + ddlEndYear.SelectedItem.Value
                                    + ddlEndMonth.SelectedItem.Value;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Begin.Value == "0" || End.Value == "0")
            {
                lblStatus.CssClass = "error-message";
                lblStatus.Text = "請先產生報表才能執行匯出";
                lblRange.Text = "";
            }
            else
            {
                Response.ClearContent();
                Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
                string excelFileName = "ProductionControlReport" + Begin.Value + "-" + End.Value + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
                Response.ContentType = "application/excel";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                grdReport.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
        }
        catch (Exception ex)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
    }
}