/*
 * SC Header, do not delete!
 *
 * $Revision: $
 * $Date: 1/24/2024 $
 * $Author: $
 * $Archive: $
 *
 */
USE warehousedb
GO



--region Non Primary Key Constraints    
    
--endregion

--region Foreign Keys that this table references
IF OBJECT_ID('employees') IS NOT NULL
BEGIN
    ALTER TABLE [].[inventory] ADD 
        CONSTRAINT [Inventory_Employees] FOREIGN KEY 
        (
            [EmployeeId] 
        ) REFERENCES [].[employees] (
            [idEmployees] 
        )
END
GO


IF OBJECT_ID('inventorycodes') IS NOT NULL
BEGIN
    ALTER TABLE [].[inventory] ADD 
        CONSTRAINT [Inventory_InventoryCodes] FOREIGN KEY 
        (
            [Code] 
        ) REFERENCES [].[inventorycodes] (
            [Name] 
        )
END
GO


IF OBJECT_ID('receipts') IS NOT NULL
BEGIN
    ALTER TABLE [].[inventory] ADD 
        CONSTRAINT [Inventory_Receipts] FOREIGN KEY 
        (
            [ReceiptId] 
        ) REFERENCES [].[receipts] (
            [idReceipts] 
        )
END
GO


IF OBJECT_ID('supplies') IS NOT NULL
BEGIN
    ALTER TABLE [].[inventory] ADD 
        CONSTRAINT [Inventory_Supplies] FOREIGN KEY 
        (
            [SupplyId] 
        ) REFERENCES [].[supplies] (
            [idSupplies] 
        )
END
GO


--endregion

--region Foreign Keys that reference this table
--endregion
