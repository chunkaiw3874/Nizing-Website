<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="conductor.aspx.cs" Inherits="conductor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Conductor Material - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Conductor
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="plastic.aspx">Plastic</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="silicone.aspx">Silicone</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="teflon.aspx">Teflon</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="twinning.aspx">Twinning Material</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="conductor.aspx" CssClass="active">Conductor</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="material-content">
        <div class="inner-content">
            <div class="content-row">
                <table>
        	        <tr>
            	        <th>Material</th>
                        <th>Introduction</th>
                    </tr>
                    <tr>
            	        <td>Oxygen Free Copper<br />(OFC)</td>
                        <td>
                            <p>Oxygen-free copper is typically specified according to the ASTM/UNS database.[3] The UNS database includes many different compositions of high conductivity electrical copper. Of these three are widely used and two are considered oxygen-free.</p>
                            <p>C10100 - also known as Oxygen-Free Electronic (OFE). This is a 99.99%pure copper with 0.0005% oxygen content. It achieves a minimum 101% IACS conductivity rating. This copper is finished to a final form in a carefully regulated, oxygen-free environment. Silver (Ag) is considered an impurity in the OFE chemical specification. This is also the most expensive of the three grades listed here.</p>
                            <p>C10200 - also known as Oxygen-Free (OF). While OF is considered oxygen-free, its conductivity rating is no better than the more common ETP grade below. It has a 0.001% oxygen content, 99.95% purity and minimum 100% IACS conductivity. For the purposes of purity percentage, silver (Ag) content is counted as copper (Cu).</p>
                            <p>C11000 - also known as Electrolytic-Tough-Pitch (ETP). This is the most common copper. It is universal for electrical applications. ETP has a minimum conductivity rating of 100% IACS and is required to be 99.9% pure. It has 0.02% to 0.04% oxygen content (typical). Most ETP sold today will meet or exceed the 101% IACS specification. As with OF copper, silver (Ag) content is counted as copper (Cu) for purity purposes.</p>
                        </td>
                    </tr>
                    <tr>
            	        <td>Cupronickel<br />(Ni-Cu)</td>
                        <td>
                            <p>Copper nickels are commonly specified in heat exchanger or condenser tubes in evaporators of desalination plants, process industry plants, air cooling zones of thermal power plants, high-pressure feed water heaters, and sea water piping in ships. The composition of the alloys can vary from 90% Cu–10% Ni to 70% Cu–30% Ni.</p>
                            <p>Single-core thermocouple cables use a single conductor pair of thermocouple conductors such as iron-constantan, copper constantan or nickel-chromium/nickel-aluminium. These have the heating element of constantan or nickel-chromium alloy within a sheath of copper, cupronickel or stainless steel.</p>
                            <p>Beginning around the turn of the 20th century, bullet jackets were commonly made from this material. It was soon replaced with gilding metal to reduce metal fouling in the bore.</p>
                            <p>Currently, cupronickel remains the basic material for silver-plated cutlery. It is commonly used for mechanical and electrical equipment, medical equipment, zippers, jewelry items, and as material for strings for string instruments.</p>
                            <p>For high-quality cylinder locks and locking systems, the cylinder cores are made from wear-resistant cupronickel.</p>
                        </td>
                    </tr>
                    <tr>
            	        <td>Chromel<br />(Ni-Cr)</td>
                        <td>
                            <p>Chromel is an alloy made of approximately 90 percent nickel and 10 percent chromium that is used to make the positive conductors of ANSI Type E (chromel-constantan) and K (chromel-alumel) thermocouples. It can be used up to 1100 °C in oxidizing atmospheres. Chromel is a registered trademark of Concept Alloys, Inc.</p>
                            <p>Chromel A - is an alloy containing 80% of nickel and 20% chromium (by weight). It is used for its excellent resistance to high-temperature corrosion and oxidation. It is also commonly called Nichrome 80-20 and used for electric heating elements.</p>
                            <p>Chromel C - is an alloy containing 60% nickel, 16% chromium, and 24% iron. It is also commonly called Nichrome 60 and is used for heating elements, resistance windings, and hot wire cutters.</p>
                        </td>
                    </tr>
                    <tr>
            	        <td>Alumel<br />(Ni-Al)</td>
                        <td>
                            <p>Alumel is an alloy consisting of approximately 95% nickel, 2% manganese, 2% aluminium and 1% silicon. This magnetic alloy is used for thermocouples and thermocouple extension wire. Alumel is a registered trademark of Concept Alloys, Inc.</p>
                            <p>Properties of Alumel:<br />
                            Electrical Resistivity: 0.294 μΩm<br />
                            Thermal Conductivity: 30 W/m/K<br />
                            Curie Point:152°C</p>
                            <p>In thermocouples, alumel is often used together with chromel to form type K thermocouples.</p>
                        </td>
                    </tr>
                    <tr>
            	        <td>Iron<br />(Fe)</td>
                        <td>
                            <p>Commercially available iron is classified based on purity and the abundance of additives. Pig iron has 3.5–4.5% carbon and contains varying amounts of contaminants such as sulfur, silicon and phosphorus. Pig iron is not a saleable product, but rather an intermediate step in the production of cast iron and steel. The reduction of contaminants in pig iron that negatively affect material properties, such as sulfur and phosphorus, yields cast iron containing 2–4% carbon, 1–6% silicon, and small amounts of manganese. It has a melting point in the range of 1420–1470 K, which is lower than either of its two main components, and makes it the first product to be melted when carbon and iron are heated together. Its mechanical properties vary greatly and depend on the form the carbon takes in the alloy.</p>
                            <p>"White" cast irons contain their carbon in the form of cementite, or iron-carbide. This hard, brittle compound dominates the mechanical properties of white cast irons, rendering them hard, but unresistant to shock. The broken surface of a white cast iron is full of fine facets of the broken iron-carbide, a very pale, silvery, shiny material, hence the appellation.</p>
                            <p>In gray iron the carbon exists as separate, fine flakes of graphite, and also renders the material brittle due to the sharp edged flakes of graphite that produce stress concentration sites within the material. A newer variant of gray iron, referred to as ductile iron is specially treated with trace amounts of magnesium to alter the shape of graphite to spheroids, or nodules, reducing the stress concentrations and vastly increasing the toughness and strength of the material.</p>
                            <p>Wrought iron contains less than 0.25% carbon but large amounts of slag that give it a fibrous characteristic. It is a tough, malleable product, but not as fusible as pig iron. If honed to an edge, it loses it quickly. Wrought iron is characterized by the presence of fine fibers of slag entrapped within the metal. Wrought iron is more corrosion resistant than steel. It has been almost completely replaced by mild steel for traditional "wrought iron" products and blacksmithing.</p>
                            <p>Mild steel corrodes more readily than wrought iron, but is cheaper and more widely available. Carbon steel contains 2.0% carbon or less, with small amounts of manganese, sulfur, phosphorus, and silicon. Alloy steels contain varying amounts of carbon as well as other metals, such as chromium, vanadium, molybdenum, nickel, tungsten, etc. Their alloy content raises their cost, and so they are usually only employed for specialist uses. One common alloy steel, though, is stainless steel. Recent developments in ferrous metallurgy have produced a growing range of microalloyed steels, also termed 'HSLA' or high-strength, low alloy steels, containing tiny additions to produce high strengths and often spectacular toughness at minimal cost.</p>
                            <p>The main disadvantage of iron and steel is that pure iron, and most of its alloys, suffer badly from rust if not protected in some way. Painting, galvanization, passivation, plastic coating and bluing are all used to protect iron from rust by excluding water and oxygen or by cathodic protection.</p>
                        </td>
                    </tr>
                    <tr>
            	        <td>Tinned Copper<br />(TC)</td>
                        <td>
                            <p>Tinned copper wire is copper wire coated with a thin, electroplated layer of tin. This type of wire may be composed of a single tin-coated copper cable or many individually tinned strands of copper wire bound together. It is available in insulated versions and in uninsulated, or "buss wire," versions.</p>
                            <p>Tinning was originally developed to protect insulated copper wire from corrosive chemicals -- primarily sulfur -- released by wire-insulating materials. While no longer used in most wire insulation, these materials do sometimes show up in cable produced for a few high-environmental-stress industries, including waste-water treatment and paper milling. Tinning makes it easier to solder copper wire because it readily bonds to solder, which is itself largely made of tin. Tinned copper wire also suffers less corrosion at high temperatures than untinned copper.</p>
                        </td>
                    </tr>
                    <tr>
            	        <td>Stainless Steel<br />(SUS304)</td>
                        <td>
                            <p>Stainless steel, also known as inox steel or inox from French "inoxydable", is a steel alloy with a minimum of 10.5% chromium content by mass.</p>
                            <p>Oxidation<br />
                            High oxidation resistance in air at ambient temperature is normally achieved with additions of a minimum of 13% (by weight) chromium, and up to 26% is used for harsh environments. The chromium forms a passivation layer of chromium(III) oxide (Cr2O3) when exposed to oxygen. The layer is too thin to be visible, and the metal remains lustrous and smooth. The layer is impervious to water and air, protecting the metal beneath, and this layer quickly reforms when the surface is scratched. This phenomenon is called passivation and is seen in other metals, such as aluminium and titanium. Corrosion resistance can be adversely affected if the component is used in a non-oxygenated environment, a typical example being underwater keel bolts buried in timber.</p>
                            <p>When stainless steel parts such as nuts and bolts are forced together, the oxide layer can be scraped off, allowing the parts to weld together. When forcibly disassembled, the welded material may be torn and pitted, an effect known as galling. This destructive galling can be avoided by the use of dissimilar materials for the parts forced together, for example bronze and stainless steel, or even different types of stainless steels (martensitic against austenitic). However, two different alloys electrically connected in a humid environment may act as Voltaic pile and corrode faster. Nitronic alloys made by selective alloying with manganese and nitrogen may have a reduced tendency to gall. Additionally, threaded joints may be lubricated to prevent galling. Low temperature carburizing is another option that virtually eliminates galling and allows the use of similar materials without the risk of corrosion and the need for lubrication.</p>
                            <p>Acids<br />
                            Stainless steel is generally highly resistant to attack from acids, but this quality depends on the kind and concentration of the acid, the surrounding temperature, and the type of steel. Type 904 is resistant to sulfuric acid at room temperature, even in high concentrations, type 316 and 317 are resistant below 10% and 304 should not be used at any concentration. All types of stainless steel resist attack from phosphoric acid, 316 and 317 more so than 304; and Types 304L and 430 have been successfully used with nitric acid. Hydrochloric acid will damage any kind of stainless steel, and should be avoided.</p>
                            <p>Bases<br />
                            The 300 series of stainless steel grades is unaffected by any of the weak bases such as ammonium hydroxide, even in high concentrations and at high temperatures. The same grades of stainless exposed to stronger bases such as sodium hydroxide at high concentrations and high temperatures will likely experience some etching and cracking, especially with solutions containing chlorides such as sodium hypochlorite.</p>
                            <p>Organics<br />
                            Types 316 and 317 are both useful for storing and handling acetic acid, especially in solutions where it is combined with formic acid and when aeration is not present (oxygen helps protect stainless steel under such conditions), though 317 provides the greatest level of resistance to corrosion. Type 304 is also commonly used with formic acid though it will tend to discolor the solution. All grades resist damage from aldehydes and amines, though in the latter case grade 316 is preferable to 304; cellulose acetate will damage 304 unless the temperature is kept low. Fats and fatty acids only affect grade 304 at temperatures above 150 °C (302 °F), and grade 316 above 260 °C (500 °F), while 317 is unaffected at all temperatures. Type 316L is required for processing of urea.</p>
                            <p>Electricity and magnetism<br />
                            Similarly to steel, stainless steel is a relatively poor conductor of electricity, with a lower electrical conductivity than that of copper.</p>
                            <p>Ferritic and martensitic stainless steels are magnetic. Annealed Austenitic stainless steels are non-magnetic. Work hardening can make austenitic stainless steels slightly magnetic.</p>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>