<%@ Page Title="CRAZY MELVINS SHOPPING EMPORIUM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="CrazyMelvinsCleint.SecondPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <div class = "block" align="center" style="margin-right: 30%; margin-left: 30%;">
		    <a class ="basetext"> Please generate a Purchase Order (P.O.)</a>
	    </div>
        <!-- Customer Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Customer</h1>
		    <div>
			    <a class="inputtag">custID<input type="text"/></a>
			    <a class="inputtag">firstName<input type="text"/></a>
			    <a class="inputtag">lastName<input type="text"/></a>
			    <a class="inputtag">phoneNumber<input type="text"/> xxx-xxx-xxxx</a>
		    </div>
	    </div>
        
        <!-- Product Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Product</h1>
		    <div>
			    <a class="inputtag">prodID<input type="text"/></a>
			    <a class="inputtag">productName<input type="text"/></a>
			    <a class="inputtag">price<input type="text"/></a>
			    <a class="inputtag">prodWeight<input type="text"/></a>
		    </div>
	    </div>
        
        <!-- Order Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Order</h1>
		    <div>
			    <a class="inputtag">orderID<input type="text"/></a>
			    <a class="inputtag">custID<input type="text"/></a>
			    <a class="inputtag">poNumber<input type="text"/></a>
			    <a class="inputtag">orderDate<input type="text"/> MM-DD-YY</a>
		    </div>
	    </div>	

        <!-- Cart Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Cart</h1>
		    <div>
			    <a class="inputtag">orderID<input type="text"/></a>
			    <a class="inputtag">prodID<input type="text"/></a>
			    <a class="inputtag">quantity<input type="text"/></a>
		    </div>
	    </div>	

        <!-- Buttons -->
	    <div align = "center">
		    <button onclick="location.href='Default.aspx'" type="button" >Go back</button>
		    <asp:Button runat="server" CssClass="MyButton" id="ExecuteBtn" Text="Execute" OnClick="ExecuteBtn_Click"/>
		    <button class ="MyButton" type="button" width="170px" onclick="location.href='https://www.google.ca/search?safe=off&rlz=1C5CHFA_enCA819CA819&biw=1280&bih=721&tbm=isch&sa=1&ei=glzgW9S3IsepjwTL2rxg&q=puppies&oq=puppies&gs_l=img.3..0i67k1j0j0i67k1j0j0i67k1j0l5.523.2137.0.2344.7.5.0.2.2.0.86.357.5.5.0....0...1c.1.64.img..0.7.364...35i39k1.0.d-_6GaqTDvU'"> 
				<marquee behavior = "alternate" truespeed = true scrolldelay = 45 width = "160px">GET ME OUT OF HERE</marquee>
			</button>
	    </div>
    </body>
</asp:Content>
