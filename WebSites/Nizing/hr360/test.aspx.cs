using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hr360_test : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["ERP2ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (IsPostBack && uploadFile.PostedFile != null)
        //{
        //    HttpPostedFile filename = Request.Files["uploadFile"];
        //    if (uploadFile.PostedFile.FileName.Length > 0)
        //    {
        //        System.IO.Directory.CreateDirectory(Server.MapPath("~//hr360//file//"));
        //        string filePath = Server.MapPath("~//hr360//file//" + filename);
        //        string fileNameOriginal = Path.GetFileNameWithoutExtension(filePath);
        //        string fileName = fileNameOriginal;
        //        string fileExt = Path.GetExtension(filePath);
        //        int i = 1;
        //        while (File.Exists(Server.MapPath("~//hr360//file//" + fileName + fileExt)))
        //        {
        //            fileName = fileNameOriginal + "(" + i.ToString() + ")";
        //            i++;
        //        }
        //        //this.uploadFile.SaveAs(Server.MapPath("~//hr360//file//" + fileName + fileExt));
        //        uploadFile.PostedFile.SaveAs(Server.MapPath("~//hr360//file//" + fileName + fileExt));

        //        Label lbl = new Label();
        //        lbl.Text = fileName;

        //        Label lbl2 = new Label();
        //        lbl2.Text = fileName;

        //        ListBox1.Items.Add(lbl.Text);
        //    }
        //}
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //string blah = uploadFile.PostedFile.FileName;
        HttpPostedFile filename = Request.Files[0];
        if (uploadFile.PostedFile.FileName.Length > 0)
        {
            System.IO.Directory.CreateDirectory(Server.MapPath(@"~/hr360/file/"));
            string filePath = Server.MapPath(@"~/hr360/file/" +  Path.GetFileName(filename.FileName));
            string fileNameOriginal = Path.GetFileNameWithoutExtension(filePath);
            string fileName = fileNameOriginal;
            string fileExt = Path.GetExtension(filePath);
            int i = 1;
            while (File.Exists(Server.MapPath(@"~/hr360/file/" + fileName + fileExt)))
            {
                fileName = fileNameOriginal + "(" + i.ToString() + ")";
                i++;
            }
            //this.uploadFile.SaveAs(Server.MapPath("~//hr360//file//" + fileName + fileExt));
            uploadFile.PostedFile.SaveAs(Server.MapPath(@"~/hr360/file/" + fileName + fileExt));

            Label lbl = new Label();
            lbl.Text = fileName+fileExt;

            //Label lbl2 = new Label();
            //lbl2.Text = fileName;

            ListBox1.Items.Add(lbl.Text);
        }
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = Server.MapPath(@"~/hr360/file/" + ListBox1.SelectedItem.Text);
        proc.StartInfo.UseShellExecute = true;
        proc.Start();  
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath(@"~/hr360/file/" + ListBox1.SelectedItem.Text)))
        {
            File.Delete(Server.MapPath(@"~/hr360/file/" + ListBox1.SelectedItem.Text));
            ListBox1.Items.Remove(ListBox1.SelectedItem);
        }
        
    }
}