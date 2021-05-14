<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="ADM_SalesBonusCalculator.aspx.cs" Inherits="employee_section_report_ADM_SalesBonusCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .scrollbox-500 {
            height: auto;
            max-height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="mb-3">
            <h2>業績獎金計算作業</h2>
        </div>
        <div id="Parameter" class="border-bottom mb-3 pb-3">
            <div class="input-group mb-1">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="custom-select"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="RefreshData">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="custom-select"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="RefreshData">
                </asp:DropDownList>
            </div>
            <div class="input-group mb-1">
                <div class="input-group-prepend">
                    <span class="input-group-text">業務員</span>
                </div>
                <asp:DropDownList ID="ddlSales" runat="server" CssClass="custom-select" AutoPostBack="true"
                    OnSelectedIndexChanged="RefreshData">
                </asp:DropDownList>
            </div>
        </div>
        <div id="AdminInput" runat="server" class="border-bottom mb-3 pb-3">
            <div class="row">
                <div class="col-md-6">
                    <asp:UpdatePanel ID="upBonusPercentageData" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlYear" />
                            <asp:AsyncPostBackTrigger ControlID="ddlMonth" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveBonusPercent" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Label ID="lblBonusPercentageTimeframe" runat="server" CssClass="h5" Text=""></asp:Label>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">新客獎金成數(%)</span>
                                </div>
                                <asp:TextBox ID="txtNewCustomerBonusPercent" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">舊客獎金成數(%)</span>
                                </div>
                                <asp:TextBox ID="txtOldCustomerBonusPercent" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnSaveBonusPercent" runat="server" Text="更新獎金成數" CssClass="btn btn-success"
                                OnClick="btnSaveBonusPercent_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="upOldCustomerExceptionData" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlYear" />
                            <asp:AsyncPostBackTrigger ControlID="ddlMonth" />
                            <asp:AsyncPostBackTrigger ControlID="ddlSales" />
                            <asp:AsyncPostBackTrigger ControlID="btnRemoveFromExceptionList" />
                            <asp:AsyncPostBackTrigger ControlID="btnAddToExceptionList" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Label ID="lblCustomerExceptionTimeframe" runat="server" CssClass="h5" Text=""></asp:Label>
                            <div class="input-group mb-1">
                                <asp:TextBox ID="txtCustomersToAddToExceptionList" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="btnAddToExceptionList" runat="server" Text="加入例外清單" CssClass="btn btn-success"
                                        OnClick="btnAddToExceptionList_Click"/>
                                </div>
                            </div>
                            <asp:ListBox ID="lstExceptionList" runat="server" CssClass="custom-select mb-1"></asp:ListBox>
                            <asp:Button ID="btnRemoveFromExceptionList" runat="server" Text="移除" CssClass="btn btn-success full-width"
                                OnClick="btnRemoveFromExceptionList_Click"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="mb-2">
            <asp:UpdatePanel ID="upBonusDataDisplay" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlYear" />
                    <asp:AsyncPostBackTrigger ControlID="ddlMonth" />
                    <asp:AsyncPostBackTrigger ControlID="ddlSales" />
                    <asp:AsyncPostBackTrigger ControlID="btnSaveBonusPercent" />
                    <asp:AsyncPostBackTrigger ControlID="btnRemoveFromExceptionList" />
                    <asp:AsyncPostBackTrigger ControlID="btnAddToExceptionList" />
                </Triggers>
                <ContentTemplate>
                    <div>
                        <asp:Label ID="lblPersonnelAndTimeframeDescription" runat="server" CssClass="h5 mb-1" Text=""></asp:Label>
                        <asp:Label ID="lblTotalSalesBonus" runat="server" CssClass="h5" Text="Label"></asp:Label>
                    </div>
                    <span>新客</span>
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">獎金成數</span>
                        </div>
                        <asp:Label ID="lblNewCustomerBonusPercent" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text">%</span>
                        </div>
                    </div>
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">銷售淨額</span>
                        </div>
                        <asp:Label ID="lblNewCustomerTotalSales" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text">NTD</span>
                        </div>
                    </div>
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">獎金小記</span>
                        </div>
                        <asp:Label ID="lblNewCustomerSalesBonus" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text">NTD</span>
                        </div>
                    </div>
                    <div class="table-responsive scrollbox-500 mb-2">
                        <asp:GridView ID="gvSalesBonusDisplayNew" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover table-striped-blue"
                            EmptyDataText="查詢期間無資料">
                            <Columns>
                                <asp:TemplateField HeaderText="銷售年月">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("銷售年月") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶代號">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("客戶代號") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶簡稱">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("客戶簡稱") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="銷售淨額">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSales" runat="server" Text='<%#Eval("銷售淨額") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶屬性">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Convert.ToInt32(Eval("客戶屬性"))==1?"舊客":"新客" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶建立日期">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("客戶建立日期") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <span>舊客</span>
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">獎金成數</span>
                        </div>
                        <asp:Label ID="lblOldCustomerBonusPercent" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text">%</span>
                        </div>
                    </div>
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">銷售淨額</span>
                        </div>
                        <asp:Label ID="lblOldCustomerTotalSales" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text">NTD</span>
                        </div>
                    </div>
                    <div class="input-group mb-1">
                        <div class="input-group-prepend">
                            <span class="input-group-text">獎金小記</span>
                        </div>
                        <asp:Label ID="lblOldCustomerSalesBonus" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text">NTD</span>
                        </div>
                    </div>
                    <div class="table-responsive scrollbox-500 mb-2">
                        <asp:GridView ID="gvSalesBonusDisplayOld" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover table-striped-blue"
                            EmptyDataText="查詢期間無資料">
                            <Columns>
                                <asp:TemplateField HeaderText="銷售年月">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("銷售年月") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶代號">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("客戶代號") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶簡稱">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("客戶簡稱") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="銷售淨額">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSales" runat="server" Text='<%#Eval("銷售淨額") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶屬性">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Convert.ToInt32(Eval("客戶屬性"))==1?"舊客":"新客" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶建立日期">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("客戶建立日期") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

