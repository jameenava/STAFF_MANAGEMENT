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
        public Administration()
        {

        }
        public Administration(int sid, int eid, Nullable<int> salary, int designation, string institutename, string administrationArea) : base(sid, eid, salary, designation, institutename)
        {
            this.AdminArea = administrationArea;

        }
        public Administration(int sid, Nullable<int> salary, int designation, string institutename, string administrationArea) : base(sid, salary, designation, institutename)
        {
            this.AdminArea = administrationArea;

        }
    }
}
