-- Lab
-- T-SQL Variables
DECLARE @Year SMALLINT = 2024
SELECT @Year

SET @Year += 1

DECLARE @TempTable  TABLE([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50))
INSERT INTO @TempTable ([Name])
	VALUES
('Ivo'),
('Spas'),
('Alex')

SELECT * FROM @TempTable

-- T-SQL Conditional Statements
IF YEAR(GETDATE()) = 2024
BEGIN
	SET @Year = 2025
	INSERT INTO @TempTable ([Name]) VALUES ('Ivaylo')
END
ELSE IF YEAR(GETDATE()) = 2023
	SELECT * FROM @TempTable
ELSE
	SET @Year = 0

-- T-SQL Loops
WHILE @Year >= 2017
BEGIN
	SELECT @Year, COUNT(*) FROM [Employees] WHERE YEAR([HireDate]) = @Year
	SET @Year -= 1
END

-- Functions
CREATE FUNCTION udf_BigPower(@Base INT, @Exp INT)
RETURNS BIGINT
AS
BEGIN
	DECLARE @Result BIGINT = 1;
	WHILE @Exp > 0
	BEGIN
		SET @Result *= @Base;
		SET @Exp -= 1;
	END
	RETURN @Result;
END

SELECT [dbo].[udf_BigPower](2, 60)

--Views vs Functions
CREATE OR ALTER VIEW v_EmployeesByYear AS
SELECT * FROM [Employees]
	WHERE YEAR([HireDate]) = 2001

CREATE FUNCTION udf_EmployeesByYear(@YEAR INT)
RETURNS TABLE
AS
RETURN
(
	SELECT * FROM [Employees]
	WHERE YEAR([HireDate]) = @YEAR
)

SELECT * FROM udf_EmployeesByYear(2000)

CREATE FUNCTION udf_AllPowers(@MaxPower INT)
RETURNS @Table TABLE([Id] INT PRIMARY KEY IDENTITY, [Square] BIGINT)
AS
BEGIN
	DECLARE @I INT = 1;
	WHILE @MaxPower >= @I
	BEGIN
		INSERT INTO @Table ([Square]) VALUES (@I * @I);
		SET @I += 1;
	END
	RETURN
END

SELECT * FROM [dbo].[udf_AllPowers](1000)
	WHERE [Square] % 3 = 0
	ORDER BY [Square] DESC

--PROBLEM 01 - Salary Level Function
CREATE OR ALTER FUNCTION udf_GetSalaryLevel(@Salary MONEY) 
RETURNS VARCHAR(7)
AS
BEGIN
	IF @Salary IS NULL
		RETURN NULL

	IF @Salary < 30000
		RETURN 'Low'
	ELSE IF @Salary < 50000
		RETURN 'Average'

	RETURN 'High'
END

SELECT [FirstName], [LastName], [Salary],
		[dbo].[udf_GetSalaryLevel]([Salary]) AS [SalaryLevel]
	FROM [Employees]

--System Stored Procedures
EXEC sp_databases
EXEC sp_monitor
EXEC sp_columns 'Employees'
EXEC sp_depends 'dbo.Employees'
EXEC sp_datatype_info

CREATE OR ALTER PROC sp_RecreateProjects(@Count SMALLINT)
AS
	INSERT INTO Projects([Name], [Description], [StartDate], [EndDate])
		SELECT TOP(@Count) 'New ' + [Name], [Description], [StartDate], [EndDate] FROM [Projects];
GO

-- Exercises
--PROBLEM 01 - Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT [FirstName], [LastName]
		FROM [Employees]
		WHERE [Salary] > 35000;

EXEC usp_GetEmployeesSalaryAbove35000

--PROBLEM 02 - Employees with Salary Above Given Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Salary DECIMAL(18, 4))
AS
	SELECT [FirstName], [LastName]
		FROM [Employees]
		WHERE [Salary] >= @Salary;

EXEC usp_GetEmployeesSalaryAboveNumber 60000;

--PROBLEM 03 - Town Names Starting With
CREATE PROC usp_GetTownsStartingWith(@StartingCharacters VARCHAR(30))
AS
	SELECT [Name]	
		FROM [Towns]
		WHERE CHARINDEX(@StartingCharacters, [Name]) = 1;

EXEC usp_GetTownsStartingWith 'b';

--PROBLEM 04 - Employees from Town
CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(50))
AS
	SELECT e.[FirstName], e.[LastName]
		FROM [Employees] e
		LEFT JOIN [Addresses] a ON e.[AddressID] = a.[AddressID]
		LEFT JOIN [Towns] t ON t.[ID] = a.[TownID]
		WHERE t.[Name] = @TownName;

