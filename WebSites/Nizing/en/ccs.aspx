<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="ccs.aspx.cs" Inherits="ccs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Copper Plated Steel - Nizing Electric Wire & Cable</title>
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
    Copper Plated Steel
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx" CssClass="active">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/en/images/alloy/ccs-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            Rectangular Copper Clad Steel Wire, Rectangular Tinned Copper Clad Steel Wire, Circular Copper Clad Steel Wire, Circular Tinned Copper Clad Steel Wire
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Size:
                        </td>
                        <td>
                            Common Specs are as the table below
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application:
                        </td>
                        <td>
                            High Frequency signal transfer, Shielding for braid cables, Coaxial cable, Drain wire, Control Wire, etc.
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>Rectangular<br />Rectangure Tinned</th>
                        <th>Circular<br />Circular Tinned</th>
                    </tr>
                    <tr>
                        <td>Size</td>
                        <td>0.5mm x 0.5mm<br />0.64mm x 0.64mm<br />0.8mm x 0.8mm</td>
                        <td>0.5mm~1.0mm</td>
                    </tr>
                    <tr>
                        <td>Conductivity</td>
                        <td>23% & 30%</td>
                        <td>23% & 30%</td>
                    </tr>

                    <tr>
                        <td>Rigidity</td>
                        <td>>1/2H : 3/4H</td>
                        <td>1/2H : 3/4H</td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/en/images/alloy/ccs-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

