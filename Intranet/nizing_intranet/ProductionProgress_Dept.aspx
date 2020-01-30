<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductionProgress_Dept.aspx.cs" Inherits="nizing_intranet_ProductionProgress_Dept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ProductionProgress_Dept" class ="container">
        <div class="row">
            <div class="col-sm-12">
                <h2>部門未完成製令</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:ImageButton ID="btnC" runat="server" OnClick="btnC_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-C.png" />
                <asp:ImageButton ID="btnD" runat="server" OnClick="btnD_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-D.png" />
                <asp:ImageButton ID="btnE" runat="server" OnClick="btnE_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-E.png" />
                <asp:ImageButton ID="btnG" runat="server" OnClick="btnG_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-G.png" />
                <asp:ImageButton ID="btnK" runat="server" OnClick="btnK_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-K.png" />
                <asp:ImageButton ID="btnP" runat="server" OnClick="btnP_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-P.png" />
                <asp:ImageButton ID="btnS" runat="server" OnClick="btnS_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-S.png" />
                <asp:ImageButton ID="btnT" runat="server" OnClick="btnT_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-T.png" />            
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" CssClass="grdResultWithFooter" ShowFooter="true" OnDataBound="grdList_DataBound" OnRowCreated="grdList_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="製令編號">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("製令編號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="母製令編號">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("母製令編號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶交期">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("客戶交期")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客戶簡稱">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("客戶簡稱")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="狀態" HeaderStyle-Width="80px">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("狀態")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="母/子">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("母/子")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="生產線別">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("生產線別")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="品號">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("品號")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="品名">
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("品名")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="規格">
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("規格")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預計產量">
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("預計產量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("單位")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已領料量">
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("已領料量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="製令編號">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("已生產量")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

