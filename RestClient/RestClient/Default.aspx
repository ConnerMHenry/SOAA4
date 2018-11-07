<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <%--<div class="navbar navbar-inverse navbar-fixed-top">--%>
            <%--<div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/">Crazy Mel's Shopping Emporium</a>
                </div>--%>
    <%--<li><asp:LinkButton runat="server" ID="searchLbl" OnClick="searchLbl_Click">Search</asp:LinkButton></li>
                        <li><asp:LinkButton runat="server" ID="insertLbl" OnClick="insertLbl_Click">Insert</asp:LinkButton></li>
                        <li><asp:LinkButton runat="server" ID="updateLbl" OnClick="updateLbl_Click">Update</asp:LinkButton></li>
                        <li><asp:LinkButton runat="server" ID="deleteLbl" OnClick="deleteLbl_Click">Delete</asp:LinkButton></li>--%>


    <div class="header">
        <a class="title">Crazy Melvin's Shopping Emporium</a>    
        <div class="header-buttons">
            <asp:LinkButton runat="server" ID="searchLbl" CssClass="header-link" OnClick="searchLbl_Click">Search</asp:LinkButton>
            <asp:LinkButton runat="server" ID="insertLbl" CssClass="header-link" OnClick="insertLbl_Click">Insert</asp:LinkButton>
            <asp:LinkButton runat="server" ID="updateLbl" CssClass="header-link" OnClick="updateLbl_Click">Update</asp:LinkButton>
            <asp:LinkButton runat="server" ID="deleteLbl" CssClass="header-link" OnClick="deleteLbl_Click">Delete</asp:LinkButton>
        </div>
    </div>
</asp:Content>
