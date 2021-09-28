<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDMaterialMaster.master" AutoEventWireup="true" CodeFile="material.aspx.cs" Inherits="material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-材料特性</title>
    <meta name="keywords" content="電線,外被,材料,矽膠,鐵氟龍,塑膠,編織,Wire,Insulation Material,Silicone,Teflon,PVC,Braiding" />
    <style>
        .display-block:last-child {
            padding-bottom: 0;
        }

        .material-list-item {
            margin-bottom: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-materials-en.webp" type="image/webp" />
                <img src="/images/banner/banner-materials-en.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div id="divMenuList" runat="server" class="content material-list row row-cols-1">

                </div>
            </div>
        </div>
    </div>
</asp:Content>

