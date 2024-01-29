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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Ingredients_MenuItems') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[ingredients] DROP CONSTRAINT Ingredients_MenuItems
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Ingredients_Supplies') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[ingredients] DROP CONSTRAINT Ingredients_Supplies
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[ingredients]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[ingredients] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[ingredients_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[ingredients]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[ingredients]
END
GO
--endregion

IF OBJECT_ID(N'[].[ingredients]') IS NULL
BEGIN
    CREATE TABLE [].[ingredients] (
		[idIngredients] INT IDENTITY (1, 1) NOT NULL ,
		[MenuItemId] INT NOT NULL ,
		[SupplyId] INT NOT NULL ,
		[created_ts] DATETIME NOT NULL ,
		[updated_ts] DATETIME NOT NULL 
    ) ON []
END


GO


