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
        public string AdminArea { get; set; }
        public Administration()
        {

        }
        public Administration(int sid, int eid, int? salary, StaffType designation, string institutename, string administrationArea) : base(sid, eid, salary, designation, institutename)
        {
            this.AdminArea = administrationArea;

        }
        public Administration(int sid, int? salary, StaffType designation, string institutename, string administrationArea) : base(sid, salary, designation, institutename)
        {
            this.AdminArea = administrationArea;

        }
    }
}
