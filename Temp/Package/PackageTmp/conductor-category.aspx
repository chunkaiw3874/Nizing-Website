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
            <picture>
                <source srcset="/images/banner/banner-conductor.webp" type="image/webp" />
                <img src="/images/banner/banner-conductor.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div id="divMenuList" runat="server" class="conductor-list row row-cols-1">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

