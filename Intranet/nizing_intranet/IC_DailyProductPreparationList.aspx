<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/nizing-master.master" AutoEventWireup="true" CodeFile="IC_DailyProductPreparationList.aspx.cs" Inherits="nizing_intranet_IC_DailyProductPreparationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            font-size: 0.8rem;
        }

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

        .form-check input {
            height: 14px;
            width: 14px;
            margin-bottom: 5px;
        }

        .color-box-wrapper {
            display: inline-flex;
            align-content: start;
            margin-right: 5px;
        }

        .color-box {
            width: 12px;
            height: 12px;
            border-radius: 50%;
            display: inline-block;
            margin-right: 3px;
        }

        .color-box-text {
            display: inline-block;
            line-height: 12px;
        }

        textarea {
            resize: none;
        }

        .text-as-label {
            padding: 0;
            background-color: inherit;
            min-height: 100%;
            width: 100%;
        }

        .scrollable-table {
            max-width: 100%;
            max-height: 500px;
            overflow: auto;
            margin-bottom: 10px;
            border: solid 1px #000000;
        }

        .caption {
            width: 100%;
            margin-top: 1rem;
            margin-bottom: 1rem;
            font-size: 1.25rem;
            display: none;
        }

        .popover {
            z-index: 0;
        }

            .popover .btn-search a {
                padding-top: 7px;
            }

        @media print {
            body * {
                visibility: hidden;
            }

            .printarea, .printarea * {
                visibility: visible;
            }

            .printarea {
                position: absolute;
                left: 0;
                top: 0;
                font-size: 1rem;
            }

            .caption {
                display: inline;
            }
        }
    </style>
    <script type="text/javascript">

        function ResizeTextareaToCellSize() {
            //$('.text-as-label').parent().resize(
            //    function () {
            //        var $t = $(this);
            //        $t.find('.text-as-label').height($t.height());
            //    }).resize();
        };
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

        $('.popover').on('hidden.bs.popover', function () {
            //$('.popover').find('.popover .form-control').focus();
            alert('popup hide~');
        })

        $(document).on('keypress', function (e) {
            if (e.which == 13) {
                console.log('enter is detected');
            }
        })


        function GettxtSalesRecordIdvalue() {
            $('[id*=hdnSalesRecordId]').val($('.popover .form-control').val());
            $('.popover').popover('hide');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
    <asp:UpdatePanel ID="upDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="recordDetail" class="modal fade" data-backdrop="static" aria-labelledby="recordDetail" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">備貨資料</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="text-right text-black-50 font-weight-light">
                                <asp:Label ID="txtModalEditTime" runat="server"></asp:Label>
                            </div>
                            <asp:HiddenField ID="hdnModalCustomerId" runat="server" />
                            <asp:HiddenField ID="hdnModalProductAmount" runat="server" />
                            <asp:HiddenField ID="hdnModalProductPrice" runat="server" />
                            <asp:HiddenField ID="hdnModalProductInv" runat="server" />
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">單號</span>
                                </div>
                                <asp:Label ID="lblModalRecordFullId" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">客戶</span>
                                </div>
                                <asp:Label ID="lblModalCustomerName" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">品號</span>
                                </div>
                                <asp:Label ID="lblModalProductId" runat="server" CssClass="form-control" Text="Label"></asp:Label>
                            </div>
                            <hr />
                            <h6>辦公室填寫:</h6>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="ckxModalAttachUl" runat="server" Text="附UL" />
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="ckxModalNoReceipt" runat="server" Text="不附單據" />
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="ckxModalNoSegments" runat="server" Text="不可有接頭" />
                            </div>
                            <div class="form-group">
                                <label for="txtModalItemMemo">包裝注意事項:</label>
                                <asp:TextBox ID="txtModalItemMemo" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <hr />
                            <h6>倉管填寫:</h6>
                            <div class="form-check form-check-inline">
                                <asp:CheckBox ID="ckxModalRequireAttention" runat="server" Text="有異動，請倉管注意(倉管確認後取消勾選)" />
                            </div>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">包裝數量</span>
                                </div>
                                <asp:TextBox ID="txtModalPackingAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:DropDownList ID="ddlModalPackingUnit" runat="server" CssClass="custom-select">
                                        <asp:ListItem>箱</asp:ListItem>
                                        <asp:ListItem>公斤</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <div class="btn-group full-width" role="group">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="取消"
                                    data-dismiss="modal" />
                                <asp:Button ID="btnSaveDetail" runat="server" OnClick="btnSaveDetail_Click"
                                    CssClass="btn btn-success" Text="儲存" UseSubmitBehavior="false"
                                    data-dismiss="modal" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvSalesRecordData" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="container">
        <div class="form-group">
            <span class="h2">倉管備貨明細表</span>
        </div>
        <div class="row form-group">
            <div class="col-sm-12 btn-search mr-2">
                <a class="btn btn-lg btn-primary"
                    data-toggle="popover">
                    <i class="fas fa-search"></i>
                </a>
                <asp:LinkButton ID="btnSalesRecordRefresh" runat="server" class="btn btn-lg btn-primary" ToolTip="更新表格">
                    <i class="fas fa-sync-alt"></i>
                </asp:LinkButton>
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
        <div class="form-group">
            <div class="color-box-wrapper">
                <div class="color-box" style="background-color: lightblue"></div>
                <div class="color-box-text">包裝為0</div>
            </div>
            <div class="color-box-wrapper">
                <div class="color-box" style="background-color: palevioletred"></div>
                <div class="color-box-text">有異動，請倉管確認</div>
            </div>
        </div>
        <div class="scrollable-table">
            <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="printarea">
                        <div class="caption">
                            <asp:Label ID="lblgvSalesRecordDataCaption" runat="server" Text="caption here"></asp:Label>
                        </div>
                        <div style="display: inline;">
                            <asp:Label ID="lblTotalPackedBoxes" runat="server" Text="Label"></asp:Label>
                        </div>
                        <asp:GridView ID="gvSalesRecordData" runat="server" CssClass="table table-striped table-hover table-white"
                            AutoGenerateColumns="false"
                            OnPreRender="gridView_PreRender"
                            OnSelectedIndexChanged="gvSalesRecordData_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="包裝" HeaderStyle-Width="100">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPackage" runat="server" Text='<%#Eval("包裝數量").ToString() + Eval("包裝單位").ToString() %>'></asp:Label>
                                        <asp:HiddenField ID="lblPackageAmount" runat="server" Value='<%#Eval("包裝數量")%>' />
                                        <asp:HiddenField ID="lblPackageUnit" runat="server" Value='<%#Eval("包裝單位")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客戶">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("客戶簡稱") %>'></asp:Label>
                                        <asp:HiddenField ID="lblCustomerId" Value='<%#Eval("客戶代號") %>' runat="server" />
                                        <asp:HiddenField ID="lblSalesRecordType" Value='<%#Eval("單別") %>' runat="server" />
                                        <asp:HiddenField ID="lblSalesRecordId" Value='<%#Eval("單號") %>' runat="server" />
                                        <asp:HiddenField ID="lblSalesRecordItemNumber" Value='<%#Eval("序號") %>' runat="server" />
                                        <asp:HiddenField ID="lblProductPrice" Value='<%#Eval("單價") %>' runat="server" />
                                        <asp:HiddenField ID="ckxRequireAttention" runat="server" Value='<%#Eval("需要注意") %>' />
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
                                <asp:TemplateField HeaderText="送貨地址" HeaderStyle-Width="100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerDeliverAddress" runat="server" Text='<%#Eval("送貨地址") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="附UL">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckxAttachUl" runat="server" Checked='<%# Convert.ToInt32(Eval("附UL")) == 1 ? true:false %>'
                                            onclick='return false' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="不附單據">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckxNoReceipt" runat="server" Checked='<%# Convert.ToInt32(Eval("不附單據")) == 1 ? true:false %>'
                                            onclick='return false' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="不可有接頭">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckxNoSegments" runat="server" Checked='<%# Convert.ToInt32(Eval("不可有接頭")) == 1 ? true:false %>'
                                            onclick='return false' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="注意事項" HeaderStyle-Width="200">
                                    <%--<ItemStyle CssClass="m-0 p-1 pb-0" />--%>
                                    <ItemTemplate>
                                        <pre style="white-space: pre-wrap;"><asp:Label ID="lblMemo" runat="server" Text='<%#Eval("注意事項").ToString() %>'></asp:Label></pre>
                                        <%--<asp:Label ID="lblMemo" runat="server" Text='<%#Eval("注意事項").ToString().Replace("\n","<br />") %>'></asp:Label>--%>
                                        <%--<asp:TextBox ID="lblMemo" runat="server" CssClass="text-as-label" Text='<%#Eval("注意事項") %>' TextMode="MultiLine" ReadOnly="true"></asp:TextBox>--%>
                                        <%--<asp:Label ID="lblMemo" runat="server" Text='<%#Eval("注意事項") %>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最後更新時間">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastEditTime" runat="server" Text='<%#Eval("最後編輯時間") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSalesRecordDataSearch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSaveDetail" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSalesRecordRefresh" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

