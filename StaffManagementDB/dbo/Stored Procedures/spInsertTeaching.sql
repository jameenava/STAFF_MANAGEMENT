



CREATE procedure [dbo].[spInsertTeaching]
(
 @employeeID int,
 @instituteName nchar(20),
 @salary int,
 @staffType int,
 @subjectorArea nchar(10)

)
as 
begin try
	begin transaction
		set nocount on;
		declare @id int;
		insert into Staff values(@employeeID,@instituteName,@salary,@staffType )
		set @id = @@IDENTITY;
		--select @id;
		--select * from Staff;
		if (@staffType=1)
		begin
			insert into Teaching(staffID,subject)values(@id,@subjectorArea);  
		end
		else if(@staffType=2)
		begin
			insert into Administration(StaffID,AdministrationArea)values(@id,@subjectorArea)
		end
		else
		begin
			insert into Supporting(StaffID,SupportingArea)values(@id,@subjectorArea)
		end
	commit transaction
end try
begin catch
	rollback transaction
end catch