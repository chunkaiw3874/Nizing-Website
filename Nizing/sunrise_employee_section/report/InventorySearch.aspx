<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/report/sunrise-master.master" CodeFile="InventorySearch.aspx.cs" Inherits="InventorySearch" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style>
        /*#inventory #search-result .grdResult tr td:nth-child(n+3):nth-child(-n+5) {
            text-align: left;
        }*/
        div {
            display: block;
        }

        table th, td {
            text-align: center;
            /*font-size:12px;*/
        }

            table th:hover {
                cursor: context-menu;
            }

        table tr td:nth-child(n+4):nth-child(-n+6) {
            text-align: left;
        }

        table td img:hover {
            cursor: pointer;
        }

        .scrollable {
            max-height: 500px;
            overflow: auto;
        }

        /*.modal{
            width:500px;
        }*/

        .imagepreview {
            width: 100%;
        }
    </style>
    <script>
        function uploadStart(sender, args) {
            var fileName = args.get_fileName();
            var dotIndex = fileName.lastIndexOf('.');
            var fileNameNoExt = fileName.substr(0, dotIndex);
            var fileNameExt = fileName.substr(dotIndex + 1);

        }
        function uploadComplete(sender, args) {
            alert("upload complete: " + args.get_fileName() + '-' + (new Date()).toISOString().replace(/[^0-9]/g, "").slice(0, -3));
        }
        //function showImage() {
        //    alert('image clicked');
        //    $('.imagepreview').attr('src', $(this).find('img').attr('src'));
        //    $('#imagemodal').modal('show');
        //};
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
        <asp:UpdatePanel ID="upParameterField" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClear" />
            </Triggers>
            <ContentTemplate>
                <div>
                    <h2>庫存查詢系統</h2>
                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                    <div>
                        <div class="input-group mb-1">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <asp:CheckBox ID="chkId" runat="server" Checked="true" />
                                </div>
                                <span class="input-group-text">品號查詢</span>
                            </div>
                            <%--<asp:TextBox ID="txtId_Start" runat="server" CssClass="form-control" placeholder="開頭為..." ToolTip="品號開頭為..."></asp:TextBox>--%>
                            <asp:TextBox ID="txtId_Middle" runat="server" CssClass="form-control" placeholder="包含有..." ToolTip="品號包含有..."></asp:TextBox>
                            <%--<asp:TextBox ID="txtId_End" runat="server" CssClass="form-control" placeholder="結尾為..." ToolTip="品號結尾為..."></asp:TextBox>--%>
                        </div>
                        <div class="input-group mb-1">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <asp:CheckBox ID="chkName" runat="server" />
                                </div>
                                <span class="input-group-text">品名查詢</span>
                            </div>
                            <%--<asp:TextBox ID="txtName_Start" runat="server" CssClass="form-control" placeholder="開頭為..." ToolTip="品名開頭為..."></asp:TextBox>--%>
                            <asp:TextBox ID="txtName_Middle" runat="server" CssClass="form-control" placeholder="包含有..." ToolTip="品名包含有..."></asp:TextBox>
                            <%--<asp:TextBox ID="txtName_End" runat="server" CssClass="form-control" placeholder="結尾為..." ToolTip="品名結尾為..."></asp:TextBox>--%>
                        </div>
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text">
                                    <asp:CheckBox ID="chkCategory" runat="server" />
                                </div>
                                <span class="input-group-text">分類查詢</span>
                            </div>
                            <asp:DropDownList ID="ddlCategory_Acct" runat="server" CssClass="custom-select"></asp:DropDownList>
                        </div>
                        <div>
                            <asp:CheckBox ID="chkInvShowZero" runat="server" Text="顯示實際在庫量為0的項目" Checked="false" />
                        </div>
                        <div>
                            <asp:CheckBox ID="chkSafetyShowZero" runat="server" Text="顯示預估安全存量為0的項目" Checked="true" />
                        </div>
                        <div class="input-group full-width">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success form-control" Text="查詢" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger form-control" Text="清除查詢條件" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr />
        <asp:UpdateProgress ID="upGvItemList" runat="server">
            <ProgressTemplate>
                <div class="d-flex justify-content-center">
                <div class="spinner-border text-primary" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
                    </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                <asp:AsyncPostBackTrigger ControlID="gvItemList" EventName="PageIndexChanging" />
            </Triggers>
            <ContentTemplate>
                <div class="scrollable mb-5">
                    <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-white"
                        EmptyDataText="查無資料"
                        AllowPaging="true" PageSize="10"
                        OnPageIndexChanging="gvItemList_PageIndexChanging"
                        OnPreRender="gvItemList_PreRender">
                        <Columns>
                            <asp:TemplateField HeaderText="品項封面" HeaderStyle-Width="150">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgItemCover" runat="server" Width="150"
                                        OnClick="imgItemCover_Click"/>
                                    <%--<asp:Image ID="imgItemCover" runat="server" CssClass="pop" Width="150" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="在庫量" HeaderStyle-Width="60">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountInInv" runat="server" Text='<%#Eval("AMOUNT_IN_INV") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="儲位" HeaderStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvLocation" runat="server" Text='<%#Eval("INV_LOCATION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品號" HeaderStyle-Width="160">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ITEM_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名" HeaderStyle-Width="200">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ITEM_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="規格" HeaderStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemSpec" runat="server" Text='<%#Eval("ITEM_SPEC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位成本未稅">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvAvgCost" runat="server" Text='<%#Eval("INV_AVG_COST") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="幣別" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrency" runat="server" Text="NTD"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="label" runat="server" Text='<%#Eval("UNIT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="庫別" HeaderStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvId" runat="server" Text='<%#Eval("INV_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="庫別名稱" HeaderStyle-Width="70">
                                <ItemTemplate>
                                    <asp:Label ID="lblInvName" runat="server" Text='<%#Eval("INV_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="安全庫存量">
                                <ItemTemplate>
                                    <asp:Label ID="lblSafeInv" runat="server" Text='<%#Eval("AMOUNT_SAFETY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:UpdatePanel ID="upCoverImageView" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvItemList" />
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="imagemodal" role="dialog" aria-labelledby="CoverImageView" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="lblCoverImageTitle" runat="server" CssClass="modal-title"></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <asp:Image ID="imgCoverImage" runat="server" CssClass="imagepreview img-fluid" />
                            <%--<img class="imagepreview" style="width: 100%;">--%>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
