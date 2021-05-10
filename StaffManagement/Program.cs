
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
            Console.WriteLine("6.Insert multiple staff records");
            Console.WriteLine("7.Exit");
        }
        static void DisplayStaffMenu()
        {
            Console.WriteLine("Select Staff Type:");
            foreach (int i in Enum.GetValues(typeof(StaffType)))
            {
                Console.WriteLine($" {(int)i}. {((StaffType)i)}");
            }
        }
        public static void DisplayAllStaff(List<Staff> staffs)
        {
            foreach (Staff staff in staffs)
            {
                DisplayStaff(staff);
            }

        }
        private static string GetSubjectFromUser()
        {
            string subject;
            while (1 == 1)
            {
                var subjects = Teaching.SubjectList.Split(",");
                Console.WriteLine("Select Subject");
                for (int i = 0; i < subjects.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {subjects[i]}");
                }
                int.TryParse(Console.ReadLine(), out int subjectID);
                if (subjectID == 0)
                {
                    Console.WriteLine("Entered Subject is invalid");
                    continue;
                }
                else
                {
                    subject = subjects[subjectID - 1];
                    break;
                }
            }

            return subject;
        }

        public static void DisplayStaff(Staff item)
        {
            Console.WriteLine("____________________________________________________________________");
            Console.Write("STAFF:" + "INSTITUTE:" + item.Institute + " |" + "ID:" + item.StaffID + "| " + "EMPLOYEE ID:" + item.EmployeeID +
            "| " + "SALARY:" + item.Salary + " |" + "STAFF TYPE:" + item.Designation);
            if (item.Designation == StaffType.Teaching)
            {
                Console.Write(" |" + "AREA/SUBJECT:" + ((Teaching)item).Subject);
                Console.WriteLine(" ");
            }
            else if (item.Designation == StaffType.Administration)
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
            string managerClassTypeString = config["StorageType"];

            //get the type of the class
            Type managerClassType = Type.GetType("StaffLibrary." + managerClassTypeString + ",StaffLibrary", true);

            //build an instance of the class
            IStaff manager = Activator.CreateInstance(managerClassType) as IStaff;
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


                        Staff StaffObj = AddDetails(manager);
                        manager.AddStaff(StaffObj);
                        break;
                    case 2:
                        DisplayStaffMenu();
                        int choice;
                        choice = int.Parse(Console.ReadLine());
                        //DisplayStaffList(choice);
                        DisplayAllStaff(manager.GetEachStaffType(choice));
                        //DisplayAllStaff(manager.GetAllStaff());
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id to be searched");
                        int iD = int.Parse(Console.ReadLine());
                        var item = manager.GetStaffByID(iD);
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
                        bool result = manager.DeleteStaff(staffID);
                        if (result == true)
                            Console.WriteLine("Employee deleted");
                        else
                            Console.WriteLine("Employee with ID:" + staffID + " not found");
                        break;
                    case 5:
                        UpdateDetails(manager);
                        break;
                    case 6:
                        int numberOfStaff, i;
                        List<Staff> staffList = new List<Staff>();
                        Console.WriteLine("Enter the number of records do you want to insert");
                        numberOfStaff = int.Parse(Console.ReadLine());
                        for (i = 0; i < numberOfStaff; i++)
                        {
                            Staff staffObj = AddDetails(manager);
                            staffList.Add(staffObj);

                        }
                        manager.BulkInsert(staffList);
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }

        private static Staff AddDetails(IStaff istaffObj)
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
                    var item = istaffObj.GetStaffByID(sid);
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
            if (staffChoice == 1)
            {
                string subject = GetSubjectFromUser();
                staffObject = new Teaching(sid, salary, StaffType.Teaching, INSTITUTENAME, subject);
            }
            else if (staffChoice == 2)
            {
                Console.WriteLine("Enter Administration area");
                string adminArea = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(adminArea))
                {
                    adminArea = null;
                }
                staffObject = new Administration(sid, salary, StaffType.Administration, INSTITUTENAME, adminArea);
            }

            else if (staffChoice == 3)
            {
                Console.WriteLine("Enter supporting area");
                string supportArea = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(supportArea))
                {
                    supportArea = null;
                }
                staffObject = new Supporting(sid, salary, StaffType.Supporting, INSTITUTENAME, supportArea);

            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
            return staffObject;
        }

        private static void UpdateDetails(IStaff istaffObj)
        {
            Console.WriteLine("Enter Employee Id which you want to update:");
            int staffID = int.Parse(Console.ReadLine());
            var item = istaffObj.GetStaffByID(staffID);
            string subjectOrArea;
            if (item != null)
            {
                Console.WriteLine("Enter the details to update");
                if (item.Designation == StaffType.Teaching)
                {
                    Console.WriteLine("Old Subject is" + ((Teaching)item).Subject);
                    string subject = GetSubjectFromUser();
                    ((Teaching)item).Subject = subject;

                }
                else if (item.Designation == StaffType.Administration)
                {
                    Console.WriteLine("Old area is" + ((Administration)item).AdminArea);
                    Console.WriteLine("Enter Administration area");
                    subjectOrArea = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(subjectOrArea))
                    {
                        subjectOrArea = null;
                    }
                    ((Administration)item).AdminArea = subjectOrArea;

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
                     ((Supporting)item).SupportArea = subjectOrArea;
                }

                istaffObj.UpdateStaff(item);
                Console.WriteLine("Staff Details are updated");

            }
            else
            {
                Console.WriteLine("Staff with id" + staffID + "does not exists");
            }
        }
    }
}
