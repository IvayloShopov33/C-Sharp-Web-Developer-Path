-- PROBLEM 01 - Create Database
CREATE DATABASE [Minions]

-- PROBLEM 02 - Create Tables
USE Minions

CREATE TABLE [Minions]
(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(150) NOT NULL,
	[Age] TINYINT NOT NULL
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(150) NOT NULL
)

-- PROBLEM 03 - Alter Minions Table 
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

--PROBLEM 04 - Insert Records in Both Tables
ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

INSERT INTO [Towns]([Id], [Name])
	VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--PROBLEM 05 - Truncate Table Minions
TRUNCATE TABLE [Minions]
SELECT * FROM [Minions]

--PROBLEM 06 - Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]

--PROBLEM 07 - Create Table People
CREATE TABLE [People]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('John', 1.95, 95.50, 'm', '1999-01-27'),
('Mark', NULL, NULL, 'm', '1990-12-06'),
('Mia', 1.60, NULL, 'f', '2001-04-30'),
('Viki', NULL, 59.00, 'f', '1993-07-31'),
('Adam', 1.80, 85.00, 'm', '1984-03-03')

SELECT * FROM [People]

--PROBLEM 08 - Create Table Users
CREATE TABLE [Users]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATE,
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [IsDeleted])
	VALUES
('iamthebest', 'iamtheworst', 0),
('ronaldo', 'messi', 1),
('cool', 'cold', 0),
('ninja', 'monster', 1),
('skyscraper', 'high', 0)

SELECT * FROM [Users]

--PROBLEM 09 - Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC072F39CDE4

ALTER TABLE [Users]
ADD CONSTRAINT PK_User PRIMARY KEY ([Id], [Username])

--PROBLEM 10 - Add Check Constraint
ALTER TABLE [Users] WITH NOCHECK
ADD CONSTRAINT CHK_Password_Length CHECK (
	DATALENGTH([Password]) >= 5
)

--PROBLEM 11 - Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginTime 
DEFAULT (GETDATE()) FOR [LastLoginTime]

--PROBLEM 12 - Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT PK_User

ALTER TABLE [Users]
ADD CONSTRAINT PK_User PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT UQ_Username UNIQUE ([Username])

ALTER TABLE [Users] WITH NOCHECK
ADD CONSTRAINT CHK_Username_Length CHECK (
	DATALENGTH([Username]) >= 3
)

--PROBLEM 13 - Movies Database
CREATE DATABASE [Movies]
USE [Movies]

CREATE TABLE [Directors] 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(150) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(150) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] DATE NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] VARCHAR(5),
	CHECK ([Rating] = 'G' OR [Rating] = 'PG' OR [Rating] = 'PG-13' OR [Rating] = 'R' OR
			[Rating] = 'NC-17' OR [Rating] = 'TV-Y' OR [Rating] = 'TV-Y7' OR [Rating] = 'TV-G' OR
			[Rating] = 'TV-PG' OR [Rating] = 'TV-14' OR [Rating] = 'TV-MA'),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors]([DirectorName], [Notes])
	VALUES
('Steven Spielberg', 'Renowned for his work in blockbuster films such as "Jurassic Park" and "E.T. the Extra-Terrestrial".'),
('Quentin Tarantino', 'Known for his unique style and nonlinear storytelling in films like "Pulp Fiction" and "Kill Bill"'),
('Martin Scorsese', NULL),
('Christopher Nolan', 'Renowned for his mind-bending narratives in films like "Inception", "Interstellar" and "Oppenheimer".'),
('Greta Gerwig', NULL)

SELECT * FROM [Directors]

INSERT INTO [Genres]([GenreName], [Notes])
	VALUES
('Biography', NULL),
('Science Fiction', 'Explores imaginative and futuristic concepts, often involving advanced technology or space exploration.'),
('Action', 'Characterized by high energy, fast-paced sequences, and thrilling stunts.'),
('Criminal', NULL),
('Drama', 'Focuses on character development, interpersonal relationships, and emotional depth.')

SELECT * FROM [Genres]

INSERT INTO [Categories]([CategoryName], [Notes])
	VALUES
('Classic', 'Timeless films that have stood the test of time and continue to be revered for their cultural significance and artistic merit.'),
('Documentary', 'Non-fiction films that aim to educate, inform, or raise awareness about real-life subjects, events, or issues.'),
('Indie', 'Independent films produced outside of the major studio system, often characterized by artistic expression and unconventional storytelling.'),
('Blockbuster', 'High-budget films with wide appeal, typically featuring big-name actors and extensive marketing campaigns.'),
('Foreign', NULL)

SELECT * FROM [Categories]

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
	VALUES
