<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="ccs.aspx.cs" Inherits="ccs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-銅包鋼</title>
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
    銅包鋼
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="copper.aspx">純銅</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="agcu.aspx">銀銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="sncu.aspx">錫銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="nicu.aspx">鎳銅合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ag.aspx">純銀及銀合金</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="ccs.aspx" CssClass="active">銅包鋼</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="alloy-content">
        <div class="inner-content">
            <div class="large-pic">
                <asp:Image ID="imgPrd" runat="server" ImageUrl="~/images/alloy/ccs-1.jpg" />
            </div>
            <div class="brief">
                <table class="no-grid-table">
                    <tr>
                        <td>
                            產品：
                        </td>
                        <td>
                            方形銅包鋼線、方形鍍錫銅包鋼線、圓形銅包鋼線、圓形鍍錫銅包鋼線
                        </td>
                    </tr>
                    <tr>
                        <td>
                            承製線徑：
                        </td>
                        <td>
                            如下表為常用規格
                        </td>
                    </tr>
                    <tr>
                        <td>
                            應用：
                        </td>
                        <td>
                            高頻信號傳輸、編織電纜屏蔽防護層、傳輸電子訊號、接地釋放、同軸電線、射頻電纜、控制電纜的導體及編織層等。
                        </td>
                    </tr>
                </table>
                <table class="grid-table">
                    <tr>
                        <th></th>
                        <th>方形銅包鋼線<br />方形鍍錫銅包鋼線</th>
                        <th>圓形銅包鋼線<br />圓形鍍錫銅包鋼線</th>
                    </tr>
                    <tr>
                        <td>線徑</td>
                        <td>0.5mm x 0.5mm<br />0.64mm x 0.64mm<br />0.8mm x 0.8mm</td>
                        <td>0.5mm~1.0mm</td>
                    </tr>
                    <tr>
                        <td>導電率</td>
                        <td>23% & 30%</td>
                        <td>23% & 30%</td>
                    </tr>
                    <tr>
                        <td>硬度</td>
                        <td>>1/2H : 3/4H : 0材(特殊要求)</td>
                        <td>1/2H : 3/4H : 0材(特殊要求)</td>
                    </tr>
                </table>
            </div>            
            <div class="small-pic">
                <asp:Image ID="Image1" runat="server" Width="50" onmouseover="SwapImage();" ImageUrl="~/images/alloy/ccs-1.jpg" />
            </div>
        </div>
    </div>
</asp:Content>

