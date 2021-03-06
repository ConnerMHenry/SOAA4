﻿/*
Deployment script for SOA4DB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SOA4DB"
:setvar DefaultFilePrefix "SOA4DB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Rename refactoring operation with key e912ddc4-f404-47bc-8bae-31960eab8e88 is skipped, element [dbo].[tblCart].[Id] (SqlSimpleColumn) will not be renamed to cartId';


GO
PRINT N'Creating [dbo].[tblCart]...';


GO
CREATE TABLE [dbo].[tblCart] (
    [orderId]  INT NOT NULL,
    [prodId]   INT NOT NULL,
    [quantity] INT NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([orderId] ASC, [prodId] ASC)
);


GO
PRINT N'Creating [dbo].[tblCustomer]...';


GO
CREATE TABLE [dbo].[tblCustomer] (
    [custId]      INT  IDENTITY (1, 1) NOT NULL,
    [firstName]   TEXT NOT NULL,
    [lastName]    TEXT NOT NULL,
    [phoneNumber] TEXT NOT NULL,
    PRIMARY KEY CLUSTERED ([custId] ASC)
);


GO
PRINT N'Creating [dbo].[tblOrder]...';


GO
CREATE TABLE [dbo].[tblOrder] (
    [orderId]   INT      IDENTITY (1, 1) NOT NULL,
    [custId]    INT      NOT NULL,
    [orderDate] DATETIME NOT NULL,
    [poNumber]  TEXT     NULL,
    PRIMARY KEY CLUSTERED ([orderId] ASC)
);


GO
PRINT N'Creating [dbo].[tblProduct]...';


GO
CREATE TABLE [dbo].[tblProduct] (
    [prodId]     INT          IDENTITY (1, 1) NOT NULL,
    [prodName]   TEXT         NOT NULL,
    [price]      DECIMAL (18) NOT NULL,
    [prodWeight] DECIMAL (18) NOT NULL,
    [inStock]    BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([prodId] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[tblCart]...';


GO
ALTER TABLE [dbo].[tblCart] WITH NOCHECK
    ADD FOREIGN KEY ([orderId]) REFERENCES [dbo].[tblOrder] ([orderId]);


GO
PRINT N'Creating unnamed constraint on [dbo].[tblCart]...';


GO
ALTER TABLE [dbo].[tblCart] WITH NOCHECK
    ADD FOREIGN KEY ([prodId]) REFERENCES [dbo].[tblProduct] ([prodId]);


GO
PRINT N'Creating unnamed constraint on [dbo].[tblOrder]...';


GO
ALTER TABLE [dbo].[tblOrder] WITH NOCHECK
    ADD FOREIGN KEY ([custId]) REFERENCES [dbo].[tblCustomer] ([custId]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e912ddc4-f404-47bc-8bae-31960eab8e88')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e912ddc4-f404-47bc-8bae-31960eab8e88')

GO

GO
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

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.tblCart'), OBJECT_ID(N'dbo.tblOrder'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO
