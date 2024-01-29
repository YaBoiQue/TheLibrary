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



--region Non Primary Key Constraints    
    
--endregion

--region Foreign Keys that this table references
IF OBJECT_ID('employees') IS NOT NULL
BEGIN
    ALTER TABLE [].[transactions] ADD 
        CONSTRAINT [Transactions_Employees] FOREIGN KEY 
        (
            [EmployeeId] 
        ) REFERENCES [].[employees] (
            [idEmployees] 
        )
END
GO


IF OBJECT_ID('transactioncodes') IS NOT NULL
BEGIN
    ALTER TABLE [].[transactions] ADD 
        CONSTRAINT [Transactions_TransactionCodes] FOREIGN KEY 
        (
            [Code] 
        ) REFERENCES [].[transactioncodes] (
            [Name] 
        )
END
GO


--endregion

--region Foreign Keys that reference this table
--endregion
