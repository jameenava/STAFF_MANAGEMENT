using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
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

        private Nullable<int> salary;
        public Nullable<int> Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private string designation;
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        //public virtual void DisplayStaff()
        //{
        //    Console.Write("Staff:" + "INSTITUTE:" + this.Institute + " |" + "ID:" + this.StaffID + "| "
        //    + "SALARY:" + this.Salary + " |" + "STAFF TYPE:" + this.Designation + "|");
        //}
        public Staff(int sid,Nullable<int>salary,string designation,string institutename)
        {
            this.StaffID = sid;
            this.Salary = salary;
            this.Designation = designation;
            this.Institute = institutename;
        }
        //public virtual void AddStaff(int sid)
        //{
        //    //Nullable<int> salary = null;
           
        //}
    }
}
