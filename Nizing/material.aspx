<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDMaterialMaster.master" AutoEventWireup="true" CodeFile="material.aspx.cs" Inherits="material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-材料特性</title>
    <meta name="keywords" content="電線,外被,材料,矽膠,鐵氟龍,塑膠,編織,Wire,Insulation Material,Silicone,Teflon,PVC,Braiding" />
    <style>
        .display-block:last-child {
            padding-bottom: 0;
        }

        .material-list-item {
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/materialMaster2021.master" AutoEventWireup="true" CodeFile="material.aspx.cs" Inherits="material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-材料特性</title>
    <style>
        .material-list-item {
            box-shadow: 10px 10px 10px 0 rgba(0, 0, 0, 0.5);
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
            margin-bottom: 30px;
        }
    </style>
</asp:Content>
<<<<<<< HEAD
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
=======
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="material-list row row-cols-1">
            <div class="col material-list-wrapper">
                <div class="material-list-item move">
                    <a href="conductor-category.aspx" class="card-link">
                        <img src="/images/material/材料特性-導體系列.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col material-list-wrapper">
                <div class="material-list-item move">
                    <a href="silicone.aspx" class="card-link">
                        <img src="/images/material/材料特性-矽膠原料.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col material-list-wrapper">
                <div class="material-list-item move">
                    <a href="teflon.aspx" class="card-link">
                        <img src="/images/material/材料特性-鐵氟龍材料.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col material-list-wrapper">
                <div class="material-list-item move">
                    <a href="plastic.aspx" class="card-link">
                        <img src="/images/material/材料特性-塑膠原料.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col material-list-wrapper">
                <div class="material-list-item move">
                    <a href="twinning.aspx" class="card-link">
                        <img src="/images/material/材料特性-編織.png" class="img w-100" />
                    </a>
>>>>>>> 92aa7e2a76567558931eaa2d6e25a676875dc4bc
                </div>
            </div>
        </div>
    </div>
</asp:Content>

