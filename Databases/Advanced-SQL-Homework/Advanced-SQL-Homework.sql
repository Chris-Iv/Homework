SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary IN 
	(SELECT MIN(Salary)
	FROM Employees)

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN
	(SELECT MIN(Salary) FROM Employees)
		AND (SELECT MIN(Salary) * 1.1 FROM Employees)

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name AS Department
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary)
	FROM Employees
	WHERE DepartmentID = e.DepartmentID)
ORDER BY d.DepartmentID

SELECT AVG(Salary) AS [Average Salary]
FROM Employees
WHERE DepartmentID = 1

SELECT AVG(Salary) AS [Average Salary in Sales Department]
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

SELECT COUNT(*) AS [Employees in Sales Department]
FROM Employees e
	JOIN Departments d
		ON e.AddressID = d.DepartmentID
WHERE d.Name = 'Sales'

SELECT COUNT(ManagerID) AS [Number of Managers]
FROM Employees

SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

SELECT d.Name AS Department, AVG(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name
ORDER BY d.Name

SELECT t.Name AS Town, d.Name AS Department, COUNT(*) AS [Employees count]
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID, d.Name, t.Name
ORDER BY d.Name

SELECT m.FirstName, m.LastName, COUNT(e.ManagerID) AS [Employees Count]
FROM Employees e
	JOIN Employees m
		ON m.EmployeeID = e.ManagerID
GROUP BY m.ManagerID, m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5

SELECT e.FirstName + ' ' + e.LastName AS Employee,
		 ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
FROM Employees e
	JOIN Employees m
		ON m.EmployeeID = e.ManagerID

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

SELECT CONVERT(nvarchar, GETDATE(), 4) + ' '
	+ CONVERT(nvarchar, GETDATE(), 114) AS DateTime

CREATE TABLE Users (
	UserID int IDENTITY,
	Username nvarchar(100) NOT NULL,
	[Password] nvarchar(100) NOT NULL,
	FullName nvarchar(100) NOT NULL,
	LastLoginTime smalldatetime,
	CONSTRAINT PK_UserID PRIMARY KEY(UserID),
	CONSTRAINT chk_Password CHECK (LEN(Password) > 5))
GO

CREATE VIEW [SHOW USERS] AS
SELECT * FROM Users
GO
SELECT * FROM [SHOW USERS]
GO

CREATE TABLE Groups (
	Id int IDENTITY,
	Name nvarchar(100) NOT NULL,
	CONSTRAINT PK_Id PRIMARY KEY(Id),
	CONSTRAINT UK_Name UNIQUE(Name))

ALTER TABLE Users
ADD GroupId int FOREIGN KEY REFERENCES Groups(Id)

INSERT INTO Groups
VALUES ('pepi')

INSERT INTO Groups
VALUES ('Desi')

INSERT INTO Groups
VALUES ('Mimi')

INSERT INTO Users (UserName, Password, FullName, LastLoginTime)
VALUES ('pepi', '123456', 'pepi pepov', '2015-02-15')

INSERT INTO Users (UserName, Password, FullName, LastLoginTime)
VALUES ('Desi', '123456', 'Desislava Painerova', '2015-02-14')

INSERT INTO Users (UserName, Password, FullName, LastLoginTime)
VALUES ('Mimi', '123456', 'Mara Otvarachkata', '2015-02-15')

UPDATE Groups
SET Name = 'Mara'
WHERE Name = 'Mimi'

UPDATE Users
SET UserName = 'Mara', GroupId = 2
WHERE UserName = 'Mimi'

Delete Users
WHERE UserName = 'Mara'

Delete Groups
WHERE Name = 'Mara'

INSERT INTO Users
SELECT LOWER(LEFT(FirstName, 1) + LEFT(LastName, 1)) AS UserName,
	LOWER(LEFT(FirstName, 1) + LEFT(LastName, 1)+ '1234') AS Password,
	FirstName + ' ' + LastName as FullName,
	NULL AS LastLoginTime,
	2 AS GroupId
FROM Employees

UPDATE Users
SET Password = NULL
WHERE LastLoginTime <= CAST('2013-10-03' AS smalldatetime);

Delete Users
WHERE Password IS NULL

SELECT d.Name, JobTitle, AVG(Salary) AS [Average Employee Salary]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, JobTitle

SELECT FirstName, LastName, d.Name, Salary
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
WHERE Salary =
	(SELECT MIN(Salary) FROM Employees
	WHERE DepartmentID = e.DepartmentID)
GROUP BY d.Name, FirstName, LastName, Salary
ORDER BY d.Name

SELECT t.Name AS Town, COUNT(t.TownID) AS [Number of employees]
FROM Employees e
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name, t.TownID

SELECT mt.Town, COUNT(*) AS [Number of manager]
FROM (SELECT DISTINCT e.EmployeeID, e.FirstName, e.LastName, t.Name AS Town
FROM Employees e
	JOIN Employees m
		ON m.ManagerID = e.EmployeeID
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID) AS mt
GROUP BY mt.Town
ORDER BY mt.Town

CREATE TABLE WorkHours
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeId) NOT NULL,
	Date datetime NULL,
	Task nvarchar(150) NOT NULL,
	Hours int NOT NULL,
	Comments ntext NULL
)
GO

CREATE TABLE WorkHoursLogs
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	Message nvarchar(150) NOT NULL,
	DateOfChange datetime NOT NULL
	)
GO

CREATE TRIGGER tr_WorkHoursInsert
ON WorkHours
	FOR INSERT
AS
	INSERT INTO WorkHoursLogs (Message, DateOfChange)
	VALUES('Added row', GETDATE ( ))
GO

CREATE TRIGGER tr_WorkHoursDelete
ON WorkHours
	FOR DELETE
AS
	INSERT INTO WorkHoursLogs (Message, DateOfChange)
	VALUES('Deleted row', GETDATE ( ))
GO

CREATE TRIGGER tr_WorkHoursUpdate
ON WorkHours
	FOR UPDATE
AS
	INSERT INTO WorkHoursLogs (Message, DateOfChange)
	VALUES('Update row', GETDATE ( ))
GO

INSERT INTO WorkHours (EmployeeId, Date, Task, Hours)
	VALUES(10, GETDATE ( ), 'Bla-Bla', 10)

INSERT INTO WorkHours (EmployeeId, Date, Task, Hours)
	VALUES(11, GETDATE ( ), 'Bla-Bla-2', 100)

DELETE WorkHours
WHERE EmployeeId = 10

UPDATE WorkHours
SET Task = 'Bla-Bla Ura-a-a'
WHERE EmployeeId = 11

SELECT * FROM WorkHoursLogs

BEGIN TRAN
DELETE Employees
WHERE DepartmentID =
	(SELECT DepartmentID
	FROM Departments
	WHERE Name = 'Sales')
SELECT * FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ROLLBACK TRAN

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

SELECT * INTO ##TempTableProjects
FROM EmployeesProjects
	DROP TABLE EmployeesProjects
	CREATE TABLE EmployeesProjects
	(
		EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
		ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID) NOT NULL,
	)
INSERT INTO EmployeesProjects
SELECT * FROM ##TempTableProjects