using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
{
    public abstract class Staff
    {
        private string instituteName;
        public string Institute
        {
            get { return instituteName; }
            set { instituteName = value; }
        }

        private string sid;
        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        private float salary;
        public float Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
