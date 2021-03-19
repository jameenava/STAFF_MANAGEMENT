using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlType("Administration")]
    [XmlRoot("Administration")]
    public class Administration : Staff
    {
        private string adminArea;

        public string AdminArea
        {
            get { return adminArea; }
            set { adminArea = value; }
        }
        //public override void DisplayStaff()
        //{
        //    Console.WriteLine("____________________________________________________________________");
        //    base.DisplayStaff();
        //    Console.Write("SUBJECT:/Area:" + this.AdminArea + "| ");
        //    Console.WriteLine(" ");
        //}
        public Administration()
        {

        }
        public Administration(int sid, Nullable<int> salary, string designation, string institutename, string administrationArea) : base(sid, salary, designation, institutename)
        {
            this.AdminArea = administrationArea;

        }
        //public override void AddStaff(int sid)
        //{
        //    base.AddStaff(sid);
            
        //}
    }
}
