<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ACC01.aspx.cs" Inherits="nizing_intranet_ACC01" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-ui-1.12.0.min.js"></script>
    <style>
        .right-align {
            text-align: right !important;
        }

        .ui-autocomplete {
            padding: 0px;
            background-color: inherit;
            border: solid 1px #cccccc;
            border-radius: 4px;
            max-height: 200px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
            /* add padding to account for vertical scrollbar */
            padding-right: 20px;
            cursor: pointer;
        }

            .ui-autocomplete .ui-menu-item:hover {
                background-color: lightblue;
            }
    </style>
    <script type="text/javascript">
        jQuery.ui.autocomplete.prototype._resizeMenu = function () {
            var ul = this.menu.element;
            ul.outerWidth(this.element.outerWidth());
        }
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtClientID").autocomplete({
                source: function (request, response) {
                    var param = { keyword: $('#<%= txtClientID.ClientID %>').val() };
                    $.ajax({
                        url: "/nizing_intranet/ACC01.aspx/GetClientList",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1,
                autoFocus: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-sm-12 h2">
            發票開立統計表
       
        </div>
    </div>
    <div class="row form-group">
        <div class="col-sm-2">
            <asp:RadioButton ID="rdoDetailReport" runat="server" GroupName="ReportType" AutoPostBack="true" Checked="true" OnCheckedChanged="rdoDetailReport_CheckedChanged" CssClass="radio-inline" Text="明細報表" />
        </div>
        <div class="col-sm-2">
            <asp:RadioButton ID="rdoAnnualReport" runat="server" GroupName="ReportType" AutoPostBack="true" OnCheckedChanged="rdoDetailReport_CheckedChanged" CssClass="radio-inline" Text="年度報表" />
        </div>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <label class="input-group-text">發票期間</label>
        </div>
        <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="custom-select">
        </asp:DropDownList>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <label class="input-group-text">客戶代號</label>
        </div>
        <asp:TextBox ID="txtClientID" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <label class="input-group-text">申報公司</label>
        </div>
        <asp:DropDownList ID="ddlCompanyID" runat="server" CssClass="custom-select">
            <asp:ListItem Value="ALL">全部</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="input-group">
        <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnSubmit_Click" />
    </div>
    <div id="ReportSection">
        <div id="divDetailReport" class="row" runat="server">
            <div class="col-sm-12">
                <asp:GridView ID="gvDetailReport" runat="server" CssClass="grdResultWithFooter" AutoGenerateColumns="false" ShowFooter="true" OnDataBound="gvDetailReport_DataBound" OnRowCreated="gvDetailReport_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="結帳單據日期" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl1" runat="server" Text='<%#Eval("結帳單據日期") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶代號" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("客戶代號") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶名稱" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl3" runat="server" Text='<%#Eval("客戶名稱") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發票日期" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("發票日期") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發票號碼" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("發票號碼") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申報公司" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("申報公司") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公司簡稱" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl7" runat="server" Text='<%#Eval("公司簡稱") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="應收金額" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="right-align">
                            <ItemTemplate>
                                <asp:Label ID="lbl8" runat="server" Text='<%#Eval("應收金額") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="營業稅額" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="right-align">
                            <ItemTemplate>
                                <asp:Label ID="lbl9" runat="server" Text='<%#Eval("營業稅額") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="應收總計" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="right-align">
                            <ItemTemplate>
                                <asp:Label ID="lbl10" runat="server" Text='<%#Eval("應收總計") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="divAnnualReport" class="row" runat="server">
            <div class="col-sm-7">
                <asp:GridView ID="gvAnnualReport" runat="server" CssClass="grdResultWithFooter" AutoGenerateColumns="false" ShowFooter="true" OnDataBound="gvAnnualReport_DataBound" OnRowCreated="gvAnnualReport_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="發票年度" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl1" runat="server" Text='<%#Eval("發票年度") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申報公司" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("申報公司") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公司簡稱" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lbl3" runat="server" Text='<%#Eval("公司簡稱") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="應收金額" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="right-align">
                            <ItemTemplate>
                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("應收金額") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="營業稅額" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="right-align">
                            <ItemTemplate>
                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("營業稅額") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="應收總計" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="right-align">
                            <ItemTemplate>
                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("應收總計") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-5">
                <asp:Chart ID="chartAnnualReport" runat="server">
                    <Series>
                        <asp:Series Name="Series1" IsValueShownAsLabel="True"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </div>
</asp:Content>

