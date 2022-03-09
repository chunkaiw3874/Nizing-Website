<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="portal.aspx.cs" Inherits="portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .display-block img {
            width: 100%;
        }

        .display-block .col {
            padding-bottom: 1.5rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
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
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div class="row row-cols-2 row-cols-md-3 row-cols-lg-4 row-cols-xl-5">
                    <div class="col">
                        <a href="/hr360/mobile/login.aspx" target="_blank">
                            <img src="/images/employee_section/portal/HR360.png" /></a>
                    </div>
                    <div class="col">
                        <a href="/employee_section/Default.aspx" target="_blank">
                            <img src="/images/employee_section/portal/NEW-new.png" /></a>
                    </div>
                    <div class="col">
                        <a href="/revivify_employee_section/Default.aspx" target="_blank">
                            <img src="/images/employee_section/portal/RVI.png" /></a>
                    </div>
                    <div class="col">
                        <a href="/neo_employee_section/Default.aspx" target="_blank">
                            <img src="/images/employee_section/portal/NEO.png" /></a>
                    </div>
                    <div class="col">
                        <a href="/sunrise_employee_section/Default.aspx" target="_blank">
                            <img src="/images/employee_section/portal/SUNRISE.png" /></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

