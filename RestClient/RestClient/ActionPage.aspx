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
        <div id="display-panel">
            <div class="panel panel-danger">
                <div class="panel-heading row">
                    <div class="col-md-6 vcenter" style="padding: 0px;">
                        You can not have Products included with Customer, Order, or Cart tables.
                        Would you like to remove the other tables and add Product?
                    </div>
                    <div class="btn-group col-md-6 vcenter" style="padding:0px;">
                        <button class="btn btn-danger">Yes</button><button class="btn btn-danger">No</button>
                    </div>
                </div>
            </div>
        </div>

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

                    // Add Customer Table button
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

                            makeTable("customerTable", "Customer", fields);
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

                            makeTable("orderTable", "Order", fields);
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

                            makeTable("cartTable", "Cart", fields);
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

                                makeTable("productTable", "Product", fields);
                            }
                            else {
                                alert("ah fuck i can't believe you've done this")
                            }
                        }
                    });

                    // Method for making a table
                    function makeTable(tableName, title, fields) {
                        // Make table....
                         $("#table-template")
                            .clone()
                            .removeAttr("style")
                            .attr("id", tableName)
                            .appendTo($('#tables'));
                        // Fade out table so we can fade back in
                        var table = $("#" + tableName);
                        table.fadeOut(0);

                        $("#" + tableName + " #table-title")
                            .text(title);

                        for (field of fields) {
                            // Add column to table...
                            $("#column-template")
                                .clone()
                                .removeAttr("style")
                                .attr("id", field.id)
                                .appendTo($("#"+tableName+" #table-body"));

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
                <div id="table-template" style="display:none;">
                    <h2 id="table-title" style="padding: 5px;">Title</h2>
                    <div id="table-body" class="row well well-lg"></div>
                </div>
                <div id="column-template" class="col-md-3" style="display:none;">
                    <div class="col-md-3" style="padding: 0px;">
                        <a class="text-field-desc" id="desc"></a>
                    </div>
                    <div class="col-md-9">
                        <input type="text" id="txt-input">
                    </div>
                </div>

            </div>
        </div>     
    </div>
</asp:Content>
