-- Task 1 - Write a SQL query to find the names and salaries of the employees 
--			that take the minimal salary in the company. Use a nested SELECT statement.
SELECT CONCAT(FirstName, ' ', LastName) AS Employee, Salary FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- Task 2 - Write a SQL query to find the names and salaries of the employees
--			that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT CONCAT(FirstName, ' ', LastName) AS Employee, Salary FROM Employees
WHERE Salary <= (SELECT MIN(Salary) FROM Employees) * 1.1

-- Task 3 - Write a SQL query to find the full name, salary and department of the employees
--			that take the minimal salary in their department. Use a nested SELECT statement.
SELECT CONCAT(FirstName, ' ', LastName) AS FullName, Salary, d.Name
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary)
	FROM Employees
	WHERE DepartmentID = e.DepartmentID)

-- Task 4 - Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS AvarageSalary
FROM Employees
WHERE DepartmentID = 1

-- Task 5 - Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary) AS AvarageSalary
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- Task 6 - Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID) AS EmployeesCount
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- Task 7 - Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(EmployeeID) AS [Employees With Manager Count]
FROM Employees
	WHERE ManagerID IS NOT NULL

-- Task 8 - Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(EmployeeID) AS [Employees With Manager Count]
FROM Employees
	WHERE ManagerID IS NULL

-- Task 9 - Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS Department, AVG(Salary) AS AvarageSalary
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- Task 10 - Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS Department, t.Name AS Town, COUNT(*) AS EmployeesCount
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY d.Name, t.Name

-- Task 11 - Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS ManagerName, COUNT(*) EmployeesCount
FROM Employees e JOIN Employees em
	ON e.EmployeeID = em.ManagerID
GROUP BY e.FirstName, e.LastName
	HAVING COUNT(*) = 5

-- Task 12 - Write a SQL query to find all employees along with their managers.
--			 For employees that do not have manager display the value "(no manager)".
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	ISNULL(em.FirstName + ' ' + em.LastName, 'no manager' ) AS Manager
FROM Employees e
LEFT OUTER JOIN Employees em
ON e.ManagerID = em.EmployeeID

-- Task 13 - Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
--			 Use the built-in LEN(str) function.
SELECT CONCAT(FirstName, ' ', LastName) AS FullName
FROM Employees
WHERE LEN(LastName) = 5

-- Task 14 - Write a SQL query to display the current date and time in the following format
--			 "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
SELECT CONCAT(CONVERT(VARCHAR(15), GETDATE(), 104), ' ', CONVERT(VARCHAR(25), GETDATE(), 114)) AS Date


-- Task 15 - Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--			 Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--			 Define the primary key column as identity to facilitate inserting records.
--			 Define unique constraint to avoid repeating usernames.
--			 Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users
(
	UserId int IDENTITY(1, 1),
	Username nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLogin DateTime,
	CONSTRAINT PK_Users PRIMARY KEY(UserId), 
	CONSTRAINT PK_Password CHECK (LEN(Password) >= 5),
	CONSTRAINT UK_UsersName UNIQUE(Username)
)
GO

-- Task 16 - Write a SQL statement to create a view that displays the users from the Users table
--			 that have been in the system today. Test if the view works correctly.
INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('Peshoo', 'kirkata', 'Pesho Kirkata', GETDATE())

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('Gosho', 'ludiqq', 'Gosho Ludiq', GETDATE())

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('Mariq', 'mimeto', 'Mariq Mimcheva', GETDATE())

INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('Stamat', 'password', 'Stamat Stamatov', '2010-1-1')
GO

CREATE VIEW RecentUsers
AS
	SELECT Username, LastLogin
	FROM Users
	WHERE DAY(GETDATE() - LastLogin) = 1
GO

-- Task 17 - Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--			 Define primary key and identity column.
CREATE TABLE Groups
(
	GroupId int IDENTITY,
	Name nvarchar(30) NOT NULL,
	CONSTRAINT PK_GroupId PRIMARY KEY(GroupId),
	CONSTRAINT UK_GroupsName UNIQUE(Name)
)
GO

-- Task 18 - Write a SQL statement to add a column GroupID to the table Users.
--			 Fill some data in this new column and as well in the Groups table. 
--			 Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
INSERT INTO Groups(Name)
VALUES ('FirstGroup')

INSERT INTO Groups(Name)
VALUES ('SecondGroup')
GO

ALTER TABLE Users
ADD GroupId int
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId)
REFERENCES Groups(GroupId)
GO

UPDATE Users
SET GroupId = 1
GO

-- Task 19 - Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups(Name)
VALUES ('ThirdGroup'),
	('FourthGroup')

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupId)
VALUES ('Pavliken', 'pavkata', 'Pavel Ivanov', GETDATE(), 2),
	('Dimitrin', 'mitaka', 'Dimitar Dimitrov', GETDATE(), 4),
	('Kalkata', 'kalata', 'Kaloqn Kaloqnov', GETDATE(), 1)
GO

-- Task 20 - Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username = 'Dimo Updated'
WHERE Username = 'Dimitrin'

UPDATE Users
SET Username = 'Mariq Updated'
WHERE FullName = 'Mariq Mimcheva'

UPDATE Groups
SET Name = 'First Group Updated'
WHERE Name = 'FirstGroup'
GO

