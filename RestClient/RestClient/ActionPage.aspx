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
    <div align="center">
        <asp:Button runat="server" CssClass="button-norm" Text="Go Back" />
        <asp:Button runat="server" ID="ExecuteBtn" CssClass="button-main" Text="Search" />
    </div>
</asp:Content>
