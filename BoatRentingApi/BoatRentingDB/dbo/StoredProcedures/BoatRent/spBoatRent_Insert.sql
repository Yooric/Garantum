CREATE PROCEDURE [dbo].[spBoatRent_Insert]
	@BoatNr int,
	@PersonNr bigint,
	@BoatCategory int,
	@RentedFrom DateTime
AS
begin
	INSERT INTO dbo.[BoatRent] (BoatNr, PersonNr, BoatCategory, RentedFrom)
	VALUES (@BoatNr, @PersonNr, @BoatCategory, @RentedFrom);
end
