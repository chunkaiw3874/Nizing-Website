<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="product-profile.aspx.cs" Inherits="product_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <asp:PlaceHolder ID="MetaTagPlaceholder" runat="server"></asp:PlaceHolder>
    <meta name="robots" content="index, follow" />
    <style>
        textarea {
            width: 100%;
            border: none;
            height:100%;
        }
    </style>
    <script type="text/javascript">
        //$(function () {
        //    dragScroll();
        //});
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="productItem" class="display-block-wrapper product-item" runat="server">
    </div>
</asp:Content>

