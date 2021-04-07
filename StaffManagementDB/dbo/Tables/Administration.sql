CREATE TABLE [dbo].[Administration] (
    [AdministrationID]   INT        IDENTITY (1, 1) NOT NULL,
    [StaffID]            INT        NOT NULL,
    [AdministrationArea] NCHAR (10) NULL,
    CONSTRAINT [PK_Administration] PRIMARY KEY CLUSTERED ([AdministrationID] ASC),
    CONSTRAINT [FK_Administration_Staff] FOREIGN KEY ([StaffID]) REFERENCES [dbo].[Staff] ([StaffID])
);

