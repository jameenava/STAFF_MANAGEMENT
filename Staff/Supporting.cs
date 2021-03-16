using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public class Supporting : Staff
    {
        private string supportarea;

        public string SupportArea
        {
            get { return supportarea; }
            set { supportarea = value; }
        }
        //public override void DisplayStaff()
        //{
        //    Console.WriteLine("____________________________________________________________________");
        //    base.DisplayStaff();
        //    Console.Write("SUBJECT:/Area:" + this.SupportArea + "| ");
        //    Console.WriteLine(" ");
        //}
        public Supporting(int sid, Nullable<int> salary, string designation, string institutename, string supportArea) : base(sid, salary, designation, institutename)
        {
            this.SupportArea = supportArea;

        }
        //public override void AddStaff(int sid)
        //{
        //    base.AddStaff(sid);
            

        //}
    }
}
