--Lab
--PROBLEM 01 - Employees with their addresses and towns
SELECT TOP(50) e.[FirstName], e.[LastName], a.[AddressText], t.[Name] AS [TownName]
	FROM [Employees] e
	LEFT JOIN [Addresses] a ON a.[Id] = e.[AddressID]
	LEFT JOIN [Towns] t ON t.[ID] = a.[TownID]
	ORDER BY e.[FirstName], e.[LastName]

--PROBLEM 02 - Sales Employees
SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name]
	FROM [Employees] e
	JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
	ORDER BY e.[EmployeeID]

--PROBLEM 03 - Employees Hired After
SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName]
	FROM [Employees] e
	JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] IN ('Sales', 'Finance') AND
		e.[HireDate] > '1999-01-01'
	ORDER BY e.[HireDate]

--PROBLEM 04 - Employee Summary
WITH CTE_Employees(EmployeeID, EmployeeName, ManagerName, DepartmentName, EmployeesInDepartment) AS 
(
	SELECT TOP(50) e.[EmployeeID], CONCAT_WS(' ', e.[FirstName], e.[LastName]) AS [EmployeeName],
		CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [ManagerName],
		d.[Name] AS [DepartmentName],
		(SELECT COUNT(*) FROM [Employees] WHERE [DepartmentID] = d.[DepartmentID]) AS [EmployeesInDepartment]
	FROM [Employees] e
	LEFT JOIN [Employees] m ON e.[ManagerID] = m.[EmployeeID]
	LEFT JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	ORDER BY e.[EmployeeID]
)

SELECT * FROM CTE_Employees

--PROBLEM 05 - Min Average Salary
SELECT d.[DepartmentID], d.[Name] AS [DepartmentName],
		(SELECT SUM([Salary]) FROM [Employees] WHERE [DepartmentID] = d.[DepartmentID]) AS [SalarySum],
		(SELECT COUNT(*) FROM [Employees] WHERE [DepartmentID] = d.[DepartmentID]) AS [EmployeesCount],
		(SELECT AVG([Salary]) FROM [Employees] WHERE [DepartmentID] = d.[DepartmentID]) AS [AverageSalary]
	FROM [Departments] d

SELECT e.[DepartmentID], COUNT(*) AS [EmployeesCount], MIN(e.[Salary]) AS [MinSalary], MAX(e.[Salary]) AS [MaxSalary]
	FROM [Employees] e
	GROUP BY e.[DepartmentID]

--Exercises
--PROBLEM 01 - Employee Address
SELECT TOP(5) e.[EmployeeID], e.[JobTitle], e.[AddressID], a.[AddressText]
	FROM [Employees] e
	JOIN [Addresses] a ON e.[AddressID] = a.[AddressID]
	ORDER BY e.[AddressID]

--PROBLEM 02 - Addresses with Towns
SELECT TOP(50) e.[FirstName], e.[LastName], t.[Name] AS [Town], a.[AddressText]
	FROM [Employees] e
	JOIN [Addresses] a ON e.[AddressID] = a.[AddressID]
	JOIN [Towns] t ON t.[ID] = a.[TownID]
	ORDER BY e.[FirstName], e.[LastName]

--PROBLEM 03 - Sales Employees
SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name] AS [DepartmentName]
	FROM [Employees] e
	JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
	ORDER BY e.[EmployeeID]

--PROBLEM 04 - Employee Departments
SELECT TOP(5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name] AS [DepartmentName]
	FROM [Employees] e
	JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE e.[Salary] > 15000
	ORDER BY e.[DepartmentID]

--PROBLEM 05 - Employees Without Projects
SELECT TOP(3) e.[EmployeeID], e.[FirstName]
	FROM [Employees] e
	LEFT JOIN [EmployeesProjects] ep ON e.[EmployeeID] = ep.[EmployeeID]
	WHERE ep.[EmployeeID] IS NULL
	ORDER BY e.[EmployeeID]

--PROBLEM 06 - Employees Hired After
SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName]
	FROM [Employees] e
	JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] IN ('Sales', 'Finance') AND
		e.[HireDate] > '1999-01-01'
	ORDER BY e.[HireDate]

--PROBLEM 07 - Employees with Project
SELECT TOP(5) e.[EmployeeID], e.[FirstName], p.[Name] AS [ProjectName]
	FROM [Employees] e
	JOIN [EmployeesProjects] ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects] p ON p.[ProjectID] = ep.[ProjectID]
	WHERE p.[StartDate] > '2002-08-13' AND p.[EndDate] IS NULL
	ORDER BY e.[EmployeeID]

--PROBLEM 08 - Employee 24
SELECT e.[EmployeeID], e.[FirstName],
		CASE 
			WHEN YEAR(p.[StartDate]) >= 2005 THEN NULL
			ELSE p.[Name]
		END AS [ProjectName]
	FROM [Employees] e
	JOIN [EmployeesProjects] ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects] p ON p.[ProjectID] = ep.[ProjectID]
	WHERE ep.[EmployeeID] = 24

