CREATE TABLE [dbo].[tblProduct]
(
	[prodId] INT IDENTITY(1,1) PRIMARY KEY,
	[prodName] VARCHAR(MAX) NOT NULL,
	[price] DECIMAL(18, 2) NOT NULL,
	[prodWeight] DECIMAL(18, 2) NOT NULL,
	[inStock] BIT NOT NULL
)
