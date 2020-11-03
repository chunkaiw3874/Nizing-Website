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

public partial class hr360_UI01 : System.Web.UI.Page
{
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            imgAvatar.ImageUrl = "~\\hr360\\image\\employee_profile\\" + Session["erp_id"].ToString() + ".jpg";
            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT CMSMV.MV001"// 員工代號
                                                        + " ,CMSMV.MV002"//員工姓名
                                                        + " ,CMSME.ME002"// 部門
                                                        + " ,CMSMJ.MJ003"// 職稱
                                                        + " ,CMSMV.MV015"// 手機
                                                        + " ,CMSMV.MV016"// 電話
                                                        + " ,CMSMV.MV017"// 戶籍地址
                                                        + " ,CMSMV.MV019"// 通訊地址
                                                        + " ,CMSMV.MV020"// E-MAIL
                                                        + " ,CMSMV.MV021"// 到職日期
                                                        + " ,CMSMV.MV035"// 銀行薪轉代號
                                                        + " ,CMSMV.MV036"// 銀行薪轉帳號
                                                        + " ,CMSMV.MV008"// 生日
                                                        + " ,CMSMV.MV029"// 星座
                                                        + " FROM CMSMV"
                                                        + " LEFT JOIN CMSMJ ON CMSMV.MV006 = CMSMJ.MJ001"
                                                        + " LEFT JOIN CMSME ON CMSMV.MV004 = CMSME.ME001"
                                                        + " WHERE CMSMV.MV001 = @ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);
            }
            lblEmployee_Id.Text = dt.Rows[0][0].ToString();
            lblEmployee_Name.Text = dt.Rows[0][1].ToString();
            lblEmployee_Department.Text = dt.Rows[0][2].ToString();
            lblEmployee_Rank.Text = dt.Rows[0][3].ToString();
            lblCell.Text = dt.Rows[0][4].ToString();
            lblTel.Text = dt.Rows[0][5].ToString();
            lblAddress.Text = dt.Rows[0][6].ToString();
            lblResidentialAddress.Text = dt.Rows[0][7].ToString();
            lblEmail.Text = dt.Rows[0][8].ToString();
            DateTime date = DateTime.ParseExact(dt.Rows[0][9].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            lblStartDate.Text = date.ToString("yyyy/MM/dd");
            lblBankId.Text = dt.Rows[0][10].ToString();
            lblBankAccount.Text = dt.Rows[0][11].ToString();
            date = DateTime.ParseExact(dt.Rows[0][12].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            lblBirthDate.Text = date.ToString("yyyy/MM/dd");
            lblHoroscope.Text = dt.Rows[0][13].ToString();
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand("SELECT LINE_ID"
                                                    + " FROM HR360_BI01_A"
                                                    + " WHERE ERP_ID=@ID", conn);
                cmdSelect.Parameters.AddWithValue("@ID", Session["erp_id"].ToString());
                lblLine.Text = (string)cmdSelect.ExecuteScalar();
            }
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        
    }
}