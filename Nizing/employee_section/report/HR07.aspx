<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="HR07.aspx.cs" Inherits="nizing_intranet_HR07" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <link href="/css/bootstrap/bootstrap.css" rel="stylesheet" />
    <script src="/Scripts/bootstrap.js"></script>
    <style>
        text-center {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div id="title">
            <div class="row">
                <div class="col-xs-12 title">
                    <h2>年終獎金統計表</h2>
                </div>
            </div>
        </div>
        <div id="search" class="form-group">
            <div class="row">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnSubmit_Click" />
                </div>
                <div class="col-xs-4">
                        <asp:RadioButton ID="rdoOrderByScore" runat="server" GroupName="order" Checked="true" Text="依總金額排序" CssClass="radio-inline" />
                        <asp:RadioButton ID="rdoOrderByID" runat="server" GroupName="order" Text="依員工編號排序" CssClass="radio-inline" />
                </div>
            </div>
        </div>
        <div id="info" style="margin-top: 10px;">
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="gvBonusResult" runat="server" CssClass="grdResultWithFooter" AutoGenerateColumns="false" ShowFooter="true" OnDataBound="gvBonusResult_DataBound" OnRowCreated="gvBonusResult_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="年度" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl1" runat="server" Text='<%#Eval("年度") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="員工編號" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl2" runat="server" Text='<%#Eval("員工編號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="員工姓名" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl3" runat="server" Text='<%#Eval("員工姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="年度考績" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl4" runat="server" Text='<%#Eval("年度考績") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl5" runat="server" Text='<%#Eval("年度考績備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="特休未休" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl6" runat="server" Text='<%#Eval("特休未休") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl7" runat="server" Text='<%#Eval("休假未休備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="年度全勤" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl8" runat="server" Text='<%#Eval("年度全勤") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl9" runat="server" Text='<%#Eval("年度全勤備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="年度獎懲" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl10" runat="server" Text='<%#Eval("年度獎懲") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl11" runat="server" Text='<%#Eval("年度獎懲備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他項目" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl12" runat="server" Text='<%#Eval("其他項目") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl13" runat="server" Text='<%#Eval("其他項目備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
<%--                            <asp:TemplateField HeaderText="其他減項" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl14" runat="server" Text='<%#Eval("其他減項") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl15" runat="server" Text='<%#Eval("其他減項備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="總金額" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl14" runat="server" Text='<%#Eval("總金額") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

