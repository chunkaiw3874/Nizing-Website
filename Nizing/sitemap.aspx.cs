using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class sitemap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["language"] = RouteData.Values["language"] == null ? "zh" : RouteData.Values["language"].ToString();

        string language = Session["language"].ToString();

        BuildList(language);
    }

    protected void BuildList(string language)
    {
        //日進簡介
        HtmlGenericControl div = new HtmlGenericControl("div");
        div.Attributes.Add("class", "col");
        divSitemapItem.Controls.Add(div);
        HtmlGenericControl ul = AddSubLevel(div);
        HtmlGenericControl li = AddItem(language, "日進", "Nizing", "/company/intro", ul);
        ul = AddSubLevel(li);
        AddItem(language, "日進簡介", "Intro", "/company/intro", ul);
        AddItem(language, "企業核心與經營理念", "Culture", "/company/culture", ul);
        AddItem(language, "歷史歷程", "History", "/company/history", ul);
        AddItem(language, "實驗室", "Lab", "/company/lab", ul);

        //產品資訊
        div = new HtmlGenericControl("div");
        div.Attributes.Add("class", "col");
        divSitemapItem.Controls.Add(div);
        ul = AddSubLevel(div);
        li = AddItem(language, "產品資訊", "Product", "/product", ul);
        ul = AddSubLevel(li);
        AddItem(language, "軍規線", "Military Grade Wire", "/product/military-grade-wire", ul);
        AddItem(language, "矽膠編織線", "Silicone Fiberglass Wire", "/product/silicone-fiberglass-wire", ul);
        AddItem(language, "高溫線", "High Temperature Wire", "/product/high-temperature-wire", ul);
        AddItem(language, "矽膠線", "Silicone Wire", "/product/silicone-wire", ul);
        AddItem(language, "鐵氟龍線", "Teflon Wire", "/product/teflon-wire", ul);
        AddItem(language, "交連照射線", "Cross-Link Wire", "/product/xlpe-wire", ul);
        AddItem(language, "PVC線", "PVC Wire", "/product/pvc-wire", ul);
        AddItem(language, "套管", "Tube", "/product/tube", ul);
        AddItem(language, "補償導線", "Thermocouple", "/product/thermocouple", ul);
        AddItem(language, "發熱線", "Heating Wire", "/product/heating-wire", ul);
        AddItem(language, "汽車花線", "Automobile Wire", "/product/automobile-wire", ul);
        AddItem(language, "複合線", "Composite Cable", "/product/composite-cable", ul);
        AddItem(language, "冷媒線", "Anti-Refrigerant Wire", "/product/anti-refrigerant-wire", ul);

        //應用產業
        div = new HtmlGenericControl("div");
        div.Attributes.Add("class", "col");
        divSitemapItem.Controls.Add(div);
        ul = AddSubLevel(div);
        li = AddItem(language, "產品資訊", "Application", "/application", ul);
        ul = AddSubLevel(li);
        AddItem(language, "車用配線", "Automobile", "/application/automobile", ul);
        AddItem(language, "醫療配線", "Medical", "/application/medical", ul);
        AddItem(language, "加熱系統", "Heating System", "/application/heating-system", ul);
        AddItem(language, "溫控系統", "Temperature Control System", "/application/temperature-control-system", ul);
        AddItem(language, "LED配線", "LED Lighting", "/application/led-lighting", ul);
        AddItem(language, "建築配線", "Construction", "/application/construction", ul);
        AddItem(language, "太陽能配線", "Solar Power", "/application/solar-power", ul);
        AddItem(language, "鋼鐵工業", "Steel Industry", "/application/steel-industry", ul);
        AddItem(language, "半導體產業", "Semiconductor", "/application/semiconductor", ul);
        AddItem(language, "機械手臂", "Robotic", "/application/robotic", ul);
        AddItem(language, "雲端系統", "Cloud System", "/application/cloud-system", ul);
        AddItem(language, "其他應用", "Misc Application", "/application/misc-app", ul);
    }

    protected HtmlGenericControl AddSubLevel(HtmlGenericControl parent)
    {
        HtmlGenericControl ul = new HtmlGenericControl("ul");
        parent.Controls.Add(ul);
        return ul;
    }

    protected HtmlGenericControl AddItem(string language, string zhText, string enText, string url, HtmlGenericControl parent)
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        parent.Controls.Add(li);
        HtmlAnchor a = new HtmlAnchor();
        a.HRef = "/" + language + url;
        if (language == "zh")
        {
            a.InnerText = zhText;
        }
        else
        {
            a.InnerText = enText;
        }
        li.Controls.Add(a);
        return li;
    }
}