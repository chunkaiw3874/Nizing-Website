<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/sunrise-master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .list-body li input{
            width:150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-1.png" PostBackUrl="~/sunrise_employee_section/report/SD01.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/employee_section/report/image/button/dept/OrderInProgress.png" PostBackUrl="~/sunrise_employee_section/report/SD03_OrderInProgress.aspx" />
                </li>
            </ul>
        </div>        
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PD.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <a href="/sunrise_employee_section/report/PD_PurchaseInProgress.aspx">採購未交單</a>
                    <%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/employee_section/report/image/button/dept/inventory.png" PostBackUrl="~/sunrise_employee_section/report/InventorySearch.aspx" />--%>
                </li>
            </ul>
        </div>        
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/employee_section/report/image/button/dept/IC.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <asp:ImageButton ID="btnInvCheck" runat="server" ImageUrl="~/employee_section/report/image/button/dept/inventory.png" PostBackUrl="~/sunrise_employee_section/report/InventorySearch.aspx" /></li>
            </ul>
        </div>
    </div>
</asp:Content>
