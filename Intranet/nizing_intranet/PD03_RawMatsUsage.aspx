<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PD03_RawMatsUsage.aspx.cs" Inherits="nizing_intranet_PD03_RawMatsUsage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .grdResultWithFooter {
            min-width: 100%;
        }

            .grdResultWithFooter tr th {
                padding: 4px;
                background-color: #29ABE2;
                color: #FFFFFF;
                border: solid 1px #ffffff;
            }

                .grdResultWithFooter tr th:nth-child(n+6) {
                    background-color: #9400D3;
                }

            .grdResultWithFooter tr td {
                padding: 4px;
                background-color: #ffffff;
                color: #000000;
                text-align: center;
                border: solid 1px #ffffff;
            }

            .grdResultWithFooter tr:nth-child(2n) td {
                padding: 4px;
                background-color: #c3e8f4;
                color: #000000;
                text-align: center;
                border: solid 1px #ffffff;
            }

            .grdResultWithFooter tr td .bold {
                font-weight: bold;
                /*background-color:#faf0bb*/
            }

            .grdResultWithFooter tr:last-child td {
                padding: 4px;
                background-color: #29ABE2;
                color: #FFFFFF;
                text-align: center;
                font-weight: bold;
                border: solid 1px #ffffff;
            }

            .grdResultWithFooter .stackedHeader-1 {
                background-color: #29ABE2;
            }

            .grdResultWithFooter .stackedHeader-2 {
                background-color: #9400D3;
                color: #ffffff;
            }

        .btn-group.flex {
            display: flex;
        }

        .flex .btn {
            flex: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div id="formTitle" class="form-group">
            <div class="row">
                <div class="col-sm-12 h2">
                    原物料年用量表
                </div>
            </div>
        </div>
        <div>
            <div id="searchField" class="pb-3" style="border-bottom: solid 1px #cccccc">
                <div class="form-group">
                    <div id="searchFieldDate">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">開始年份
                                </span>
                            </div>
                            <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="custom-select" />
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">結束年份
                                </span>
                            </div>
                            <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select" />
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="searchFieldRawMatsCategory">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <asp:RadioButton ID="rdoRawMatsCategory" runat="server" GroupName="QueryParameter" />
                                        </div>
                                        <span class="input-group-text">原物料分類</span>
                                    </div>
                                    <asp:DropDownList ID="ddlRawMatsCategory" runat="server" CssClass="custom-select"></asp:DropDownList>
                                </div>
                            </div>
                            <div id="searchFieldLargeCategory">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <asp:RadioButton ID="rdoLargeCategory" runat="server" GroupName="QueryParameter" />
                                        </div>
                                        <span class="input-group-text">大成品分類</span>
                                    </div>
                                    <asp:DropDownList ID="ddlLargeCategory" runat="server" CssClass="custom-select"></asp:DropDownList>
                                </div>
                            </div>
                            <div id="searchFieldSmallCategory">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <asp:RadioButton ID="rdoSmallCategory" runat="server" GroupName="QueryParameter" />
                                        </div>
                                        <span class="input-group-text">小成品分類</span>
                                    </div>
                                    <asp:DropDownList ID="ddlSmallCategory" runat="server" CssClass="custom-select"></asp:DropDownList>
                                </div>
                            </div>
                            <div id="searchFieldID">
                                <div class="input-group mb-3">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">
                                            <asp:RadioButton ID="rdoID" runat="server" GroupName="QueryParameter" />
                                        </div>
                                        <span class="input-group-text">品號&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                    </div>
                                    <asp:TextBox ID="txtSearchID" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="input-group mb-3">
                        <asp:CheckBox ID="ckxNoDisplayWhenInvAndSafeInvIsZero" runat="server" Checked="true" Text="不顯示安全存量、在庫量為0且當年未領料的品項" />
                    </div>
                    <div class="btn-group flex" role="group">
                        <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-secondary btn-success"
                            OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnExportToExcel" runat="server" Text="匯出" CssClass="btn btn-secondary btn-success"
                            OnClick="btnExportToExcel_Click" />
                    </div>
                </div>
            </div>
            <div id="displayField" class="pt-3">
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
                                        品號
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label0" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        安全存量
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("safeInv") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        在庫量
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("invAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        單位
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("unit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        年分
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("yr") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        01
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("01") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        02
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("02") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        03
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("03") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        04
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        05
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        06
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        07
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        08
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        09
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        10
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        11
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        12
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        小計
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

