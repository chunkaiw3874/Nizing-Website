<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="company-history.aspx.cs" Inherits="company_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>History - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    History
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">Introduction</a> | <a href="company-culture.aspx">Culture</a> | <a href="company-history.aspx" class="active">History</a> | <a href="company-capability.aspx">Capability</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-history">
        <div class="inner-content">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/en/images/company/company-history-timeline.jpg" />
        </div>
    </div>
</asp:Content>

