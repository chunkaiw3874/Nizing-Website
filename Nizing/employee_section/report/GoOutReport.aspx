<%@ Page Title="" Language="C#" MasterPageFile="~/master/report/MasterPage.master" AutoEventWireup="true" CodeFile="GoOutReport.aspx.cs" Inherits="employee_section_report_GoOutReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
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
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            loadChartData();
            $('#<%=txtSearchbox.ClientID%>').keyup(function () {
                var value = $(this).val().toLowerCase();
                $('#<%=gvGoOutData.ClientID%> tr.tbody').filter(function () {
                    $(this).toggle(($(this).text().toLowerCase().indexOf(value) > -1)
                        || ($(this).find('input[type="hidden"]').val().toLowerCase().indexOf(value) > -1))
                });
                $('#userUsageChart').remove();
                $('#userUsageChartContainer').append('<canvas id="userUsageChart"></canvas>')
                $('#locationChart').remove();
                $('#locationChartContainer').append('<canvas id="locationChart"></canvas>')
                loadChartData();
            });
        };

        //統計顯示於gvGoOutData中的資料
        function loadChartData() {
            //計算總外出時間
            var timespanArray = $('#<%=gvGoOutData.ClientID%>').find('span[id*="lblTimespan"]:visible');
            var timespan = 0;
            for (let i = 0; i < timespanArray.length; i++) {
                timespan = parseFloat(timespan) + parseFloat(timeToHours(timespanArray[i].innerText));
            }
            $('#totalOutTime').text(timespan.toFixed(2));   //顯示總外出時間
            ///////

            //整理使用者使用時間資料
            var users = getUsers();
            //console.log(getTimespans(users));
            var ctx = document.getElementById('userUsageChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: users,
                    datasets: [{
                        data: getTimespans(users),
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
                        text: '使用者外出時間'
                    },
                    legend: {
                        display: false
                    }
                }
            });

        }

        function timeToHours(time) {
            if (!(typeof (time) == 'undefined')) {
                time = time.split(/:/);
                return isNaN(parseFloat(time[0])) || isNaN(parseFloat(time[1])) ? 0 : parseFloat(time[0]) + parseFloat(time[1] / 60);
            }
            else {
                return 0;
            }
        }

        function getUsers() {
            var users = $('#<%=gvGoOutData.ClientID%>').find('span[id*="UserName"]:visible');
            var userArray = [];
            for (let i = 0; i < users.length; i++) {
                userArray.push(users[i].innerText);
            }
            return userArray.filter(function (value, index, self) { return self.indexOf(value) == index; });
        }

        function getTimespans(users) {
            var timespans = [];
            var dataRows = $('#<%=gvGoOutData.ClientID%> tr.tbody:visible');
            for (let i = 0; i < dataRows.length; i++) {
                for (let j = 0; j < users.length; j++)
                    if ((dataRows.children('td').find('span[id*="UserName"]'))[i].innerText === users[j]) {
                        timespans[j] = typeof (timespans[j]) == 'undefined' ?
                            parseFloat(timeToHours(dataRows.children('td').find('span[id*="Timespan"]')[i].innerText))
                            : parseFloat(timespans[j]) + parseFloat(timeToHours(dataRows.children('td').find('span[id*="Timespan"]')[i].innerText));
                        break;
                    }
            }
      
            return timespans;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h4>外出報表</h4>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <span class="input-group-text">查詢年月</span>
        </div>
        <asp:DropDownList ID="ddlParameterYear" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlParameterMonth" runat="server" CssClass="custom-select">
        </asp:DropDownList>
        <div class="input-group-append">
            <asp:Button ID="btnSearchGoOutData" runat="server" Text="查詢" CssClass="btn btn-success"
                OnClick="btnSearchGoOutData_Click" />
        </div>
    </div>
    <div class="input-group mb-2">
        <div class="input-group-prepend">
            <div class="input-group-text">
                <i class="fas fa-search"></i>
            </div>
        </div>
        <asp:TextBox ID="txtSearchbox" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div id="ChartArea">
        總外出時間:
        <span id="totalOutTime">0</span>
        小時
        <div class="row">
            <div id="userUsageChartContainer" class="col-sm-6">
                <canvas id="userUsageChart"></canvas>
            </div>
            <div id="locationChartContainer" class="col-sm-6">
                <canvas id="locationChart"></canvas>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="upDataview" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearchGoOutData" />
        </Triggers>
        <ContentTemplate>
            <div class="table-responsive scrollbox-500 mb-3">
                <asp:GridView ID="gvGoOutData" runat="server" AutoGenerateColumns="false" CssClass="table table-light table-hover"
                    EmptyDataText="無外出資料">
                    <RowStyle CssClass="tbody" />
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblFormId" runat="server" Text='<%#Eval("FormId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="使用者">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                <asp:HiddenField ID="hdnUserId" runat="server" Value='<%#Eval("UserId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公司別">
                            <ItemTemplate>
                                <asp:Label ID="lblUserCompany" runat="server" Text='<%#Eval("UserCompany") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblEstimatedStartTime" runat="server" Text='<%#Eval("EstimateStartTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblEstimateTimeUsed" runat="server" Text='<%#Eval("EstimateTimeUsed") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="出發時間">
                            <ItemTemplate>
                                <asp:Label ID="lblActualStartTime" runat="server" Text='<%#Eval("ActualStartTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="結束時間">
                            <ItemTemplate>
                                <asp:Label ID="lblActualEndTime" runat="server" Text='<%#Eval("ActualEndTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="使用時間">
                            <ItemTemplate>
                                <asp:Label ID="lblTimespan" runat="server" Text='<%#Eval("Timespan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="目的地">
                            <ItemTemplate>
                                <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("Destination") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="事由">
                            <ItemTemplate>
                                <asp:Label ID="lblMemo" runat="server" Text='<%#Eval("Memo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分攤公司">
                            <ItemTemplate>
                                <asp:Label ID="lblForWhichCompany" runat="server" Text='<%#Eval("ForWhichCompany") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="狀態">
                            <ItemTemplate>
                                <asp:Label ID="lblFormStatus" runat="server" Text='<%#Eval("FormStatus") %>'></asp:Label>
                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("Status") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

