<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="xlpe-wire.aspx.cs" Inherits="xlpe_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>XLPE 照射線-日進電線</title>
    <meta name="keywords" content="XLPE,照射線" />
    <meta name="description" content="各式XLPE線材，經交連作用後特性加強的照射線，包含UL3173、UL3266、UL3272、UL3290、UL3320、UL3321、UL3613、UL3688、UL10368、及其他各類常規及訂製照射線">

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/xlpe-wire/background/xlpe-wire.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="照射線系列 XLPE Wire UL10368 UL1430 UL3173 UL3265 UL3266 UL3271 UL3272 UL3290
                 UL3302 UL3320 UL3321 UL3385 UL3386 UL3613 UL3688" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    照射線系列
                </div>
                <div class="subtitle">
                    XLPE Wire Series
                </div>
            </div>
            <div class="container-fluid bg-wrapper">
                <div class="content container">
                    <div id="divProductList" runat="server" class="row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

