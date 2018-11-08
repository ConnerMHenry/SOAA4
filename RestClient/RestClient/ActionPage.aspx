<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActionPage.aspx.cs" Inherits="RestClient.ActionPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header">
        <a class="title">Crazy Melvin's Shopping Emporium</a>    
        <div class="header-buttons">
            <a runat="server" href="ActionPage.aspx?action=Search">Search</a> 
            <a runat="server" href="ActionPage.aspx?action=Insert">Insert</a> 
            <a runat="server" href="ActionPage.aspx?action=Update">Update</a> 
            <a runat="server" href="ActionPage.aspx?action=Delete">Delete</a>
        </div>
    </div>
    <div align="center" id="InsertControls" runat="server">
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
    </div>
</asp:Content>
