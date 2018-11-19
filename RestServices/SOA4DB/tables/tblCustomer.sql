CREATE TABLE [dbo].[tblCustomer]
(
	[custId] INT IDENTITY(1,1) PRIMARY KEY,
	[firstName] VARCHAR(MAX) NULL,
	[lastName] VARCHAR(MAX) NOT NULL,
	[phoneNumber] VARCHAR(MAX) NOT NULL
)
