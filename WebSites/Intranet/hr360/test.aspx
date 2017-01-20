<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/HR360_Master.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="hr360_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function chooseFile() {
            $("#<%= uploadFile.ClientID%>").click();
            _doPostBack("#<%= btnUpload.UniqueID%>", "");            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="Panel1" runat="server" style="border:solid 1px #cccccc; width:400px; height:100px;">
        <asp:ListBox ID="ListBox1" runat="server" Width="400px" Height="100px"></asp:ListBox>
    </div>    
    <div class="upload">
        <input id="uploadFile" name="uploadFile" type="file" runat="server"/>
    </div>
    <div id="uploadTrigger" onclick="chooseFile();" style="display:inline-block;cursor:pointer;">
        <asp:Image ID="imgBrowse" runat="server" ImageUrl="~/hr360/image/icon/add.png" />
    </div>
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"/>    
    <asp:Button ID="btnOpen" runat="server" Text="Open" OnClick="btnOpen_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

