<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI04.aspx.cs" Inherits="hr360_UI04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" runat="Server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'yyyymmdd',
                autoclose: true
            });            
            var isPostBack = $('#<%=hdnIsDayOffAppVisible.ClientID%>').val();
            if (isPostBack == '0') {
                $('#DayOffApp').hide();
            }
            else {
                if ($('#<%=hdnIsDayOffAppVisible.ClientID%>').val()=='1') {
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
            <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtTestName" runat="server"></asp:TextBox>
            <asp:Button ID="btnTestName" runat="server" Text="測試ERP ID" OnClick="btnTestName_Click" />
        </div>
        <div class="row form-group" style="margin-top: 10px;">
            <div class="col-xs-12">
                <span class="label label-info" id="btnDayOffAppVisibility" style="cursor: pointer; font-size: 20px;">我要請假</span>
                <asp:HiddenField ID="hdnIsPostBack" runat="server" />
                <asp:HiddenField ID="hdnIsDayOffAppVisible" runat="server" />
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
            <div class="row form-group">
                <div class="col-xs-2">
                    <asp:Label ID="lblDayOffRemainType" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblDayOffRemainAmount" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblDayOffRemainUnit" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-xs-7 col-xs-offset-3">
                    <asp:ImageButton ID="btnDayOffAdd" runat="server" ImageUrl="~/hr360/image/icon/green-arrow-down.png" Width="40" OnClick="btnDayOffAdd_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            本次請假內容                       
                        </div>
                        <div class="panel-body">
                            <table class="table col-xs-12">
                                <thead>
                                    <tr>
                                        <th>假別</th>
                                        <th>開始時間</th>
                                        <th>結束時間</th>
                                        <th>請假總量</th>
                                        <th>假別剩餘</th>
                                        <th>代理人</th>
                                        <th>移除</th>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">特休</td>
                                        <td style="text-align: center;">2017/01/31 08:00 AM</td>
                                        <td style="text-align: center;">2017/01/31 05:30 PM</td>
                                        <td style="text-align: center;">8.5 時</td>
                                        <td style="text-align: center;">300 時</td>
                                        <td style="text-align: center;">0010 陳淑倩</td>
                                        <td style="text-align: center;">移除</td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">補休</td>
                                        <td style="text-align: center;">2017/02/01 08:00 AM</td>
                                        <td style="text-align: center;">2017/02/01 13:00 PM</td>
                                        <td style="text-align: center;">5 時</td>
                                        <td style="text-align: center;">300 時</td>
                                        <td style="text-align: center;">0010 陳淑倩</td>
                                        <td style="text-align: center;">移除</td>
                                    </tr>
                                </thead>
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

