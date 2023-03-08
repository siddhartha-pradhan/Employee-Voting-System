<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeVotingSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
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
                                    20%
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
                                    5%
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
                                <div class="stats-meta">
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
                                <div class="stats-meta">New</div>
                            </div>
                            <a class="app-card-link-mask" href="#"></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
    </html>
    
</asp:Content>
