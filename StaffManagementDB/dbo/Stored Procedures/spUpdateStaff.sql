




CREATE   procedure [dbo].[spUpdateStaff]
(
 @staffId int,
 @subjectorArea nchar(10)

)
as 
begin try
	begin transaction
		set nocount on;
		declare @StaffType int
		set @StaffType=(SELECT StaffType FROM Staff WHERE StaffID = @staffId)
		if (@staffType=1)
		begin
			 update Teaching  
            set    Subject = @subjectorArea  
            where  StaffID = @staffId 
           
		end
		else if(@staffType=2)
		begin
			 update Administration  
            set    AdministrationArea = @subjectorArea  
            where  StaffID = @staffId 
		end
		else
		begin
			 update Supporting  
            set    SupportingArea = @subjectorArea  
            where  StaffID = @staffId 
		end
	commit transaction
end try
begin catch
	rollback transaction
end catch