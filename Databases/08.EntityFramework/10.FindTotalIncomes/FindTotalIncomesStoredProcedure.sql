USE Northwind
GO

IF OBJECT_ID('dbo.usp_FindTotalIncomesOfSupplier', 'P') IS NOT NULL
    DROP PROC dbo.usp_FindTotalIncomesOfSupplier;
GO

CREATE PROC dbo.usp_FindTotalIncomesOfSupplier
	@supplierName nvarchar(MAX),
    @startDate DATETIME,
    @endDate DATETIME
AS
	SET NOCOUNT ON

	SELECT SUM(od.UnitPrice) AS TotalIncomes
    FROM Suppliers s
    JOIN Products p
        ON p.SupplierID = s.SupplierID
    JOIN [Order Details] od
        ON od.ProductID = p.ProductID
    JOIN Orders o
        ON o.OrderID = od.OrderID
    WHERE s.CompanyName = @supplierName AND (o.OrderDate BETWEEN @startDate AND @endDate)
	RETURN
GO

DECLARE @supplierName nvarchar(MAX) = 'Exotic Liquids'
DECLARE @startDate DATETIME = CAST('1/1/1996' AS DATETIME);
DECLARE @endDate DATETIME = CAST('12/31/2000' AS DATETIME);
EXEC usp_FindTotalIncomesOfSupplier @supplierName, @startDate, @endDate
GO