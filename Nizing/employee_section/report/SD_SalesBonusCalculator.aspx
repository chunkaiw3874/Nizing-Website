<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="SD_SalesBonusCalculator.aspx.cs" Inherits="employee_section_report_SD_SalesBonusCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .table td {
            vertical-align: middle;
            text-align: center;
        }

        table td:first-child {
            text-align: center;
            vertical-align: middle;
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

        tr:last-child td {
            background-color: yellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <!--2021.01.29 This Calculator is no longer in use; Sales Bonus calculation method has been changed-->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h4>業務獎金計算機</h4>
    </div>
    <asp:UpdatePanel ID="upSearchParameter" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div class="row mb-1">
                <div class="col-sm-3">
                    <asp:RadioButton ID="rdoYear" runat="server" Text="年終獎金計算機" GroupName="reportType" AutoPostBack="true" CssClass="radio-inline"
                        OnCheckedChanged="reportTypeChanged" />
                </div>
                <div class="col-sm-3">
                    <asp:RadioButton ID="rdoMonth" runat="server" Text="月獎金計算機" Checked="true" GroupName="reportType" AutoPostBack="true" CssClass="radio-inline"
                        OnCheckedChanged="reportTypeChanged" />
                </div>
            </div>
            <div class="input-group mb-1">
                <div class="input-group-append">
                    <span class="input-group-text">時段</span>
                </div>
                <asp:DropDownList ID="ddlParameterYear" runat="server" CssClass="custom-select" AutoPostBack="true"
                    OnSelectedIndexChanged="TimeFrameChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlParameterMonth" runat="server" CssClass="custom-select" AutoPostBack="true"
                    OnSelectedIndexChanged="TimeFrameChanged">
                </asp:DropDownList>
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
                <asp:Button ID="btnResetParameter" runat="server" CssClass="btn btn-danger form-control" Text="清除"
                    OnClick="btnResetParameter_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
    <asp:UpdatePanel ID="upData" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
            <asp:AsyncPostBackTrigger ControlID="btnResetParameter" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdateBonusData" />
            <asp:AsyncPostBackTrigger ControlID="ddlParameterYear" />
            <asp:AsyncPostBackTrigger ControlID="ddlParameterMonth" />
            <asp:AsyncPostBackTrigger ControlID="rdoYear" />
            <asp:AsyncPostBackTrigger ControlID="rdoMonth" />
        </Triggers>
        <ContentTemplate>
            <asp:HiddenField ID="hdnDataYear" runat="server" />
            <asp:HiddenField ID="hdnDataMonth" runat="server" />
            <asp:HiddenField ID="hdnBonusType" runat="server" />
            <div class="d-flex justify-content-between mb-2">
                <h5>
                    <asp:Label ID="lblBonusType" runat="server" Text=""></asp:Label></h5>
                <asp:Button ID="btnUpdateBonusData" runat="server" CssClass="btn btn-success" Text="更新獎金資料" Visible="false" Enabled="false"
                    OnClick="btnUpdateBonusData_Click" />
            </div>
            <div class="mb-2">
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
                        <asp:TemplateField HeaderText="銷售淨額">
                            <ItemTemplate>
                                <asp:Label ID="lblNetSaleValue" runat="server" Text='<%#Eval("銷售淨額") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="淨利">
                            <ItemTemplate>
                                <asp:Label ID="lblNetProfit" runat="server" Text='<%#Eval("淨利") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="獎金成數<br/>%" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <div class="input-group">
                                    <asp:TextBox ID="txtBonusPercent" runat="server" CssClass="form-control" Text='<%#Eval("獎金成數") %>'></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="獎金">
                            <ItemTemplate>
                                <asp:Label ID="lblBonus" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="mb-5">
                <asp:Chart ID="Chart1" runat="server" Width="400" Height="300">
                    <Series>
                        <asp:Series Name="Series1" IsValueShownAsLabel="True"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

