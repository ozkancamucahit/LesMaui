﻿CREATE TABLE [dbo].[MEMO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [About] VARCHAR(2000) NULL, 
    [CityId] INT NULL, 
    [UserId] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [Latitude] DECIMAL(8, 6) NULL, 
    [Longitude] DECIMAL(9, 6) NULL, 
    CONSTRAINT [FK_MEMO_ToUser] FOREIGN KEY ([UserId]) REFERENCES [USER]([Id])
)
