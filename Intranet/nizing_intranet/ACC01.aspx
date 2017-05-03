<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ACC01.aspx.cs" Inherits="nizing_intranet_ACC01" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/jquery-ui-1.12.0.min.js"></script>
    <style>
        .right-align{
            text-align:right !important;
        }
        /*.grdResultWithFooter tr td{
            text-align:right;
        }*/
    </style>
    <%--<script type="text/javascript">
        $(document).ready(function(){
            $("#txtClientID").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ACC01.aspx/GetClientList") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    })
                }
            })
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-xs-12 h2">
            發票開立統計表
        </div>
    </div>
    <div class="row form-group">
        <div class="col-xs-2">
            <asp:RadioButton ID="rdoDetailReport" runat="server" GroupName="ReportType" AutoPostBack="true" Checked="true" OnCheckedChanged="rdoDetailReport_CheckedChanged" CssClass="radio-inline" Text="明細報表" />
        </div>
        <div class="col-xs-2">
            <asp:RadioButton ID="rdoAnnualReport" runat="server" GroupName="ReportType" AutoPostBack="true" OnCheckedChanged="rdoDetailReport_CheckedChanged" CssClass="radio-inline" Text="年度報表" />
        </div>
    </div>
    <div class="row">
        <label class="control-label col-xs-1">發票期間:</label>
        <div class="col-xs-1" style="padding-right: 0px;">
            <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-xs-1" style="padding: 0px;">
            <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-xs-1" style="width: auto;">
            ~
        </div>
        <div class="col-xs-1" style="padding: 0px;">
            <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-xs-1" style="padding: 0px;">
            <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <label class="control-label col-xs-1">客戶代號:</label>
        <div class="col-xs-2" style="padding-right: 0px;">
            <asp:DropDownList ID="ddlClientID" runat="server" CssClass="form-control">
                <asp:ListItem Value="ALL">全部</asp:ListItem>
            </asp:DropDownList>
            <asp:HiddenField ID="hdnClientID" runat="server" />
            <%--<ajaxToolkit:ComboBox ID="cboClientID" runat="server" OnSelectedIndexChanged="cboClientID_SelectedIndexChanged"></ajaxToolkit:ComboBox>--%>
            <%--<asp:TextBox ID="txtClientID" runat="server"></asp:TextBox>--%>
        </div>
    </div>
    <div class="row form-group">
        <label class="control-label col-xs-1">申報公司:</label>
        <div class="col-xs-2" style="padding-right: 0px;">
            <asp:DropDownList ID="ddlCompanyID" runat="server" CssClass="form-control">
                <asp:ListItem Value="ALL">全部</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row form-group">
        <div class="col-xs-1">
            <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-success form-control" OnClick="btnSubmit_Click" />
        </div>
    </div>
    <div id="ReportSection">
        <div id="divDetailReport" class="row" runat="server">
            <div class="col-xs-12">
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
            <div class="col-xs-7">
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
            <div class="col-xs-5">
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

