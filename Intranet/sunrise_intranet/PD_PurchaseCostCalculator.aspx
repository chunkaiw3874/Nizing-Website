<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/sunrise-master.master" AutoEventWireup="true" CodeFile="PD_PurchaseCostCalculator.aspx.cs" Inherits="sunrise_intranet_PD_PurchaseCostCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        th {
            text-align: center;
        }

        .text-enabled[readonly] {
            background-color: white;
        }

        .scrollable-table {
            max-width: 100%;
            max-height: 500px;
            overflow: auto;
            margin-bottom: 20px;
            /*border: solid 1px #000000;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="form-group">
            <h2>採購單費用計算機</h2>
        </div>
        <div class="form-group">
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">採購單號</span>
                </div>
                <asp:DropDownList ID="ddlPurchaseFormType" CssClass="custom-select" runat="server"></asp:DropDownList>
                <asp:TextBox ID="txtPurchaseFormId" CssClass="form-control" runat="server"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="btnSearchPurchaseForm" runat="server" CssClass="btn btn-success" Text="查詢單號"
                        OnClick="btnSearchPurchaseForm_Click" />
                </div>
            </div>
        </div>
        <hr />
        <asp:UpdatePanel ID="upCalculationParameter" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchPurchaseForm" />
                <asp:AsyncPostBackTrigger ControlID="btnCalculateTotalCost" />
            </Triggers>
            <ContentTemplate>
                <div class="form-group">
                    <div class="row mb-2">
                        <div class="col-lg-6">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">採購單匯率</span>
                                    <asp:Label ID="lblPurchaseFormCurrency" runat="server" CssClass="input-group-text" Text=""></asp:Label>
                                </div>
                                <asp:TextBox ID="txtPurchaseFormExchangeRate" runat="server" CssClass="form-control text-enabled" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">報關單匯率</span>
                                    <asp:Label ID="lblImportFormCurrency" runat="server" CssClass="input-group-text" Text=""></asp:Label>
                                </div>
                                <asp:TextBox ID="txtImportFormExchangeRate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-lg-3">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">運費</span>
                                </div>
                                <asp:TextBox ID="txtTransportCost" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Label ID="lblTransportCostPercent" runat="server" CssClass="input-group-text" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">推廣貿易費</span>
                                </div>
                                <asp:TextBox ID="txtPromotionCost" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Label ID="lblPromotionCostPercent" runat="server" CssClass="input-group-text" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">關稅</span>
                                </div>
                                <asp:TextBox ID="txtImportTax" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Label ID="lblImportTaxPercent" runat="server" CssClass="input-group-text" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">其他費用</span>
                                </div>
                                <asp:TextBox ID="txtOtherCost" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Label ID="lblOtherCostPercent" runat="server" CssClass="input-group-text" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="input-group">
                        <asp:Button ID="btnCalculateTotalCost" runat="server" CssClass="btn btn-success form-control" Text="計算費用"
                            OnClick="btnCalculateTotalCost_Click" />
                    </div>
                </div>

                <div class="input-group mb-2">
                    <div class="input-group-prepend">
                        <span class="input-group-text">採購單總費用</span>
                    </div>
                    <asp:Label ID="lblTotalNonMaterialCost" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="scrollable-table">
            <asp:UpdatePanel ID="upData" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearchPurchaseForm" />
                    <asp:AsyncPostBackTrigger ControlID="btnCalculateTotalCost" />
                </Triggers>
                <ContentTemplate>
                    <asp:GridView ID="gvPurchaseForm" runat="server"
                        CssClass="table table-striped table-hover table-white"
                        AutoGenerateColumns="false"
                        OnPreRender="gvPurchaseForm_PreRender">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblItemNo" runat="server" Text='<%#Eval("序號") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnTotalMaterialCostBeforeTax" runat="server" Value='<%#Eval("未稅採購金額") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品號">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("品號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("品名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="規格">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemSpec" runat="server" Text='<%#Eval("規格") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單價">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemUnitCost" runat="server" Text='<%#Eval("單價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="數量">
                                <ItemTemplate>
                                    <asp:Label ID="lblPurchasedAmount" runat="server" Text='<%#Eval("數量") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="總價">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemTotalCost" runat="server" Text='<%#Eval("總價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="費用<br/>(NTD)">
                                <ItemTemplate>
                                    <asp:Label ID="lblCostExcludeMaterial" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

