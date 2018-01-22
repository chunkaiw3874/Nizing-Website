using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class hr360_mobile_main : System.Web.UI.Page
{
    //need to figure out how to call non-static method in static method for jquery to call static webmethod which contains non-static method

    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    public DataTable dtAnnouncementData = new DataTable();
    public int lastNewsRow = 0;
    public string jsonAnnouncementData;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNewsFromDB();
        //ConstructNewsDiv(dtAnnouncementData, lastNewsRow, 2);
        jsonAnnouncementData = ConvertDtToString(dtAnnouncementData);
        //txtTest.Text = jsonAnnouncementData;
    }
    private DataTable LoadNewsFromDB()
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = "SELECT ROW_NUMBER() OVER (ORDER BY [CREATE_TIME] DESC, [ID] DESC) [ROW]"
                        + " ,ANNOUNCE.[ID]"
                        + " ,ANNOUNCE.[CREATE_TIME]"
                        + " ,ANNOUNCE.[CREATOR]"
                        + " ,MVCREATOR.MV002 [CREATOR_NAME]"
                        + " ,ANNOUNCE.[LAST_EDIT_TIME]"
                        + " ,ANNOUNCE.[LAST_EDITOR]"
                        + " ,MVEDITOR.MV002 [EDITOR_NAME]"
                        + " ,ANNOUNCE.[BODY]"
                        + " FROM HR360_COMPANYANNOUNCEMENT ANNOUNCE"
                        + " LEFT JOIN NZ.dbo.CMSMV MVCREATOR ON ANNOUNCE.[CREATOR] = MVCREATOR.MV001"
                        + " LEFT JOIN NZ.dbo.CMSMV MVEDITOR ON ANNOUNCE.LAST_EDITOR = MVEDITOR.MV001"
                        + " ORDER BY [CREATE_TIME] DESC, [ID] DESC";            
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtAnnouncementData);
        }
        return dtAnnouncementData;
    }
    public string ConvertDtToString(DataTable dt)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        DateTime result;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                if (DateTime.TryParse(dr[col].ToString(), out result))
                {
                    row.Add(col.ColumnName, result.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    row.Add(col.ColumnName, dr[col]);
                }

            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }
    private void ConstructNewsDiv(DataTable dt, int lastRow, int numberOfItemsToLoad)
    {       
        
        for (int i = lastRow; i < lastRow + numberOfItemsToLoad; i++)
        {
            news_list.Controls.Add(new Literal() { Text = "<hr/>" });
            HtmlGenericControl div = new HtmlGenericControl();
            div.TagName = "div";
            div.ID = "news" + i;
            div.Attributes["class"] = "row";
            news_list.Controls.Add(div);
            HtmlGenericControl row = new HtmlGenericControl();
            row.TagName = "div";
            row.ID = div.ID + "_headingrow";
            row.Attributes["class"] = "col-sm-2";
            div.Controls.Add(row);
            Label heading = new Label();
            heading.ID = div.ID + "_heading";
            heading.CssClass = "form-ctonrol";
            heading.Text = ((DateTime)dtAnnouncementData.Rows[i]["CREATE_TIME"]).ToString("yyyy-MM-dd");
            row.Controls.Add(heading);
            row = new HtmlGenericControl();
            row.TagName = "div";
            row.ID = div.ID + "_bodyrow";
            row.Attributes["class"] = "col-sm-9";
            div.Controls.Add(row);
            TextBox body = new TextBox();
            body.TextMode = TextBoxMode.MultiLine;
            body.ID = div.ID + "_body";
            body.ReadOnly = true;
            body.Width = new Unit("100%");
            body.CssClass = "form-group no-resize autosize";
            body.Text = dtAnnouncementData.Rows[i]["BODY"].ToString();
            body.BorderWidth = 0;
            row.Controls.Add(body);
            Label edit_note = new Label();
            edit_note.ID = div.ID + "_editnote";
            edit_note.Font.Size = 6;
            edit_note.Font.Italic = true;
            edit_note.ForeColor = System.Drawing.Color.Gray;
            edit_note.Text = "最後編輯: " + dtAnnouncementData.Rows[i]["EDITOR_NAME"].ToString() + " " + dtAnnouncementData.Rows[i]["LAST_EDIT_TIME"].ToString();
            row.Controls.Add(edit_note);            
        }
        lastNewsRow += numberOfItemsToLoad;
    }

    //[WebMethod]
    //public static DataTable GetNews(DataTable dt, int row)
    //{
    //    return dt;
    //}

    //[WebMethod]
    //public static string GetCurrentTime(string name)
    //{
    //    return "Hello " + name + Environment.NewLine + "The Current Time is: "
    //        + DateTime.Now.ToString();
    //}

}