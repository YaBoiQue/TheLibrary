﻿/*
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
	ALTER TABLE [].[employees] ADD CONSTRAINT [PRIMARY] PRIMARY KEY NONCLUSTERED
	(
		[idEmployees] DESC
	)
	ON []
END


--endregion

