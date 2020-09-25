<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="SD_ProfitMarginByProductReport.aspx.cs" Inherits="employee_section_report_SD_ProfitMarginByProductReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .scrollable {
            max-height: 500px;
            overflow: auto;
        }

        th {
            background-color: #29ABE2;
            color: #FFFFFF
        }

        td {
            background-color: #ffffff;
            color: #000000;
        }

        tr:nth-child(2n) td {
            background-color: #c3e8f4;
            color: #000000;
        }

        tr:last-child td{
            background-color: yellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h4>業務員利潤明細表</h4>
    </div>
    <asp:UpdatePanel ID="upSearchParameter" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div class="row mb-1">
                <div class="col-sm-3">
                    <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="reportType" AutoPostBack="true" OnCheckedChanged="reportTypeChanged" CssClass="radio-inline" />
                </div>
                <div class="col-sm-3">
                    <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="reportType" AutoPostBack="true" OnCheckedChanged="reportTypeChanged" CssClass="radio-inline" />
                </div>
            </div>
            <div class="input-group mb-1">
                <div class="input-group-append">
                    <span class="input-group-text">查詢時段</span>
                </div>
                <asp:DropDownList ID="ddlParameterYear" runat="server" CssClass="custom-select" AutoPostBack="true"
                    OnSelectedIndexChanged="TimeFrameChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlParameterMonth" runat="server" CssClass="custom-select" AutoPostBack="true"
                    OnSelectedIndexChanged="TimeFrameChanged">
                </asp:DropDownList>
            </div>
            <div class="input-group mb-2">
                <div class="input-group-append">
                    <span class="input-group-text">查詢人員</span>
                </div>
                <asp:DropDownList ID="ddlParameterSales" runat="server" CssClass="custom-select"></asp:DropDownList>
            </div>
            <div class="input-group mb-2">
                <div class="input-group-prepend">
                    <span class="input-group-text">管銷費用</span>
                    <span class="input-group-text">%</span>
                </div>
                <asp:TextBox ID="txtOperationCost" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="btn-group full-width">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success form-control" Text="送出"
                    OnClick="btnSubmit_Click" />
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-warning form-control" Text="匯出Excel"
                    OnClick="btnExport_Click"/>
                <asp:Button ID="btnResetParameter" runat="server" CssClass="btn btn-danger form-control" Text="清除"
                    OnClick="btnResetParameter_Click" />
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
    <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
            <asp:AsyncPostBackTrigger ControlID="btnResetParameter" />
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="lblDateRange" runat="server" Text=""></asp:Label>
            <div class="mb-5">
                <asp:GridView ID="gvData" runat="server" CssClass="table table-striped table-hover table-white"
                    AutoGenerateColumns="false" ShowFooter="true"
                    EmptyDataText="查無資料"
                    OnRowDataBound="gvData_RowDataBound"
                    OnDataBound="gvData_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="業務">
                            <ItemTemplate>
                                <asp:Label ID="lblSalesId" runat="server" Text='<%#Eval("業務") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="業務名稱">
                            <ItemTemplate>
                                <asp:Label ID="lblSalesName" runat="server" Text='<%#Eval("業務名稱") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="品號">
                            <ItemTemplate>
                                <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("品號") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label ID="lblItemUnit" runat="server" Text='<%#Eval("單位") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="品名" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("品名") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="規格" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblItemSpec" runat="server" Text='<%#Eval("規格") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銷售淨量">
                            <ItemTemplate>
                                <asp:Label ID="lblNetSaleAmount" runat="server" Text='<%#Eval("銷售淨量") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銷售淨額">
                            <ItemTemplate>
                                <asp:Label ID="lblNetSaleValue" runat="server" Text='<%#Eval("銷售淨額") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銷貨成本">
                            <ItemTemplate>
                                <asp:Label ID="lblSaleCost" runat="server" Text='<%#Eval("銷貨成本") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銷貨毛利">
                            <ItemTemplate>
                                <asp:Label ID="lblGrossProfit" runat="server" Text='<%#Eval("銷貨毛利") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="毛利率">
                            <ItemTemplate>
                                <asp:Label ID="lblGrossProfitPercent" runat="server" Text='<%#Eval("毛利率") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="管銷費用率">
                            <ItemTemplate>
                                <asp:Label ID="lblOperationCost" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="淨利率">
                            <ItemTemplate>
                                <asp:Label ID="lblNetProfitPercent" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

