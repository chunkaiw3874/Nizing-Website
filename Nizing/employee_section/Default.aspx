<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .list-title li img {
            width: 200px;
        }
        .list-body li input {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/employee_section/report/image/button/dept/CHIEF.png" /></li>
            </ul>
            <ul>
                <li><%--<asp:ImageButton ID="btnUnfinishedWorkOrder" runat="server" ImageUrl="~/employee_section/report/image/button/dept/CHIEF-1.png" PostBackUrl="~/employee_section/report/ProductionProgress.aspx" />--%></li>
                <li>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/employee_section/report/image/button/dept/CHIEF-2.png" PostBackUrl="~/employee_section/report/HR08.aspx" /></li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PC.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton8" runat="server" Width="150px" Height="30px" ImageUrl="~/employee_section/report/image/button/dept/PC-4.png" PostBackUrl="~/employee_section/report/PC04.aspx" /></li>
                <li><%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PC-2.png" PostBackUrl="~/employee_section/report/ProductionControlReport.aspx" />--%></li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/employee_section/report/image/button/dept/IC.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="btnInvCheck" runat="server" ImageUrl="~/employee_section/report/image/button/dept/inventory.png" PostBackUrl="~/employee_section/report/InventorySearch.aspx" /></li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/employee_section/report/image/button/dept/M.png" /></li>
            </ul>
            <ul>
                <li><%--<asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/employee_section/report/image/button/dept/M-1.png" PostBackUrl="~/employee_section/report/M01.aspx" />--%></li>
                <li><%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PC-3.png" PostBackUrl="~/employee_section/report/ProductionEfficiencyReport.aspx" />--%></li>
                <li>
                    <asp:ImageButton ID="ImageButton18" runat="server" Width="150px" ImageUrl="~/employee_section/report/image/button/dept/M-3.png" PostBackUrl="~/employee_section/report/M02.aspx" />
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD.png" /></li>
            </ul>
            <ul>
                <li>
                    <asp:ImageButton ID="ImageButton6" runat="server" Width="150" ImageUrl="~/employee_section/report/image/button/dept/SD-7.png" PostBackUrl="~/employee_section/report/quotation-list.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-1.png" PostBackUrl="~/employee_section/report/SD01.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-2.png" PostBackUrl="~/employee_section/report/SaleRecord.aspx" />
                </li>                
                <li>
                    <a href="report/SD_ReceivableReceived.aspx">業務兌現表</a>
                </li>
                <%--<li><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-3.png" PostBackUrl="~/employee_section/report/NewClientReport.aspx" /></li>--%>
                <%--<li><asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-4.png" PostBackUrl="~/employee_section/report/CustomerTransactionReport.aspx" /></li>--%>
                <%--<li><asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD-5.png" PostBackUrl="~/employee_section/report/ABC_Comparison.aspx" /></li>--%>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PD.png" /></li>
            </ul>
            <ul class="list-body">
                <li>
                    <%--<a href="/employee_section/report/PD_PurchaseInProgress.aspx">採購未交單</a>--%>
                    <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PD_PurchaseInProgress.png" PostBackUrl="~/employee_section/report/PD_PurchaseInProgress.aspx" />
                    <%--<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/employee_section/report/image/button/dept/PD-1.png" PostBackUrl="~/employee_section/report/PurchaseReport.aspx" />--%>

                </li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/employee_section/report/image/button/dept/QC.png" /></li>
            </ul>
            <ul>
                <li>
                    <%--<asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/employee_section/report/image/button/dept/QC-1.png" PostBackUrl="~/employee_section/report/QC/QC01.aspx" />--%>                    
                </li>
                <li>
                    <%--<a href="/employee_section/report/QC/scrap/SP_R01.aspx">廢線統計</a>--%>
                </li>
            </ul>
        </div>
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/employee_section/report/image/button/dept/ED.png" /></li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul>
                <li>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/employee_section/report/image/button/dept/HR.png" /></li>
            </ul>
            <ul>
                <li><%--<asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/nizing_intranet/image/button/dept/HR-2.png" PostBackUrl="~/hr360/login.aspx" />--%></li>
                <%--<li><a href="../nizing_intranet/SalaryChangeReport.aspx">薪資異動報表</a></li>--%>
                <%--<li><a href="../nizing_intranet/EmployeeDayOff.aspx">員工特休查詢</a></li>--%>
                <li>
                    <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/employee_section/report/image/button/dept/HR-3.png" PostBackUrl="~/employee_section/report/EmployeeDayOffReport.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/employee_section/report/image/button/dept/HR-4.png" PostBackUrl="~/employee_section/report/WorkDuration.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/employee_section/report/image/button/dept/HR-5.png" PostBackUrl="~/employee_section/report/HR05.aspx" /></li>
                <li>
                    <asp:ImageButton ID="ImageButton3" runat="server" Width="150px" ImageUrl="~/employee_section/report/image/button/dept/HR-8.png" PostBackUrl="~/employee_section/report/HR09.aspx" /></li>
                <li><a href="/employee_section/report/HR04.aspx">面試表</a></li>
                <li><a href="/employee_section/report/HR06.aspx">考核成績表</a></li>
                <li><a href="/employee_section/report/HR07.aspx">Annual Report</a></li>
            </ul>
        </div>
        
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
            <ul class="list-title">
                <li>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/employee_section/report/image/button/dept/ADM.png" />
                </li>
            </ul>
            <ul class="list-body">                
                <li>
                    <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/employee_section/report/image/button/dept/ADM-01.png" PostBackUrl="~/employee_section/report/SD_SalesBonusCalculator.aspx" />
                </li>
                <li>
                    <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/employee_section/report/image/button/dept/ADM-02.png" PostBackUrl="~/employee_section/report/SD_ProfitMarginByProductReport.aspx" />
                </li>
                <li>
                    <a href="report/GoOutReport.aspx">外出報告</a>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
