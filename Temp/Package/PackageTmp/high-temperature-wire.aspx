<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="high-temperature-wire.aspx.cs" Inherits="high_temperature_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>耐熱電線、高溫電線-日進電線</title>
    <meta name="keywords" content="耐熱電線、高溫電線" />
    <meta name="description" content="各式耐熱電線，常於特殊高溫場所及機台使用的TGGT-5256、TGGT-400、MG5107、CF-750及其他各類常規及訂製電線">
    <style type="text/css">
        .product-category .bg-wrapper {
            /*background-image: url('/images/product/high-temperature-wire/background/high-temperature-wire.jpg');*/
            background: url('/images/product/high-temperature-wire/background/high-temperature-wire.jpg') top / contain no-repeat,
                #cccccc bottom repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="高溫耐熱線 High Temperature Wire CF-750 MF-5107 TGGT-400 TGGT-5256" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    高溫耐熱線系列
                </div>
                <div class="subtitle">
                    High Temperature Series
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

