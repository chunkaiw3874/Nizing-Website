<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="HR08.aspx.cs" Inherits="nizing_intranet_HR08" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <h2>部門請假表</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-2">
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-xs-2">
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-xs-2">
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <div id="divReport_Section" runat="server">
    </div>
</asp:Content>

