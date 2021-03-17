using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StaffLibrary
{
    public class Inmemory : IStaff
    {
        
        const string INSTITUTENAME = " ABC SCHOOL";
        private List<Staff> staffList = new List<Staff>();

        public List<Staff> StaffList
        {
            get { return staffList; }
            set { staffList = value; }
        }

        public int IfExists(int sid)
        {
            int flag = 0;
            if ((StaffList.Exists(s => s.StaffID == sid) && StaffList.Count > 0))
            {
                flag = 1;
            }
            return flag;
        }


        public  Staff SearchStaff(int iD)
        {
            var item = staffList.FirstOrDefault(o => o.StaffID == iD);
            Console.WriteLine(item);
            return item;
        }
        public bool DeleteStaff(int staffID)
        {
            
            bool result = false;
            var item = staffList.FirstOrDefault(o => o.StaffID == staffID);
            if(item!=null)
            {
                result = staffList.Remove(item);
            }
            return result;

        }
        //public  Staff ViewAllStaff()
        //{
        //    foreach (Staff t in staffList)
    
        //}

        public void AddStaff(Staff staffObject)
        {
            
            staffList.Add(staffObject);
           

        }

        public Staff UpdateStaff(int staffID,string subjectOrArea)
        {
            var item = staffList.FirstOrDefault(o => o.StaffID == staffID);
            if(item.Designation== Enum.GetName(typeof(StaffType), 1))
            {
                ((Teaching)item).Subject = subjectOrArea;
            }
            else if (item.Designation == Enum.GetName(typeof(StaffType), 2))
            {
                ((Administration)item).AdminArea = subjectOrArea;
            }
            else
            {
                ((Supporting)item).SupportArea = subjectOrArea;
            }
            return item;
        }
    }
}
