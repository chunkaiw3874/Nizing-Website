<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HR11.aspx.cs" Inherits="nizing_intranet_HR11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 h2">
                人員應上班時數
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Label ID="lblMemo" runat="server" Text="[placeholder]"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:GridView ID="grdReport" runat="server" CssClass="grdResult"></asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

