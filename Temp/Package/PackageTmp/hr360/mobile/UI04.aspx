﻿<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/hr360/mobile/master/greenMaster.master" AutoEventWireup="true" CodeFile="UI04.aspx.cs" Inherits="hr360_UI04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <link href="../../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap-datepicker.js"></script>
    <script src="../../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>--%>
    <script src="../../Scripts/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/js/tempusdominus-bootstrap-4.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tempusdominus-bootstrap-4/5.0.0-alpha14/css/tempusdominus-bootstrap-4.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/additional-methods.min.js"></script>

    <style>
        textarea {
            resize: none;
        }

            textarea.form-control[readonly] {
                background-color: #ffffff;
            }

        #loading-screen {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            text-align: center;
        }

        .col {
            margin-bottom: 1rem;
        }

        .application-form-list-item {
            border: solid 1px #cccccc;
            border-radius: 5px;
            padding: 0.5rem 1rem;
        }

            .application-form-list-item .input-group {
                margin-bottom: 5px;
            }

        .highlight {
            background-color: lightblue;
        }

        .nohighlight {
            background-color: none;
        }

        .noselect {
            user-select: none; /* CSS3 (little to no support) */
            -ms-user-select: none; /* IE 10+ */
            -moz-user-select: none; /* Gecko (Firefox) */
            -webkit-user-select: none; /* Webkit (Safari, Chrome) */
        }

        .pointer-cursor {
            cursor: pointer;
        }

        .card-header a {
            color: white;
        }

            .card-header a:hover {
                color: #e8e8e8;
            }

        .search-conditions > div {
            margin-bottom: 8px;
        }

        table th a,
        table th a:hover {
            color: #ffffff;
            text-decoration: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(this).on("click", "[alt*='expand']", function () {
                console.log($(this).attr('id'));
                $(this).closest("tr").after("<tr><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
                $(this).attr("alt", "collapse");
            });
            $(this).on("click", "[alt*='collapse']", function () {
                $(this).attr("alt", "expand");
                $(this).closest("tr").next().remove();
            });

            $('.classApprovalPending tr').click(function () {
                approvalTableSelection($(this).index());
            });

            $('[data-toggle="popover"]').popover({
                sanitize: false,
            });
        });

        function pageLoad(sender, args) {
            //RWD Version Code
            $('#datetimepicker').datetimepicker({
                ignoreReadonly: true,
                locale: 'zh-tw',
                buttons: {
                    showToday: true
                },
                format: "YYYY/MM/DD HH:mm",
                stepping: 30,
                toolbarPlacement: 'top',
                //minDate: new moment().minutes(0)
            });

            $('#timepickerend').datetimepicker({
                ignoreReadonly: true,
                locale: 'zh-tw',
                format: "HH:mm",
                stepping: 30,
                toolbarPlacement: 'top'
            });

            $('.datetimepicker-input').keydown(function (e) {
                return false;
            });

            autosize($('.autosize'));

            $('#searchDateStart, #searchDateEnd').datetimepicker({
                ignoreReadonly: true,
                locale: 'zh-tw',
                buttons: {
                    showToday: true
                },
                format: "yyyyMMDD",
                toolbarPlacement: 'top'
            });
        }

        function uploadFileFromApplication() {
            var attachmentControlId = 'fileAttachment';
            var formId = $('#<%=lblApplicationIdForAttachment.ClientID%>').text().split(' ')[1];
            uploadFile(attachmentControlId, formId);
        }

        function uploadFile(attachmentControlId, formId) {
            var fileUpload = $("#" + attachmentControlId).get(0);
            var files = fileUpload.files;
            var userId = formId.split('-')[0];
            var folderId = formId.split('-')[1] + '-' + formId.split('-')[2];
            var filepath = "";
            if (formId) {
                filepath = "/hr360/attachment/dayoff-application-attachment/" + userId + "/" + folderId + "/";
            }

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
                ;
            };

            //額外的參數 
            data.append("filePath", filepath);

            var options = {};
            options.url = "/hr360/FileUploadHandler.ashx";
            options.type = "POST";
            options.data = data;
            options.contentType = false;
            options.processData = false;
            options.success = function (result) { alert(result); };
            options.error = function (err) { alert(err.statusText); };

            $.ajax(options);

        };

        var approvalPendingAnchor = 0;
        function approvalTableSelection(e) {
            if (e != 0) {
                if (window.event.shiftKey) {
                    if (approvalPendingAnchor == 0) {
                        selectBetweenItemsIntbApprovalPending(e, e);
                        approvalPendingAnchor = e;
                    }
                    else {
                        if (approvalPendingAnchor <= e) {
                            selectBetweenItemsIntbApprovalPending(approvalPendingAnchor, e);
                        }
                        else {
                            selectBetweenItemsIntbApprovalPending(e, approvalPendingAnchor);
                        }
                        approvalPendingAnchor = e;
                    }
                }
                else if (window.event.ctrlKey) {
                    $('.classApprovalPending tr').eq(e).toggleClass('highlight');
                    approvalPendingAnchor = e;
                }
                else {
                    var isSelected = false;
                    var isClickedSelected = false;
                    var numberSelected = 0;
                    for (var i = 1; i <= $('.classApprovalPending tr').length; i++) {
                        if ($('.classApprovalPending tr').eq(i).hasClass('highlight')) {
                            isSelected = true;
                            if (i == e) {
                                isClickedSelected = true;
                            }
                            numberSelected++;
                        }
                    }
                    if (isSelected) {
                        if (!isClickedSelected || numberSelected != 1) {
                            clearSelectionOntbApprovalPending();
                        }
                    }

                    $('.classApprovalPending tr').eq(e).toggleClass('highlight');
                    approvalPendingAnchor = e;
                }
            }
            else {
            }
        };

        function selectBetweenItemsIntbApprovalPending(a, b) {
            for (var i = a; i <= b; i++) {
                $('.classApprovalPending tr').eq(i).addClass('highlight');
            }
        };

        function clearSelectionOntbApprovalPending() {
            for (var i = 1; i <= $('.classApprovalPending tr').length; i++) {
                $('.classApprovalPending tr').eq(i).removeClass('highlight');
            }
        };

        function storeApprovalPendingSelectionToHiddenField() {
            var selectionList = [];
            var applicationID = "";
            for (var i = 1; i <= $('.classApprovalPending tr').length; i++) {
                if ($('.classApprovalPending tr').eq(i).hasClass('highlight')) {
                    applicationID = $('.classApprovalPending tr').eq(i).find('td').eq(0).text();
                    selectionList.push(applicationID);
                }
            }
            $('#hdnApprovalPendingSelection').val(selectionList);
        };

        function confirmWithdrawal() {
            if (confirm('確定要撤銷此張假單嗎?')) {
                return true;
            }
            else {
                return false;
            }
        };

        function confirmApprove() {
            storeApprovalPendingSelectionToHiddenField();
            if ($('#hdnApprovalPendingSelection').val().trim() != "") {
                if (confirm('確定要簽核選取的假單嗎?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                alert("尚未選取要簽核的假單，請先點選要簽核的假單 (被選取的假單，背景顏色會變成藍色)");
                return false;
            }
        };

        function confirmDeny() {
            var reason = prompt("請輸入退回原因(必填、50字內):");
            var trimmedReason = '';
            if (reason != null) {
                trimmedReason = reason.trim();
            }
            if (trimmedReason != '' && reason !== null) {
                document.getElementById('<%= hdnDenyReason.ClientID %>').value = trimmedReason;
                return true;
            }
            else {
                if (reason !== null) {
                    alert('請填入退件原因');
                }
                return false;
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="container" style="visibility: hidden">
        維護中，請稍後
    </div>
    <div class="container" style="visibility: visible">
        <div id="application_section">
            <div class="row" style="color: red">
            </div>
            <div id="DayOffApp">
                <!--RWD version application form-->
                <asp:HiddenField ID="hdnIsPostBack" runat="server" />
                <asp:HiddenField ID="hdnOfficeOrProduction" runat="server" />
                <asp:HiddenField ID="hdnImmediateReviewerID" runat="server" />
                <asp:HiddenField ID="hdnDayOffTimeRemainBeforeSubmit" runat="server" />
                <asp:HiddenField ID="hdnDenyReason" runat="server" />

                <asp:UpdatePanel ID="upApplicationList" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDayOffAdd" />
                        <asp:AsyncPostBackTrigger ControlID="btnAppSubmit" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="divSystemMessage" runat="server">
                            <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="card">
                            <div class="card-header bg-success d-flex justify-content-between text-white">
                                本次請假內容                      
                        <asp:LinkButton ID="btnAddApplicationForm" runat="server" CssClass="text-decoration-none"
                            OnClick="btnAddApplicationForm_Click">
                            <i class="fas fa-plus-circle"></i> 新增請假單
                        </asp:LinkButton>
                            </div>
                            <div class="card-body">
                                <div class="card-text" style="color: red">
                                    *假單不得跨天，請假半小時無須代理人<br />
                                    *休假最小單位為:辦公室0.5小時;製造部門0.5天<br />
                                    *請假前須確認當天工作進度已安排人員支援，且有代理人簽名<br />
                                    *請事假、病假過多者，會影響到年終獎金之發放<br />
                                    *未經主管核簽及人事核准，假單不生效，不出勤將視為曠職<br />
                                    *請病假1天以內，需附上合法醫療院所之收據；2日(含)以上者，需附上醫生診斷證明<br />
                                    *連續請假3日(含)者，須有正當理由<br />
                                    *連續請假超過5日(含)者，須至少提前兩周告知，以利人力安排<br />
                                    *補單者須四日內完成補單動作(例:1/7臨時請假，最晚須於1/10補單)
                                </div>
                                <hr />
                                <div id="divApplicationFormList" runat="server"
                                    class="row row-cols-1 row-cols-md-2 row-cols-lg-3">
                                </div>
                            </div>
                            <div class="card-footer d-flex justify-content-end">
                                <asp:Button ID="btnAppSubmit" runat="server" Text="送出" CssClass="btn btn-primary" OnClick="btnAppSubmit_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <hr />
        <div id="in-progress_section">
            <div class="row form-group">
                <div class="col-sm-12">
                    <h2>申請中</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-info">
                        <div class="panel-body">
                            <table id="tbInProgressSummary" class="table col-sm-12" runat="server">
                            </table>
                            <div id="divInProgressApplicationList"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div id="approval_section">
            <div class="row form-group">
                <div class="col-sm-12">
                    <h2>待簽核</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-info">
                        <div class="panel-body">
                            <div style="color: red;">
                                *請先點選要簽核的假單，再點選最上層的"簽核"按鈕;如欲一次簽核多張假單，可按住Shift一次選擇，或按住Ctrl增選<br />
                                **退回不可複選<br />
                                ***如操作上有疑問，請詢問人事部
                            </div>
                            <asp:HiddenField ID="hdnApprovalPendingSelection" ClientIDMode="Static" runat="server" />
                            <table id="tbApprovalPending" class="classApprovalPending table col-sm-12 noselect" runat="server">
                                <tr style="background-color: lightblue; color: white;">
                                    <th style="text-align: center; font-weight: bold;">假單ID</th>
                                    <th style="text-align: center; font-weight: bold;">申請人ID</th>
                                    <th style="text-align: center; font-weight: bold;">申請人</th>
                                    <th style="text-align: center; font-weight: bold;">假別</th>
                                    <th style="text-align: center; font-weight: bold;">開始時間</th>
                                    <th style="text-align: center; font-weight: bold;">結束時間</th>
                                    <th style="text-align: center; font-weight: bold;">請假總量</th>
                                    <th style="text-align: center; font-weight: bold;">代理人</th>
                                    <th style="text-align: center; font-weight: bold;">請假原因</th>
                                    <th style="text-align: center; font-weight: bold;">簽核階段</th>
                                    <th style="text-align: center; font-weight: bold;">ERP狀態</th>
                                    <th style="text-align: center; font-weight: bold;">
                                        <asp:Button ID="btnApprove" runat="server" Text="簽核" CssClass="btn btn-success" OnClientClick="javascript:return confirmApprove();" OnClick="btnApprove_Click" />
                                    </th>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <asp:UpdatePanel ID="upQueryField" runat="server" ChildrenAsTriggers="true">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <span class="label label-info" id="btnSearchVisibility" style="cursor: pointer; font-size: 20px;">查詢歷史假單</span>
                        <%--<asp:HiddenField ID="hdnIsSearchFieldVisible" runat="server" />--%>
                    </div>
                </div>
                <div id="search_section">
                    <div class="row row-cols-1 row-cols-md-5 justify-content-between search-conditions">
                        <div class="col">
                            <div class="input-group">
                                <asp:DropDownList ID="ddlSearch_Parameter_ApplicantID" runat="server" CssClass="custom-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col">
                            <div class="input-group" id="searchDateStart" data-target-input="nearest">
                                <asp:TextBox ID="txtSearch_Parameter_StartDate" runat="server"
                                    CssClass="form-control datetimepicker-input"
                                    data-target="#searchDateStart"
                                    placeholder="查詢起始日期"></asp:TextBox>
                                <div class="input-group-append" data-target="#searchDateStart" data-toggle="datetimepicker">
                                    <div class="input-group-text">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="input-group" id="searchDateEnd" data-target-input="nearest">
                                <asp:TextBox ID="txtSearch_Parameter_EndDate" runat="server"
                                    CssClass="form-control datetimepicker-input"
                                    data-target="#searchDateEnd"
                                    placeholder="查詢結束日期"></asp:TextBox>
                                <div class="input-group-append" data-target="#searchDateEnd" data-toggle="datetimepicker">
                                    <div class="input-group-text">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="input-group">
                                <asp:DropDownList ID="ddlSearch_Parameter_ApplicationStatus" runat="server" CssClass="custom-select"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col">
                            <asp:Button ID="btnSearchSubmit" runat="server" Text="查詢" CssClass="btn btn-success w-100" OnClick="btnSearchSubmit_Click" />
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvSearchResult" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-striped table-striped-blue"
                            AllowPaging="True"
                            PageSize="10"
                            PagerSettings-Position="Top"
                            PagerSettings-Mode="NumericFirstLast"
                            PagerSettings-FirstPageText="首頁"
                            PagerSettings-LastPageText="尾頁"
                            OnRowDataBound="gvSearchResult_RowDataBound"
                            OnPageIndexChanging="gvSearchResult_PageIndexChanging"
                            OnRowCommand="gvSearchResult_RowCommand">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbApplication_ID" runat="server" Text="假單單號"
                                            CommandName="Sort" CommandArgument="APPLICATION_ID"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppId" runat="server" Text='<%#Eval("APPLICATION_ID") %>' alt="expand" CssClass="pointer-cursor"></asp:Label>
                                        <asp:Panel ID="pnlAppTrail" runat="server" Style="display: none;">
                                            <asp:GridView ID="gvAppTrail" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-striped-blue" GridLines="Horizontal">
                                                <Columns>
                                                    <%--                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblAppTrailId" runat="server" Text="假單單號"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAppTrailIdContent" runat="server" Text='<%#Eval("APPLICATION_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblAppTrailTime" runat="server" Text="動作時間"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAppTrailTimeContent" runat="server" Text='<%#Eval("ACTION_TIME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text="申請狀態"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatusContent" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblExecutorId" runat="server" Text="動作執行者"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExecutorIdContent" runat="server" Text='<%#Eval("EXECUTOR_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblActionName" runat="server" Text="動作"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblActionNameContent" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblMemo" runat="server" Text="備註"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMemoContent" runat="server" Text='<%#Eval("MEMO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbApplicant_ID" runat="server" Text="員工代號" CommandName="Sort" CommandArgument="APPLICANT_ID"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("APPLICANT_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbAPPLICANT_NAME" runat="server" Text="申請者" CommandName="Sort" CommandArgument="APPLICANT_NAME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("APPLICANT_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbDAYOFF_NAME" runat="server" Text="假別" CommandName="Sort" CommandArgument="DAYOFF_NAME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("DAYOFF_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbDAYOFF_START_TIME" runat="server" Text="請假開始時間" CommandName="Sort" CommandArgument="DAYOFF_START_TIME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDayoffStartTime" runat="server" Text='<%#Eval("DAYOFF_START_TIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbDAYOFF_END_TIME" runat="server" Text="請假結束時間" CommandName="Sort" CommandArgument="DAYOFF_END_TIME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDayoffEndTime" runat="server" Text='<%#Eval("DAYOFF_END_TIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbDAYOFF_TOTAL_TIME" runat="server" Text="請假總量" CommandName="Sort" CommandArgument="DAYOFF_TOTAL_TIME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("DAYOFF_TOTAL_TIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbFUNC_SUB_NAME" runat="server" Text="代理人" CommandName="Sort" CommandArgument="FUNC_SUB_NAME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("FUNC_SUB_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbREASON" runat="server" Text="請假原因" CommandName="Sort" CommandArgument="REASON"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("REASON") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbSTATUS" runat="server" Text="假單狀態" CommandName="Sort" CommandArgument="STATUS"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppStatus" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbNEXT_REVIEWER" runat="server" Text="下位簽核者" CommandName="Sort" CommandArgument="NEXT_REVIEWER"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNextReviewer" runat="server" Text='<%#Eval("NEXT_REVIEWER") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbApplication_Time" runat="server" Text="申請時間" CommandName="Sort" CommandArgument="APPLICATION_DATE"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplicationTime" runat="server" Text='<%#Eval("APPLICATION_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbLAST_ACTION_TIME" runat="server" Text="最後動作時間" CommandName="Sort" CommandArgument="LAST_ACTION_TIME"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastActionTime" runat="server" Text='<%#Eval("LAST_ACTION_TIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="人事退回" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnSearch_Deny" runat="server" Text="退回" CssClass="btn btn-danger" OnClientClick="return confirmDeny();" OnClick="btnDeny_Click"></asp:LinkButton>
                                        <%--<asp:Button ID="btnSearch_Deny" runat="server" Text="退回" CssClass="btn btn-danger" OnClientClick="return confirmDeny();" OnClick="btnDeny_Click" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbERP_STATUS" runat="server" Text="ERP登入狀態" CommandName="Sort" CommandArgument="ERP_STATUS"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblERPStatus" runat="server" Text='<%#Eval("ERP_STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!--Modals-->
    <asp:UpdatePanel ID="upApplicationForm" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddApplicationForm" />
            <asp:AsyncPostBackTrigger ControlID="ddlDayOffType" />
        </Triggers>
        <ContentTemplate>
            <div class="modal" id="ApplicationForm" data-backdrop="false" tabindex="-1" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="lblApplicationFormTitle" runat="server" Text=""></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">假別</span>
                                </div>
                                <asp:DropDownList ID="ddlDayOffType" runat="server" CssClass="custom-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDayOffType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="mb-1">
                                <asp:Label ID="lblDayOffRemaining" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="input-group mb-1" id="datetimepicker" data-target-input="nearest">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">請假日期</span>
                                </div>
                                <asp:TextBox ID="txtDayOffBeginDateTime" runat="server"
                                    CssClass="form-control datetimepicker-input"
                                    data-target="#datetimepicker"></asp:TextBox>
                                <div class="input-group-append" data-target="#datetimepicker" data-toggle="datetimepicker">
                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                </div>
                            </div>
                            <div class="input-group mb-1" id="timepickerend" data-target-input="nearest">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">結束時間</span>
                                </div>
                                <asp:TextBox ID="txtDayOffEndTime" runat="server"
                                    CssClass="form-control datetimepicker-input"
                                    data-target="#timepickerend"></asp:TextBox>
                                <div class="input-group-append" data-target="#timepickerend" data-toggle="datetimepicker">
                                    <div class="input-group-text"><i class="far fa-clock"></i></div>
                                </div>
                            </div>
                            <div class="input-group mb-1">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">代理人</span>
                                </div>
                                <asp:DropDownList ID="ddlDayOffFuncSub" runat="server" CssClass="custom-select"></asp:DropDownList>
                            </div>
                            <div class="input-group">
                                <asp:CheckBox ID="ckbTyphoonDayNoSub" runat="server" CssClass="custom-checkbox" Checked="false"
                                    Text="此假用在颱風天，無須代理人" />
                            </div>
                            <div class="form-group">
                                <span>請假事由:</span>
                                <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" MaxLength="100"
                                    TextMode="MultiLine"
                                    placeholder="事假必填(100字內)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnDayOffAdd" runat="server" CssClass="btn btn-success w-100" Text=""
                                UseSubmitBehavior="false"
                                data-dismiss="modal"
                                OnClick="btnDayOffAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upAttachment" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div class="modal" id="Attachment" data-backdrop="false" tabindex="-1" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <asp:Label ID="lblApplicationIdForAttachment" runat="server" Text=""></asp:Label>
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="input-group justify-content-between mb-2">
                                <input id="fileAttachment" name="fileBox" type="file" multiple="multiple" accept=".jpg, .png" />
                                <asp:Button ID="btnAddAttachment" runat="server" Text="增加附件" CssClass="btn btn-success"
                                    UseSubmitBehavior="false"
                                    OnClientClick="uploadFileFromApplication();"/>
                            </div>
                            <div class="input-group justify-content-end mb-2">
                                <asp:Button ID="btnOpenAttachment" runat="server" Text="開啟附件" CssClass="btn btn-primary mr-2"
                                    UseSubmitBehavior="false"
                                    OnClick="btnOpenAttachment_Click" />
                                <asp:Button ID="btnRemoveAttachment" runat="server" Text="移除附件" CssClass="btn btn-danger"
                                    UseSubmitBehavior="false"
                                    OnClick="btnRemoveAttachment_Click" />
                            </div>
                            <div class="input-group">
                                <asp:ListBox ID="lbxAttachmentList" runat="server" CssClass="form-control"></asp:ListBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
