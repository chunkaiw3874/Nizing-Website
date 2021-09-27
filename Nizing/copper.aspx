<%@ Page Title="" Language="C#" MasterPageFile="~/master/RWDConductorMaster.master" AutoEventWireup="true" CodeFile="copper.aspx.cs" Inherits="copper" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <title>日進電線-純銅</title>
    <meta name="keywords" content="電線,導體,純銅,Wire,Conductor,Copper" />
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="banner" runat="Server">
    <div class="container-fluid">
        <div class="banner">
            <img src="/images/banner/banner-materials-en-1920x500.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="Server">
    <div class="display-block-wrapper material-item">
        <div class="container">
            <div class="display-block">
                <div class="title">
                    純銅系列
                </div>
                <div class="subtitle">
                    Copper
                </div>
                <div class="content">
                    <div class="image-frame">
                        <img src="/images/material/conductor/copper/copper-1.jpg" class="image shadow" alt="電線導體 銅 Wire Conductor Pure Copper" />
                        <div class="image-text">
                            純銅
                        </div>
                    </div>
                    <div>
                        <p>產品：高導性無氧銅線(棒)、單方向結晶無氧銅線(棒)</p>
                        <p>
                            線徑 (可電鍍銀、錫、鋅、鎳等)：OFC-0.1-16mm / 其餘-0.1-8.0mm
                        </p>
                        <p>
                            特性：具有『超高無氧』、『高純度』及『高導電』等特點。
                        </p>
                        <p>
                            應用：喇叭線、漆包線、鍍銀銅線、鍍錫銅線、冷鍛用材料、各種電子導體、製罐用熔接線、高溫熔射用線、銅製程構裝用導線及太陽能導電帶等。
                        </p>
                        <div class="table-responsive">
                            <table class="table table-striped-blue">
                                <tr>
                                    <th></th>
                                    <th>無氧銅線<br />
                                        OFC</th>
                                    <th>高導性無氧銅線<br />
                                        OFHC</th>
                                    <th>單方向結晶無氧銅線<br />
                                        PCVCC-02</th>
                                    <th>單方向結晶無氧銅線<br />
                                        PCVCC-03</th>
                                </tr>
                                <tr>
                                    <td>純度<br />
                                        (%)</td>
                                    <td>≧99.95</td>
                                    <td>≧99.99</td>
                                    <td>≧99.99</td>
                                    <td>≧99.99</td>
                                </tr>
                                <tr>
                                    <td>氧含量<br />
                                        (ppm)</td>
                                    <td>≦15</td>
                                    <td>&lt; 1</td>
                                    <td>&lt; 1</td>
                                    <td>&lt; 1</td>
                                </tr>
                                <tr>
                                    <td>導電率<br />
                                        (%IACS)</td>
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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/material/conductor/copper/PCVCC-02.png" />
                                    </td>
                                    <td>
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/material/conductor/copper/PCVCC-03.png" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


