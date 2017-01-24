<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="teflon.aspx.cs" Inherits="teflon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-鐵氟龍特性</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    鐵氟龍
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="plastic.aspx">塑料</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="silicone.aspx">矽膠</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="teflon.aspx" CssClass="active">鐵氟龍</asp:HyperLink> | 
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
            	        <td>PTFE</td>
                        <td>聚四氟乙烯，為不粘塗料可以在260°C連續使用，具有最高使用溫度290-300°C，極低的摩擦係數、良好的耐磨性以及極好的化學穩定性。</td>
                    </tr>
                    <tr>
            	        <td>FEP</td>
                        <td>氟化乙烯丙稀共聚物，為不粘塗料在烘烤時熔融流動形成無孔薄膜，具有卓越的化學穩定性、極好的不粘特性，最高使用溫度為200°C。</td>
                    </tr>
                    <tr>
            	        <td>PFA</td>
                        <td>過氟烷基化物，為不粘塗料與FEP一樣在烘烤時熔融流動形成無孔薄膜。PFA的優點是具有更高的連續使用溫度260°C，更強的剛韌度，特別適合使用在高溫條件下防粘和耐化學性使用領域。</td>
                    </tr>
                    <tr>
            	        <td>ETFE</td>
                        <td>乙烯和四氟乙烯的共聚物，該樹脂是最堅韌的氟聚合物，可以形成一層高度耐用的塗層，具有卓越的耐化學性，並可在150°C下連續工作。</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

