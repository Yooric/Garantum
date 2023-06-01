﻿/*
Deployment script for BoatRentingDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BoatRentingDB"
:setvar DefaultFilePrefix "BoatRentingDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\"

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
PRINT N'Dropping Foreign Key [dbo].[FK_BoatRent_To_BoatCategory]...';


GO
ALTER TABLE [dbo].[BoatRent] DROP CONSTRAINT [FK_BoatRent_To_BoatCategory];


GO
PRINT N'Starting rebuilding table [dbo].[BoatRent]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_BoatRent] (
    [BookingNr]    INT      IDENTITY (1, 1) NOT NULL,
    [BoatNr]       INT      NOT NULL,
    [PersonNr]     BIGINT   NOT NULL,
    [BoatCategory] INT      NOT NULL,
    [RentedFrom]   DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([BookingNr] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[BoatRent])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_BoatRent] ON;
        INSERT INTO [dbo].[tmp_ms_xx_BoatRent] ([BookingNr], [BoatNr], [PersonNr], [BoatCategory], [RentedFrom])
        SELECT   [BookingNr],
                 [BoatNr],
                 [PersonNr],
                 [BoatCategory],
                 [RentedFrom]
        FROM     [dbo].[BoatRent]
        ORDER BY [BookingNr] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_BoatRent] OFF;
    END

DROP TABLE [dbo].[BoatRent];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_BoatRent]', N'BoatRent';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating Foreign Key [dbo].[FK_BoatRent_To_BoatCategory]...';


GO
ALTER TABLE [dbo].[BoatRent] WITH NOCHECK
    ADD CONSTRAINT [FK_BoatRent_To_BoatCategory] FOREIGN KEY ([BoatCategory]) REFERENCES [dbo].[BoatCategory] ([Id]);


GO
PRINT N'Refreshing Procedure [dbo].[spBoatRent_Insert]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spBoatRent_Insert]';


GO
if not exists (SELECT 1 FROM dbo.[BoatCategory])
begin
	INSERT INTO dbo.[BoatCategory] (Category, Price)
	VALUES	('Jolle', 1),
			('Båt < 40 fot', 1.2),
			('Båt >= 40 fot', 1.5);
end
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[BoatRent] WITH CHECK CHECK CONSTRAINT [FK_BoatRent_To_BoatCategory];


GO
PRINT N'Update complete.';


GO
