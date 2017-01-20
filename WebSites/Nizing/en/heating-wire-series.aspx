<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/product.master" AutoEventWireup="true" CodeFile="heating-wire-series.aspx.cs" Inherits="heating_wire_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Heating Wire Series - Nizing Electric Wire & Cable</title>
    <meta name="description" content="All types of heating wires, including UL3589 for medical aspiration pipe, Parallel Heating Cable for surface heating, and an abundance of other wire and cable models and customized products.">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/product_pic/ul3589-menu.jpg" alt="UL3589 Heating Wire" NavigateUrl="ul3589.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL3589<br />
                    Heating Wire<br />
                    Medical Breathing Circuit, Electric Blanket
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Electrical Resistance:</td>
                            <td>1~2000 Ohm</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +200°C FT-1</td>
                        </tr>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V/600V</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Twinning Alloy</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>Silicone Rubber, Fiberglass</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/en/images/product_pic/phc-menu.jpg" alt="PHC Parallel Heating Cable" NavigateUrl="phc.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    PHC<br />
                    Heating Wire<br />
                    Greenhouse Cultivation, Tank and Tube Heating, Electric Heating Floor Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>110V/230V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Twining Alloy, Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>Silicone Rubber</td>
                        </tr>
                        <tr>
                            <td>Shielding:</td>
                            <td>Silicone Rubber</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

