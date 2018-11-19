CREATE TABLE [dbo].[tblOrder]
(
	[orderId] INT IDENTITY(1,1) PRIMARY KEY,
	[custId] INT NOT NULL FOREIGN KEY REFERENCES tblCustomer(custId),
	[orderDate] DATETIME NOT NULL,
	[poNumber] VARCHAR(MAX)
)
