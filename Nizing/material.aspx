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
            <img src="images/banner/banner-materials-en-1920x500.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div class="content material-list row row-cols-1">
                    <div class="col material-list-wrapper">
                        <div class="material-list-item move">
                            <a href="conductor-category.aspx" class="card-link">
                                <img src="images/material/材料特性-導體系列.png" class="shadow" alt="電線導體 Conductor" />
                            </a>
                        </div>
                    </div>
                    <div class="col material-list-wrapper">
                        <div class="material-list-item move">
                            <a href="silicone.aspx" class="card-link">
                                <img src="images/material/材料特性-矽膠原料.png" class="shadow" alt="電線外被材質 矽膠 Silicone" />
                            </a>
                        </div>
                    </div>
                    <div class="col material-list-wrapper">
                        <div class="material-list-item move">
                            <a href="teflon.aspx" class="card-link">
                                <img src="images/material/材料特性-鐵氟龍材料.png" class="shadow" alt="電線外被材質 鐵氟龍 Teflon" />
                            </a>
                        </div>
                    </div>
                    <div class="col material-list-wrapper">
                        <div class="material-list-item move">
                            <a href="plastic.aspx" class="card-link">
                                <img src="images/material/材料特性-塑膠原料.png" class="shadow" alt="電線外被材質 塑膠 PVC" />
                            </a>
                        </div>
                    </div>
                    <div class="col material-list-wrapper">
                        <div class="material-list-item move">
                            <a href="twinning.aspx" class="card-link">
                                <img src="images/material/材料特性-編織.png" class="shadow" alt="電線外被編織材質 Braiding" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

