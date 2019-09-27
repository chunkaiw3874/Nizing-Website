<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDayOff.aspx.cs" Inherits="EmployeeDayOff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div id="formTitle">
            <div class="row">
                <div class="col-sm-12 h2">
                    特休查詢
                </div>
            </div>
        </div>
        <div id="searchFieldPersonnel" class="mb-3">
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">
                        選擇查詢人員
                    </span>
                    <asp:DropDownList ID="ddlPerson" runat="server" CssClass="custom-select" AutoPostBack="True" DataSourceID="employeeID" DataTextField="MV002" DataValueField="MV001"></asp:DropDownList>
                    <asp:SqlDataSource ID="employeeID" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT [MV001], [MV002] FROM [CMSMV] WHERE ([MV022] = '') ORDER BY [MV001]"></asp:SqlDataSource>
                </div>
            </div>
        </div>
        <div id="displayField">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="grdResult" runat="server" CssClass="grdResult"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

