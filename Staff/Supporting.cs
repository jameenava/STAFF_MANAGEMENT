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
        public override void AddStaff(int sid)
        {
            base.AddStaff(sid);
            Console.WriteLine("Enter supporting area");
            this.SupportArea = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(this.SupportArea))
            {
                this.SupportArea = null;
            }
            this.Designation = "Supporting";

        }
    }
}
