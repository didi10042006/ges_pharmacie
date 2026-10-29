-- =========================================================================
-- DATABASE INITIALIZATION SCRIPT - GESTION PHARMACIE
-- SQLite Database Schema Definition
-- =========================================================================

PRAGMA foreign_keys = ON;

-- -------------------------------------------------------------------------
-- 1. Table: Users
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL COLLATE NOCASE,
    PasswordHash TEXT NOT NULL,
    Role TEXT NOT NULL DEFAULT 'Pharmacist',
    IsActive INTEGER NOT NULL DEFAULT 1,
    CONSTRAINT UQ_Users_Username UNIQUE (Username)
);

-- -------------------------------------------------------------------------
-- 2. Table: Products
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Products (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Reference TEXT NOT NULL COLLATE NOCASE,
    Name TEXT NOT NULL,
    Category TEXT,
    Dosage TEXT,
    Form TEXT,
    SellingPrice NUMERIC NOT NULL CHECK (SellingPrice >= 0),
    MinStockThreshold INTEGER NOT NULL DEFAULT 5 CHECK (MinStockThreshold >= 0),
    IsArchived INTEGER NOT NULL DEFAULT 0,
    CONSTRAINT UQ_Products_Reference UNIQUE (Reference)
);

-- -------------------------------------------------------------------------
-- 3. Table: Suppliers
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Suppliers (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Phone TEXT,
    Email TEXT,
    Address TEXT,
    IsArchived INTEGER NOT NULL DEFAULT 0
);

-- -------------------------------------------------------------------------
-- 4. Table: StockLots
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS StockLots (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ProductId INTEGER NOT NULL,
    SupplierId INTEGER,
    LotNumber TEXT NOT NULL,
    ExpiryDate TEXT NOT NULL,
    Quantity INTEGER NOT NULL DEFAULT 0 CHECK (Quantity >= 0),
    PurchaseCost NUMERIC NOT NULL DEFAULT 0 CHECK (PurchaseCost >= 0),
    IsBlocked INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY (ProductId) REFERENCES Products(Id) ON DELETE RESTRICT,
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id) ON DELETE SET NULL
);

-- -------------------------------------------------------------------------
-- 5. Table: Sales
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Sales (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SaleNumber TEXT NOT NULL,
    SaleDate TEXT NOT NULL,
    UserId INTEGER NOT NULL,
    PaymentMethod TEXT NOT NULL DEFAULT 'Cash',
    TotalAmount NUMERIC NOT NULL CHECK (TotalAmount >= 0),
    DiscountAmount NUMERIC NOT NULL DEFAULT 0 CHECK (DiscountAmount >= 0),
    PaidAmount NUMERIC NOT NULL CHECK (PaidAmount >= 0),
    ChangeGiven NUMERIC NOT NULL DEFAULT 0 CHECK (ChangeGiven >= 0),
    Status TEXT NOT NULL DEFAULT 'Completed',
    CONSTRAINT UQ_Sales_SaleNumber UNIQUE (SaleNumber),
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE RESTRICT
);

-- -------------------------------------------------------------------------
-- 6. Table: SaleItems
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS SaleItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SaleId INTEGER NOT NULL,
    StockLotId INTEGER NOT NULL,
    Quantity INTEGER NOT NULL CHECK (Quantity > 0),
    UnitPrice NUMERIC NOT NULL CHECK (UnitPrice >= 0),
    LineTotal NUMERIC NOT NULL CHECK (LineTotal >= 0),
    FOREIGN KEY (SaleId) REFERENCES Sales(Id) ON DELETE CASCADE,
    FOREIGN KEY (StockLotId) REFERENCES StockLots(Id) ON DELETE RESTRICT
);

-- -------------------------------------------------------------------------
-- 7. Table: StockAdjustments
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS StockAdjustments (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ProductId INTEGER NOT NULL,
    StockLotId INTEGER NOT NULL,
    QuantityChange INTEGER NOT NULL,
    Reason TEXT NOT NULL,
    UserId INTEGER NOT NULL,
    AdjustmentDate TEXT NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(Id) ON DELETE RESTRICT,
    FOREIGN KEY (StockLotId) REFERENCES StockLots(Id) ON DELETE RESTRICT,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE RESTRICT
);

-- -------------------------------------------------------------------------
-- 8. Table: AuditLogs
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS AuditLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    Action TEXT NOT NULL,
    Details TEXT,
    Timestamp TEXT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE SET NULL
);

-- -------------------------------------------------------------------------
-- 9. Table: AppSettings
-- -------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS AppSettings (
    Key TEXT PRIMARY KEY NOT NULL,
    Value TEXT NOT NULL
);

-- =========================================================================
-- INDEXES
-- =========================================================================

CREATE INDEX IF NOT EXISTS IX_Users_Username ON Users(Username);

CREATE INDEX IF NOT EXISTS IX_Products_Reference ON Products(Reference);
CREATE INDEX IF NOT EXISTS IX_Products_Name ON Products(Name);
CREATE INDEX IF NOT EXISTS IX_Products_Category ON Products(Category);
CREATE INDEX IF NOT EXISTS IX_Products_IsArchived ON Products(IsArchived);

CREATE INDEX IF NOT EXISTS IX_Suppliers_Name ON Suppliers(Name);

CREATE INDEX IF NOT EXISTS IX_StockLots_ProductId ON StockLots(ProductId);
CREATE INDEX IF NOT EXISTS IX_StockLots_ExpiryDate ON StockLots(ExpiryDate);
CREATE INDEX IF NOT EXISTS IX_StockLots_LotNumber ON StockLots(LotNumber);
CREATE INDEX IF NOT EXISTS IX_StockLots_IsBlocked ON StockLots(IsBlocked);

CREATE INDEX IF NOT EXISTS IX_Sales_SaleNumber ON Sales(SaleNumber);
CREATE INDEX IF NOT EXISTS IX_Sales_SaleDate ON Sales(SaleDate);
CREATE INDEX IF NOT EXISTS IX_Sales_UserId ON Sales(UserId);
CREATE INDEX IF NOT EXISTS IX_Sales_Status ON Sales(Status);

CREATE INDEX IF NOT EXISTS IX_SaleItems_SaleId ON SaleItems(SaleId);
CREATE INDEX IF NOT EXISTS IX_SaleItems_StockLotId ON SaleItems(StockLotId);

CREATE INDEX IF NOT EXISTS IX_StockAdjustments_ProductId ON StockAdjustments(ProductId);
CREATE INDEX IF NOT EXISTS IX_StockAdjustments_StockLotId ON StockAdjustments(StockLotId);
CREATE INDEX IF NOT EXISTS IX_StockAdjustments_AdjustmentDate ON StockAdjustments(AdjustmentDate);

CREATE INDEX IF NOT EXISTS IX_AuditLogs_UserId ON AuditLogs(UserId);
CREATE INDEX IF NOT EXISTS IX_AuditLogs_Timestamp ON AuditLogs(Timestamp);
