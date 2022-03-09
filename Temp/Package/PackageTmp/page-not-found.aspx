<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="page-not-found.aspx.cs" Inherits="page_not_found" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .breadcrumb {
            display:none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-home-mobile.webp" media="(max-width:767px)" type="image/webp" />
                <source srcset="/images/banner/banner-home.webp" type="image/webp" />
                <source srcset="/images/banner/banner-home-mobile.jpg" media="(max-width:767px)" />
                <img src="/images/banner/banner-home.jpg" alt="日進電線電纜 Nizing Electric Wire and Cable" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="container-fluid">
        <img src="/images/placeholder/404-page-not-found.png" />
    </div>
</asp:Content>

