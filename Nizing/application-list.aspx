<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDApplicationMaster.master" AutoEventWireup="true" CodeFile="application-list.aspx.cs" Inherits="application_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-application-en.webp" type="image/webp" />
                <img src="/images/banner/banner-application-en.png" alt="電線電纜應用產業 wire and cable application" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="divBackground" runat="server" class="display-block bg-wrapper">
        <div class="title">
            車用配線
        </div>
        <div class="subtitle">
            Automobile
        </div>
        <div class="container">
            <div id="divApplicationItemList" runat="server" class="content row row-cols-2 row-cols-md-4 application-item-list">

            </div>
        </div>
    </div>
</asp:Content>

