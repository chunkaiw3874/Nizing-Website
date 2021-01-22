<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SD_ReceivableReceived.aspx.cs" Inherits="SD_ReceivableReceived" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <script src="https://cdn.jsdelivr.net/npm/chart.js@2.9.4/dist/Chart.min.js" integrity="sha256-t9UJPrESBeG2ojKTIcFLPGF7nHi2vEc7f5A2KpH/UBU=" crossorigin="anonymous"></script>
    <style>
        .error-class {
            color: #FF0000; /* red */
        }

        .valid-class {
            /*color:#00CC00;*/ /* green */
        }

        .scrollbox-500 {
            height: auto;
            max-height: 500px;
        }

        .table td, .table th {
            /*border:initial;*/
        }

        th {
            background-color: #29ABE2;
            color: #FFFFFF
        }

        td {
            background-color: #ffffff;
            color: #000000;
        }

        tr:nth-child(2n) td {
            background-color: #c3e8f4;
            color: #000000;
        }

        .tbody {
            text-align: center;
        }

        tr:last-child td {
            background-color: yellow;
            text-align: center;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            loadChartData();
        };

        function loadChartData() {
            //整理使用者使用時間資料
            var sales = getSales();
            var ctx = document.getElementById('salesReceivableChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: sales,
                    datasets: [{
                        data: getReceivables(sales),
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    title: {
                        display: true,
                        text: '業務兌現金額'
                    },
                    legend: {
                        display: false
                    }
                }
            });

        }

        function getSales() {
            var sales = $('#<%=gvReport.ClientID%>').find('span[id*="Label3"]:visible');
            var salesArray = [];
            for (let i = 0; i < sales.length; i++) {
                salesArray.push(sales[i].innerText);
            }
            return salesArray.filter(function (value, index, self) { return self.indexOf(value) == index; });
        }
        function getReceivables(sales) {
            var values = [];
            var dataRows = $('#<%=gvReport.ClientID%> tr.tbody:visible');
            for (let i = 0; i < dataRows.length; i++) {
                for (let j = 0; j < sales.length; j++)
                    if ((dataRows.children('td').find('span[id*="Label3"]'))[i].innerText === sales[j]) {
                        values[j] = dataRows.children('td').find('span[id*="Label4"]')[i].innerText;
                        break;
                    }
            }

            return values;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h2>業務兌現表</h2>
            </div>
        </div>
        <div id="SearchCondition" class="form-group">
            <div class="btn-group btn-group-toggle mb-1" data-toggle="buttons">
                <label class="btn btn-outline-primary active" style="height: 38px;">
                    <asp:RadioButton ID="rdoMonth" runat="server" GroupName="ReportMethod"
                        Text="月報表" Checked="true" />
                </label>
                <label class="btn btn-outline-primary" style="height: 38px;">
                    <asp:RadioButton ID="rdoYear" runat="server" GroupName="ReportMethod"
                        Text="年報表" />
                </label>
            </div>
            <div class="input-group mb-1">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="custom-select">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="custom-select">
                </asp:DropDownList>
            </div>
            <div class="input-group mb-1">
                <asp:DropDownList ID="ddlPersonnel" runat="server" CssClass="custom-select">
                    <asp:ListItem Selected="True" Value="all">全部人員</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btnReport" runat="server" Text="產生報表"
                    CssClass="btn btn-primary"
                    OnClick="btnReport_Click" />
            </div>
        </div>
        <hr />
        <div id="OutputField">
            <asp:UpdatePanel ID="upResultView" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnReport" />
                </Triggers>
                <ContentTemplate>
                    <div id="search-result">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label ID="lblRange" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div id="ChartArea">
                            <div class="row">
                                <div id="receivableChartContainer">
                                    <canvas id="salesReceivableChart"></canvas>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gvReport" runat="server" CssClass="table table-light table-hover"
                                EmptyDataText="查詢期間無資料"
                                AutoGenerateColumns="false"
                                ShowFooter="True"
                                OnDataBound="gvReport_DataBound"
                                OnRowCreated="gvReport_RowCreated">
                                <RowStyle CssClass="tbody" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Rank") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="業務代號">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("SalesId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="業務名稱">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("SalesName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="兌現金額">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("ReceivableReceiveValue") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

