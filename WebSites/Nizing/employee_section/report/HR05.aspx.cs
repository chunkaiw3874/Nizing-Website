using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
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

public partial class nizing_intranet_HR05 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i > (2011 - Convert.ToInt16(DateTime.Today.Year)); i--)
            {
                ddlStartYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
                ddlEndYear.Items.Add(DateTime.Today.AddYears(i).Year.ToString());
            }
            ddlStartYear.SelectedIndex = 0;
            ddlEndYear.SelectedIndex = 0;
        }
    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT TI001,MV002,YR,ISNULL([01], 0) AS [01], ISNULL([02], 0) AS [02], ISNULL([03], 0) AS [03], ISNULL([04], 0) AS [04], ISNULL([05], 0) AS [05], ISNULL([06], 0) AS [06], ISNULL([07], 0) AS [07], ISNULL([08], 0) AS [08], ISNULL([09], 0) AS [09], ISNULL([10], 0) AS [10], ISNULL([11], 0) AS [11], ISNULL([12], 0)  AS [12],(ISNULL([01],0)+ISNULL([02],0)+ISNULL([03],0)+ISNULL([04],0)+ISNULL([05],0)+ISNULL([06],0)+ISNULL([07],0)+ISNULL([08],0)+ISNULL([09],0)+ISNULL([10],0)+ISNULL([11],0)+ISNULL([12],0)) TOTAL"
                                                    + " FROM"
                                                    + " ("
                                                    + " SELECT PALTI.TI001"
                                                    + " , CMSMV.MV002"
                                                    + " , SUBSTRING(PALTI.TI002,1,4) YR"
                                                    + " , SUBSTRING(PALTI.TI002,5,2) MN"
                                                    + " , (PALTI.TI007+PALTI.TI008+PALTI.TI009+PALTI.TI010+PALTI.TI011+PALTI.TI012+PALTI.TI013+PALTI.TI014+PALTI.TI058+PALTI.TI059+PALTI.TI062+PALTI.TI063+PALTI.TI064+PALTI.TI065+PALTI.TI066+PALTI.TI067) OT"
                                                    + " FROM PALTI"
                                                    + " LEFT JOIN CMSMV ON PALTI.TI001=CMSMV.MV001"
                                                    + " WHERE SUBSTRING(PALTI.TI002,1,4) BETWEEN @STARTYEAR AND @ENDYEAR"
                                                    + " AND PALTI.TI001 <> N'0000'"
                                                    + " AND PALTI.TI001 BETWEEN @STARTID AND @ENDID"
                                                    + " AND (CMSMV.MV022=N'' OR SUBSTRING(CMSMV.MV022,1,4)>=@STARTYEAR)"
                                                    + " ) AS PIVOTTABLE"
                                                    + " PIVOT"
                                                    + " ("
                                                    + " SUM(OT)"
                                                    + " FOR MN"
                                                    + " IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12])"
                                                    + " ) P", conn);
                cmdSelect.Parameters.AddWithValue("@STARTYEAR", ddlStartYear.SelectedValue);
                cmdSelect.Parameters.AddWithValue("@ENDYEAR", ddlEndYear.SelectedValue);
                cmdSelect.Parameters.AddWithValue("@STARTID", txtStartPeronnel.Text.Trim());
                cmdSelect.Parameters.AddWithValue("@ENDID", txtEndPersonnel.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grdReport.DataSource = dt;
                grdReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
    protected void grdReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double jan = 0;
            double feb = 0;
            double mar = 0;
            double apr = 0;
            double may = 0;
            double june = 0;
            double july = 0;
            double aug = 0;
            double sep = 0;
            double oct = 0;
            double nov = 0;
            double dec = 0;
            int i = 12;
            if (!double.TryParse(((Label)e.Row.FindControl("lbl3")).Text, out jan))
            {
                jan = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl4")).Text, out feb))
            {
                feb = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl5")).Text, out mar))
            {
                mar = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl6")).Text, out apr))
            {
                apr = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl7")).Text, out may))
            {
                may = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl8")).Text, out june))
            {
                june = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl9")).Text, out july))
            {
                july = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl10")).Text, out aug))
            {
                aug = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl11")).Text, out sep))
            {
                sep = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl12")).Text, out oct))
            {
                oct = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl13")).Text, out nov))
            {
                nov = 0;
                i -= 1;
            }
            if (!double.TryParse(((Label)e.Row.FindControl("lbl14")).Text, out dec))
            {
                dec = 0;
                i -= 1;
            }

            ((Label)e.Row.FindControl("lbl15")).Text = Math.Round((jan + feb + mar + apr + may + june + july + aug + sep + oct + nov + dec), 2).ToString();
            ((Label)e.Row.FindControl("lbl16")).Text = Math.Round((Convert.ToDouble(((Label)e.Row.FindControl("lbl15")).Text) / i), 2).ToString();
        }
    }
}