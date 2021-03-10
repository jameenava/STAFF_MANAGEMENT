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
        public override void AddStaff(int sid)
        {
            base.AddStaff(sid);
            Console.WriteLine("Enter subject");
            this.Subject = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(this.Subject))
            {
                this.Subject = null;
            }
            this.Designation = "Teaching";
           
        }
    }
}
