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
PRINT N'Altering Procedure [dbo].[spBoatRent_Get]...';


GO
ALTER PROCEDURE [dbo].[spBoatRent_Get]
	@BoatNr int
AS
begin
	SELECT * 
	FROM dbo.BoatRent
	WHERE BoatNr = @BoatNr;
end
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
PRINT N'Update complete.';


GO
