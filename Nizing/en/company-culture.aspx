<%@ Page Title="" Language="C#" MasterPageFile="~/en/master/child.master" AutoEventWireup="true" CodeFile="company-culture.aspx.cs" Inherits="company_culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
    <title>Culture - Nizing Electric Wire & Cable</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleRow" Runat="Server">
    Culture
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitleLink" Runat="Server">
    <a href="company-intro.aspx">Introduction</a> | <a href="company-culture.aspx" class="active">Culture</a> | <a href="company-history.aspx">History</a> | <a href="company-capability.aspx">Capability</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="company-culture">
        <div class="inner-content">
            <div class="content-row">
                <div class="text">
                    Nizing employees treasure and value our every chance of service. It is our principle to server our customers with sincerity and reliability. Innovation and the Pursuit of Excellence is incorporated into our day-to-day operation. We believe that only with immovable resolve, great passion, high efficiency, and responsible attitude, can we create a long and sustainable relationsip with our customers.
                    <p>Nizing is a harbor to all of its employees. We come together not only for business, but to enrich ourselves as we help the company grow, and finally work as one to bring the absolute best service to satisfy our customers. That is our core value.</p>
                </div>
                <div class="img">
                    <div style="float:right;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/en/images/company/comany-culture3.jpg" />
                    </div>
                    <div>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/en/images/company/comany-culture1.jpg" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

