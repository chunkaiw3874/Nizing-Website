<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="HR04.aspx.cs" Inherits="nizing_intranet_HR04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="HR04">
        <div class="row form-group">
            <div class="col-xs-12">
                <h2>員工年薪/平均底薪</h2>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-2">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-2">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                    <asp:ListItem Value="年薪">年薪</asp:ListItem>
                    <asp:ListItem Value="底薪">底薪</asp:ListItem>
                </asp:DropDownList>
            </div>            
            <div class="col-sm-2">
                <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-sm-2">
                <asp:Button ID="btnSubmit" runat="server" Text="查詢" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                <%--<asp:ImageButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ImageUrl="~/nizing_intranet/image/button/Search_Button.png" />--%>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message col-xs-12"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="lblScope" runat="server" CssClass="col-xs-12"></asp:Label>
        </div>
        <div id="search-result" class="row">
            <div class="inline-top col-xs-12">
                <asp:GridView ID="grdReport" runat="server" GridLines="None" AutoGenerateColumns="false" OnRowDataBound="grdReport_RowDataBound" OnDataBound="grdReport_DataBound" OnRowCreated="grdReport_RowCreated"
                    OnRowCommand="grdReport_RowCommand" ShowFooter="True" CssClass="grdResultWithFooter">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:LinkButton ID="lb_ID" runat="server" CommandName="Sort" CommandArgument="ID" Text="員工代號" ForeColor="White"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>                                
                                <asp:Label ID="lbl1" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工姓名">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lb_Name" runat="server" CommandName="Sort" CommandArgument="NAME" Text="員工姓名" ForeColor="White"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl2" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="員工部門">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lb_Dept" runat="server" CommandName="Sort" CommandArgument="DEPT" Text="員工部門" ForeColor="White"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="label1" runat="server" Text='<%#Eval("DEPT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="一月">
                            <ItemTemplate>
                                <asp:Label ID="lbl3" runat="server" Text='<%#Eval("01") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="二月">
                            <ItemTemplate>
                                <asp:Label ID="lbl4" runat="server" Text='<%#Eval("02") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="三月">
                            <ItemTemplate>
                                <asp:Label ID="lbl5" runat="server" Text='<%#Eval("03") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="四月">
                            <ItemTemplate>
                                <asp:Label ID="lbl6" runat="server" Text='<%#Eval("04") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="五月">
                            <ItemTemplate>
                                <asp:Label ID="lbl7" runat="server" Text='<%#Eval("05") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="六月">
                            <ItemTemplate>
                                <asp:Label ID="lbl8" runat="server" Text='<%#Eval("06") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="七月">
                            <ItemTemplate>
                                <asp:Label ID="lbl9" runat="server" Text='<%#Eval("07") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="八月">
                            <ItemTemplate>
                                <asp:Label ID="lbl10" runat="server" Text='<%#Eval("08") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="九月">
                            <ItemTemplate>
                                <asp:Label ID="lbl11" runat="server" Text='<%#Eval("09") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十月">
                            <ItemTemplate>
                                <asp:Label ID="lbl12" runat="server" Text='<%#Eval("10") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十一月">
                            <ItemTemplate>
                                <asp:Label ID="lbl13" runat="server" Text='<%#Eval("11") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="十二月">
                            <ItemTemplate>
                                <asp:Label ID="lbl14" runat="server" Text='<%#Eval("12") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年薪">
                            <ItemTemplate>
                                <asp:Label ID="lbl15" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年度平均">
                            <ItemTemplate>
                                <asp:Label ID="lbl16" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

