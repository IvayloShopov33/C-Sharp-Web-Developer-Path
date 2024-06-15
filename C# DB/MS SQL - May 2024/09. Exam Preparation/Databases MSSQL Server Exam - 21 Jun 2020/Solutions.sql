--Databases MSSQL Server Exam - 21 Jun 2020
--PROBLEM 01 - DDL
CREATE DATABASE [TripService]
USE [TripService]

CREATE TABLE [Cities]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[CountryCode] CHAR(2) NOT NULL
)

CREATE TABLE [Hotels]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[CityId] INT REFERENCES [Cities]([Id]) NOT NULL,
	[EmployeeCount] INT NOT NULL,
	[BaseRate] DECIMAL(18, 2)
)

CREATE TABLE [Rooms]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Price] DECIMAL(18, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	[Beds] INT NOT NULL,
	[HotelId] INT REFERENCES [Hotels]([Id]) NOT NULL
)

CREATE TABLE [Trips]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[RoomId] INT REFERENCES [Rooms]([Id]) NOT NULL,
	[BookDate] DATE NOT NULL,
	[ArrivalDate] DATE NOT NULL,
	[ReturnDate] DATE NOT NULL,
	CHECK ([BookDate] < [ArrivalDate]),
	CHECK ([ArrivalDate] < [ReturnDate]),
	[CancelDate] DATE
)

CREATE TABLE [Accounts]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(20),
	[LastName] NVARCHAR(50) NOT NULL,
	[CityId] INT REFERENCES [Cities]([Id]) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Email] VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE [AccountsTrips]
(
	[AccountId] INT REFERENCES [Accounts]([Id]) NOT NULL,
	[TripId] INT REFERENCES [Trips]([Id]) NOT NULL,
	[Luggage] INT NOT NULL,
	CHECK ([Luggage] >= 0),
	CONSTRAINT PK_AccountsTrips PRIMARY KEY ([AccountId], [TripId])
)

--PROBLEM 02 - Insert
INSERT INTO [Accounts]([FirstName], [MiddleName], [LastName], [CityId], [BirthDate], [Email])
	VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO [Trips]([RoomId], [BookDate], [ArrivalDate], [ReturnDate], [CancelDate])
	VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--PROBLEM 03 - Update
UPDATE [Rooms]
	SET [Price] = [Price] + 0.14 * [Price]
	WHERE [HotelId] IN (5, 7, 9)

--PROBLEM 04 - Delete
DELETE 
	FROM [AccountsTrips]
	WHERE [AccountId] = 47

--PROBLEM 05 - EEE-Mails
SELECT a.[FirstName], a.[LastName], FORMAT(a.[BirthDate], 'MM-dd-yyyy') AS [BirthDate], c.[Name], a.[Email]
	FROM [Accounts] a
	JOIN [Cities] c ON c.[Id] = a.[CityId]
	WHERE LEFT(a.[Email], 1) = 'e'
	ORDER BY c.[Name]

--PROBLEM 06 - City Statistics
SELECT c.[Name], COUNT(h.[Id]) 
	FROM [Cities] c
	JOIN [Hotels] h ON h.[CityId] = c.[Id]
	GROUP BY c.[Name]
	HAVING COUNT(h.[Id]) > 0
	ORDER BY COUNT(h.[Id]) DESC, c.[Name]

