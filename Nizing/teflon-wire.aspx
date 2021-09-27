<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="teflon-wire.aspx.cs" Inherits="teflon_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>鐵氟龍線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="鐵氟龍線,醫療器材配線" />
    <meta name="description" content="各式鐵氟龍電線，為抗腐蝕及其它化學特性的首選，包含PTFE材質的UL1199、UL10344、UL10393、FEP材質的UL1330、UL1331、UL1332、UL1887、UL1901、VDE8219、VDE8220、VDE REG-NR8295、PFA材質的UL1709、UL1710、UL1726、UL1727、UL10362、ETFE材質的UL10109、醫療專用的鐵氟龍矽膠醫療器材配線、傳輸訊號的RG178B/U、RG179、RG316高頻同軸線及其他各類常規及訂製線材">

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/teflon-wire/background/teflon-wire.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="鐵氟龍線系列 Teflon Wire UL10109 UL10344 UL10362 UL10393 UL1199 UL1330
                 UL1331 UL1332 UL1709 UL1710 UL1726 UL1727 UL1887 UL1901 VDE-8219 VDE-8220
                VDE-REG-NR-8295" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    鐵氟龍線系列
                </div>
                <div class="subtitle">
                    Teflon Wire Series
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

