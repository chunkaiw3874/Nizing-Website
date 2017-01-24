<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/product.master" AutoEventWireup="true" CodeFile="thermocouple-series.aspx.cs" Inherits="thermocouple_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Thermocouple Series - Nizing Electric Wire & Cable</title>
    <meta name="description" content="All types of thermocouples, used as temperature sensor and detector. Models include RTD, K-Type, J-Type, T-Type, R-Type, S-Type, E-Type">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="thermocouple-submenu">
        <div class="link">
            <div class="button">
                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/button/tp_button.jpg" NavigateUrl="tp.aspx"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/en/images/button/rtd_button.jpg" NavigateUrl="rtd.aspx"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/button/k_type_button.jpg" NavigateUrl="k-type.aspx"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/button/j_type_button.jpg" NavigateUrl="j-type.aspx"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/en/images/button/t_type_button.jpg" NavigateUrl="t-type.aspx"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/button/r_s_type_button.jpg" NavigateUrl="rs-type.aspx"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/button/e_type_button.jpg" NavigateUrl="e-type.aspx"></asp:HyperLink>
            </div>
        </div>
        <div class="content">
            <div class="div-top-50">
                <div class="title">
                    What is Thermocouple
                </div>
                Thermocouple consists of two different conductors that are welded into a close circuit, which produces voltage when heated. The voltage produced depends on the difference of temperature between the two junctions. The Cold Welding junction is set at a constant temperature (usually 0°C), and the temperature of the Hot Welding junction can be calculated through the EMF Curve that is specific to this combination of conductors. The pairing of these two specific conductors is called "Thermocouple".
                <br />
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/en/images/product_pic/thermocouple_principle.jpg" />
            </div>
            <div class="div-top-50">
                <div class="title">
                    Thermal EMF Curve
                </div>
                <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/product_pic/thermocouple_thermal_emf.jpg" NavigateUrl="~/en/images/product_pic/thermocouple_thermal_emf_large.jpg" Target="_blank"></asp:HyperLink>
            </div>
            <div class="div-bottom-100">
                <div class="title">
                    Thermocouple Categories
                </div>
                <table>
    	            <tr>
                        <th rowspan="2" colspan="2">Wire Type</th>
                        <th rowspan="2">EMF<br />(mV)</th>
                        <th rowspan="2">Measured Temperature Range<br />(°C)</th>
                        <th rowspan="2">Advantage</th>
                        <th rowspan="2">Disadvantage</th>
                        <th colspan="2">Material</th>
    	            </tr>
                    <tr>
    	                <th>+</th>
                        <th>-</th>
                    </tr>                                                                                    
                    <tr>
                        <td rowspan="2">High Temp</td>
                        <td rowspan="2">K</td>
                        <td rowspan="2" nowrap>-200~1200</td>
                        <td>-5.89/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. Widely used in manufacture industry<br />
							2. High stability in acidic envirnoment <br />
							3. Linear EMF curve<br />
							4. Nice resistance against oxidization under 1000°C</td>
                        <td rowspan="2" style="text-align:left">1. Not suitable in CO and sulfiric gas environment<br />
										  2. Degrades in hot redox gas environment</td>
                        <td>Cr</td>
                        <td rowspan="2">Alloy of Ni and Al, Mn, or Si</td>                  
                    </tr>
                    <tr>
    	                <td>48.8/1200°C</td>
                        <td>Ni</td>
                    </tr>
                    <tr>
        	            <td rowspan="4">Med Temp</td>
                        <td rowspan="2">E</td>
                        <td rowspan="2">-200~800</td>
                        <td>-8.82/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. Largest EMF<br />
							2. Best sensitivity<br />
							3. Good heat resistance compare with J-Type<br />
							4. Two junctions are not magnetized<br />
							5. Suitable for oxidized gas environment</td>
                        <td rowspan="2" style="text-align:left">1. Not suitable in redox gas environment<br />
							2. High electrical resistance</td>
            			<td>Cr</td>
                        <td>Ni</td>
                    </tr>
                    <tr>
        	            <td>61.02/800°C</td>
                        <td>Ni</td>
                        <td>Cu</td>
                    </tr>
                    <tr>
                        <td rowspan="2">J</td>
                        <td rowspan="2">-200~350</td>
                        <td>-7.89/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. Suitable in redox air environment<br />
							2. EMF is 20% higher than K-Type<br />
							3. Lower pricing, suitable for median temperature zone</td>
                        <td rowspan="2" style="text-align:left">1. Rusts<br />
							2. Low reproducibility</td>
                        <td rowspan="2">Fe</td>
                        <td>Ni</td>  
                    </tr>
                    <tr>
        	            <td>72.28/750°C</td>
                        <td>Cu</td>
                    </tr>
                    <tr>
                        <td rowspan="2">Low Temp</td>
                        <td rowspan="2">T</td>
                        <td rowspan="2">-200~350</td>
                        <td>-5.6/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. Stable in acid-deficient, redox gas environment<br />
							2. Linear EMF curve<br />
							3. Stable characteristic in low temperature zone<br />
							4. High density, high reproducibility</td>
                        <td rowspan="2" style="text-align:left">1. Copper oxidized above 300°C<br />
							2. Low temperature zone under extreme conditions<br />
							3. Copper in the positive junction oxidizes easily<br />
			  4. Larger range for error</td>           
                        <td rowspan="2">Cu</td>
                        <td>Ni</td>
                    </tr>
                    <tr>
        	            <td>17.82/350°C</td>
                        <td>Cu</td>
                    </tr> 
    	            <tr>
        	            <td rowspan="6" nowrap>High Temp</td>
                        <td rowspan="2">B</td>
                        <td rowspan="2">500~1700</td>
                        <td>1.24/500°C</td>
                        <td rowspan="2" style="text-align:left">1. Usable in acidic gas environment<br />
							2. Usable for 1000°C~1800°C high temperature test<br />
							3. Low EMF under room temperature<br />
							4. Good oxidization resistance and chemical resistance<br />
							5. Better heat resistance and mechanical property than R-Type</td>
                        <td rowspan="2" style="text-align:left">1. Not suitable in redox gas environment<br />
							2. Not reliable under 600°C<br />
							3. Low sensitivity<br />
							4. Non-linear EMF curve<br />
			  5. High pricing</td>
                        <td>Rh</td>
                        <td>Rh</td>
                    </tr>
                    <tr>
    	                <td>12.4/1700°C</td>
                        <td>Pt</td>
                        <td>Pt</td>
                    </tr>
                    <tr>
                        <td rowspan="2">R</td>
                        <td rowspan="4">0~1600</td>
                        <td>0/0°C</td>
                        <td rowspan="4" style="text-align:left">1. Good heat resistance, stability, and reproducibility<br />
							2. Good resistance against oxidization and chemical<br />
							3. Can be used as standard</td>
                        <td rowspan="4" style="text-align:left">1. Low EMF range<br />
							2. Fragile in redox gas environment (espcially in hydrogen gas or metallic vapor)<br />
							3. Large range of error<br />
			  4. High pricing</td>
                        <td>Rh</td>
                        <td rowspan="2">Pt</td>
                    </tr>
                    <tr>
    	                <td>18.84/1600°C</td>
                        <td>Pt</td>
                    </tr>
                    <tr>
                        <td rowspan="2">S</td>
                        <td>-7.89/-200°C</td>
                        <td>Rh</td>
                        <td rowspan="2">Pt</td>
                    </tr>
                    <tr>
        	            <td>72.28/750°C</td>
                        <td>Pt</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

