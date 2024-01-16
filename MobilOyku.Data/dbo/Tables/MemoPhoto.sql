CREATE TABLE [dbo].[MemoPhoto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemoId] INT NOT NULL, 
    [PhotoId] INT NOT NULL, 
    CONSTRAINT [FK_MemoPhoto_ToMemo] FOREIGN KEY ([MemoId]) REFERENCES [MEMO]([Id]), 
    CONSTRAINT [FK_MemoPhoto_ToPhoto] FOREIGN KEY ([PhotoId]) REFERENCES [Photo]([Id]) 
)
