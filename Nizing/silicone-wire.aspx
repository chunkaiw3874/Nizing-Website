<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="silicone-wire.aspx.cs" Inherits="silicone_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>矽膠電線、醫療器材配線-日進電線</title>
    <meta name="keywords" content="矽膠電線,矽膠高壓線,醫療器材配線,矽膠多芯線,矽膠絕緣線" />
    <meta name="description" content="各式矽膠電線，包含家電及需耐溫的機台常用的UL3123、UL3132、UL3135、UL3136、VDE H05S-K、VDE H05SS-F、VDE FG4G4、PSE3323矽膠耐熱電線、耐高壓的UL3239矽膠高壓電線、醫療業界使用的VDE REG-NR:103874醫療線、及其他各類常規及訂製電線">

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/silicone-wire/background/silicone-wire.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="矽膠線系列 Silicone Wire PSE3323 UL3123 UL3132 UL3135 UL3136 UL3239 UL4330 UL4476 VDE-FG4G4 VDE-H05S-K VDE-H05SS-F VDE-REG-NR-103874 " />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    矽膠線系列
                </div>
                <div class="subtitle">
                    Silicone Wire Series
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

