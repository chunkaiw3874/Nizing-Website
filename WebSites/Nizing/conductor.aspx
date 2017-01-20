<%@ Page Title="" Language="C#" MasterPageFile="~/master/child.master" AutoEventWireup="true" CodeFile="conductor.aspx.cs" Inherits="conductor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>日進電線-導體</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    導體
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="plastic.aspx">塑料</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="silicone.aspx">矽膠</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="teflon.aspx">鐵氟龍</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="twinning.aspx">纏繞編織材料</asp:HyperLink> | 
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="conductor.aspx" CssClass="active">導體</asp:HyperLink>
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
            	        <td>無氧銅<br />(OFC)</td>
                        <td>根據含氧量和雜質含量，無氧銅又分爲一號和二號無氧銅。一號無氧銅純度達到99.97%，氧含量不大於0.003%，雜質總含量不大於0.03%；二號無氧銅純度達到99.95%，氧含量不大於0.003%，雜質總含量不大於0.05%。<br />
                        無氧銅無氫脆現象，導電率高，加工性能和焊接性能、耐蝕性能和低溫性能均好。各國對於含氧量的標准也不完全相同，存在一定的差異。<br />
                        OFC（無氧銅）：純度爲99.995% 的金屬銅。一般用於音響器材、真空電子器件、電纜等電工電子應用之中。其中無氧銅中又有 LC-OFC（線形結晶無氧銅或結晶無氧銅）：純度在99.995%以上和OCC（單晶無氧銅）：純度最高，在99.996%以上，又分爲PC-OCC和UP-OCC 等。<br />
                        采用UP-OCC技術（Ultra Pure Copper by Ohno Continuous Casting Process）制造的單結晶無氧銅，無方向性、高純度、防腐蝕、極低的電氣阻抗使得線材適合高速優質的傳輸信號。</td>
                    </tr>
                    <tr>
            	        <td>銅鎳合金<br />(Ni-Cu)</td>
                        <td>銅鎳合金，銅Cu 跟鎳Ni,呈銀白色，有金屬光澤，故名白銅。銅鎳之間彼此可無限固溶，從而形成連續固溶體，即不論彼此的比例多少，而恆為α--單相合金。當把鎳熔入紅銅裡D200，含量超過16%以上時，產生的合金色澤就變得相對近白如銀，鎳含量越高，顏色越白，但是，畢竟與銅融合，只要鎳含量比例不超過70%，肉眼都會看到銅的黃色。白銅密度在銅和鎳之間，為8.9-8.88。<br />
                        純銅加鎳能顯著提高強度、耐蝕性、硬度、電阻和熱電性，並降低電阻率溫度係數。因此白銅較其他銅合金的機械性能、物理性能都異常良好，延展性好、硬度高、色澤美觀、耐腐蝕富有深衝性能，被廣泛使用於造船、石油化工、電器、儀表、醫療機械、日用品、工藝品等領域，並還是重要的電阻和熱電偶合金。白銅的缺點就是主要添加元素——鎳屬於稀缺的戰略物資，價格比較昂貴。</td>
                    </tr>
                    <tr>
            	        <td>鎳鉻合金<br />(Ni-Cr)</td>
                        <td>此合金具有高強度和抗腐蝕性，常用於切削工具；用噴鍍、沉積和高溫擴散等方法在鋼或鐵的表面形成抗腐蝕合金層；重鉻酸鉀和重鉻酸鈉是有機合成和石油工業中的強氧化劑；鉻黃、鉻橙、鉻綠等可用作無機顏料。鎳鉻合金還可用於製實驗室用電阻。高電阻電熱合金（高鎳及鐵鉻鋁）、高溫合金、精密合金、耐熱合金、特種合金、不銹鋼等都是常見和常用的鎳鉻合金.在長度，橫截面積一定時，溫度越低，鎳鉻合金的電阻越大，這與一般的規律是相反的。鎳鉻合金在真空鍍膜行業也應用較廣，可以做成一定比例的合金靶材，作磁控濺射鍍膜的原材料。</td>
                    </tr>
                    <tr>
            	        <td>鎳鋁合金<br />(Ni-Al)</td>
                        <td>鋁鎳合金別稱雷氏合金，具有活性較高的催化性能，乾燥的鋁鎳合金在空氣中能自燃，應保存在無水乙醇中。它是一種還原或加氫反應的催化劑，多用於有機合成中。</td>
                    </tr>
                    <tr>
            	        <td>鐵<br />(Fe)</td>
                        <td>鐵是有光澤的銀白色金屬，硬而有延展性，熔點為1538°C，沸點為2750°C，有很強的鐵磁性，並有良好的可塑性和導熱性。晶體結構為體心立方結構，晶格常數a=2.87埃。日常生活中的鐵通常含有碳因而暴露在氧氣中容易在遇到水的情況下發生電化學腐蝕，而純度較高的鐵則不易腐蝕</td>
                    </tr>
                    <tr>
            	        <td>鍍錫銅<br />(TC)</td>
                        <td>鍍錫銅是指表面鍍有一薄層金屬錫的銅，如鍍錫銅線。錫在空氣中形成二氧化錫薄膜，防止進一步氧化，錫與鹵素也能形成類似作用的薄膜。從而既具有良好的抗腐蝕性能,又有一定的強度和硬度,成型性好又易焊接,錫層無毒無味,能防止鐵溶進被包裝物。</td>
                    </tr>
                    <tr>
            	        <td>不鏽鋼<br />(SUS304)</td>
                        <td>
                            <table>
                                <tr>
                                    <td>200系列：</td>
                                    <td>鉻-鎳-錳奧氏體不鏽鋼</td>
                                </tr>
                                <tr>
                                    <td>300系列：</td>
                                    <td>鉻-鎳奧氏體不鏽鋼</td>
                                </tr>
                                <tr>
                                    <td>型號301：</td>
                                    <td>延展性好，用於成型產品。也可通過機械加工使其迅速硬化。焊接性好。抗磨性和疲勞強度優於304不鏽鋼，產品如：彈簧、鋼構、車輪蓋。</td>
                                </tr>
                                <tr>
                                    <td>型號302：</td>
                                    <td>耐腐蝕性同304，由於含碳相對要高因而強度更好。</td>
                                </tr>
                                <tr>
                                    <td>型號303：</td>
                                    <td>通過添加少量的硫、磷使其較304更易切削加工。</td>
                                </tr>
                                <tr>
                                    <td>型號304：</td>
                                    <td>通用型號；即18/8不鏽鋼。產品如：耐蝕容器、餐具、家俱、欄杆、醫療器材。標準成分是18 %鉻加8 %鎳。為無磁性、當雜質含量高時,加工後偶爾會呈現弱磁性、此弱磁性只能使用熱處理的方式消除。屬於無法藉由熱處理方法來改變其金相組織結構的不鏽鋼。</td>
                                </tr>
                                <tr>
                                    <td>型號304 L：</td>
                                    <td>與304相同特性，但低碳故更耐蝕、易熱處理，但機械性較差適用焊接及不易熱處理之產品。</td>
                                </tr>
                                <tr>
                                    <td>型號304 N：</td>
                                    <td>與304相同特性，是一種含氮的不鏽鋼，加氮是為了提高鋼的強度。</td>
                                </tr>
                                <tr>
                                    <td>型號309：</td>
                                    <td>較之304有更好的耐溫性。</td>
                                </tr>
                                <tr>
                                    <td>型號309 S：</td>
                                    <td>具多量鉻、鎳，故耐熱、抗氧化性佳，產品如：熱交換器、鍋爐零組件、噴射引擎。</td>
                                </tr>
                                <tr>
                                    <td>型號310 S：</td>
                                    <td>含最多量鉻、鎳，故耐熱、抗氧化性最佳熱交換器、鍋爐零組件、電機設備。</td>
                                </tr>
                                <tr>
                                    <td>型號316：</td>
                                    <td>繼304之後，第二個得到最廣泛應用的鋼種，主要用於食品工業和外科手術器材，添加鉬元素使其獲得一種抗腐蝕的特殊結構。由於較之304其具有更好的抗氯化物腐蝕能力因而也作「船用鋼」來使用。SS316則通常用於核燃料回收裝置。18/10級不鏽鋼通常也符合這個應用級別。特用於化學、海邊等易腐蝕環境、船舶裝配、建材。</td>
                                </tr>
                                <tr>
                                    <td>型號316 L：</td>
                                    <td>低碳故更耐蝕、易熱處理，產品如：化學加工設備、核能發電機、冷凍劑儲槽。</td>
                                </tr>
                                <tr>
                                    <td>型號321：</td>
                                    <td>除了因為添加了鈦元素降低了材料焊縫鏽蝕的風險之外其他性能類似304，適於焊接釀酒設備、蒸氣管、航空零件。</td>
                                </tr>
                                <tr>
                                    <td>型號347：</td>
                                    <td>添加安定化元素鈮，適於焊接航空器具零件及化學設備。</td>
                                </tr>
                                <tr>
                                    <td>400系列：</td>
                                    <td>肥粒鐵和馬氏體不鏽鋼</td>
                                </tr>
                                <tr>
                                    <td>型號408：</td>
                                    <td>耐熱性好，弱抗腐蝕性，11 %的Cr，8 %的Ni。</td>
                                </tr>
                                <tr>
                                    <td>型號409：</td>
                                    <td>除了因為添加了鈦元素，最廉價的型號（英美），通常用作汽車排氣管，屬肥粒鐵不鏽鋼（鉻鋼），適於焊接，成本較低汽車排氣管、石油設備。</td>
                                </tr>
                                <tr>
                                    <td>型號410：</td>
                                    <td>馬氏體（高強度鉻鋼），耐磨性好，抗腐蝕性較差，適於幫浦。其化學成分含13 %鉻、0.15 %以下的碳及少量的其他元素合金。原料價格較便宜，具有磁性、可經由熱處理硬化。一般用途有軸承、醫療用具及刀具等。</td>
                                </tr>
                                <tr>
                                    <td>型號416：</td>
                                    <td>添加了硫改善了材料的加工性能。</td>
                                </tr>
                                <tr>
                                    <td>型號420：</td>
                                    <td>含較高碳、硬度、強度更高，刃具級馬氏體不鏽鋼，類似布氏不鏽鋼（Brearley's stainless steel，英國治金家Harry Brearley）這種最早的不鏽鋼，可以做的非常光亮，適於刀、彈簧、外科器具、剃刀切頭、閥。</td>
                                </tr>
                                <tr>
                                    <td>型號430：</td>
                                    <td>肥粒鐵不鏽鋼，裝飾用，具磁性，例如用於汽車飾品。良好的成型性，但耐溫性和抗腐蝕性要差，適於扣接件、餐具、家具用品。其標準化學成份為16～18 %鉻，含碳量低。此類不銹鋼具有磁性。</td>
                                </tr>
                                <tr>
                                    <td>型號434：</td>
                                    <td>含鉬故耐蝕性較430優良，適於餐具、雨刷、汽車裝璜。</td>
                                </tr>
                                <tr>
                                    <td>型號440：</td>
                                    <td>高強度刃具鋼，含碳稍高，經過適當的熱處理後可以獲得較高屈服強度，硬度可以達到58HRC，屬於最硬的不鏽鋼之列。最常見的應用例子就是「剃鬚刀片」。常用型號有三種：440A、440B、440C，另外還有440F（易加工型）。</td>
                                </tr>
                                <tr>
                                    <td>500系列：</td>
                                    <td>耐熱鉻合金鋼。</td>
                                </tr>
                                <tr>
                                    <td>600系列：</td>
                                    <td>馬氏體沉澱硬化不鏽鋼。</td>
                                </tr>
                                <tr>
                                    <td>型號630：</td>
                                    <td>最常用的沉澱硬化不鏽鋼型號，通常也叫17－4；17 % Cr，4 % Ni。</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>