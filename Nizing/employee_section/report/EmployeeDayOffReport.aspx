<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDayOffReport.aspx.cs" Inherits="EmployeeDayOffReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="EmployeeDayOffReport">
        <div class="row">
            <div class="col-xs-12">
                <h2>員工年度請假報表</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-2">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-xs-2">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        <div class="col-xs-2">
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" CssClass="btn btn-success" />
        </div>
    </div>
    <div class="row form-group">
        <div class="col-xs-12">
            <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </div>
    <div class="grdDoubleHeader">
        <div class="row">
            <div class="col-xs-12">
                <asp:Label ID="lblScope" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" OnPreRender="grdReport_PreRender" OnRowCreated="grdReport_RowCreated" CssClass="grdResult">
                    <Columns>
                        <asp:TemplateField HeaderText="員工代號">
                            <ItemTemplate>
                                <asp:Label ID="Label0" runat="server" Text='<%#Eval("EMPLOYEE_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工名稱">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("EMPLOYEE_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="到職日期">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("START_DATE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已休時數-天/小時">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("03")==DBNull.Value || Eval("03")==DBNull.Value?"":Eval("03") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="未休時數-天/小時">
                            <ItemTemplate>
                                <asp:Label ID="lblUnusedDayoff" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年度特休-天/小時">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("DAYOFF_TOTAL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="病假">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="事假">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="婚假">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="喪假">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="產假">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="陪產假">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="曠職">
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="颱風假">
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公假">
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公休假">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("13") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公傷假">
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("14") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="產檢假">
                            <ItemTemplate>
                                <asp:Label ID="Label16" runat="server" Text='<%#Eval("15") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="生理假">
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("16") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="其他假">
                            <ItemTemplate>
                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("17") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="育嬰留停">
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%#Eval("18") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="安胎假">
                            <ItemTemplate>
                                <asp:Label ID="Label20" runat="server" Text='<%#Eval("19") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="非特休總計/小時">
                            <ItemTemplate>
                                <asp:Label ID="lblRowSum" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

