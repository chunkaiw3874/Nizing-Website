using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OQS;


namespace WpfHost
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private readonly MainForm frm1 = new MainForm();

        public Page1()
        {
            InitializeComponent();            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtLoginAccount = new DataTable();
            LoginAccountDataSetTableAdapters.LOGIN_ACCOUNTTableAdapter accountAdapter = new LoginAccountDataSetTableAdapters.LOGIN_ACCOUNTTableAdapter();
            dtLoginAccount = accountAdapter.GetData();
            
            DataRow[] drVerifyLogin = dtLoginAccount.Select("ID='" + txtUserName.Text.Trim().ToUpper()+"'");

            if (drVerifyLogin.Length == 0)
            {
                lblLoginStatus.Content = "使用者不存在";
            }
            else if (drVerifyLogin[0]["PASSWORD"].ToString() != txtPassword.Password)
            {
                lblLoginStatus.Content = "密碼錯誤";
            }
            else
            {                
                spLogin.Visibility = Visibility.Hidden;
                WindowsFormsHost wfh = new WindowsFormsHost();

                spMainWindow.Width = frm1.Width;
                spMainWindow.Height = frm1.Height;
                wfh.Width = frm1.Width;
                wfh.Height = frm1.Height;

                frm1.TopLevel = false;

                wfh.Child = frm1;
                spMainWindow.Children.Add(wfh);
            }
        }
    }
}
