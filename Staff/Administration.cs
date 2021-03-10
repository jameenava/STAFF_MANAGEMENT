using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public class Administration : Staff, IStaff
    {
        private string adminArea;

        public string AdminArea
        {
            get { return adminArea; }
            set { adminArea = value; }
        }
        public override void DisplayStaff()
        {
            Console.WriteLine("____________________________________________________________________");
            base.DisplayStaff();
            Console.Write("SUBJECT:/Area:" + this.AdminArea + "| ");
            Console.WriteLine(" ");
        }
        public override void AddStaff(int sid, List<Staff> staffList)
        {
            base.AddStaff(sid, staffList);
            Console.WriteLine("Enter Administration area");
            string administrationArea = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(administrationArea))
            {
                administrationArea = null;
            }
            string designation = "Administration";
            staffList.Add(item: new Administration() { Institute = Institute, Designation = designation, Sid = sid, Salary = Salary, AdminArea = administrationArea });

        }
    }
}
