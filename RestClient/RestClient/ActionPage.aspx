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
        <div>
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

            <script>
                $(document).ready(function () {

                    $("#customerChk").hide();
                    $("#orderChk").hide();
                    $("#cartChk").hide();
                    $("#productChk").hide();

                    $("#addCustomerBtn").click(function () {
                        var check = $("#customerChk");
                        var toggled = check.is(":hidden");

                        if (toggled) {
                            check.show();

                            var fields = [
                                { id: "customerId", display: "Customer ID" },
                                { id: "firstName", display: "First Name" },
                                { id: "lastName", display: "Last Name" },
                                { id: "phoneNumber", display: "Phone Number", format: "(xxx-xxx-xxxx)"}];

                            makeTable("customerTable", fields);
                            customerMade = true;
                        }
                    });

                    // Add Order Table method
                    $("#addOrderBtn").click(function () {
                        var check = $("#orderChk");
                        var toggled = check.is(":hidden");

                        if (toggled) {
                            check.show();

                            var fields = [
                                { id: "orderId", display: "Order ID" },
                                { id: "custId", display: "Customer ID" },
                                { id: "poNumber", display: "P.O. Number" },
                                { id: "orderDate", display: "OrderDate", format: "MM-DD-YY"}];

                            makeTable("orderTable", fields);
                        }
                    });

                    // Add Cart Table method
                    $("#addCartBtn").click(function () {
                        var check = $("#cartChk");
                        var toggled = check.is(":hidden");

                        if (toggled) {
                            check.show();

                            var fields = [
                                { id: "orderId", display: "Order ID" },
                                { id: "prodId", display: "Product ID" },
                                { id: "qauntity", display: "Quantity" }];

                            makeTable("cartTable", fields);
                        }
                    });

                    $("#addProductBtn").click(function () {
                        var isPossible = $("#customerChk").is(":hidden") && $("#orderChk").is(":hidden") && $("#cartChk").is(":hidden");
                        var check = $("#productChk");
                        if (check.is(":hidden")) {
                            if (isPossible) {
                                check.show();

                                var fields = [
                                { id: "prodId", display: "Product ID" },
                                { id: "prodName", display: "Product Name" },
                                { id: "prodWeight", display: "Product Weight", format: "kg." }];

                                makeTable("productTable", fields);
                            }
                            else {
                                alert("ah fuck i can't believe you've done this")
                            }
                        }
                    });

                    // Method for making a table
                    function makeTable(tableName, fields) {
                        // Make table....
                         $("#table-template")
                            .clone()
                            .removeAttr("style")
                            .attr("id", tableName)
                            .appendTo($('#tables'));
                        // Fade out table so we can fade back in
                        var table = $("#" + tableName);
                        table.fadeOut(0);

                        for (field of fields) {
                            // Add column to table...
                            $("#column-template")
                                .clone()
                                .removeAttr("style")
                                .attr("id", field.id)
                                .appendTo(table);

                            $("#" + field.id + " #desc")
                                .attr("id", field.id + "Lbl")
                                .text(field.display);

                            if (field.format) {
                                $("#" + field.id + " #txt-input").after("<a style=\"padding-left: 15px;\" class=\"text-field-desc\">" + field.format+"</a>")
                            }
                               
                        }
                        table.fadeIn(200);
                    }
                });

            </script>
            <div class="dropdown">
                <button style="width:150px;" class="btn btn-default dropdown-toggle bold-boy" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">Add Table <i class="glyphicon glyphicon-plus"></i>
                </button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                    <!-- Add Customer button -->
                    <li>
                        <a id="addCustomerBtn" OnClick="return false;" class="inline bold-boy">
                            Customer <span id="customerChk" class="glyphicon glyphicon-ok"></span>
                        </a> 
                    </li>
                    <!-- Add Cart button -->
                    <li>
                        <a id="addCartBtn" OnClick="return false;" class="inline bold-boy">
                            Cart <span id="cartChk" style="display:none;"class="glyphicon glyphicon-ok"></span>
                        </a>
                    </li>
                    <!-- Add Order button -->
                    <li>
                        <a id="addOrderBtn" OnClick="return false;" class="inline bold-boy">
                            Order <span id="orderChk" style="display:none;" class="glyphicon glyphicon-ok"></span>
                        </a>
                    </li>
                    <li role="separator" class="divider"></li>
                    <!-- Add Product button -->
                    <li>
                        <a id="addProductBtn" OnClick="return false;" class="inline bold-boy">
                            Product <span id="productChk" style="display:none;" class="glyphicon glyphicon-ok"></span>
                        </a>
                    </li>
                </ul>
            </div>

            <div id="tables" style="padding: 0px 20px;">
                <!-- Table row template -->
                <div id="table-template" style="display:none;" class="row well well-lg"></div>
                <div id="column-template" class="col-md-3" style="display:none;">
                        <div class="col-md-3" style="padding: 0px;">
                            <a class="text-field-desc" id="desc"></a>
                        </div>
                        <div class="col-md-9">
                            <input type="text" id="txt-input">
                        </div>
                    </div>


                <%--<div id="table-template" class="row well-lg well-cs-bg">

                    <!-- First Column - Customer ID -->
                    <div class="col-md-3">
                        <div class="col-md-3">
                            <a class="text-field-desc">Customer ID</a>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="CustID"/>
                            <br />
                            <asp:RegularExpressionValidator ID="CustomerIDValidator"
                                    ControlToValidate="CustID" runat="server"
                                    ErrorMessage="Only Numbers allowed"
                                    CssClass="error"
                                    ValidationExpression="\d+"/>
                        </div>
                    </div>
                    <!-- Second Column - First Name -->
                    <div class="col-md-3">
                        <div class="col-md-3">
                            <a class="text-field-desc">First Name</a>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="FirstName"/>
                        </div>
                    </div>

                    <!-- Third Column - Last Name -->
                    <div class="col-md-3">
                        <div class="col-md-3">
                            <a class="text-field-desc">Last Name</a>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="LastName"/>
                        </div>
                    </div>

                    <!-- Fourth Column - Phone Number -->
                    <div class="col-md-3">
                        <div class="col-md-3">
                            <a class="text-field-desc">Phone Number</a>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="PhoneNumber" />
                            <a class="text-field-desc">xxx-xxx-xxxx</a>
                            <br />
                            <asp:RegularExpressionValidator ID="CustomerPhoneNumberValidator"
                                ControlToValidate="PhoneNumber" runat="server"
                                ErrorMessage="Invalid phone number format"
                                CssClass="error"
                                ValidationExpression="(\d{3}-\d{3}-\d{4})?"/>
                        </div>
                    </div>

                </div>--%>
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
