CREATE PROCEDURE [dbo].[spBoatCategory_Get]
	@Id int
AS
begin
	SELECT * 
	FROM dbo.[BoatCategory]
	WHERE Id = @Id;
end
