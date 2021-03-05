using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public abstract class Staff
    {
        private string instituteName;
        public string Institute
        {
            get { return instituteName; }
            set { instituteName = value; }
        }

        private int sid;
        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        private Nullable<int> salary;
        public Nullable<int> Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
