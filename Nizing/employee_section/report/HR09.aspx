<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="HR09.aspx.cs" Inherits="nizing_intranet_HR09" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <h2>部門人力配置表</h2>
        </div>
    </div>
<%--    <div class="row form-group">
        <div class="col-sm-2 col-xs-4">
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-2 col-xs-4">
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-2 col-xs-4">
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <div class="row">
        <span class="col-xs-12" style="color:red;">紅色代表今日請假</span>
    </div>--%>
    <div id="divReport_Section_Manufacture" runat="server">
        <div class="row">
            <div class="col-sm-12">
                <h4>製造中心</h4>
            </div>
        </div>
    </div>
    <div id="divReport_Section_Office" runat="server">
        <div class="row">
            <div class="col-sm-12">
                <h4>營運中心</h4>
            </div>
        </div>
    </div>
</asp:Content>

