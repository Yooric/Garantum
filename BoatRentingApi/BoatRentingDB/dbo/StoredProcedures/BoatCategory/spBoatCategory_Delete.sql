CREATE PROCEDURE [dbo].[spBoatCategory_Delete]
	@Id int
AS
begin
	DELETE 
	FROM dbo.[BoatCategory]
	WHERE Id = @Id;
end