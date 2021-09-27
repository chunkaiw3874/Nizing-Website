<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="pvc-wire.aspx.cs" Inherits="pvc_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HEAD" runat="Server">
    <title>PVC電線、控制線、家用電器配線-日進電線</title>
    <meta name="keywords" content="PVC電線,PVC電纜,PVC IV 粗芯控制線,KIV細芯控制線,家用電器配線" />
    <meta name="description" content="各式PVC線材，有一般家用的UL1007、UL1015、電腦傳輸訊號用的UL2464、UL2517、建築用的IV控制線、機械設備使用的KIV控制線、及其他各類常規及訂製線材">
    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/pvc-wire/background/pvc-wire.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="PVC線系列 PVC Wire UL1007 UL1015" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    PVC線系列
                </div>
                <div class="subtitle">
                    PVC Wire Series
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

