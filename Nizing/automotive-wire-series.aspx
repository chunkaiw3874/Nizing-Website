<%@ Page Title="" Language="C#" MasterPageFile="~/master/product.master" AutoEventWireup="true" CodeFile="automotive-wire-series.aspx.cs" Inherits="automotive_wire_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>汽車花線系列-日進電線</title>
    <meta name="description" content="各式汽車花線">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/button/auto_wire_jaso.jpg" alt="日規汽車花線" NavigateUrl="~/automotive-wire-standard-jaso.aspx"></asp:HyperLink>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/button/auto_wire_sae.jpg" alt="美規汽車花線" NavigateUrl="~/automotive-wire-standard-sae.aspx"></asp:HyperLink>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/button/auto_wire_iso.jpg" alt="歐規汽車花線" NavigateUrl="~/automotive-wire-standard-iso.aspx"></asp:HyperLink>
                </div> 
            </div>
        </div>

    </div>
</asp:Content>

