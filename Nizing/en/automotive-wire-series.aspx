<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/product.master" AutoEventWireup="true" CodeFile="automotive-wire-series.aspx.cs" Inherits="automotive_wire_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Automobile Wire Series - Nizing Electric Wire & Cable</title>
    <meta name="description" content="Automobile Wires">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/button/auto_wire_jaso.jpg" alt="JASO Standard Automobile Wire" NavigateUrl="automotive-wire-standard-jaso.aspx"></asp:HyperLink>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/en/images/button/auto_wire_sae.jpg" alt="SAE Standard Automobile Wire" NavigateUrl="automotive-wire-standard-sae.aspx"></asp:HyperLink>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/button/auto_wire_iso.jpg" alt="ISO Standard Automobile Wire" NavigateUrl="automotive-wire-standard-iso.aspx"></asp:HyperLink>
                </div> 
            </div>
        </div>

    </div>
</asp:Content>

