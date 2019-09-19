<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PC04.aspx.cs" Inherits="nizing_intranet_PC04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
    .grdResultWithFooter{
    min-width:100%;
    }
    .grdResultWithFooter tr th{
        padding:4px;
        background-color:#29ABE2;
        color:#FFFFFF;
        border:solid 1px #ffffff;
    }
    .grdResultWithFooter tr th:nth-child(n+5){
        background-color:#9400D3;
    }
    .grdResultWithFooter tr td{
        padding:4px;
        background-color:#ffffff;
        color:#000000;
        text-align:center;
        border:solid 1px #ffffff;
    }
    .grdResultWithFooter tr:nth-child(2n) td{
        padding:4px;
        background-color:#c3e8f4;
        color:#000000;    
        text-align:center;
        border:solid 1px #ffffff;
    }
        .grdResultWithFooter tr td .bold{
        font-weight:bold;
    }
    .grdResultWithFooter tr:last-child td{
        padding:4px;
        background-color:#29ABE2;
        color:#FFFFFF;    
        text-align:center;
        font-weight:bold;
        border:solid 1px #ffffff;
    }
    .grdResultWithFooter .stackedHeader-1{
        background-color:#29ABE2;
    }
    .grdResultWithFooter .stackedHeader-2{
        background-color:#9400D3;
        color:#ffffff;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    
    <div class="container">
        <div id="formTitle" class="form-group">
            <div class="row">
                <div class="col-sm-12 h2">
                    商品銷貨統計表
                </div>
            </div>
        </div>        
        <div id="searchField" class="mb-3" style="border-bottom:solid 1px #cccccc">
            <div class="form-group">
                <div id="searchFieldDate">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                查詢開始年月
                            </span>                                    
                            <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="custom-select"/>
                            <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="custom-select"/>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">
                                    查詢結束年月
                                </span>                                    
                                <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select"/>
                                <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="custom-select"/>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="searchFieldSmallCategory">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <asp:CheckBox ID="ckxSmallCategory" runat="server" 
                                                AutoPostBack="true"
                                                OnCheckedChanged="ckxSmallCategory_CheckedChanged" />
                                        </div>     
                                        <span class="input-group-text">
                                            產品分類
                                        </span>                                
                                        <asp:DropDownList ID="ddlSmallCategory" runat="server" CssClass="custom-select"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="searchFieldID">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <asp:CheckBox ID="ckxID" runat="server" 
                                                AutoPostBack="true"
                                                OnCheckedChanged="ckxID_CheckedChanged" />
                                        </div>     
                                        <span class="input-group-text">
                                            品號查詢
                                        </span>
                                        <asp:TextBox ID="txtSearchID" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    <div style="border-bottom:solid 1px #cccccc">
                        <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-success form-control"
                            OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="displayField">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="gvResult" runat="server" CssClass="grdResultWithFooter"
                        AutoGenerateColumns="false"
                        ShowFooter="true"
                        OnRowCreated="gvResult_RowCreated"                       
                        OnRowDataBound="gvResult_RowDataBound"
                        OnDataBound="gvResult_DataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>品號</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label0" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                                                        
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>安全存量</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("safeInv") %>'></asp:Label>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>在庫量</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("invAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>年分</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("yr") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>01</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("01") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>02</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("02") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>03</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("03") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>04</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>05</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>06</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>07</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>08</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>09</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>10</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>11</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <span>12</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>                                    
                                    <span>小計</span>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAnnualSum" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            
        </div>
    </div>        
</asp:Content>

