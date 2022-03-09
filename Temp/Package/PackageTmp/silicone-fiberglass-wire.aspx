<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="silicone-fiberglass-wire.aspx.cs" Inherits="silicone_fiberglass_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>矽膠編織電線、耐熱電線、高溫家用電器配線-日進電線</title>
    <meta name="keywords" content="矽膠編織電線,耐熱電線,高溫家用電器配線" />
    <meta name="description" content="各式矽膠編織線材，有家電及高溫場所常使用的RS-GE矽膠編織耐熱電線、UL3071矽膠編織耐熱電線、UL3074矽膠編織耐熱電線、UL3075矽膠編織耐熱電線、UL3122、UL3172、UL3304、UL3512、VDE-H05SJ-5、及其他各類常規及訂製線材">

    <style type="text/css">
        .product-category .silicone-fiberglass.bg-wrapper {
            background-image: url('/images/product/silicone-fiberglass-wire/background/rsge-white-1706x960.jpg');
        }

        .product-category .copper-braid.bg-wrapper {
            background-image: url('/images/product/silicone-fiberglass-wire/background/ul3512-blue-4032x2268.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="矽膠耐熱線 Silicone Fiberglass Wire RS-GE UL3068 UL3071 UL3074 UL3075 UL3122 UL3172 UL3304
                UL3512 UL3513 UL3645 VDE H05SJ-K TM3320" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    矽膠編織線系列
                </div>
                <div class="subtitle">
                    Silicone Fiberglass Series
                </div>
            </div>
            <div class="container-fluid bg-wrapper silicone-fiberglass">
                <div class="content container">
                    <div id="divProductList" runat="server" class="row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list">                        
                    </div>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>

