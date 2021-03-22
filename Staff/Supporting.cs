using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlType("Supporting")]
    [XmlRoot("Supporting")]
    public class Supporting : Staff
    {
        private string supportarea;

        public string SupportArea
        {
            get { return supportarea; }
            set { supportarea = value; }
        }
        public Supporting()
        {

        }
        public Supporting(int sid, Nullable<int> salary, string designation, string institutename, string supportArea) : base(sid, salary, designation, institutename)
        {
            this.SupportArea = supportArea;

        }
    }
}
