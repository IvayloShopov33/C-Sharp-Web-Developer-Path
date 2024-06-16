--MS SQL Regular Exam - 16 June 2024
--PROBLEM 01 - DDL
CREATE DATABASE [LibraryDb]
USE [LibraryDb]

CREATE TABLE [Genres]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Contacts]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Email] NVARCHAR(100),
	[PhoneNumber] NVARCHAR(20),
	[PostAddress] NVARCHAR(200),
	[Website] NVARCHAR(50)
)

CREATE TABLE [Libraries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[ContactId] INT REFERENCES [Contacts]([Id]) NOT NULL
)

CREATE TABLE [Authors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[ContactId] INT REFERENCES [Contacts]([Id]) NOT NULL
)

CREATE TABLE [Books]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(100) NOT NULL,
	[YearPublished] INT NOT NULL,
	[ISBN] NVARCHAR(13) UNIQUE NOT NULL,
	[AuthorId] INT REFERENCES [Authors]([Id]) NOT NULL,
	[GenreId] INT REFERENCES [Genres]([Id]) NOT NULL
)

CREATE TABLE [LibrariesBooks]
(
	[LibraryId] INT REFERENCES [Libraries]([Id]) NOT NULL,
	[BookId] INT REFERENCES [Books]([Id]) NOT NULL,
	CONSTRAINT PK_LibrariesBooks PRIMARY KEY ([LibraryId], [BookId])
)

--PROBLEM 02 - Insert
INSERT INTO [Contacts]([Email], [PhoneNumber], [PostAddress], [Website])
	VALUES
