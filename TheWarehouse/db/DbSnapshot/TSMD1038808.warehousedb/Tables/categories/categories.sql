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
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[categories]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[categories] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[categories_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[categories]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[categories]
END
GO
--endregion

IF OBJECT_ID(N'[].[categories]') IS NULL
BEGIN
    CREATE TABLE [].[categories] (
		[idCategories] INT IDENTITY (1, 1) NOT NULL ,
		[Name] VARCHAR(135) NOT NULL 
    ) ON []
END


GO


