CREATE PROCEDURE [dbo].[spUser_Insert]
	@UserName VARCHAR(50)
AS

/*
	EXEC [dbo].[spUser_Insert] ''
*/


IF LEN(@UserName) < 3
	BEGIN
		RAISERROR('USERNAME MUST BE AT LEAST 4 CHARACTERS', 16, 1);
		RETURN;
	END

INSERT INTO [dbo].[USER]
( 
 [UserName], [CreatedDate]
)
VALUES
( 
 @UserName, GETUTCDATE()
)
