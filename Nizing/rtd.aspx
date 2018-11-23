<%@ Page Title="" Language="C#" MasterPageFile="~/master/product-detail.master" AutoEventWireup="true" CodeFile="rtd.aspx.cs" Inherits="rtd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>RTD 鉑電阻-日進電線</title>
    <meta name="description" content="RTD 白金電阻式溫度感測器是一款在 0°C 時電阻為 100 Ohm 的感溫裝置, 它的電阻隨著溫度變動, 通常可以測量高達 850°C 的溫度, 電阻和溫度之間呈直線線性關係。詳細的鉑電阻RTD的產品規格以及使用範圍值。鐵氟龍、矽膠及玻璃纖維材質通過UL VW-1垂直燃燒測試以及多項IEC測試，證實為低煙、無鹵、耐燃之產品。">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="smallPicArea" Runat="Server">
    <div class="content-row">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/product_pic/rtd-1.jpg" AlternateText="RTD 鉑電阻" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/product_pic/rtd-2.jpg" AlternateText="RTD 鉑電阻" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="largePicArea1" Runat="Server">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/product_pic/rtd-3.jpg" AlternateText="RTD 鉑電阻" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="largePicArea2" Runat="Server">
        <%--<asp:Image ID="Image4" runat="server" ImageUrl="~/images/product_pic/lshf.jpg" AlternateText="RTD 鉑電阻" />--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="largePicArea3" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="prdTitle" Runat="Server">
    鉑電阻<br />
    RTD
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="titleRowLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/pdf/rtd.pdf" ImageUrl="~/images/button/download_pdf_button2.jpg" Target="_blank"></asp:HyperLink>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="briefDescription" Runat="Server">
    <div class="subtitle">
        應用範圍
    </div>
    <table>
        <tr>
            <td>RTD 白金電阻式溫度感測器是一款在 0°C 時電阻為 100 Ohm 的感溫裝置, 它的電阻隨著溫度變動, 通常可以測量高達 850°C 的溫度, 電阻和溫度之間呈直線線性關係。詳細的鉑電阻RTD的產品規格以及使用範圍值。鐵氟龍、矽膠及玻璃纖維材質通過UL VW-1垂直燃燒測試以及多項IEC測試，證實為低煙、無鹵、耐燃之產品。</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="detailDescription" Runat="Server">
    <div class="subtitle">
        RTD 鉑電阻 產品規格表
    </div>
    <div class="content">
        <table>
        <tr>
          <td rowspan="2">代號<br />
            Wire Code</td>
          <td rowspan="2">規格<br />
            Specification</td>
          <td colspan="2">線徑<br />
            Dimension</td>
          <td rowspan="2">絕緣材質<br />
            Insulation Material</td>
          <td colspan="2">導體材質<br />
            Conductor Material</td>
          <td rowspan="2">環境溫度<br />
            Temperature Range (°C)</td>
          <td rowspan="2">米/卷<br />
            Meters/ Coil</td>
        </tr>
        <tr>
          <td>ID (mm)</td>
          <td>OD (mm)</td>
          <td>A<br />
						(Red)</td>
          <td>BB<br />
						(White)</td>
        </tr>
        <tr>
          <td>RTDJ-PP-24S</td>
          <td>0.12/19    x 3<br />
			  (24 AWG)</td>
          <td>1.05</td>
          <td>3.80</td>
          <td>PVC</td>
          <td>OFC/TC/<br />
            			SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -30 ~ 105</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-P2P-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>4.80</td>
          <td>PVC-AL FOIL</td>
          <td>OFC/TC/<br />
						SPC/NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -30 ~ 105</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-SS-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>4.00</td>
          <td>矽橡膠<br />
            Silicone</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -60 ~ 200</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-TT-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>2.65</td>
          <td>聚合氟化物<br />
            Fluoropolymer</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -190 ~ 205</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-T2T-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>2.85</td>
          <td>聚合氟化物-鋁箔隔離<br />
            Fluoropolymer-AL FOIL</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -190 ~ 205</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-T6T-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>3.00</td>
          <td>聚合氟化物-編織銅網隔離<br />
            Fluoropolymer-TCB FOIL</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -190 ~ 205</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-TT-24S</td>
          <td>0.12/19    x 3<br />
            (24 AWG)</td>
          <td>1.05</td>
          <td>2.75</td>
          <td>PFA<br />
            PFA</td>
          <td>OFC/TC/<br />
            SPC/ NPC</td>
          <td>OFC/TC/<br />
            SPC/ NPC</td>
          <td> -190 ~ 260</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-TT-20S</td>
          <td>0.19/19    x 3<br />
						(20 AWG)</td>
          <td>1.30</td>
          <td>3.30</td>
          <td>PFA<br />
            PFA</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -190 ~ 260</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-GG-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>2.65</td>
          <td>玻璃纖維<br />
            Fiberglass</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -60 ~ 400</td>
          <td>500</td>
        </tr>
        <tr>
          <td>RTDJ-1GG-24S</td>
          <td>0.12/19    x 3<br />
						(24 AWG)</td>
          <td>1.05</td>
          <td>3.00</td>
          <td>玻璃纖維-不鏽鋼網<br />
            Fiberglass-SUS304</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td>OFC/TC/<br />
						SPC/ NPC</td>
          <td> -60 ~ 400</td>
          <td>500</td>
        </tr>
          </table>
    </div>
    <div class="subtitle">
        技術資料
    </div>
    <div class="content">
        <table>
            <tr>
                <td colspan="8">絕緣體種類特性</td>
    	    </tr>
            <tr>
                <td>種類<br />
           	        Material</td>
           	    <td>適用溫度<br />
           	        Temp Range<br />
					(°C)</td>
           	    <td>耐燃性<br />
                    Flame Retardant</td>
    	        <td>耐磨性<br />
                    Friction<br />
					Resistance</td>
           	        <td>耐油性<br />
           	          Oil<br />
						Resistance</td>
    				<td>耐酸鹼性<br />
           		        Chemical<br />
					Resistance</td>
           	        <td>耐濕性<br />
           	          Waterproof</td>
           	        <td>可繞性<br />
           	          Flexibility</td>
          	      </tr>
           	      <tr>
           	        <td>塑膠<br />
						PVC</td>
           	        <td> -10 ~ 105</td>
           	        <td>Bad</td>
           	        <td>Good</td>
           	        <td>Bad</td>
           	        <td>Fair</td>
           	        <td>Good</td>
           	        <td>Excellent</td>
          	      </tr>
           	      <tr>
           	        <td>橡膠<br />
						EPR/HYP<br />
					    Rubber</td>
           	        <td> -15 ~ 110</td>
           	        <td>Bad</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Excellent</td>
          	      </tr>
           	      <tr>
           	        <td>矽膠<br />
						Silicone</td>
           	        <td> -60 ~ 200</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
          	      </tr>
           	      <tr>
           	        <td>聚合氟化物 FEP<br />
					Fluoropolymer FEP</td>
           	        <td> -100 ~ 200</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Good</td>
          	      </tr>
           	      <tr>
           	        <td>聚合氟化物 PFA<br />
					Fluoropolymer PFA</td>
           	        <td> -267 ~ 260</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Excellent</td>
           	        <td>Good</td>
          	      </tr>
           	      <tr>
           	        <td>聚醯亞胺<br />
       	            KAPTON</td>
           	        <td> -267 ~ 316</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Good</td>
           	        <td>Fair</td>
           	        <td>Fair</td>
          	      </tr>
           	      <tr>
           	        <td>玻璃纖維<br />
						Fiberglass </td>
           	        <td> -100 ~ 500</td>
           	        <td>Excellent</td>
           	        <td>Fair</td>
           	        <td>Fair</td>
           	        <td>Excellent</td>
           	        <td>Bad</td>
           	        <td>Fair</td>
          	      </tr>
           	      <tr>
           	        <td>耐高溫陶瓷纖維<br />
						Ceramic Fiber</td>
           	        <td> -100 ~ 1200</td>
           	        <td>Excellent</td>
           	        <td>Bad</td>
           	        <td>Fair</td>
           	        <td>Excellent</td>
           	        <td>Bad</td>
           	        <td>Fair</td>
          	      </tr>
   		  </table>
    </div>
    <div class="subtitle">
        縮寫對照表
    </div>
    <div class="content">
        <table>
        <tr>
          <td colspan="3">絕緣體縮寫表</td>
          <td colspan="3">導體縮寫表</td>
        </tr>
        <tr>
          <td>中文</td>
          <td>English</td>
          <td>Abbreviation</td>
          <td>中文</td>
          <td>English</td>
          <td>Abbreviation</td>
        </tr>
        <tr>
          <td>塑膠</td>
          <td>PVC</td>
          <td>P</td>
          <td>無氧銅</td>
          <td>Oxyen-Free Copper</td>
          <td>OFC</td>
        </tr>
        <tr>
          <td>橡膠</td>
          <td>EPR/HYP Rubber</td>
          <td>R</td>
          <td>銅鎳合金</td>
          <td>Ni-Copper</td>
          <td>Ni-Cu</td>
        </tr>
        <tr>
          <td>矽膠</td>
          <td>Silicone Rubber</td>
          <td>S</td>
          <td>鎳鉻合金</td>
          <td>Nickel-Chromiun</td>
          <td>Ni-Cr</td>
        </tr>
        <tr>
          <td>聚合氟化物 FEP</td>
          <td>Fluoropolymer FEP</td>
          <td>T</td>
          <td>鎳鋁合金</td>
          <td>Nickel-Alumel</td>
          <td>Ni-Al</td>
        </tr>
        <tr>
          <td>聚合氟化物 PFA</td>
          <td>Fluoropolymer PFA</td>
          <td>T</td>
          <td>鐵</td>
          <td>Iron</td>
          <td>Iron/Fe</td>
        </tr>
        <tr>
          <td>KAPTON</td>
          <td>KAPTON</td>
          <td>K</td>
          <td>鍍錫銅</td>
          <td>Tinned Copper</td>
          <td>Tc</td>
        </tr>
        <tr>
          <td>玻璃纖維</td>
          <td>Fiberglass</td>
          <td>G</td>
          <td>鍍包鋼</td>
          <td>Copper Claded Steel</td>
          <td>CCS</td>
        </tr>
        <tr>
          <td>耐高溫陶瓷纖維</td>
          <td>Ceramic Fiber</td>
          <td>C</td>
          <td>不鏽鋼</td>
          <td>Stainless Steel</td>
          <td>SUS304</td>
        </tr>
        <tr>
          <td>雲母</td>
          <td>Mica</td>
          <td>M</td>
          <td>純鎳</td>
          <td>Pure Nickel</td>
          <td>PN</td>
        </tr>
        </table>
    </div>
</asp:Content>
