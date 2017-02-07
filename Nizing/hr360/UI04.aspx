<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI04.aspx.cs" Inherits="hr360_UI04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" runat="Server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'yyyymmdd',
                autoclose: true
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
            <div class="col-xs-12">
                <asp:Button ID="btnDayOffAppVisibility" runat="server" Text="我要請假" CssClass="btn btn-info btn-lg" />
            </div>
        </div>
        <div id="DayOffApp">
            <div class="row">
                <div class="col-xs-2">
                    <span class="label label-default" style="font-size:16px;">假別</span>
                </div>
                <div class="col-xs-4">
                    <span class="label label-default" style="font-size:16px;">請假起始時間</span>
                </div>
                <div class="col-xs-4">
                    <span class="label label-default" style="font-size:16px;">請假結束時間</span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlDayOffType" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-2" style="display:inline;padding-right:0px;">
                    <asp:TextBox ID="txtDatePickerStart" runat="server" CssClass="form-control datepicker" placeholder="請假起始日期"></asp:TextBox>
                </div>
                <div class="col-xs-1" style="display:inline;padding:0px;">
                    <asp:DropDownList ID="ddlDayOffStartHour" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1" style="display:inline;padding-left:0px;">
                    <asp:DropDownList ID="ddlDayOffStartMin" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-2" style="display:inline;padding-right:0px;">
                    <asp:TextBox ID="txtDatePickerEnd" runat="server" CssClass="form-control datepicker" placeholder="請假結束日期"></asp:TextBox>
                </div>
                <div class="col-xs-1" style="display:inline;padding:0px;">
                    <asp:DropDownList ID="ddlDayOffEndHour" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-xs-1" style="display:inline;padding-left:0px;">
                    <asp:DropDownList ID="ddlDayOffEndMin" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
    </div>
</asp:Content>

