SELECT Title
FROM Ads
ORDER BY Title

SELECT Title, Date
FROM Ads
WHERE Date BETWEEN '26-Dec-2014' AND '2-Jan-2015'
ORDER BY Date

SELECT Title, Date, 
	CASE
		WHEN ImageDataURL IS NOT NULL THEN 'yes'
		WHEN ImageDataURL IS NULL THEN 'no'
	END AS [Has Image]
FROM Ads
ORDER BY Id

SELECT *
FROM Ads
WHERE TownId IS NULL
	OR CategoryId IS NULL
	OR ImageDataURL IS NULL
ORDER BY Id

SELECT a.Title, t.Name AS Town
FROM Ads a
	LEFT OUTER JOIN Towns t
		ON a.TownId = t.Id
ORDER BY a.Id

SELECT a.Title, c.Name AS CategoryName, t.Name AS TownName, s.Status
FROM Ads a
	LEFT OUTER JOIN Categories c
		ON a.CategoryId = c.Id
	LEFT OUTER JOIN Towns t
		ON a.TownId = t.Id
	LEFT OUTER JOIN AdStatuses s
		ON a.StatusId = s.Id
ORDER BY a.Id

SELECT a.Title, c.Name AS CategoryName, t.Name AS TownName, s.Status
FROM Ads a
	LEFT OUTER JOIN Categories c
		ON a.CategoryId = c.Id
	LEFT OUTER JOIN Towns t
		ON a.TownId = t.Id
	LEFT OUTER JOIN AdStatuses s
		ON a.StatusId = s.Id
WHERE s.Status = 'Published'
	AND t.Name IN ('Sofia', 'Stara Zagora', 'Blagoevgrad')
ORDER BY a.Title

SELECT MIN(Date) AS MinDate, MAX(Date) AS MaxDate
FROM Ads

SELECT TOP 10 a.Title, a.Date, s.Status
FROM Ads a
	JOIN AdStatuses s
		ON a.StatusId = s.Id
ORDER BY a.Date DESC

SELECT a.Id, a.Title, a.Date, s.Status
FROM Ads a
	JOIN AdStatuses s
		ON a.StatusId = s.Id
WHERE s.Status != 'Published'
	AND MONTH(Date) = (SELECT MONTH(MIN(Date)) FROM Ads)
	AND YEAR(Date) = (SELECT YEAR(MIN(Date)) FROM Ads)
ORDER BY a.Id

SELECT s.Status, COUNT(*) AS Count
FROM Ads a
	JOIN AdStatuses s
		ON a.StatusId = s.Id
GROUP BY s.Status
ORDER BY s.Status

SELECT t.Name AS [Town Name], s.Status, COUNT(*) AS Count
FROM Ads a
	JOIN Towns t
		ON a.TownId = t.Id
	JOIN AdStatuses s
		ON a.StatusId = s.Id
GROUP BY t.Name, s.Status
ORDER BY t.Name, s.Status

SELECT u.UserName, COUNT(*) AS AdsCount, 
	CASE 
		WHEN r.Name = 'Administrator' THEN 'yes'
		ELSE 'no'
	END AS IsAdministrator
FROM Ads a
	LEFT OUTER JOIN AspNetUsers u
		ON a.OwnerId = u.Id
	LEFT OUTER JOIN AspNetUserRoles ur
		ON u.Id = ur.UserId
	LEFT OUTER JOIN AspNetRoles r
		ON ur.RoleId = r.Id
GROUP BY u.UserName, r.Name
ORDER BY u.UserName

SELECT COUNT(*) AS AdsCount, ISNULL(t.Name, '(no town)') AS Town
FROM Ads a
	LEFT OUTER JOIN Towns t
		ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Id) BETWEEN 2 AND 3
ORDER BY t.Name

SELECT a.Date AS FirstDate, b.Date AS SecondDate
FROM Ads a
	JOIN Ads b
		ON a.Date < b.Date
WHERE DATEDIFF(hour, a.Date, b.Date) < 12
ORDER BY a.Date, b.Date