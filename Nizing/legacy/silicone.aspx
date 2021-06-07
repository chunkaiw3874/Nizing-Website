<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="silicone.aspx.cs" Inherits="silicone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-矽膠特性</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    矽膠
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="plastic.aspx">塑料</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="silicone.aspx" CssClass="active">矽膠</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="teflon.aspx">鐵氟龍</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="twinning.aspx">纏繞編織材料</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="conductor.aspx">導體</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="material-content">
        <div class="inner-content">
            <div class="content-row">
                <table>
        	        <tr>
            	        <th>材質名稱</th>
                        <th>介紹</th>
                    </tr>
                    <tr>
            	        <td>矽氧樹脂</td>
                        <td>一般俗稱的矽酮、矽利康或矽膠都是指『矽氧樹脂』，是一個介於有機與無機的聚合物，其化學式為[-R2SiO-]n。由無機矽氧鍵骨架(...-Si-O-Si-O-Si-O-...)和共價鍵與矽原子結合的支鏈有機基團組成；透過控制骨架的長度、有機基團的種類和骨架的交聯，可得到具有不同性質的矽氧聚合物，從液體的矽油到有柔軟彈性的矽凝膠、矽橡膠和剛性的矽樹脂。<br />
                        矽膠可沉積於土壤中分解，對水生物無危害且無生物蓄積性，不含任何重金屬、塑化劑與有毒物質；因而是目前世界公認最具環保之素材，歐美日等國已普遍採用 Silicone 材料來取代其他材料。<br />
                        矽膠擁有極為優越的溫度穩定性，可在-40°C~200°C溫度內穩定使用不變質，並擁有最佳的離型能力；因此，矽膠產品在加工製程中的矽膠原料與包覆材的結合和封口作業就顯得非常重要。</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

