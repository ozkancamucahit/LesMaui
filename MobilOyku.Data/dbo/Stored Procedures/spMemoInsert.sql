CREATE PROCEDURE [dbo].[spMemoInsert]
	@UserId INT,
	@About VARCHAR(2000),
	@Latitude DECIMAL(12,10),
	@Longitude DECIMAL(12,10)
AS
/*
	EXEC [dbo].[spMemoInsert]
*/

BEGIN

	INSERT INTO [dbo].MEMO
	( 
	 [UserId], [About], [CreatedDate],
	 [Latitude], [Longitude]
	)
	VALUES
	( 
	 @UserId, @About, GETUTCDATE(),
	 @Latitude, @Longitude
	)


END

