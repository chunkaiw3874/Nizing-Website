<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="product-not-found.aspx.cs" Inherits="product_not_found" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="h1 text-center">
            <asp:Label ID="lblErrorMessage" runat="server" Text="Label"></asp:Label>
        </div>
        <img src="/images/placeholder/product-not-found.png" />
    </div>
</asp:Content>