('Oppenheimer', 4, '2023-07-21', '03:00:00', 1, 2, 'R', 'One of the best Oscar-winning films of all time!'),
('Jurassic Park', 1, '1993-09-17', '02:02:00', 2, 1, 'PG-13', NULL),
('Kill Bill', 2, '2004-10-01', '01:51:00', 3, 1, 'R', Null),
('Goodfellas', 3, '1990-09-19', '02:26:00', 4, 1, 'R', NULL),
('Little Women', 5, '2019-12-25', '02:15:00', 5, 3, 'PG', 'Good romantic and dramatical film')

SELECT * FROM [Movies]

--PROBLEM 14 - Car Rental Database
CREATE DATABASE [CarRental]
USE [CarRental]

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] SMALLINT,
	[WeeklyRate] SMALLINT,
	[MonthlyRate] INT,
	[WeekendRate] SMALLINT
)

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(30) NOT NULL,
	[Manufacturer] VARCHAR(50) NOT NULL,
	[Model] VARCHAR(30) NOT NULL,
	[CarYear] DATE NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Doors] TINYINT NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 900000),
	[Condition] NVARCHAR(15),
	[Available] BIT
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Title] NVARCHAR(20),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] NVARCHAR(30) NOT NULL,
	[FullName] NVARCHAR(60) NOT NULL,
	[Address] NVARCHAR(80) NOT NULL,
	[City] NVARCHAR(40) NOT NULL,
	[ZipCode] SMALLINT NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RentalOrders] 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
	[TankLevel] SMALLINT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] SMALLINT NOT NULL,
	[RateApplied] INT NOT NULL,
	[TaxRate] INT NOT NULL,
	[OrderStatus] BIT NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
	VALUES
('Regular', 15, 105, 435, 50),
('Sports', 45, 315, 1260, 115),
('CityEnvironment', 26, NULL, NULL, 80)

SELECT * FROM [Categories]

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Available])
	VALUES
('1', 'Bugatti', 'Chiron', '2016-03-01', 2, 2, 1),
('CB9999KM', 'Audi', 'Q7', '2009-12-12', 3, 4, 0),
('E EEEEEE', 'Lamborghini', 'Huracan', '2013-12-08', 2, 2, 1)

SELECT * FROM [Cars]

INSERT INTO [Employees]([FirstName], [LastName])
	VALUES
('Grigor', 'Dimitrov'),
('Spas', 'Nedelev'),
('Cristiano', 'Ronaldo')

SELECT * FROM [Employees]

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZipCode])
	VALUES
('1234GFDFDD', 'Gosho Petkov', 'Vitosha street 1', 'Sofia', 1000),
('G89GF7G0G5', 'Martina Spasova', 'Liberty street 99', 'Plovdiv', 4000),
('HGF45HFGHF', 'Ivayla Ivanova', 'Alen Mak 7', 'Varna', 9000)

SELECT * FROM [Customers]

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], 
	[StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus])
	VALUES
(1, 1, 1, 400, 20000, 100000, 80000, '2016-07-07', '2024-04-30', 2854, 10, 100, 1),
(2, 2, 2, 300, 130000, 190000, 60000, '2018-06-06', '2022-12-12', 1650, 8, 95, 0),
(3, 3, 3, 350, 10000, 50000, 40000, '2019-08-08', '2023-03-03', 1303, 9, 110, 1)

SELECT * FROM [RentalOrders]

--PROBLEM 15 - Hotel Database
CREATE DATABASE [Hotel]
USE [Hotel]

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Title] NVARCHAR(20),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers]
(
	[AccountNumber] NVARCHAR(30) PRIMARY KEY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[PhoneNumber] NVARCHAR(30) NOT NULL,
	[EmergencyName] VARCHAR(12) NOT NULL,
	[EmergencyNumber] VARCHAR(5) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] VARCHAR(15) PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] VARCHAR(15) PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes]
(
	[BedType] VARCHAR(15) PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY,
	[RoomType] VARCHAR(15) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
	[BedType] VARCHAR(15) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
	[Rate] TINYINT NOT NULL,
	[RoomStatus] VARCHAR(15) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Payments]
(
	[Id] INT NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[PaymentDate] DATE NOT NULL,
	[AccountNumber] NVARCHAR(30) FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE PRIMARY KEY,
	[TotalDays] AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied]),
	[AmountCharged] DECIMAL(7, 2) NOT NULL,
	[TaxRate] DECIMAL(7, 2),
	[TaxAmount] AS [AmountCharged] * [TaxRate],
	[PaymentTotal] AS [AmountCharged] + [AmountCharged] * [TaxRate],
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[DateOccupied] DATE FOREIGN KEY REFERENCES [Payments]([LastDateOccupied]) NOT NULL,
	[AccountNumber] NVARCHAR(30) FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL,
	[RateApplied] TINYINT,
	[PhoneCharged] DECIMAL(7, 2) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName])
	VALUES
