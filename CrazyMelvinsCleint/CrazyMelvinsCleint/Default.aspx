<%@ Page Title="CRAZY MELVINS SHOPPING EMPORIUM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrazyMelvinsCleint._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <body>
	    <div class = "block" align="center">
			<p class = "basetext">Here at 
				<marquee width = "270px" behavior = "alternate" truespeed = true scrolldelay = 45 class = "smallepic"> CRAZY MELVINS SHOPPING EMPORIUM </marquee> 
				we believe in selling things cheap!! That's why our User interface is 
                <marquee behavior = "alternate" truespeed = true scrolldelay = 45 class = "smallepic" width = "60px"> CHEAP!! </marquee> 
	    </div>
			<div align = "center">
				<asp:Button runat="server" CssClass="MyButton" id="SearchBtn" Text="Search" OnClick="SearchBtn_Click"/>
				<asp:Button runat="server" CssClass="MyButton" id="InsertBtn" Text="Insert some stuff" OnClick="InsertBtn_Click"/>
				<asp:Button runat="server" CssClass="MyButton" id="UpdateBtn" Text="Update some stuff" OnClick="UpdateBtn_Click"/>
				<asp:Button runat="server" CssClass="MyButton" id="DeletBtn" Text="Delete some stuff" OnClick="DeletBtn_Click"/>
			</div>
			<div style="margin:10px" align = "center">
				<button class ="MyButton" type="button" width="170px" onclick="location.href='https://www.google.ca/search?safe=off&rlz=1C5CHFA_enCA819CA819&biw=1280&bih=721&tbm=isch&sa=1&ei=glzgW9S3IsepjwTL2rxg&q=puppies&oq=puppies&gs_l=img.3..0i67k1j0j0i67k1j0j0i67k1j0l5.523.2137.0.2344.7.5.0.2.2.0.86.357.5.5.0....0...1c.1.64.img..0.7.364...35i39k1.0.d-_6GaqTDvU'"> 
					<marquee behavior = "alternate" truespeed = true scrolldelay = 45 width = "160px">GET ME OUT OF HERE</marquee>
				</button>
			</div>
    </body>
</asp:Content>
