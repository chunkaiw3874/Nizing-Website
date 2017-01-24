using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class oqs : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["OQSConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Write_Data();
    }
    private void Write_Data()
    {
        string query = "INSERT INTO order_m_test (order_number, date, customer_name, phone, company_address, shipping_address, contact, memo)"
                        +" VALUES (CASE"
			            +" WHEN CONVERT(CHAR(8), GETDATE(), 112) > COALESCE(CONVERT(CHAR(8), (SELECT MAX(order_number) FROM order_m_test)),0)"
				        +" THEN CONVERT(CHAR(8), GETDATE(), 112)+'001'"
			            +" ELSE CONVERT(NVARCHAR(20), CONVERT(NUMERIC(20), (SELECT MAX(order_number) FROM order_m_test)) + 1)"
		                +" END"
		                +" , CONVERT(CHAR(10), GETDATE(), 101), @customer_name, @phone, @company_address, @shipping_address, @contact, @memo)";
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add("@customer_name", SqlDbType.NVarChar);
            cmd.Parameters["@customer_name"].Value = txtCompany_Name.Text;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);
            cmd.Parameters["@phone"].Value = txtPhone.Text;
            cmd.Parameters.Add("@company_address", SqlDbType.NVarChar);
            cmd.Parameters["@company_address"].Value = txtCompany_Add.Text;
            cmd.Parameters.Add("@shipping_address", SqlDbType.NVarChar);
            cmd.Parameters["@shipping_address"].Value = txtShipping_Add.Text;
            cmd.Parameters.Add("@contact", SqlDbType.NVarChar);
            cmd.Parameters["@contact"].Value = txtContact.Text;
            cmd.Parameters.Add("@memo", SqlDbType.NVarChar);
            cmd.Parameters["@memo"].Value = txtMemo.Text;

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}