-- Assignment 3 by Michael Zhang
-- 1.      List all cities that have both Employees and Customers.
SELECT City FROM Employees
INTERSECT
SELECT City FROM Customers;

-- 2.      List all cities that have Customers but no Employee.
-- a.      Use sub-query
SELECT DISTINCT City FROM Customers
WHERE City NOT IN (SELECT City FROM Employees);

-- b.      Do not use sub-query
SELECT DISTINCT c.City FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.EmployeeID IS NULL;

-- 3.      List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS TotalQuantity FROM Products p
JOIN "Order Details" od ON p.ProductID = od.ProductID
GROUP BY p.ProductName;

-- 4.      List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS TotalProductsOrdered FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN "Order Details" od ON o.OrderID = od.OrderID
GROUP BY c.City;

-- 5.      List all Customer Cities that have at least two customers.
SELECT City FROM Customers
GROUP BY City
HAVING COUNT(1) >= 2;

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN "Order Details" od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2;

-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT DISTINCT c.ContactName FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity;

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH ProductSales AS (
    SELECT TOP 5
        p.ProductName,
        AVG(p.UnitPrice) AS AvgPrice,
        o.ShipCity,
        SUM(od.Quantity) AS TotalQuantity,
        RANK() OVER (ORDER BY SUM(od.Quantity) DESC) AS Rank 
    FROM Products p
    JOIN "Order Details" od ON p.ProductID = od.ProductID
    JOIN Orders o ON od.OrderID = o.OrderID
    GROUP BY p.ProductName, o.ShipCity
)
-- SELECT * FROM ProductSales;
SELECT ProductName, AvgPrice, ShipCity
FROM ProductSales
ORDER BY TotalQuantity DESC;

-- 9.      List all cities that have never ordered something but we have employees there.
-- a.      Use sub-query
SELECT DISTINCT City FROM Employees
WHERE City NOT IN (SELECT DISTINCT ShipCity FROM Orders);

-- b.      Do not use sub-query
SELECT DISTINCT e.City FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.OrderID IS NULL;

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH EmployeeSales AS (
    SELECT TOP 1 
        e.City AS EmployeeCity, 
        COUNT(o.OrderID) AS TotalOrders
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
    ORDER BY TotalOrders DESC
),
CustomerSales AS (
    SELECT TOP 1 
        o.ShipCity AS CustomerCity, 
        SUM(od.Quantity) AS TotalQuantity
    FROM Orders o
    JOIN "Order Details" od ON o.OrderID = od.OrderID
    GROUP BY o.ShipCity
    ORDER BY TotalQuantity DESC
)
SELECT 
    es.EmployeeCity AS EmployeeCityWithMostOrders, 
    cs.CustomerCity AS CustomerCityWithMostProducts
FROM EmployeeSales es, CustomerSales cs;

-- 11. How do you remove the duplicates record of a table?
-- One idea is we can create a new table in sql where we use DISTINCT to remove the duplicates.
-- The only thing is I'm not sure about sql's backend if its allowed to replace the new/destination table
-- as the current table, or if we need to create a temp/local table and then maybe replace the current table
-- with the new local table.