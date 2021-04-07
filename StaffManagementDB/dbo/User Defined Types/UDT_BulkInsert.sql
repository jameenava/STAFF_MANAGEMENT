CREATE TYPE [dbo].[UDT_BulkInsert] AS TABLE (
    [EmployeeID]    INT        NOT NULL,
    [InstituteName] NCHAR (20) NOT NULL,
    [Salary]        INT        NULL,
    [StaffType]     INT        NULL,
    [SubjectOrArea] NCHAR (10) NULL);

