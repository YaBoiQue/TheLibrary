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
--region Drop constraints that reference this table
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_Employees') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_Employees
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_InventoryCodes') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_InventoryCodes
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_Receipts') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_Receipts
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_Supplies') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_Supplies
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[inventory]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[inventory] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[inventory_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[inventory]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[inventory]
END
GO
--endregion

IF OBJECT_ID(N'[].[inventory]') IS NULL
BEGIN
    CREATE TABLE [].[inventory] (
		[idInventory] INT IDENTITY (1, 1) NOT NULL ,
		[SupplyId] INT NOT NULL ,
		[Amount] INT NOT NULL ,
		[Price] DECIMAL(6, 2) NULL ,
		[EmployeeId] INT NOT NULL ,
		[ReceiptId] INT NULL ,
		[Code] VARCHAR(135) NOT NULL ,
		[timestamp] DATETIME NOT NULL 
    ) ON []
END


GO


