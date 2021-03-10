using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    public abstract class Staff : IStaff
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
        private string designation;
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public virtual void DisplayStaff()
        {
            Console.Write("Staff:" + "INSTITUTE:" + this.Institute + " |" + "ID:" + this.Sid + "| "
            + "SALARY:" + this.Salary + " |" + "STAFF TYPE:" + this.Designation + "|");
        }
        public virtual void AddStaff(int sid)
        {
            //Nullable<int> salary = null;

            int flag2;
            do
            {
                flag2 = 0;
                Console.WriteLine("Enter salary");
                string inputSalary = Console.ReadLine();
                if (String.IsNullOrEmpty(inputSalary))
                {
                    this.Salary = null;
                    Console.WriteLine("Salary Not Entered");
                }
                else
                {
                    try
                    {
                        this.Salary = int.Parse(inputSalary);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Entered data is invalid");
                        flag2 = 1;
                    }
                }
            } while (flag2 == 1);
            this.Institute = "ABC SCHOOL";
        }
    }
}
