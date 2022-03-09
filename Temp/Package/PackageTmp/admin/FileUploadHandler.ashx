<%@ WebHandler Language="C#" Class="FileUploadHandler" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


public class FileUploadHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            HttpPostedFile file = context.Request.Files[0];
            var resultList = new List<UploadFilesResult>();
            string path = context.Server.MapPath("~/uploads/");
            file.SaveAs(path + file.FileName);

            UploadFilesResult uploadFiles = new UploadFilesResult();
            uploadFiles.name = file.FileName;
            uploadFiles.size = file.ContentLength;
            uploadFiles.type = "image/jpeg";
            uploadFiles.url = "/uploads/" + file.FileName;
            uploadFiles.deleteUrl = "/FileUploadHandler.ashx?file=" + file.FileName;
            uploadFiles.thumbnailUrl = "/uploads/" + file.FileName;
            uploadFiles.deleteType = "GET";

            resultList.Add(uploadFiles);

            JsonFiles jFiles = new JsonFiles(resultList);
            string jFilesJson = JsonConvert.SerializeObject(jFiles);

            context.Response.ContentType = "text/plain";
            context.Response.Write(jFilesJson);
        }

        if (context.Request.QueryString["file"] != null)
        {
            File.Delete(Path.Combine(context.Server.MapPath("~/uploads/"), context.Request.QueryString["file"]));
            context.Response.ContentType = "application/json";
            context.Response.Write("\"OK\"");
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