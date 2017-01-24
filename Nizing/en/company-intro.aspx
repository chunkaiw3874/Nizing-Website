<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="company-intro.aspx.cs" Inherits="company_intro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Introduction - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Introduction
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx" class="active">Introduction</a> | <a href="company-culture.aspx">Culture</a> | <a href="company-history.aspx">History</a> | <a href="company-capability.aspx">Capability</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-intro">
        <div class="inner-content">
            <div class="content-row">
                <div class="text">
                    Nizing Electric Co. Ltd is established in 1983. We started out specializing in heat-resistant wires and cables, and grew to become the leading manufactuerer of special wires and cable. We also successfully crossed into green energy and optoelectronic industries, and brought our enterprise to the international level.
        	        <p>The Silicone Wire, Thermocouple, PVC Wire, and other products manufactured by Nizing Electric are widely used in infrastructures such as telecom network, electricity grid, transportation, and industrial production. Our core products include Silicone Wire, Thermocouple, PVC Wire, XLPE Wire, Fluoropolymer Wire. We have complete production lines to satisfy our customers' every need, both local and abroad.</p>
	                <p>Since 2003, Nizing Electric has been devoting resources into developing LED, Temperature Control, Medical, Cloud System, and Solar Power Industries, crossing fields to make sure that we are always in sync with the world's leading technology.</p>
                    <p>Nizing Electric has a full range of products, certified with the highest standard. We continue to develop new products, and serve our customers with the utmost passion. We strive to be not just another supplier, but THE supplier that our customers can depend on and grow with.</p>
                </div>
                <div class="img">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/en/images/company/company-intro4.jpg" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

