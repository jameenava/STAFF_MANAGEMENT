CREATE TABLE [dbo].[Teaching] (
    [TeachingID] INT        IDENTITY (1, 1) NOT NULL,
    [StaffID]    INT        NOT NULL,
    [Subject]    NCHAR (10) NOT NULL,
    CONSTRAINT [PK_Teaching] PRIMARY KEY CLUSTERED ([TeachingID] ASC),
    CONSTRAINT [FK_Teaching_Staff] FOREIGN KEY ([StaffID]) REFERENCES [dbo].[Staff] ([StaffID])
);

