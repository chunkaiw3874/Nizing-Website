<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PD04_KeyInFormAmount.aspx.cs" Inherits="nizing_intranet_PD04_KeyInFormAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <style>
        .btn-group.flex {
            display: flex;
        }

        .flex .btn {
            flex: 1;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                language: 'zh-TW',
                format: 'yyyymmdd',
                autoclose: true,
                todayBtn: true,
                todayHighlight: true
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div id="formTitle" class="form-group">
            <div class="row">
                <div class="col-sm-12 h2">
                    打單數量報表
                </div>
            </div>
        </div>
        <div id="searchField" class="pb-3" style="border-bottom: solid 1px #cccccc">
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <asp:RadioButton ID="rdoYear" runat="server" GroupName="ReportPeriod" CssClass="input-group-text" />
                        <span class="input-group-text">年報表
                        </span>
                    </div>
                    <asp:DropDownList ID="ddlSearchYear" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
                <div class="input-group mb-2">
                    <div class="input-group-prepend">
                        <asp:RadioButton ID="rdoMonth" runat="server" GroupName="ReportPeriod" CssClass="input-group-text" Checked="true" />
                        <span class="input-group-text">月報表
                        </span>
                    </div>
                    <asp:DropDownList ID="ddlSearchMonth" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <asp:RadioButton ID="rdoCustom" runat="server" GroupName="ReportPeriod" CssClass="input-group-text" />
                        <span class="input-group-text">自選查詢範圍
                        </span>
                    </div>
                    <asp:TextBox ID="txtStartDate" CssClass="form-control datepicker bg-white" placeholder="開始查詢日期" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtEndDate" CssClass="form-control datepicker bg-white" placeholder="結束查詢日期" runat="server"></asp:TextBox>
                </div>
                <div class="btn-group flex mt-3" role="group">
                    <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-secondary btn-success"
                        OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnExportToExcel" runat="server" Text="匯出" CssClass="btn btn-secondary btn-success"
                        OnClick="btnExportToExcel_Click" />
                </div>
            </div>
        </div>
        <div id="displayField" class="pt-3">
            <asp:Label ID="lblQueryRange" runat="server" Text="{查詢範圍}"></asp:Label>
            <div class="table-responsive">
                <asp:GridView ID="gvResult" runat="server"
                    CssClass="table table-striped-blue table-has-footer"
                    AutoGenerateColumns="false"
                    ShowFooter="true"
                    OnDataBound="gvResult_DataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("#") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                人員姓名
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("人員姓名") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                小記:
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                報價單
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPI" runat="server" Text='<%#Eval("報價單") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblPITotal" runat="server" Text="Label"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                訂單
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPO" runat="server" Text='<%#Eval("訂單") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblPOTotal" runat="server" Text="Label"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                銷貨單
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSO" runat="server" Text='<%#Eval("銷貨單") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSOTotal" runat="server" Text="Label"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                總數
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("總數") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblAllTotal" runat="server" Text="Label"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

