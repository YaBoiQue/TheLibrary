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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Receipts_Employees') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[receipts] DROP CONSTRAINT Receipts_Employees
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Transactions_Employees') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactions] DROP CONSTRAINT Transactions_Employees
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[employees]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[employees] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[employees_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[employees]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[employees]
END
GO
--endregion

IF OBJECT_ID(N'[].[employees]') IS NULL
BEGIN
    CREATE TABLE [].[employees] (
		[idEmployees] INT NOT NULL ,
		[FirstName] VARCHAR(135) NOT NULL ,
		[LastName] VARCHAR(135) NOT NULL ,
		[created_ts] DATETIME NOT NULL ,
		[updated_ts] DATETIME NOT NULL 
    ) ON []
END


GO


