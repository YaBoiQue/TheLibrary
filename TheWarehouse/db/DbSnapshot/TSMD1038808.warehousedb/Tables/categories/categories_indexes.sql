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


--region Create indexes
IF OBJECT_ID('PRIMARY') IS NULL
BEGIN
	ALTER TABLE [].[categories] ADD CONSTRAINT [PRIMARY] PRIMARY KEY NONCLUSTERED
	(
		[idCategories] DESC
	)
	ON []
END


--endregion

