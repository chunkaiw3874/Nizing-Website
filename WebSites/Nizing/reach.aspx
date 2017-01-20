<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="reach.aspx.cs" Inherits="reach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-安規認證</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    REACH
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="rohs.aspx">RoHS</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reach.aspx" CssClass="active">REACH</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="certificate-document">
        <div class="inner-content">
            <div class="content-row">
                <div class="icon">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/certificate/cert_reach1-small.jpg" NavigateUrl="~/images/certificate/cert_reach1.jpg" Target="_blank"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

