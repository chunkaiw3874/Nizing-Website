<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="RewardAndPunishmentSlip.aspx.cs" Inherits="hr360_mobile_RewardAndPunishmentSlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="/Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="/Scripts/bootstrap-datepicker.js"></script>
    <script src="/Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>

    <style type="text/css">
        .container {
            margin-bottom: 100px;
        }

        .input-group {
            margin-bottom: 0.5rem;
        }

        textarea.form-control {
            min-height: 100px;
        }

        textarea {
            resize: none;
        }

        .result-table {
            height: 300px;
            border: solid 1px #cccccc;
            overflow-y: scroll;
        }

        .file-upload {
            cursor: pointer;
            margin: 0;
        }

        .attachment-list.form-control {
            height: 100%;
            min-height: calc(1.5em + .75rem + 2px);
        }

        .attachment-list > .item {
            padding-top: 0.5rem;
            padding-bottom: 0.5rem;
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
        });

        function confirmDelete() {
            if (confirm('確定要刪除' + $('#<%=lblRewardAndPunishmentSlipID.ClientID%>').html() + '嗎?')) {
                return true;
            }
            else {
                return false;
            }
        }

        function RefreshUpdatePanel() {
            __doPostBack('<%= txtFormSearch.ClientID %>', '');
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text">查詢單據</span>
            </div>
            <asp:TextBox ID="txtFormSearch" CssClass="form-control" runat="server"
                placeholder="不可有空白"
                onkeyup="RefreshUpdatePanel();"
                OnTextChanged="txtFormSearch_TextChanged">
            </asp:TextBox>
        </div>
        <asp:UpdatePanel ID="upSearchResult" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtFormSearch" />
            </Triggers>
            <ContentTemplate>
                <div class="table-responsive result-table">
                    <asp:GridView ID="gvResult" runat="server"
                        CssClass="table table-striped-blue"
                        AutoGenerateColumns="false"
                        OnSelectedIndexChanged="gvResult_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField Text="看單據" CommandName="Select" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    ID
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("RecordID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    員工名稱
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("EmpName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    歸屬年份
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    事件分類
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent" runat="server" Text='<%#Eval("EventName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    獎懲項目
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRnP" runat="server" Text='<%#Eval("RnPName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    次
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCount" runat="server" Text='<%#Eval("count") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upForm" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvResult" />
                <asp:AsyncPostBackTrigger ControlID="btnUploadData" />
                <asp:AsyncPostBackTrigger ControlID="btnClearData" />
                <asp:AsyncPostBackTrigger ControlID="btnDeleteData" />
            </Triggers>
            <ContentTemplate>
                <div class="d-flex input-group justify-content-between mt-2">
                    <div class="title">
                        <h2>獎懲單建立作業</h2>
                    </div>
                    <div>
                        <asp:LinkButton ID="btnUploadData" runat="server" CssClass="btn text-white bg-primary" ToolTip="上傳"
                            OnClick="btnUploadData_Click">
                                <i class="fas fa-file-upload"></i>
                        </asp:LinkButton>
                        <asp:Button ID="btnClearData" runat="server" CssClass="btn btn-info" ToolTip="清除資料" Text="清除資料"
                            OnClick="btnClearData_Click" />
                        <asp:LinkButton ID="btnDeleteData" runat="server" CssClass="btn text-white bg-danger" ToolTip="刪除資料"
                            OnClientClick="javascript:return confirmDelete();"
                            OnClick="btnDeleteData_Click">
                                <i class="fas fa-trash-alt"></i>
                        </asp:LinkButton>
                    </div>
                </div>
                <div id="divSystemMessages" runat="server" class="my-2">
                </div>
                <div class="d-flex align-items-center">
                    <asp:CheckBox ID="ckbVerified" runat="server" Text="CC確認執行" CssClass="align-items-center" />
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">單據建立日期</span>
                    </div>
                    <asp:TextBox ID="txtDateCreated" runat="server" CssClass="form-control datepicker"
                        AutoPostBack="true"
                        OnTextChanged="txtDateCreated_TextChanged"></asp:TextBox>
                </div>
                <asp:UpdatePanel ID="upSlipID" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtDateCreated" />
                    </Triggers>
                    <ContentTemplate>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">獎懲單號</span>
                            </div>
                            <asp:Label ID="lblRewardAndPunishmentSlipID" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">歸屬年份</span>
                    </div>
                    <asp:DropDownList ID="ddlEventYear" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">員工ID</span>
                    </div>
                    <asp:DropDownList ID="ddlEmpID" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">事件分類</span>
                    </div>
                    <asp:DropDownList ID="ddlEvent" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">內容</span>
                    </div>
                    <asp:TextBox ID="txtEventContent" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">獎懲</span>
                    </div>
                    <asp:DropDownList ID="ddlRewardAndPunishmentCategory" runat="server" CssClass="custom-select"></asp:DropDownList>
                    <span class="input-group-text rounded-0">x</span>
                    <asp:TextBox ID="txtRewardAndPunishmentCount" runat="server" CssClass="form-control">1.00</asp:TextBox>
                    <div class="input-group-append">
                        <span class="input-group-text">次</span>
                    </div>
                </div>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">備註</span>
                    </div>
                    <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:UpdatePanel ID="upUploadFile" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <Triggers>
                    </Triggers>
                    <ContentTemplate>
                        <div class="input-group">
                            <label for="<%=fuAttachment.ClientID %>" class="file-upload btn btn-success">
                                上傳附件
                                    <asp:FileUpload ID="fuAttachment" runat="server" AllowMultiple="true" CssClass="d-none"
                                        onchange="this.form.submit()" />
                            </label>
                        </div>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">附件</span>
                            </div>
                            <div id="divAttachmentList" runat="server" class="form-control attachment-list">
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

