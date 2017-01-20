<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HR06.aspx.cs" Inherits="nizing_intranet_HR06" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <style>
        text-center {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div id="title">
            <div class="row">
                <div class="col-xs-12 title">
                    <h2>考核成績表</h2>
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
                        <asp:RadioButton ID="rdoOrderByScore" runat="server" GroupName="order" Checked="true" Text="依成績排序" CssClass="radio-inline" />
                        <asp:RadioButton ID="rdoOrderByID" runat="server" GroupName="order" Text="依員工編號排序" CssClass="radio-inline" />
                </div>
            </div>
        </div>
        <div id="info" style="margin-top: 10px;">
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="gvAssessmentScore" runat="server" CssClass="grdResult" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="年度" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl1" runat="server" Text='<%#Eval("年度") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="受評者ID" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl2" runat="server" Text='<%#Eval("受評者ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="受評者姓名" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl3" runat="server" Text='<%#Eval("受評者姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="自評分數" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl4" runat="server" Text='<%#Eval("自評分數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主管ID" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl5" runat="server" Text='<%#Eval("主管ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主管姓名" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl6" runat="server" Text='<%#Eval("主管姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主管評分數" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl7" runat="server" Text='<%#Eval("主管評分數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="特評者ID" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl8" runat="server" Text='<%#Eval("特評者ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="特評者姓名" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl9" runat="server" Text='<%#Eval("特評者姓名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="特評分數" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl10" runat="server" Text='<%#Eval("特評分數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出勤成績" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl11" runat="server" Text='<%#Eval("出勤成績") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="考績" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl12" runat="server" Text='<%#Eval("考績") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="考績級別" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lbl13" runat="server" Text='<%#Eval("考績級別") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

