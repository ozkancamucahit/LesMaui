CREATE PROCEDURE [dbo].[spUserLookUp]
	@UserName VARCHAR(50)

AS
/*
	EXEC spUserLookUp ''
*/

BEGIN
	SET NOCOUNT ON;
	
	SELECT
	U.Id
	,U.UserName
	,U.CreatedDate
	FROM
		[dbo].[User] AS U (NOLOCK)
	WHERE
	U.UserName = @UserName;

END
