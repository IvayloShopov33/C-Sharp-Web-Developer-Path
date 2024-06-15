--Databases MSSQL Server Retake Exam - 10 Aug 2022
--PROBLEM 01 - DDL
CREATE DATABASE [NationalTouristSitesOfBulgaria]
USE [NationalTouristSitesOfBulgaria]

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Locations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50)
)

CREATE TABLE [Sites]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT REFERENCES [Locations]([Id]) NOT NULL,
	[CategoryId] INT REFERENCES [Categories]([Id]) NOT NULL,
	[Establishment] VARCHAR(15)
)

CREATE TABLE [Tourists]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL,
	CHECK ([Age] BETWEEN 0 AND 120),
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20)
)

CREATE TABLE [SitesTourists]
(
	[TouristId] INT REFERENCES [Tourists]([Id]) NOT NULL,
	[SiteId] INT REFERENCES [Sites]([Id]) NOT NULL,
	CONSTRAINT PK_SitesTourists PRIMARY KEY ([TouristId], [SiteId])
)

CREATE TABLE [BonusPrizes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes]
(
	[TouristId] INT REFERENCES [Tourists]([Id]) NOT NULL,
	[BonusPrizeId] INT REFERENCES [BonusPrizes]([Id]) NOT NULL,
	CONSTRAINT PK_TouristsBonusPrizes PRIMARY KEY ([TouristId], [BonusPrizeId])
)

--PROBLEM 02 - Insert
INSERT INTO [Tourists]([Name], [Age], [PhoneNumber], [Nationality], [Reward])
	VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO [Sites]([Name], [LocationId], [CategoryId], [Establishment])
	VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--PROBLEM 03 - Update
UPDATE [Sites]
	SET [Establishment] = '(not defined)'
	WHERE [Establishment] IS NULL

--PROBLEM 04 - Delete
DELETE
	FROM [TouristsBonusPrizes]
	WHERE [BonusPrizeId] IN (SELECT [Id] FROM [BonusPrizes] WHERE [Name] = 'Sleeping Bag')

DELETE
	FROM [BonusPrizes]
	WHERE [Name] = 'Sleeping Bag'

--PROBLEM 05 - Tourists
SELECT [Name], [Age], [PhoneNumber], [Nationality]
	FROM [Tourists]
	ORDER BY [Nationality], [Age] DESC, [Name]

--PROBLEM 06 - Sites with Their Location and Category
SELECT s.[Name], l.[Name], s.[Establishment], c.[Name]
	FROM [Sites] s
	JOIN [Locations] l ON l.[Id] = s.[LocationId]
	JOIN [Categories] c ON c.[Id] = s.[CategoryId]
	ORDER BY c.[Name] DESC, l.[Name], s.[Name]

--PROBLEM 07 - Count of Sites in Sofia Province
SELECT l.[Province], l.[Municipality], l.[Name] AS [Location], COUNT(s.[Id]) AS [CountOfSites]
	FROM [Locations] l
	JOIN [Sites] s ON s.[LocationId] = l.[Id]
	GROUP BY l.[Province], l.[Municipality], l.[Name]
	HAVING l.[Province] = 'Sofia'
	ORDER BY [CountOfSites] DESC, l.[Name]

--PROBLEM 08 - Tourist Sites established BC
SELECT s.[Name], l.[Name], l.[Municipality], l.[Province], s.[Establishment]
	FROM [Sites] s
	JOIN [Locations] l ON l.[Id] = s.[LocationId]
	WHERE LEFT(l.[Name], 1) NOT IN ('B', 'M', 'D') AND
		RIGHT(s.[Establishment], 2) = 'BC'
	ORDER BY s.[Name]

--PROBLEM 09 - Tourists with their Bonus Prizes
SELECT t.[Name], t.[Age], t.[PhoneNumber], t.[Nationality], ISNULL(bp.[Name], '(no bonus prize)')
	FROM [Tourists] t
	LEFT JOIN [TouristsBonusPrizes] tbp ON tbp.[TouristId] = t.[Id]
	LEFT JOIN [BonusPrizes] bp ON bp.[Id] = tbp.[BonusPrizeId]
	GROUP BY t.[Name], t.[Age], t.[PhoneNumber], t.[Nationality], bp.[Name]
	ORDER BY t.[Name]

--PROBLEM 10 - Tourists visiting History & Archaeology sites
SELECT SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name]) - CHARINDEX(' ', t.[Name]) + 1) AS [LastName],
		t.[Nationality], t.[Age], t.[PhoneNumber]
	FROM [Tourists] t
	JOIN [SitesTourists] st ON st.[TouristId] = t.[Id]
	JOIN [Sites] s ON s.[Id] = st.[SiteId]
	JOIN [Categories] c ON c.[Id] = s.[CategoryId]
	WHERE c.[Name] = 'History and archaeology'
	GROUP BY t.[Name], t.[Nationality], t.[Age], t.[PhoneNumber]
	ORDER BY [LastName]

--PROBLEM 11 - Tourists Count on a Tourist Site
CREATE FUNCTION udf_GetTouristsCountOnATouristSite(@Site VARCHAR(100)) 
RETURNS INT
AS
BEGIN
	DECLARE @Count INT = (SELECT COUNT(t.[Id])
							FROM [Sites] s
							JOIN [SitesTourists] st ON st.[SiteId] = s.[Id]
							JOIN [Tourists] t ON t.[Id] = st.[TouristId]
							WHERE s.[Name] = @Site
							GROUP BY s.[Name]);
	RETURN @Count;
END

SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Regional History Museum – Vratsa')
SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Samuil’s Fortress')
SELECT [dbo].[udf_GetTouristsCountOnATouristSite]('Gorge of Erma River')

--PROBLEM 12 - Annual Reward Lottery
CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
	IF ((SELECT COUNT(s.[Id])
		FROM [Tourists] t
		JOIN [SitesTourists] st ON st.[TouristId] = t.[Id]
		JOIN [Sites] s ON s.[Id] = st.[SiteId]
		WHERE t.[Name] = @TouristName
		GROUP BY t.[Name]) >= 25)
	BEGIN
		UPDATE [Tourists]
			 SET [Reward] = 'Bronze badge'
			 WHERE [Name] = @TouristName
	END

	IF ((SELECT COUNT(s.[Id])
		FROM [Tourists] t
		JOIN [SitesTourists] st ON st.[TouristId] = t.[Id]
		JOIN [Sites] s ON s.[Id] = st.[SiteId]
		WHERE t.[Name] = @TouristName
		GROUP BY t.[Name]) >= 50)
	BEGIN
		UPDATE [Tourists]
			 SET [Reward] = 'Silver badge'
			 WHERE [Name] = @TouristName
	END

	IF ((SELECT COUNT(s.[Id])
		FROM [Tourists] t
		JOIN [SitesTourists] st ON st.[TouristId] = t.[Id]
		JOIN [Sites] s ON s.[Id] = st.[SiteId]
		WHERE t.[Name] = @TouristName
		GROUP BY t.[Name]) >= 100)
	BEGIN
		UPDATE [Tourists]
			 SET [Reward] = 'Gold badge'
			 WHERE [Name] = @TouristName
	END

	SELECT [Name], [Reward]
		FROM [Tourists]
		WHERE [Name] = @TouristName

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Brus Brown'