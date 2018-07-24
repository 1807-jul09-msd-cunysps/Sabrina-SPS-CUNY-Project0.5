DROP TABLE IF EXISTS Orders;
DROP TABLE If EXISTS Customers;
DROP TABLE IF EXISTS Products;

--CREATE TABLE Products
--	([ProductID] int PRIMARY KEY IDENTITY(1,1),
--	 [name] varchar(50),
--	 [price] money NOT NULL
--	 )
--	 ;


--CREATE TABLE Customers
--	([CustomerID] int PRIMARY KEY IDENTITY(1,1),
--	 [FirstName] varchar(50),
--	 [LastName] varchar(50),
--	 [CardNumber] varchar(50)
--	 )
--	 ;

--CREATE TABLE Orders
--	([OrderID] int PRIMARY KEY IDENTITY(1,1),
--	 ProductID int FOREIGN KEY REFERENCES Products(ProductID),
--	 CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID)
--	 )
--	 ;

--INSERT INTO Products
--	([name],[price])
--VALUES
--	('iPhone', 200.00),
--	('Galaxy S8', 400.00),
--	('Sony Xperia Z5', 500.00)
--	;

--INSERT INTO Customers
--	([FirstName], [LastName],[CardNumber])
--VALUES
--	('Tina', 'Smith', '4757873943309880'),
--	('Christina', 'Garcia', '9088434375201097'),
--	('Harry', 'Potter', '8929747845261984')
--	;

--SELECT * FROM Customers;
--SELECT * FROM Products;

SELECT * FROM Orders;

INSERT INTO Orders(ProductID,CustomerID)
VALUES
((SELECT ProductID FROM Products
WHERE name = 'iPhone'),
(SELECT CustomerID FROM Customers
WHERE FirstName = 'Christina' AND LastName='Garcia'))
;

INSERT INTO Orders(ProductID,CustomerID)
VALUES
((SELECT ProductID FROM Products
WHERE name = 'iPhone'),
(SELECT CustomerID FROM Customers
WHERE FirstName = 'Tina' AND LastName='Smith'))
;

SELECT * FROM Orders
WHERE CustomerID = (SELECT CustomerID FROM Customers WHERE FirstName = 'Tina' AND LastName = 'Smith');

SELECT * FROM Orders
WHERE ProductID = (SELECT ProductID FROM Products WHERE name= 'iPhone');


SELECT Products.name, Products.ProductID, FORMAT(SUM(Products.price), 'C', 'en-us')
FROM Products
INNER JOIN Orders ON Products.ProductID = Orders.ProductID
GROUP BY Products.name, Products.ProductID;


UPDATE Products
SET price = 250.00
WHERE name = 'iPhone';



--SELECT COUNT(*) FROM Orders
--WHERE ProductID = (SELECT ProductID FROM Products WHERE name = 'iPhone') *
--SELECT price FROM Product WHERE ;

