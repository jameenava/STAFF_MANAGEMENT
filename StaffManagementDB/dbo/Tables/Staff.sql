CREATE TABLE [dbo].[Staff] (
    [StaffID]       INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeID]    INT        NOT NULL,
    [InstituteName] NCHAR (20) NOT NULL,
    [Salary]        INT        NULL,
    [StaffType]     INT        NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([StaffID] ASC),
    CONSTRAINT [AK_Staff] UNIQUE NONCLUSTERED ([EmployeeID] ASC)
);

