<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="ag.aspx.cs" Inherits="ag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">    
    <title>日進電線-純銀及銀合金</title>
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
    純銀及銀合金
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">純銅</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">銀銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">錫銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">鎳銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ag.aspx" CssClass="active">純銀及銀合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ccs.aspx">銅包鋼</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/images/alloy/ag-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            產品：
                        </td>
                        <td>
                            單方向結晶無氧純銀線(棒)、銀合金線(棒)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            承製線徑：
                        </td>
                        <td>
                            0.1mm-6.0mm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            特性：
                        </td>
                        <td>
                            單方向結晶無氧純銀線具有『超高無氧』、『高純度』及『高導電性』等特點，而合金線則有『合金成份均質化』之特性。
                        </td>
                    </tr>
                    <tr>
                        <td>
                            應用：
                        </td>
                        <td>
                            高端喇叭線、高端音響訊號線導體、電子零件用材料、構裝用導線、蒸(電)鍍用銀粒、銀飾品、銀接點、電子零件、探針及銀觸點材料等。
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>單方向結晶無氧純銀線<br />PSVCC</th>
                        <th>銀銅合金</th>
                        <th>銀銅鎳合金</th>
                        <th>其他銀合金</th>
                    </tr>
                    <tr>
                        <td>成分<br />(%)</td>
                        <td>Ag≧99.99</td>
                        <td>Ag:80-99.9<br />Cu:0.1-20</td>
                        <td>Ag:75<br />Cu:24.5<br />Ni:0.5</td>
                        <td>客製化</td>
                    </tr>
                    <tr>
                        <td>導電率<br />(%IACS)</td>
                        <td>>102</td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/images/alloy/ag-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

