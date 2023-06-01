CREATE TABLE [dbo].[BoatRent]
(
	[BookingNr] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BoatNr] INT NOT NULL, 
    [PersonNr] BIGINT NOT NULL, 
    [BoatCategory] INT NOT NULL, 
    [RentedFrom] DATETIME NOT NULL, 
    [RentedTo] DATETIME NULL, 
    CONSTRAINT [FK_BoatRent_To_BoatCategory] FOREIGN KEY ([BoatCategory]) REFERENCES [BoatCategory]([Id])
)
