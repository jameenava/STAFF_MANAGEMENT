using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public class Supporting : Staff, IStaff
    {
        private string supportarea;

        public string SupportArea
        {
            get { return supportarea; }
            set { supportarea = value; }
        }
        public override void DisplayStaff()
        {
            Console.WriteLine("____________________________________________________________________");
            base.DisplayStaff();
            Console.Write("SUBJECT:/Area:" + this.SupportArea + "| ");
            Console.WriteLine(" ");
        }
        public override void AddStaff(int sid, List<Staff> staffList)
        {
            base.AddStaff(sid, staffList);
            Console.WriteLine("Enter supporting area");
            string supportingArea = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(supportingArea))
            {
                supportingArea = null;
            }
            string designation = "Supporting";
            staffList.Add(item: new Supporting() { Institute = Institute, Designation = designation, Sid = sid, Salary = Salary, SupportArea = supportingArea });

        }
    }
}
