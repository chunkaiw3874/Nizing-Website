using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class hr360_UI04 : System.Web.UI.Page
{
    string ERP2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdnIsPostBack.Value = "0";
            hdnIsDayOffAppVisible.Value = "0";
            DataTable dt = new DataTable();
            string query = "";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                query = "SELECT PALMC.MC001+' '+PALMC.MC002,PALMC.MC001"
                    + " FROM PALMC"
                    + " ORDER BY PALMC.MC001";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            ddlDayOffType.Items.Add(new ListItem("請選擇假別", "0"));
            ddlDayOffType.SelectedIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlDayOffType.Items.Add(new ListItem(dt.Rows[i][0].ToString().Trim(), dt.Rows[i][1].ToString().Trim()));
            }
        }
        else
        {
            hdnIsPostBack.Value = "1";
        }
    }
    protected void btnDayOffAdd_Click(object sender, ImageClickEventArgs e)
    {
        lblTest.Text = ((ImageButton)sender).ID + " clicked";
    }
    protected void ddlDayOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDayOffType.SelectedValue.ToString() == "0")
        {
            lblDayOffRemainType.Text = "";
            lblDayOffRemainAmount.Text = "";
            lblDayOffRemainUnit.Text = "";
        }
        else
        {
            DataTable dt = new DataTable();
            string query = "";
            string dayOffHourById = "";
            lblDayOffRemainType.Text = "本年度" + ddlDayOffType.SelectedItem.Text.Substring(3, ddlDayOffType.SelectedItem.Text.Length - 3) + "剩餘";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                if (Session["erp_id"].ToString().Trim() == "0010")
                {
                    dayOffHourById = "8.5";
                }
                else
                {
                    dayOffHourById = "8";
                }
                query = "SELECT '02' 'ID',CONVERT(DECIMAL(5,2),TK.TK005),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)),'小時'"
                    + " FROM PALTK TK"
                    + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='02'"
                    + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                    + " GROUP BY TK.TK005"
                    + " UNION"
                    + " SELECT '03' 'ID',CONVERT(DECIMAL(5,2),TK.TK003*" + dayOffHourById + "),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0)),'小時'"
                    + " FROM PALTK TK"
                    + " LEFT JOIN PALTL TL ON TK.TK001=TL.TL001 AND TK.TK002=TL.TL002 AND TL.TL004='03'"
                    + " WHERE TK.TK001=@ID AND TK.TK002=@YEAR"
                    + " GROUP BY TK.TK003"
                    + " UNION"
                    + " SELECT MC.MC001 'ID',CONVERT(DECIMAL(5,2),MC.MC007),CONVERT(DECIMAL(5,2),COALESCE(SUM(TL.TL006+TL.TL007),0))"
                    + " ,CASE MC.MC004"
                    + " WHEN '1' THEN '天'"
                    + " WHEN '2' THEN '小時'"
                    + " END"
                    + " FROM PALMC MC"
                    + " LEFT JOIN PALTL TL ON TL.TL001=@ID AND TL.TL002=@YEAR AND TL.TL004=MC.MC001"
                    + " WHERE MC.MC001<>'02' AND MC.MC001<>'03'"
                    + " GROUP BY MC.MC001,MC.MC007,MC.MC004";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", Session["erp_id"].ToString().Trim());
                cmd.Parameters.AddWithValue("@YEAR", DateTime.Now.Year.ToString().Trim());
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
            }
            DataRow[] row;
            if (dt.Rows.Count > 0)
            {
                row = dt.Select("ID=" + ddlDayOffType.SelectedValue.ToString());

                if (Convert.ToDouble(row[0][1]) > 0)
                {
                    lblDayOffRemainAmount.Text = (Convert.ToDouble(row[0][1]) - Convert.ToDouble(row[0][2])).ToString();
                    lblDayOffRemainUnit.Text = row[0][3].ToString();
                }
                else
                {
                    lblDayOffRemainType.Text = "";
                    lblDayOffRemainAmount.Text = "";
                    lblDayOffRemainUnit.Text = "";
                }
            }
        }
        
    }

    /// <summary>
    /// test only for different IDs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTestName_Click(object sender, EventArgs e)
    {
        Session["erp_id"] = txtTestName.Text.Trim();
    }
}