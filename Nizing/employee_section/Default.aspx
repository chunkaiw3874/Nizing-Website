<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage2021.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        ul {
            list-style: none;
        }

        .img{
            display:block;
        }

        .col .title .img {
            width: 200px;
        }

        .col .list .img {
            height: 30px;
            margin-bottom:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4">
            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image1" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/CHIEF.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton2" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/CHIEF-2.png" PostBackUrl="~/employee_section/report/HR08.aspx" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image6" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/PC.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton8" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/PC-4.png" PostBackUrl="~/employee_section/report/PC04.aspx" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image2" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/IC.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="btnInvCheck" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/inventory.png" PostBackUrl="~/employee_section/report/InventorySearch.aspx" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image7" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/M.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton18" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/M-3.png" PostBackUrl="~/employee_section/report/M02.aspx" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/employee_section/report/image/button/dept/SD.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton6" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/SD-7.png" PostBackUrl="~/employee_section/report/quotation-list.aspx" />
                    <asp:ImageButton ID="ImageButton4" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/SD-1.png" PostBackUrl="~/employee_section/report/SD01.aspx" />
                    <asp:ImageButton ID="ImageButton5" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/SD-2.png" PostBackUrl="~/employee_section/report/SaleRecord.aspx" />
                    <div>
                        <a href="report/SD02_KeyInFormAmount.aspx">打單數量報表</a>
                    </div>
                    <div>
                        <a href="report/SD_ReceivableReceived.aspx">業務兌現表</a>
                    </div>
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image4" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/PD.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton7" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/PD_PurchaseInProgress.png" PostBackUrl="~/employee_section/report/PD_PurchaseInProgress.aspx" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image9" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/QC.png" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image8" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/ED.png" />
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image5" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/HR.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton12" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/HR-3.png" PostBackUrl="~/employee_section/report/EmployeeDayOffReport.aspx" />
                    <asp:ImageButton ID="ImageButton13" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/HR-4.png" PostBackUrl="~/employee_section/report/WorkDuration.aspx" />
                    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/HR-5.png" PostBackUrl="~/employee_section/report/HR05.aspx" />
                    <asp:ImageButton ID="ImageButton3" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/HR-8.png" PostBackUrl="~/employee_section/report/HR09.aspx" />
                    <div>
                        <a href="/employee_section/report/HR04.aspx">面試表</a>
                    </div>
                    <div>
                        <a href="/employee_section/report/HR06.aspx">考核成績表</a>
                    </div>
                    <div>
                        <a href="/employee_section/report/HR07.aspx">Annual Report</a>
                    </div>
                </div>
            </div>

            <div class="col mb-4">
                <div class="title mb-2">
                    <asp:Image ID="Image10" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/ADM.png" />
                </div>
                <div class="list">
                    <asp:ImageButton ID="ImageButton9" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/ADM-01.png" PostBackUrl="~/employee_section/report/ADM_SalesBonusCalculator.aspx" />
                    <asp:ImageButton ID="ImageButton10" runat="server" CssClass="img"
                        ImageUrl="~/employee_section/report/image/button/dept/ADM-02.png" PostBackUrl="~/employee_section/report/SD_ProfitMarginByProductReport.aspx" />
                    <div>
                        <a href="report/GoOutReport.aspx">外出報告</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
