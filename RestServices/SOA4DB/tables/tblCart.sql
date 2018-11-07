CREATE TABLE [dbo].[tblCart]
(
	[orderId] INT NOT NULL FOREIGN KEY REFERENCES tblOrder(orderId),
	[prodId] INT NOT NULL FOREIGN KEY REFERENCES tblProduct(prodId),
	[quantity] INT NOT NULL,
	CONSTRAINT PK_Cart PRIMARY KEY (orderId, prodId)
)
