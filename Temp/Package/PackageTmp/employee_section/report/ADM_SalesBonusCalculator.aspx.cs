using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class employee_section_report_ADM_SalesBonusCalculator : System.Web.UI.Page
{
    public static string userName;
    string NZconnectionString = ConfigurationManager.ConnectionStrings["NZConnectionString"].ConnectionString;
    string ERP2connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = DateTime.Now.Year; i > 2019; i--)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.SelectedIndex = 0;

            for (int i = 1; i < 13; i++)
            {
                ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString("D2")));
            }
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString("D2");

            using (SqlConnection conn = new SqlConnection(NZconnectionString))
            {
                string query = "select distinct CMSMV.MV001 'value'" +
                    " ,CMSMV.MV001+' '+CMSMV.MV002 'text'" +
                    " from COPTG" +
                    " left join CMSMV on COPTG.TG006=CMSMV.MV001" +
                    " where COPTG.TG006<>''" +
                    " order by CMSMV.MV001";

                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlSales.Items.Add(new ListItem(dt.Rows[i]["text"].ToString().Trim(), dt.Rows[i]["value"].ToString().Trim()));
                }

                ddlSales.SelectedValue = "0006";
            }
            updateData();
        }
        userName = getId();
        if(userName != "chrissy" 
           && userName !="kevin")
        {
            AdminInput.Visible = false;
        }
    }

    protected List<string> getRoles()
    {
        List<string> role = new List<string>();
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        foreach (IdentityReference SIDRef in identity.Groups)
        {
            SecurityIdentifier sid = (SecurityIdentifier)SIDRef.Translate(typeof(SecurityIdentifier));
            NTAccount account = (NTAccount)SIDRef.Translate(typeof(NTAccount));
            role.Add(account.Value);
        }
        return role;
    }
    protected string getId()
    {
        WindowsPrincipal principal = (WindowsPrincipal)User;
        WindowsIdentity identity = (WindowsIdentity)User.Identity;
        string[] name = identity.Name.Split('\\');
        return name[1];
    }

    protected void RefreshData(object sender, EventArgs e)
    {
        updateData();
    }

    protected void updateData()
    {
        lblBonusPercentageTimeframe.Text = ddlYear.SelectedItem.Text + "年" + ddlMonth.SelectedItem.Text + "月業績獎金成數:";
        lblCustomerExceptionTimeframe.Text = ddlYear.SelectedItem.Text + "年" + ddlMonth.SelectedItem.Text + "月舊客例外清單:";
        lblPersonnelAndTimeframeDescription.Text = ddlSales.SelectedItem.Text + "於" + ddlYear.SelectedItem.Text + "年" + ddlMonth.SelectedItem.Text + "月業績獎金:";
        txtCustomersToAddToExceptionList.Text = "";

        getPercentageData();
        displayExceptionList();
        displaySalesData();
        displaySalesAndBonusData();
    }

    protected void getPercentageData()
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = ";with OldClientParams " +
                " as" +
                " (" +
                " select YearMonth" +
                " , ClientStatus" +
                " , SalesBonusPercent" +
                " from SalesBonusPercent" +
                " where ClientStatus = 1" +
                " and YearMonth <= CONVERT(datetime2(0), @date)" +
                " union" +
                " select null,1,1" +
                " )" +
                " , NewClientParams" +
                " as" +
                " (" +
                " select YearMonth" +
                " , ClientStatus" +
                " , SalesBonusPercent" +
                " from SalesBonusPercent" +
                " where ClientStatus = 2" +
                " and YearMonth <= CONVERT(datetime2(0), @date)" +
                " union" +
                " select null,2,1" +
                " )" +
                " select *" +
                " from" +
                " (" +
                " select top 1 ClientStatus" +
                " , SalesBonusPercent" +
                " from OldClientParams" +
                " order by YearMonth desc" +
                " ) as OldSrc" +
                " union" +
                " select *" +
                " from" +
                " (" +
                " select top 1 ClientStatus" +
                " , SalesBonusPercent" +
                " from NewClientParams" +
                " order by YearMonth desc" +
                " ) as NewSrc" +
                " order by ClientStatus";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@date", ddlYear.SelectedValue + ddlMonth.SelectedValue + "01");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ClientStatus"].ToString() == "1")
                {
                    txtOldCustomerBonusPercent.Text = dt.Rows[i]["SalesBonusPercent"].ToString();
                    lblOldCustomerBonusPercent.Text = dt.Rows[i]["SalesBonusPercent"].ToString();
                }
                else if (dt.Rows[i]["ClientStatus"].ToString() == "2")
                {
                    txtNewCustomerBonusPercent.Text = dt.Rows[i]["SalesBonusPercent"].ToString();
                    lblNewCustomerBonusPercent.Text = dt.Rows[i]["SalesBonusPercent"].ToString();
                }
            }
        }
    }

    protected void btnSaveBonusPercent_Click(object sender, EventArgs e)
    {
        saveBonusData();
        updateData();
    }

    protected void saveBonusData()
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();
            string query = "update SalesBonusPercent" +
                " set SalesBonusPercent = @salesBonusPercent" +
                " , Modifier = @id" +
                " , ModifyTime = @time" +
                " where YearMonth = @date" +
                " and ClientStatus = @clientStatus" +
                " if @@ROWCOUNT = 0" +
                " begin" +
                " insert SalesBonusPercent(Creator, CreateTime, Modifier, ModifyTime, YearMonth, ClientStatus, SalesBonusPercent)" +
                " values(@id, @time, @id, @time, @date, @clientStatus, @salesBonusPercent)" +
                " end";
            //insert or update 舊客獎金資料
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", userName);
            cmd.Parameters.AddWithValue("@time", DateTime.Now);
            cmd.Parameters.AddWithValue("@date", new DateTime(Int32.Parse(ddlYear.SelectedValue), Int32.Parse(ddlMonth.SelectedValue), 1));
            cmd.Parameters.AddWithValue("@clientStatus", 1);
            cmd.Parameters.AddWithValue("@salesBonusPercent", decimal.Parse(txtOldCustomerBonusPercent.Text));
            cmd.ExecuteNonQuery();

            //insert or update 新客獎金資料
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", userName);
            cmd.Parameters.AddWithValue("@time", DateTime.Now);
            cmd.Parameters.AddWithValue("@date", new DateTime(Int32.Parse(ddlYear.SelectedValue), Int32.Parse(ddlMonth.SelectedValue), 1));
            cmd.Parameters.AddWithValue("@clientStatus", 2);
            cmd.Parameters.AddWithValue("@salesBonusPercent", decimal.Parse(txtNewCustomerBonusPercent.Text));
            cmd.ExecuteNonQuery();
        }
    }

    protected DataTable GetSalesData()
    {
        DateTime endDate = DateTime.ParseExact(ddlYear.SelectedValue + ddlMonth.SelectedValue + "25", "yyyyMMdd", null, System.Globalization.DateTimeStyles.None);
        using (SqlConnection conn = new SqlConnection(NZconnectionString))
        {
            conn.Open();
            string query = ";with data" +
                " as" +
                " (" +
                " select ti.TI006 '業務'" +
                " ,ti.TI004 '客代'" +
                " ,ma.CREATE_DATE '客戶建立日期'" +
                " ,tj.TJ004 '品號'" +
                " ,-tj.TJ033 '金額'" +
                " from COPTI ti" +
                " left join COPTJ tj on ti.TI001 = tj.TJ001 and ti.TI002 = tj.TJ002" +
                " left join COPMA ma on ti.TI004 = ma.MA001" +
                " where ti.TI019 = 'Y'" +
                " and ti.TI004 <> 'AA2446'" +
                " and ti.TI034 between @beginDate and @endDate" +
                " union all" +
                " select tg.TG006 '業務'" +
                " ,tg.TG004 '客代'" +
                " ,ma.CREATE_DATE '客戶建立日期'" +
                " ,th.TH004 '品號'" +
                " ,th.TH037 '金額'" +
                " from COPTG tg" +
                " left join COPTH th on tg.TG001 = th.TH001 and tg.TG002 = th.TH002" +
                " left join COPMA ma on tg.TG004 = ma.MA001" +
                " where tg.TG023 = 'Y'" +
                " and tg.TG004 <> 'AA2446'" +
                " and tg.TG042 between @beginDate and @endDate" +
                " )" +
                " ,ClientStatusReport" +
                " as" +
                " (" +
                " select" +
                " d.業務 '業務'" +
                " ,mv.MV002 '業務名稱'" +
                " ,d.客代" +
                " ,d.客戶建立日期" +
                " ,case" +
                " when d.客戶建立日期 between @beginDate and @endDate then 2" +
                " when exists " +
                " (" +
                " select *" +
                " from NZ_ERP2.dbo.OldCustomerExceptionList" +
                " where YearMonth=@exceptionListYearMonth" +
                " and CustomerId=d.客代" +
                " )" +
                " then 2" +
                " else 1" +
                " end '新舊客'" +
                " ,coalesce(convert(decimal(20, 2), SUM(d.金額)), '0.00') '銷售淨額'" +
                " from data d" +
                " left join CMSMV mv on d.業務 = mv.MV001" +
                " group by" +
                " d.業務" +
                " ,mv.MV002" +
                " ,d.客代" +
                " ,d.客戶建立日期" +
                " )" +
                " select @yearMonth '銷售年月'" +
                " ,csr.業務 '業務代號'" +
                " ,csr.業務名稱 '業務名稱'" +
                " ,csr.客代 '客戶代號'" +
                " ,ma.MA002 '客戶簡稱'" +
                " ,csr.銷售淨額 '銷售淨額'" +
                " ,csr.新舊客 '客戶屬性'" +
                " ,csr.客戶建立日期 '客戶建立日期'" +
                " from ClientStatusReport csr" +
                " left join COPMA ma on csr.客代 = ma.MA001" +
                " where csr.業務=@sales" +
                " order by csr.業務" +
                " ,csr.新舊客" +
                " ,csr.客代";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@beginDate", endDate.AddMonths(-1).AddDays(1).ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@yearMonth", endDate.Year.ToString() + endDate.Month.ToString("D2"));
            cmd.Parameters.AddWithValue("@sales", ddlSales.SelectedValue);
            cmd.Parameters.AddWithValue("@exceptionListYearMonth", new DateTime(endDate.Year, endDate.Month, 1));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }

    protected void displaySalesData()
    {
        DataTable dtSales = GetSalesData();


        DataTable filteredTableNewCustomer = new DataTable();
        var filteredRowsNewCustomer = dtSales.AsEnumerable()
            .Where(sales => sales.Field<int>("客戶屬性") == 2);

        if (filteredRowsNewCustomer.Any())
        {
            filteredTableNewCustomer = filteredRowsNewCustomer.CopyToDataTable();
        }

        gvSalesBonusDisplayNew.DataSource = filteredTableNewCustomer;
        gvSalesBonusDisplayNew.DataBind();


        DataTable filteredTableOldCustomer = new DataTable();
        var filteredRowsOldCustomer = dtSales.AsEnumerable()
            .Where(sales => sales.Field<int>("客戶屬性") == 1);

        if (filteredRowsOldCustomer.Any())
        {
            filteredTableOldCustomer = filteredRowsOldCustomer.CopyToDataTable();
        }

        gvSalesBonusDisplayOld.DataSource = filteredTableOldCustomer;
        gvSalesBonusDisplayOld.DataBind();

    }

    protected void displaySalesAndBonusData()
    {
        if (gvSalesBonusDisplayNew.Rows.Count > 0)
        {
            decimal bonusPercent = decimal.Parse(lblNewCustomerBonusPercent.Text);
            decimal sum = 0;
            foreach (GridViewRow row in gvSalesBonusDisplayNew.Rows)
            {
                sum += decimal.Parse(((Label)row.Cells[3].FindControl("lblTotalSales")).Text);
            }
            lblNewCustomerTotalSales.Text = sum.ToString();
            lblNewCustomerSalesBonus.Text = (Math.Round(sum * bonusPercent / 100, 2)).ToString();
        }
        else
        {
            lblNewCustomerTotalSales.Text = "0.00";
            lblNewCustomerSalesBonus.Text = "0.00";
        }

        if (gvSalesBonusDisplayOld.Rows.Count > 0)
        {
            decimal bonusPercent = decimal.Parse(lblOldCustomerBonusPercent.Text);
            decimal sum = 0;
            foreach (GridViewRow row in gvSalesBonusDisplayOld.Rows)
            {
                sum += decimal.Parse(((Label)row.Cells[3].FindControl("lblTotalSales")).Text);
            }
            lblOldCustomerTotalSales.Text = sum.ToString();
            lblOldCustomerSalesBonus.Text = (Math.Round(sum * bonusPercent / 100, 2)).ToString();
        }
        else
        {
            lblOldCustomerTotalSales.Text = "0.00";
            lblOldCustomerSalesBonus.Text = "0.00";
        }

        lblTotalSalesBonus.Text = "NTD "
            + (decimal.Parse(lblNewCustomerSalesBonus.Text) + decimal.Parse(lblOldCustomerSalesBonus.Text)).ToString();
    }

    protected void btnAddToExceptionList_Click(object sender, EventArgs e)
    {
        saveExceptionListData();
        updateData();
    }

    protected void saveExceptionListData()
    {
        char[] separators = new char[] { ',', '，', ' ' };
        string[] customerIds = txtCustomersToAddToExceptionList.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in customerIds)
        {
            using (SqlConnection conn = new SqlConnection(ERP2connectionString))
            {
                conn.Open();
                string query = "begin" +
                    " if not exists (" +
                    " select *" +
                    " from OldCustomerExceptionList ocel" +
                    " where YearMonth=@yearMonth" +
                    " and ocel.CustomerId=@customerId" +
                    " )" +
                    " begin" +
                    " insert into [OldCustomerExceptionList]" +
                    " values (@id,@time,@id,@time,@yearMonth,@customerId)" +
                    " end" +
                    " end";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userName);
                cmd.Parameters.AddWithValue("@time", DateTime.Now);
                cmd.Parameters.AddWithValue("@yearMonth", new DateTime(Int32.Parse(ddlYear.SelectedValue), Int32.Parse(ddlMonth.SelectedValue), 1));
                cmd.Parameters.AddWithValue("@customerId", s);
                cmd.ExecuteNonQuery();
            }
        }
    }

    protected void displayExceptionList()
    {
        lstExceptionList.Items.Clear();
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();

            string query = "select ocel.CustomerId + ' ' + ma.MA002 'text'" +
                " ,ocel.CustomerId 'value'" +
                " from OldCustomerExceptionList ocel" +
                " left join NZ.dbo.COPMA ma on ocel.CustomerId=ma.MA001" +
                " where ocel.YearMonth=@yearMonth" +
                " order by ocel.CustomerId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@yearMonth", new DateTime(Int32.Parse(ddlYear.SelectedValue), Int32.Parse(ddlMonth.SelectedValue), 1));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstExceptionList.Items.Add(new ListItem(dt.Rows[i]["text"].ToString(), dt.Rows[i]["value"].ToString()));
            }
        }
    }

    protected void btnRemoveFromExceptionList_Click(object sender, EventArgs e)
    {
        deleteExceptionListData();
        updateData();
    }

    protected void deleteExceptionListData()
    {
        using (SqlConnection conn = new SqlConnection(ERP2connectionString))
        {
            conn.Open();

            string query = "delete from OldCustomerExceptionList" +
                " where YearMonth=@yearMonth" +
                " and CustomerId=@customerId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@yearMonth", new DateTime(Int32.Parse(ddlYear.SelectedValue), Int32.Parse(ddlMonth.SelectedValue), 1));
            cmd.Parameters.AddWithValue("@customerId", lstExceptionList.SelectedValue);
            cmd.ExecuteNonQuery();
        }
    }
}