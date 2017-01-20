<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="copper.aspx.cs" Inherits="copper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-純銅</title>
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
    純銅
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx" CssClass="active">純銅</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">銀銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">錫銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">鎳銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ag.aspx">純銀及銀合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ccs.aspx">銅包鋼</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/images/alloy/copper-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            產品：
                        </td>
                        <td>
                            高導性無氧銅線(棒)、單方向結晶無氧銅線(棒)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            承製線徑：
                        </td>
                        <td>
                            (可電鍍銀、錫、鋅、鎳等)<br />
                            OFC：0.1mm-16mm<br />
                            其餘：0.1mm-8.0mm
                        </td>
                    </tr>
                    <tr>
                        <td>
                            特性：
                        </td>
                        <td>
                            具有『超高無氧』、『高純度』及『高導電』等特點。
                        </td>
                    </tr>
                    <tr>
                        <td>
                            應用：
                        </td>
                        <td>
                            喇叭線、漆包線、鍍銀銅線、鍍錫銅線、冷鍛用材料、各種電子導體、製罐用熔接線、高溫熔射用線、銅製程構裝用導線及太陽能導電帶等。
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
                        <td>純度<br />(%)</td>
                        <td>≧99.95</td>
                        <td>≧99.99</td>
                        <td>≧99.99</td>
                        <td>≧99.99</td>
                    </tr>
                    <tr>
                        <td>氧含量<br />(ppm)</td>
                        <td>≦15</td>
                        <td>&lt; 1</td>
                        <td>&lt; 1</td>
                        <td>&lt; 1</td>
                    </tr>
                    <tr>
                        <td>導電率<br />(%IACS)</td>
                        <td>&gt; 100</td>
                        <td>&gt; 100</td>
                        <td>&gt; 102</td>
                        <td>&gt; 102</td>
                    </tr>
                    <tr>
                        <td>晶粒組織</td>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/alloy/PCVCC-02.png" />
                        </td>
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/alloy/PCVCC-03.png" />
                        </td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/images/alloy/copper-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

