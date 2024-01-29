/*
 * SC Header, do not delete!
 *
 * $Revision:  $
 * $Date: 1/24/2024 $
 * $Author: 101059445 $
 * $Archive: $
 *
 * Purpose:
 *   To recreate the Data in inventory Table
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
SET @SQL = 'SELECT * INTO [].[inventory_' + @Revision + '_' + @TimeStamp + '] FROM [].[inventory]'
    
    EXEC sp_executesql @SQL

IF (@@ROWCOUNT = 0 AND (SELECT COUNT(*) FROM [].[inventory]) > 0)
OR (@@ERROR > 0)
BEGIN
    RAISERROR('not enough rows inserted into the backup table', 16, 1)
    GOTO ErrorHandler
END
ELSE
BEGIN
    SET @StatusMessage = 'All existing data was copied into the table [].[inventory_' + @Revision + '_' + @TimeStamp + ']'
    PRINT @StatusMessage
END
--#endregion

DELETE FROM [].[inventory]
IF @@ERROR > 0
BEGIN
	PRINT 'Delete Failed, roll back the transaction'
    GOTO ErrorHandler
END
	
DBCC CHECKIDENT ('[].[inventory]', RESEED, 1)
IF @@ERROR > 0
BEGIN
	PRINT 'DBCC CHECKIDENT Failed, roll back the transaction'
    GOTO ErrorHandler
END

SET IDENTITY_INSERT [].[inventory] ON
-- Setup the XML document that is the table data, this text string can be up to 2gb in size.
--#region
DECLARE @DocumentHandle INT
EXEC dbo.sp_xml_preparedocument @DocumentHandle OUTPUT, N'
<?xml version="1.0" encoding="utf-16"?>
<inventoryRows />
'
--#endregion
INSERT INTO [].[inventory] (
	[idInventory],
	[SupplyId],
	[Amount],
	[Price],
	[EmployeeId],
	[ReceiptId],
	[Code],
	[timestamp]
)
SELECT 
	[idInventory],
	[SupplyId],
	[Amount],
	[Price],
	[EmployeeId],
	[ReceiptId],
	[Code],
	[timestamp]
FROM OPENXML(@DocumentHandle, 'inventoryRows/inventoryRow', 2) WITH ( 
	[idInventory] INT,
	[SupplyId] INT,
	[Amount] INT,
	[Price] DECIMAL(6, 2),
	[EmployeeId] INT,
	[ReceiptId] INT,
	[Code] VARCHAR(135),
	[timestamp] DATETIME
)
-- important to clean up the memory consumed by the XML Document
EXEC dbo.sp_xml_removedocument @DocumentHandle

SET IDENTITY_INSERT [].[inventory] OFF

COMMIT TRANSACTION
ErrorHandler:
IF @@TRANCOUNT > 0
BEGIN
	ROLLBACK TRANSACTION
	PRINT 'Transaction for [].[inventory] Rolled Back'
END
GO


