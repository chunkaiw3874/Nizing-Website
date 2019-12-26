<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/oqs-master.master" AutoEventWireup="true" CodeFile="quotation-list.aspx.cs" Inherits="oqs_quotation_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        @media print{
            body *{
                visibility: hidden;
                /*display:none;*/
            }
     
            .printarea *{
                visibility: visible;
                /*position:absolute; width:100%; top:0; padding:0; margin:-1px;*/
            }
        }
        .hidden {
            display: none;
        }
        .align-left{
            text-align: left;
        }
        .readonly{
            background-color: #29ABE2;
            color: white;
            border-color: transparent;
            border-style: solid;
            text-align:center;
        }
        .edit{
            background-color: #29ABE2;
            border-color:transparent;
            text-align:right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--    <asp:HiddenField ID="hdnInternalCostPercent" runat="server" />
    <asp:HiddenField ID="hdnQuotationAPercent" runat="server" />
    <asp:HiddenField ID="hdnQuotationBPercent" runat="server" />
    <asp:HiddenField ID="hdnQuotationCPercent" runat="server" />
    <asp:HiddenField ID="hdnQuotationDPercent" runat="server" />--%>
    <div class="printarea">
        <div class="row">
            <div class="col-sm-12">
                <a href="../Default.aspx">回去首頁</a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6 h2">
                <asp:Label ID="Label1" runat="server" Text="牌價表"></asp:Label>
                <%--<asp:Label ID="lblQuotationListDate" runat="server" Text="2019/03"></asp:Label>--%>
            </div>            
            <div class="col-sm-6 text-right">
                <asp:Label ID="Label2" runat="server" Text="牌價最後更新於:"></asp:Label>
                <asp:Label ID="lblQuotationRefreshTime" runat="server" Text="yyyy/mm/dd hh:mm"></asp:Label>
            </div>
        </div>
        <asp:UpdatePanel ID="upQuotationList" runat="server">
            <ContentTemplate>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-success" Text="Reset" OnClick="btnReset_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <asp:GridView ID="gvQuotationList" runat="server" 
                            ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" CssClass="gv-alternate-row">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblCategoryHeader" runat="server" Text="系列"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>' CssClass="tablecenter"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblProductIDHeader" runat="server" Text="品號"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ProductID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lbl3" runat="server" Text="品名"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lbl4" runat="server" Text="包裝米數"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackageSize" runat="server" Text='<%#Eval("PackageSize") %>' CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="單位成本">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbl5" runat="server" Text="單位成本" CssClass="tableright"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitProductionCost" runat="server" Text='<%#Eval("UnitProductionCost", "{0:0.00}") %>' CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="管銷費用">
                                    <HeaderTemplate>
                                        <div>
                                            <asp:Label ID="lbl6" runat="server" Text="管銷費用"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtInternalCostPercent" runat="server" Width="60px" AutoPostBack="true"
                                                OnTextChanged="DisplayResultWithInternalCostChange"></asp:TextBox>%
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInternalCost" runat="server" Text="" CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="總成本">
                                    <HeaderTemplate>
                                        <asp:Label ID="lbl7" runat="server" Text="總成本"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalCost" runat="server" Text="" CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="報價A">
                                    <HeaderTemplate>
                                        <div>
                                            <asp:Label ID="lbl8" runat="server" Text="報價A"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtQuotationAPercent" runat="server" Width="60px" AutoPostBack="true"
                                                OnTextChanged="DisplayResultWithQuotationChange"></asp:TextBox>%
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuotationA" runat="server" Text="" CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <div>
                                            <asp:Label ID="lbl9" runat="server" Text="報價B"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtQuotationBPercent" runat="server" Width="60px" AutoPostBack="true"
                                                OnTextChanged="DisplayResultWithQuotationChange"></asp:TextBox>%
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuotationB" runat="server" Text="" CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <div>
                                            <asp:Label ID="lbl10" runat="server" Text="報價C"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtQuotationCPercent" runat="server" Width="60px" AutoPostBack="true"
                                                OnTextChanged="DisplayResultWithQuotationChange"></asp:TextBox>%
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuotationC" runat="server" Text="" CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <div>
                                            <asp:Label ID="lbl11" runat="server" Text="報價D"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtQuotationDPercent" runat="server" Width="60px" AutoPostBack="true"
                                                OnTextChanged="DisplayResultWithQuotationChange"></asp:TextBox>%
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuotationD" runat="server" Text="" CssClass="tableright"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="txtInternalCostPercent" />--%>
                <%--<asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

