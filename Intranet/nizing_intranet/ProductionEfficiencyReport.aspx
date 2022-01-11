<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductionEfficiencyReport.aspx.cs" Inherits="ProductionEfficiencyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="col-12">
            <h2>生產效率報表</h2>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="col-12">
                <asp:RadioButton ID="rdoYear" runat="server" Text="年報表" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
                <asp:RadioButton ID="rdoMonth" runat="server" Text="月報表" Checked="true" GroupName="R1" AutoPostBack="true" OnCheckedChanged="R1_CheckedChanged" />
            </div>
            <div class="col-lg-6 col-md-12">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">開始查詢時間</span>
                    </div>
                    <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="custom-select">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="custom-select">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text">結束查詢時間</span>
                    </div>
                    <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="custom-select">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="custom-select">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <asp:RadioButton ID="rdoSearchByDept" runat="server" GroupName="SearchBy" CssClass="input-group-text" Checked="true" />
                    </div>
                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="custom-select">
                        <asp:ListItem Value="all">全部部門</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group mb-3">
                    <asp:RadioButton ID="rdoSearchByEmployee" runat="server" GroupName="SearchBy" CssClass="input-group-text" />
                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="custom-select">
                        <asp:ListItem Value="all">全部人員</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="d-flex justify-content-end">
                    <asp:Button ID="btnReport" runat="server" Text="產生報表" CssClass="btn btn-success mr-3" OnClick="btnReport_Click" />
                    <asp:Button ID="btnExport" runat="server" Text="匯出Excel" CssClass="btn btn-info" OnClick="btnExport_Click" />
                </div>
                <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
            </div>
        </div>
        <br />
        <div class="col-12">
            <div style="color: red;">*當月生產情況未至當月15日前不一定出現，如需了解當月生產數量，請使用"每月產量排名表"報表</div>
            <div style="color: red;">*依現行系統制度，跨部門支援時，時數仍會算在人員隸屬的部門上，請各組長自行記錄組員跨部門支援時數，並於每月KPI表中自行調整計算正確的生產效能</div>
        </div>
        <br />
        <div class="col-12 mb-5">
            <asp:UpdatePanel ID="upReport" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnReport" />
                </Triggers>
                <ContentTemplate>
                    <div>
                        <asp:Label ID="lblRange" runat="server"></asp:Label>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="grdReport" runat="server" CssClass="grdResult">
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

