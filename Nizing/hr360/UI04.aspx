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
            var isPostBack = $('#<%=hdnIsDayOffAppVisible.ClientID%>').val();
            if (isPostBack == '0') {
                $('#DayOffApp').hide();
            }
            else {
                if ($('#<%=hdnIsDayOffAppVisible.ClientID%>').val() == '1') {
                    $('#DayOffApp').show();
                }
                else {
                    $('#DayOffApp').hide();
                }
            };

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
            })
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
            if (confirm('確定要退回此張假單嗎?')) {
                return true;
            }
            else {
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
        <div id="application_section">
            <div class="row form-group">
                測試中，請勿使用
           
                <br />
                <asp:TextBox ID="txtTestName" runat="server"></asp:TextBox>
                <asp:Button ID="btnTestName" runat="server" Text="測試ERP ID" OnClick="btnTestName_Click" />
                <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
            </div>
            <hr />
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
    </div>
</asp:Content>

