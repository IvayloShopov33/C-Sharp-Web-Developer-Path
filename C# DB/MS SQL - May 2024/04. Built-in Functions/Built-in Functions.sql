--Lab
--Analytic functions
USE [SoftUni1]
SELECT [FirstName], [Salary], [DepartmentID],
	PERCENTILE_CONT(0.5)
	WITHIN GROUP (ORDER BY [Salary] DESC)
	OVER (PARTITION BY [DepartmentID]) AS MedianCont
	FROM [Employees]

--String functions
--CONCAT, CONCAT_WS
SELECT [FIrstName], [MiddleName], [LastName],
		CONCAT([FIrstName], ' ', [MiddleName], ' ', [LastName]),
		CONCAT_WS(' ', [FIrstName], [MiddleName], [LastName])
	FROM [Employees]

--SUBSTRING
SELECT SUBSTRING('SoftUni', 1, 4)

--REPLACE
SELECT [FirstName],
	REPLACE([FirstName], 'Rob', N'»ван') AS [ChangedName]
	FROM [Employees]

--TRIM
SELECT TRIM('   Spas   ')

--LEN
SELECT LEN('1234567')

--LEFT & RIGHT
SELECT LEFT('SoftUni', 4)
SELECT RIGHT('SoftUni', 3)

--LOWER & UPPER
SELECT LOWER('MILK')
SELECT UPPER('milk')

--REVERSE
SELECT REVERSE('TUG NIB HCI')

--REPLICATE
SELECT REPLICATE('A', 3)

--FORMAT
SELECT [FirstName], [LastName], [HireDate],
		FORMAT([HireDate], 'dd-MM-yyyy', 'bg-BG'),
		FORMAT([Salary], 'C', 'bg-BG')
	FROM [Employees]

--CHARINDEX
SELECT CHARINDEX('Uni', 'Softuni')
SELECT CHARINDEX('Uni', 'SoftUni')
SELECT CHARINDEX('Uni', 'SoftUni', 6)

--STUFF
SELECT STUFF('Uni', 1, 0, 'Soft')
SELECT STUFF('Uni', 1, 3, 'Soft')

--MATH functions
--PROBLEM - Find The Area Of Triangles
USE [Demo]
SELECT [A], [H],
		0.5 * [A] * [H] AS [S]
	FROM [Triangles2]

--PI
SELECT PI()

--ABS
SELECT ABS(3)
SELECT ABS(-3)

--SQRT
SELECT SQRT(4)
SELECT SQRT(9)
SELECT SQRT(144)
SELECT SQRT(4761)

--SQUARE
SELECT SQUARE(2)
SELECT SQUARE(3)
SELECT SQUARE(12)
SELECT SQUARE(69)

--PROBLEM - Line Lengths
SELECT [X1], [Y1], [X2], [Y2], 
		SQRT(SQUARE([X2]-[X1]) + SQUARE([Y2] - [Y1])) AS [LengthOfTheLine]
	FROM [Lines]

--POWER
SELECT POWER(2, 4)

--ROUND
SELECT ROUND(PI(), 2)
SELECT ROUND(1234.567, -2)

--FLOOR
SELECT FLOOR(1.999)

--CEILING
SELECT CEILING(1.001)

--PROBLEM - Pallets
SELECT *,
		CEILING(1.0 * [Quantity] / ([BoxCapacity] * [PalletCapacity])) AS [NumberOfPallets]
	FROM [Products]

--SIGN
SELECT SIGN(-0.001), SIGN(0), SIGN(5)

--RAND
SELECT RAND(), RAND(1)

--LOG10
SELECT LOG10(100)

--LOG
SELECT LOG(512, 2)

--SIN, COS, TAN, COT
SELECT SIN(PI() / 2), COS(1110), TAN(1234), COT(PI() / 2)

--DATE functions
--PROBLEM - Quarterly Report (using DATEPART)
SELECT [InvoiceId], [Total],
		DATEPART(QUARTER, [InvoiceDate]) AS [Quarter],
		DATEPART(MONTH, [InvoiceDate]) AS [Month],
		DATEPART(YEAR, [InvoiceDate]) AS [Year],
		DATEPART(DAY, [InvoiceDate]) AS [Day]
	FROM [Invoices]

--DATEDIFF
SELECT DATEDIFF(YEAR, '2000-01-01', GETDATE())

--DATENAME
SELECT DATENAME(WEEKDAY, '2006-06-11')

--DATEADD
SELECT DATEADD(WEEK, 2, '2000-01-01')

--GETDATE
SELECT GETDATE()

--EOMONTH
SELECT EOMONTH('2024-02-02')

--Other functions
--CAST & CONVERT
SELECT CAST('17' AS SMALLINT), CONVERT(SMALLINT, '17')

--ISNULL
SELECT ISNULL(NULL, 1), ISNULL(0, 1)

--OFFSET & FETCH
USE [SoftUni1]
SELECT *
	FROM [Employees]
	ORDER BY [Salary] DESC
	OFFSET 0 ROWS
	FETCH NEXT 5 ROWS ONLY

--ROW_Number
SELECT ROW_NUMBER() OVER (ORDER BY [Salary] DESC) AS [Row Number], *
	FROM [Employees]
	ORDER BY [Salary] DESC

