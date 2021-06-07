<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDConductorMaster.master" AutoEventWireup="true" CodeFile="conductor-category.aspx.cs" Inherits="conductor_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-合金導體</title>
    <style>
        .display-block:last-child {
            padding-bottom: 0;
        }

        .conductor-list-item {
            box-shadow: 10px 10px 10px 0 rgba(0, 0, 0, 0.5);
            margin-bottom: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
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
                <div class="conductor-list row row-cols-1">
                    <div class="col conductor-list-wrapper">
                        <div class="conductor-list-item">
                            <a href="copper.aspx" class="card-link">
                                <img src="images/material/conductor/合金導體-純銅系列.png" class="w-100" />
                            </a>
                        </div>
                    </div>
                    <div class="col conductor-list-wrapper">
                        <div class="conductor-list-item">
                            <a href="agcu.aspx" class="card-link">
                                <img src="images/material/conductor/合金導體-銀銅合金.png" class="w-100" />
                            </a>
                        </div>
                    </div>
                    <div class="col conductor-list-wrapper">
                        <div class="conductor-list-item move">
                            <a href="sncu.aspx" class="card-link">
                                <img src="images/material/conductor/合金導體-錫銅合金.png" class="w-100" />
                            </a>
                        </div>
                    </div>
                    <div class="col conductor-list-wrapper">
                        <div class="conductor-list-item">
                            <a href="nicu.aspx" class="card-link">
                                <img src="images/material/conductor/合金導體-鎳銅合金.png" class="w-100" />
                            </a>
                        </div>
                    </div>
                    <div class="col conductor-list-wrapper">
                        <div class="conductor-list-item">
                            <a href="ag.aspx" class="card-link">
                                <img src="images/material/conductor/合金導體-純銀與銀合金.png" class="w-100" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

