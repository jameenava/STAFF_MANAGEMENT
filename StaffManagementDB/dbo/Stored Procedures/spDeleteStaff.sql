

CREATE       procedure [dbo].[spDeleteStaff]
(
 @staffID int
)
as
begin try
begin transaction
declare @StaffType int
set @StaffType=(SELECT StaffType FROM Staff WHERE StaffID = @staffID)
	
    if(@StaffType=1)
	begin
		DELETE FROM Teaching 
            WHERE  StaffID = @staffID 
	end
	else if(@StaffType=2)
	begin
		DELETE FROM Administration 
            WHERE  StaffID = @staffID 
	end
	else 
	begin
		DELETE FROM Supporting 
            WHERE  StaffID = @staffID 
	end
	 DELETE FROM Staff  
            WHERE  StaffID = @staffID 
commit transaction
end try
begin catch
	rollback transaction
end catch