
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using StaffLibrary;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Configuration;

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
        static void DisplayStorageMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Xml File");
            Console.WriteLine("2.Json File");
        }
        public static void DisplayAllStaff(List<Staff> staffs)
        {
            foreach (Staff staff in staffs)
            {
                DisplayStaff(staff);
            }

        }
        public static void DisplayStaff(Staff item)
        {
            Console.WriteLine("____________________________________________________________________");
            Console.Write("STAFF:" + "INSTITUTE:" + item.Institute + " |" + "ID:" + item.StaffID + "| " + "EMPLOYEE ID:" + item.EmployeeID +
            "| " + "SALARY:" + item.Salary + " |" + "STAFF TYPE:" + item.Designation);
            if (item.Designation == (int)StaffType.Teaching)
            {
                Console.Write(" |" + "AREA/SUBJECT:" + ((Teaching)item).Subject);
                Console.WriteLine(" ");
            }
            else if (item.Designation == (int)StaffType.Administration)
            {
                Console.Write(" |" + "AREA/SUBJECT:" + ((Administration)item).AdminArea);
                Console.WriteLine(" ");
            }
            else
            {
                Console.Write(" |" + "AREA/SUBJECT:" + ((Supporting)item).SupportArea);
                Console.WriteLine(" ");
            }
            Console.WriteLine("____________________________________________________________________");
        }
        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string currentDirectory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .AddJsonFile(currentDirectory + $"\\appSettings.Development.json", true, true);
            var config = builder.Build();
            ObjectHandle handle1 = Activator.CreateInstance("StaffLibrary", "StaffLibrary.DbProcedures");
            IStaff istaffObj = (IStaff)handle1.Unwrap();
            int yourChoice;
            var subjectForTeaching = config["SubjectList"];
            if (!string.IsNullOrEmpty(subjectForTeaching))
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

                        AddDetails(istaffObj);

                        break;
                    case 2:
                        List<Staff> staffs = istaffObj.ViewAllStaff();
                        DisplayAllStaff(staffs);
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id to be searched");
                        int iD = int.Parse(Console.ReadLine());
                        var item = istaffObj.SearchStaff(iD);
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
                        bool result = istaffObj.DeleteStaff(staffID);
                        if (result == true)
                            Console.WriteLine("Employee deleted");
                        else
                            Console.WriteLine("Employee with ID:" + staffID + " not found");
                        break;
                    case 5:
                        UpdateDetails(istaffObj);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }
        private static void AddDetails(IStaff istaffObj)
        {
            DisplayStaffMenu();
            Console.WriteLine("Enter the details of Staff");
            int staffChoice;
            staffChoice = int.Parse(Console.ReadLine());
            bool isStaff;
            int sid;
            Staff staffObject = null;

            do
            {
                Console.WriteLine("Enter the Staff ID");
                isStaff = false;
                try
                {
                    sid = int.Parse(Console.ReadLine());
                    var item = istaffObj.SearchStaff(sid);
                    if (item != null)
                    {
                        Console.WriteLine("Staff already exists with id:" + sid);
                        Console.WriteLine("Re enter ID");
                        isStaff = true;
                    }

                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        Console.WriteLine("Entered ID is invalid");
                    }
                    throw;
                }
            } while (isStaff);
            bool isSubject;
            bool isSalary;
            Nullable<int> salary = 0;
            do
            {
                isSalary = false;
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
                    catch (FormatException)
                    {
                        Console.WriteLine("Entered data is invalid");
                        isSalary = true;
                    }
                }
            } while (isSalary);
            string subject;
            if (staffChoice == 1)
            {
                do
                {
                    isSubject = false;
                    Console.WriteLine("Enter subject");
                    subject = Console.ReadLine();
                    if (Teaching.SubjectList.Split(",").Contains(subject) == false)
                    {
                        Console.WriteLine("Entered Subject is invalid");
                        isSubject = true;
                    }

                } while (isSubject);
                int designation = (int)StaffType.Teaching;
                staffObject = new Teaching(sid, salary, designation, INSTITUTENAME, subject);
            }
            else if (staffChoice == 2)
            {
                Console.WriteLine("Enter Administration area");
                string adminArea = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(adminArea))
                {
                    adminArea = null;
                }
                int designation = (int)StaffType.Administration;
                staffObject = new Administration(sid, salary, designation, INSTITUTENAME, adminArea);
            }

            else if (staffChoice == 3)
            {
                Console.WriteLine("Enter supporting area");
                string supportArea = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(supportArea))
                {
                    supportArea = null;
                }
                int designation = (int)StaffType.Supporting;
                staffObject = new Supporting(sid, salary, designation, INSTITUTENAME, supportArea);

            }
            else
            {
                Console.WriteLine("Invalid choice");
            }

            istaffObj.AddStaff(staffObject);
        }

        private static void UpdateDetails(IStaff istaffObj)
        {
            Console.WriteLine("Enter Employee Id which you want to update:");
            int staffID = int.Parse(Console.ReadLine());
            var item = istaffObj.SearchStaff(staffID);
            string subjectOrArea;
            int flag = 0;
            if (item != null)
            {
                Console.WriteLine("Enter the details to update");
                if (item.Designation == (int)StaffType.Teaching)
                {
                    Console.WriteLine("Old Subject is" + ((Teaching)item).Subject);
                    do
                    {
                        flag = 0;
                        Console.WriteLine("Enter new subject");
                        subjectOrArea = Console.ReadLine();
                        if (Teaching.SubjectList.Split(",").Contains(subjectOrArea) == false)
                        {
                            Console.WriteLine("Entered Subject is invalid");
                            flag = 1;
                        }

                    } while (flag == 1);

                }
                else if (item.Designation == (int)StaffType.Administration)
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

                istaffObj.UpdateStaff(staffID, subjectOrArea);
                Console.WriteLine("Staff Details are updated");

            }
            else
            {
                Console.WriteLine("Staff with id" + staffID + "does not exists");
            }
        }
    }
}
