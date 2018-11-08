<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActionPage.aspx.cs" Inherits="RestClient.ActionPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Parse action -->
    <%
        try
        {
            string actionStr = Request.QueryString["action"];

            switch (actionStr)
            {
                case "Delete":
                    action = RestClient.Action.Delete;
                    break;

                case "Update":
                    action = RestClient.Action.Update;
                    break;

                case "Insert":
                    action = RestClient.Action.Insert;
                    break;

                default:
                    action = RestClient.Action.Search;
                    break;
            }

        }
        catch
        {
            action = RestClient.Action.Search;
        }

        SetupUI();



    %>
    <!-- NavBar -->
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Crazy Melvin's Shopping Emporium</a>
            </div>
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <!-- Search action -->
                    <% Response.Write(action == RestClient.Action.Search ? "<li class=\"active\">" : "<li>"); %>
                        <asp:LinkButton runat="server" ID="searchLbl" CssClass="active" OnClick="searchLbl_Click">Search</asp:LinkButton>
                    <%Response.Write("</li>"); %>

                    <!-- Insert action -->
                    <% Response.Write(action == RestClient.Action.Insert ? "<li class=\"active\">" : "<li>"); %>
                        <asp:LinkButton runat="server" ID="insertLbl" OnClick="insertLbl_Click">Insert</asp:LinkButton>
                    <%Response.Write("</li>"); %>

                    <!-- Update action -->
                    <% Response.Write(action == RestClient.Action.Update ? "<li class=\"active\">" : "<li>"); %>
                        <asp:LinkButton runat="server" ID="updateLbl" OnClick="updateLbl_Click">Update</asp:LinkButton>
                    <%Response.Write("</li>"); %>

                    <!-- Delete action -->
                    <% Response.Write(action == RestClient.Action.Delete ? "<li class=\"active\">" : "<li>"); %>
                        <asp:LinkButton runat="server" ID="deleteLbl" OnClick="deleteLbl_Click">Delete</asp:LinkButton>
                    <%Response.Write("</li>"); %>
                </ul>
            </div>
        </div> 
    </nav>

    <div style="padding: 0px 20px;">
        <div class="well well-lg">
            <%
                switch (action)
                {
                    case RestClient.Action.Search:
                        Response.Write("Search for: ");
                        break;

                    case RestClient.Action.Insert:
                        Response.Write("Insert: ");
                        break;

                    case RestClient.Action.Update:
                        Response.Write("Update: ");
                        break;

                    default:
                        Response.Write("Delete: ");
                        break;
                }
            %>
            <div class="dropdown">
                <button style="width:150px;" class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">Add Table <i class="glyphicon glyphicon-plus"></i>
                </button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                    <li><asp:LinkButton runat="server" ID="AddCustomerBtn" CssClass="inline" OnClick="AddCustomerBtn_Click">Customer <span class="glyphicon glyphicon-ok"></span></asp:LinkButton> </li>
                    <li><asp:LinkButton runat="server" ID="AddCartBtn" CssClass="inline" OnClick="AddCartBtn_Click">Cart <span class="glyphicon glyphicon-ok"></span></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" ID="AddOrderBtn" CssClass="inline" OnClick="AddOrderBtn_Click">Order <span class="glyphicon glyphicon-ok"></span></asp:LinkButton></li>
                    <li role="separator" class="divider"></li>
                    <li>
                        <asp:LinkButton runat="server" ID="AddProductBtn" CssClass="inline" OnClientClick="return false;" OnClick="AddProductBtn_Click">
                            Product <span runat="server" id="ProductChk" style="visibility:hidden" class="glyphicon glyphicon-ok"></span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>

        </div>
        
    </div>

    <%--<div align="center" id="InsertControls" runat="server">
        <!-- Customer Fields -->
        <asp:Label runat="server" CssClass="" Text="First Name" />
        <asp:TextBox runat="server" id="txtFirstName" CssClass="" Text="" />
        <asp:Label runat="server" CssClass="" Text="Last Name" />
        <asp:TextBox runat="server" id="txtLastName" CssClass="" Text="" />
        <asp:Label runat="server" CssClass="" Text="Phone Number" />
        <asp:TextBox runat="server" id="txtPhoneNumber" CssClass="" Text="" />
        <asp:Button runat="server" ID="btnInsertCustomer" OnClick="btnInsertCustomer_Click" CssClass="button-main" Text="Insert Customer" />
        <!-- Product Fields -->
        <asp:Label runat="server" CssClass="" Text="First Name" />
        <asp:TextBox runat="server" id="TextBox1" CssClass="" Text="" />
        <asp:Label runat="server" CssClass="" Text="Last Name" />
        <asp:TextBox runat="server" id="TextBox2" CssClass="" Text="" />
        <asp:Label runat="server" CssClass="" Text="Phone Number" />
        <asp:TextBox runat="server" id="TextBox3" CssClass="" Text="" />
        <asp:Button runat="server" ID="Button1" OnClick="btnInsertCustomer_Click" CssClass="button-main" Text="Insert Customer" />
    </div>
    <div align="center">
        <asp:Button runat="server" CssClass="button-norm" Text="Go Back" />
        <asp:Button runat="server" ID="ExecuteBtn" CssClass="button-main" Text="Search" />
    </div>--%>
</asp:Content>
