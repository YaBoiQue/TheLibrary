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
IF OBJECT_ID('suppliers') IS NOT NULL
BEGIN
    ALTER TABLE [].[supplies] ADD 
        CONSTRAINT [Supplies_Suppliers] FOREIGN KEY 
        (
            [SupplierId] 
        ) REFERENCES [].[suppliers] (
            [idSuppliers] 
        )
END
GO


IF OBJECT_ID('supplytype') IS NOT NULL
BEGIN
    ALTER TABLE [].[supplies] ADD 
        CONSTRAINT [Supplies_SupplyType] FOREIGN KEY 
        (
            [TypeId] 
        ) REFERENCES [].[supplytype] (
            [Name] 
        )
END
GO


--endregion

--region Foreign Keys that reference this table
--endregion
