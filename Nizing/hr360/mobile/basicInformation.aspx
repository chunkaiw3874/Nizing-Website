<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="basicInformation.aspx.cs" Inherits="hr360_mobile_basicInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <asp:Image ID="imgAvatar" runat="server" Width="100px" Height="100px" />
            </div>
            <div class="col-sm-6">
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass=""></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

