--Databases MSSQL Server Retake Exam - 04 Apr 2023
--PROBLEM 01 - DDL
CREATE DATABASE [Accounting]
USE [Accounting]

CREATE TABLE [Countries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(20) NOT NULL,
	[StreetNumber] INT,
	[PostCode] INT NOT NULL,
	[City] VARCHAR(25) NOT NULL,
	[CountryId] INT REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Vendors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[NumberVAT] NVARCHAR(15) NOT NULL,
	[AddressId] INT REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [Clients]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[NumberVAT] NVARCHAR(15) NOT NULL,
	[AddressId] INT REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Products]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	[Price] DECIMAL(18, 2) NOT NULL,
	[CategoryId] INT REFERENCES [Categories]([Id]) NOT NULL,
	[VendorId] INT REFERENCES [Vendors]([Id]) NOT NULL
)

CREATE TABLE [Invoices]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Number] INT NOT NULL,
	[IssueDate] DATETIME2 NOT NULL,
	[DueDate] DATETIME2 NOT NULL,
	[Amount] DECIMAL(18, 2) NOT NULL,
	[Currency] VARCHAR(5) NOT NULL,
	[ClientId] INT REFERENCES [Clients]([Id]) NOT NULL
)

CREATE TABLE [ProductsClients]
(
	[ProductId] INT REFERENCES [Products]([Id]) NOT NULL,
	[ClientId] INT REFERENCES [Clients]([Id]) NOT NULL,
	CONSTRAINT PK_ProductsClients PRIMARY KEY ([ProductId], [ClientId])
)

--PROBLEM 02 - Insert
INSERT INTO [Products]([Name], [Price], [CategoryId], [VendorId])
	VALUES
('SCANIA Oil Filter XD01', 78.69, 1, 1),
('MAN Air Filter XD01', 97.38, 1, 5),
('DAF Light Bulb 05FG87', 55.00, 2, 13),
('ADR Shoes 47-47.5', 49.85, 3, 5),
('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO [Invoices]([Number], [IssueDate], [DueDate], [Amount], [Currency], [ClientId])
	VALUES
(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

--PROBLEM 03 - Update
UPDATE [Invoices]
	SET [DueDate] = '2023-04-01'
	WHERE YEAR([IssueDate]) = 2022 AND MONTH([IssueDate]) = 11

UPDATE [Clients]
	SET [AddressId] = 3
	WHERE CHARINDEX('CO', [Name]) != 0

--PROBLEM 04 - Delete
DELETE 
	FROM [Invoices]
	WHERE [ClientId] IN (SELECT [Id] FROM [Clients] WHERE LEFT([NumberVAT], 2) = 'IT')

DELETE 
	FROM [ProductsClients]
	WHERE [ClientId] IN (SELECT [Id] FROM [Clients] WHERE LEFT([NumberVAT], 2) = 'IT')

DELETE 
	FROM [Clients]
	WHERE LEFT([NumberVAT], 2) = 'IT'

--PROBLEM 05 - Invoices by Amount and Date
SELECT [Number], [Currency]
	FROM [Invoices]
	ORDER BY [Amount] DESC, [DueDate]

--PROBLEM 06 - Products by Category
SELECT p.[Id], p.[Name], p.[Price], c.[Name]
	FROM [Products] p
	JOIN [Categories] c ON c.[Id] = p.[CategoryId]
	WHERE c.[Name] IN ('ADR', 'Others')
	ORDER BY p.[Price] DESC

--PROBLEM 07 - Clients without Products
SELECT c.[Id], c.[Name], 
		a.[StreetName] + ' ' + CONCAT_WS(', ', a.[StreetNumber], a.[City], a.[PostCode], co.[Name]) AS [Address]
	FROM [ProductsClients] pc
	RIGHT JOIN [Clients] c ON c.[Id] = pc.[ClientId]
	JOIN [Addresses] a ON c.[AddressId] = a.[Id]
	JOIN [Countries] co ON co.[Id] = a.[CountryId]
	WHERE pc.[ProductId] IS NULL
	ORDER BY c.[Name]

--PROBLEM 08 - First 7 Invoices
SELECT TOP(7) i.[Number], i.[Amount], c.[Name]
	FROM [Invoices] i
	JOIN [Clients] c ON c.[Id] = i.[ClientId]
	WHERE (i.[IssueDate] < '2023-01-01' AND i.[Currency] = 'EUR') OR
		(i.[Amount] > 500.00 AND LEFT(c.[NumberVAT], 2) = 'DE')
	ORDER BY i.[Number], i.[Amount] DESC

--PROBLEM 09 - Clients with VAT
SELECT c.[Name], MAX(p.[Price]) AS [Price], c.[NumberVAT]
	FROM [ProductsClients] pc
	JOIN [Clients] c ON c.[Id] = pc.[ClientId]
	JOIN [Products] p ON p.[Id] = pc.[ProductId]
	WHERE RIGHT(c.[Name], 2) != 'KG'
	GROUP BY c.[Name], c.[NumberVAT]
	ORDER BY MAX([Price]) DESC

--PROBLEM 10 - Clients by Price
SELECT c.[Name], FLOOR(AVG(p.[Price])) AS [Average Price]
	FROM [ProductsClients] pc
	JOIN [Clients] c ON c.[Id] = pc.[ClientId]
	JOIN [Products] p ON p.[Id] = pc.[ProductId]
	JOIN [Vendors] v ON v.[Id] = p.[VendorId]
	WHERE CHARINDEX('FR', v.[NumberVAT]) != 0
	GROUP BY c.[Name]
	ORDER BY [Average Price], c.[Name] DESC

--PROBLEM 11 - Product with Clients
CREATE FUNCTION udf_ProductWithClients(@Name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT;
	SELECT @Count = (SELECT COUNT(c.[Name])
						FROM [ProductsClients] pc
						JOIN [CLients] c ON c.[Id] = pc.[ClientId]
						JOIN [Products] p ON p.[Id] = pc.[ProductId]
						WHERE p.[Name] = @Name
						GROUP BY p.[Name])

	RETURN @Count;
END

SELECT [dbo].[udf_ProductWithClients]('DAF FILTER HU12103X')

--PROBLEM 12 - Search for Vendors from a Specific Country
CREATE PROC usp_SearchByCountry(@Country VARCHAR(10)) 
AS
	SELECT v.[Name], v.[NumberVAT], CONCAT_WS(' ', a.[StreetName], a.[StreetNumber]) AS [Street Info],
			CONCAT_WS(' ', a.[City], a.[PostCode]) AS [City Info]
		FROM [Vendors] v
		JOIN [Addresses] a ON a.[Id] = v.[AddressId]
		JOIN [Countries] c ON c.[Id] = a.[CountryId]
		WHERE c.[Name] = @Country
		ORDER BY v.[Name], a.[City]

EXEC usp_SearchByCountry 'France'