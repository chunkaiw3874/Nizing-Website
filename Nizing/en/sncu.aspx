<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="sncu.aspx.cs" Inherits="sncu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Tin-Copper Alloy - Nizing Electric Wire & Cable</title>
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
    Tin-Copper Alloy
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx" CssClass="active">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/en/images/alloy/sncu-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            Tin-Copper Alloy Wire(Bar)
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
                            High Tensile Strength, High Fatigue Tolerance
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application:
                        </td>
                        <td>
                            High voltage wire and cable, Automation equipment, Stereo wire, Telecommunication, Medica wire, ABS, etc.
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>SnCu0.15%</th>
                        <th>SnCu0.2%</th>
                        <th>SnCu0.3%</th>
                        <th>SnCu0.4%</th>
                        <th>SnCu0.6%<br />(C50100)</th>
                        <th>SnCu0.7%<br />(C50100)</th>
                        <th>Phosphorbronze<br />(C51910)</th>
                    </tr>
                    <tr>
                        <td>Tin Content<br />(%)</td>
                        <td>0.1-0.2</td>
                        <td>0.15-0.25</td>
                        <td>0.24-0.36</td>
                        <td>0.33-0.47</td>
                        <td>0.5-0.7</td>
                        <td>0.6-0.8</td>
                        <td>5.5-7.0</td>
                    </tr>
                    <tr>
                        <td>Tensile Strength<br />(MPa)</td>
                        <td>467.3</td>
                        <td>503.4</td>
                        <td>512.6</td>
                        <td>514.9</td>
                        <td>554.1</td>
                        <td>560.6</td>
                        <td>957.46</td>
                    </tr>
                    <tr>
                        <td>Conductivity<br />(%IACS)</td>
                        <td>83.1</td>
                        <td>80.3</td>
                        <td>80.1</td>
                        <td>74.9</td>
                        <td>66.1</td>
                        <td>64.9</td>
                        <td></td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/en/images/alloy/sncu-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

