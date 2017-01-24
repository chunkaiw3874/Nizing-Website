<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="nicu.aspx.cs" Inherits="nicu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Nickel-Cooper Alloy</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
    <script>
        //for onmouseover image swap
        function SwapImage(e) {
            e = e || window.event;
            var link = e.target || e.srcElement;
            var source = link.src;
            document.getElementById("ContentPlaceHolder1_ContentPlaceHolder1_imgPrd").src = source;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Nickel-Copper Alloy
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx" CssClass="active">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/en/images/alloy/nicu-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            Nickel Copper Alloy Wire(Bar)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Size:
                        </td>
                        <td>
                            0.1mm-2.6mm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Characteristic:
                        </td>
                        <td>
                            Alloy content homogenization
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application:
                        </td>
                        <td>
                            Heating wire, Temperature resistance wire, Resistor, Divertor, Thermalcouple, etc.
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>CN5<br />(NiCu2%)</th>
                        <th>CN10<br />(NiCu6%)</th>
                        <th>CN15<br />(NiCu10%)</th>
                    </tr>
                    <tr>
                        <td>Nickel Content<br />(%)</td>
                        <td>1.5-2.5</td>
                        <td>5.0-7.0</td>
                        <td>9.0-11.0</td>
                    </tr>
                    <tr>
                        <td>Elongation<br />(%)</td>
                        <td>1.6</td>
                        <td>1.2</td>
                        <td>1.0</td>
                    </tr>
                    <tr>
                        <td>Resistance<br />(µ&Omega;-m)</td>
                        <td>418</td>
                        <td>892</td>
                        <td>1336</td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/en/images/alloy/nicu-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

