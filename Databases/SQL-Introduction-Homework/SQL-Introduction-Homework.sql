SELECT * FROM Departments

SELECT Name FROM Departments

SELECT FirstName, LastName, Salary FROM Employees

SELECT FirstName + ' ' + LastName AS [Full Name] FROM Employees

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Addresses] FROM Employees

SELECT DISTINCT Salary FROM Employees

SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT FirstName, LastName
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

SELECT TOP 5 FirstName, LastName, Salary
FROM Employees
ORDER BY Salary DESC

SELECT FirstName, LastName, a.AddressText, t.Name AS Town
FROM Employees e
		JOIN Addresses a
				ON e.AddressID = a.AddressID
		JOIN Towns t
				ON a.TownID = t.TownID

SELECT FirstName, LastName, a.AddressText, t.Name AS Town
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
		JOIN Employees m
				ON e.ManagerID = m.EmployeeID

SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Name], a.AddressText
FROM Employees e
		JOIN Employees m
				ON e.ManagerID = m.EmployeeID
		JOIN Addresses a
				ON e.AddressID = a.AddressID

SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
		RIGHT OUTER JOIN Employees m
				ON e.ManagerID = m.EmployeeID

SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
		LEFT OUTER JOIN Employees m
				ON e.ManagerID = m.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.Name
FROM Employees e, Departments d
 WHERE (e.HireDate BETWEEN '1995' AND '2005') AND 
		(e.DepartmentID = d.DepartmentID) AND
		(d.Name = 'Sales' OR d.Name = 'Finances')