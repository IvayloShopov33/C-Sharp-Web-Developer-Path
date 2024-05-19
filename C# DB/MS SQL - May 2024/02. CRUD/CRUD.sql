--Lab
--PROBLEM - Employee Summary
USE [SoftUni]
SELECT [FirstName] + ' ' + [LastName] AS [FullName], [JobTitle], [Salary]
	FROM [Employees]

--PROBLEM - Highest Peak
USE [Geography]

CREATE VIEW [v_HighestPeak] AS
SELECT TOP(1) *
	FROM [Peaks]
	ORDER BY [Elevation] DESC

SELECT * FROM [v_HighestPeak]

--PROBLEM - Update Projects
USE [SoftUni1]
UPDATE [Projects]
	SET [EndDate] = GETDATE()
	WHERE [EndDate] IS NULL

--Exercises
--PROBLEM 02 - Find All Information About Departments
SELECT * FROM [Departments]

--PROBLEM 03 - Find all Department Names
SELECT [Name] FROM [Departments]

--PROBLEM 04 - Find Salary of Each Employee
SELECT [FirstName], [LastName], [Salary] FROM [Employees]

--PROBLEM 05 - Find Full Name of Each Employee
SELECT [FirstName], [MiddleName], [LastName] FROM [Employees]

--PROBLEM 06 - Find Email Address of Each Employee
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address]
	FROM [Employees]

--PROBLEM 07 - Find All Different Employee’s Salaries
SELECT DISTINCT [Salary] FROM [Employees]

--PROBLEM 08 - Find all Information About Employees
SELECT *
	FROM [Employees]
	WHERE [JobTitle] = 'Sales Representative'

--PROBLEM 09 - Find Names of All Employees by Salary in Range
SELECT [FirstName], [LastName], [JobTitle]
	FROM [Employees]
	WHERE [Salary] BETWEEN 20000 AND 30000

--PROBLEM 10 - Find Names of All Employees
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [Full Name]
	FROM [Employees]
	WHERE [Salary] IN (25000, 14000, 12500, 23600)

--PROBLEM 11 - Find All Employees Without Manager
SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [ManagerID] IS NULL

--PROBLEM 12 - Find All Employees with Salary More Than 50000
SELECT [FirstName], [LastName], [Salary]
	FROM [Employees]
	WHERE [Salary] > 50000
	ORDER BY [Salary] DESC

--PROBLEM 13 - Find 5 Best Paid Employees
SELECT TOP(5) [FirstName], [LastName]
	FROM [Employees]
	ORDER BY [Salary] DESC

--PROBLEM 14 - Find All Employees Except Marketing
SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [DepartmentID] != 4

--PROBLEM 15 - Sort Employees Table
SELECT * 
	FROM [Employees]
	ORDER BY [Salary] DESC, [FirstName], [LastName] DESC, [MiddleName]

--PROBLEM 16 - Create View Employees with Salaries
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary]
	FROM [Employees]

--PROBLEM 17 - Create View Employees with Job Titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT [FirstName] + ' ' + ISNULL([MiddleName], '') + ' ' + [LastName] AS [Full Name],
	[JobTitle]
	FROM [Employees]

--PROBLEM 18 - Distinct Job Titles
SELECT DISTINCT [JobTitle]
	FROM [Employees]

--PROBLEM 19 - Find First 10 Started Projects
SELECT TOP(10) *
	FROM [Projects]
	ORDER BY [StartDate], [Name]

--PROBLEM 20 - Last 7 Hired Employees
SELECT TOP(7) [FirstName], [LastName], [HireDate]
	FROM [Employees]
	ORDER BY [HireDate] DESC

--PROBLEM 21 - Increase Salaries
UPDATE [Employees]
	SET [Salary] = [Salary] + [Salary] * 0.12
	WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary]
	FROM [Employees]

--PROBLEM 22 - All Mountain Peaks
USE [Geography]
SELECT [PeakName]
	FROM [Peaks]
	ORDER BY [PeakName]

--PROBLEM 23 - Biggest Countries by Population in Europe
SELECT TOP(30) [CountryName], [Population]
	FROM [Countries]
	WHERE [ContinentCode] = 'EU'
	ORDER BY [Population] DESC, [CountryName]

--PROBLEM 24 - Countries and Currency (Euro / Not Euro)
SELECT [CountryName], [CountryCode],
	CASE
		WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
	FROM [Countries]
	ORDER BY [CountryName]

--PROBLEM 25 - All Diablo Characters
USE [Diablo]
SELECT [Name]	
	FROM [Characters]
	ORDER BY [Name]