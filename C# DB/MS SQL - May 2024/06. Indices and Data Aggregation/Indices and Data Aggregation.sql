--Lab
USE [SoftUni1]
SELECT [DepartmentID], COUNT(*) AS [Count], STRING_AGG([LastName], ', ') AS [EmployeesSurnames],
		MIN([Salary]) AS [MinSalary], MAX([Salary]) AS [MaxSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]

--PROBLEM 01 - Departments Total Salaries Over 150000
SELECT d.[Name], SUM([Salary]) AS [TotalSalaries], COUNT(*) AS [EmployeesTotalCount],
		COUNT(e.[Salary]) AS [CountNotNull], COUNT(DISTINCT e.[LastName]) AS [UniqueNames],
		AVG(e.[Salary]) AS [AverageSalary], STDEV(e.[Salary]) AS [StDev], MAX(e.[Salary]) - MIN(e.[Salary]) AS [Range]
	FROM [Employees] e
	JOIN [Departments] d ON d.[DepartmentID] = e.[DepartmentID]
	GROUP BY d.[Name]
	HAVING SUM([Salary]) > 150000

--Exercises
--PROBLEM 01 - Records’ Count
USE [Gringotts]
SELECT COUNT(*) AS [Count]
	FROM [WizzardDeposits]

--PROBLEM 02 - Longest Magic Wand
SELECT TOP(1) [MagicWandSize] AS [LongestMagicWand]
	FROM [WizzardDeposits]
	ORDER BY [MagicWandSize] DESC

--PROBLEM 03 - Longest Magic Wand per Deposit Groups
SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]

--PROBLEM 04 - Smallest Deposit Group Per Magic Wand Size
SELECT TOP(2) [DepositGroup]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]
	ORDER BY AVG([MagicWandSize])

--PROBLEM 05 - Deposits Sum
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup]

--PROBLEM 06 - Deposits Sum for Ollivander Family
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]

--PROBLEM 07 - Deposits Filter
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]
	HAVING SUM([DepositAmount]) < 150000
	ORDER BY SUM([DepositAmount]) DESC

--PROBLEM 08 - Deposit Charge
SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup], [MagicWandCreator]
	ORDER BY [MagicWandCreator], [DepositGroup]

--PROBLEM 09 - Age Groups
SELECT w.[AgeGroup], COUNT(w.[AgeGroup]) AS [WizzardCount]
	FROM (SELECT CASE
			WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]' 
		END AS [AgeGroup]
	FROM [WizzardDeposits]) AS w
	GROUP BY w.[AgeGroup]

--PROBLEM 10 - First Letter
SELECT LEFT([FirstName], 1) AS [FirstLetter]
	FROM [WizzardDeposits]
	GROUP BY LEFT([FirstName], 1)
	ORDER BY LEFT([FirstName], 1)

--PROBLEM 11 - Average Interest
SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest]) AS [AverageInterest]
	FROM [WizzardDeposits]
	WHERE [DepositStartDate] > '1985-01-01'
	GROUP BY [DepositGroup], [IsDepositExpired]
	ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--PROBLEM 12 - Rich Wizard, Poor Wizard
SELECT SUM(k.[SumDifference]) AS [SumDifference]
	FROM (SELECT [Host].[DepositAmount] - LEAD([Host].[DepositAmount], 1) OVER (ORDER BY [Host].[Id]) AS [SumDifference]
	FROM [WizzardDeposits] AS Host) AS k

--PROBLEM 13 - Departments Total Salaries
USE [SoftUni1]
SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
	ORDER BY [DepartmentID]

--PROBLEM 14 - Employees Minimum Salaries
SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary]
	FROM [Employees]
	WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '2000-01-01'
	GROUP BY [DepartmentID]

--PROBLEM 15 - Employees Average Salaries
SELECT * INTO [EmployeesNewTable]
	FROM [Employees]
	WHERE [Salary] > 30000

DELETE 
	FROM [EmployeesNewTable]
	WHERE [ManagerID] = 42

UPDATE [EmployeesNewTable]
	SET [Salary] = [Salary] + 5000
	WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary]
	FROM [EmployeesNewTable]
	GROUP BY [DepartmentID]

--PROBLEM 16 - Employees Maximum Salaries
SELECT [DepartmentID], MAX([Salary]) AS [MaxSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
	HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--PROBLEM 17 - Employees Count Salaries
SELECT COUNT(*) AS [Count]
	FROM [Employees]
	WHERE [ManagerID] IS NULL

--PROBLEM 18 - 3rd Highest Salary
SELECT DISTINCT e.[DepartmentID], e.[Salary]
	FROM(SELECT [DepartmentID], [Salary],
				DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Ranked]
			FROM [Employees]) AS e
	WHERE e.[Ranked] = 3

--PROBLEM 19 - Salary Challenge
SELECT TOP(10) e.[FirstName], e.[LastName], e.[DepartmentID]
	FROM [Employees] e
	WHERE e.[Salary] > (SELECT AVG([Salary])
				FROM [Employees]
				WHERE [DepartmentID] = e.[DepartmentID]
				GROUP BY [DepartmentID])
	ORDER BY e.[DepartmentID]
