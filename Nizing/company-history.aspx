<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="company-history.aspx.cs" Inherits="company_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-歷史紀錄</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    歷史紀錄
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">公司簡介</a> | <a href="company-culture.aspx">核心文化</a> | <a href="company-history.aspx" class="active">歷史紀錄</a> | <a href="company-capability.aspx">設備技術</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-history">
        <div class="inner-content">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/company/company-history-timeline.jpg" />
        </div>
    </div>
</asp:Content>

