<%@ Page Title="Department" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="EmployeeVotingSystem.Forms.Simple.Departments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="message-alert" id="alert">
    </div>

    <div class="container-fluid">
        <div class="card mb-3">
            <div class="card-header text-center bg-white">
                <h4 style="color: #976CFE;"><%: Title %> Index</h4>
            </div>
            <div class="card-body">
                <div class="row justify-content-center">
                    <div class="col-md-3 ">
                        <asp:Label runat="server" AssociatedControlID="departmentID" CssClass="m-1"><b>Department ID</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="departmentID" class="form-control input-sm" placeholder="Department ID"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="departmentName" CssClass="m-1"><b>Department Name</b></asp:Label><br />
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="departmentName" class="form-control input-sm" placeholder="Department Name"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server" AssociatedControlID="departmentFloor" CssClass="m-1"><b>Floor</b></asp:Label><br />
                        <asp:DropDownList ID="departmentFloor" CssClass="form-select input-sm" runat="server">
                            <asp:ListItem Selected="True" Value="" Text="Select a floor" />
                            <asp:ListItem Text="1" />
                            <asp:ListItem Text="2" />
                            <asp:ListItem Text="3" />
                            <asp:ListItem Text="4" />
                            <asp:ListItem Text="5" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row justify-content-center mt-3 offset-4">
                    <asp:Label ID="labelMessage" runat="server"><b></b></asp:Label><br />
                </div>
                <br />
                <div class="row justify-content-center offset-1 mb-3">
                    <div class="col-9 offset-1">
                        <asp:Button Text="Add" ID="addButton" OnClick="AddDepartment" CssClass="btn btn-primary text-white" Width="135px" runat="server" />
                        <asp:Button Text="Update" ID="updateButton" OnClick="UpdateDepartment" CssClass="btn btn-secondary text-dark" Width="135px" runat="server" />
                        <asp:Button Text="Delete" ID="deleteButton" OnClick="DeleteDepartment" CssClass="btn btn-danger" Width="135px" runat="server" />
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


