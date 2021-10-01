using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HR360LoggedUser
/// </summary>
public static class HR360LoggedUser
{
    public static string HR360Id { set; get; }
    public static string ERPId { set; get; }
    public static string Company { set; get; }
    public static string Name { set; get; }
    public static string Sex { set; get; }
    public static string Dept { set; get; }
    public static string Job { set; get; }
    public static DateTime StartDate { set; get; }
}