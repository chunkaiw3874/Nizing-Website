<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductionProgress_Dept.aspx.cs" Inherits="nizing_intranet_ProductionProgress_Dept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ProductionProgress_Dept">
        <div class="title">
            <h2>部門未完成製令</h2>
            <br />
            <asp:ImageButton ID="btnC" runat="server" OnClick="btnC_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-C.png" />
            <asp:ImageButton ID="btnD" runat="server" OnClick="btnD_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-D.png" />
            <asp:ImageButton ID="btnE" runat="server" OnClick="btnE_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-E.png" />
            <asp:ImageButton ID="btnG" runat="server" OnClick="btnG_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-G.png" />
            <asp:ImageButton ID="btnK" runat="server" OnClick="btnK_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-K.png" />
            <asp:ImageButton ID="btnP" runat="server" OnClick="btnP_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-P.png" />
            <asp:ImageButton ID="btnS" runat="server" OnClick="btnS_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-S.png" />
            <asp:ImageButton ID="btnT" runat="server" OnClick="btnT_Click" ImageUrl="~/nizing_intranet/image/button/dept/CHIEF1-T.png" />            
        </div>
        <div>
            <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" CssClass="grdResultWithFooter" ShowFooter="true" OnDataBound="grdList_DataBound" OnRowCreated="grdList_RowCreated">
                <Columns>
                    <asp:BoundField DataField="製令編號" HeaderText="製令編號" >
                        <HeaderStyle Width="70px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="母製令編號" HeaderText="母製令編號" >
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
            </asp:GridView>
        </div>
    </div>
</asp:Content>

