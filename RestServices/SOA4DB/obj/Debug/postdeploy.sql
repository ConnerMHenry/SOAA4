/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO tblCustomer (firstName, lastName, phoneNumber)
VALUES	('Joe', 'Smith', '555-555-1212'),
		('Nancy', 'Jones', '555-235-4578'),
		('Henry', 'Hoover', '555-326-8456');

INSERT INTO tblProduct (prodName, price, prodWeight, inStock)
VALUES	('Grommet', 0.02, 0.005, 1),
		('Widgets', 2.35, 0.532, 1),
		('Bushings', 8.75, 5.650, 0);

INSERT INTO tblOrder (custId, orderDate, poNumber)
VALUES	(1, '2018-09-15', 'GRAP-09-2018-001'),
		(1, '2018-09-30', 'GRAP-09-2018-056'),
		(3, '2018-10-05', '');

INSERT INTO tblCart (orderId, prodId, quantity)
VALUES	(1, 1, 500),
		(1, 2, 1000),
		(2, 3, 10),
		(3, 1, 75),
		(3, 2, 15),
		(3, 3, 5);
GO
