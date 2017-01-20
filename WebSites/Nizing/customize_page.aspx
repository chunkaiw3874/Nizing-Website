<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="customize_page.aspx.cs" Inherits="customize_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>客製化流程-日進電線</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    客製化流程
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>日進電線為市場上少數著重於客製線材的電線電纜製造商。為符合您的客製需求，日進可從兩種不同的方向切入，以生產出最適合您的產品</p>
    <p>一、從需求面出發</p>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icon/custom_procedure.png" />
    <p>當客戶研發新產品時，所需要的線材在市場中並無販售，需要專業的團隊為您打造，這個流程即是為了您而設計的。日進電線會針對您線材的需求及用途，為您架構最合適的線材。從導體、隔離、到絕緣體、及外被的分拆搭配等，製作出專屬於您的產品。</p>
    <p>二、從樣品面出發</p>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icon/custom_procedure2.png" />
    <p>當客戶所需要的線材已經存在，但卻因種種原因而需要另尋製造商製作，此流程就是您的選擇。日進電線的專業工程師將會針對您所提供的樣品進行分析，並複製出任何您所需要的線材。</p>
</asp:Content>

