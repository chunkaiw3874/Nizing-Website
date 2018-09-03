<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HR10.aspx.cs" Inherits="nizing_intranet_HR10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../css/paper.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-datepicker.js"></script>
    <script src="../Scripts/locales/bootstrap-datepicker.zh-TW.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                language: 'zh-TW',
                format: 'yyyy-mm-dd',
                autoclose: true,
                todayBtn: true,
                todayHighlight: true
            });
        })
    </script>
    <style>
        @page{
            size: A4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <h2>每月人事出勤首尾筆報告(由智碁系統擷取)</h2>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-xs-2" style="display: inline; padding-right: 0px;">
                <asp:TextBox ID="txtDatePickerStart" runat="server" CssClass="form-control datepicker" placeholder="選擇查詢開始日期"></asp:TextBox>
            </div>            
            <div class="col-xs-2" style="display: inline; padding-right: 0px;">
                <asp:TextBox ID="txtDatePickerEnd" runat="server" CssClass="form-control datepicker" placeholder="選擇查詢結束日期"></asp:TextBox>
            </div>
            <div class="col-xs-2">
                <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
    <div class="row printarea">
        <div class="col-xs-12">
            <asp:GridView ID="gvResult" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>

