using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StaffLibrary
{
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

        public override void DisplayStaff()
        {
            Console.WriteLine("____________________________________________________________________");
            base.DisplayStaff();
            Console.Write("SUBJECT:/Area:" + this.Subject + "| ");
            Console.WriteLine(" ");
        }
        public override void AddStaff(int sid)
        {
            int flag;
            base.AddStaff(sid);
            do
            {
                flag = 0;
                Console.WriteLine("Enter subject");
                this.Subject = Console.ReadLine();
                //Console.WriteLine(SubjectList);
                //if (String.IsNullOrWhiteSpace(this.Subject))
                //{
                //    this.Subject = null;
                //}
                if (SubjectList.Split(",").Contains(this.Subject) == false)
                {
                    Console.WriteLine("Entered Subject is invalid");
                    flag = 1; 
                }

            } while (flag==1); 
            this.Designation = "Teaching";

        }
    }
}
