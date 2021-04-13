using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StaffLibrary
{
    [XmlType("Teaching")]
    [XmlRoot("Teaching")]
    //[DataContract]
    //[JsonConverter(typeof(StaffConverter))]
    public class Teaching : Staff
    {

        public string Subject { get; set; }

        public static string SubjectList { get; set; }
        public Teaching()
        {

        }
        public Teaching(int sid, int eid, int? salary, StaffType designation, string institutename, string subject): base(sid, eid, salary, designation, institutename)
        {
            this.Subject = subject;

        }
        public Teaching(int sid, int? salary, StaffType designation, string institutename, string subject): base(sid, salary, designation, institutename)
        {
            this.Subject = subject;
        }
    }
}
