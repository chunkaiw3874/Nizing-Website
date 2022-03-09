<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/product.master" AutoEventWireup="true" CodeFile="teflon-series.aspx.cs" Inherits="teflon_series" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" runat="Server">
    <title>Teflon Wire Series - Nizing Electric Wire & Cable</title>
    <meta name="description" content="All types of Teflon Wires and Cables, the best choice for corrosion resistance and generally all types of chemical resistance. We sport PTFE such as UL1199, UL10344, UL10393, FEP such as UL1330, UL1331, UL1332, UL1887, UL1901, VDE8219, VDE8220, VDE REG-NR8295, PFA such as UL1709, UL1710, UL1726, UL1727, UL10362, ETFE such as UL10109, medical grade FEP-Silicone Wire, signal transmitting RG178B/U, RG179, RG316 Coaxial Cables, and an abundance of other wire and cable models and customized products.">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" integrity="sha384-1CmrxMRARb6aLqgBO7yyAxTOQE2AKb9GfXnEo760AUcUmFx3ibVJJAzGytlQcNXd" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/32e9a84b4a.js" crossorigin="anonymous"></script>
    <style>
        .navigation-row {
            cursor: pointer;
        }

        .scrollable-300 {
            max-height: 300px;
            overflow: auto;
        }
    </style>
    <script>
        $(document).ready(function ($) {
            $('.navigation-row').click(function () {
                window.location = $(this).data('href');
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="mb-2 d-block">
            <div class="row">
                <h5>Teflon Wire
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-wire-black-menu.jpg" class="img-fluid" alt="Teflon Wire" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>Code
                        </th>
                        <th>Characteristic
                        </th>
                        <th>Voltage
                        </th>
                        <th>Temperature
                        </th>
                        <th>Composition
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="ul1199.aspx">
                        <td>UL1199
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated/Nickel-Plated Copper<br />
                            Insulation: PTFE
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1330.aspx">
                        <td>UL1330
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1331.aspx">
                        <td>UL1331
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1332.aspx">
                        <td>UL1332
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>300V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1709.aspx">
                        <td>UL1709
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>300V
                        </td>
                        <td>-100°C~+200°C
                        </td>
                        <td>Conductor: Tinned Copper<br />
                            Insulation: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1710.aspx">
                        <td>UL1710
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+200°C
                        </td>
                        <td>Conductor: Tinned Copper<br />
                            Insulation: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1726.aspx">
                        <td>UL1726
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>300V
                        </td>
                        <td>-80°C~+250°C
                        </td>
                        <td>Conductor: Tinned Copper<br />
                            Insulation: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1727.aspx">
                        <td>UL1727
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-80°C~+250°C
                        </td>
                        <td>Conductor: Tinned Copper<br />
                            Insulation: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1813.aspx">
                        <td>UL1813
                        </td>
                        <td>Heat Resistant, Chemical Resistant, High Voltage
                        </td>
                        <td>3000V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1887.aspx">
                        <td>UL1887
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated/Nickel-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul1901.aspx">
                        <td>UL1901
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10109.aspx">
                        <td>UL10109
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>300V
                        </td>
                        <td>-40°C~+150°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10344.aspx">
                        <td>UL10344
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+250°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated/Nickel-Plated Copper<br />
                            Insulation: PTFE
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10362.aspx">
                        <td>UL10362
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-80°C~+250°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: PFA
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul10393.aspx">
                        <td>UL10393
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-100°C~+250°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated/Nickel-Plated Copper<br />
                            Insulation: PTFE
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul11331.aspx">
                        <td>UL11331
                        </td>
                        <td>Heat Resistant, Chemical Resistant
                        </td>
                        <td>600V
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul11817.aspx">
                        <td>UL11817
                        </td>
                        <td>Heat Resistant, Chemical Resistant, High Voltage
                        </td>
                        <td>3000V
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>Teflon Multi-Core Wire
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-multicore-wire-white-menu.jpg" class="img-fluid"
                    width="220"
                    alt="Teflon Multi-Core Wire" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>Code
                        </th>
                        <th>Characteristic
                        </th>
                        <th>Voltage
                        </th>
                        <th>Temperature
                        </th>
                        <th>Composition
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="ul2748.aspx">
                        <td>UL2748
                        </td>
                        <td>Heat Resistant, Chemical Resistant, Multi-Core
                        </td>
                        <td>600V AC
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP<br />
                            Jacket: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul2750.aspx">
                        <td>UL2750
                        </td>
                        <td>Heat Resistant, Chemical Resistant, Multi-Core
                        </td>
                        <td>600V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP<br />
                            Jacket: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul2894.aspx">
                        <td>UL2894
                        </td>
                        <td>Heat Resistant, Chemical Resistant, Multi-Core
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+150°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP<br />
                            Jacket: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="ul2895.aspx">
                        <td>UL2895
                        </td>
                        <td>Heat Resistant, Chemical Resistant, Multi-Core
                        </td>
                        <td>300V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP<br />
                            Jacket: FEP
                        </td>
                    </tr>
                    <tr class="navigation-row" data-href="teflon-silicone-medical-wire.aspx">
                        <td>Medical Wire
                        </td>
                        <td>Heat Resistant, Multi-Core, Multi-Layer
                        </td>
                        <td>600V AC
                        </td>
                        <td>-60°C~+200°C
                        </td>
                        <td>Conductor: Tinned/Silver-Plated Copper<br />
                            Insulation: FEP<br />
                            Jacket: Silicone Rubber
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>Multi-Layer Teflon Wire
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-multi-layer-wire-white-menu.jpg" class="img-fluid"
                    width="220"
                    alt="Multi-Layer Teflon Wire" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>Code
                        </th>
                        <th>Characteristic
                        </th>
                        <th>Voltage
                        </th>
                        <th>Temperature
                        </th>
                        <th>Composition
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="vde-reg-nr8295.aspx">
                        <td>VDE REG-NR8295
                        </td>
                        <td>Heat Resistant, Chemical Resistant, Multi-Layer
                        </td>
                        <td>300V AC/500V DC
                        </td>
                        <td>-100°C~+180°C
                        </td>
                        <td>Conductor: Tinned Copper<br />
                            Insulation: FEP
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="mb-2 d-block">
            <div class="row">
                <h5>Teflon Coaxial Cable
                </h5>
            </div>
            <div class="row mb-1">
                <img src="images/product_pic/teflon-coaxial-cable-clear-menu.jpg" class="img-fluid"
                    alt="Teflon Coaxial Cable" />
            </div>
            <div class="scrollable-300 row">
                <table class="table table-hover table-sm">
                    <tr>
                        <th>Code
                        </th>
                        <th>Characteristic
                        </th>
                        <th>Voltage
                        </th>
                        <th>Temperature
                        </th>
                        <th>Composition
                        </th>
                    </tr>
                    <tr class="navigation-row" data-href="rg178bu-rg179-rg316.aspx">
                        <td>RG178B/U RG179 RG316
                        </td>
                        <td>Coaxial
                        </td>
                        <td>30V
                        </td>
                        <td>-70°C~+200°C
                        </td>
                        <td>Conductor: Silver-Plated銅絲/Silver-Plated銅包鋼<br />
                            Insulation: FEP
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--<div id="product-submenu">
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/en/images/product_pic/ul1199-menu.jpg" alt="UL1199 PTFE Teflon Wire" NavigateUrl="ul1199.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1199<br />
                    PTFE Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-100°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PTFE</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/product_pic/ul1330-menu.jpg" alt="UL1330 FEPTeflon Wire" NavigateUrl="~/ul1330.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1330<br />
                    FEPTeflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/en/images/product_pic/ul1331-menu.jpg" alt="UL1331 FEP Teflon Wire" NavigateUrl="ul1331.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1331<br />
                    FEP Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/en/images/product_pic/ul1332-menu.jpg" alt="UL1332 FEP Teflon Wire" NavigateUrl="ul1332.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1332<br />
                    FEP Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/en/images/product_pic/ul1709-menu.jpg" alt="UL1709 PFA Teflon Wire" NavigateUrl="ul1709.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1709<br />
                    PFA Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-100°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink6" runat="server" ImageUrl="~/en/images/product_pic/ul1710-menu.jpg" alt="UL1710 PFA Teflon Wire" NavigateUrl="ul1710.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1710<br />
                    PFA Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-100°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/en/images/product_pic/ul1726-menu.jpg" alt="UL1726 PFA Teflon Wire" NavigateUrl="ul1726.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1726<br />
                    PFATeflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-80°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink8" runat="server" ImageUrl="~/en/images/product_pic/ul1727-menu.jpg" alt="UL1727 PFA Teflon Wire" NavigateUrl="ul1727.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1727<br />
                    PFA Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-80°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink9" runat="server" ImageUrl="~/en/images/product_pic/ul1887-menu.jpg" alt="UL1887 FEP Teflon Wire" NavigateUrl="ul1887.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1887<br />
                    FEP Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink10" runat="server" ImageUrl="~/en/images/product_pic/ul1901-menu.jpg" alt="UL1901 FEP Teflon Wire" NavigateUrl="ul1901.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL1901<br />
                    FEP Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/en/images/product_pic/ul10109-menu.jpg" alt="UL10109 ETFE Teflon Wire" NavigateUrl="ul10109.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10109<br />
                    ETFE Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-40°C~ +150°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>ETFE</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink12" runat="server" ImageUrl="~/en/images/product_pic/ul10344-menu.jpg" alt="UL10344 PTFE Teflon Wire" NavigateUrl="ul10344.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10344<br />
                    PTFE Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-100°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PTFE</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink13" runat="server" ImageUrl="~/en/images/product_pic/ul10362-menu.jpg" alt="UL10362 PFA Teflon Wire" NavigateUrl="ul10362.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10362<br />
                    PFA Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-80°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PFA</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink14" runat="server" ImageUrl="~/en/images/product_pic/ul10393-menu.jpg" alt="UL10393 PTFE Teflon Wire" NavigateUrl="ul10393.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    UL10393<br />
                    PTFE Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-100°C~ +250°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>PTFE</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink15" runat="server" ImageUrl="~/en/images/product_pic/vde8219-menu.jpg" alt="VDE8219 FEP Teflon Wire" NavigateUrl="vde-8219.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE8219<br />
                    FEP Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V/ 500V AC</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-80°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                        <tr>
                            <td>Jacket:</td>
                            <td>FEP Teflon</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink16" runat="server" ImageUrl="~/en/images/product_pic/vde8220-menu.jpg" alt="VDE8220 FEP Teflon Wire" NavigateUrl="vde-8220.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE8220<br />
                    FEPTeflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>450V AC/750V DC</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-80°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned/Silver-Plated/Nickel-Plated Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink17" runat="server" ImageUrl="~/en/images/product_pic/vde_reg-nr8295-menu.jpg" alt="VDE REG-NR8295 Double Insulation Teflon Wire" NavigateUrl="vde-reg-nr8295.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    VDE REG-NR8295<br />
                    Double Insulation Teflon Wire<br />
                    Home Appliances Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>300V AC/500V DC</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-100°C~ +180°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink18" runat="server" ImageUrl="~/en/images/product_pic/teflon_silicone_medical_wire-menu.jpg" alt="Teflon Silicone Medical Wire" NavigateUrl="teflon-silicone-medical-wire.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    Medical Wire<br />
                    Teflon Silicone Medical Wire<br />
                    Meding Wiring
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>600V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-60°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Tinned Copper</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                        <tr>
                            <td>Jacket:</td>
                            <td>Silicone Rubber</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content-row">
            <div class="content-column">
                <div class="button">
                    <asp:HyperLink ID="HyperLink19" runat="server" ImageUrl="~/en/images/product_pic/rg178-menu.jpg" alt="RG178B/U RG179 RG316 Coaxial Cable" NavigateUrl="rg178bu-rg179-rg316.aspx"></asp:HyperLink>
                </div>
                <div class="title">
                    RG178B/U RG179 RG316<br />
                    Coaxial Cable<br />
                    Signal Transmitting Device
                </div>
                <div class="data">
                    <table>
                        <tr>
                            <td>Nominal Voltage:</td>
                            <td>30V</td>
                        </tr>
                        <tr>
                            <td>Nominal Temperature:</td>
                            <td>-70°C~ +200°C</td>
                        </tr>
                        <tr>
                            <td>Conductor:</td>
                            <td>Silver coated Copper/Silver coated Copper Clad Steel</td>
                        </tr>
                        <tr>
                            <td>Insulation:</td>
                            <td>FEP</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>

