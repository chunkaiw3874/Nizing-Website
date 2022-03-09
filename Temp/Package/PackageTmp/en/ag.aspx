<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="ag.aspx.cs" Inherits="ag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">    
    <title>Pure Silver and Silver Alloy - Nizing Electric Wire & Cable</title>
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
    Silver
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx" CssClass="active">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/en/images/alloy/ag-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            Linear Crystal Oxygen Free Pure Silver Wire(Bar), Silver Alloy Wire(Bar)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Size:
                        </td>
                        <td>
                            0.1mm-6.0mm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Characteristic:
                        </td>
                        <td>
                            Pure Silver is comprised of traits such as Ultra high Oxygen Free, High purity, and High conductivity
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application:
                        </td>
                        <td>
                            High-End Speaker Wire, High-End Stereo signal conductor, and other products that requires exceptional conductivity.
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>PSVCC</th>
                        <th>AgCu</th>
                        <th>AgCuNi</th>
                        <th>Other Alloy</th>
                    </tr>
                    <tr>
                        <td>Content<br />(%)</td>
                        <td>Ag≧99.99</td>
                        <td>Ag:80-99.9<br />Cu:0.1-20</td>
                        <td>Ag:75<br />Cu:24.5<br />Ni:0.5</td>
                        <td>Customize</td>
                    </tr>
                    <tr>
                        <td>Conductivity<br />(%IACS)</td>
                        <td>>102</td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/en/images/alloy/ag-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

