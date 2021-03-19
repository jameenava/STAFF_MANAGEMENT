using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlType("Teaching")]
    [XmlRoot("Teaching")]
    public class Teaching : Staff
    {
        
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private static string subjectList;

        public static string SubjectList
        {
            get { return subjectList; }
            set { subjectList = value; }
        }

        //public override void DisplayStaff()
        //{
           
        //}
        public Teaching()
        {

        }
        public Teaching(int sid,Nullable<int>salary,string designation,string institutename,string subject):base(sid,salary,designation,institutename)
        {
            this.Subject = subject;
           
        }
    }
}
