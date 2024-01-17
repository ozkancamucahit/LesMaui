CREATE PROCEDURE [dbo].[spPhoto_Remove]
	@PhotoId INT
AS


/*
	EXEC [dbo].[spPhoto_Remove]
*/

BEGIN

	DELETE FROM [dbo].[Photo]
	WHERE 	[Id] = @PhotoId;

END


