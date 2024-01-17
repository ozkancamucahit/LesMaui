CREATE PROCEDURE [dbo].[spPhoto_Insert]
	@FilePath NVARCHAR(200),
	@MemoId INT
AS

/*
	EXEC [dbo].[spPhoto_Insert] ''
*/

BEGIN

	--INSERT INTO [dbo].Photo(FilePath, CreatedDate)
	--VALUES (@FilePath, GETUTCDATE());

	INSERT INTO [dbo].[Photo]
	(
	 FilePath, CreatedDate
	)
	VALUES
	( 
	 @FilePath, GETUTCDATE()
	)

	DECLARE @PhotoId INT;

	SET @PhotoId = SCOPE_IDENTITY();

	-- Insert rows into table 'TableName'
	INSERT INTO [dbo].[MemoPhoto]
	( 
	 [MemoId], [PhotoId]
	)
	VALUES
	(
	 @MemoId, @PhotoId
	);

END


