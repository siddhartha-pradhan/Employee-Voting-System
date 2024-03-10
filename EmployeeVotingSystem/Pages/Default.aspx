<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeVotingSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
    <body>
        <div class="app-content pt-3 p-md-3 p-lg-4">
            <div class="container-xl">
                <h1 class="app-page-title">Overview</h1>
                <div class="row g-4 mb-4">
                    <div class="col-6 col-lg-3">
                        <div class="app-card app-card-stat shadow-sm h-100">
                            <div class="app-card-body p-3 p-lg-4">
                                <h4 class="stats-type mb-1">Departments</h4>
                                <div class="stats-figure">
                                    <asp:Label ID="departments" runat="server"></asp:Label>
                                </div>
                                <div class="stats-meta text-success">
                                    Conduction
                                </div>
                            </div>
                            <a class="app-card-link-mask" href="#"></a>
                        </div>
                    </div>

                    <div class="col-6 col-lg-3">
                        <div class="app-card app-card-stat shadow-sm h-100">
                            <div class="app-card-body p-3 p-lg-4">
                                <h4 class="stats-type mb-1">Employees</h4>
                                <div class="stats-figure">
                                    <asp:Label ID="employees" runat="server"></asp:Label>
                                </div>
                                <div class="stats-meta text-success">
                                    Work Rate
                                </div>
                            </div>
                            <a class="app-card-link-mask" href="#"></a>
                        </div>
                    </div>
                    <div class="col-6 col-lg-3">
                        <div class="app-card app-card-stat shadow-sm h-100">
                            <div class="app-card-body p-3 p-lg-4">
                                <h4 class="stats-type mb-1">Jobs</h4>
                                <div class="stats-figure">
                                    <asp:Label ID="jobs" runat="server"></asp:Label>
                                </div>
                                <div class="stats-meta text-success">
                                    Open
                                </div>
                            </div>
                            <a class="app-card-link-mask" href="#"></a>
                        </div>
                    </div>
                    <div class="col-6 col-lg-3">
                        <div class="app-card app-card-stat shadow-sm h-100">
                            <div class="app-card-body p-3 p-lg-4">
                                <h4 class="stats-type mb-1">Roles</h4>
                                <div class="stats-figure">
                                    <asp:Label ID="roles" runat="server"></asp:Label>
                                </div>
                                <div class="stats-meta text-success">
                                    New
                                </div>
                            </div>
                            <a class="app-card-link-mask" href="#"></a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Chart ID="dataChart" runat="server" Width="1500px" Height="400px" ToolTip="MyChart">
                        <Titles><asp:Title Text="Working Employees"></asp:Title></Titles>
                        <series>
                            <asp:Series Name="DataSeries" ChartArea="ChartAreaData">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartAreaData">
                                <AxisX Title="Departments"></AxisX>
                                <AxisY Title="Total Employees"></AxisY>
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </div>
                <div class="row">
                    <asp:Chart ID="pieChart" runat="server" Width="1500px" Height="700px" ToolTip="PieChart">
                        <Titles><asp:Title Text="Total Employee Votes"></asp:Title></Titles>
                        <series>
                            <asp:Series Name="EmployeeSeries" ChartArea="ChartAreaEmployee" ChartType="Bar">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartAreaEmployee">
                                <AxisX Title="Employee Name" Interval="1"></AxisX>
                                <AxisY Title="Votes"></AxisY>
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </div>
            </div>
        </div>
    </body>
    </html>
    <style>
        img[title$='MyOfficeChart']
            {
                height:auto !important;
                width:auto !important;
                min-width:0 !important;
            }
    </style>
</asp:Content>

