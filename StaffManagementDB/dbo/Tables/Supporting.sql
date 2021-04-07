CREATE TABLE [dbo].[Supporting] (
    [SupportingID]   INT        IDENTITY (1, 1) NOT NULL,
    [StaffID]        INT        NOT NULL,
    [SupportingArea] NCHAR (10) NULL,
    CONSTRAINT [PK_Supporting] PRIMARY KEY CLUSTERED ([SupportingID] ASC),
    CONSTRAINT [FK_Supporting_Staff] FOREIGN KEY ([StaffID]) REFERENCES [dbo].[Staff] ([StaffID])
);

