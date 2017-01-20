<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ED01.aspx.cs" Inherits="nizing_intranet_ED01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/jquery.orgchart.css" rel="stylesheet" />
    <script src="../Scripts/jquery.orgchart.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="chart-container">
        <ul id="ul-data" style="visibility:hidden;">
            <li>Lao Lao
                <ul>
                    <li>Bo Miao</li>
                    <li>Su Miao
                        <ul>
                            <li>Tie Hua</li>
                            <li>Hei Hei
                                <ul>
                                    <li>Pang Pang</li>
                                    <li>Xiang Xiang</li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
        <script>
            $('#chart-container').orgchart({
                'data': $('#ul-data')
            });
    </script>
</asp:Content>

