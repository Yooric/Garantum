CREATE PROCEDURE [dbo].[spBoatRent_Get]
	@BoatNr int
AS
begin
	SELECT * 
	FROM dbo.BoatRent
	WHERE BoatNr = @BoatNr;
end
