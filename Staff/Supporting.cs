using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public class Supporting : Staff
    {
        private string supportarea;

        public string SupportArea
        {
            get { return supportarea; }
            set { supportarea = value; }
        }
    }
}