(NULL, NULL, NULL, NULL),
(NULL, NULL, NULL, NULL),
('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO [Authors]([Name], [ContactId])
	VALUES
('George Orwell', 21),
('Aldous Huxley', 22),
('Stephen King', 23),
('Suzanne Collins', 24)

INSERT INTO [Books]([Title], [YearPublished], [ISBN], [AuthorId], [GenreId])
	VALUES
('1984', 1949, '9780451524935', 16, 2),
('Animal Farm', 1945, '9780451526342'	, 16, 2),
('Brave New World', 1932, '9780060850524', 17, 2),
('The Doors of Perception', 1954, '9780060850531', 17, 2),
('The Shining', 1977, '9780307743657', 18, 9),
('It', 1986, '9781501142970', 18, 9),
('The Hunger Games', 2008, '9780439023481', 19, 7),
('Catching Fire', 2009, '9780439023498', 19, 7),
('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO [LibrariesBooks]([LibraryId], [BookId])
	VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44)

--PROBLEM 03 - Update
UPDATE c
	SET c.[Website] = 
		'www.' + LOWER(CONCAT(SUBSTRING(a.[Name], 1, CHARINDEX(' ', a.[Name]) - 1), SUBSTRING(a.[Name], CHARINDEX(' ', a.[Name]) + 1, LEN(a.[Name]) - CHARINDEX(' ', a.[Name]) + 1))) + '.com'
	FROM [Authors] AS a
	JOIN [Contacts] c ON c.[Id] = a.[ContactId]
	WHERE c.[Website] IS NULL

--PROBLEM 04 - DELETE
DELETE
	FROM [LibrariesBooks]
	WHERE [BookId] IN (SELECT b.[Id] FROM [Books] b
				JOIN [Authors] a ON a.[Id] = b.[AuthorId]
				WHERE a.[Name] = 'Alex Michaelides')

DELETE
	FROM [Books]
	WHERE [Id] IN (SELECT b.[Id] FROM [Books] b
			 	JOIN [Authors] a ON a.[Id] = b.[AuthorId]
			    	WHERE a.[Name] = 'Alex Michaelides')

DELETE
	FROM [Authors]
	WHERE [Name] = 'Alex Michaelides'

--PROBLEM 05 - Books by Year of Publication
SELECT [Title], [ISBN], [YearPublished]
	FROM [Books]
	ORDER BY [YearPublished] DESC, [Title]

--PROBLEM 06 - Books by Genre
SELECT b.[Id], b.[Title], b.[ISBN], g.[Name]
	FROM [Books] b
	JOIN [Genres] g ON g.[Id] = b.[GenreId]
	WHERE g.[Name] IN ('Biography', 'Historical Fiction')
	ORDER BY g.[Name], b.[Title]

--PROBLEM 07 - Libraries Missing Specific Genre
SELECT f.[Name], f.[Email]
	FROM (SELECT l.[Name], c.[Email], STRING_AGG(g.[Name], ' ') AS [GenresNames]
		FROM [LibrariesBooks] lb
		JOIN [Libraries] l ON lb.[LibraryId] = l.[Id]
		JOIN [Books] b ON b.[Id] = lb.[BookId]
		JOIN [Genres] g ON g.[Id] = b.[GenreId]
		JOIN [Contacts] c ON c.[Id] = l.[ContactId]
		GROUP BY l.[Name], c.[Email]
		HAVING CHARINDEX('Mystery', STRING_AGG(g.[Name], ' ')) = 0) AS f
		ORDER BY f.[Name]

--PROBLEM 08 - First 3 Books
SELECT TOP(3) b.[Title], b.[YearPublished], g.[Name]
	FROM [Books] b
	JOIN [Genres] g ON g.[Id] = b.[GenreId]
	WHERE (b.[YearPublished] > 2000 AND CHARINDEX('a', b.[Title]) > 0) OR
		(b.[YearPublished] < 1950 AND g.[Name] = 'Fantasy')
	ORDER BY b.[Title], b.[YearPublished] DESC

--PROBLEM 09 - Authors from UK
SELECT a.[Name], c.[Email], c.[PostAddress]
	FROM [Authors] a
	JOIN [Contacts] c ON c.[Id] = a.[ContactId]
	WHERE CHARINDEX('UK', c.[PostAddress]) > 0
	ORDER BY a.[Name]
	
--PROBLEM 10 - Fictions in Denver
SELECT a.[Name], b.[Title], l.[Name], c.[PostAddress]
	FROM [Books] b
	JOIN [LibrariesBooks] lb ON lb.[BookId] = b.[Id]
	JOIN [Libraries] l ON l.[Id] = lb.[LibraryId]
	JOIN [Genres] g ON g.[Id] = b.[GenreId]
	JOIN [Contacts] c ON c.[Id] = l.[ContactId]
	JOIN [Authors] a ON a.[Id] = b.[AuthorId]
	WHERE g.[Name] = 'Fiction' AND CHARINDEX('Denver', c.[PostAddress]) > 0
	ORDER BY b.[Title]

--PROBLEM 11 - Authors with Books
CREATE FUNCTION udf_AuthorsWithBooks(@Name NVARCHAR(100)) 
RETURNS INT
AS
BEGIN
	DECLARE @CountOfBooksByAuthor INT = (SELECT COUNT(b.[Id])
		FROM [Authors] a
		LEFT JOIN [Books] b ON b.[AuthorId] = a.[Id]
		WHERE a.[Name] = @Name
		GROUP BY a.[Name]);

	RETURN @CountOfBooksByAuthor;
END

SELECT [dbo].[udf_AuthorsWithBooks]('J.K. Rowling')

--PROBLEM 12 - Search for Books from a Specific Genre
CREATE PROC usp_SearchByGenre(@GenreName NVARCHAR(30))
AS
	SELECT b.[Title], b.[YearPublished], b.[ISBN], a.[Name], g.[Name]
		FROM [Books] b
		JOIN [Genres] g ON g.[Id] = b.[GenreId]
		JOIN [Authors] a ON a.[Id] = b.[AuthorId]
		WHERE g.[Name] = @GenreName
		ORDER BY b.[Title]

EXEC [usp_SearchByGenre] 'Fantasy'
