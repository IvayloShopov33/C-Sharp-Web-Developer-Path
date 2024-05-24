--Lab
CREATE DATABASE CoursesTest
USE [CoursesTest]

CREATE TABLE [Students]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(150) NOT NULL,
	[FacultyNumber] CHAR(6) NOT NULL UNIQUE,
	[Photo] VARBINARY(MAX),
	[DateOfEnlistment] DATE
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE [Courses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(150) NOT NULL,
	[TownId] INT REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [StudentsCourses]
(
	[StudentId] INT REFERENCES [Students]([Id]),
	[CoursesId] INT REFERENCES [Courses]([Id]),
	[Mark] DECIMAL(3, 2) NOT NULL,
	CONSTRAINT PK_StudentsCourses
		PRIMARY KEY ([StudentId], [CoursesId])
)

INSERT INTO [Towns]([Name])
	VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas'),
('Veliko Tarnovo')

INSERT INTO [Courses]([Name], [TownId])
	VALUES
('C# OOP', 1),
('JavaScript Front-End', 5),
('Python Basics', 3),
('Java DB', 2),
('PHP Fundamentals', 4)

SELECT * 
	FROM [Courses] AS c
	JOIN [Towns] AS t
		ON c.[TownId] = t.[Id]

INSERT INTO [Students]([Name], [FacultyNumber])
	VALUES
('Spas Nedelev', 'ABCD12'),
('Ivo Ivov', 'POHGOH'),
('Ivan Kukov', 'F12345'),
('Georgi Petrov', 'YTGSVF'),
('Mincho Minchev', 'KAJFLB'),
('Mag Papazov', '127ACA')

INSERT INTO [StudentsCourses]([StudentId], [CoursesId], [Mark])
	VALUES
(1, 1, 5.97),
(1, 3, 4.51),
(2, 2, 4.10),
(5, 1, 5.00),
(2, 3, 2.50)

SELECT s.[Name] AS [Student Name], c.[Name] AS [Course Name], 
	t.[Name] AS [Town], sc.[Mark]
	FROM [StudentsCourses] AS sc
	JOIN [Courses] AS c
		ON sc.[CoursesId] = c.[Id]
	JOIN [Students] AS s
		ON sc.[StudentId] = s.[Id]
	JOIN [Towns] AS t
		ON c.[TownId] = t.[Id]

--Exercises
--PROBLEM 01 - One-To-One Relationship
CREATE TABLE [Passports]
(
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1),
	[PassportNumber] NCHAR(8) UNIQUE NOT NULL
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(60) NOT NULL,
	[Salary] DECIMAL(9, 2) NOT NULL,
	[PassportID] INT REFERENCES [Passports]([PassportID]) NOT NULL
)

INSERT INTO [Passports]([PassportNumber])
	VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
	VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--PROBLEM 02 - One-To-Many Relationship
CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models] 
(
	[ModelID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	[ManufacturerID] INT REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers]([Name], [EstablishedOn])
	VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO [Models]([Name], [ManufacturerID])
	VALUES
('X1', 1),
('i6', 1),
('ModelS', 2),
('ModelX', 2),
('Model3', 2),
('Nova', 3)

--PROBLEM 03 - Many-To-Many Relationship
CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT REFERENCES [Students]([StudentID]),
	[ExamID] INT REFERENCES [Exams]([ExamID]),
	CONSTRAINT PK_StudentsExams
		PRIMARY KEY ([StudentID], [ExamID])
)

INSERT INTO [Students]([Name])
	VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO [Exams]([Name])
	VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO [StudentsExams]([StudentID], [ExamID])
	VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--PROBLEM 04 - Self-Referencing
CREATE TABLE [Teachers]
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(100) NOT NULL,
	[ManagerID] INT REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers]([Name], [ManagerID])
	VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--PROBLEM 05 - Online Store Database
CREATE DATABASE [OnlineStore]
USE [OnlineStore]

CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE,
	[CityID] INT REFERENCES [Cities]([CityID]) NOT NULL,
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY IDENTITY,
	[CustomerID] INT REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE [OrderItems]
(
	[OrderID] INT REFERENCES [Orders]([OrderID]),
	[ItemID] INT REFERENCES [Items]([ItemID]),
	CONSTRAINT PK_OrderItems
		PRIMARY KEY ([OrderID], [ItemID])
)

--PROBLEM 06 - University Database
CREATE DATABASE [University]
USE [University]

CREATE TABLE [Majors]
(
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] CHAR(10) NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Payments]
(
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(10, 2) NOT NULL,
	[StudentID] INT REFERENCES [Students]([StudentID]) NOT NULL
)

CREATE TABLE [Subjects]
(
	[SubjectsID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Agenda]
(
	[StudentID] INT REFERENCES [Students]([StudentID]) NOT NULL,
	[SubjectID] INT REFERENCES [Subjects]([SubjectsID]) NOT NULL,
	CONSTRAINT PK_Agenda
		PRIMARY KEY ([StudentID], [SubjectID])
)

--PROBLEM 09 - Peaks in Rila
USE [Geography]
SELECT m.[MountainRange], p.[PeakName], p.[Elevation]
	FROM [Peaks] AS p
	JOIN [Mountains] AS m
		ON p.[MountainId] = m.[Id]
	WHERE m.[MountainRange] = 'Rila'
	ORDER BY p.[Elevation] DESC
