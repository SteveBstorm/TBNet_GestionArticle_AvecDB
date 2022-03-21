CREATE TABLE [dbo].[Article]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL UNIQUE, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [EAN13] CHAR(13) NOT NULL UNIQUE, 
    [Description] VARCHAR(250) NOT NULL, 
    [CategoryId] INT NOT NULL

    CONSTRAINT FK_Article_Category FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
