<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI04.aspx.cs" Inherits="hr360_UI04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" runat="Server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <script src="../Scripts/text.area.auto.adjust.js"></script>
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
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" runat="Server">
    <div class="container">
        <div class="row form-group">
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
            </div>
        </div>
        <div id="DayOffApp">
            <asp:HiddenField ID="hdnNormalWorkHour" runat="server" />
            <asp:HiddenField ID="hdnTotalDayOffTime" runat="server" />
            <asp:HiddenField ID="hdnDayOffTypeUnit" runat="server" />
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
            <div class="row form-group">
                <div class="col-xs-2">
                    <asp:Label ID="lblDayOffRemainType" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblDayOffRemainAmount" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblDayOffRemainUnit" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-xs-1 col-xs-offset-3">
                    <asp:ImageButton ID="btnDayOffAdd" runat="server" ImageUrl="~/hr360/image/icon/green-arrow-down.png" Width="40" OnClick="btnDayOffAdd_Click" />
                </div>
                <div class="col-xs-6">
                    <asp:TextBox ID="txtErrorMessage" runat="server" TextMode="MultiLine" CssClass="autosize no-resize error-message" Width="300" BorderStyle="none" Wrap="false" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            本次請假內容                       
                        </div>
                        <div class="panel-body">
                            <table id="tbAppSummary" class="table col-xs-12" runat="server">
                                <%--<thead>
                                    <tr>
                                        <th>假別</th>
                                        <th>開始時間</th>
                                        <th>結束時間</th>
                                        <th>請假總量</th>
                                        <th>假別剩餘</th>
                                        <th>代理人</th>
                                        <th>移除</th>
                                    </tr>
                                </thead>--%>
                            </table>
                        </div>
                        <div class="panel-footer" style="text-align: right;">
                            <asp:Button ID="Button1" runat="server" Text="送出" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

