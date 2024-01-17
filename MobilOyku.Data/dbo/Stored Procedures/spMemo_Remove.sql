CREATE PROCEDURE [dbo].[spMemo_Remove]
	@MemoId INT
AS

/*
	EXEC [dbo].[spMemo_Remove]
*/

BEGIN

	DELETE FROM [dbo].[MEMO]
	WHERE 	[Id] = @MemoId;

END




