CREATE PROCEDURE [dbo].[spMemoInsert]
	@UserId INT,
	@About VARCHAR(2000)
AS
/*
	EXEC [dbo].[spMemoInsert]
*/

BEGIN

	INSERT INTO [dbo].MEMO
	( 
	 [UserId], [About], [CreatedDate]
	)
	VALUES
	( 
	 @UserId, @About, GETUTCDATE()
	)


END

