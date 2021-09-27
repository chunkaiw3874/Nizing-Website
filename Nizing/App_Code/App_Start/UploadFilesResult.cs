﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UploadFilesResult 的摘要描述
/// </summary>
public class UploadFilesResult
{
    public string name { get; set; }
    public long size { get; set; }
    public string type { get; set; }
    public string url { get; set; }
    public string deleteUrl { get; set; }
    public string thumbnailUrl { get; set; }
    public string deleteType { get; set; }
}