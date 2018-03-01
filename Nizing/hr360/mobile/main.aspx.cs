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
    public string jsonAnnouncementData;
    public byte[] blob;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNewsFromDB();
        jsonAnnouncementData = ConvertDtToString(dtAnnouncementData);
        LoadBlob();
    }
    private void LoadBlob()
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = "SELECT [DATA] FROM HR360_FILE_STORAGE";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            blob = (byte[])cmd.ExecuteScalar();
            //SqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //Response.BinaryWrite((byte[])dr["DATA"]);
        }

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
                        + " LEFT JOIN NZ.dbo.CMSMV MVEDITOR ON ANNOUNCE.LAST_EDITOR = MVEDITOR.MV001";            
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtAnnouncementData);
        }
        return dtAnnouncementData;
    }
    private string ConvertDtToString(DataTable dt)
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
    private DataTable LoadDayoffFromDB()
    {
        DataTable dt = new DataTable();
        
        return dt;
    }
}