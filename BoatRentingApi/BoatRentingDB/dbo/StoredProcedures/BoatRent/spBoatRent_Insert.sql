CREATE PROCEDURE [dbo].[spBoatRent_Insert]
	@BoatNr int,
	@PersonNr bigint,
	@BoatCategory int
AS
begin
	INSERT INTO dbo.[BoatRent] (BoatNr, PersonNr, BoatCategory, RentedFrom)
	VALUES (@BoatNr, @PersonNr, @BoatCategory, GETDATE());
end
