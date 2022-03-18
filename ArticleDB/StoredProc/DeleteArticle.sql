CREATE PROCEDURE [dbo].[DeleteArticle]
	@id INT
AS
BEGIN
	DELETE FROM Article WHERE Id = @id
END