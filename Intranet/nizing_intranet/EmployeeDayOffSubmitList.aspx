<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDayOffSubmitList.aspx.cs" Inherits="nizing_intranet_EmployeeDayOffSubmitList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <style type="text/css">
        .form-control[readonly] {
            background-color: #ffffff;
        }

        .section {
            padding-top: 12px;
            padding-bottom: 12px;
            border-bottom: solid 1px #CCCCCC;
        }

            .section.no-border {
                border: none;
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                language: 'zh-TW',
                format: 'yyyy-mm-dd',
                autoclose: true,
                todayBtn: true,
                todayHighlight: true
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="h2">
            請假單清單
        </div>
        <div class="section">
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">請假日期</span>
                </div>
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control datepicker"></asp:TextBox>
                <div class="input-group-append">
                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-success"
                        OnClick="btnSubmit_Click">
                    <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
            </Triggers>
            <ContentTemplate>
                <div class="section no-border">
                    <div class="table-responsive">
                        <asp:GridView ID="gvResult" runat="server"
                            class="table table-striped-blue"
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        員工ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("員工ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        員工名稱
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("員工名稱") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        請假開始時間
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("請假開始時間") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        請假結束時間
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("請假結束時間") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        請假單狀態
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("請假單狀態") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

