CREATE DATABASE Stock
go
USE Stock
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(100) NOT NULL,
    ProductType NVARCHAR(50),
    Supplier NVARCHAR(100),
    Quantity INT,
    Cost DECIMAL(10, 2),
    DeliveryDate DATE
);

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY,
    SupplierName NVARCHAR(100) NOT NULL,
    SupplierAddress NVARCHAR(255),
    SupplierPhone NVARCHAR(20)
);

ALTER TABLE Products
ADD CONSTRAINT FK_Products_Suppliers FOREIGN KEY (Supplier) REFERENCES Suppliers(SupplierName);
S