-- Task 21 - Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username LIKE '%sho%'

DELETE FROM Groups
WHERE Name = 'ThirdGroup'
GO

-- Task 22 - Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--			 Combine the first and last names as a full name. 
--			 For username use the first letter of the first name + the last name (in lowercase).
--			 Use the same for the password, and NULL for last login time.
ALTER TABLE Users
DROP CONSTRAINT UK_UsersName

INSERT Users (Username, Password, FullName, LastLogin)
SELECT CONVERT(nvarchar, EmployeeID) + LEFT(FirstName, 1) + LOWER(LastName),
	CONVERT(nvarchar, EmployeeID) + LEFT(FirstName, 1) + LOWER(LastName),
	CONCAT(FirstName, ' ', LastName),
	NULL
FROM Employees  

ALTER TABLE Users
ADD CONSTRAINT UK_UsersName UNIQUE(Username)

GO

-- Task 23 - Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
INSERT INTO Users(Username, Password, FullName, LastLogin)
VALUES ('Asq', 'asetoo', 'Asq Simeonova', '2009-03-10'),
	('Asenq', 'asetoo', 'Asenq Simeonova', '2006-07-10'),
	('Traicho', 'traioo', 'Traicho Traichev', '2003-03-10')

UPDATE Users
SET Password = '123456'
WHERE LastLogin < '2010-03-10'


-- Task 24 - Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Password = '123456'

-- Task 25 - Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name AS Department, e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- Task 26 - Write a SQL query to display the minimal employee salary by department and job title
--			 along with the name of some of the employees that take it.
SELECT MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS FullName, MIN(e.Salary) AS MinSalary, d.Name AS Department, e.JobTitle
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- Task 27 - Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(t.TownID) AS EmployeesCount
FROM Employees e JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
	ORDER BY EmployeesCount DESC

-- Task 28 - Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*) AS ManagersCount
FROM Employees e JOIN Addresses a
	ON e.EmployeeID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	WHERE e.ManagerID IS NOT NULL
GROUP BY t.Name
ORDER BY ManagersCount

-- Task 29 - Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, Task, hours, comments). 
--			 Don't forget to define  identity, primary key and appropriate foreign key. 
--			 Issue few SQL statements to insert, update and delete of some data in the table.
--			 Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--			 For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours (
    WorkReportId int IDENTITY,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours Int NOT NULL,
    Comments nvarchar(256),
    CONSTRAINT PK_Id PRIMARY KEY(WorkReportId),
    CONSTRAINT FK_Employees_WorkHours 
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId)
) 
GO

-- insert, update and delete of some data in the table
DECLARE @counter int;
SET @counter = 20;
WHILE @counter > 0
BEGIN
    INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
    VALUES (@counter, GETDATE(), 'TASK: ' + CONVERT(varchar(10), @counter), @counter)
    SET @counter = @counter - 1
END

UPDATE WorkHours
SET Comments = 'Work harder!'
WHERE [Hours] > 10

DELETE FROM WorkHours
WHERE EmployeeId IN (1, 3, 5, 7, 13)

-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
CREATE TABLE WorkHoursLogs (
    WorkLogId int,
    EmployeeId Int NOT NULL,
    OnDate DATETIME NOT NULL,
    Task nvarchar(256) NOT NULL,
    Hours int NOT NULL,
    Comments nvarchar(256),
    [Action] nvarchar(50) NOT NULL,
    CONSTRAINT FK_Employees_WorkHoursLogs
        FOREIGN KEY (EmployeeId)
        REFERENCES Employees(EmployeeId),
    CONSTRAINT [CC_WorkReportsLogs] CHECK ([Action] IN ('Insert', 'Delete', 'DeleteUpdate', 'InsertUpdate'))
) 
GO

-- insert trigger
CREATE TRIGGER tr_InsertWorkReports ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Insert'
    FROM inserted
GO

-- delete trigger
CREATE TRIGGER tr_DeleteWorkReports ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'Delete'
    FROM deleted
GO

-- update trigger
CREATE TRIGGER tr_UpdateWorkReports ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'InsertUpdate'
    FROM inserted

-- triggers test
INSERT INTO WorkHoursLogs(WorkLogId, EmployeeId, OnDate, Task, [Hours], Comments, [Action])
    SELECT WorkReportId, EmployeeID, OnDate, Task, [Hours], Comments, 'DeleteUpdate'
    FROM deleted
GO

DELETE FROM WorkHoursLogs

INSERT INTO WorkHours(EmployeeId, OnDate, Task, [Hours])
VALUES (25, GETDATE(), 'TASK: 25', 25)

DELETE FROM WorkHours
WHERE EmployeeId = 25

UPDATE WorkHours
SET Comments = 'Updated'
WHERE EmployeeId = 2

-- Task 30 - Start a database transaction, delete all employees from the 'Sales' department
--			 along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
GO

DELETE e FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

ROLLBACK TRAN
COMMIT TRAN


-- Task 31 - Start a database transaction and drop the table EmployeesProjects. 
--			 Now how you could restore back the lost table data?
BEGIN TRANSACTION

DROP TABLE EmployeesProjects

ROLLBACK TRANSACTION
COMMIT TRANSACTION