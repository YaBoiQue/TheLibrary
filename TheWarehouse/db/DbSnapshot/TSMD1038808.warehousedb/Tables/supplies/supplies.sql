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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Supplies_Suppliers') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[supplies] DROP CONSTRAINT Supplies_Suppliers
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Supplies_SupplyType') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[supplies] DROP CONSTRAINT Supplies_SupplyType
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Ingredients_Supplies') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[ingredients] DROP CONSTRAINT Ingredients_Supplies
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_Supplies') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_Supplies
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[supplies]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[supplies] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[supplies_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[supplies]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[supplies]
END
GO
--endregion

IF OBJECT_ID(N'[].[supplies]') IS NULL
BEGIN
    CREATE TABLE [].[supplies] (
		[idSupplies] INT NOT NULL ,
		[Name] VARCHAR(135) NOT NULL ,
		[TypeId] VARCHAR(135) NOT NULL ,
		[SupplierId] INT NULL ,
		[created_ts] DATETIME NOT NULL ,
		[updated_ts] DATETIME NOT NULL 
    ) ON []
END


GO


