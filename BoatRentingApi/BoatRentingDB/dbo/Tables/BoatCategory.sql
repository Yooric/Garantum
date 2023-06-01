CREATE TABLE [dbo].[BoatCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Category] NVARCHAR(100) NOT NULL, 
    [HourlyPrice] FLOAT NOT NULL, 
    [BasePrice] FLOAT NOT NULL
)
