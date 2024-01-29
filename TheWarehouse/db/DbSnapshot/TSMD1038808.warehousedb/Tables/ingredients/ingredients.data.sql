﻿/*
 * SC Header, do not delete!
 *
 * $Revision:  $
 * $Date: 1/24/2024 $
 * $Author: 101059445 $
 * $Archive: $
 *
 * Purpose:
 *   To recreate the Data in ingredients Table
 * Change History:
 *
 */

USE warehousedb
GO
BEGIN TRANSACTION
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
-- Backup the table
--#region
DECLARE 
    @TimeStamp VARCHAR(30),
    @SQL       NVARCHAR(4000),
    @Revision  NVARCHAR(20),
    @StatusMessage VARCHAR(400)
	
SET @Revision = CAST(REPLACE(REPLACE('$Revision: $', 'Revision:', ''), '$', '') AS INT)    
SET @TimeStamp = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR(25),GETDATE(),120),' ',''),'-',''),':','')   
SET @SQL = 'SELECT * INTO [].[ingredients_' + @Revision + '_' + @TimeStamp + '] FROM [].[ingredients]'
    
    EXEC sp_executesql @SQL

IF (@@ROWCOUNT = 0 AND (SELECT COUNT(*) FROM [].[ingredients]) > 0)
OR (@@ERROR > 0)
BEGIN
    RAISERROR('not enough rows inserted into the backup table', 16, 1)
    GOTO ErrorHandler
END
ELSE
BEGIN
    SET @StatusMessage = 'All existing data was copied into the table [].[ingredients_' + @Revision + '_' + @TimeStamp + ']'
    PRINT @StatusMessage
END
--#endregion

DELETE FROM [].[ingredients]
IF @@ERROR > 0
BEGIN
	PRINT 'Delete Failed, roll back the transaction'
    GOTO ErrorHandler
END
	
DBCC CHECKIDENT ('[].[ingredients]', RESEED, 1)
IF @@ERROR > 0
BEGIN
	PRINT 'DBCC CHECKIDENT Failed, roll back the transaction'
    GOTO ErrorHandler
END

SET IDENTITY_INSERT [].[ingredients] ON
-- Setup the XML document that is the table data, this text string can be up to 2gb in size.
--#region
DECLARE @DocumentHandle INT
EXEC dbo.sp_xml_preparedocument @DocumentHandle OUTPUT, N'
<?xml version="1.0" encoding="utf-16"?>
<ingredientsRows />
'
--#endregion
INSERT INTO [].[ingredients] (
	[idIngredients],
	[MenuItemId],
	[SupplyId],
	[created_ts],
	[updated_ts]
)
SELECT 
	[idIngredients],
	[MenuItemId],
	[SupplyId],
	[created_ts],
	[updated_ts]
FROM OPENXML(@DocumentHandle, 'ingredientsRows/ingredientsRow', 2) WITH ( 
	[idIngredients] INT,
	[MenuItemId] INT,
	[SupplyId] INT,
	[created_ts] DATETIME,
	[updated_ts] DATETIME
)
-- important to clean up the memory consumed by the XML Document
EXEC dbo.sp_xml_removedocument @DocumentHandle

SET IDENTITY_INSERT [].[ingredients] OFF

COMMIT TRANSACTION
ErrorHandler:
IF @@TRANCOUNT > 0
BEGIN
	ROLLBACK TRANSACTION
	PRINT 'Transaction for [].[ingredients] Rolled Back'
END
GO


