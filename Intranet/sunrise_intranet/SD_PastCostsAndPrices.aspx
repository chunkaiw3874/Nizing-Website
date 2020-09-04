<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/sunrise-master.master" AutoEventWireup="true" CodeFile="SD_PastCostsAndPrices.aspx.cs" Inherits="sunrise_employee_section_report_SD_PastCostsAndPrices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            margin-bottom: 20px;
        }

        .scrollable-table {
            max-width: 100%;
            max-height: 225px;
            overflow: auto;
        }

        th {
            text-align: center;
        }

        text-center {
            text-align: center;
        }

        table th:hover {
            cursor: context-menu;
        }

        table td:hover {
            cursor: pointer;
        }

        .section-end {
            /*border-bottom: solid 1px #ff9595;
            margin-bottom: 15px;*/
        }

        .form-inline > .col-sm-3:first-child {
            padding-left: 0;
        }

        @media screen and (min-width: 992px) {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnIdSearch">
        <div class="form-row">
            <h2>業務報價系統</h2>
        </div>
        <div id="ParameterInputs" class="section-end">
            <div class="form-row">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">品號</span>
                    </div>
                    <asp:TextBox ID="txtItemId" runat="server" CssClass="form-control"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="btnIdSearch" runat="server" CssClass="btn btn-outline-success" Text="查詢品號" OnClick="btnItemSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="form-row">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">品名</span>
                    </div>
                    <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="btnNameSearch" runat="server" CssClass="btn btn-outline-success" Text="查詢品名" OnClick="btnItemSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="form-row">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">規格</span>
                    </div>
                    <asp:TextBox ID="txtItemSpec" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-row form-inline">
                <div class="col-sm-3">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">庫存</span>
                        </div>
                        <asp:TextBox ID="txtInvAmount" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">平均成本</span>
                        </div>
                        <asp:TextBox ID="txtInvAvgCost" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <asp:UpdatePanel ID="upItemListTable" runat="server">
            <ContentTemplate>
                <div id="ItemList" class="section-end">
                    <div class="scrollable-table">
                        <asp:GridView ID="gvItemList" runat="server" CssClass="table table-striped table-hover table-dark table-sm"
                            AutoGenerateColumns="false"
                            OnSelectedIndexChanged="gvItemList_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemStyle CssClass="text-center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNo" runat="server" Text='<%#Eval("no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="品號">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("itemId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="品名">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("itemName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="規格">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemSpec" runat="server" Text='<%#Eval("itemSpec") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="庫存">
                                    <ItemStyle CssClass="text-center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemInv" runat="server" Text='<%#Eval("inv") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="單位">
                                    <ItemStyle CssClass="text-center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemUnit" runat="server" Text='<%#Eval("itemUnit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="平均成本">
                                    <ItemStyle CssClass="text-center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvAvgCost" runat="server" Text='<%#Eval("invAvgCost") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="gvItemList" />
            </Triggers>
        </asp:UpdatePanel>
        <hr />
        <div id="PastRecords">
            <div class="form-row">
                <div class="col-lg-6">
                    <asp:GridView ID="gvSaleRecord" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="false"
                        OnRowCreated="gvSaleRecord_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="日期">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("saleDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="客戶">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("customerName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="單價">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("unitPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="數量">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("saleAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-lg-6">
                    <asp:GridView ID="gvPurchaseRecord" runat="server" CssClass="table table-striped table-dark"
                        AutoGenerateColumns="false"
                        OnRowCreated="gvPurchaseRecord_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="日期">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("purchaseDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="廠商">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("supplierName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="單價">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("unitPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="數量">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("purchaseAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