EXEC usp_GetEmployeesFromTown 'Berlin'
--PROBLEM 05 - Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18, 4)) 
RETURNS VARCHAR(7)
AS
BEGIN
	IF @Salary IS NULL
		RETURN NULL

	IF @Salary < 30000
		RETURN 'Low'
	ELSE IF @Salary < 50000
		RETURN 'Average'

	RETURN 'High'
END

SELECT [Salary], [dbo].[ufn_GetSalaryLevel]([Salary]) AS [SalaryLevel]
	FROM [Employees]

--PROBLEM 06 - Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(7))
AS
	SELECT [firstName], [LastName]
	FROM [Employees]
	WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @SalaryLevel;

EXEC usp_EmployeesBySalaryLevel 'Low';
EXEC usp_EmployeesBySalaryLevel 'Average';
EXEC usp_EmployeesBySalaryLevel 'High';

--PROBLEM 07 - Define Function
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(50), @Word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @I SMALLINT = 1, @SetOfLettersToLower VARCHAR(50) = LOWER(@SetOfLetters), @WordToLower VARCHAR(50) = LOWER(@Word);
	WHILE @I <= LEN(@Word)
	BEGIN
		IF CHARINDEX(SUBSTRING(@WordToLower, @I, 1), @SetOfLettersToLower) = 0
			RETURN 0;

		SET @I += 1;
	END

	RETURN 1;
END

--PROBLEM 08 - Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT NULL

	DELETE
		FROM [EmployeesProjects]
		WHERE [EmployeeID] IN (
		SELECT [EmployeeID]
			FROM [Employees]
			WHERE [DepartmentID] = @DepartmentId)

	UPDATE [Employees]
		SET [ManagerID] = NULL
		WHERE [EmployeeID] IN (
		SELECT [EmployeeID] 
			FROM [Employees]
			WHERE [DepartmentID] = @DepartmentId)

	UPDATE [Employees]
		SET [ManagerID] = NULL
		WHERE [ManagerID] IN (
		SELECT [EmployeeID] 
			FROM [Employees]
			WHERE [DepartmentID] = @DepartmentId)

	UPDATE [Departments]
		SET [ManagerID] = NULL
		WHERE [DepartmentID] = @DepartmentId

	DELETE
		FROM [Employees]
		WHERE [DepartmentID] = @DepartmentId

	DELETE 
		FROM [Departments]
		WHERE [DepartmentID] = @DepartmentId

	SELECT COUNT(*)
		FROM [Employees]
		WHERE [DepartmentID] = @DepartmentId

EXEC usp_DeleteEmployeesFromDepartment 1

--PROBLEM 09 - Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT_WS(' ', [FirstName], [LastName]) AS [Full Name]
		FROM [AccountHolders];

--PROBLEM 10 - People with Balance Higher Than+
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Balance DECIMAL(10, 2))
AS
	SELECT ah.[FirstName], ah.[LastName]
		FROM [AccountHolders] ah
		LEFT JOIN [Accounts] a ON a.[AccountHolderId] = ah.[Id]		
		GROUP BY ah.[FirstName], ah.[LastName]
		HAVING SUM(a.[Balance]) > @Balance
		ORDER BY ah.[FirstName], ah.[LastName];

--PROBLEM 11 - Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@InitialSum DECIMAL(18, 2), @YearlyInterestRate FLOAT, @YearsCount INT)
RETURNS DECIMAL(18, 4)
AS 
BEGIN
	DECLARE @RateAmount DECIMAL(18, 8) = 1 + @YearlyInterestRate
	DECLARE @InitialRateAmount DECIMAL(18, 8) = @RateAmount;

	WHILE @YearsCount > 1
	BEGIN
		SET @RateAmount *= @InitialRateAmount;
		SET @YearsCount -= 1;
	END

	RETURN ROUND(@InitialSum * @RateAmount, 4);
END

--PROBLEM 12 - Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount(@AccountID INT, @InterestRate FLOAT)
AS
	SELECT a.[Id], ah.[FirstName], ah.[LastName], a.[Balance] AS [Current Balance],
			[dbo].[ufn_CalculateFutureValue](a.[Balance], @InterestRate, 5) AS [Balance in 5 years]
		FROM [Accounts] a
		JOIN [AccountHolders] ah ON a.[AccountHolderId] = ah.[Id]
		WHERE @AccountID = a.[Id];

--PROBLEM 13 - Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@Name VARCHAR(150))
RETURNS TABLE
AS
RETURN (
	SELECT SUM(d.[Cash]) AS [SumCash]
		FROM (
			SELECT [Cash],
				ROW_NUMBER() OVER (ORDER BY ug.[Cash] DESC) AS [RowNumber]
			FROM [Games] g
			JOIN [UsersGames] ug ON g.[Id] = ug.[GameId]
			WHERE g.[Name] = @Name) AS d
		WHERE d.[RowNumber] % 2 = 1)

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')
SELECT * FROM [dbo].[ufn_CashInUsersGames]('Lisbon')
