﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerTransactionReport.aspx.cs" Inherits="CustomerTransactionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="title">
        <h2>客戶年度成交狀況</h2>
    </div>
    <div id="scope">
        <asp:Label ID="Label1" runat="server" Text="查詢範圍"></asp:Label>
        <asp:DropDownList ID="ddlStartYear" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlStartMonth" runat="server">
            <asp:ListItem Value="1226">01</asp:ListItem>
            <asp:ListItem Value="0126">02</asp:ListItem>
            <asp:ListItem Value="0226">03</asp:ListItem>
            <asp:ListItem Value="0326">04</asp:ListItem>
            <asp:ListItem Value="0426">05</asp:ListItem>
            <asp:ListItem Value="0526">06</asp:ListItem>
            <asp:ListItem Value="0626">07</asp:ListItem>
            <asp:ListItem Value="0726">08</asp:ListItem>
            <asp:ListItem Value="0826">09</asp:ListItem>
            <asp:ListItem Value="0926">10</asp:ListItem>
            <asp:ListItem Value="1026">11</asp:ListItem>
            <asp:ListItem Value="1126">12</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="~"></asp:Label>
        <asp:DropDownList ID="ddlEndYear" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlEndMonth" runat="server">
            <asp:ListItem Value="0125">01</asp:ListItem>
            <asp:ListItem Value="0225">02</asp:ListItem>
            <asp:ListItem Value="0325">03</asp:ListItem>
            <asp:ListItem Value="0425">04</asp:ListItem>
            <asp:ListItem Value="0525">05</asp:ListItem>
            <asp:ListItem Value="0625">06</asp:ListItem>
            <asp:ListItem Value="0725">07</asp:ListItem>
            <asp:ListItem Value="0825">08</asp:ListItem>
            <asp:ListItem Value="0925">09</asp:ListItem>
            <asp:ListItem Value="1025">10</asp:ListItem>
            <asp:ListItem Value="1125">11</asp:ListItem>
            <asp:ListItem Value="1225">12</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="查詢業務"></asp:Label>
        <asp:DropDownList ID="ddlPersonnel" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="TG006">
        <asp:ListItem Selected="True">全部人員</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT DISTINCT TG006, MV002
        FROM COPTG
	    LEFT JOIN CMSMV MV ON TG006 = MV001
        WHERE TG006 &lt;&gt; ''
        ORDER BY TG006"></asp:SqlDataSource>  
        <br />
        <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
    </div>
    <br />
    <div id="button">
        <asp:Button ID="btnReport" runat="server" Text="查詢" OnClick="btnReport_Click" />
    </div>
    <br />
    <div id="report">
        <asp:GridView ID="grdReport" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false" CssClass="grdResult" OnDataBound="grdReport_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="年度">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("YR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客戶代號">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("CLIENTNO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客戶名稱">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("CLIENTNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="負責業務">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("SALENAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="一月">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("01") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="二月">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("02") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="三月">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("03") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="四月">
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="五月">
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="六月">
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="七月">
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="八月">
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="九月">
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="十月">
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="十一月">
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="十二月">
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="總金額">
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server" Text='<%#Eval("TOTAL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
