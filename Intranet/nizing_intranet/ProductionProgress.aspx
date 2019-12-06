<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductionProgress.aspx.cs" Inherits="ProductionProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
    $("[src*=expand]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "image/button/collapse.png");        
    });
    $("[src*=collapse]").live("click", function () {
        $(this).attr("src", "image/button/expand.png");
        $(this).closest("tr").next().remove();
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ProductionProgress">
        <div class="title">
            <h2>生產進度</h2>
            <br />
            未生產完成的製令
        </div>
        <div>
            <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="False" DataKeyNames="製令編號" CssClass="grdResult" OnRowDataBound="grdList_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img alt="" style="cursor:pointer" src="image/button/expand.png" />
                            <asp:Panel ID="pnlDetail" runat="server" Style="display:none;">                            
                                <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="false" CssClass="grdResult" GridLines="Horizontal">
                                    <Columns>
                                        <asp:BoundField DataField="製令編號" HeaderText="製令編號">
                                            <HeaderStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="預計完工日期" HeaderText="預計完工日期">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="狀態" HeaderText="狀態">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="母/子" HeaderText="母/子">
                                            <HeaderStyle Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="生產線別" HeaderText="生產線別">
                                            <HeaderStyle Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="品號" HeaderText="品號">
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="品名" HeaderText="品名">
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="規格" HeaderText="規格">
                                            <HeaderStyle Width="170px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="預計產量" HeaderText="預計產量">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="單位" HeaderText="單位">
                                            <HeaderStyle Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="已領料量" HeaderText="已領料量">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="已生產量" HeaderText="已生產量">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="未生產量" HeaderText="未生產量">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="製令編號" HeaderText="製令編號">
                        <HeaderStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="客戶交期" HeaderText="客戶交期" >
                        <HeaderStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="客戶簡稱" HeaderText="客戶簡稱" >
                        <HeaderStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="狀態" HeaderText="狀態" >
                        <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="母/子" HeaderText="母/子" >
                        <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="生產線別" HeaderText="生產線別">
                        <HeaderStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="品號" HeaderText="品號">
                        <HeaderStyle Width="170px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="品名" HeaderText="品名">
                        <HeaderStyle Width="170px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="規格" HeaderText="規格">
                        <HeaderStyle Width="170px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="預計產量" HeaderText="預計產量" >
                        <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="單位" HeaderText="單位" >
                        <HeaderStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="已領料量" HeaderText="已領料量" >
                        <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="已生產量" HeaderText="已生產量" >
                        <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="未生產量" HeaderText="未生產量" >
                        <HeaderStyle Width="60px" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    此製令沒有子製令
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

