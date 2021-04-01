using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public interface IStaff
    {
        void AddStaff(Staff staffObject);
        Staff SearchStaff(int iD);
        bool DeleteStaff(int staffID);
        void UpdateStaff(int staffID,string subjectOrArea);
        List<Staff> ViewAllStaff();

    }
}