--PROBLEM 09 - Employee Manager
SELECT e.[EmployeeID], e.[FirstName], m.[EmployeeID], m.[FirstName] AS [ManagerName]
	FROM [Employees] e
	JOIN [Employees] m ON e.[ManagerID] = m.[EmployeeID]
	WHERE m.[EmployeeID] IN (3, 7)
	ORDER BY e.[EmployeeID]

--PROBLEM 10 - Employees Summary
SELECT TOP(50) e.[EmployeeID], CONCAT_WS(' ', e.[FirstName], e.[LastName]) AS [EmployeeName],
		CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [ManagerName],
		d.[Name] AS [DepartmentName]
	FROM [Employees] e
	LEFT JOIN [Employees] m ON e.[ManagerID] = m.[EmployeeID]
	LEFT JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
	ORDER BY e.[EmployeeID]

--PROBLEM 11 - Min Average Salary
SELECT TOP(1)
		(SELECT AVG([Salary]) FROM [Employees] WHERE [DepartmentID] = d.[DepartmentID]) AS [MinAverageSalary]
	FROM [Departments] d
	ORDER BY [MinAverageSalary]

--PROBLEM 12 - Highest Peaks in Bulgaria
SELECT c.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation]
	FROM [Countries] c
	JOIN [MountainsCountries] mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN [Mountains] m ON m.[Id] = mc.[MountainId]
	JOIN [Peaks] p ON p.[MountainId] = m.[Id]
	WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
	ORDER BY p.[Elevation] DESC

--PROBLEM 13 - Count Mountain Ranges
SELECT DISTINCT c.[CountryCode], 
		(SELECT COUNT(CountryCode) FROM [MountainsCountries] mc WHERE mc.[CountryCode] = c.[CountryCode])
	FROM [Countries] c
	WHERE c.CountryCode IN ('BG', 'RU', 'US')

--PROBLEM 14 - Countries With or Without Rivers
SELECT TOP(5) c.[CountryName], r.[RiverName]
	FROM [Countries] c
	LEFT JOIN [CountriesRivers] cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] r ON r.[Id] = cr.[RiverId]
	WHERE c.[ContinentCode] = 'AF'
	ORDER BY c.[CountryName]

--PROBLEM 15 - Continents and Currencies
WITH CTE_Currencies AS 
(
	SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyUsage],
		DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY COUNT([CurrencyCode]) DESC) AS [Ranked]
	FROM [Countries]
	GROUP BY [ContinentCode], [CurrencyCode]
)

SELECT [ContinentCode], [CurrencyCode], [CurrencyUsage]
	FROM [CTE_Currencies]
	WHERE [CurrencyUsage] > 1 AND [Ranked] = 1
	ORDER BY [ContinentCode]

--PROBLEM 16 - Countries Without any Mountains
SELECT COUNT(*) AS [Count]
	FROM 
		(
			SELECT c.[CountryCode]
		FROM [Countries] c
		LEFT JOIN [MountainsCountries] mc ON c.[CountryCode] = mc.[CountryCode]
		LEFT JOIN [Mountains] m ON m.[Id] = mc.[MountainId]
		WHERE mc.[MountainId] IS NULL
		) AS CountriesWithoutMountains

--PROBLEM 17 - Highest Peak and Longest River by Country
SELECT TOP(5) c.[CountryName], 
		(MAX(p.[Elevation])) AS [HighestPeakElevation],
		(MAX(r.[Length])) AS [LongestRiverLength]
	FROM [Countries] c
	JOIN [MountainsCountries] mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN [Peaks] p ON p.[MountainId] = mc.[MountainId]
	JOIN [CountriesRivers] cr ON c.[CountryCode] = cr.[CountryCode]
	JOIN [Rivers] r ON r.[Id] = cr.[RiverId]
	GROUP BY c.[CountryName]
	ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName]

-- PROBLEM 18 - Highest Peak Name and Elevation by Country
SELECT TOP(5) [CountryName] AS [Country], ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
		ISNULL([HighestPeak], 0) AS [Highest Peak Elevation], ISNULL([MountainRange], '(no mountain)') AS [Mountain]
	FROM (
	SELECT c.[CountryName], p.[PeakName], MAX(p.[Elevation]) AS [HighestPeak], m.[MountainRange], 
		DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [Ranked]
	FROM [Countries] c
	LEFT JOIN [MountainsCountries] mc ON mc.[CountryCode] = c.[CountryCode]
	LEFT JOIN [Mountains] m ON m.[Id] = mc.[MountainId]
	LEFT JOIN [Peaks] p ON p.[MountainId] = m.[Id]
	GROUP BY c.[CountryName], p.[Elevation], p.[PeakName], m.[MountainRange]) AS g
	WHERE [Ranked] = 1
	ORDER BY [CountryName], [Highest Peak Name]