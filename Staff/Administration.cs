using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
{
    public class Administration : Staff
    {
        private string adminArea;

        public string AdminArea
        {
            get { return adminArea; }
            set { adminArea = value; }
        }
    }
}
