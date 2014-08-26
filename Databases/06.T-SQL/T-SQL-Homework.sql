--- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
--- and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
--- Write a stored procedure that selects the full names of all persons.

--- The database name is Accounts

--- Persons and Accounts tables creation
CREATE TABLE Persons
(
	PersonId int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(30) NOT NULL
);
GO

CREATE TABLE Accounts
(
	AccountId int IDENTITY PRIMARY KEY,
	PersonId int NOT NULL,
	Balance money,
	CONSTRAINT FK_PERSONS_ACCOUNTS
		FOREIGN KEY (PersonId) REFERENCES Persons (PersonId)
);
GO

--- Add 30 persons and 30 accounts to tables
DECLARE @counter int;
SET @counter = 30;
WHILE @counter > 0
BEGIN
    INSERT INTO Persons(FirstName, LastName, SSN)
    VALUES ('FirstName ' + CONVERT(varchar(10), @counter),
            'LastName ' + CONVERT(varchar(10), @counter),
             @counter + 987654)
    SET @counter = @counter - 1
END
GO

DECLARE @counter int;
SET @counter = 30;
WHILE @counter > 0
BEGIN
	DECLARE @randomBalance money
	DECLARE @balanceLowerBound int = 100
	DECLARE @balanceUpperBound int = 20000
    DECLARE @randomPersonId int
	DECLARE @idLowerBound int = 1
	DECLARE @idUpperBound int = 30

	SELECT @randomBalance = ROUND(((@balanceUpperBound - @balanceLowerBound - 1) * RAND() + @balanceLowerBound), 0)
    SELECT @randomPersonId = ROUND(((@idUpperBound - @idLowerBound - 1) * RAND() + @idLowerBound), 0)

    INSERT INTO Accounts(PersonId, Balance)
    VALUES (@randomPersonId, @randomBalance)
    SET @counter = @counter - 1
END
GO

--- Creates stored procedure
CREATE PROC usp_SelectFullNameOfPersons
AS
    SELECT CONCAT(FirstName, ' ', LastName) AS FullName
    FROM Persons
GO

EXEC usp_SelectFullNameOfPersons;
GO

--- 2. Create a stored procedure that accepts a number as a parameter and 
--- returns all persons who have more money in their accounts than the supplied number.

CREATE PROC usp_SelectPersonsWithBalance(@minMoneyInAccount money = 100)
AS
    SELECT p.FirstName, p.LastName, p.SSN, a.Balance
    FROM Persons p
    JOIN Accounts a
        ON p.PersonId = a.PersonId
    WHERE a.Balance >= @minMoneyInAccount
    ORDER BY a.Balance
GO

EXEC usp_SelectPersonsWithBalance;
EXEC usp_SelectPersonsWithBalance 10000;

--- 3. Create a function that accepts as parameters – sum, yearly interest rate 
--- and number of months. It should calculate and return the new sum. Write a SELECT
--- to test whether the function works as expected.
USE TelerikAcademy
GO

CREATE FUNCTION dbo.ufn_CalculateBonus(@sum money, @yearlyInterestRate float, @numOfMonths int)
    RETURNS money
AS
BEGIN
    RETURN @sum + (@yearlyInterestRate / 12) * @numOfMonthS * @sum
END
GO

SELECT Salary, dbo.ufn_CalculateBonus(Salary / 12, 0.1, DATEDIFF(month, HireDate, GETDATE())) as Bonus
FROM Employees

--- 4. Create a stored procedure that uses the function from the 
--- previous example to give an interest to a person's account for one
--- month. It should take the AccountId and the interest rate as parameters.
USE Accounts
GO

CREATE PROC dbo.usp_CalculateBonusForOneMonth(@accountId int, @yearlyInterestRate float)
AS
    DECLARE @balance money
    SELECT @balance = Balance FROM Accounts WHERE AccountId = @accountId

    DECLARE @newBalance money;
    SELECT @newBalance = dbo.ufn_CalculateBonus(@balance, @yearlyInterestRate, 1)

    SELECT p.FirstName, p.LastName, a.Balance, @newBalance AS NewBalance
    FROM Accounts a
    JOIN Persons p
        ON a.PersonId = p.PersonId
    WHERE a.AccountId = @accountId
GO

EXEC usp_CalculateBonusForOneMonth 20, 0.1;
GO

--- 5. Add two more stored procedures WithdrawMoney( AccountId, money) 
--- and DepositMoney (AccountId, money) that operate in transactions.
USE Accounts
GO

CREATE PROC usp_WithdrawMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance -= @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO

CREATE PROC usp_DepositMoney(@accountId int, @money money)
AS
    BEGIN TRAN
        UPDATE Accounts
        SET Balance += @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO

EXEC usp_WithdrawMoney 1, 1000

EXEC usp_DepositMoney 2, 2000

--- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--- Add a trigger to the Accounts table that enters a new entry into the
--- Logs table every time the sum on an account changes.

--- Create table Logs
CREATE TABLE Logs (
    LogId int IDENTITY PRIMARY KEY,
    AccountId int NOT NULL,
    OldSum money NOT NULL,
    NewSum money NOT NULL,
    CONSTRAINT FK_Logs_Accounts
        FOREIGN KEY (AccountId)
        REFERENCES Accounts(AccountId)
);
GO

--- Create trigger on Accounts update
CREATE TRIGGER tr_UpdateAccountBalance ON Accounts FOR UPDATE
AS
    DECLARE @oldSum money;
    SELECT @oldSum = Balance FROM deleted;

    INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT AccountId, @oldSum, Balance
        FROM inserted
GO

EXEC usp_WithdrawMoney 1, 1000

EXEC usp_DepositMoney 2, 2000

--- 7. Define a function in the database TelerikAcademy that returns 
--- all Employee's names (first or middle or last name) and all town's 
--- names that are comprised of given set of letters. Example 'oistmiahf' 
--- will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.