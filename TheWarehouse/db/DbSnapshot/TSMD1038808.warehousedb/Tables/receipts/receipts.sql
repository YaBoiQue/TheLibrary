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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Receipts_Employees') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[receipts] DROP CONSTRAINT Receipts_Employees
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Inventory_Receipts') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[inventory] DROP CONSTRAINT Inventory_Receipts
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[receipts]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[receipts] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[receipts_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[receipts]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[receipts]
END
GO
--endregion

IF OBJECT_ID(N'[].[receipts]') IS NULL
BEGIN
    CREATE TABLE [].[receipts] (
		[idReceipts] INT IDENTITY (1, 1) NOT NULL ,
		[Store] VARCHAR(135) NULL ,
		[ReceiptNum] VARCHAR(135) NULL ,
		[Total] DOUBLE NULL ,
		[EmployeeId] INT NULL ,
		[timestamp] DATETIME NOT NULL 
    ) ON []
END


GO


