
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
        const string INSTITUTENAME = " ABC SCHOOL";
        static void DisplayStaffMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Teaching");
            Console.WriteLine("2.Admistrating");
            Console.WriteLine("3.Supporting");
        }
        public enum StaffType { Teaching = 1, Administration = 2, Supporting = 3 };
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
            int staffChoice;
            List<Staff> staffList = new List<Staff>();
            var subjectForTeaching = config["SubjectList"];
            if(!string.IsNullOrEmpty(subjectForTeaching))
            {
                Teaching.SubjectList = subjectForTeaching;
            }
           
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Add staff record");
                Console.WriteLine("2.View all staff records");
                Console.WriteLine("3.Search a staff record");
                Console.WriteLine("4.Delete a staff record");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice:");
                yourChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the details of Staff");

                switch (yourChoice)
                {
                    case 1:
                        DisplayStaffMenu();
                        staffChoice = int.Parse(Console.ReadLine());
                        int flag1;
                        int sid = 0;
                        Staff staffObject = null;

                        do
                        {
                            Console.WriteLine("Enter the Staff ID");
                            flag1 = 0;
                            try
                            {
                                sid = int.Parse(Console.ReadLine());
                                if ((staffList.Exists(s => s.Sid == sid) && staffList.Count > 0))
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

                        if (staffChoice == (int)StaffType.Teaching)
                        {
                            staffObject = new Teaching();
                            staffObject.AddStaff(sid);
                        }

                        else if (staffChoice == (int)StaffType.Administration)
                        {
                            staffObject = new Administration();
                            staffObject.AddStaff(sid);
                        }

                        else if (staffChoice == (int)StaffType.Supporting)
                        {
                            staffObject = new Supporting();
                            staffObject.AddStaff(sid);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                            break;
                        }

                        staffList.Add(staffObject);
                        break;
                    case 2:
                        foreach (Staff t in staffList)
                        {
                            t.DisplayStaff();
                        };
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id to be searched");
                        int iD = int.Parse(Console.ReadLine());
                        var item = staffList.FirstOrDefault(o => o.Sid == iD);

                        if (item != null)
                        {
                            item.DisplayStaff();
                        }
                        else
                        {
                            Console.WriteLine("Staff with id:" + iD + " does not exist");

                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Staff Id which you want to delete:");
                        int staffID = int.Parse(Console.ReadLine());
                        bool result = false;

                        foreach (Staff t in staffList)
                        {
                            if (t.Sid == staffID)
                            {
                                result = staffList.Remove(t);
                                break;
                            }
                        };

                        if (result == true)
                            Console.WriteLine("Employee deleted");
                        else
                            Console.WriteLine("Employee with ID:" + staffID + " not found");
                        break;
                    case 5:
                        return;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }
    }
}
