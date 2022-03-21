CREATE PROCEDURE [dbo].[AddCategory]
	@name VARCHAR(50)
AS
BEGIN
	INSERT INTO Category (Name) VALUES (@name)
END