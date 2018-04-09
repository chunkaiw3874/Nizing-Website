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
        th td {
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
        $(document).on('click', '#<%=tbApprovalPending.ClientID%> tr', function () {
            $(this).toggleClass('highlight');
        });
        //$('td').attr('unselectable', 'on');
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
        });
        function confirmWithdrawal() {
            if (confirm('確定要撤銷此張假單嗎?')) {
                return true;
            }
            else {
                return false;
            }
        };
        function confirmApprove() {
            if (confirm('確定要簽核此張假單嗎?')) {                
                return true;
            }
            else {
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
            <%--<div class="row form-group">
                <div class="col-xs-12">
                    <h2>新申請</h2>
                </div>
            </div>--%>
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
                    <div class="col-xs-10">
                        <span class="label label-default" style="font-size: 16px;">請假原因</span>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-xs-4 col-xs-offset-2" style="display: inline;">
                        <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" MaxLength="20" placeholder="事假必填(20字內)"></asp:TextBox>
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
                            <table id="tbApprovalPending" class="table col-xs-12" runat="server">
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
                                    <asp:LinkButton ID="lbApplication_Date" runat="server" Text="申請時間" CommandName="Sort" CommandArgument="APPLICATION_DATE"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("APPLICATION_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lbLAST_ACTION_TIME" runat="server" Text="最後動作時間" CommandName="Sort" CommandArgument="LAST_ACTION_TIME"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("LAST_ACTION_TIME") %>'></asp:Label>
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
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("DAYOFF_START_TIME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lbDAYOFF_END_TIME" runat="server" Text="請假結束時間" CommandName="Sort" CommandArgument="DAYOFF_END_TIME"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("DAYOFF_END_TIME") %>'></asp:Label>
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

