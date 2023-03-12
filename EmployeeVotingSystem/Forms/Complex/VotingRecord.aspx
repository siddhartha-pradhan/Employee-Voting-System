<%@ Page Title="Employee of the Month" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VotingRecord.aspx.cs" Inherits="EmployeeVotingSystem.Forms.Complex.VotingRecord" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid w-75">
        <div class="card mb-3 w-75 m-auto">
            <div class="card-header text-center bg-white">
                <h4 style="color: #976CFE;"><%: Title %> Index</h4>
            </div>
        </div>
        <div class="row ms-5">
            <div class="col-md-12 ms-5">
                <div class="form-group ms-3">
                    <div class="table-secondary ms-1">
                        <asp:GridView
                            ID="gridView"
                            Width="80%"
                            OnSelectedIndexChanged="SelectMonthRecord"
                            CssClass="table table-bordered table-striped"
                            SelectedRowStyle-BackColor="#E6E6FA"
                            GridLines="Both"
                            runat="server"
                            EmptyDataText="No records has been added.">
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:CommandField SelectText="Details" ShowSelectButton="true" ControlStyle-CssClass="GridSelector" />
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

</asp:Content>
