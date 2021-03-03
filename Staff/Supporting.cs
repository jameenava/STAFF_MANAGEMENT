using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
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
