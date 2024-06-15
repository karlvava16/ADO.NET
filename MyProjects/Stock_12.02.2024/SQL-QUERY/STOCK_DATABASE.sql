CREATE DATABASE Stock
go

USE Stock

CREATE TABLE Suppliers (
    ID INT PRIMARY KEY IDENTITY,
    SupplierName NVARCHAR(100) NOT NULL
);


CREATE TABLE Products (
    ID INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(100) NOT NULL,
    ProductType NVARCHAR(50),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(ID),
    Quantity INT,
    Cost DECIMAL(10, 2),
    DeliveryDate DATE
);

USE Stock
go
-- Insert data into the Suppliers table
INSERT INTO Suppliers (SupplierName)
VALUES 
('ABC Electronics'),
('XYZ Corporation'),
('Globe Imports'),
('Tech Solutions Ltd.');

-- Insert data into the Products table
INSERT INTO Products (ProductName, ProductType, SupplierID, Quantity, Cost, DeliveryDate)
VALUES 
('Laptop', 'Electronics', 1, 50, 800.00, '2024-02-15'),
('Smartphone', 'Electronics', 2, 100, 500.00, '2024-02-14'),
('Headphones', 'Accessories', 3, 200, 30.00, '2024-02-13'),
('Printer', 'Electronics', 1, 30, 300.00, '2024-02-16'),
('Tablet', 'Electronics', 4, 80, 400.00, '2024-02-17'),
('Keyboard', 'Accessories', 3, 150, 20.00, '2024-02-18'),
('Mouse', 'Accessories', 2, 120, 15.00, '2024-02-19'),
('Monitor', 'Electronics', 4, 40, 200.00, '2024-02-20'),
('Router', 'Networking', 1, 60, 100.00, '2024-02-21'),
('Camera', 'Electronics', 3, 70, 600.00, '2024-02-22');
