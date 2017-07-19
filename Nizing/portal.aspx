<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.master" AutoEventWireup="true" CodeFile="portal.aspx.cs" Inherits="portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-content">
        <ul>
            <li>
                <a href="hr360/login.aspx" target="_blank"><img src="images/employee_section/portal/HR360.png" /></a>
                <%--<asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl="~/hr360/login.aspx" ImageUrl="~/images/employee_section/portal/HR360.png" />--%>
            </li>
            <li> 
                <a href="employee_section/Default.aspx" target="_blank"><img src="images/employee_section/portal/nizing.png" /></a>
                <%--<asp:ImageButton ID="ImageButton2" runat="server" PostBackUrl="~/employee_section/Default.aspx" ImageUrl="~/images/employee_section/portal/add_credit.png" />--%>
            </li>
            <li> 
                <a href="revivify_employee_section/Default.aspx" target="_blank"><img src="images/employee_section/portal/RVI.png" /></a>
                <%--<asp:ImageButton ID="ImageButton2" runat="server" PostBackUrl="~/employee_section/Default.aspx" ImageUrl="~/images/employee_section/portal/add_credit.png" />--%>
            </li>
            <li>
                <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/oqs.aspx">Test Link</asp:HyperLink>--%>
            </li>
        </ul>
    </div>    
</asp:Content>

