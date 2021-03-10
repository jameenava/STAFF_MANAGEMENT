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
        public override void AddStaff(int sid)
        {
            base.AddStaff(sid);
            Console.WriteLine("Enter Administration area");
            this.AdminArea = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(this.AdminArea))
            {
                this.adminArea = null;
            }
            this.Designation = "Administration";
        }
    }
}
