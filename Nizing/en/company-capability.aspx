<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="company-capability.aspx.cs" Inherits="company_capability" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Production Capability - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Capability
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">Introduction</a> | <a href="company-culture.aspx">Culture</a> | <a href="company-history.aspx">History</a> | <a href="company-capability.aspx" class="active">Capability</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-capability">
        <div class="inner-content">
            <ajaxToolkit:TabContainer ID="capabilityDetail" runat="server" ActiveTabIndex="0" CssClass="CapabilityTab">
                <ajaxToolkit:TabPanel runat="server" HeaderText="Capability" ID="TabPanel1">
                    <ContentTemplate>
                        <h4>Commercial Wire Products</h4>
                        <p>Appliance Wire. Fixture Wiry, High Voltage Wire High-Temperature Wire, Machine Tool Wire, Motor Lead Wire, Signal Wire, Silicone Wire, Fluoropolymer Wire, Test Lead Wire.</p>
                        <h4>Commercial Cable Products</h4>
                        <p>Alarm, Audio/Sound, CATV, Micro Coaxial, Data Control, Patenred Slim Flat Ethernet Cable, High Temperature, Cable, Heating Cable, lnstrumentation Cable, Local Area Network Cable, Multi-Conductor Cable, Multi-Pair Cable, Plenum Cable, Robotic Cable, Shielded/Unshielded, Potented Super Slim Flat Telephone Cord, Thermocouple, Tray Cable, UL/CSA Approved, Ultra Flexible, Voice and Data, USB 2.0 Cable.</p>
                        <h4>Conductor & Stranding</h4>
                        <p>Bare Copper, Bunched Strands. Concentric Lay Stranding, Copper Clad Steel, High Strength Copper Alloy, Nickel Plated Copper, Pure Silver, Rope Lay Stranding, Silver Plated Copper, Tinned Copper, Tinsel Copper, Unilary Stranding.</p>
                        <h4>Shielding</h4>
                        <p>Spiral, Braiding, AL/MY, PTEE TAPE, Mylar...</p>
                        <h4>Insulation & Jacket Material</h4>
                        <p>FEP, Fiberglass Braids, Hytrel, Nylon, Low Smoke/Halogen Free, PFA, Polyethylene, Polypropylene, Polyurethane, PTFE, PVC, Silicone Rubber, Tefzel. TPR, TPE, TPU, TPV(Santoprene, Sarlink...), PUR, etc.</p>
                        <h4>Reinforcement</h4>
                        <p>Kevlar, Nylon yarn, cotton yarn, Nomex, Technora, Fiberglass...</p>
                        <h4>Custom Engineering</h4>
                        <p>Custom made OEM & ODM Service.</p>
                        <div class="img">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/en/images/company/company-capability1.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/en/images/company/company-capability2.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/en/images/company/company-capability3.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/en/images/company/company-capability4.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/en/images/company/company-capability5.jpg" />
                        </div>
                        <div class="img">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/en/images/company/company-capability6.jpg" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Machine" ID="TabPanel2">
                    <ContentTemplate>
                        <div class="img">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/en/images/company/company-capability-machine1.jpg" />
                            Motorized Pay off
                        </div>
                        <div class="img">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/en/images/company/company-capability-machine2.jpg" />
                            Temperature Control Box
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/en/images/company/company-capability-machine3.jpg" />
                            Automatic Feeder
                        </div>
                        <div class="img">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/en/images/company/company-capability-machine4.jpg" />
                            Extrusion Machine
                        </div>
                        <div class="img">
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/en/images/company/company-capability-machine5.jpg" />
                            Haul Off Unit
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/en/images/company/company-capability-machine6.jpg" />
                            Automatic Coiler
                        </div>
                        <div class="img">
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/en/images/company/company-capability-machine7.jpg" />
                            Braiding Machine
                        </div>
                        <div class="img">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/en/images/company/company-capability-machine8.jpg" />
                            Stranding Machine
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/en/images/company/company-capability-machine9.jpg" />
                            Digital Labeler
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" HeaderText="Test Equipment" ID="TabPanel3">
                    <ContentTemplate>
                        <div class="img">
                            <asp:Image ID="Image16" runat="server" ImageUrl="~/en/images/company/company-capability-test1.jpg" />
                            Flex-Life Tester
                        </div>
                        <div class="img">
                            <asp:Image ID="Image17" runat="server" ImageUrl="~/en/images/company/company-capability-test2.jpg" />
                            Insulator Tester
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image18" runat="server" ImageUrl="~/en/images/company/company-capability-test3.jpg" />
                            Flame Retardance Tester
                        </div>
                        <div class="img">
                            <asp:Image ID="Image19" runat="server" ImageUrl="~/en/images/company/company-capability-test4.jpg" />
                            Safety Tester
                        </div>
                        <div class="img">
                            <asp:Image ID="Image20" runat="server" ImageUrl="~/en/images/company/company-capability-test5.jpg" />
                            Multimeter
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image21" runat="server" ImageUrl="~/en/images/company/company-capability-test6.jpg" />
                            Aging Oven
                        </div>
                        <div class="img">
                            <asp:Image ID="Image22" runat="server" ImageUrl="~/en/images/company/company-capability-test7.jpg" />
                            Tensile Strength Tester
                        </div>
                        <div class="img">
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/en/images/company/company-capability-test8.jpg" />
                            Voltage Tester
                        </div>
                        <div class="img" style="margin-right:0px;">
                            <asp:Image ID="Image24" runat="server" ImageUrl="~/en/images/company/company-capability-test9.jpg" />
                            Laser OD Measurer
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
</asp:Content>

