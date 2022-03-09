<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="copper.aspx.cs" Inherits="copper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Pure Copper - Nizing Electric Wire & Cable</title>
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
    Copper
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx" CssClass="active">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/en/images/alloy/copper-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            High Conductivity OFC strand(bar), Linear Crystal OFC strand(bar)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Size:
                        </td>
                        <td>
                            (Optional Coating of Silver, Tin, Nickel, Zinc, and others)<br />
                            OFC：0.1mm-16mm<br />
                            Other：0.1mm-8.0mm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Characteristic:
                        </td>
                        <td>
                            Comprise of traits such as oxygen free, high conductivity, and high purity
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application:
                        </td>
                        <td>
                            Speaker Wire, Magnet Wire, Tinned Copper, Silvered Copper, and Conductance Material of many other electrical appliances.
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>無氧銅線<br />OFC</th>
                        <th>高導性無氧銅線<br />OFHC</th>
                        <th>單方向結晶無氧銅線<br />PCVCC-02</th>
                        <th>單方向結晶無氧銅線<br />PCVCC-03</th>
                    </tr>
                    <tr>
                        <td>Purity<br />(%)</td>
                        <td>≧99.95</td>
                        <td>≧99.99</td>
                        <td>≧99.99</td>
                        <td>≧99.99</td>
                    </tr>
                    <tr>
                        <td>Oxygen Content<br />(ppm)</td>
                        <td>≦15</td>
                        <td>&lt; 1</td>
                        <td>&lt; 1</td>
                        <td>&lt; 1</td>
                    </tr>
                    <tr>
                        <td>Conductivity<br />(%IACS)</td>
                        <td>&gt; 100</td>
                        <td>&gt; 100</td>
                        <td>&gt; 102</td>
                        <td>&gt; 102</td>
                    </tr>
                    <tr>
                        <td>Grain Structure</td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/en/images/alloy/PCVCC-02.png" />
                        </td>
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/en/images/alloy/PCVCC-03.png" />
                        </td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/en/images/alloy/copper-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

