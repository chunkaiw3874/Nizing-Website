<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/nizing-master.master" AutoEventWireup="true" CodeFile="IC_DailyProductPreparationList.aspx.cs" Inherits="nizing_intranet_IC_DailyProductPreparationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        th {
            text-align: center;
        }

        text-center {
            text-align: center;
        }

        table th:hover {
            cursor: context-menu;
        }

        table td:hover {
            cursor: pointer;
        }

        .btn-search {
            color: white;
        }

            .btn-search:hover {
                color: white;
            }

        .btn-group.full-width {
            width: 100%;
        }

        .full-width .btn {
            flex: 1
        }

        .popover .btn-search a {
            padding-top: 7px;
        }

        .overlay {
            position: fixed;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background: rgba(0, 0, 0, 0.7);
            transition: opacity 500ms;
            visibility: hidden;
            opacity: 0;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="popover"]').popover({
                container: 'body',
                title: '查詢歷史單據',
                html: true,
                offset: 5,
                placement: 'right',
                sanitize: false,
                content: function () {
                    return $("#popover-content").html();
                }
            });
        })

        function GettxtSalesRecordIdvalue() {
            $('[id*=hdnSalesRecordId]').val($('.popover .form-control').val());
            $('.popover').popover('hide');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
        </Services>
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnSalesRecordId" runat="server" />

    <div id="popover-content" class="d-none">
        <div class="input-group">
            <asp:TextBox ID="txtSalesRecordId" runat="server" CssClass="form-control" MaxLength="8" placeholder="銷貨單號(前八碼)"></asp:TextBox>
            <div class="input-group-append btn-search">
                <asp:LinkButton ID="btnSalesRecordDataSearch" runat="server" class="btn btn-sm btn-primary" OnClick="btnSalesRecordDataSearch_Click" OnClientClick="GettxtSalesRecordIdvalue()">
                        <i class="fas fa-search"></i>
                </asp:LinkButton>
            </div>
        </div>
    </div>

    <div id="recordDetail" class="modal fade" data-backdrop="static" aria-labelledby="recordDetail" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ADD NEW BANQUET</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">單別</span>
                        </div>
                        <asp:Label ID="lblModalRecordType" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">單號</span>
                        </div>
                        <asp:Label ID="lblModalRecordId" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">序號</span>
                        </div>
                        <asp:Label ID="lblModalItemNumber" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="btn-group full-width" role="group">
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="取消"
                            data-dismiss="modal" />
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"
                            CssClass="btn btn-success btn-lg btn-block" Text="儲存" UseSubmitBehavior="false"
                            data-dismiss="modal" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="form-group">
            <span class="h2">倉管備貨明細表</span>
        </div>
        <div class="row form-group">
            <div class="col-sm-12 btn-search">
                <a class="btn btn-lg btn-primary"
                    data-toggle="popover">
                    <i class="fas fa-search"></i>
                </a>
            </div>
        </div>
        <asp:UpdatePanel ID="upDataParameter" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">銷貨單號</span>
                    </div>
                    <asp:Label ID="lblSalesRecordId" runat="server" CssClass="form-control"></asp:Label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSalesRecordDataSearch" />
            </Triggers>
        </asp:UpdatePanel>
        <hr />
        <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <asp:GridView ID="gvSalesRecordData" runat="server" CssClass="table table-striped table-hover table-white"
                        AutoGenerateColumns="false"
                        OnSelectedIndexChanged="gvSalesRecordData_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="箱數">
                                <ItemTemplate>
                                    <asp:Label ID="lblBoxAmount" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶">
                                <ItemTemplate>
                                    <asp:HiddenField ID="lblSalesRecordType" Value='<%#Eval("單別") %>' runat="server" />
                                    <asp:HiddenField ID="lblSalesRecordId" Value='<%#Eval("單號") %>' runat="server" />
                                    <asp:HiddenField ID="lblSalesRecordItemNumber" Value='<%#Eval("序號") %>' runat="server" />
                                    <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("客戶簡稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品號">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductId" runat="server" Text='<%#Eval("品號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("品名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="規格">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("規格") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="數量">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductAmount" runat="server" Text='<%#Eval("數量") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductUnit" runat="server" Text='<%#Eval("單位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="庫別">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductInv" runat="server" Text='<%#Eval("庫別") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="儲位">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductInvDetail" runat="server" Text='<%#Eval("儲位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="送貨地址">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerDeliverAddress" runat="server" Text='<%#Eval("送貨地址") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSalesRecordDataSearch" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>

