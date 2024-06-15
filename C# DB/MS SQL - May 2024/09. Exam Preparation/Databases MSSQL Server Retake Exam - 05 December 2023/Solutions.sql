--Database Basics MS SQL Regular Exam – 05 Dec 2023
--PROBLEM 01 - DDL
CREATE DATABASE [RailwaysDb]

CREATE TABLE [Passengers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [RailwayStations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[TownId] INT REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Trains]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[HourOfDeparture] VARCHAR(5) NOT NULL,
	[HourOfArrival] VARCHAR(5) NOT NULL,
	[DepartureTownId] INT REFERENCES [Towns]([Id]) NOT NULL,
	[ArrivalTownId] INT REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [TrainsRailwayStations]
(
	[TrainId] INT REFERENCES [Trains]([Id]) NOT NULL,
	[RailwayStationId] INT REFERENCES [RailwayStations]([Id]) NOT NULL,
	CONSTRAINT PK_TrainsRailwayStations PRIMARY KEY ([TrainId], [RailwayStationId])
)

CREATE TABLE [MaintenanceRecords]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DateOfMaintenance] DATE NOT NULL,
	[Details] VARCHAR(2000) NOT NULL,
	[TrainId] INT REFERENCES [Trains]([Id]) NOT NULL
)

CREATE TABLE [Tickets]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Price] DECIMAL(18, 2) NOT NULL,
	[DateOfDeparture] DATE NOT NULL,
	[DateOfArrival] DATE NOT NULL,
	[TrainId] INT REFERENCES [Trains]([Id]) NOT NULL,
	[PassengerId] INT REFERENCES [Passengers]([Id]) NOT NULL
)

--PROBLEM 02 - Insert
INSERT INTO [Trains]([HourOfDeparture], [HourOfArrival], [DepartureTownId], [ArrivalTownId])
	VALUES
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5)

INSERT INTO [TrainsRailwayStations]([TrainId], [RailwayStationId])
	VALUES
(36, 1), (36, 4),
(36, 57), (36, 31),
(36, 7), (37, 13),
(37, 54), (37, 60),
(37, 16), (38, 10),
(38, 50), (38, 52),
(38, 22), (39, 68),
(39, 3), (39, 31),
(39, 19), (40, 41),
(40, 7), (40, 52),
(40, 13)

INSERT INTO [Tickets]([Price], [DateOfDeparture], [DateOfArrival], [TrainId], [PassengerId])
	VALUES
