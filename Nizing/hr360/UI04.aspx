<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI04.aspx.cs" Inherits="hr360_UI04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" runat="Server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <script src="../Scripts/text.area.auto.adjust.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <style>
        .no-resize {
            resize: none;
        }
        #loading-screen{
            display:none;
            position:fixed;
            top:50%;
            left:50%;
            text-align:center;
        }
        .highlight{
            background-color:lightblue;
        }
        .nohighlight{
            background-color:none;
        }
        .noselect {
            user-select: none; /* CSS3 (little to no support) */
            -ms-user-select: none; /* IE 10+ */
            -moz-user-select: none; /* Gecko (Firefox) */
            -webkit-user-select: none; /* Webkit (Safari, Chrome) */
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $('.autosize').autosize();
        });
        $(document).ready(function () {
            $('.datepicker').datepicker({
                language: 'zh-TW',
                format: 'yyyy/mm/dd',
                autoclose: true,
                todayBtn: true,
                todayHighlight: true
            });
            var isPostBack = $('#<%=hdnIsPostBack.ClientID%>').val();
            if (isPostBack == '0') {
                $('#DayOffApp').hide();
                $('#search_section').show();
            }
            else {
                    if ($('#<%=hdnIsDayOffAppVisible.ClientID%>').val() == '1') {
                        $('#DayOffApp').show();
                    }
                    else {
                        $('#DayOffApp').hide();
                    }
                    if ($('#<%=hdnIsSearchFieldVisible.ClientID%>').val() == '1') {
                        $('#search_section').show();
                    }
                    else {
                        $('#search_section').hide();
                    }
            };
            $(document).on('click', '#btnSearchVisibility', function () {
                $('#search_section').toggle();
                if ($('#search_section').is(":visible") == true) {
                    $('#search_section').show();
                    $('#<%=hdnIsSearchFieldVisible.ClientID%>').val('1');
                }
                else {
                    $('#search_section').hide();
                    $('#<%=hdnIsSearchFieldVisible.ClientID%>').val('0');
                }
            });
            $(document).on('click', '#btnDayOffAppVisibility', function () {
                $('#DayOffApp').toggle();
                if ($('#DayOffApp').is(":visible") == true) {
                    $('#DayOffApp').show();
                    $('#<%=hdnIsDayOffAppVisible.ClientID%>').val('1');
                }
                else {
                    $('#DayOffApp').hide();
                    $('#<%=hdnIsDayOffAppVisible.ClientID%>').val('0');
                }
            });
            $("[data-toggle='popover']").popover({
                trigger: 'click'
            });
            
            $('.classApprovalPending tr').click(function () {
                approvalTableSelection($(this).index());
            }
            );
        });
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
        }
        function selectBetweenItemsIntbApprovalPending(a, b) {
            for (var i = a; i <= b; i++) {                    
                $('.classApprovalPending tr').eq(i).addClass('highlight');
            }            
        }
        function clearSelectionOntbApprovalPending(){
            for(var i=1; i<= $('.classApprovalPending tr').length; i++){
                $('.classApprovalPending tr').eq(i).removeClass('highlight');
            }
        }
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
        }
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
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" runat="Server">    
    <div class="container">
        <%--<div id="test_section">
            <div class="row form-group">
                測試中，請勿使用    
                <br />
                <asp:TextBox ID="txtTestName" runat="server"></asp:TextBox>
                <asp:Button ID="btnTestName" runat="server" Text="測試ERP ID" OnClick="btnTestName_Click" />
                <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="row form-group">
                <asp:Button ID="btnTestEmail" runat="server" Text="Send Test Email" OnClick="btnTestEmail_Click" />
            </div>
            <hr />
        </div>--%>
        <div id="application_section">
            <div class="row" style="color:red">
                *本次版更內容: 一張假單僅能請一天假，如需多天請假需登打多張假單
            </div>
            <div class="row form-group" style="margin-top: 10px;">
                <div class="col-xs-12">
                    <span class="label label-info" id="btnDayOffAppVisibility" style="cursor: pointer; font-size: 20px;">我要請假</span>
                    <asp:HiddenField ID="hdnIsPostBack" runat="server" />
                    <asp:HiddenField ID="hdnIsDayOffAppVisible" runat="server" />
                    <asp:HiddenField ID="hdnDayOffTimeRestraint" runat="server" />
                    <asp:HiddenField ID="hdnOfficeOrProduction" runat="server" />
                    <asp:HiddenField ID="hdnEmployeeRank" runat="server" />
                    <asp:HiddenField ID="hdnImmediateReviewerID" runat="server" />
                    <asp:HiddenField ID="hdnNormalWorkHour" runat="server" />
                    <asp:HiddenField ID="hdnDayOffTimeRemainBeforeSubmit" runat="server" />
                    <asp:HiddenField ID="hdnTotalDayOffTime" runat="server" />
                    <asp:HiddenField ID="hdnDayOffTypeUnit" runat="server" />
                    <asp:HiddenField ID="hdnDenyReason" runat="server" />
                </div>
            </div>
            <div id="DayOffApp">                
                <div class="row">
                    <div class="col-xs-2">
                        <span class="label label-default" style="font-size: 16px;">假別</span>
                    </div>
                    <div class="col-xs-4">
                        <span class="label label-default" style="font-size: 16px;">請假起始時間</span>
                    </div>
                    <div class="col-xs-4">
                        <span class="label label-default" style="font-size: 16px;">請假結束時間</span>
                    </div>
                    <div class="col-xs-2">
                        <span class="label label-default" style="font-size: 16px;">代理人</span>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-xs-2">
                        <asp:DropDownList ID="ddlDayOffType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDayOffType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2" style="display: inline; padding-right: 0px;">
                        <asp:TextBox ID="txtDatePickerStart" runat="server" CssClass="form-control datepicker" placeholder="請假起始日期"></asp:TextBox>
                    </div>
                    <div class="col-xs-1" style="display: inline; padding: 0px;">
                        <asp:DropDownList ID="ddlDayOffStartHour" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-xs-1" style="display: inline; padding-left: 0px;">
                        <asp:DropDownList ID="ddlDayOffStartMin" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2" style="display: inline; padding-right: 0px;">
                        <asp:TextBox ID="txtDatePickerEnd" runat="server" CssClass="form-control datepicker" placeholder="請假結束日期"></asp:TextBox>
                    </div>
                    <div class="col-xs-1" style="display: inline; padding: 0px;">
                        <asp:DropDownList ID="ddlDayOffEndHour" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-xs-1" style="display: inline; padding-left: 0px;">
                        <asp:DropDownList ID="ddlDayOffEndMin" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2" style="display: inline;">
                        <asp:DropDownList ID="ddlDayOffFuncSub" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2">
                        <asp:Label ID="lblDayOffRemainType" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblDayOffRemainAmount" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblDayOffRemainUnit" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-2 col-xs-offset-8">
                        <asp:CheckBox ID="ckbTyphoonDayNoSub" runat="server" CssClass="checkbox-inline" Checked="false" Text="此假用在颱風天，無須代理人" />
                    </div>
                </div>
                <div class="row">                    
                    <div class="col-xs-12">
                        <span class="label label-default" style="font-size: 16px;">請假原因</span>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-xs-12" style="display: inline;">
                        <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" MaxLength="100" placeholder="事假必填(100字內)"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-xs-1 col-xs-offset-5">
                        <asp:ImageButton ID="btnDayOffAdd" runat="server" ImageUrl="~/hr360/image/icon/green-arrow-down.png" Width="40" OnClick="btnDayOffAdd_Click" />
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="txtErrorMessage" runat="server" TextMode="MultiLine" CssClass="autosize no-resize error-message" Width="400" BorderStyle="none" Wrap="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                本次請假內容                      
                           
                            </div>
                            <div class="panel-body">
                                <div style="color:red">
                                    *假單不得跨天，請假半小時無須代理人<br />
                                    *休假最小單位為:辦公室0.5小時;製造部門0.5天<br />
                                    *請假前須確認當天工作進度已安排人員支援，且有代理人簽名<br />
                                    *請事假、病假過多者，會影響到年終獎金之發放<br />
                                    *未經主管核簽及人事核准，假單不生效，不出勤將視為曠職<br />
                                    *請病假1天以內，需附上合法醫療院所之收據；2日(含)以上者，需附上醫生診斷證明<br />
                                    *連續請假3日(含)者，須有正當理由
                                </div>
                                <table id="tbAppSummary" class="table col-xs-12" runat="server">
                                </table>
                            </div>
                            <div class="panel-footer" style="text-align: right;">
                                <asp:Button ID="btnAppSubmit" runat="server" Text="送出" CssClass="btn btn-primary" OnClick="btnAppSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div id="in-progress_section">
            <div class="row form-group">
                <div class="col-xs-12">
                    <h2>申請中</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            申請中假單
                       
                        </div>
                        <div class="panel-body">
                            <table id="tbInProgressSummary" class="table col-xs-12" runat="server">
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div id="approval_section">
            <div class="row form-group">
                <div class="col-xs-12">
                    <h2>待簽核</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            待簽核假單                       
                        </div>
                        <div class="panel-body">
                            <div style="color:red;">
                                *請先點選要簽核的假單，再點選最上層的"簽核"按鈕;如欲一次簽核多張假單，可按住Shift一次選擇，或按住Ctrl增選<br />
                                **退回不可複選<br />
                                ***如操作上有疑問，請詢問人事部
                            </div>
                            <asp:HiddenField ID="hdnApprovalPendingSelection" ClientIDMode="Static" runat="server" />
                            <table id="tbApprovalPending" class="table col-xs-12 classApprovalPending noselect" runat="server">
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row form-group">
            <div class="col-xs-12">
                <span class="label label-info" id="btnSearchVisibility" style="cursor: pointer; font-size: 20px;">查詢歷史假單</span>
                <asp:HiddenField ID="hdnIsSearchFieldVisible" runat="server" />
            </div>
        </div>
        <div id="search_section">
            <div class="row form-group">
                <div class="col-xs-3">
                    <asp:DropDownList ID="ddlSearch_Parameter_ApplicantID" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-2">
                    <asp:TextBox ID="txtSearch_Parameter_StartDate" runat="server" CssClass="form-control datepicker" placeholder="查詢起始日期"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:TextBox ID="txtSearch_Parameter_EndDate" runat="server" CssClass="form-control datepicker" placeholder="查詢結束日期"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList ID="ddlSearch_Parameter_ApplicationStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-2">
                    <asp:Button ID="btnSearchSubmit" runat="server" Text="查詢" CssClass="btn btn-success" OnClick="btnSearchSubmit_Click" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col-xs-12">
                    <asp:GridView ID="gvSearchResult" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" 
                        OnRowDataBound="gvSearchResult_RowDataBound" OnPageIndexChanging="gvSearchResult_PageIndexChanging"                                         
                        AllowPaging="True" PageSize="10" PagerSettings-Position="Top" PagerSettings-Mode="NumericFirstLast"
                        PagerSettings-FirstPageText="首頁" PagerSettings-LastPageText="尾頁" OnRowCommand="gvSearchResult_RowCommand">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lbApplication_ID" runat="server" Text="假單單號" CommandName="Sort" CommandArgument="APPLICATION_ID"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAppId" runat="server" Text='<%#Eval("APPLICATION_ID") %>'></asp:Label>
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
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>    
</asp:Content>

