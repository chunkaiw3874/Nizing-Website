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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div id="formTitle" class="form-group">
            <div class="row">
                <div class="col-sm-12 h2">
                    客戶銷貨淨額成長率123
                </div>
            </div>
        </div>
        <div id="searchField" class="mb-3" style="border-bottom:solid 1px #cccccc">
            <div class="form-group">
                <div id="searchFieldDate">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                查詢起始年月
                            </span>
                            <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="custom-select"></asp:DropDownList>
                            <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="custom-select">
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
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                查詢結束年月
                            </span>
                            <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select"></asp:DropDownList>
                            <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="custom-select">
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
                        </div>
                    </div>
                </div>
                <div id="searchFieldSales">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                查詢業務
                            </span>
                            <asp:DropDownList ID="ddlPersonnel" runat="server" CssClass="custom-select" 
                                AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="TG006">
                            <asp:ListItem Selected="True">全部人員</asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT DISTINCT TG006, MV002
                            FROM COPTG
	                        LEFT JOIN CMSMV MV ON TG006 = MV001
                            WHERE TG006 &lt;&gt; ''
                            ORDER BY TG006"></asp:SqlDataSource>  
                        </div>
                    </div>
                    <div id="searchFieldButton" class="mb-3">
                        <asp:Button ID="btnGenerateReport" runat="server" Text="查詢"
                             CssClass="btn btn-success form-control"
                             OnClick="btnGenerateReport_Click" />
                    </div>
                    
                    <asp:HiddenField ID="hdnNewStart" runat="server" />
                    <asp:HiddenField ID="hdnNewEnd" runat="server" />
                    <asp:HiddenField ID="hdnPrevStart" runat="server" />
                    <asp:HiddenField ID="hdnPrevEnd" runat="server" />
                    
                </div>   
            </div>
        </div>
        <div>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>     
        </div>
        <div style="color:red;margin-bottom:10px;">
            *「去年同期銷貨淨額」為您的查詢期間之年份減1<br />
            例:<br />
            查詢期間為2016年1月~2016年6月<br />
            去年同期為2015年1月~2015年6月
        </div>
        <div>
            <asp:Label ID="lblScope" runat="server"></asp:Label>
        </div>
        <div id="displayField">
            <div class="row">
                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>           
                    <asp:GridView ID="grdReport" runat="server"
                        AutoGenerateColumns="False" ShowFooter="true" OnDataBound="grdReport_DataBound" 
                        OnRowCreated="grdReport_RowCreated" CssClass="grdResultWithFooter" OnRowCommand="grdReport_RowCommand">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="今年度排名">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="今年度排名" CommandName="Sort" CommandArgument="RN" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("RN")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶代號">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Text="客戶代號" CommandName="Sort" CommandArgument="CUSTID" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("CUSTID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶名稱">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Text="客戶名稱" CommandName="Sort" CommandArgument="CUSTNAME" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("CUSTNAME")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="負責業務">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" Text="負責業務" CommandName="Sort" CommandArgument="SALESNAME" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("SALESNAME")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="今年查詢期間銷貨淨額">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton5" runat="server" Text="今年查詢期間銷貨淨額" CommandName="Sort" CommandArgument="SALENOW" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("SALENOW")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="去年同期銷貨淨額">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton6" runat="server" Text="去年同期銷貨淨額" CommandName="Sort" CommandArgument="SALEPREV" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("SALEPREV")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="銷貨淨額成長率">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton7" runat="server" Text="銷貨淨額成長率(%)" CommandName="Sort" CommandArgument="GROWTH" ForeColor="White"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("GROWTH")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>            
                </div>
            </div>
        </div>
    </div>
</asp:Content>

