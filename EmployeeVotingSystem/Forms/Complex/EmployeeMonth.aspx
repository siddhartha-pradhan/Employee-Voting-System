<%@ Page Title="Employee of the Month" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeMonth.aspx.cs" Inherits="EmployeeVotingSystem.Forms.Complex.EmployeeMonth" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="card mb-3">
            <div class="card-header text-center bg-primary text-white">
                <h4><%: Title %></h4>
            </div>
            <div class="card-body">
                <div class="row justify-content-center">
                    <div class="col-md-3 d-none">
                        <asp:Label runat="server" AssociatedControlID="employeeID" CssClass="m-1"><b>Employee ID</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="employeeID" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3 ">
                        <asp:Label runat="server" AssociatedControlID="employeeName" CssClass="m-1"><b>Employee Name</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="employeeName" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="contactNumber" CssClass="m-1"><b>Contact Number</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="contactNumber" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="salary" CssClass="m-1"><b>Salary</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="salary" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="dateOfBirth" CssClass="m-1"><b>Date Of Birth</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="dateOfBirth" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="hireDate" CssClass="m-1"><b>Hire Date</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="hireDate" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="supervisorID" CssClass="m-1"><b>Supervisor</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="supervisorID" class="form-control input-sm" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <br />
            </div>
        </div>

        <div class="card mb-3">
            <div class="card-header text-center bg-primary text-white">
                <h4>Monthly Voting Details</h4>
            </div>
        </div>

        <div class="row justify-content-center ">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="table-secondary">
                        <asp:GridView
                            ID="gridView"
                            Width="100%"
                            CssClass="table table-bordered table-striped"
                            SelectedRowStyle-BackColor="#E6E6FA"
                            GridLines="Both"
                            runat="server"
                            EmptyDataText="No records has been added.">
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <style type="text/css">
        .GridHeader th {
            color: white !important;
            background-color: #593196;
            font-size: 15px;
        }

        .GridPager {
            border-top: double;
            background-color: #F2F2F2;
            margin: 50% auto;
        }

            .GridPager a {
                margin: auto 15%;
                border-radius: 20%;
                background-color: #E6E6FA;
                padding: 5px 10px 5px 10px;
                color: #000;
                text-decoration: none;
            }

                .GridPager a:hover {
                    background-color: #fff;
                    color: #000;
                    border: #593196 solid 0.1px;
                }

            .GridPager span {
                background-color: #593196;
                color: #fff;
                border-radius: 20%;
                padding: 5px 10px 5px 10px;
            }

        .GridSelector {
            border-radius: 5%;
            background-color: #13b955;
            padding: 5px 10px 5px 10px;
            color: #fff;
            text-decoration: none;
        }

        .GridSelector {
            border-radius: 5%;
            background-color: #593196;
            padding: 5px 10px 5px 10px;
            color: #fff;
            text-decoration: none;
        }

            .GridSelector:hover {
                color: #fff;
            }

        .message-alert {
            width: 100%;
            position: fixed;
            top: 0;
            z-index: 100000;
            padding: 0px;
            font-size: 15px;
        }
    </style>

</asp:Content>
