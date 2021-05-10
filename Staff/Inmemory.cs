using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlRoot("Staff")]
    public class Inmemory : IStaff
    {

        const string INSTITUTENAME = " ABC SCHOOL";
        internal List<Staff> staffList = new List<Staff>();
        [XmlElement("Staff")]
        public List<Staff> StaffList
        {
            get { return staffList; }
            set { staffList = value; }
        }
        public Staff GetStaffByID(int iD)
        {
            var item = staffList.FirstOrDefault(o => o.StaffID == iD);
            return item;
        }
        public bool DeleteStaff(int staffID)
        {

            bool result = false;
            var item = staffList.FirstOrDefault(o => o.StaffID == staffID);
            if (item != null)
            {
                result = staffList.Remove(item);
            }
            return result;

        }
        public void AddStaff(Staff staffObject)
        {

            staffList.Add(staffObject);
        }

        public void UpdateStaff(Staff staff)
        {
            staffList.Remove(staff);
            staffList.Add(staff);

        }

        public List<Staff> GetAllStaff()
        {
            return staffList;
        }

        public void BulkInsert(List<Staff> staffList)
        {
            foreach (Staff item in staffList)
            {
                this.staffList.Add(item);
            }

            
        }

        public List<Staff> GetEachStaffType(int choice)
        {
            List<Staff> staffTypeList=new List<Staff>();
            if (choice==1)
            {
                staffTypeList= staffList.Where(item => item.Designation == StaffType.Teaching).ToList();
            }
            else if(choice==2)
            {
                staffTypeList = staffList.Where(item => item.Designation == StaffType.Administration).ToList();
            }
            else
            {
                staffTypeList = staffList.Where(item => item.Designation == StaffType.Supporting).ToList();
            }
            return staffTypeList; 
        }
    }
}
