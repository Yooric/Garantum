CREATE PROCEDURE [dbo].[spBoatRent_Update]
	@BoatNr int
AS
begin
	UPDATE dbo.[BoatRent]
	SET RentedTo = GETDATE()
	WHERE @BoatNr = BoatNr;
end