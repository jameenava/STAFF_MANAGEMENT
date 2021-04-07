
 
CREATE       procedure [dbo].[spSearchStaff]
(
 @staffID int
)
as
begin try
begin transaction
select s.StaffID,s.EmployeeID,s.InstituteName,s.Salary,s.StaffType,t.Subject,a.AdministrationArea,st.SupportingArea from Staff as s 
 left join Teaching as t on s.StaffID=t.StaffID
 left join Administration as a on s.StaffID=a.StaffID
 left join Supporting as st on s.StaffID=st.StaffID
 where s.StaffID=@staffID 
commit transaction
end try
begin catch
	rollback transaction
end catch