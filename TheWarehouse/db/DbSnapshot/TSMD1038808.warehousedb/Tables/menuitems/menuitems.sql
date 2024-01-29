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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'MenuItems_Category') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[menuitems] DROP CONSTRAINT MenuItems_Category
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Ingredients_MenuItems') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[ingredients] DROP CONSTRAINT Ingredients_MenuItems
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'TransactionItems_MenuItems') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactionitems] DROP CONSTRAINT TransactionItems_MenuItems
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[menuitems]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[menuitems] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[menuitems_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[menuitems]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[menuitems]
END
GO
--endregion

IF OBJECT_ID(N'[].[menuitems]') IS NULL
BEGIN
    CREATE TABLE [].[menuitems] (
		[idMenuItems] INT IDENTITY (1, 1) NOT NULL ,
		[Name] VARCHAR(135) NOT NULL ,
		[Price] DECIMAL(5, 2) NULL ,
		[CategoryId] INT NULL ,
		[created_ts] DATETIME NOT NULL ,
		[updated_ts] DATETIME NOT NULL 
    ) ON []
END


GO


