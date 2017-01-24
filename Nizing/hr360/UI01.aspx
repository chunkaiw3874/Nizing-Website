<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI01.aspx.cs" Inherits="hr360_UI01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <div>
        <div style="width:100%;display:flex;flex-direction:row;">
            <div style="width:30%;display:flex; border:solid 1px #a9caff;flex-direction:column;">
                <div style="width:100%;display:flex;margin-bottom:10px;flex-direction:row;justify-content:center;">
                    <asp:Image ID="imgAvatar" runat="server" Width="150px" Height="150px" />
                </div>                
                <div style="width:100%;display:flex;flex-direction:row;justify-content:center;">
                    <div style="width:45%;text-align:right;margin-right:10%;margin-bottom:10px;">
                        <asp:Label ID="lblEmployee_Id" runat="server"></asp:Label>
                    </div>
                    <div style="width:45%;display:flex;">
                        <asp:Label ID="lblEmployee_Name" runat="server"></asp:Label>
                    </div>
                </div>
                <div style="width:100%;display:flex;flex-direction:row;justify-content:center;">                    
                    <div style="width:45%;text-align:right;margin-right:10%;margin-bottom:10px;">
                        <asp:Label ID="lblEmployee_Department" runat="server"></asp:Label>
                    </div>
                    <div style="width:45%;display:flex;">
                        <asp:Label ID="lblEmployee_Rank" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div style="width:65%;margin-left:5%;">
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;">
                    手機: 
                    <asp:Label ID="lblCell" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    電話: 
                    <asp:Label ID="lblTel" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    戶籍地址: 
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    通訊地址: 
                    <asp:Label ID="lblResidentialAddress" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    E-Mail: 
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div style="width:100%;display:flex;flex-direction:row;">
            <div style="width:30%;">
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    到職日期: 
                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    銀行薪轉代號: 
                    <asp:Label ID="lblBankId" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    銀行薪轉帳號: 
                    <asp:Label ID="lblBankAccount" runat="server"></asp:Label>
                </div>
            </div>
            <div style="width:65%;margin-left:5%;">
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    生日: 
                    <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    星座: 
                    <asp:Label ID="lblHoroscope" runat="server"></asp:Label>
                </div>
                <div style="width:100%;border-bottom:solid 1px #cccccc;padding-bottom:13px;padding-top:13px;">
                    Line-ID: 
                    <asp:Label ID="lblLine" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div>

        </div>
    </div>
</asp:Content>
