using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_mobile_basicInformation : System.Web.UI.Page
{
    string erp2ConnectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    string nzConnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {        
        string ext = "jpg";
        string data;
        using (SqlConnection conn = new SqlConnection(erp2ConnectionString))
        {
            conn.Open();
            string query = "SELECT DATA"
                        + " FROM HR360_FILE_STORAGE";
            SqlCommand cmd = new SqlCommand(query, conn);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            data = Convert.ToBase64String(bytes, 0, bytes.Length);       
        }
        imgAvatar.ImageUrl = "data:image/" + ext + ";base64," + data;
    }
}