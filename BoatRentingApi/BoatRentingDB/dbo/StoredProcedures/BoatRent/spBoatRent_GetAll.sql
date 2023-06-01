CREATE PROCEDURE [dbo].spBoatRent_GetAll
AS
begin
	SELECT * 
	FROM dbo.[BoatRent];
end
