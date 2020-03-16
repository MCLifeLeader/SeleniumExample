CREATE TABLE [dbo].[Configuration] (
    [Id]       UNIQUEIDENTIFIER     NOT NULL DEFAULT NewId(),
    [Key]      NVARCHAR(50)         NOT NULL, 
    [Value]    NVARCHAR(MAX)        NOT NULL, 
    [IsActive] BIT                  NOT NULL DEFAULT 1, 
    [DateCreated] DATETIME NOT NULL DEFAULT GetUtcDate(), 
    [LastUpdated] DATETIME NOT NULL DEFAULT GetUtcDate(), 
    CONSTRAINT [PK_Configuration] PRIMARY KEY ([Id])
);

GO

-- Allow only a unique set of configurations
CREATE UNIQUE INDEX [IX_Configuration_Key] ON [dbo].[Configuration] ([Key])
