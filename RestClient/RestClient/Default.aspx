<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- NavBar -->
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="#">Crazy Melvin's Shopping Emporium</a>
            </div>
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li><asp:LinkButton runat="server" ID="searchLbl" CssClass="active" OnClick="searchLbl_Click">Search</asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" ID="insertLbl" OnClick="insertLbl_Click">Insert</asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" ID="updateLbl" OnClick="updateLbl_Click">Update</asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" ID="deleteLbl" OnClick="deleteLbl_Click">Delete</asp:LinkButton></li>
                </ul>
            </div>
        </div> 
    </nav>

    <div>
       <div class="row">
           <a href="#">BUTTON1</a>
           <a href="#">BUTTON2</a>
           <a href="#">BUTTON3</a>
       </div>
       
       <div class="row background" id="changeingDiv">
           Changing content, this content changes depending on which button you press. Without refreshing the page.  
       </div>
        
    </div>

</asp:Content>
