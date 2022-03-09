<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="composite-cable.aspx.cs" Inherits="composite_cable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>客製線、冷媒線-日進電線</title>
    <meta name="keywords" content="客製電線,冷媒線" />
    <meta name="description" content="各式客製特殊線材，有一般冷凍壓縮馬達使用的UL5048冷媒線、及其他各類客製電線">
    <link href="/css/RWD-ProductCategory.css" rel="stylesheet" />

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/composite-cable/background/composite-cable.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="複合線 Composite Cable" />
        </div>
    </div>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    複合線系列
                </div>
                <div class="subtitle">
                    Composite Cable Series
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

