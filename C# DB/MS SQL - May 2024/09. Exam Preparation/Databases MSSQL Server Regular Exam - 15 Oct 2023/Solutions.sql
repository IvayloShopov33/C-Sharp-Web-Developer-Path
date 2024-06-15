--Databases MSSQL Server Regular Exam - 15 Oct 2023
--PROBLEM 01 - DDL
CREATE DATABASE [TouristAgency]
USE [TouristAgency]

CREATE TABLE [Countries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Destinations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[CountryId] INT REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Rooms]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(50) NOT NULL,
	[Price] DECIMAL(18, 2) NOT NULL,
	[BedCount] INT NOT NULL,
	CHECK ([BedCount] > 0 AND [BedCount] <= 10)
)

CREATE TABLE [Hotels]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[DestinationId] INT REFERENCES [Destinations]([Id]) NOT NULL
)

CREATE TABLE [Tourists]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Email] VARCHAR(80),
	[CountryId] INT REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Bookings]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[ArrivalDate] DateTime2 NOT NULL,
	[DepartureDate] DateTime2 NOT NULL,
	[AdultsCount] INT NOT NULL,
	CHECK ([AdultsCount] BETWEEN 1 AND 10),
	[ChildrenCount] INT NOT NULL,
	CHECK ([ChildrenCount] BETWEEN 0 AND 9),
	[TouristId] INT REFERENCES [Tourists]([Id]) NOT NULL,
	[HotelId] INT REFERENCES [Hotels]([Id]) NOT NULL,
	[RoomId] INT REFERENCES [Rooms]([Id]) NOT NULL
)

CREATE TABLE [HotelsRooms]
(
	[HotelId] INT REFERENCES [Hotels]([Id]) NOT NULL,
	[RoomId] INT REFERENCES [Rooms]([Id]) NOT NULL
	CONSTRAINT PK_HotelsRooms PRIMARY KEY ([HotelId], [RoomId])
)

--PROBLEM 02 - INSERT
INSERT INTO [Tourists]([Name], [PhoneNumber], [Email], [CountryId])
	VALUES
('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO [Bookings]([ArrivalDate], [DepartureDate], [AdultsCount], [ChildrenCount], [TouristId], [HotelId], [RoomId])
	VALUES
('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

--PROBLEM 03 - UPDATE
UPDATE [Bookings]
	SET [DepartureDate] = DATEFROMPARTS(YEAR([DepartureDate]), MONTH([DepartureDate]), DAY([DepartureDate]) + 1)
	WHERE [DepartureDate] BETWEEN '2023-12-01' AND '2023-12-31'

UPDATE [Tourists]
	SET [Email] = NULL
	WHERE CHARINDEX('MA', [Name]) > 0

--PROBLEM 04 - DELETE
DELETE
	FROM [Bookings]
	WHERE [TouristId] IN (
		SELECT [Id]
			FROM [Tourists]
			WHERE CHARINDEX('Smith', [Name]) > 0)

DELETE
	FROM [Tourists]
	WHERE CHARINDEX('Smith', [Name]) > 0

--PROBLEM 05 - Bookings by Price of Room and Arrival Date
SELECT CONVERT(varchar, b.[ArrivalDate],23) AS [ArrivalDate], b.[AdultsCount], b.[ChildrenCount]
	FROM [Bookings] b
	JOIN [Rooms] r ON r.[Id] = b.[RoomId]
	ORDER BY r.[Price] DESC, b.[ArrivalDate]

--PROBLEM 06 - Hotels by Count of Bookings
SELECT h.[Id], h.[Name]
	FROM [Hotels] h
	JOIN [HotelsRooms] hr ON hr.[HotelId] = h.[Id]
	JOIN [Rooms] r ON r.[Id] = hr.[RoomId]
	WHERE r.[Type] = 'VIP Apartment'
	GROUP BY h.[Id], h.[Name]
	ORDER BY (SELECT COUNT(ho.[Name])
				FROM [Bookings] b
				JOIN [Hotels] ho ON ho.[Id] = b.[HotelId]
				WHERE ho.[Id] = b.[HotelId] AND ho.[Name] = h.[Name]
				GROUP BY ho.[Name]) DESC

--PROBLEM 07 - Tourists without Bookings
SELECT t.[Id], t.[Name], t.[PhoneNumber] 
	FROM [Bookings] b
	RIGHT JOIN [Tourists] t ON t.[Id] = b.[TouristId]
	WHERE b.[ArrivalDate] IS NULL
	ORDER BY t.[Name]

--PROBLEM 08 - First 10 Bookings
SELECT TOP(10) h.[Name], d.[Name], c.[Name]
	FROM [Bookings] b
	JOIN [Hotels] h ON h.[Id] = b.[HotelId]
	JOIN [Destinations] d ON d.[Id] = h.[DestinationId]
	JOIN [Countries] c ON c.[Id] = d.[CountryId]
	WHERE b.[ArrivalDate] < '2023-12-31' AND h.[Id] % 2 = 1
	ORDER BY c.[Name], b.[ArrivalDate]

--PROBLEM 09 - Tourists booked in Hotels
SELECT h.[Name], r.[Price]
	FROM [Bookings] b
	JOIN [Tourists] t ON t.[Id] = b.[TouristId]
	JOIN [Hotels] h ON h.[Id] = b.[HotelId]
	JOIN [Rooms] r ON r.[Id] = b.[RoomId]
	WHERE RIGHT(t.[Name], 2) != 'EZ'
	ORDER BY r.[Price] DESC

--PROBLEM 10 - Hotels Revenue
SELECT h.[Name], (SELECT SUM(r1.[Price] * DATEDIFF(DAY, b1.[ArrivalDate], b1.[DepartureDate]))
					FROM [Bookings] b1
					JOIN [Hotels] h1 ON h1.[Id] = b1.[HotelId]
					JOIN [Rooms] r1 ON r1.[Id] = b1.[RoomId]
					GROUP BY h1.[Name]
					HAVING h.[Name] = h1.[Name]) AS [TotalRevenue]
	FROM [Bookings] b
	JOIN [Hotels] h ON h.[Id] = b.[HotelId]
	JOIN [Rooms] r ON r.[Id] = b.[RoomId]
	GROUP BY h.[Name]
	ORDER BY [TotalRevenue] DESC

--PROBLEM 11 - Rooms with Tourists
CREATE FUNCTION udf_RoomsWithTourists(@Name VARCHAR(50)) 
RETURNS INT
AS
BEGIN
	DECLARE @Count INT;
	SELECT @COUNT = SUM(b.[AdultsCount] + b.[ChildrenCount])
		FROM [Bookings] b
		JOIN [Rooms] r ON r.[Id] = b.[RoomId]
		WHERE r.[Type] = @Name
		GROUP BY r.[Type]

	RETURN @Count;
END

SELECT [dbo].[udf_RoomsWithTourists]('Double Room')

--PROBLEM 12 - Search for Tourists from a Specific Country
CREATE PROC usp_SearchByCountry(@Country NVARCHAR(50))
AS
	SELECT t.[Name], t.[PhoneNumber], t.[Email], COUNT(*) AS [CountOfBookings] 
		FROM [Bookings] b
		JOIN [Tourists] t ON t.[Id] = b.[TouristId]
		JOIN [Countries] c ON c.[Id] = t.[CountryId]
		WHERE c.[Name] = @Country
		GROUP BY t.[Name], t.[PhoneNumber], t.[Email]
		ORDER BY t.[Name], [CountOfBookings] DESC

EXEC usp_SearchByCountry 'Greece'