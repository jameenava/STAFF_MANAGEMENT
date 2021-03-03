using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
{
    public class Teaching : Staff
    {
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}
