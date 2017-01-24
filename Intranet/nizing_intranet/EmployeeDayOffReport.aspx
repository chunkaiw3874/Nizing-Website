<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDayOffReport.aspx.cs" Inherits="EmployeeDayOffReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="EmployeeDayOffReport">
        <div>
            <h2>員工年度請假報表</h2>
            <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
        </div>
        <br />    
        <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        <div>
            <asp:Button ID="btnReport" runat="server" Text="產生報表" OnClick="btnReport_Click" />
            <%--<asp:Button ID="btnExport" runat="server" Text="匯出Excel" OnClick="btnExport_Click" />--%>
        </div>
        <br />
        <div class="grdDoubleHeader">
            <asp:Label ID="lblScope" runat="server" Text=""></asp:Label>
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
                    <asp:TemplateField HeaderText="年度特休-天/小時">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("DAYOFF_TOTAL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="已休時數-天/小時">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("03")==DBNull.Value || Eval("03")==DBNull.Value?"":Convert.ToInt16(Math.Floor(double.Parse(Eval("03").ToString())/8)).ToString()+" / "+Eval("03") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="病假">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="事假">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="婚假">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="喪假">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="產假">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="陪產假">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="曠職">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="颱風假">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="公假">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="公休假">
                        <ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Text='<%#Eval("13") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="公傷假">
                        <ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%#Eval("14") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="產檢假">
                        <ItemTemplate>
                            <asp:Label ID="Label15" runat="server" Text='<%#Eval("15") %>'></asp:Label>
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
</asp:Content>

