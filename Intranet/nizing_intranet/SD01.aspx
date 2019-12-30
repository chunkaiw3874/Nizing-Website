﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SD01.aspx.cs" Inherits="SD01" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .error-class {
            color: #FF0000; /* red */
        }

        .valid-class {
            /*color:#00CC00;*/ /* green */
        }
        .grdResultWithFooter .stackedHeader-1{
            background-color:#29ABE2;
            color:#ffffff;
            font-weight:bold;
        }
    </style>
    <script>
        $(document).ready(function () {
            jQuery.validator.addMethod('decimal', function (value, element) {
                return !(value % 1);
            }, "不可有小數"); //validate no decimal places
            //jQuery.validator.addMethod('sRequired', $.validator.methods.required, "此為必填欄位"); //custom message for validating required field
            jQuery.validator.addMethod('sNumber', $.validator.methods.number, "請輸入正確的數字格式"); //custom message for validating number-only input
            //jQuery.validator.addMethod('sRange', $.validator.methods.range, $.validator.format("數值必須在{0}與{1}之間")); //custom message for validating range
            jQuery.validator.addClassRules('numbers-only', {
                //sRequired: true,
                sNumber: true,
                decimal: true
            }); //intialize validation
            $('#form1').validate({
                errorClass: "error-class",
                validClass: "valid-class",
                //submitHandler: function (form) {
                //    form.submit();
                //}
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="NetSale" class="container-fluid">
        <div id="Admin" runat="server" visible="false">
            <div id="SetTarget" runat="server">
                <div id="SetTargetTrigger" runat="server">
                    <div class="row form-group">
                        <div class="col-xs-12">
                            <asp:Button ID="btnTargetTrigger" runat="server" Text="設定業務目標" CssClass="btn btn-info" OnClick="btnTargetTrigger_Click" />
                        </div>
                    </div>
                </div>
                <div id="SetTargetContent" runat="server" visible="false">
                    <div class="row form-group">
                        <div class="col-xs-2">
                            <asp:DropDownList ID="ddlTargetYear" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTargetChanged"></asp:DropDownList>
                        </div>
                        <div class="col-xs-1">
                            <asp:DropDownList ID="ddlTargetMonth" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTargetChanged"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:DropDownList ID="ddlTargetEmp" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTargetChanged"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:TextBox ID="txtTarget" runat="server" CssClass="form-control numbers-only" placeholder="目標金額"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button ID="btnTargetSubmit" runat="server" Text="儲存" CssClass="btn btn-success" OnClick="btnTargetSubmit_Click" />
                        </div>
                        <div class="col-xs-1">
                            <asp:Button ID="btnTargetDelete" runat="server" Text="刪除" CssClass="btn btn-danger" Enabled="false" OnClick="btnTargetDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h2>業績排名表</h2>
            </div>
        </div>
        <div id="SearchCondition" class="form-group">
            <div class="row">
                <div class="col-xs-3">
                    <asp:RadioButton ID="rdoDDL" runat="server" Text="快速選單" GroupName="R2" Checked="true" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" CssClass="radio-inline" />
                </div>
                <div class="col-xs-3">
                    <asp:RadioButton ID="rdoText" runat="server" Text="選擇日期(yyyyMMdd)" GroupName="R2" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1">
                    <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" CssClass="radio-inline" />
                </div>
                <div class="col-xs-1">
                    <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col-xs-2">
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-1">
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label class="control-label col-xs-2">開始查詢日期</label>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtStart" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label class="control-label col-xs-2 col-xs-offset-3">結束查詢日期</label>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        <br />
            <div class="row">
                <div class="col-xs-3">
                    <asp:DropDownList ID="ddlPersonnel" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="TG006" CssClass="form-control">
                        <asp:ListItem Selected="True">全部人員</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NZConnectionString %>" SelectCommand="SELECT DISTINCT TG006, TG006+' '+MV002 MV002
                    FROM COPTG
	                    LEFT JOIN CMSMV MV ON TG006 = MV001
                    WHERE TG006 &lt;&gt; ''
                    ORDER BY TG006"></asp:SqlDataSource>
                </div>
                <div class="col-xs-5">
                    <asp:Label ID="lblRdoTextWarning" runat="server" Text="" ForeColor="Red" Visible="false">*使用"選擇日期"作為查詢條件時，目標金額及未達成金額僅供參考</asp:Label>
                </div>
            </div>
        </div>
        <div>
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnExport" runat="server" Text="匯出至Excel" OnClick="btnExport_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <div id="OutputField">
        <div id="search-result">
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Label ID="lblRange" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdReport" runat="server" 
                        OnDataBound="grdReport_DataBound" 
                        OnRowCreated="grdReport_RowCreated"
                        AutoGenerateColumns="false"
                        ShowFooter="True" CssClass="grdResultWithFooter" HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="排名">
                                <itemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("rank") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務名稱">
                                <itemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("salesName") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務代號">
                                <itemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("salesId") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="國內">
                                <itemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("domesticSale") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="國外">
                                <itemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("foreignSale") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="國內">
                                <itemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("domesticReturn") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="國外">
                                <itemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("foreignReturn") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="銷貨淨額">
                                <itemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("netSale") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="目標金額">
                                <itemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("saleTarget") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
<%--                            <asp:TemplateField HeaderText="未達成金額">
                                <itemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("targetDifference") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="退貨件數">
                                <itemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("returnAmount") %>'></asp:Label>
                                </itemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Chart ID="Chart1" runat="server" Width="400" Height="300" >
                        <Legends>
                           <asp:Legend Alignment="Center" Docking="Bottom" Name="Legend1">
                           </asp:Legend>
                       </Legends>
                        <Series>
                            <asp:Series ChartType="StackedColumn" Name="domestic" Color="#29ABE2" LegendText="國內" Label="#VAL" LabelForeColor="#000000"></asp:Series>
                            <asp:Series ChartType="StackedColumn" Name="foreign" Color="Orange" LegendText="國外" Label="#VAL" LabelForeColor="#000000"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>           
        </div>
    </div>
</asp:Content>

