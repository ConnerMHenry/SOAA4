CREATE TABLE [dbo].[tblProduct]
(
	[prodId] INT IDENTITY(1,1) PRIMARY KEY,
	[prodName] TEXT NOT NULL,
	[price] DECIMAL NOT NULL,
	[prodWeight] DECIMAL NOT NULL,
	[inStock] BIT NOT NULL
)
