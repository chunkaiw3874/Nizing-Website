<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/sunrise-master.master" AutoEventWireup="true" CodeFile="SD03_OrderInProgress.aspx.cs" Inherits="sunrise_employee_section_report_SD03_OrderInProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" integrity="sha384-1CmrxMRARb6aLqgBO7yyAxTOQE2AKb9GfXnEo760AUcUmFx3ibVJJAzGytlQcNXd" crossorigin="anonymous"></script>
    <style>
        .custom-select {
            height: 30px;
        }
        th {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="NetSale" class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h2>未交單明細表</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">產品分類選擇</label>
                    </div>
                    <asp:DropDownList ID="ddlCategoryOne" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryOne_SelectedIndexChanged"></asp:DropDownList>
                    <%--<div class="input-group-append">
                                <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-outline-success" />
                            </div>--%>
                </div>
            </div>
        </div>
        <hr />
        <div id="OutputField">
            <div id="search-result">
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvReport" runat="server" CssClass="grdResultWithFooter" HorizontalAlign="Center" AutoGenerateColumns="false"
                            ShowFooter="true"
                            OnPreRender="gvReport_PreRender">
                            <Columns>
                                <asp:TemplateField HeaderText="單據日期">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("單據日期") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="預交日期">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("預交日期") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="客戶代號">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustId" runat="server" Text='<%#Eval("客戶代號") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶名稱">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("客戶名稱") %>'></asp:Label>
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
                                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("單價") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="數量">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemAmount" runat="server" Text='<%#Eval("數量") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="金額<br/>(NTD)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("金額") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <%--    <asp:TemplateField HeaderText="幣別">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("幣別") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="未交量">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemUndelivered" runat="server" Text='<%#Eval("未交量") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="庫存數量">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemInStock" runat="server" Text='<%#Eval("庫存數量") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="儲位">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemStorage" runat="server" Text='<%#Eval("儲位") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="業務名稱">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesName" runat="server" Text='<%#Eval("業務名稱") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="備註">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("備註") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

