SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [SalesLT].[getProductById]
@ProductID INT
AS
SELECT ProductID
      ,Name
      ,ProductNumber
      ,Color
      ,StandardCost
      ,ListPrice
      ,Size
      ,Weight
FROM SalesLT.Product
WHERE ProductID = @ProductID
GO
