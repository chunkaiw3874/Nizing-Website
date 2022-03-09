<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master/adminMaster.master" AutoEventWireup="true" CodeFile="productSetupAddCategory.aspx.cs" Inherits="admin_productSetupAddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .link {
            color: var(--nizing-blue);
        }

            .link:hover {
                text-decoration: underline;
                color: var(--nizing-skyblue);
            }

        .input-group-wrapper {
            margin-bottom: 16px;
        }

        .input-group .stacked-control-wrapper {
            flex: 1 1 auto;
        }

    </style>
    <script type="text/javascript">
        function confirmApprove() {
            if (confirm('確定要刪除 ' + $('#<%=lblCategory.ClientID%>').html() +
                ': ' + $('#<%=lblID.ClientID%>').html() + '嗎?')) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <a href="productSetup" target="_blank" class="link">回到產品設定</a>
        <div class="product-data-fetch input-group input-group-wrapper my-4">
            <div class="input-group-prepend">
                <span class="input-group-text">新增/搜尋</span>
            </div>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="custom-select"></asp:DropDownList>
            <asp:TextBox ID="txtIDSearch" CssClass="form-control" runat="server"
                placeholder="不可有空白或特殊符號 ID Syntax:CamelCase"></asp:TextBox>
            <div class="input-group-append">
                <asp:LinkButton ID="btnFetchData" CssClass="btn text-white bg-green" runat="server"
                    OnClick="btnFetchData_Click">
                    <i class="fas fa-search"></i>
                </asp:LinkButton>
            </div>
        </div>
        <asp:UpdatePanel ID="upItemDetail" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFetchData" />
                <asp:AsyncPostBackTrigger ControlID="btnUploadData" />
                <asp:AsyncPostBackTrigger ControlID="btnClearData" />
                <asp:AsyncPostBackTrigger ControlID="btnDeleteData" />
            </Triggers>
            <ContentTemplate>
                <div class="h1 d-flex justify-content-between">
                    增加認證/顏色/材料/規格
                        <div>
                            <asp:LinkButton ID="btnUploadData" runat="server" CssClass="btn text-white bg-blue" ToolTip="上傳"
                                OnClick="btnUploadData_Click">
                                <i class="fas fa-file-upload"></i>
                            </asp:LinkButton>
                            <asp:Button ID="btnClearData" runat="server" CssClass="btn btn-info" ToolTip="清除資料" Text="清除資料"
                                OnClick="btnClearData_Click" />
                            <asp:LinkButton ID="btnDeleteData" runat="server" CssClass="btn text-white bg-red" ToolTip="刪除資料"
                                OnClientClick="javascript:return confirmApprove();"
                                OnClick="btnDeleteData_Click">
                                <i class="fas fa-trash-alt"></i>
                            </asp:LinkButton>
                        </div>
                </div>
                <div id="divSystemMessages" runat="server" class="my-2">
                </div>
                <div class="input-group input-group-wrapper">
                    <div class="input-group-prepend">
                        <span class="input-group-text">ID</span>
                    </div>
                    <asp:Label ID="lblID" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="input-group input-group-wrapper">
                    <div class="input-group-prepend">
                        <span class="input-group-text">分類</span>
                    </div>
                    <asp:Label ID="lblCategory" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div id="ProductName" class="input-group input-group-wrapper">
                    <div class="input-group-prepend">
                        <span class="input-group-text">名稱</span>
                    </div>
                    <div class="flex-column stacked-control-wrapper">
                        <asp:TextBox ID="txtChineseName" runat="server" CssClass="form-control" placeholder="中文"></asp:TextBox>
                        <asp:TextBox ID="txtEnglishName" runat="server" CssClass="form-control" placeholder="英文"></asp:TextBox>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

