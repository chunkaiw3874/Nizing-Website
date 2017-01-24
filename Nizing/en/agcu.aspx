<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="agcu.aspx.cs" Inherits="agcu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Silver Copper Alloy - Nizing Electric Wire & Cable</title>
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
    Silver-Copper Alloy
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx" CssClass="active">Silver-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">Tin-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">Nickel-Copper</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx">Silver</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">Copper Plated Steel</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/en/images/alloy/agcu-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            CuAg Alloy Strand(Bar)
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
                            Comprise of traits such as high conductivity, high temperature tolerance, high tensile strength, and high flexing endurance
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application:
                        </td>
                        <td>
                            Coaxial cable, Temperature Resistant wire and cable, Medical Grade wire and cable, Stereo cable, small motor, etc.
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>AgCu0.3%</th>
                        <th>AgCu0.6%</th>
                        <th>AgCu1%</th>
                        <th>AgCu2%</th>
                        <th>AgCu4%</th>
                        <th>AgCu7%</th>
                    </tr>
                    <tr>
                        <td>Silver Content<br />(%)</td>
                        <td>0.25-0.35</td>
                        <td>0.5-0.7</td>
                        <td>0.7-1.3</td>
                        <td>1.5-2.5</td>
                        <td>3.5-4.5</td>
                        <td>6.5-7.5</td>
                    </tr>
                    <tr>
                        <td>Tensile Strength<br />(MPa)</td>
                        <td>430</td>
                        <td>469</td>
                        <td>478</td>
                        <td>546</td>
                        <td>626</td>
                        <td>718</td>
                    </tr>
                    <tr>
                        <td>Conductivity<br />(%IACS)</td>
                        <td>98.55</td>
                        <td>94.68</td>
                        <td>93.53</td>
                        <td>90.54</td>
                        <td>83.53</td>
                        <td>79.40</td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/en/images/alloy/agcu-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

