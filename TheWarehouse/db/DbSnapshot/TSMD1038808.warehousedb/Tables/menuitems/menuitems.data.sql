/*
 * SC Header, do not delete!
 *
 * $Revision:  $
 * $Date: 1/24/2024 $
 * $Author: 101059445 $
 * $Archive: $
 *
 * Purpose:
 *   To recreate the Data in menuitems Table
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
SET @SQL = 'SELECT * INTO [].[menuitems_' + @Revision + '_' + @TimeStamp + '] FROM [].[menuitems]'
    
    EXEC sp_executesql @SQL

IF (@@ROWCOUNT = 0 AND (SELECT COUNT(*) FROM [].[menuitems]) > 0)
OR (@@ERROR > 0)
BEGIN
    RAISERROR('not enough rows inserted into the backup table', 16, 1)
    GOTO ErrorHandler
END
ELSE
BEGIN
    SET @StatusMessage = 'All existing data was copied into the table [].[menuitems_' + @Revision + '_' + @TimeStamp + ']'
    PRINT @StatusMessage
END
--#endregion

DELETE FROM [].[menuitems]
IF @@ERROR > 0
BEGIN
	PRINT 'Delete Failed, roll back the transaction'
    GOTO ErrorHandler
END
	
DBCC CHECKIDENT ('[].[menuitems]', RESEED, 1)
IF @@ERROR > 0
BEGIN
	PRINT 'DBCC CHECKIDENT Failed, roll back the transaction'
    GOTO ErrorHandler
END

SET IDENTITY_INSERT [].[menuitems] ON
-- Setup the XML document that is the table data, this text string can be up to 2gb in size.
--#region
DECLARE @DocumentHandle INT
EXEC dbo.sp_xml_preparedocument @DocumentHandle OUTPUT, N'
<?xml version="1.0" encoding="utf-16"?>
<menuitemsRows />
'
--#endregion
INSERT INTO [].[menuitems] (
	[idMenuItems],
	[Name],
	[Price],
	[CategoryId],
	[created_ts],
	[updated_ts]
)
SELECT 
	[idMenuItems],
	[Name],
	[Price],
	[CategoryId],
	[created_ts],
	[updated_ts]
FROM OPENXML(@DocumentHandle, 'menuitemsRows/menuitemsRow', 2) WITH ( 
	[idMenuItems] INT,
	[Name] VARCHAR(135),
	[Price] DECIMAL(5, 2),
	[CategoryId] INT,
	[created_ts] DATETIME,
	[updated_ts] DATETIME
)
-- important to clean up the memory consumed by the XML Document
EXEC dbo.sp_xml_removedocument @DocumentHandle

SET IDENTITY_INSERT [].[menuitems] OFF

COMMIT TRANSACTION
ErrorHandler:
IF @@TRANCOUNT > 0
BEGIN
	ROLLBACK TRANSACTION
	PRINT 'Transaction for [].[menuitems] Rolled Back'
END
GO


