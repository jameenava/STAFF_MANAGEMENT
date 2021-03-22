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
        Staff UpdateStaff(int staffID,string subjectOrArea);
        int IfExists(int sid);

    }
}