--RANK
SELECT RANK() OVER (ORDER BY [Salary] DESC) AS [Rank], *
	FROM [Employees]
	ORDER BY [Salary] DESC

--DENSE_RANK
SELECT DENSE_RANK() OVER (ORDER BY [Salary] DESC) AS [Dense Rank], *
	FROM [Employees]
	ORDER BY [Salary] DESC

--NTILE
SELECT NTILE(2) OVER (ORDER BY [Salary] DESC) AS [NTile], *
	FROM [Employees]
	ORDER BY [Salary] DESC

--PROBLEM 01 - Hide Payment Number
USE [Demo]

CREATE VIEW V_ObfuscatedCustomers AS
SELECT [CustomerID], [FirstName], [LastName],
	CONCAT(LEFT([PaymentNumber], 6), REPLICATE('*', LEN([PaymentNumber]) - 6)) AS [PaymentNumber]
	FROM [Customers]

--Exercises
--PROBLEM 01 - Find Names of All Employees by First Name
USE [SoftUni1]
SELECT [FirstName], [LastName]
	FROM [employees]
	WHERE LEFT([FirstName], 2) = 'SA'

--PROBLEM 02 - Find Names of All Employees by Last Name
SELECT [FirstName], [LastName]
	FROM [employees]
	WHERE CHARINDEX('ei', [LastName]) != 0

--PROBLEM 03 - Find First Names of All Employees
SELECT [FirstName]
	FROM [employees]
	WHERE [DepartmentID] IN (3, 10) AND
		(YEAR([HireDate]) BETWEEN 1995 AND 2005)

--PROBLEM 04 - Find All Employees Except Engineers
SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE CHARINDEX('engineer', [JobTitle]) = 0

--PROBLEM 05 - Find Towns with Name Length
SELECT [Name]	
	FROM [Towns]
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name]

--PROBLEM 06 - Find Towns Starting With
SELECT [ID], [Name]
	FROM [Towns]
	WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name]

--PROBLEM 07 - Find Towns Not Starting With
SELECT [ID], [Name] --TownID
	FROM [Towns]
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name]

--PROBLEM 08 - Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
	FROM [employees]
	WHERE YEAR([HireDate]) > 2000 

--PROBLEM 09 - Length of Last Name
SELECT [FirstName], [LastName]
	FROM [employees]
	WHERE LEN([LastName]) = 5

--PROBLEM 10 - Rank Employees by Salary
SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
		DENSE_RANK() OVER (
			PARTITION BY [Salary]
			ORDER BY [EmployeeID]
		) AS [Rank]
	FROM [Employees]
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC

--PROBLEM 11 - Find All Employees with Rank
SELECT *
	FROM (
		SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
		DENSE_RANK() OVER (
			PARTITION BY [Salary]
			ORDER BY [EmployeeID]
		) AS [Rank]
		FROM [Employees]
	) AS [RankedEmployees]
	WHERE ([Salary] BETWEEN 10000 AND 50000) AND 
		([Rank] = 2)
	ORDER BY [Salary] DESC

--PROBLEM 12 - Countries Holding СAТ 3 or More Times
USE [Geography]
SELECT [CountryName], [IsoCode]
	FROM [Countries]
	WHERE [CountryName] LIKE '%a%a%a%'
	ORDER BY [IsoCode]

--PROBLEM 13 - Mix of Peak and River Names
SELECT [PeakName], [RiverName],
		LOWER(LEFT([PeakName], LEN([PeakName]) - 1) + [RiverName]) AS [Mix]
	FROM [Peaks], [Rivers]
	WHERE LOWER(RIGHT([PeakName], 1)) = LOWER(LEFT([RiverName], 1))
	ORDER BY [Mix]

--PROBLEM 14 - Games from 2011 and 2012 year
USE [Diablo]
SELECT TOP(50) [Name], FORMAT(CAST([Start] AS DATE), 'yyyy-MM-dd') AS [Start]
	FROM [Games]
	WHERE YEAR([Start]) IN (2011, 2012)
	ORDER BY [Start], [Name]

--PROBLEM 15 - User Email Providers
SELECT [Username], SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]) - CHARINDEX('@', [Email])) AS [EmailProvider]
	FROM [Users]
	ORDER BY [EmailProvider], [Username]

--PROBLEM 16 - Get Users with IPAdress Like Pattern
SELECT [Username], [IpAddress]
	FROM [Users]
	WHERE [IpAddress] LIKE '___.1%.%.___'
	ORDER BY [Username]

--PROBLEM 17 - Show All Games with Duration and Part of the Day
SELECT [Name],
		CASE 
			WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) >=12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
			WHEN DATEPART(HOUR, [Start]) >-18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
		END AS [Part of the Day],
		CASE 
			WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			WHEN [Duration] >= 6 THEN 'Long'
			WHEN [Duration] IS NULL THEN 'Extra Long'
		END AS [Duration]
	FROM [Games]
	ORDER BY [Name], [Duration], [Part of the Day]

--PROBLEM 18 - Orders Table
SELECT [ProductName], [OrderDate], 
		DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
		DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
		FROM [Orders]