<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage2021.master" AutoEventWireup="true" CodeFile="HR08.aspx.cs" Inherits="nizing_intranet_HR08" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div class="h2 mb-3">部門請假一欄表</div>

        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">查詢年月</span>
            </div>
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
            <div class="input-group-append">
                <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click"
                    CssClass="btn btn-success" />
            </div>
        </div>
        
        <div class="text-danger mb-3">紅色代表今日請假</div>

        <div id="divReport_Section" runat="server">
        </div>
    </div>
</asp:Content>

