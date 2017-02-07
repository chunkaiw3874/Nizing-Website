<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PC03.aspx.cs" Inherits="nizing_intranet_PC03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link href="../Content/bootstrap.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 page-header">
                <h2>大宗貨品查詢</h2>
            </div>
        </div>
        <div class="row form-group">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="col-sm-2">
                <span class="h4">選擇查詢規格</span>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-2">
                <asp:DropDownList ID="ddlCategory1" runat="server" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                    <asp:ListItem Value="R">RS-GE</asp:ListItem>
                    <asp:ListItem Value="3122-">3122</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <asp:DropDownList ID="ddlCategory2" runat="server" CssClass="form-control">
                    <asp:ListItem>0.3</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.75</asp:ListItem>
                    <asp:ListItem>1.25</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3.5</asp:ListItem>
                    <asp:ListItem>5.5</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
        </div>
        <div class="row">
            <div class="col-xs-12">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th style="padding-right: 20px; padding-top: 5px; padding-bottom: 5px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">押出半成品品號
                            </th>
                            <th style="padding-right: 20px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">押出半成品數量
                            </th>
                            <th style="padding-right: 20px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">編織半成品品號
                            </th>
                            <th style="padding-right: 20px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">編織半成品數量
                            </th>
                            <th style="padding-right: 20px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">軸裝成品未交量
                            </th>
                            <th style="padding-right: 20px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">再加工1成品未交量
                            </th>
                            <th style="padding-right: 20px; border-bottom: solid 1px #cccccc; border-right: solid 1px #cccccc;">再加工2成品未交量
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbOutstandingOrderSumBody" runat="server">
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" ShowFooter="true" CssClass="grdResultWithFooter">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="押出半成品品號">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("押出半成品品號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="押出半成品數量">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("押出半成品數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="編織半成品品號">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("編織半成品品號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="編織半成品數量">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("編織半成品數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="軸裝成品品號">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("軸裝成品品號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="軸裝成品數量">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("軸裝成品數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預計出貨">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("軸裝預計出貨")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預交日期">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("軸裝預交日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶簡稱">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("軸裝客戶簡稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="再加工1成品品號">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("再加工1成品品號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="再加工1成品數量">
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("再加工1成品數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預計出貨">
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("再加工1預計出貨")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預交日期">
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("再加工1預交日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶簡稱">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("再加工1客戶簡稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="再加工2成品品號">
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("再加工2成品品號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="再加工2成品數量">
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("再加工2成品數量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預計出貨">
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("再加工2預計出貨")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預交日期">
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("再加工2預交日期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶簡稱">
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%#Eval("再加工2客戶簡稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

