<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PD02_NetSpending.aspx.cs" Inherits="nizing_intranet_PD02_NetSpending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .btn-group.flex{
            display: flex;
        }
        .flex .btn{
            flex: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div id="formTitle" class="form-group">
            <div class="row">
                <div class="col-sm-12 h2">
                    廠商進貨金額表
                </div>
            </div>
        </div>
        <div id="searchField" class="pb-3" style="border-bottom:solid 1px #cccccc">
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">
                            查詢年分
                        </span>                                    
                        <asp:DropDownList ID="ddlSearchYear" runat="server" CssClass="custom-select"/>
                    </div>
                </div>
                <div class="btn-group btn-group-lg flex mt-3" role="group">
                    <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-secondary btn-success"
                        OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnExportToExcel" runat="server" Text="匯出" CssClass="btn btn-secondary btn-success"
                        OnClick="btnExportToExcel_Click" />
                </div>
            </div>
        </div>
        <div id="displayField" class="pt-3">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvResult" runat="server"
                        CssClass="grdResult"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    #
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("rank") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    廠商代號
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("supplierId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    廠商簡稱
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("supplierName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    年度
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("yr") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    購買淨額
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("netSpending") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

