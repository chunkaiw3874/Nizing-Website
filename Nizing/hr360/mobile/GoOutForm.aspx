<%@ Page Title="" Language="C#" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="GoOutForm.aspx.cs" Inherits="hr360_mobile_GoOutForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../Scripts/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/js/tempusdominus-bootstrap-4.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/css/tempusdominus-bootstrap-4.min.css" />
    <style>
        #datetimepicker .form-control[readonly] {
            background-color: white;
        }

        textarea {
            resize: none;
        }

        .input-group > .input-group-prepend {
            flex: 0 0 20%;
        }

        .input-group .input-group-text {
            width: 100%;
        }

        .checkboxlist label {
            padding-right: 10px;
        }

        .table th {
            border-bottom: 2px solid #dee2e6;
        }

        .table td, .table th {
            border-bottom: 1px solid #dee2e6;
        }

        .btn-list {
            font-size: 1.5rem;
        }

        .whitespace-nowrap{
            /*white-space:nowrap;*/
            word-break:keep-all;
        }
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $('#datetimepicker').datetimepicker({
                ignoreReadonly: true,
                locale: 'zh-tw',
                buttons: {
                    showToday: true
                },
                format: "YYYY/MM/DD HH:mm",
                stepping: 15,
                toolbarPlacement: 'top',
                //minDate: new moment().minutes(0)
            });

            $(".datetimepicker-input").keydown(function (e) {
                return false;
            });

            autosize($('.autosize'));
        }
        function confirmChoice(s) {
            if (confirm(s)) {
                return true;
            }
            else {
                return false;
            }
        };

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Label ID="lblTestMessage" runat="server" Text="Test Message"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>--%>

        <asp:UpdatePanel ID="upInProgress" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvReservationList" />
                <asp:AsyncPostBackTrigger ControlID="gvInProgressList" />
                <asp:AsyncPostBackTrigger ControlID="btnSaveReservationForm" />
                <asp:AsyncPostBackTrigger ControlID="tmrTripDuration" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer ID="tmrTripDuration" runat="server" Interval="1000" OnTick="tmrTripDuration_Tick"></asp:Timer>
                <div id="divInProgress" runat="server">
                    <div>
                        <h5>執行中</h5>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvInProgressList" runat="server" CssClass="table table-sm table-light"
                            AutoGenerateColumns="false"
                            EmptyDataText="無執行中行程">
                            <Columns>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditReservation" runat="server" CssClass="btn-list text-decoration-none"
                                            ToolTip="編輯行程"
                                            OnClick="btnEditReservation_Click">
                                        <i class="far fa-edit"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="單號" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScheduleFormId" runat="server" Text='<%#Eval("FormId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="預定出發時間" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScheduledStartTime" runat="server" Text='<%#Eval("EstimateStartTime","{0:MM/dd HH:mm}") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnScheduledStartTime" runat="server" Value='<%#Eval("EstimateStartTime","{0:yyyy/MM/dd HH:mm}") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="出發時間">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTripStartTime" runat="server" Text='<%#Eval("ActualStartTime","{0:MM/dd HH:mm:ss}") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnTripStartTime" runat="server" Value='<%#Eval("ActualStartTime","{0:yyyy/MM/dd HH:mm:ss}") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="經過時間">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTripDuration" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="預定使用時間(HR)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScheduleTimeUsed" runat="server" Text='<%#Eval("EstimateTimeUsed") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="目的地">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScheduledDestination" runat="server" Text='<%#Eval("Destination") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公司別" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScheduleForWhichCompany" runat="server" Text='<%#Eval("ForWhichCompany") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="備註" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtScheduleMemo" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true"
                                            Text='<%#Eval("Memo") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="狀態" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScheduleStatusName" runat="server" Text='<%#Eval("StatusName") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnScheduleStatusCode" runat="server" Value='<%#Eval("Status") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEndTrip" runat="server" CssClass="btn-list text-decoration-none"
                                            ToolTip="結束行程"
                                            OnClientClick="javascript: return confirmChoice('結束行程?');"
                                            OnClick="btnEndTrip_Click">
                                        <i class="fas fa-stop-circle"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <hr />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <h5>
            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>的預約單
        </h5>

        <asp:UpdatePanel ID="upReservationList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSaveReservationForm" />
                <asp:AsyncPostBackTrigger ControlID="gvReservationList" />
                <asp:AsyncPostBackTrigger ControlID="gvInProgressList" />
                <asp:AsyncPostBackTrigger ControlID="btnDisplayFormDetail" />
                <asp:AsyncPostBackTrigger ControlID="btnHideFormDetail" />
            </Triggers>
            <ContentTemplate>

                <div class="d-flex justify-content-between">
                    <div>
                        <asp:LinkButton ID="btnAddReservation" runat="server" CssClass="text-decoration-none"
                            OnClick="btnAddReservation_Click">
                        <i class="far fa-calendar-plus"></i> 新增
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnViewAllActiveReservation" runat="server" CssClass="text-decoration-none"
                            OnClick="btnViewAllActiveReservation_Click">
                            <i class="fas fa-search"></i> 查看
                        </asp:LinkButton>
                    </div>
                    <div>
                        <asp:LinkButton ID="btnDisplayFormDetail" runat="server" CssClass="text-decoration-none"
                            OnClick="btnDisplayFormDetail_Click">
                <i class="fas fa-plus"></i> 顯示詳細資訊
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnHideFormDetail" runat="server" CssClass="text-decoration-none"
                            OnClick="btnHideFormDetail_Click" Visible="false">
                <i class="fas fa-minus"></i> 隱藏詳細資訊
                        </asp:LinkButton>
                    </div>
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="gvReservationList" runat="server" BorderWidth="0" CssClass="table table-sm table-light"
                        AutoGenerateColumns="false"
                        EmptyDataText="您沒有未完成的行程"
                        OnRowDataBound="gvReservationList_RowDataBound"
                        OnPreRender="gvReservationList_PreRender">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnCancelReservation" runat="server" CssClass="btn-list text-decoration-none"
                                        ToolTip="取消行程"
                                        OnClientClick="javascript: return confirmChoice('確定取消預約單?');"
                                        OnClick="btnCancelReservation_Click">
                                        <i class="far fa-calendar-minus"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditReservation" runat="server" CssClass="btn-list text-decoration-none"
                                        ToolTip="編輯行程"
                                        OnClick="btnEditReservation_Click">
                                        <i class="far fa-edit"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單號" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblScheduleFormId" runat="server" Text='<%#Eval("FormId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="預定出發時間">
                                <ItemTemplate>
                                    <asp:Label ID="lblScheduledStartTime" runat="server" Text='<%#Eval("EstimateStartTime","{0:MM/dd HH:mm}") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnScheduledStartTime" runat="server" Value='<%#Eval("EstimateStartTime","{0:yyyy/MM/dd HH:mm}") %>'></asp:HiddenField>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="使用時間" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblScheduleTimeUsed" runat="server" Text='<%#Eval("EstimateTimeUsed") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="實際出發時間" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTripStartTime" runat="server" Text='<%#Eval("ActualStartTime","{0:MM/dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="目的地">
                                <ItemTemplate>
                                    <asp:Label ID="lblScheduledDestination" runat="server" Text='<%#Eval("Destination") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公司別" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblScheduleForWhichCompany" runat="server" Text='<%#Eval("ForWhichCompany") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtScheduleMemo" runat="server" TextMode="MultiLine" ReadOnly="true"
                                        CssClass="form-control bg-transparent border-0 p-0 autosize w-auto"
                                        Text='<%#Eval("Memo") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="狀態" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblScheduleStatusName" runat="server" Text='<%#Eval("StatusName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnScheduleStatusCode" runat="server" Value='<%#Eval("Status") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnStartTrip" runat="server" CssClass="btn-list text-decoration-none"
                                        ToolTip="出發"
                                        OnClientClick="javascript: return confirmChoice('確定出發?');"
                                        OnClick="btnStartTrip_Click">
                                        <i class="fas fa-play-circle"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:UpdatePanel ID="upReservationForm" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddReservation" />
            <asp:AsyncPostBackTrigger ControlID="btnSaveReservationForm" />
            <asp:AsyncPostBackTrigger ControlID="gvReservationList" />
            <asp:AsyncPostBackTrigger ControlID="gvInProgressList" />
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="ReservationForm" data-backdrop="static" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="lblReservationFormTitle" runat="server" Text=""></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">預約單號</span>
                                </div>
                                <asp:Label ID="lblReservationId" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>
                            <%--                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">使用者</span>
                                </div>
                                <asp:Label ID="lblReservationUser" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>--%>
                            <div class="input-group mb-1 date" id="datetimepicker" data-target-input="nearest">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">出發時間</span>
                                </div>
                                <asp:TextBox ID="txtEstimatedStartTime" runat="server"
                                    CssClass="form-control datetimepicker-input"
                                    data-target="#datetimepicker"></asp:TextBox>
                                <div class="input-group-append" data-target="#datetimepicker" data-toggle="datetimepicker">
                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                </div>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">使用時間</span>
                                </div>
                                <asp:DropDownList ID="ddlReservationDuration" runat="server" CssClass="custom-select"></asp:DropDownList>
                                <div class="input-group-append">
                                    <span class="input-group-text">小時</span>
                                </div>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">目的地</span>
                                </div>
                                <asp:TextBox ID="txtReservationDestination" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                                <span class="col-12 text-danger">複數目的地請以逗號(,)做分隔</span>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    分攤公司:
                                </div>
                            </div>
                            <asp:CheckBoxList ID="cblGoOutFor" runat="server" CssClass="checkboxlist" RepeatDirection="Horizontal">
                                <asp:ListItem Text="日進" Value="NIZING">
                                </asp:ListItem>
                                <asp:ListItem Text="日出" Value="SUNRIZE">
                                </asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="row">
                                <div class="col-12">
                                    外出事由:
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <asp:TextBox ID="txtReservationMemo" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSaveReservationForm" runat="server" CssClass="btn btn-success w-100" Text="送出"
                                UseSubmitBehavior="false"
                                data-dismiss="modal"
                                OnClick="btnSaveReservationForm_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

