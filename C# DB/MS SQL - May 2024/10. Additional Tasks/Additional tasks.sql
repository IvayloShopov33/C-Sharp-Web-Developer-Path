--Additional tasks
--PROBLEM 01 - Number of Users for Email Provider
SELECT g.[EmailProvider], COUNT(*) AS [Number Of Users]
	FROM (SELECT RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [EmailProvider]
		FROM [Users]) AS g
	GROUP BY [EmailProvider]
	ORDER BY [Number Of Users] DESC, g.[EmailProvider]

--PROBLEM 02 - All Users in Games
SELECT g.[Name], gt.[Name], u.[Username], ug.[Level], ug.[Cash], c.[Name]
	FROM [UsersGames] ug
	JOIN [Users] u ON u.[Id] = ug.[UserId]
	JOIN [Games] g ON g.[Id] = ug.[GameId]
	JOIN [GameTypes] gt ON gt.[Id] = g.[GameTypeId]
	JOIN [Characters] c ON c.[Id] = ug.[CharacterId]
	ORDER BY ug.[Level] DESC, u.[Username], g.[Name]

--PROBLEM 03 - Users in Games with Their Items
SELECT u.[Username], g.[Name], COUNT(i.[Id]) AS [Items Count], SUM(i.[Price]) AS [Items Price]
	FROM [Games] g
	JOIN [UsersGames] ug ON ug.[GameId] = g.[Id]
	JOIN [Users] u ON u.[Id] = ug.[UserId]
	JOIN [UserGameItems] ugi ON ugi.[UserGameId] = ug.[Id]
	JOIN [Items] i ON i.[Id] = ugi.[ItemId]
	GROUP BY u.[Username], g.[Name]
	HAVING COUNT(i.[Id]) >= 10
	ORDER BY [Items Count] DESC, [Items Price] DESC, u.[Username]

--PROBLEM 05 - All Items with Greater than Average Statistics
DECLARE @AvgLuck DECIMAL = (SELECT AVG([Luck]) FROM [Statistics]);
DECLARE @AvgMind DECIMAL = (SELECT AVG([Mind]) FROM [Statistics]);
DECLARE @AvgSpeed DECIMAL = (SELECT AVG([Speed]) FROM [Statistics]);

SELECT i.[Name], i.[Price], i.[MinLevel], s.[Strength], 
		s.[Defence], s.[Speed], s.[Luck], s.[Mind]
	FROM [Items] i
	JOIN [Statistics] s ON s.[Id] = i.[StatisticId]
	WHERE s.[Luck] > @AvgLuck AND s.[Mind] > @AvgMind AND s.[Speed] > @AvgSpeed
	ORDER BY i.[Name]

--PROBLEM 06 - Display All Items about Forbidden Game Type
SELECT i.[Name], i.[Price], i.[MinLevel], gt.[Name]
	FROM [Items] i
	LEFT JOIN [GameTypeForbiddenItems] fi ON fi.[ItemId] = i.[Id]
	LEFT JOIN [GameTypes] gt ON gt.[Id] = fi.[GameTypeId]
	ORDER BY gt.[Name] DESC, i.[Name]

--PROBLEM 08 - Peaks and Mountains
SELECT p.[PeakName], m.[MountainRange], p.[Elevation]
	FROM [Peaks] p
	JOIN [Mountains] m ON m.[Id] = p.[MountainId]
	ORDER BY p.[Elevation] DESC, p.[PeakName]

--PROBLEM 09 - Peaks with Mountain, Country and Continent
SELECT p.[PeakName], m.[MountainRange], c.[CountryName], co.[ContinentName]
	FROM [Peaks] p
	JOIN [Mountains] m ON m.[Id] = p.[MountainId]
	JOIN [MountainsCountries] mc ON mc.[MountainId] = m.[Id]
	JOIN [Countries] c ON c.[CountryCode] = mc.[CountryCode]
	JOIN [Continents] co ON co.[ContinentCode] = c.[ContinentCode]
	ORDER BY p.[PeakName], c.[CountryName]

--PROBLEM 10 - Rivers by Country
SELECT c.[CountryName], co.[ContinentName], 
		ISNULL(COUNT(r.[Id]), 0) AS [RiversCount], ISNULL(SUM(r.[Length]), 0) AS [TotalLength]
	FROM [Countries] c
	LEFT JOIN [CountriesRivers] cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] r ON r.[Id] = cr.[RiverId]
	JOIN [Continents] co ON co.[ContinentCode] = c.[ContinentCode]
	GROUP BY c.[CountryName], co.[ContinentName]
	ORDER BY [RiversCount] DESC, [TotalLength] DESC, c.[CountryName]

--PROBLEM 11 - Count of Countries by Currency
SELECT cu.[CurrencyCode], cu.[Description] AS [Currency], COUNT(c.[CountryCode]) AS [NumberOfCountries]
	FROM [Currencies] cu
	LEFT JOIN [Countries] c ON c.[CurrencyCode] = cu.[CurrencyCode]
	GROUP BY cu.[CurrencyCode], cu.[Description]
	ORDER BY [NumberOfCountries] DESC, cu.[Description]

--PROBLEM 12 - Population and Area by Continent
SELECT co.[ContinentName], SUM(c.[AreaInSqKm]) AS [CountriesArea], SUM(CAST(c.[Population] AS BIGINT)) AS [CountriesPopulation]
	FROM [Continents] co
	JOIN [Countries] c ON c.[ContinentCode] = co.[ContinentCode]
	GROUP BY co.[ContinentName]
	ORDER BY [CountriesPopulation] DESC