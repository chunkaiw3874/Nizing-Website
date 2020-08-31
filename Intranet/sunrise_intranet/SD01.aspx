<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/sunrise-master.master" AutoEventWireup="true" CodeFile="SD01.aspx.cs" Inherits="SD01" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .error-class {
            color: #FF0000; /* red */
        }

        .valid-class {
            /*color:#00CC00;*/ /* green */
        }

        th{
            text-align:center;
        }

        .text-left{
            text-align:left;
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
        <div class="row">
            <div class="col-sm-12">
                <h2>銷售淨額報表</h2>
            </div>
        </div>
        <div id="SearchCondition" class="form-group">
            <div class="row">
                <div class="col-sm-7">
                    <asp:RadioButton ID="rdoDDL" runat="server" Text="快速選單" GroupName="R2" Checked="true" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" CssClass="radio-inline" />
                </div>
                <div class="col-sm-5">
                    <asp:RadioButton ID="rdoText" runat="server" Text="選擇日期(yyyyMMdd)" GroupName="R2" AutoPostBack="true" OnCheckedChanged="R2_CheckedChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" CssClass="radio-inline" />
                </div>
                <div class="col-sm-3">
                    <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3">
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
                <label class="control-label col-sm-2">開始查詢日期</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtStart" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label class="control-label col-sm-2 offset-sm-7">結束查詢日期</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlPersonnel" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="MV002" DataValueField="TG006" CssClass="form-control">
                        <asp:ListItem Selected="True">全部人員</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SunriseConnectionString %>" SelectCommand="SELECT DISTINCT TG006, TG006+' '+MV002 MV002
                    FROM COPTG
	                    LEFT JOIN CMSMV MV ON TG006 = MV001
                    WHERE TG006 &lt;&gt; ''
                    ORDER BY TG006"></asp:SqlDataSource>
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
                <div class="col-sm-12">
                    <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="lblRange" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    <asp:GridView ID="grdReport" runat="server" OnDataBound="grdReport_DataBound" OnRowCreated="grdReport_RowCreated" ShowFooter="True" CssClass="grdResultWithFooter" HorizontalAlign="Center">
                    </asp:GridView>
                </div>
                <div class="col-md-5">
                    <asp:Chart ID="Chart1" runat="server" Width="500px">
                        <Series>
                            <asp:Series Name="Series1" IsValueShownAsLabel="True"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="grdSalesRecord" runat="server" CssClass="grdResult" HorizontalAlign="Center" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="單據日期">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("單據日期") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶代號">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("客戶代號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客戶簡稱">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("客戶簡稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務員">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("業務員") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品號">
                                <ItemStyle CssClass="text-left" />
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("品號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="品名">
                                <ItemStyle CssClass="text-left" />
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("品名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="銷貨數量">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("銷貨數量") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("單位") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="幣別">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("幣別") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單價">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("單價") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="本幣銷貨金額">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("本幣銷貨金額") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="備註">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("備註") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    <asp:GridView ID="grdReport2" runat="server" AutoGenerateColumns="false" OnDataBound="grdReport2_DataBound" OnRowCreated="grdReport2_RowCreated" ShowFooter="True" CssClass="grdResultWithFooter">
                        <Columns>
                            <asp:TemplateField HeaderText="排名">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("排名") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務名稱">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("業務名稱") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="業務代號">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("業務代號") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨金額">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("退貨金額") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="退貨件數">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("退貨件數") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-5">
                    <asp:Chart ID="Chart2" runat="server" Width="500px">
                        <Series>
                            <asp:Series Name="Series2" IsValueShownAsLabel="True"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

