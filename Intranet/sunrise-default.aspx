﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/portal-master.master" AutoEventWireup="true" CodeFile="sunrise-default.aspx.cs" Inherits="sunrise_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .list-title li img {
            width: 200px;
        }
        .list-body li input{
            height:30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <%--<a href="sunrise_intranet/SD_PastCostsAndPrices.aspx">業務報價系統</a>--%>
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD_PastCostsAndPrices.png" PostBackUrl="~/sunrise_intranet/SD_PastCostsAndPrices.aspx" /></li>
                <li>
                    <a href="sunrise_intranet/SD01.aspx">車材業績排名表</a>
                    <%--<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD-1.png" PostBackUrl="~/sunrise_intranet/SD01.aspx" />--%></li>
                <li>
                    <a href="sunrise_intranet/SD01Car.aspx">車業業績排名表</a>
                </li>
                <li>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/OrderInProgress.png" PostBackUrl="~/sunrise_intranet/SD03_OrderInProgress.aspx" />
                </li>
            </ul>
        </div>        
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PD.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <%--<a href="/sunrise_employee_section/report/PD_PurchaseInProgress.aspx">採購未交單</a>--%>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PD_PurchaseInProgress.png" PostBackUrl="~/sunrise_intranet/PD_PurchaseInProgress.aspx" />
                </li>
            </ul>
        </div>        
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/IC.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <asp:ImageButton ID="btnInvCheck" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/inventory.png" PostBackUrl="~/sunrise_intranet/InventorySearch.aspx" /></li>
            </ul>
        </div>        
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image4" runat="server" Width="200" ImageUrl="~/nizing_intranet/image/button/dept/INT.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/INT-1.png" PostBackUrl="~/sunrise_intranet/PD_PurchaseCostCalculator.aspx" /></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul class="list-title">
                <li>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/ADM.png" />
                </li>
            </ul>
            <ul class="list-body">            
                <li>
                    <a href="sunrise_intranet/HR04.aspx">面試表</a>
                </li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/ACC.png" /></li>
            </ul>
            <ul>
                <li>
                    <a href="sunrise_intranet/ACC01-Sunrise.aspx">發票開立統計表-日出國際</a>
                </li>
                <li>
                    <a href="sunrise_intranet/ACC01-Sunrize.aspx">發票開立統計表-日出車材</a>
                </li>                    
            </ul>
        </div>
    </div>
</asp:Content>

