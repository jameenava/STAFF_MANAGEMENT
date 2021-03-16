
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using StaffLibrary;
using System.IO;
namespace StaffManagement
{
    class Program

    {
        const string INSTITUTENAME = "ABC SCHOOL";
        static void DisplayStaffOpMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Add staff record");
            Console.WriteLine("2.View all staff records");
            Console.WriteLine("3.Search a staff record");
            Console.WriteLine("4.Delete a staff record");
            Console.WriteLine("5.Update a staff record");
            Console.WriteLine("6.Exit");
        }
        static void DisplayStaffMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Teaching");
            Console.WriteLine("2.Admistrating");
            Console.WriteLine("3.Supporting");
        }
        public static void DisplayStaff(Staff staff)
        {

            Console.WriteLine("____________________________________________________________________");
            Console.Write("STAFF:" + "INSTITUTE:" + staff.Institute + " |" + "ID:" + staff.StaffID + "| " + "SALARY:" + staff.Salary + " |" + "STAFF TYPE:" + staff.Designation);
            if (staff.Designation == Enum.GetName(typeof(StaffType), 1))
            {

                Console.Write(" |" + "AREA/SUBJECT:" + ((Teaching)staff).Subject);
                Console.WriteLine(" ");
            }
            else if (staff.Designation == Enum.GetName(typeof(StaffType), 2))
            {

                Console.Write(" |" + "AREA/SUBJECT:" + ((Administration)staff).AdminArea);
                Console.WriteLine(" ");
            }
            else
            {
                Console.Write(" |" + "AREA/SUBJECT:" + ((Supporting)staff).SupportArea);
                Console.WriteLine(" ");
            }
            Console.WriteLine("____________________________________________________________________");
        }
        public static void ViewAllStaff(List<Staff> staffList)
        {
            foreach (Staff t in staffList)
            {
                DisplayStaff(t);
            };

        }
        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string currentDirectory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .AddJsonFile(currentDirectory + $"\\appSettings.Development.json", true, true);
                //.AddJsonFile($"appsettings.{env}.json", true, true)
                //.AddEnvironmentVariables();
            var config = builder.Build();
            int yourChoice;
            Inmemory inmemoryObj = new Inmemory();

            var subjectForTeaching = config["SubjectList"];
            if(!string.IsNullOrEmpty(subjectForTeaching))
            {
                Teaching.SubjectList = subjectForTeaching;
            }
           
            do
            {
                DisplayStaffOpMenu();
                Console.Write("Enter your choice:");
                yourChoice = int.Parse(Console.ReadLine());

                switch (yourChoice)
                {
                    case 1:
                        DisplayStaffMenu();
                        Console.WriteLine("Enter the details of Staff");
                        int staffChoice;
                        staffChoice = int.Parse(Console.ReadLine());
                        int flag1;
                        int sid;
                        Staff staffObject = null;

                        do
                        {
                            Console.WriteLine("Enter the Staff ID");
                            flag1 = 0;
                            try
                            {
                                sid = int.Parse(Console.ReadLine());
                                if ((inmemoryObj.StaffList.Exists(s => s.StaffID == sid) &&inmemoryObj.StaffList.Count > 0))
                                {
                                    Console.WriteLine("Staff already exists with id:" + sid);
                                    Console.WriteLine("Re enter ID");
                                    flag1 = 1;
                                }

                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException || ex is OverflowException)
                                {
                                    Console.WriteLine("Entered ID is invalid");
                                    flag1 = 1;
                                }
                                throw;
                            }
                        } while (flag1 == 1);
                        int flag;
                        //base.AddStaff(sid);
                        int flag2;
                        Nullable<int> salary = 0;
                        do
                        {
                            flag2 = 0;
                            Console.WriteLine("Enter salary");
                            string inputSalary = Console.ReadLine();
                            if (String.IsNullOrEmpty(inputSalary))
                            {
                                salary = null;
                                Console.WriteLine("Salary Not Entered");
                            }
                            else
                            {
                                try
                                {
                                    salary = int.Parse(inputSalary);
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Entered data is invalid");
                                    flag2 = 1;
                                }
                            }
                        } while (flag2 == 1);
                        string subject;

                        if (staffChoice == 1)
                        {
                            do
                            {
                                flag = 0;
                                Console.WriteLine("Enter subject");
                                subject = Console.ReadLine();
                                //Console.WriteLine(SubjectList);
                                //if (String.IsNullOrWhiteSpace(this.Subject))
                                //{
                                //    this.Subject = null;
                                //}
                                if (Teaching.SubjectList.Split(",").Contains(subject) == false)
                                {
                                    Console.WriteLine("Entered Subject is invalid");
                                    flag = 1;
                                }

                            } while (flag == 1);
                            string designation = Enum.GetName(typeof(StaffType), 1);
                            staffObject = new Teaching(sid, salary, designation, INSTITUTENAME, subject);
                            //staffObject.AddStaff(sid);
                        }
                        else if (staffChoice == 2)
                        {
                            Console.WriteLine("Enter Administration area");
                            string adminArea = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(adminArea))
                            {
                                adminArea = null;
                            }
                            string designation = Enum.GetName(typeof(StaffType), 2);
                            staffObject = new Administration(sid, salary, designation, INSTITUTENAME, adminArea);
                            //staffObject = new Administration();
                            //staffObject.AddStaff(sid);
                        }

                        else if (staffChoice == 3)
                        {
                            Console.WriteLine("Enter supporting area");
                            string supportArea = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(supportArea))
                            {
                                supportArea = null;
                            }
                            string designation = Enum.GetName(typeof(StaffType), 3);
                            // staffObject = new Supporting();
                            //staffObject.AddStaff(sid);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }

                        inmemoryObj.AddStaff(staffObject);
                        break;
                    case 2:
                        ViewAllStaff(inmemoryObj.StaffList);
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id to be searched");
                        int iD = int.Parse(Console.ReadLine());
                        var item=inmemoryObj.SearchStaff(iD);
                        if (item != null)
                        {
                            DisplayStaff(item);
                        }
                        else
                        {
                            Console.WriteLine("Staff with id:" + iD + " does not exist");

                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Staff Id which you want to delete:");
                        int staffID = int.Parse(Console.ReadLine());
                        bool result=inmemoryObj.DeleteStaff(staffID);
                        if (result == true)
                            Console.WriteLine("Employee deleted");
                        else
                            Console.WriteLine("Employee with ID:" + staffID + " not found");
                        break;
                    case 5:
                        Console.WriteLine("Enter Staff Id which you want to update:");
                        staffID = int.Parse(Console.ReadLine());
                        item = inmemoryObj.StaffList.FirstOrDefault(o => o.StaffID == staffID);
                        string subjectOrArea;
                        if (item!=null)
                        {
                            Console.WriteLine("Enter the details to update");
                            if (item.Designation == Enum.GetName(typeof(StaffType), 1))
                            {
                                Console.WriteLine("Old Subject is" + ((Teaching)item).Subject);
                                do
                                {
                                    flag = 0;
                                    Console.WriteLine("Enter new subject");
                                    subjectOrArea = Console.ReadLine();
                                    //Console.WriteLine(SubjectList);
                                    //if (String.IsNullOrWhiteSpace(this.Subject))
                                    //{
                                    //    this.Subject = null;
                                    //}
                                    if (Teaching.SubjectList.Split(",").Contains(subjectOrArea) == false)
                                    {
                                        Console.WriteLine("Entered Subject is invalid");
                                        flag = 1;
                                    }

                                } while (flag == 1);

                            }
                            else if (item.Designation == Enum.GetName(typeof(StaffType), 2))
                            {
                                Console.WriteLine("Old area is" + ((Administration)item).AdminArea);
                                Console.WriteLine("Enter Administration area");
                                subjectOrArea = Console.ReadLine();
                                if (String.IsNullOrWhiteSpace(subjectOrArea))
                                {
                                    subjectOrArea = null;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Old area is" + ((Supporting)item).SupportArea);
                                Console.WriteLine("Enter Administration area");
                                subjectOrArea = Console.ReadLine();
                                if (String.IsNullOrWhiteSpace(subjectOrArea))
                                {
                                    subjectOrArea = null;
                                }
                            }

                            inmemoryObj.UpdateStaff(staffID, subjectOrArea);

                        }
                        break;
                    case 6:
                        return;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }
    }
}
