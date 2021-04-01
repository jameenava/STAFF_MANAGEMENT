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
        public List<Staff> staffList = new List<Staff>();
        [XmlElement("Staff")]
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


        public Staff SearchStaff(int iD)
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

        public void UpdateStaff(int staffID, string subjectOrArea)
        {
            var item = staffList.FirstOrDefault(o => o.StaffID == staffID);
            if (item.Designation == (int)StaffType.Teaching)
            {
                ((Teaching)item).Subject = subjectOrArea;
            }
            else if (item.Designation == (int)StaffType.Administration)
            {
                ((Administration)item).AdminArea = subjectOrArea;
            }
            else
            {
                ((Supporting)item).SupportArea = subjectOrArea;
            }

        }

        public List<Staff> ViewAllStaff()
        {
            return this.staffList;
        }
    }
}
