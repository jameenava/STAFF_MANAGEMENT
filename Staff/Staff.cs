using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StaffLibrary
{
    [XmlRoot("Staff")]
    [XmlType("Staff")] 
    [XmlInclude(typeof(Teaching)), XmlInclude(typeof(Administration)), XmlInclude(typeof(Supporting))]
    public abstract class Staff 
    {
        public string Institute { get; set; }
        public int StaffID { get; set; }
        public int? Salary { get; set; }

        public StaffType Designation { get; set; }
        public int EmployeeID;
        public Staff()
        {

        }
        public Staff(int sid, int eid, int? salary, StaffType designation, string institutename)
        {
            if (string.IsNullOrEmpty(institutename))
            {
                throw new ArgumentException($"'{nameof(institutename)}' cannot be null or empty", nameof(institutename));
            }

            this.StaffID = sid;
            this.EmployeeID = eid;
            this.Salary = salary ?? throw new ArgumentNullException(nameof(salary));
            this.Designation = designation;
            this.Institute = institutename;
        }
        public Staff(int sid, int? salary, StaffType designation, string institutename)
        {
            this.StaffID = sid;
            this.Salary = salary;
            this.Designation = designation;
            this.Institute = institutename;
        }
    }
}
