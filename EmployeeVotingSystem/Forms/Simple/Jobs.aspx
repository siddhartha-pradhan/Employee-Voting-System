<%@ Page Title="Job" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="EmployeeVotingSystem.Forms.Simple.Jobs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="card mb-3">
            <div class="card-header text-center bg-white">
                <h4 style="color: #976CFE;"><%: Title %> Index</h4>
            </div>
            <div class="card-body">
                <div class="row justify-content-center">
                    <div class="col-md-3 ">
                        <asp:Label runat="server" AssociatedControlID="jobID" CssClass="m-1"><b>Job ID</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="jobID" class="form-control input-sm" placeholder="Job ID"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="jobTitle" CssClass="m-1"><b>Job Title</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="jobTitle" class="form-control input-sm" placeholder="Job Title"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="minSalary" CssClass="m-1"><b>Minimum Salary</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="minSalary" class="form-control input-sm" placeholder="Minimum Salary"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="MinSalValidation" ControlToValidate="minSalary" runat="server" ErrorMessage="Only numbers are allowed" CssClass="ms-1 text-danger" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="maxSalary" CssClass="m-1"><b>Maximum Salary</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="maxSalary" class="form-control input-sm" placeholder="Maximum Salary"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="MaxSalValidation" ControlToValidate="maxSalary" runat="server" ErrorMessage="Only numbers are allowed" CssClass="ms-1 text-danger" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <br />
                <div class="row justify-content-center offset-1 mb-2">
                    <div class="col-9 offset-1">
                        <asp:Button Text="Add" ID="addButton" OnClick="AddJob" CssClass="btn btn-primary text-white" Width="135px" runat="server" />
                        <asp:Button Text="Update" ID="updateButton" OnClick="UpdateJob" CssClass="btn btn-secondary text-dark" Width="135px" runat="server" />
                        <asp:Button Text="Delete" ID="deleteButton" OnClick="DeleteJob" CssClass="btn btn-danger" Width="135px" runat="server" />
                        <asp:Button Text="Clear" ID="clearButton" OnClick="ClearTextFields" CssClass="btn btn-warning" Width="135px" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row justify-content-center ">
            <div class="col-md-10">
                <div class="form-group">
                    <div class="table-secondary">
                        <asp:GridView
                            ID="gridView"
                            Width="100%"
                            OnSelectedIndexChanged="SelectIndexChanged"
                            CssClass="table table-bordered table-striped"
                            SelectedRowStyle-BackColor="#E6E6FA"
                            GridLines="Both"
                            AllowPaging="true"
                            PageSize="8"
                            OnPageIndexChanging="OnPaging"
                            runat="server"
                            EmptyDataText="No records has been added.">
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:CommandField SelectText="Select" ShowSelectButton="true" ControlStyle-CssClass="GridSelector" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <style type="text/css">
        .GridHeader th {
            color: white !important;
            background-color: #7322CE;
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
                margin: auto 50%;
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

    <script type="text/javascript">
        function ShowMessage(message, messageType) {
            var css;
            switch (messageType) {
                case 'Success':
                    css = 'alert-success'
                    break;
                case 'Error':
                    css = 'alert-danger'
                    break;
                case 'Warning':
                    css = 'alert-warning'
                    break;
                case 'Info':
                    css = 'alert-info'
                    break;
                default:
                    css = 'alert-success'
                    break;

            }

            $('#aleart').append('<div id="alert" style="margin:0 0.5%; -webkit-box-shadow:3px 4px 6px #999;" class="alert fade in'
                + css + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>'
                + message + '!</strong></span>' + message + '</span></div>')
        }
    </script>
</asp:Content>
