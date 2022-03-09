<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDProductMaster.master" AutoEventWireup="true" CodeFile="tube.aspx.cs" Inherits="tube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>套管、絕緣-日進電線</title>
    <meta name="keywords" content="矽膠套管,玻璃纖維套管,鐵氟龍套管,絕緣保護" />
    <meta name="description" content="各式套管、包含UL HST、UL FRS、UL SRG、各式鐵氟龍套管、矽膠套管、玻璃纖維套管，提供最適當的絕緣保護">

    <style type="text/css">
        .product-category .bg-wrapper {
            background-image: url('/images/product/tube/background/tube.jpg');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-product-en.png"
                alt="套管系列 Sleeve and Tube Series ULHST ULFRS ULSSG ULSRG Silicone Tube PFA Tube
                FEP Tube PTFE Tube" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper product-category">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    套管系列
                </div>
                <div class="subtitle">
                    Sleeve and Tube Series
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

