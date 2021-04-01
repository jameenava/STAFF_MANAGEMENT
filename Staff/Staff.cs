using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlRoot("Staff")]
    [XmlType("Staff")] 
    [XmlInclude(typeof(Teaching)), XmlInclude(typeof(Administration)), XmlInclude(typeof(Supporting))]
    public abstract class Staff 
    {
        private string instituteName;
        public string Institute
        {
            get { return instituteName; }
            set { instituteName = value; }
        }

        private int staffID;
        public int StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        public int EmployeeID;

        private Nullable<int> salary;
        public Nullable<int> Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private int designation;
        public int Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        public Staff()
        {

        }
        public Staff(int sid,int eid,Nullable<int>salary,int designation,string institutename)
        {
            this.staffID = sid;
            this.EmployeeID = eid;
            this.Salary = salary;
            this.Designation = designation;
            this.Institute = institutename;
        }
        public Staff(int sid, Nullable<int> salary, int designation, string institutename)
        {
            this.staffID = sid;
            this.Salary = salary;
            this.Designation = designation;
            this.Institute = institutename;
        }
    }
}
