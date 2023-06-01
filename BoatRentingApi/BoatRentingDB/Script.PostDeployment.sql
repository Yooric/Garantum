if not exists (SELECT 1 FROM dbo.[BoatCategory])
begin
	INSERT INTO dbo.[BoatCategory] (Category, HourlyPrice, BasePrice)
	VALUES	('Jolle', 1, 1),
			('Båt < 40 fot', 1.3, 1.2),
			('Båt >= 40 fot', 1.4, 1.5);
end