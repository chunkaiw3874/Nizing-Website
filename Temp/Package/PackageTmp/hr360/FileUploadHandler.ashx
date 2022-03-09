<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.IO;
using System.Web;

public class FileUploadHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //額外參數
        string para1 = context.Request.Params.Get("filePath") == null ? "" :
          context.Request.Params.Get("filePath");

        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string filePath = context.Server.MapPath(para1);
                string fileName = filePath + file.FileName;
                string tempFileName = fileName;
                int counter = 0;
                if (Path.GetExtension(fileName) == ".jpg" || Path.GetExtension(fileName) == ".png")
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    while (File.Exists(tempFileName))
                    {
                        counter++;
                        tempFileName = filePath + Path.GetFileNameWithoutExtension(fileName) + "(" + counter + ")" + Path.GetExtension(fileName);
                    }
                    file.SaveAs(tempFileName);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("檔案上傳成功");
                }
                else
                {
                    context.Response.Write("只能上傳JPG或PNG圖檔");
                }
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}