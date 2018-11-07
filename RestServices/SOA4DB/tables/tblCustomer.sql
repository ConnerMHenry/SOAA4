CREATE TABLE [dbo].[tblCustomer]
(
	[custId] INT IDENTITY(1,1) PRIMARY KEY,
	[firstName] TEXT NOT NULL,
	[lastName] TEXT NOT NULL,
	[phoneNumber] TEXT NOT NULL
)
