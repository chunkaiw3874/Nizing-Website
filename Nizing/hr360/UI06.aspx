<%@ Page Title="" Language="C#" MasterPageFile="~/master/HR360_Child_user.master" AutoEventWireup="true" CodeFile="UI06.aspx.cs" Inherits="hr360_UI06" %>

<asp:Content ID="Content1" ContentPlaceHolderID="javascript_section" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="top_menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="page_content" Runat="Server">
    <div>
        <div style="margin-bottom:10px;">
            <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddlMonth" runat="server">
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
        <div style="margin-bottom:10px;">
            <asp:Button ID="btnSubmit" runat="server" Text="查詢" OnClick="btnSubmit_Click" />
        </div>
        <div style="margin-bottom:10px">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <div class="printarea">
            <div id="salary_slip" runat="server" visible="false" style="width:100%;display:flex;flex-direction:column;">
                <div style="height:100px;margin-bottom:5px;display:flex;flex-direction:row">
                    <div style="width:300px;height:100%;vertical-align:top;">
                        <div>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/hr360/image/image/nizing_logo_945x197.png" Width="300px" />
                        </div>
                    </div>
                    <div style="width:400px;height:100%;text-align:center;">
                        <div style="font-size:40px;"><b style="border-bottom:solid 1px #cccccc;">員工薪資單</b></div>
                        謝謝您這個月的辛苦及對公司的貢獻
                    </div>
                    <div style="width:300px;height:100%;text-align:right;">
                        <div>
                            <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>/<asp:Label ID="lblMonth" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblJob" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <span style="margin-right:5px;"><asp:Label ID="lblDept_Id" runat="server" Text=""></asp:Label></span>
                            <asp:Label ID="lblDept_Name" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <span style="margin-right:5px;"><asp:Label ID="lblEmp_Id" runat="server" Text=""></asp:Label></span>
                            <asp:Label ID="lblEmp_Name" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="border:solid 1px #cccccc;display:flex;flex-direction:row;">
                    <div style="width:300px;display:flex;flex-direction:column;border-right:solid 1px #cccccc;">
                        <div style="display:flex;flex-direction:row;padding:5px;border-bottom:solid 1px #cccccc;">
                            <div style="width:50%;text-align:left;">
                                津貼
                            </div>
                            <div style="width:50%;text-align:right;">
                                金額
                            </div>                    
                        </div>
                        <div style="display:flex;flex-direction:row;padding:10px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                底(本)薪
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblBaseSalary" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding:0px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                全勤獎金
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblAttendanceBonus" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding:0px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                加班費
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblOTSalary" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding-bottom:10px;">
                            <div style="width:50%;text-align:left;padding:0px 0px 0px 5px;">
                                <asp:Panel ID="pnlBonusName" runat="server"></asp:Panel>
                            </div>
                            <div style="width:50%;text-align:right;padding:0px 5px 0px 0px;">
                                <asp:Panel ID="pnlBonusAmount" runat="server"></asp:Panel>
                            </div> 
                        </div>
                    </div>
                    <div style="width:400px;display:flex;flex-direction:column;border-right:solid 1px #cccccc;">
                        <div style="display:flex;flex-direction:row;padding:5px;border-bottom:solid 1px #cccccc;">
                            <div style="width:50%;text-align:left;">
                                扣款
                            </div>
                            <div style="width:50%;text-align:right;">
                                金額
                            </div>  
                        </div>
                        <div style="display:flex;flex-direction:row;padding:10px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                請假扣款
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblDayOffDeduction" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding:0px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                健保費
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblHealthCareDeduction" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding:0px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                勞保費
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblLaborRetirementDeduction" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding:0px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                員工提繳
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblEmployeeMatch" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding:0px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                補充保費
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblHealthCareDeductionAppend" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding-bottom:10px;">
                            <div style="width:50%;text-align:left;padding:0px 0px 0px 5px;">
                                <asp:Panel ID="pnlDeductionName" runat="server"></asp:Panel>
                            </div>
                            <div style="width:50%;text-align:right;padding:0px 5px 0px 0px;">
                                <asp:Panel ID="pnlDeductionAmount" runat="server"></asp:Panel>
                            </div> 
                        </div>
                    </div>
                    <div style="width:300px;display:flex;flex-direction:column;">
                        <div style="padding:5px;border-bottom:solid 1px #cccccc;">
                            <div style="width:100%;text-align:center;">
                                出勤
                            </div>
                        </div>
                        <div style="display:flex;flex-direction:row;padding:10px 5px 0px 5px;">
                            <div style="width:50%;text-align:left;">
                                加班時數
                            </div>
                            <div style="width:50%;text-align:right;">
                                <asp:Label ID="lblOTTime" runat="server" Text=""></asp:Label>
                            </div> 
                        </div>
                        <div style="display:flex;flex-direction:row;padding-bottom:10px;">
                            <div style="width:50%;text-align:left;padding:0px 0px 0px 5px;">
                                <asp:Panel ID="pnlAttendanceName" runat="server"></asp:Panel>
                            </div>
                            <div style="width:50%;text-align:right;padding:0px 5px 0px 0px;">
                                <asp:Panel ID="pnlAttendanceTime" runat="server"></asp:Panel>
                            </div> 
                        </div>
                    </div>
                </div>
                <div style="display:flex;flex-direction:column;border:solid 1px #cccccc;border-top:0px;">
                    <div style="display:flex;flex-direction:row;border-bottom:solid 1px #cccccc;">
                        <div style="width:300px;display:flex;flex-direction:row;border-right:solid 1px #cccccc;">
                            <div style="width:40%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                公司提繳
                            </div>
                            <div style="width:60%;text-align:right;padding:5px;">
                                <asp:Label ID="lblCompanyMatch" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width:400px;display:flex;flex-direction:row;border-right:solid 1px #cccccc;">
                            <div style="width:30%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                津貼合計
                            </div>
                            <div style="width:40%;text-align:right;border-right:solid 1px #cccccc;padding:5px;">
                                <asp:Label ID="lblBonusTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:30%;text-align:center;padding:5px;">
                                課稅所得
                            </div>
                        </div>
                        <div style="width:300px;display:flex;flex-direction:row;">
                            <div style="width:40%;text-align:right;border-right:solid 1px #cccccc;padding:5px;">
                                <asp:Label ID="lblTaxable" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:30%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                應發金額
                            </div>
                            <div style="width:30%;text-align:right;padding:5px;">
                                <asp:Label ID="lblNominalSalary" runat="server" Text=""></asp:Label>
                            </div>
                        </div> 
                    </div>
                    <div style="display:flex;flex-direction:row;border-bottom:solid 1px #cccccc;">
                        <div style="width:300px;display:flex;flex-direction:row;border-right:solid 1px #cccccc;">
                            <div style="width:40%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                員工累計
                            </div>
                            <div style="width:60%;text-align:right;padding:5px;">
                                <asp:Label ID="lblEmployeeMatchTotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width:400px;display:flex;flex-direction:row;border-right:solid 1px #cccccc;">
                            <div style="width:30%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                扣款合計
                            </div>
                            <div style="width:40%;text-align:right;border-right:solid 1px #cccccc;padding:5px;">
                                <asp:Label ID="lblDeductionTotal" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="width:30%;text-align:center;padding:5px;">
                        
                            </div>
                        </div>
                        <div style="width:300px;display:flex;flex-direction:row;">
                            <div style="width:40%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">

                            </div>
                            <div style="width:30%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                實發金額
                            </div>
                            <div style="width:30%;text-align:right;padding:5px;">
                                <asp:Label ID="lblRealSalary" runat="server" Text=""></asp:Label>
                            </div>
                        </div> 
                    </div>
                    <div style="display:flex;flex-direction:row;">
                        <div style="width:300px;display:flex;flex-direction:row;border-right:solid 1px #cccccc;">
                            <div style="width:40%;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                公司累計
                            </div>
                            <div style="width:60%;text-align:right;padding:5px;">
                                <asp:Label ID="lblCompanyMatchTotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width:698px;display:flex;flex-direction:row;">
                            <div style="width:112px;text-align:center;border-right:solid 1px #cccccc;padding:5px;">
                                帳號
                            </div>
                            <div style="width:580px;text-align:center;padding:5px;">
                                <asp:Label ID="lblAccount" runat="server" Text=""></asp:Label>
                            </div>
                        </div> 
                    </div>
                </div>                          
            </div>
        </div>
    </div>
</asp:Content>

