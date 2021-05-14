<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWD.master" AutoEventWireup="true" CodeFile="thermocouple-series.aspx.cs" Inherits="thermocouple_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>補償導線、熱電偶-日進電線</title>
    <meta name="keywords" content="補償導線,熱電偶" />
    <meta name="description" content="各式補償導線線材，包含RTD、K-Type 補償導線、J-Type 補償導線、T-Type 補償導線、R-Type 補償導線、S-Type 補償導線、E-Type 補償導線、手持式熱電偶，為溫度測量及感應線材">
    <link href="/css/RWD-ProductCategory.css" rel="stylesheet" />

    <style>
        .jumbotron {
            background: url("https://www.wallpapertip.com/wmimgs/33-330407_electrical-wiring.jpg");
            background-size: cover;
        }
    </style>
    <script>
        $(document).ready(function ($) {
            $('.product-category .navigation-row').click(function () {
                window.location = $(this).data('href');
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <div class="title">補償導線</div>
            <div class="subtitle">Thermocouple</div>
        </div>
    </div>
    <div class="product-subclass sticky-top">
        <nav class="navbar product-subclass-nav">
            <ul class="nav nav-pills">
                <li class="nav-item">
                    <a class="nav-link" href="#thermocouple">補償導線</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#rtd">RTD</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#thermo-probe">手持式熱電偶</a>
                </li>
            </ul>
        </nav>
    </div>
    <body data-spy="scroll" data-target=".product-subclass-nav" data-offset="56">
        <div id="thermocouple" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/etype-2.jpg" class="img d-block m-auto" alt="補償導線 Thermocouple E-Type J-Type K-Type R-Type S-Type T-Type" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">補償導線</div>
                                <p class="subtitle">Thermocouple</p>
                            </div>
                        </div>
                    </div>
                    <div class="row row-m-0">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-striped table-bordered">
                                    <tr>
                                        <th rowspan="2">代號
                                        </th>
                                        <th rowspan="2">熱電動勢
                                        </th>
                                        <th rowspan="2">溫度範圍
                                        </th>
                                        <th rowspan="2">優點
                                        </th>
                                        <th rowspan="2">缺點
                                        </th>
                                        <th colspan="2">材料
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>正極</th>
                                        <th>負極</th>
                                    </tr>
                                    <tr class="navigation-row" data-href="k-type.aspx">
                                        <td>K
                                        </td>
                                        <td>-200~1200 mV
                                        </td>
                                        <td>-200°C~+1200°C
                                        </td>
                                        <td>1. 廣泛應用於工業<br />
                                            2. 抗酸性安定佳<br />
                                            3. 具線性性質<br />
                                            4. 1000°C以下奈氧化性良
                                        </td>
                                        <td>1. 不適用於CO及亞硫酸瓦斯中<br />
                                            2. 在高溫還原性空氣中會劣化
                                        </td>
                                        <td>鉻、鎳
                                        </td>
                                        <td>鋁、錳、矽等鎳合金
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="e-type.aspx">
                                        <td>E
                                        </td>
                                        <td>-200~800 mV
                                        </td>
                                        <td>-200°C~+800°C
                                        </td>
                                        <td>1. 具有最大之熱電動勢<br />
                                            2. 現有熱電偶中感度最佳<br />
                                            3. 與J熱電偶相比，耐熱性良好<br />
                                            4. 兩腳不具磁性<br />
                                            5. 適於氧化性氣體環境
                                        </td>
                                        <td>1. 不耐於還原性中氣中使用<br />
                                            2. 電氣電阻大
                                        </td>
                                        <td>鉻、鎳
                                        </td>
                                        <td>鎳、銅
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="j-type.aspx">
                                        <td>J
                                        </td>
                                        <td>-200~350 mV
                                        </td>
                                        <td>-200°C~+750°C
                                        </td>
                                        <td>1. 耐於還原性空氣中使用<br />
                                            2. 熱電動勢較K熱電偶大20%<br />
                                            3. 價格較便宜，適用於中溫區域
                                        </td>
                                        <td>1. 容易生鏽<br />
                                            2. 再現性不佳
                                        </td>
                                        <td>鐵
                                        </td>
                                        <td>鎳、銅
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="t-type.aspx">
                                        <td>T
                                        </td>
                                        <td>-200~350 mV
                                        </td>
                                        <td>-200°C~+350°C
                                        </td>
                                        <td>1. 在弱酸性、還原性空氣中很安定<br />
                                            2. 熱電動勢之直線性良好<br />
                                            3. 低溫之特性良好<br />
                                            4. 再現性良好，高密度<br />
                                            5. 可使用於還原性氣體環境
                                        </td>
                                        <td>1. 300°C以上銅會氧化<br />
                                            2. 極限使用溫域低<br />
                                            3. 正極腳使用的銅材質容易氧化<br />
                                            4. 熱傳導誤差大
                                        </td>
                                        <td>銅
                                        </td>
                                        <td>鎳、銅
                                        </td>
                                    </tr>
                                    <tr class="navigation-row">
                                        <td>B
                                        </td>
                                        <td>500~1700 mV
                                        </td>
                                        <td>500°C~+1700°C
                                        </td>
                                        <td>1. 能耐於酸性空氣中<br />
                                            2. 適用於1000°C~1800°C之高溫測定<br />
                                            3. 於常溫環境下，熱電動勢非常小，不需補償導線<br />
                                            4. 耐氧化、耐藥品性良好<br />
                                            5. 耐熱性與機械強度較R型優良
                                        </td>
                                        <td>1. 不耐於還原性空氣中使用<br />
                                            2. 於中低溫域之熱電動勢極小，600°C以下測定溫度不準確<br />
                                            3. 感度不佳(熱電動勢值小)<br />
                                            4. 熱電動勢之直線性不佳<br />
                                            5. 價格高昂
                                        </td>
                                        <td>銠、白金
                                        </td>
                                        <td>銠、白金
                                        </td>
                                    </tr>
                                    <tr class="navigation-row" data-href="rs-type.aspx">
                                        <td>R/S
                                        </td>
                                        <td>0~1600 mV
                                        </td>
                                        <td>-200°C~+1600°C
                                        </td>
                                        <td>1. 耐熱性、安定性、再現性良好<br />
                                            2. 精準度優越<br />
                                            3. 耐氧化、耐藥品性良好<br />
                                            4. 可以作為標準使用
                                        </td>
                                        <td>1. 感度不佳(熱電動勢值小)<br />
                                            2. 於還原性氣體環境較脆弱(特別是氫、金屬蒸氣)<br />
                                            3. 補償導線誤差大<br />
                                            4. 價格高昂
                                        </td>
                                        <td>銠、白金
                                        </td>
                                        <td>銠、白金
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="rtd" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/rtd-1.jpg" class="img d-block m-auto" alt="RTD" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">RTD</div>
                                <p class="subtitle"></p>
                            </div>
                        </div>
                    </div>
                    <div class="row row-m-0">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-striped table-bordered">
                                    <tr>
                                        <th>代號
                                        </th>
                                        <th>溫度範圍
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="rtd.aspx">
                                        <td>RTD
                                        </td>
                                        <td>-30°C~+400°C
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="thermo-probe" class="main-block product-category">
            <div class="sub-block">
                <div class="container">
                    <div class="card w-100">
                        <div class="row row-m-0">
                            <div class="col-md-7">
                                <img src="/images/product_pic/tp-3.jpg" class="img d-block m-auto" alt="手持式熱電偶 thermo-probe" />
                            </div>
                            <div class="col-md-5">
                                <div class="title">手持式熱電偶</div>
                                <p class="subtitle">Thermo Probe</p>
                            </div>
                        </div>
                    </div>
                    <div class="row row-m-0">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-striped table-bordered">
                                    <tr>
                                        <th>代號
                                        </th>
                                        <th>特性
                                        </th>
                                    </tr>
                                    <tr class="navigation-row" data-href="tp.aspx">
                                        <td>Thermo Probe
                                        </td>
                                        <td>熱電偶加工之使用成品
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>        
    </body>
    <%--<div id="thermocouple-submenu">
        <div class="link">
            <div class="button">
                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/button/tp_button.jpg" NavigateUrl="~/tp.aspx" Text="手持式熱電偶"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/button/rtd_button.jpg" NavigateUrl="~/rtd.aspx" Text="RTD 補償導線"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/images/button/k_type_button.jpg" NavigateUrl="~/k-type.aspx" Text="K-Type 補償導線"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/images/button/j_type_button.jpg" NavigateUrl="~/j-type.aspx" Text="J-Type 補償導線"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/images/button/t_type_button.jpg" NavigateUrl="~/t-type.aspx" Text="T-Type 補償導線"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/images/button/r_s_type_button.jpg" NavigateUrl="~/rs-type.aspx" Text="R-Type S-Type 補償導線"></asp:HyperLink>
            </div>
            <div class="button">
                <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/button/e_type_button.jpg" NavigateUrl="~/e-type.aspx" Text="E-Type 補償導線"></asp:HyperLink>
            </div>
        </div>
        <div class="content">
            <div class="div-top-50">
                <div class="title">
                    何謂熱電偶
                </div>
                把兩種不同材質之金屬導體以電器連接(焊接)，使其產生一密閉迴路，在焊接點(即溫接點)加熱產生溫差，迴路中就會有電流流動，此現象稱為席貝克效應。如果將另一端(基準接點或稱冷接點)的溫度保持恆溫(一般設定為0°C)，則可依熱電動勢值(EMF)之大小換算出溫接點端的溫度。此兩種成對的金屬導體即稱為"熱電偶"。
                <br />
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/product_pic/thermocouple_principle.jpg" AlternateText="熱電偶 原理" />
            </div>
            <div class="div-top-50">
                <div class="title">
                    熱電動勢曲線圖
                </div>
                <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/images/product_pic/thermocouple_thermal_emf.jpg" NavigateUrl="~/images/product_pic/thermocouple_thermal_emf_large.jpg" Target="_blank"></asp:HyperLink>
            </div>
            <div class="div-bottom-100">
                <div class="title">
                    補償導線的種類
                </div>
                <table>
    	            <tr>
                        <th rowspan="2" colspan="2">偶記號<br />	Wire Type</th>
                        <th rowspan="2">熱電動勢<br />(mV)</th>
                        <th rowspan="2">測定溫度範圍<br />Measured Temperature Range<br />(°C)</th>
                        <th rowspan="2">優點<br />Advantage</th>
                        <th rowspan="2">缺點<br />Disadvantage</th>
                        <th colspan="2">材料</th>
    	            </tr>
                    <tr>
    	                <th>+</th>
                        <th>-</th>
                    </tr>                                                                                    
                    <tr>
                        <td rowspan="2">高溫</td>
                        <td rowspan="2">K</td>
                        <td rowspan="2" nowrap>-200~1200</td>
                        <td>-5.89/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. 廣泛應用於工業<br />2. 抗酸性安定佳<br />3. 具線性性質<br />4. 1000°C以下奈氧化性良</td>
                        <td rowspan="2" style="text-align:left">1. 不適用於CO及亞硫酸瓦斯中<br /> 2. 在高溫還原性空氣中會劣化</td>
                        <td>鉻</td>
                        <td rowspan="2">鋁、錳、矽等鎳合金</td>                  
                    </tr>
                    <tr>
    	                <td>48.8/1200°C</td>
                        <td>鎳</td>
                    </tr>
                    <tr>
        	            <td rowspan="4">中溫</td>
                        <td rowspan="2">E</td>
                        <td rowspan="2">-200~800</td>
                        <td>-8.82/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. 具有最大之熱電動勢<br />2. 現有熱電偶中感度最佳<br />3. 與J熱電偶相比，耐熱性良好<br />4. 兩腳不具磁性<br />5. 適於氧化性氣體環境</td>
                        <td rowspan="2" style="text-align:left">1. 不耐於還原性中氣中使用<br />2. 電氣電阻大</td>
            			<td>鉻</td>
                        <td>鎳</td>
                    </tr>
                    <tr>
        	            <td>61.02/800°C</td>
                        <td>鎳</td>
                        <td>銅</td>
                    </tr>
                    <tr>
                        <td rowspan="2">J</td>
                        <td rowspan="2">-200~350</td>
                        <td>-7.89/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. 耐於還原性空氣中使用<br />2. 熱電動勢較K熱電偶大20%<br />3. 價格較便宜，適用於中溫區域</td>
                        <td rowspan="2" style="text-align:left">1. 容易生鏽<br />2. 再現性不佳</td>
                        <td rowspan="2">鐵</td>
                        <td>鎳</td>  
                    </tr>
                    <tr>
        	            <td>72.28/750°C</td>
                        <td>銅</td>
                    </tr>
                    <tr>
                        <td rowspan="2">低溫</td>
                        <td rowspan="2">T</td>
                        <td rowspan="2">-200~350</td>
                        <td>-5.6/-200°C</td>
                        <td rowspan="2" style="text-align:left">1. 在弱酸性、還原性空氣中很安定<br />2. 熱電動勢之直線性良好<br />3. 低溫之特性良好<br />4. 再現性良好，高密度<br />5. 可使用於還原性氣體環境</td>
                        <td rowspan="2" style="text-align:left">1. 300°C以上銅會氧化<br />2. 極限使用溫域低<br />3. 正極腳使用的銅材質容易氧化<br />4. 熱傳導誤差大</td>           
                        <td rowspan="2">銅</td>
                        <td>鎳</td>
                    </tr>
                    <tr>
        	            <td>17.82/350°C</td>
                        <td>銅</td>
                    </tr> 
    	            <tr>
        	            <td rowspan="6" nowrap>耐高溫</td>
                        <td rowspan="2">B</td>
                        <td rowspan="2">500~1700</td>
                        <td>1.24/500°C</td>
                        <td rowspan="2" style="text-align:left">1. 能耐於酸性空氣中<br />2. 適用於1000°C~1800°C之高溫測定<br />3. 於常溫環境下，熱電動勢非常小，不需補償導線<br />4. 耐氧化、耐藥品性良好<br />5. 耐熱性與機械強度較R型優良</td>
                        <td rowspan="2" style="text-align:left">1. 不耐於還原性空氣中使用<br />2. 於中低溫域之熱電動勢極小，600°C以下測定溫度不準確<br />3. 感度不佳(熱電動勢值小)<br />4. 熱電動勢之直線性不佳<br />5. 價格高昂</td>
                        <td>銠</td>
                        <td>銠</td>
                    </tr>
                    <tr>
    	                <td>12.4/1700°C</td>
                        <td>白金</td>
                        <td>白金</td>
                    </tr>
                    <tr>
                        <td rowspan="2">R</td>
                        <td rowspan="4">0~1600</td>
                        <td>0/0°C</td>
                        <td rowspan="4" style="text-align:left">1. 耐熱性、安定性、再現性良好<br />2. 精準度優越<br />3. 耐氧化、耐藥品性良好<br />4. 可以作為標準使用</td>
                        <td rowspan="4" style="text-align:left">1. 感度不佳(熱電動勢值小)<br />2. 於還原性氣體環境較脆弱(特別是氫、金屬蒸氣)<br />3. 補償導線誤差大<br />4. 價格高昂</td>
                        <td>銠</td>
                        <td rowspan="2">白金</td>
                    </tr>
                    <tr>
    	                <td>18.84/1600°C</td>
                        <td>白金</td>
                    </tr>
                    <tr>
                        <td rowspan="2">S</td>
                        <td>-7.89/-200°C</td>
                        <td>銠</td>
                        <td rowspan="2">白金</td>
                    </tr>
                    <tr>
        	            <td>72.28/750°C</td>
                        <td>白金</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>--%>
</asp:Content>

