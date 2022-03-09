﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/report/MasterPage2021.Master" CodeFile="InventorySearch.aspx.cs" Inherits="InventorySearch" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        /*.table tr th {
            font-size:14px;
            background-color: #29ABE2;
            color: #ffffff;
        }

        .table tr:nth-child(2n) {
            background-color: #c3e8f4;
        }

        .table tr td, .table tr th {
            border-color: white;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid px-5">
            <h2>庫存查詢系統</h2>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            <div class="table-responsive">
                <table id="search-table" class="table table-borderless text-left">
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkId" runat="server" Text="品號查詢" Checked="true" />
                        </td>
                        <td>開頭為
                        </td>
                        <td>
                            <asp:TextBox ID="txtId_Start" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkName" runat="server" Text="品名查詢" />
                        </td>
                        <td>開頭為
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtName_Start" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>包含有
                        </td>
                        <td>
                            <asp:TextBox ID="txtId_Middle" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td></td>
                        <td>包含有
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtName_Middle" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>結尾為
                        </td>
                        <td>
                            <asp:TextBox ID="txtId_End" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkInvLoc" runat="server" Text="庫別代號" />
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlInvLoc" runat="server" Width="280"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkCategory" runat="server" Text="分類查詢" />
                        </td>
                        <td>會計分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Acct" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Acct_Select" runat="server" Text="..." PostBackUrl="#acct_search_window" OnClick="btnCategory_Acct_Select_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:CheckBox ID="chkInvShowZero" runat="server" Text="顯示實際在庫量為0的項目" />
                        </td>
                        <td></td>
                        <td>原物半分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Raw" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Raw_Select" runat="server" Text="..." PostBackUrl="#raw_search_window" OnClick="btnCategory_Raw_Select_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:CheckBox ID="chkSafetyShowZero" runat="server" Text="顯示預估安全存量為0的項目" Checked="true" />
                        </td>
                        <td></td>
                        <td>小成品分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Small" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Small_Select" runat="server" Text="..." PostBackUrl="#small_search_window" OnClick="btnCategory_Small_Select_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                        <td>大成品分類
                        </td>
                        <td>
                            <asp:TextBox ID="txtCategory_Large" runat="server"></asp:TextBox>
                            <asp:Button ID="btnCategory_Large_Select" runat="server" Text="..." PostBackUrl="#large_search_window" OnClick="btnCategory_Large_Select_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>

        <div class="table-responsive">
            <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="false" CssClass="table table-striped-blue">
                <Columns>
                    <asp:TemplateField HeaderText="實際在庫量">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("AMOUNT_IN_INV") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="品號" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("ITEM_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="品名" ItemStyle-Width="300">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("ITEM_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="規格" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("ITEM_SPEC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位" ItemStyle-Width="50">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("UNIT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="庫別">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("INV_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="庫別名稱" ItemStyle-Width="75">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("INV_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="安全庫存量" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("AMOUNT_SAFETY") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="會計分類" ItemStyle-Width="75">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_ACCT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="原物半分類" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_RAW") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="小成品分類" ItemStyle-Width="75">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_SMALL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="大成品分類" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="label" runat="server" Text='<%#Eval("CATEGORY_LARGE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="acct_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="popup">
                    <h2>會計分類</h2>
                    <a class="close" href="#">×</a>
                    <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdAcct" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdAcct_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grdAcct" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="raw_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="popup">
                    <h2>原物料半分類</h2>
                    <a class="close" href="#">×</a>
                    <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdRaw" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdRaw_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grdRaw" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="small_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="popup">
                    <h2>小成品分類</h2>
                    <a class="close" href="#">×</a>
                    <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdSmall" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdSmall_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grdSmall" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="large_search_window" class="overlay">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div class="popup">
                    <h2>大成品分類</h2>
                    <a class="close" href="#">×</a>
                    <div class="content">
                        <div class="search-result">
                            <asp:GridView ID="grdLarge" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" OnSelectedIndexChanged="grdLarge_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                <SelectedRowStyle BackColor="#FF9933" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grdLarge" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>