(90.00,	'2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22)

--PROBLEM 03 - Update
UPDATE [Tickets]
	SET [DateOfDeparture] = DATEADD(WEEK, 1, [DateOfDeparture]), 
		[DateOfArrival] = DATEADD(WEEK, 1, [DateOfArrival])
	WHERE [DateOfDeparture] > '2023-10-31'

--PROBLEM 04 - Delete
DELETE FROM [Tickets]
	WHERE [TrainId] = (
		SELECT [Id]
		FROM [Trains]
		WHERE [DepartureTownId] = (SELECT [Id] FROM [Towns] WHERE [Name] = 'Berlin')
)

DELETE FROM [MaintenanceRecords]
	WHERE [TrainId] = (
		SELECT [Id] 
		FROM [Trains] 
		WHERE [DepartureTownId] = (SELECT [Id] FROM [Towns] WHERE [Name] = 'Berlin')
)

DELETE FROM [TrainsRailwayStations] 
	WHERE [TrainId] = (
		SELECT [Id] 
		FROM [Trains] 
		WHERE [DepartureTownId] = (SELECT [Id] FROM [Towns] WHERE [Name] = 'Berlin')
)

DELETE FROM [Trains] 
	WHERE [DepartureTownId] = (SELECT [Id] FROM [Towns] WHERE [Name] = 'Berlin')

--PROBLEM 05 - Tickets by Price and Date of Departure
SELECT [DateOfDeparture], [Price] AS [TicketPrice]
	FROM [Tickets]
	ORDER BY [Price], [DateOfDeparture] DESC

--PROBLEM 06 - Passengers with their Tickets
SELECT p.[Name] AS [PassengerName], t.[Price] AS [TicketPrice],
		t.[DateOfDeparture], t.[TrainId]
	FROM [Tickets] t
	JOIN [Passengers] p ON t.[PassengerId] = p.[Id]
	ORDER BY t.[Price] DESC, p.[Name]

--PROBLEM 07 - Railway Stations without Passing Trains
SELECT t.[Name] AS [Town], rs.[Name] AS [RailwayStation]
	FROM [RailwayStations] rs
	LEFT JOIN [TrainsRailwayStations] trs ON rs.[Id] = trs.[RailwayStationId]
	LEFT JOIN [Towns] t ON t.[Id] = rs.[TownId]
	WHERE trs.[RailwayStationId] IS NULL
	ORDER BY t.[Name], rs.[Name]

--PROBLEM 08 - First 3 Trains Between 08:00 and 08:59
SELECT TOP(3) tr.[Id], tr.[HourOfDeparture], ti.[Price] AS [TicketPrice], t.[Name] AS [Destination]
	FROM [Trains] tr
	JOIN [Towns] t ON tr.[ArrivalTownId] = t.[Id]
	JOIN [Tickets] ti ON ti.[TrainId] = tr.[Id]
	WHERE DATEPART(HOUR, tr.[HourOfDeparture]) = 8 AND ti.[Price] > 50
	ORDER BY ti.[Price], tr.[Id]

--PROBLEM 09 - Count of Passengers Paid More Than Average
SELECT t.[Name] AS [TownName], COUNT(tr.[ArrivalTownId]) AS [PassengerCount]
	FROM ( 
		SELECT p.[Id], ti.[TrainId]
			FROM [Tickets] ti
			JOIN [Passengers] p ON p.[Id] = ti.[PassengerId]
			GROUP BY p.[Id], ti.[TrainId]
			HAVING SUM(ti.[Price]) >= 77) AS g
	JOIN [Trains] tr ON tr.[Id] = g.[TrainId]
	JOIN [Towns] t ON t.[Id] = tr.[ArrivalTownId]
	GROUP BY t.[Name]
	ORDER BY t.[Name]

--PROBLEM 10 - Maintenance Inspection with Town and Station
SELECT mr.[TrainId], t.[Name] AS [DepartureTown], mr.[Details]
	FROM [MaintenanceRecords] mr
	JOIN [Trains] tr ON tr.[Id] = mr.[TrainId]
	JOIN [Towns] t ON t.[Id] = tr.[DepartureTownId]
	WHERE CHARINDEX('inspection', mr.[Details]) > 0
	ORDER BY mr.[TrainId]

--PROBLEM 11 - Towns with Trains
CREATE FUNCTION udf_TownsWithTrains(@Name VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT;
	SELECT @Count = COUNT(t.[Name])
		FROM [Trains] tr
		JOIN [Towns] t ON t.[Id] = tr.[DepartureTownId] OR t.[Id] = tr.[ArrivalTownId]
		WHERE t.[Name] = @Name
		GROUP BY t.[Name]

	RETURN @Count;
END

SELECT [dbo].[udf_TownsWithTrains]('Paris')

--PROBLEM 12 - Search Passengers travelling to Specific Town
CREATE PROC usp_SearchByTown(@TownName VARCHAR(50))
AS
	SELECT p.[Name], ti.[DateOfDeparture], tr.[HourOfDeparture]
		FROM [Tickets] ti
		JOIN [Trains] tr ON tr.[Id] = ti.[TrainId]
		JOIN [Passengers] p ON p.[Id] = ti.[PassengerId]
		JOIN [Towns] t ON t.[Id] = tr.[ArrivalTownId]
		WHERE t.[Name] = @TownName
		ORDER BY ti.[DateOfDeparture] DESC, p.[Name];

EXEC usp_SearchByTown 'Berlin'