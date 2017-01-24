<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDayOff.aspx.cs" Inherits="EmployeeDayOff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>特休查詢</h2>
        <asp:DropDownList ID="ddlPerson" runat="server" placeholder="選擇查詢人員" AutoPostBack="True" DataSourceID="employeeID" DataTextField="MV002" DataValueField="MV001"></asp:DropDownList>
        <asp:SqlDataSource ID="employeeID" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT [MV001], [MV002] FROM [CMSMV] WHERE ([MV022] = '') ORDER BY [MV001]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:GridView ID="grdResult" runat="server"></asp:GridView>
    </div>
</asp:Content>

