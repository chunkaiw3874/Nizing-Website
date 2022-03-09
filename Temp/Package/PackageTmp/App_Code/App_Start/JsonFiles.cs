using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// JsonFiles 的摘要描述
/// </summary>
public class JsonFiles
{
    public UploadFilesResult[] files;
    public string TempFolder { get; set; }
    public JsonFiles(List<UploadFilesResult> filesList)
    {
        files = new UploadFilesResult[filesList.Count];
        for (int i = 0; i < filesList.Count; i++)
        {
            files[i] = filesList.ElementAt(i);
        }
    }
}