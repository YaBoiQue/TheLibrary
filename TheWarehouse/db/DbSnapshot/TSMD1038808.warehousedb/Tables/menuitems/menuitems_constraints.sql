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
IF OBJECT_ID('categories') IS NOT NULL
BEGIN
    ALTER TABLE [].[menuitems] ADD 
        CONSTRAINT [MenuItems_Category] FOREIGN KEY 
        (
            [CategoryId] 
        ) REFERENCES [].[categories] (
            [idCategories] 
        )
END
GO


--endregion

--region Foreign Keys that reference this table
--endregion
