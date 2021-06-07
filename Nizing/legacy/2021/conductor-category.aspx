<%@ Page Title="" Language="C#" MasterPageFile="~/master/conductorMaster2021.master" AutoEventWireup="true" CodeFile="conductor-category.aspx.cs" Inherits="conductor_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-合金導體</title>
    <style>
        .conductor-list-item {
            box-shadow: 10px 10px 10px 0 rgba(0, 0, 0, 0.5);
            margin-bottom: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="conductor-list row row-cols-1">
            <div class="col conductor-list-wrapper">
                <div class="conductor-list-item move">
                    <a href="copper.aspx" class="card-link">
                        <img src="/images/material/conductor/合金導體-純銅系列.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col conductor-list-wrapper">
                <div class="conductor-list-item move">
                    <a href="agcu.aspx" class="card-link">
                        <img src="/images/material/conductor/合金導體-銀銅合金.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col conductor-list-wrapper">
                <div class="conductor-list-item move">
                    <a href="sncu.aspx" class="card-link">
                        <img src="/images/material/conductor/合金導體-錫銅合金.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col conductor-list-wrapper">
                <div class="conductor-list-item move">
                    <a href="ag.aspx" class="card-link">
                        <img src="/images/material/conductor/合金導體-純銀與銀合金.png" class="img w-100" />
                    </a>
                </div>
            </div>
            <div class="col conductor-list-wrapper">
                <div class="conductor-list-item move">
                    <a href="nicu.aspx" class="card-link">
                        <img src="/images/material/conductor/合金導體-鎳銅合金.png" class="img w-100" />
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

