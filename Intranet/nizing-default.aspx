﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/portal-master.master" AutoEventWireup="true" CodeFile="nizing-default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .list-body li input {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="btnUnfinishedWorkOrder" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF-1.png" PostBackUrl="~/nizing_intranet/ProductionProgress.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton16" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF-2.png" PostBackUrl="~/nizing_intranet/HR08.aspx" /></li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PC.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PC-1.png" PostBackUrl="~/nizing_intranet/ProductionProgress_Dept.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PC-2.png" PostBackUrl="~/nizing_intranet/ProductionControlReport.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton17" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PC-4.png" Width="150px" Height="30px" PostBackUrl="~/nizing_intranet/PC04.aspx" /></li>
<%--                <li>
                    <a href="/nizing_intranet/PC03.aspx">RSGE/3122預計出貨報表</a>
                </li>--%>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/IC.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="btnInvCheck" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/inventory.png" PostBackUrl="~/nizing_intranet/InventorySearch.aspx" /></li>
                <li>
                    <a href="nizing_intranet/IC_DailyProductPreparationList.aspx">每日備貨明細表</a>
                </li>
            </ul>            
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/M.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/M-1.png" PostBackUrl="~/nizing_intranet/M01.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton2" runat="server" Width="150px" ImageUrl="~/nizing_intranet/image/button/dept/M-2.png" PostBackUrl="~/nizing_intranet/ProductionEfficiencyReport.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton18" runat="server" Width="150px" ImageUrl="~/nizing_intranet/image/button/dept/M-3.png" PostBackUrl="~/nizing_intranet/M02.aspx" /></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton20" runat="server" Width="150px" ImageUrl="~/nizing_intranet/image/button/dept/SD-7.png" PostBackUrl="~/nizing_intranet/quotation-list.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD-1.png" PostBackUrl="~/nizing_intranet/SD01.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD-2.png" PostBackUrl="~/nizing_intranet/SaleRecord.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD-3.png" PostBackUrl="~/nizing_intranet/NewClientReport.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD-4.png" PostBackUrl="~/nizing_intranet/CustomerTransactionReport.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/SD-5.png" PostBackUrl="~/nizing_intranet/ABC_Comparison.aspx" /></li>
                <li><a href="nizing_intranet/SD02_KeyInFormAmount.aspx">打單數量報表</a></li>
                <li><a href="nizing_intranet/SD_ReceivableReceived.aspx">業務兌現表</a></li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PD.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <asp:ImageButton ID="ImageButton3" runat="server" Width="150px" ImageUrl="~/nizing_intranet/image/button/dept/PD-1.png" PostBackUrl="~/nizing_intranet/PurchaseReport.aspx" /></li>

                <li>
                    <asp:ImageButton ID="ImageButton21" runat="server" Width="150px" ImageUrl="~/nizing_intranet/image/button/dept/PD-3.png" PostBackUrl="~/nizing_intranet/PD03_RawMatsUsage.aspx" /></li>
                <li>
                    <a href="nizing_intranet/PD02_NetSpending.aspx">廠商進貨金額表</a>
                </li>
                <li>
                    <%--<a href="nizing_intranet/PD_PurchaseInProgress.aspx">採購未交單</a>--%>
                    <asp:ImageButton ID="ImageButton22" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/PD_PurchaseInProgress.png" PostBackUrl="~/nizing_intranet/PD_PurchaseInProgress.aspx" />
                </li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/QC.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/QC-1.png" PostBackUrl="~/QC/QC01.aspx" />
                </li>
                <li>
                    <a href="/QC/QC02.aspx">退貨報表</a>
                </li>
                <li>
                    <a href="/QC/scrap/SP_R01.aspx">廢線統計</a>
                </li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/ED.png" /></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/HR.png" /></li>
            </ul>
            <ul>
                <li><%--<asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/HR-2.png" PostBackUrl="~/hr360/login.aspx" />--%></li>
                <%--<li><a href="../nizing_intranet/SalaryChangeReport.aspx">薪資異動報表</a></li>--%>
                <%--<li><a href="../nizing_intranet/EmployeeDayOff.aspx">員工特休查詢</a></li>--%>
                <li>
                    <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/HR-3.png" PostBackUrl="~/nizing_intranet/EmployeeDayOffReport.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/HR-4.png" PostBackUrl="~/nizing_intranet/WorkDuration.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/HR-5.png" PostBackUrl="~/nizing_intranet/HR05.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton19" runat="server" Width="150px" ImageUrl="~/nizing_intranet/image/button/dept/HR-8.png" PostBackUrl="~/nizing_intranet/HR09.aspx" /></li>
                <li><a href="nizing_intranet/HR04.aspx">面試表</a></li>
                <li><a href="nizing_intranet/HR06.aspx">考核成績表</a></li>
                <li><a href="nizing_intranet/HR07.aspx">Annual Report</a></li>
                <li><%--<a href="backend_program/NIZING_BACKEND_Data_Config.application">test</a>--%></li>

            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/ACC.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton15" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/ACC-1.png" PostBackUrl="~/nizing_intranet/ACC01.aspx" /></li>
            </ul>
        </div>
    </div>
</asp:Content>

