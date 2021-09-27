<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="application" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>應用產業-日進電線</title>
    <meta name="description" content="日進電線持續與最頂尖的新科技接軌，持續研發，滿足各種客製需求">

    <style type="text/css">
        .display-block::before {
            content: "";
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            opacity: 0.4;
            z-index: -1;
            background-size: cover;
        }

        .webp .display-block::before {
            background-image: url('/images/application/background/bg-application.webp');
        }

        .no-webp .display-block::before {
            background-image: url('/images/application/background/bg-application.jpg');
        }

        .display-block {
            position: relative;
            z-index: 1;
        }

        .overlay-parent {
            min-height: 100%;
            margin: 0px;
        }

        .opacity-100 {
            opacity: 1 !important;
        }

        .bg-skyblue .title {
            mix-blend-mode: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-application-en.webp" type="image/webp" />
                <img src="/images/banner/banner-application-en.png" alt="電線電纜應用產業 wire and cable application" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper application-category-list">
        <section class="display-block bg-wrapper">
            <div class="title">
                應用產業
            </div>
            <div class="subtitle">
                PRODUCT APPLICATION
            </div>
            <div class="container-fluid">
                <div class="container">
                    <div id="divItemList" runat="server" class="content row row-cols-2 row-cols-md-3 row-cols-lg-4 application-list">
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

