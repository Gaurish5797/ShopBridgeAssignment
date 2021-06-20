/******* Create Table ITEM *********/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
       DROP TABLE [dbo].[Item]
GO
CREATE TABLE [dbo].[Item](
	     [ItemId]    [INT] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	     [ItemName]  [VARCHAR](100) NULL,
	     [ItemDescription] [NVARCHAR](200) NULL,
	     [ItemPrice] [DECIMAL](18, 2) NULL)

GO

/* 5 Test Items are inserted */
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Hammer','Hammer Description',100.00)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Hinges','Hinges Description',350.50)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Knobs','Knobs Description',200.00)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Bolts','Bolts Description',150.00)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('PaintBrush','PaintBrush Description',100.00)

/****** DROP SPs if Exist ***********/
IF EXISTS(SELECT 1 FROM sys.procedures  WHERE Name = 'CreateTestRecords')
    DROP PROCEDURE dbo.CreateTestRecords

IF EXISTS(SELECT 1 FROM sys.procedures  WHERE Name = 'InsertItem')
    DROP PROCEDURE dbo.InsertItem

IF EXISTS(SELECT 1 FROM sys.procedures  WHERE Name = 'UpdateItem')
    DROP PROCEDURE dbo.UpdateItem

IF EXISTS(SELECT 1 FROM sys.procedures  WHERE Name = 'DeleteItem')
    DROP PROCEDURE dbo.DeleteItem

GO

/****** CREATE SPs ***********/

/****** Object:  StoredProcedure [dbo].[CreateTestRecords]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/***************************
AUTHOR : GAURISH ABHISHEKI
THIS SP IS ONLY FOR THE TEST CASE DATABASE 
****************************/
CREATE  PROCEDURE [dbo].[CreateTestRecords]
AS
BEGIN
	SET NOCOUNT ON
	
	/* THIS SP IS ONLY FOR THE TEST CASE DATABASE */
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type IN (N'U'))
       DROP TABLE [dbo].[Item]

	CREATE TABLE [dbo].[Item](
		[ItemId]    [INT] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[ItemName]  [VARCHAR](100) NULL,
		[ItemDescription] [NVARCHAR](200) NULL,
		[ItemPrice] [DECIMAL](18, 2) NULL)

		/* 5 Test Items are inserted */
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Hammer','Hammer Description',100.00)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Hinges','Hinges Description',350.50)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Knobs','Knobs Description',200.00)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('Bolts','Bolts Description',150.00)
		INSERT INTO ITEM (ItemName,ItemDescription,ItemPrice)    VALUES ('PaintBrush','PaintBrush Description',100.00)

	SET NOCOUNT OFF
END

GO

/****** Object:  StoredProcedure [dbo].[InsertItem]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/***************************
AUTHOR : GAURISH ABHISHEKI
****************************/
CREATE PROCEDURE [dbo].[InsertItem]
(	
	@ItemName			VARCHAR(100),
 	@ItemDescription	NVARCHAR(200),
 	@ItemPrice			DECIMAL(18,2)
)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO Item (ItemName,ItemDescription,ItemPrice) VALUES (@ItemName,@ItemDescription,@ItemPrice)

	SELECT SCOPE_IDENTITY() AS ItemId

	SET NOCOUNT OFF
END
GO

/****** Object:  StoredProcedure [dbo].[UpdateItem]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/***************************
AUTHOR : GAURISH ABHISHEKI
****************************/
CREATE PROCEDURE [dbo].[UpdateItem]
(	
	@ItemId             INT,
	@ItemName			VARCHAR(100),
 	@ItemDescription	NVARCHAR(200),
 	@ItemPrice			DECIMAL(18,2)
	
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE Item SET ItemName = @ItemName,
	                ItemDescription = @ItemDescription,
					ItemPrice = @ItemPrice 
		    WHERE ItemId = @ItemId

	SET NOCOUNT OFF
END
GO

/****** Object:  StoredProcedure [dbo].[DeleteItem]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/***************************
AUTHOR : GAURISH ABHISHEKI
****************************/
CREATE PROCEDURE [dbo].[DeleteItem]
(	
	@ItemId             INT
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE FROM Item   WHERE ItemId = @ItemId

	SET NOCOUNT OFF
END
GO


