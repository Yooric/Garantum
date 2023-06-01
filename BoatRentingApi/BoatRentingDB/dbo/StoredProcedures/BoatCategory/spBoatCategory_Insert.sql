CREATE PROCEDURE [dbo].[spBoatCategory_Insert]
	@Category nvarchar(100),
	@HourlyPrice float,
	@BasePrice float
AS
begin
	INSERT INTO dbo.[BoatCategory] (Category, HourlyPrice, BasePrice)
	VALUES (@Category, @HourlyPrice, @BasePrice);
end
