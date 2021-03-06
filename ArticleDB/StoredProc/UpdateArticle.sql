CREATE PROCEDURE [dbo].[UpdateArticle]
	@name VARCHAR(50),
	@EAN13 CHAR(13),
	@price DECIMAL(18,2),
	@desc VARCHAR(250),
	@catId INT,
	@id INT
AS
BEGIN
	UPDATE Article SET [Name] = @name, EAN13 = @EAN13, Price = @price, [Description] = @desc, CategoryId = @catId
	WHERE Id = @id
END