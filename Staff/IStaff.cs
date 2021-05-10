using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public interface IStaff
    {
        void AddStaff(Staff staffObject);
        Staff GetStaffByID(int iD);
        bool DeleteStaff(int staffID);
        // void UpdateStaff(int staffID,string subjectOrArea);
        void UpdateStaff(Staff staff);
        List<Staff> GetAllStaff();
        public void BulkInsert(List<Staff> staffList);
        List<Staff> GetEachStaffType(int choice);
    }
}
