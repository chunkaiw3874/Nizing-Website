<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="anti-refrigerant-wire.aspx.cs" Inherits="anti_refrigerant_wire" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>發熱線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="發熱線,並聯式發熱帶,醫療呼吸管" />
    <meta name="description" content="各式發熱線材，包含醫療呼吸管使用的UL3589，以及為表層加溫的PHC並聯式電熱帶、及其他各類常規及訂製線材">

    <style type="text/css">
        .product-category .bg-wrapper {
            /*background-image: url('/images/product/heating-wire/background/heating-wire.jpg');*/
        }

        .card-body .card-title{
            font-size:16px !important;
        }

        .card-body .card-title:first-child{
            padding-bottom:0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="冷媒線 Anti-Refrigerant Wire UL5048" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    冷媒線系列
                </div>
                <div class="subtitle">
                    Anti-Refrigerant Wire
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

