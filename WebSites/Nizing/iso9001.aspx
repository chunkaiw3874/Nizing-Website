<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="iso9001.aspx.cs" Inherits="iso9001" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-安規認證</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    ISO9001
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="iso9001.aspx" CssClass="active">ISO9001</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="ccc.aspx">CCC</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="certificate-document">
        <div class="inner-content">
            <div class="content-row">
                <div class="icon">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/certificate/cert_iso9001_en1-small.jpg" NavigateUrl="~/images/certificate/cert_iso9001_en1.jpg" Target="_blank"></asp:HyperLink>
                </div>
                <div class="icon">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/certificate/cert_iso9001_en2-small.jpg" NavigateUrl="~/images/certificate/cert_iso9001_en2.jpg" Target="_blank"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

