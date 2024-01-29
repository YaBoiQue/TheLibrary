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
IF OBJECT_ID('menuitems') IS NOT NULL
BEGIN
    ALTER TABLE [].[transactionitems] ADD 
        CONSTRAINT [TransactionItems_MenuItems] FOREIGN KEY 
        (
            [MenuItemId] 
        ) REFERENCES [].[menuitems] (
            [idMenuItems] 
        )
END
GO


IF OBJECT_ID('transactions') IS NOT NULL
BEGIN
    ALTER TABLE [].[transactionitems] ADD 
        CONSTRAINT [TransactionItems_Transactions] FOREIGN KEY 
        (
            [TransactionId] 
        ) REFERENCES [].[transactions] (
            [idTransactions] 
        )
END
GO


--endregion

--region Foreign Keys that reference this table
--endregion
