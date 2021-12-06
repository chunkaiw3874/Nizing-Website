<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="teflon-wire.aspx.cs" Inherits="teflon_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>鐵氟龍線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="鐵氟龍線,醫療器材配線" />
    <meta name="description" content="各式鐵氟龍電線，為抗腐蝕及其它化學特性的首選，包含PTFE材質的UL1199、UL10344、UL10393、FEP材質的UL1330、UL1331、UL1332、UL1887、UL1901、VDE8219、VDE8220、VDE REG-NR8295、PFA材質的UL1709、UL1710、UL1726、UL1727、UL10362、ETFE材質的UL10109、醫療專用的鐵氟龍矽膠醫療器材配線、傳輸訊號的RG178B/U、RG179、RG316高頻同軸線及其他各類常規及訂製線材">    
    <meta property="og:type" content="article" />
    <meta property="og:title" content="鐵氟龍線、醫療器材配線-日進電線" />
    <meta property="og:description" content="各式鐵氟龍電線，為抗腐蝕及其它化學特性的首選，包含PTFE材質的UL1199、UL10344、UL10393、FEP材質的UL1330、UL1331、UL1332、UL1887、UL1901、VDE8219、VDE8220、VDE REG-NR8295、PFA材質的UL1709、UL1710、UL1726、UL1727、UL10362、ETFE材質的UL10109、醫療專用的鐵氟龍矽膠醫療器材配線、傳輸訊號的RG178B/U、RG179、RG316高頻同軸線及其他各類常規及訂製線材" />
    <meta property="og:image" content="https://www.nizing.com.tw/images/product/teflon-wire/background/teflon-wire-02.jpg" />
    <meta property="og:url" content="https://www.nizing.com.tw/zh/product/teflon-wire" />
    <meta property="og:site_name" content="Nizing Electric Wire and Cable" />
    <style type="text/css">
        .navigation-buttons {
            display: flex;
            justify-content: center;
        }

            .navigation-buttons a {
                padding: 24px 5px 0 5px;
                width: 30%;
            }

        .webp .bg-wrapper.single-core {
            background: url('/images/product/teflon-wire/background/teflon-wire.webp') no-repeat top / cover;
        }

        .no-webp .bg-wrapper.single-core {
            background: url('/images/product/teflon-wire/background/teflon-wire.jpg') no-repeat top / cover;
        }

        .webp .bg-wrapper.multi-core {
            background: url('/images/product/teflon-wire/background/teflon-wire-02.webp') no-repeat top / cover;
        }

        .no-webp .bg-wrapper.multi-core {
            background: url('/images/product/teflon-wire/background/teflon-wire-02.jpg') no-repeat top / cover;
        }

        .product-list-title {
            color: white;
            text-align: center;
            font-size: 36px;
            padding-top: 32px;
        }

        @media all and (max-width:1199px) {
            .navigation-buttons a {
                width: 30%;
            }
        }

        @media all and (max-width:991px) {
            .navigation-buttons a {
                width: 35%;
            }
        }

        @media all and (max-width:767px) {
            .navigation-buttons a {
                width: 40%;
            }
        }

        @media all and (max-width:575px) {
            .navigation-buttons a {
                width: 45%;
            }
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
                <div class="navigation-buttons">
                    <a id="btnSingleCore" runat="server">
                        <picture>
                            <source srcset="/images/product/teflon-wire/background/teflon-wire-button-01.webp"
                                type="image/webp" />
                            <img src="/images/product/teflon-wire/background/teflon-wire-button-01.jpg"
                                alt="單芯鐵氟龍電線電纜 Single Core Teflon Wire and Cable" />
                        </picture>
                    </a>
                    <a id="btnMultiCore" runat="server">
                        <picture>
                            <source srcset="/images/product/teflon-wire/background/teflon-wire-button-02.webp"
                                type="image/webp" />
                            <img src="/images/product/teflon-wire/background/teflon-wire-button-02.jpg"
                                alt="多芯鐵氟龍電線電纜 Multi Core Teflon Wire and Cable" />
                        </picture>
                    </a>
                </div>
            </div>
            <div id="divProductCategory" runat="server">
                <%--                <div class="container-fluid bg-wrapper">
                    <div class="content container">
                        <div id="divProductList" runat="server" class="row row-cols-2 row-cols-md-3 row-cols-lg-4 product-list">
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>

