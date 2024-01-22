CREATE PROCEDURE [dbo].[spMemoGetMemoById]
	@memoId int 
AS
/*
	EXEC [dbo].[spMemoGetMemoById] 8
*/


SELECT
M.Id
,M.About
,M.CreatedDate
,M.Latitude
,M.Longitude
FROM
[dbo].[MEMO] AS M
WHERE
M.Id = @memoId;



