<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.master" AutoEventWireup="true" CodeFile="oqs.aspx.cs" Inherits="oqs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LanguageSwitch" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtCompany_Name" runat="server" placeholder="公司名稱"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtContact" runat="server" placeholder="聯絡人"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtPhone" runat="server" placeholder="電話"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtCompany_Add" runat="server" placeholder="公司地址"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtShipping_Add" runat="server" placeholder="送貨地址"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtMemo" runat="server" placeholder="備註(100字以內)"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="寫入" OnClick="Button1_Click" />
</asp:Content>

