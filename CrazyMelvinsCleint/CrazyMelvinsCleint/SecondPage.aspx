<%@ Page Title="CRAZY MELVINS SHOPPING EMPORIUM" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="CrazyMelvinsCleint.SecondPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <div class = "block" align="center" style="margin-right: 30%; margin-left: 30%;">
		    <asp:Label runat="server" ID="DisplayLbl" CssClass ="basetext">Please generate a Purchase Order (P.O.)</asp:Label>  <input id="GeneratePoCheckbox" style="margin-top:5px" type="checkbox" runat="server"/>
	    </div>
        <!-- Customer Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Customer</h1>
		    <div>
                <table>              
                    <tr>
                        <td>
                            <!-- Customer ID Input -->
			                <asp:Label runat="server" Text="custID" CssClass="inputtag" />
                            <br /><br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="CustID" CssClass="MyInput" />
                            <br/>
                            <asp:RegularExpressionValidator ID="CustomerIDValidator"
                                ControlToValidate="CustID" runat="server"
                                ErrorMessage="Only Numbers allowed"
                                CssClass="error"
                                ValidationExpression="\d+"/>
                        </td>
                
                        <!-- First Name Input -->
                        <td>
                            <asp:Label runat="server" Text="firstName" CssClass="inputtag" />
                            <asp:TextBox runat="server" ID="FirstName" CssClass="MyInput" />
                            <br/>
                            <br/>
                        </td>

                        <!-- Last Name Input -->
                        <td>
                            <asp:Label runat="server" Text="lastName" CssClass="inputtag" />
                            <asp:TextBox runat="server" ID="LastName" CssClass="MyInput" />
                            <br/>
                            <br/>
                        </td>

                        <!-- Phone Number Input -->
                        <td>
                            <asp:Label runat="server" Text="phoneNumber" CssClass="inputtag" />
                            <br /><br />
                        </td>

                        <td>
                            <asp:TextBox runat="server" ID="PhoneNumber" CssClass="MyInput" />
                            <asp:Label runat="server" Text="xxx-xxx-xxxx" CssClass="inputtag" />  
                            <br/>
                            <asp:RegularExpressionValidator ID="CustomerPhoneNumberValidator"
                                ControlToValidate="PhoneNumber" runat="server"
                                ErrorMessage="Invalid phone number format"
                                CssClass="error"
                                ValidationExpression="(\d{3}-\d{3}-\d{4})?"/>
                        </td>
                        <td>
                            <asp:Button runat="server" CssClass="MyButton" id="Button1" Text="Execute" OnClick="ExecuteCustomer"/>
                        </td>
                    </tr>
                </table>
		    </div>
	    </div>
        
        <!-- Product Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Product</h1>
		    <div>
                <table>              
                    <tr>
                        <td>
                            <!-- Product ID Input -->
			                <asp:Label runat="server" Text="prodID" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="ProdID" CssClass="MyInput" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                ControlToValidate="ProdID" runat="server"
                                ErrorMessage="Only Numbers allowed"
                                CssClass="error"
                                ValidationExpression="\d+"/>
                        </td>                        
                        <!-- Product Name Input -->
                        <td>
                            <asp:Label runat="server" Text="productName" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="ProductName" CssClass="MyInput" />
                            <br />
                            <br />
                        </td>
                        <!-- Price Input -->
                        <td>
                            <asp:Label runat="server" Text="price" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="Price" CssClass="MyInput" />
                            <br />
                            <br />
                        </td>
                        <!-- Product Weight Input -->
                        <td>
                            <asp:Label runat="server" Text="prodWeight" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="ProdWeight" CssClass="MyInput" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:Label runat="server" Text="kg." CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:Label runat="server" Text="soldOut" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="InStock" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:Button runat="server" CssClass="MyButton" id="Button2" Text="Execute" OnClick="ExecuteProduct"/>
                        </td>
                    </tr>
                </table>
		    </div>
	    </div>
        
        <!-- Order Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Order</h1>
		    <div>
                 <table>              
                    <tr>
                        <!-- Order ID Input -->
                        <td>
			                <asp:Label runat="server" Text="orderID" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="OrderID" CssClass="MyInput" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                ControlToValidate="OrderID" runat="server"
                                ErrorMessage="Only Numbers allowed"
                                CssClass="error"
                                ValidationExpression="\d+"/>
                        </td>
                        <!-- Customer ID Input -->
                        <td>
                            <asp:Label runat="server" Text="custID" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="OrderCustID" CssClass="MyInput" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                                ControlToValidate="OrderCustID" runat="server"
                                ErrorMessage="Only Numbers allowed"
                                CssClass="error"
                                ValidationExpression="\d+"/>
                        </td>
                        <!-- PO Number Input -->
                        <td>
                            <asp:Label runat="server" Text="poNumber" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="PoNumber" CssClass="MyInput" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                                ControlToValidate="PoNumber" runat="server"
                                ErrorMessage="Only Numbers allowed"
                                CssClass="error"
                                ValidationExpression="\d+"/>
                        </td>
                        <!-- Order Date Input -->
                        <td>
                            <asp:Label runat="server" Text="orderDate" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="OrderDate" CssClass="MyInput" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                                ControlToValidate="OrderDate" runat="server"
                                ErrorMessage="Please enter a valid date"
                                CssClass="error"
                                ValidationExpression="((0?[13578]|10|12)(-|\/)((0[0-9])|([12])([0-9]?)|(3[01]?))(-|\/)((\d{4})|(\d{2}))|(0?[2469]|11)(-|\/)((0[0-9])|([12])([0-9]?)|(3[0]?))(-|\/)((\d{4}|\d{2})))?"/>
                        </td>
                        <td>
                            <asp:Label runat="server" Text="MM-DD-YY" CssClass="inputtag" />
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:Button runat="server" CssClass="MyButton" id="Button3" Text="Execute" OnClick="ExecuteOrder"/>
                        </td>
                    </tr>
                </table>
		    </div>
	    </div>	

        <!-- Cart Block -->
	    <div class = "block" style="padding-top: 0px;">
		    <h1 style="font-size: 20px; margin-bottom: 40px;" class="inputtag" align="center">Cart</h1>
		    <div>
                <!-- Order ID Input -->
			    <asp:Label runat="server" Text="orderID" CssClass="inputtag" />
                <asp:TextBox runat="server" ID="CartOrderID" CssClass="MyInput" />

                <!-- Product ID Input -->
			    <asp:Label runat="server" Text="prodID" CssClass="inputtag" />
                <asp:TextBox runat="server" ID="CartProductID" CssClass="MyInput" />

                <!-- Quantity Input -->
                <asp:Label runat="server" Text="quantity" CssClass="inputtag" />
                <asp:TextBox runat="server" ID="Quantity" CssClass="MyInput" />
                <asp:Button runat="server" CssClass="MyButton" id="Button4" Text="Execute" OnClick="ExecuteCart"/>
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