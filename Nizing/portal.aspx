﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/index.master" AutoEventWireup="true" CodeFile="portal.aspx.cs" Inherits="portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DocTitleKeywords" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavaScriptCode" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main-content">
        <ul>
            <li>
                <asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl="~/hr360/login.aspx" ImageUrl="~/images/employee_section/portal/employee_section.png" />
            </li>
            <li>
                
                <asp:ImageButton ID="ImageButton2" runat="server" PostBackUrl="~/employee_section/Default.aspx" ImageUrl="~/images/employee_section/portal/add_credit.png" />
            </li>
        </ul>
    </div>    
</asp:Content>
