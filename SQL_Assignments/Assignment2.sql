-- Assignment 2 SQL By Michael Zhang
-- Write queries for following scenarios
-- 1.      How many products can you find in the Production.Product table?
SELECT COUNT(ProductID) FROM Production.Product;

-- 2.      Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(ProductSubcategoryID) FROM Production.Product;

-- 3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.

-- ProductSubcategoryID CountedProducts

-- -------------------- ---------------
SELECT ProductSubcategoryID, COUNT(ProductSubcategoryID) AS CountedProducts FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID;

-- 4.      How many products that do not have a product subcategory.
SELECT (SELECT COUNT(ProductID) FROM Production.Product) - COUNT(ProductSubcategoryID) FROM Production.Product;

-- 5.      Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) FROM Production.ProductInventory;

-- 6.    Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

--               ProductID    TheSum

--               -----------        ----------
SELECT ProductID, SUM(Quantity) AS TheSum FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;

-- 7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

--     Shelf      ProductID    TheSum

--     ----------   -----------        -----------
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;

-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) FROM Production.ProductInventory
WHERE LocationID = 10;

-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

--     ProductID   Shelf      TheAvg

--     ----------- ---------- -----------
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg FROM Production.ProductInventory
GROUP BY ProductID, Shelf;

-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

--     ProductID   Shelf      TheAvg

--     ----------- ---------- -----------
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf;

-- 11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

--     Color                        Class              TheCount          AvgPrice

--     -------------- - -----    -----------            ---------------------
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;

-- Joins:

-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

--     Country                        Province

--     ---------                          ----------------------
-- SELECT * FROM Person.CountryRegion cr;
-- SELECT * FROM Person.StateProvince sp;
SELECT cr.Name AS Country, sp.Name AS Province FROM Person.CountryRegion cr
JOIN Person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode;

-- 13.  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

--     Country                        Province

--     ---------                          ----------------------
SELECT * FROM Person.CountryRegion cr;
SELECT * FROM Person.StateProvince sp;
SELECT cr.Name AS Country, sp.Name AS Province FROM Person.CountryRegion cr
JOIN Person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode AND cr.CountryRegionCode IN ('DE', 'CA');

-- --  Using Northwnd Database: (Use aliases for all the Joins)

-- 14.  List all Products that has been sold at least once in last 27 years.
-- SELECT * FROM Products p;
-- SELECT * FROM "Order Details" od;
-- SELECT * FROM Orders o;
SELECT p.ProductName, MIN(o.OrderDate) AS OldestOrder FROM Products p
JOIN "Order Details" od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(year, -27, GETDATE())
GROUP BY p.ProductName;

-- 15.  List top 5 locations (Zip Code) where the products sold most.
-- SELECT * FROM Orders o;
SELECT TOP 5 o.ShipPostalCode, COUNT(o.ShipPostalCode) AS TotalSold FROM Orders o
GROUP BY o.ShipPostalCode
ORDER BY TotalSold DESC;

-- 16.  List top 5 locations (Zip Code) where the products sold most in last 27 years.
SELECT TOP 5 o.ShipPostalCode, COUNT(o.OrderDate) AS TotalSold FROM Orders o
WHERE o.OrderDate >= DATEADD(year, -27, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY TotalSold DESC;

-- 17.   List all city names and number of customers in that city.  
-- SELECT * FROM Orders o;
SELECT ShipCity, COUNT(OrderID) AS NumOfCustomers FROM Orders
GROUP BY ShipCity;

-- 18.  List city names which have more than 2 customers, and number of customers in that city
SELECT ShipCity, COUNT(OrderID) AS NumOfCustomers FROM Orders
GROUP BY ShipCity
HAVING COUNT(OrderID) > 2;

-- 19.  List the names of customers who placed orders after 1/1/98 with order date.
-- SELECT * FROM Orders o;
SELECT c.ContactName, o.OrderDate FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01';

-- 20.  List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) AS RecentOrders FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
ORDER BY RecentOrders DESC;

-- 21.  Display the names of all customers along with the count of products they bought
SELECT c.ContactName, COUNT(o.OrderID) AS CountOfProducts FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName;

-- 22.  Display the customer ids who bought more than 100 Products with count of products.
SELECT c.ContactName, COUNT(o.OrderID) AS CountOfProducts FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
HAVING COUNT(o.OrderID) > 100;

-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below

--     Supplier Company Name                Shipping Company Name

--     ---------------------------------            ----------------------------------
-- SELECT * FROM Suppliers;
-- SELECT * FROM Shippers;
-- SELECT * FROM Orders;
SELECT s.CompanyName AS 'Supplier Company Name', sh.CompanyName AS 'Shipping Company Name' FROM Suppliers s
INNER JOIN Shippers sh ON 1 = 1;

-- 24.  Display the products order each day. Show Order date and Product Name.
-- SELECT * FROM Products;
-- SELECT * FROM "Order Details";
-- SELECT * FROM OrderDate;
SELECT o.OrderDate, p.ProductName FROM Orders o
JOIN "Order Details" od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID;

-- 25.  Displays pairs of employees who have the same job title.
-- SELECT * FROM Employees;
SELECT e1.Title, e1.FirstName + ' ' + e1.LastName AS Employee1, e2.FirstName + ' ' + e2.LastName AS Employee2 FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID;
-- Adding WHERE statements to stop the multiplicative duplicates

-- 26.  Display all the Managers who have more than 2 employees reporting to them.
SELECT m.FirstName + ' ' + m.LastName AS ManagerName, COUNT(e.EmployeeID) AS NumEmployees FROM Employees m
JOIN Employees e ON m.EmployeeID = e.ReportsTo
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) > 2;

-- 27.  Display the customers and suppliers by city. The results should have the following columns

-- City

-- Name

-- Contact Name,

-- Type (Customer or Supplier)
-- SELECT * FROM Customers;
-- SELECT * FROM Suppliers;
SELECT City, ContactName, CompanyName AS Name, 'Customer' AS 'Type' FROM Customers
UNION ALL 
SELECT City, ContactName, CompanyName AS Name, 'Supplier' AS 'Type' FROM Suppliers;