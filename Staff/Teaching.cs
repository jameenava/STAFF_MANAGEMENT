using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public class Teaching : Staff
    {
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public override void DisplayStaff()
        {
            Console.WriteLine("____________________________________________________________________");
            base.DisplayStaff();
            Console.Write("SUBJECT:/Area:" + this.Subject + "| ");
            Console.WriteLine(" ");
        }
        public override void AddStaff(int sid, List<Staff> staffList)
        {
            base.AddStaff(sid, staffList);
            Console.WriteLine("Enter subject");
            string subject = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(subject))
            {
                subject = null;
            }
            string designation = "Teaching";
            staffList.Add(item: new Teaching() { Institute = Institute, Designation = designation, Sid = sid, Salary = Salary, Subject = subject });

        }
    }
}
