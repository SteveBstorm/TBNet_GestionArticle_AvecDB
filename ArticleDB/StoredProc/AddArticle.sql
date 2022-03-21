CREATE PROCEDURE [dbo].[AddArticle]
	@name VARCHAR(50),
	@EAN13 CHAR(13),
	@price DECIMAL(18,2),
	@desc VARCHAR(250),
	@catId INT
AS
	BEGIN
		INSERT INTO Article ([Name], Price, EAN13, [Description], CategoryId) VALUES (@name, @price, @EAN13, @desc, @catId)
	END