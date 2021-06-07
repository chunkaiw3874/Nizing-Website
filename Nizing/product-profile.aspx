<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="product-profile.aspx.cs" Inherits="product_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .product-item #product-image-carousel.carousel .product-image.carousel-item img {
            display: block;
        }

        .product-item #product-image-carousel.carousel .carousel-control-prev .carousel-control-prev-icon,
        .product-item #product-image-carousel.carousel .carousel-control-next .carousel-control-next-icon,
        .product-item #product-image-carousel.carousel .carousel-indicators li {
            filter: invert(1);
        }
    </style>

    <script type="text/javascript">
        $(function () {
            dragScroll();
        });
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

