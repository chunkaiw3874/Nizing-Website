<%@ Page Title="" Language="C#" MasterPageFile="~/admin/master/adminMaster.master" AutoEventWireup="true" CodeFile="productSetup.aspx.cs" Inherits="admin_productSetup"
    EnableEventValidation="false" %>

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

        .col {
            padding: 0;
            display: inline-flex;
            align-items: baseline;
        }

        .bg-as-text-color {
            color: transparent;
            background-clip: text;
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
        }

        #ProductMaterial .btn,
        #ProductApplication .btn {
            border-radius: 0;
            display: flex;
            align-items: center;
            height: 50%;
        }

        .disabled {
            background-color: var(--nizing-lightgray) !important;
        }

        .spec-list.form-control {
            height: 100%;
            min-height: calc(1.5em + .75rem + 2px);
        }

        .spec-list > .item {
            padding-top: 0.5rem;
            padding-bottom: 0.5rem;
        }

        .spec-list .txt {
            border: none;
            border-bottom: solid 1px #808080;
            margin-left: 0.3rem;
            margin-right: 0.3rem;
        }

        textarea.form-control {
            min-height: 100px;
        }

        .result-table {
            height: 400px;
            border: solid 1px #cccccc;
            overflow-y: scroll;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            //ProductIDAutoComplete();
        });

        function ProductIDAutoComplete() {
            $('#<%=txtProductIDSearch.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        url: 'productSetup/GetProductID',
                        data: JSON.stringify({ ID: document.getElementById('<%=txtProductIDSearch.ClientID%>').value }),
                        dataType: 'json',
                        success: function (data) {
                            data = jQuery.parseJSON(JSON.stringify(data));
                            // Debugging the JSON object in console
                            console.log(data);
                            debugger;
                            //response(data.d);
                        }
                        ,
                        error: function (jqXHR, textStatus, errorThrown) {
                            debugger;
                            console.log("error: ", textStatus, errorThrown);
                        }
                    });
                }
            });
        }

        function confirmApprove() {
            if (confirm('確定要刪除' + $('#<%=lblProductID.ClientID%>').html() + '嗎?')) {
                return true;
            }
            else {
                return false;
            }
        }

        function RefreshUpdatePanel() {
            __doPostBack('<%= txtProductIDSearch.ClientID %>', '');
        };
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <a href="productSetupAddCategory" target="_blank" class="link">要增加新的認證、顏色、材料、規格嗎? 請按這裡~</a>
        <div class="my-4">
            <div class="product-data-fetch input-group input-group-wrapper">
                <div class="input-group-prepend">
                    <span class="input-group-text">新增/搜尋產品</span>
                </div>
                <asp:TextBox ID="txtProductIDSearch" CssClass="form-control" runat="server"
                    placeholder="不可有空白"
                    onkeyup="RefreshUpdatePanel();"
                    OnTextChanged="txtProductIDSearch_TextChanged"></asp:TextBox>
                <div class="input-group-append">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvResult" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Button ID="btnAddProduct" runat="server" Text="新增"
                                CssClass="btn btn-success"
                                Enabled="false"
                                OnClick="btnAddProduct_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <asp:UpdatePanel ID="upSearchResult" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtProductIDSearch" />
                </Triggers>
                <ContentTemplate>
                    <div class="table-responsive result-table">
                        <asp:GridView ID="gvResult" runat="server"
                            CssClass="table table-striped-blue"
                            AutoGenerateColumns="false"
                            OnSelectedIndexChanged="gvResult_SelectedIndexChanged">
                            <Columns>
                                <asp:ButtonField Text="Select" CommandName="Select" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        產品ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        產品名稱
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        產品分類
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="upSetupForm" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvResult" />
                <asp:AsyncPostBackTrigger ControlID="btnAddProduct" />
                <asp:AsyncPostBackTrigger ControlID="btnUploadData" />
                <asp:AsyncPostBackTrigger ControlID="btnClearData" />
                <asp:AsyncPostBackTrigger ControlID="btnDeleteData" />
                <asp:AsyncPostBackTrigger ControlID="btnAddSpec" />
                <asp:AsyncPostBackTrigger ControlID="btnCopyData" />
                <asp:AsyncPostBackTrigger ControlID="btnCopyToProduct" />
            </Triggers>
            <ContentTemplate>
                <div class="setup-form">
                    <div class="h1 d-flex justify-content-between">
                        產品設定
                        <div>
                            <asp:LinkButton ID="btnUploadData" runat="server" CssClass="btn text-white bg-blue" ToolTip="上傳"
                                OnClick="btnUploadData_Click">
                                <i class="fas fa-file-upload"></i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCopyData" runat="server" CssClass="btn text-white bg-success"
                                ToolTip="複製資料"
                                OnClick="btnCopyData_Click">
                                <i class="far fa-copy"></i>
                            </asp:LinkButton>
                            <asp:Button ID="btnClearData" runat="server" CssClass="btn btn-info" ToolTip="清除資料" Text="清除資料"
                                OnClick="btnClearData_Click" />
                            <asp:LinkButton ID="btnDeleteData" runat="server" CssClass="btn text-white bg-red disabled" ToolTip="刪除資料" Enabled="false"
                                OnClientClick="javascript:return confirmApprove();"
                                OnClick="btnDeleteData_Click">
                                <i class="fas fa-trash-alt"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="my-2">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Text=""></asp:Label>
                    </div>
                    <div id="divSystemMessages" runat="server" class="my-2">
                    </div>
                    <div id="ProductID" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">產品ID</span>
                        </div>
                        <asp:Label ID="lblProductID" runat="server" CssClass="form-control bg-lightgray"></asp:Label>
                    </div>

                    <div id="HotItem" class="input-group input-group-wrapper">
                        <asp:CheckBox ID="ckxHotItem" runat="server" CssClass="custom-checkbox" Text="熱銷產品" />
                    </div>
                    <div id="ProductName" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">名稱</span>
                        </div>
                        <div class="flex-column stacked-control-wrapper">
                            <asp:TextBox ID="txtProductChineseName" runat="server" CssClass="form-control" placeholder="中文"></asp:TextBox>
                            <asp:TextBox ID="txtProductEnglishName" runat="server" CssClass="form-control" placeholder="英文"></asp:TextBox>
                        </div>
                    </div>

                    <div id="ProductCategory" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">分類</span>
                        </div>
                        <asp:DropDownList ID="ddlProductCategory" runat="server" CssClass="custom-select" />
                    </div>

                    <div id="ProductDescription" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">描述</span>
                        </div>
                        <div class="flex-column stacked-control-wrapper">
                            <asp:TextBox ID="txtProductChineseDescription" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="中文"></asp:TextBox>
                            <asp:TextBox ID="txtProductEnglishDescription" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="英文"></asp:TextBox>
                        </div>
                    </div>
                    <div id="ProductAttribute" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">特性</span>
                        </div>
                        <div id="divAttributeList" runat="server" class="form-control h-auto row-cols-2 row-cols-md-3 row-cols-lg-6"></div>
                    </div>
                    <div id="ProductCertification" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">認證</span>
                        </div>
                        <div id="divCertificationList" runat="server" class="form-control h-auto row-cols-2 row-cols-md-3 row-cols-lg-6"></div>
                    </div>

                    <div id="ProductColor" class="input-group input-group-wrapper">
                        <div class="input-group-prepend">
                            <span class="input-group-text">顏色</span>
                        </div>
                        <div id="divColorList" runat="server" class="form-control h-auto bg-lightgray row-cols-2 row-cols-md-3 row-cols-lg-6"></div>
                    </div>

                    <asp:UpdatePanel ID="upProductMaterialList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddMaterial" />
                            <asp:AsyncPostBackTrigger ControlID="btnRemoveMaterial" />
                        </Triggers>
                        <ContentTemplate>
                            <div id="ProductMaterial" class="input-group input-group-wrapper">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">材料</span>
                                </div>
                                <asp:ListBox ID="lbxProductMaterialList" runat="server" SelectionMode="Multiple" CssClass="form-control" />
                                <div class="d-flex flex-column">
                                    <asp:LinkButton ID="btnAddMaterial" runat="server" CssClass="btn btn-success"
                                        OnClick="btnAddMaterial_Click">
                                <i class="fas fa-arrow-left text-white"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnRemoveMaterial" runat="server" CssClass="btn btn-danger"
                                        OnClick="btnRemoveMaterial_Click">                                
                                <i class="fas fa-arrow-right text-white"></i>
                                    </asp:LinkButton>
                                </div>
                                <asp:ListBox ID="lbxAllMaterialList" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="upProductTechnicalSpec" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>
                            <div class="product-data-fetch input-group input-group-wrapper my-4">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">規格</span>
                                </div>
                                <div id="divSpecList" runat="server" class="spec-list form-control">
                                </div>
                                <div class="input-group-append">
                                    <asp:LinkButton ID="btnShowSpecList" CssClass="btn text-white bg-green d-flex" runat="server"
                                        ToolTip="增加規格項目"
                                        OnClick="btnShowSpecList_Click">
                                         <i class="fas fa-plus my-auto"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="upProductApplication" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddApplication" />
                            <asp:AsyncPostBackTrigger ControlID="btnRemoveApplication" />
                        </Triggers>
                        <ContentTemplate>
                            <div id="ProductApplication" class="input-group input-group-wrapper">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">應用</span>
                                </div>
                                <asp:ListBox ID="lbxProductApplicationList" runat="server" SelectionMode="Multiple" CssClass="form-control" />
                                <div class="d-flex flex-column">
                                    <asp:LinkButton ID="btnAddApplication" runat="server" CssClass="btn btn-success"
                                        OnClick="btnAddApplication_Click">
                                <i class="fas fa-arrow-left text-white"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnRemoveApplication" runat="server" CssClass="btn btn-danger"
                                        OnClick="btnRemoveApplication_Click">                                
                                <i class="fas fa-arrow-right text-white"></i>
                                    </asp:LinkButton>
                                </div>
                                <asp:ListBox ID="lbxAllApplicationList" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:UpdatePanel ID="upAllTechnicalSpecList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShowSpecList" />
        </Triggers>
        <ContentTemplate>
            <div class="modal fade" id="SpecListModal" data-backdrop="static" tabindex="-1" aria-labelledby="specListContent" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <span class="modal-title h5">產品規格選單</span>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:ListBox ID="lbxAllTechnicalSpecList" runat="server" SelectionMode="Multiple"
                            CssClass="form-control border-0 h-auto"></asp:ListBox>
                        <div class="modal-footer">
                            <asp:Button ID="btnAddSpec" runat="server" Text="增加"
                                CssClass="btn btn-success"
                                OnClick="btnAddSpec_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upCopyDataModal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="modal fade" id="CopyDataModal" data-backdrop="static" tabindex="-1" aria-labelledby="specListContent" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <span class="modal-title h5">複製資料到其他產品</span>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">複製到產品ID</span>
                            </div>
                            <div class="flex-column stacked-control-wrapper">
                                <asp:TextBox ID="txtCopyToProductID" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCopyToProduct" runat="server" Text="複製"
                                CssClass="btn btn-success"
                                OnClick="btnCopyToProduct_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

