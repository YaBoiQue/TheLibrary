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
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'Transactions_TransactionCodes') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1)
    ALTER TABLE [].[transactions] DROP CONSTRAINT Transactions_TransactionCodes
GO
--endregion

--region Drop this table, but copy the data into a backup table just in case ;)
IF (OBJECT_ID(N'[].[transactioncodes]')) IS NOT NULL
BEGIN
    IF EXISTS ( SELECT * FROM [].[transactioncodes] )
    BEGIN
        DECLARE @newName NVARCHAR(128); SET @newName = N'[].[transactioncodes_' + CONVERT(NVARCHAR(128), NEWID()) + N'_MAY_DELETE]'
        EXEC ('SELECT * INTO ' + @newName + ' FROM [].[transactioncodes]')
        SELECT 'The existing table had data.  that data was copied into ' + @newName
    END
    DROP TABLE [].[transactioncodes]
END
GO
--endregion

IF OBJECT_ID(N'[].[transactioncodes]') IS NULL
BEGIN
    CREATE TABLE [].[transactioncodes] (
		[Name] VARCHAR(135) NOT NULL ,
		[Description] MEDIUMTEXT(16777215) NULL 
    ) ON []
END


GO


