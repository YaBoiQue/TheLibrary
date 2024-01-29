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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Transactions_Employees') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactions] DROP CONSTRAINT Transactions_Employees
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Transactions_TransactionCodes') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactions] DROP CONSTRAINT Transactions_TransactionCodes
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'TransactionItems_Transactions') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactionitems] DROP CONSTRAINT TransactionItems_Transactions
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[transactions]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[transactions] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[transactions_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[transactions]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[transactions]
END
GO
--endregion

IF OBJECT_ID(N'[].[transactions]') IS NULL
BEGIN
    CREATE TABLE [].[transactions] (
		[idTransactions] INT IDENTITY (1, 1) NOT NULL ,
		[EmployeeId] INT NOT NULL ,
		[Total] DECIMAL(6, 2) NOT NULL ,
		[Code] VARCHAR(135) NOT NULL ,
		[timestamp] DATETIME NOT NULL 
    ) ON []
END


GO


