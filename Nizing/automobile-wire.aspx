<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="automobile-wire.aspx.cs" Inherits="automobile_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>汽車花線-日進電線</title>
    <meta name="keywords" content="日規汽車花線,美規汽車花線,歐規汽車花線" />
    <meta name="description" content="各種規格，符合規範的日規汽車花線、美規汽車花線、及歐規汽車花線">

    <style type="text/css">
        .product-category .bg-wrapper {
            /*background-image: url('/images/product/automobile-wire/background/automobile-wire.jpg');*/
            background: url('/images/product/automobile-wire/background/automobile-wire.jpg') top / contain no-repeat,
                #cccccc bottom repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="汽車花線 Autobobile Wire and Cable JASO SAE ISO" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    汽車花線系列
                </div>
                <div class="subtitle">
                    Automobile Wire Series
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

