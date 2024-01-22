CREATE PROCEDURE [dbo].[spMemoInsert]
	@UserId INT,
	@About VARCHAR(2000),
	@Latitude DECIMAL(13,10),
	@Longitude DECIMAL(13,10),
	@Id INT = 0 OUTPUT
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

	SET @Id = SCOPE_IDENTITY();

END

