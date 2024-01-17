CREATE PROCEDURE [dbo].[spLookupMemo]
	@Username VARCHAR(50)

AS

BEGIN

	/*
		EXEC [dbo].[spLookupMemo] ''
	
	*/

SELECT
	M.Id
	,M.About
	,M.CityId
	,M.CreatedDate AS [MemoDate]
	,U.UserName
	,P.FilePath AS [PhotoFilePath]
	,P.CreatedDate AS [PhotoCreateDate]
FROM
	[dbo].MEMO AS M (NOLOCK)
	INNER JOIN [dbo].[USER] AS U (NOLOCK) ON U.Id = M.UserId
	LEFT JOIN [dbo].[MemoPhoto] AS MP (NOLOCK) ON MP.MemoId = M.Id
	LEFT JOIN [dbo].[Photo] AS P (NOLOCK) ON P.Id = MP.PhotoId

WHERE
	U.UserName = @Username;

END






