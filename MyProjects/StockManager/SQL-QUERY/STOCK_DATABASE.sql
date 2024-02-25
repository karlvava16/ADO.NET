CREATE DATABASE Stock
go

USE Stock

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Type NVARCHAR(50),
    Quantity INT,
    CostPrice DECIMAL(10, 2)
);


CREATE TABLE Managers (
    ManagerID INT PRIMARY KEY,
    Name NVARCHAR(100)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(100)
);


CREATE TABLE Sales (
    SaleID INT PRIMARY KEY,
    ProductID INT,
    ManagerID INT,
    CustomerID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    SaleDate DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (ManagerID) REFERENCES Managers(ManagerID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


CREATE TABLE SalesManagers (
    SaleID INT,
    ManagerID INT,
    PRIMARY KEY (SaleID, ManagerID),
    FOREIGN KEY (SaleID) REFERENCES Sales(SaleID),
    FOREIGN KEY (ManagerID) REFERENCES Managers(ManagerID)
);


USE Stock
go
-- Insert data into the Suppliers table
INSERT INTO Suppliers (SupplierName, SupplierAddress, SupplierPhone)
VALUES 
('ABC Electronics', '123 Main Street, Anytown, USA', '123-456-7890'),
('XYZ Corporation', '456 Elm Street, Othertown, USA', '987-654-3210'),
('Globe Imports', '789 Oak Street, Anycity, USA', '555-123-4567'),
('Tech Solutions Ltd.', '321 Maple Avenue, Somewhere, USA', '222-333-4444');

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
