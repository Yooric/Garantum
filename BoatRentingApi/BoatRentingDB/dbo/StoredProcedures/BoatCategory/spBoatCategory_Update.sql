CREATE PROCEDURE [dbo].[spBoatCategory_Update]
	@Id int,
	@Category nvarchar(100),
	@HourlyPrice float,
	@BasePrice float
AS
begin
	UPDATE dbo.[BoatCategory]
	SET Category = @Category, @HourlyPrice = HourlyPrice, @BasePrice = BasePrice
	WHERE Id = @Id;
end
