<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ABC_Comparison.aspx.cs" Inherits="ABC_Comparison" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
    .grdReport{
        width:100%;
    }
    .grdReport tr td{
        text-align:center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>客戶銷貨淨額成長率</h2>
        <asp:Label ID="Label1" runat="server" Text="選擇起始年月"></asp:Label>
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
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="選擇結束年月"></asp:Label>
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
        <br />
        <asp:Button ID="btnGenerateReport" runat="server" Text="查詢" OnClick="btnGenerateReport_Click" />
        <asp:HiddenField ID="hdnNewStart" runat="server" />
        <asp:HiddenField ID="hdnNewEnd" runat="server" />
        <asp:HiddenField ID="hdnPrevStart" runat="server" />
        <asp:HiddenField ID="hdnPrevEnd" runat="server" />
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>        
    </div>
    <div style="color:red;margin-bottom:10px;">
        *「去年同期銷貨淨額」為您的查詢期間之年份減1<br />
        例:<br />
        查詢期間為2016年1月~2016年6月<br />
        去年同期為2015年1月~2015年6月
    </div>
    <div style="width:800px;">
        <asp:Label ID="lblScope" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" ShowFooter="true" OnDataBound="grdReport_DataBound" OnRowCreated="grdReport_RowCreated" CssClass="grdResultWithFooter">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="今年度排名">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("RN")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客戶代號">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("CUSTID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客戶名稱">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("CUSTNAME")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="負責業務">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("SALESNAME")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="今年查詢期間銷貨淨額">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("SALENOW")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="去年同期銷貨淨額">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("SALEPREV")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="銷貨淨額成長率">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("GROWTH")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

