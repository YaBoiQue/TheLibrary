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
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[suppliers]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[suppliers] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[suppliers_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[suppliers]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[suppliers]
END
GO
--endregion

IF OBJECT_ID(N'[].[suppliers]') IS NULL
BEGIN
    CREATE TABLE [].[suppliers] (
		[idSuppliers] INT NOT NULL ,
		[Name] VARCHAR(135) NOT NULL 
    ) ON []
END


GO


