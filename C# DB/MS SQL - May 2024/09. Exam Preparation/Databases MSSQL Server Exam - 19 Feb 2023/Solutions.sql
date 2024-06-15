--Databases MSSQL Server Exam - 19 Feb 2023
--PROBLEM 01 - DDL
CREATE DATABASE [Boardgames]
USE [Boardgames]

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(100) NOT NULL,
	[StreetNumber] INT NOT NULL,
	[Town] VARCHAR(30) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	[ZIP] INT NOT NULL
)

CREATE TABLE [Publishers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[AddressId] INT REFERENCES [Addresses]([Id]) NOT NULL,
	[Website] NVARCHAR(40),
	[Phone] NVARCHAR(20)
	UNIQUE ([Name])
)

CREATE TABLE [PlayersRanges]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlayersMin] INT NOT NULL,
	[PlayersMax] INT NOT NULL
)

CREATE TABLE [Boardgames]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[YearPublished] INT NOT NULL,
	[Rating] DECIMAL(18, 2) NOT NULL,
	[CategoryId] INT REFERENCES [Categories]([Id]) NOT NULL,
	[PublisherId] INT REFERENCES [Publishers]([Id]) NOT NULL,
	[PlayersRangeId] INT REFERENCES [PlayersRanges]([Id]) NOT NULL
)

CREATE TABLE [Creators]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(30) NOT NULL
)

CREATE TABLE [CreatorsBoardgames]
(
	[CreatorId] INT REFERENCES [Creators]([Id]) NOT NULL,
	[BoardgameId] INT REFERENCES [Boardgames]([Id]) NOT NULL,
	CONSTRAINT PK_CreatorsBoardgames PRIMARY KEY ([CreatorId], [BoardgameId])
)

--PROBLEM 02 - Insert
INSERT INTO [Boardgames]([Name], [YearPublished], [Rating], [CategoryId], [PublisherId], [PlayersRangeId])
	VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO [Publishers]([Name], [AddressId], [Website], [Phone])
	VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

--PROBLEM 03 - Update
UPDATE [PlayersRanges]
	SET [PlayersMax] = [PlayersMax] + 1
	WHERE [PlayersMin] = 2 AND [PlayersMax] = 2

UPDATE [Boardgames]
	SET [Name] = CONCAT([Name], 'V2')
	WHERE [YearPublished] >= 2020

--PROBLEM 04 - Delete
DELETE
	FROM [CreatorsBoardgames]
	WHERE [BoardgameId] IN (SELECT b.[Id] FROM [Boardgames] b
								JOIN [Publishers] p ON p.[Id] = b.[PublisherId]
								JOIN [Addresses] a ON a.[Id] = p.[AddressId]
								WHERE LEFT(a.[Town], 1) = 'L')

DELETE
	FROM [Boardgames]
	WHERE [PublisherId] IN (SELECT p.[Id] FROM [Publishers] p
								JOIN [Addresses] a ON a.[Id] = p.[AddressId]
								WHERE LEFT(a.[Town], 1) = 'L')

DELETE 
	FROM [Publishers]
	WHERE [AddressId] IN (SELECT [Id] FROM [Addresses]
							WHERE LEFT([Town], 1) = 'L')

DELETE 
	FROM [Addresses]
	WHERE LEFT([Town], 1) = 'L'

--PROBLEM 05 - Boardgames by Year of Publication
SELECT [Name], [Rating] 
	FROM [Boardgames]
	ORDER BY [YearPublished], [Name] DESC

--PROBLEM 06 - Boardgames by Category
SELECT b.[Id], b.[Name], b.[YearPublished], c.[Name] 
	FROM [Boardgames] b
	JOIN [Categories] c ON c.[Id] = b.[CategoryId]
	WHERE c.[Name] IN ('Strategy Games', 'Wargames')
	ORDER BY b.[YearPublished] DESC

--PROBLEM 07 - Creators without Boardgames
SELECT c.[Id], CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [CreatorName], c.[Email] 
	FROM [CreatorsBoardgames] cb
	RIGHT JOIN [Creators] c ON c.[Id] = cb.[CreatorId]
	WHERE cb.[BoardgameId] IS NULL
	ORDER BY [CreatorName]

--PROBLEM 08 - First 5 Boardgames
SELECT TOP(5) b.[Name], b.[Rating], c.[Name]
	FROM [Boardgames] b
	JOIN [PlayersRanges] pr ON pr.[Id] = b.[PlayersRangeId]
	JOIN [Categories] c ON c.[Id] = b.[CategoryId]
	WHERE (b.[Rating] > 7.00 AND CHARINDEX('a', b.[Name]) != 0) OR
		(b.[Rating] > 7.50 AND pr.[PlayersMin] = 2 AND pr.[PlayersMax] = 5)
	ORDER BY b.[Name], b.[Rating] DESC

--PROBLEM 09 - Creators with Emails
SELECT CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [FullName], c.[Email], MAX(b.[Rating]) AS [Rating]
	FROM [Creators] c
	JOIN [CreatorsBoardgames] cb ON cb.[CreatorId] = c.[Id]
	JOIN [Boardgames] b ON b.[Id] = cb.[BoardgameId]
	WHERE RIGHT(c.[Email], 3) = 'com'
	GROUP BY c.[FirstName], c.[LastName], c.[Email]
	ORDER BY [FullName]

--PROBLEM 10 - Creators by Rating
SELECT c.[LastName], CEILING(AVG(b.[Rating])) AS [AverageRating], p.[Name] 
	FROM [Creators] c
	JOIN [CreatorsBoardgames] cb ON cb.[CreatorId] = c.[Id]
	JOIN [Boardgames] b ON b.[Id] = cb.[BoardgameId]
	JOIN [Publishers] p ON p.[Id] = b.[PublisherId]
	WHERE p.[Name] = 'Stonemaier Games'
	GROUP BY c.[LastName], p.[Name]
	ORDER BY AVG(b.[Rating]) DESC

--PROBLEM 11 - Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@Name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT;
	SELECT @Count = (SELECT COUNT(cb.[BoardgameId]) FROM [Creators] c
						JOIN [CreatorsBoardgames] cb ON cb.[CreatorId] = c.[Id]
						WHERE c.[FirstName] = @Name)

	RETURN @Count;
END

SELECT [dbo].[udf_CreatorWithBoardgames]('Bruno') 

--PROBLEM 12 - Search for Boardgame with Specific Category
CREATE PROC usp_SearchByCategory(@Category VARCHAR(50)) 
AS
	SELECT b.[Name], b.[YearPublished], b.[Rating], c.[Name], p.[Name], 
			CONVERT(varchar, pr.[PlayersMin]) + ' people' AS [MinPlayers],
			CONVERT(varchar, pr.[PlayersMax]) + ' people' AS [MaxPlayers]
		FROM [Boardgames] b
		JOIN [Categories] c ON c.[Id] = b.[CategoryId]
		JOIN [Publishers] p ON p.[Id] = b.[PublisherId]
		JOIN [PlayersRanges] pr ON pr.[Id] = b.[PlayersRangeId]
		WHERE c.[Name] = @Category
		ORDER BY p.[Name], b.[YearPublished] DESC

EXEC usp_SearchByCategory 'Wargames'