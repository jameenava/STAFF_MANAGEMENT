using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlType("Supporting")]
    [XmlRoot("Supporting")]
    //[DataContract]
    //[JsonConverter(typeof(StaffConverter))]
    public class Supporting : Staff
    {
        public string SupportArea { get; set; }
        public Supporting()
        {

        }
        public Supporting(int sid,int eid, int? salary, StaffType designation, string institutename, string supportArea) : base(sid,eid, salary, designation, institutename)
        {
            this.SupportArea = supportArea;

        }
        public Supporting(int sid, int? salary, StaffType designation, string institutename, string supportArea) : base(sid, salary, designation, institutename)
        {
            this.SupportArea = supportArea;

        }
    }
}