('Spas', 'Nedelev'),
('Martina', 'Ivanova'),
('Ivo', 'Ivov')

SELECT * FROM [Employees]

INSERT INTO [Customers]([AccountNumber], [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber])
	VALUES
('12ABCSD', 'Leo', 'Messi', '084641315', 'Lefty', '911'),
('ÀÁÖÄÄÔÔ', 'Èâî', 'Öåöîâ', '086411348', 'Righty', '112'),
('KF4562F', 'John', 'Mark', '0495135461', 'Middle', '160A')

SELECT * FROM [Customers]

INSERT INTO [RoomStatus]([RoomStatus])
	VALUES
('Good'),
('Excellent'),
('Bad')

SELECT * FROM [RoomStatus]

INSERT INTO [RoomTypes]([RoomType])
	VALUES
('THREE ROOMS'),
('ONE ROOM'),
('FOUR ROOMS')

SELECT * FROM [RoomTypes]

INSERT INTO [BedTypes]([BedType])
	VALUES
('Big'),
('Small'),
('Medium')

SELECT * FROM [BedTypes]

INSERT INTO [Rooms]([RoomNumber], [RoomType], [RoomStatus], [BedType], [Rate])
	VALUES
(106, 'ONE ROOM', 'Bad', 'Small', 1),
(307, 'FOUR ROOMS', 'Excellent', 'Big', 10),
(531, 'THREE ROOMS', 'Good', 'Medium', 5)

SELECT * FROM [Rooms]

INSERT INTO [Payments]([Id], [EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], 
	 [AmountCharged], [TaxRate])
	VALUES
('12354961', 3, '2024-08-07', 'KF4562F', '2024-08-01', '2024-08-07', 351.51, 0.00),
('65489416', 2, '2023-06-06', 'ÀÁÖÄÄÔÔ', '2023-06-05', '2023-06-06', 90.54, 0.00),
('96545613', 1, '2022-07-07', '12ABCSD', '2022-07-05', '2022-07-07', 140.00, 0.00)

SELECT * FROM [Payments]

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [PhoneCharged])
	VALUES
(1, '2022-07-07', '12ABCSD', 106, 0.00),
(2, '2023-06-06', 'ÀÁÖÄÄÔÔ', 307, 5.00),
(3, '2024-08-07', 'KF4562F', 531, 2.00)

SELECT * FROM [Occupancies]

--PROBLEM 16 - Create SoftUni Database
CREATE DATABASE [SoftUni]
USE [SoftUni]

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(150) NOT NULL,
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(150) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Departments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(150) NOT NULL,
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(150) NOT NULL,
	[MiddleName] NVARCHAR(150) NOT NULL,
	[LastName] NVARCHAR(150) NOT NULL,
	[JobTitle] VARCHAR(100) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(8, 2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

--PROBLEM 18 - Basic Insert
INSERT INTO [Towns]([Name])
	VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Addresses]([AddressText], [TownId])
	VALUES
('Vitosha street 1', 1),
('Tapetata street 28', 2),
('Chaika street 94', 3),
('Lasuri street 17', 4),
('Liberty street 51', 1)

INSERT INTO [Departments]([Name])
	VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId])
	VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, 3),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 5),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 4),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 1),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 2)

--PROBLEM 19 - Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

--PROBLEM 20 - Basic Select All Fields and Order Them
SELECT * FROM [Towns]
	ORDER BY [Name]

SELECT * FROM [Departments]
	ORDER BY [Name]

SELECT * FROM [Employees]
	ORDER BY [Salary] DESC

--PROBLEM 21 - Basic Select Some Fields
SELECT [Name] 
	FROM [Towns]
	ORDER BY [Name]

SELECT [Name] 
	FROM [Departments]
	ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary]
	FROM [Employees]
	ORDER BY [Salary] DESC

--PROBLEM 22 - Increase Employees Salary
UPDATE [Employees]
	SET [Salary] = [Salary] + 0.1 * [Salary]

SELECT [Salary]
	FROM [Employees]

--PROBLEM 23 - Decrease Tax Rate
USE [Hotel]

UPDATE [Payments]
	SET [TaxRate] = [TaxRate] - 0.03 * [TaxRate]

SELECT [TaxRate]
	FROM [Payments]

--PROBLEM 24 - Delete All Records
TRUNCATE TABLE [Occupancies]