--PROBLEM 07 - Longest and Shortest Trips
SELECT a.[Id], CONCAT_WS(' ', a.[FirstName], a.[LastName]) AS [FullName],
		MAX(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [LongestTrip], 
		MIN(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [ShortestTrip]
	FROM [AccountsTrips] act
	JOIN [Accounts] a ON a.[Id] = act.[AccountId]
	JOIN [Trips] t ON t.[Id] = act.[TripId]
	WHERE a.[MiddleName] IS NULL AND t.[CancelDate] IS NULL
	GROUP BY a.[Id], a.[FirstName], a.[LastName]
	ORDER BY [LongestTrip] DESC, [ShortestTrip]

--PROBLEM 08 - Metropolis
SELECT TOP(10) c.[Id], c.[Name], c.[CountryCode], COUNT(*) AS [Accounts]
	FROM [Cities] c
	JOIN [Accounts] a ON a.[CityId] = c.[Id]
	GROUP BY c.[Id], c.[Name], c.[CountryCode]
	ORDER BY [Accounts] DESC

--PROBLEM 09 - Romantic Getaways
SELECT a.[Id], a.[Email], c.[Name], COUNT(*) AS [Trips]
	FROM [AccountsTrips] act
	JOIN [Accounts] a ON a.[Id] = act.[AccountId]
	JOIN [Trips] t ON t.[Id] = act.[TripId]
	JOIN [Cities] c ON c.[Id] = a.[CityId]
	JOIN [Rooms] r ON r.[Id] = t.[RoomId]
	JOIN [Hotels] h ON h.[Id] = r.[HotelId]
	WHERE h.[CityId] = c.[Id]
	GROUP BY a.[Id], a.[Email], c.[Name]
	HAVING COUNT(*) > 0
	ORDER BY [Trips] DESC, a.[Id]

--PROBLEM 10 - GDPR Violation
SELECT t.[Id], CONCAT_WS(' ', a.[FirstName], a.[MiddleName], a.[LastName]) AS [FullName],
		c.[Name] AS [From], ci.[Name],
		CASE
			WHEN t.[CancelDate] IS NULL THEN CONCAT(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate]), ' days')
			ELSE 'Canceled'
		END AS [Duration]
	FROM [AccountsTrips] act
	JOIN [Accounts] a ON a.[Id] = act.[AccountId]
	JOIN [Trips] t ON t.[Id] = act.[TripId]
	JOIN [Cities] c ON c.[Id] = a.[CityId]
	JOIN [Rooms] r ON r.[Id] = t.[RoomId]
	JOIN [Hotels] h ON h.[Id] = r.[HotelId]
	JOIN [Cities] ci ON ci.[Id] = h.[CityId]
	ORDER BY [FullName], t.[Id]

--PROBLEM 11 - Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT) 
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Output VARCHAR(MAX) = 
		(SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.[Id]) + ': ' + r.[Type] + ' (' + 
			CONVERT(VARCHAR, r.[Beds]) + ' beds) - $' + CONVERT(VARCHAR, (h.[BaseRate] + r.[Price]) * @People)
			FROM [Rooms] r
			JOIN [Hotels] h ON h.[Id] = r.[HotelId]
			WHERE r.[Beds] >= @People AND @HotelId = h.[Id] AND
				NOT EXISTS (SELECT * FROM [Trips] t WHERE t.[RoomId] = r.[Id]
														AND t.[CancelDate] IS NULL
														AND @Date BETWEEN t.[ArrivalDate] AND t.[ReturnDate])
			ORDER BY (h.[BaseRate] + r.[Price]) * @People DESC);

	IF @Output IS NULL
		RETURN 'No rooms available';

	RETURN @Output;
END

SELECT [dbo].[udf_GetAvailableRoom](112, '2011-12-17', 2)
SELECT [dbo].[udf_GetAvailableRoom](94, '2015-07-26', 3)

--PROBLEM 12 - Switch Room
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripHotelId INT = (SELECT r.[HotelId] FROM [Trips] t JOIN [Rooms] r ON r.[Id] = t.[RoomId] WHERE t.[Id] = @TripId);
	DECLARE @TargetRoomHotelId INT = (SELECT [HotelId] FROM [Rooms] WHERE [Id] = @TargetRoomId);

	IF @TripHotelId != @TargetRoomHotelId
		THROW 50001, 'Target room is in another hotel!', 1;

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM [AccountsTrips] WHERE [TripId] = @TripId);
	DECLARE @TargetRoomBeds INT = (SELECT [Beds] FROM [Rooms] WHERE [Id] = @TargetRoomId);

	IF @TripAccounts > @TargetRoomBeds
		THROW 50002, 'Not enough beds in target room!', 1;

	UPDATE [Trips]
		SET [RoomId] = @TargetRoomId
		WHERE [Id] = @TripId

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8