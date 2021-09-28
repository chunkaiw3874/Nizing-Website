<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDCompanyMaster.master" AutoEventWireup="true" CodeFile="company-lab.aspx.cs" Inherits="company_lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <picture>
                <source srcset="/images/banner/banner-lab-en.webp" type="image/webp" />
                <img src="/images/banner/banner-lab-en.png" />
            </picture>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper">
        <div class="display-block">
            <div class="container">
                <div class="title">
                    實驗室
                </div>
                <div class="subtitle">
                    LAB
                </div>
            </div>
        </div>
    </div>
</asp:Content>

