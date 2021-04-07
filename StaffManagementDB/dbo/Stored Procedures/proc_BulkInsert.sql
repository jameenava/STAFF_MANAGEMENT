CREATE PROCEDURE [dbo].[proc_BulkInsert]
(
 
@UserDefineTable [dbo].[UDT_BulkInsert] readonly
 
 )
--- Here i am assign User_Define_Table_Type to Variable and making it readonly
 
AS
 BEGIN
 begin try
	begin transaction
		set nocount on;
		declare @id int;
		insert into Staff(EmployeeID,InstituteName,Salary,StaffType)
		select EmployeeID,InstituteName,Salary,StaffType from @UserDefineTable
		insert into Teaching
		select s.StaffID, udt.SubjectorArea
		from Staff s
		inner join @UserDefineTable udt on (s.EmployeeID = udt.EmployeeID)
		where s.StaffType=1
		insert into Administration
		select s.StaffID, udt.SubjectorArea
		from Staff s
		inner join @UserDefineTable udt on (s.EmployeeID = udt.EmployeeID)
		where s.StaffType=2
		insert into Supporting
		select s.StaffID, udt.SubjectorArea
		from Staff s
		inner join @UserDefineTable udt on (s.EmployeeID = udt.EmployeeID)
		where s.StaffType=3

		
	commit transaction
end try
begin catch
	rollback transaction
end catch
 END