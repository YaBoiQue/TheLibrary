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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_InventoryCodes') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_InventoryCodes
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[inventorycodes]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[inventorycodes] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[inventorycodes_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[inventorycodes]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[inventorycodes]
END
GO
--endregion

IF OBJECT_ID(N'[].[inventorycodes]') IS NULL
BEGIN
    CREATE TABLE [].[inventorycodes] (
		[Name] VARCHAR(135) NOT NULL ,
		[Description] MEDIUMTEXT(16777215) NULL 
    ) ON []
END


GO


