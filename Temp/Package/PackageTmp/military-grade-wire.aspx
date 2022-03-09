<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="military-grade-wire.aspx.cs" Inherits="military_grade_wire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>軍規電線、軍規電纜-日進電線</title>
    <meta name="keywords" content="船用軍規電纜,軍規電子線" />
    <meta name="description" content="各式軍規線材，MIL-C-24643/23-08軍規船用電纜、MIL-W-22759鐵氟龍軍規電子線等軍規線材">

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/military-grade-wire/background/military-grade-wire.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="軍規線系列 Military Grade Wire and Cable M16878 MIL-DTL-16878 M22759 MIL-DTL-22759 
                M24643 MIL-DTL24643 M27500 MIL-DTL27500 M81822 MIL-DTL81822" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    軍規線系列
                </div>
                <div class="subtitle">
                    Military Grade Wire and Cable Series
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

