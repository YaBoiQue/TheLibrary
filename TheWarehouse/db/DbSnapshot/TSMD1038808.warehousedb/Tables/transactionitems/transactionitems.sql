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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'TransactionItems_MenuItems') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactionitems] DROP CONSTRAINT TransactionItems_MenuItems
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'TransactionItems_Transactions') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactionitems] DROP CONSTRAINT TransactionItems_Transactions
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[transactionitems]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[transactionitems] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[transactionitems_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[transactionitems]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[transactionitems]
END
GO
--endregion

IF OBJECT_ID(N'[].[transactionitems]') IS NULL
BEGIN
    CREATE TABLE [].[transactionitems] (
		[idTransactionItems] INT NOT NULL ,
		[TransactionId] INT NOT NULL ,
		[MenuItemId] INT NOT NULL ,
		[Count] INT NOT NULL ,
		[Price] DOUBLE NOT NULL ,
		[timestamp] DATETIME NULL 
    ) ON []
END


GO


