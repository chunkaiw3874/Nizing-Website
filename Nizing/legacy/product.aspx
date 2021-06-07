<%@ Page Title="" Language="C#" MasterPageFile="~/master/product.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進產品線-日進電線</title>
    <meta name="description" content="各式電線電纜，經過UL、VDE、CCC、PSE等國際認證，品質優良，外銷內需皆可滿足">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-menu">
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/product/pro_01.jpg" NavigateUrl="~/pvc-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/product/pro_02.jpg" NavigateUrl="~/silicone-fiberglass-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/product/pro_03.jpg" NavigateUrl="~/high-temperature-resistance-series.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/product/pro_04.jpg" NavigateUrl="~/silicone-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/product/pro_05.jpg" NavigateUrl="~/teflon-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/product/pro_06.jpg" NavigateUrl="~/xlpe-series.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/product/pro_07.jpg" NavigateUrl="~/sleeve-and-tube-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/images/product/pro_08.jpg" NavigateUrl="~/thermocouple-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/images/product/pro_09.jpg" NavigateUrl="~/heating-wire-series.aspx"></asp:HyperLink> 
            </div>
        </div>
        <div class="content-row">
            <div class="button">
                <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/images/product/pro_10.jpg" NavigateUrl="~/special-cable.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/images/product/pro_11.jpg" NavigateUrl="~/automotive-wire-series.aspx"></asp:HyperLink> 
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/images/product/pro_12.jpg" NavigateUrl="~/military-grade-series.aspx"></asp:HyperLink> 
            </div>
        </div>
    </div>
</asp:Content>

