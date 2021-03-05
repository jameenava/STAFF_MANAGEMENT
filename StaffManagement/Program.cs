
using System;
using System.Collections.Generic;
using System.Linq;
using StaffLibrary;
namespace StaffManagement
{
    class Program
    {
        const string instituteName = " ABC SCHOOL";
        static void display(Teaching teacher)
        {
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine("Teacher:" + "INSTITUTE:" + teacher.Institute + " |" + "ID:" + teacher.Sid + "| " + "SALARY:" + teacher.Salary + " |" + "SUBJECT:" + teacher.Subject);
            Console.WriteLine("____________________________________________________________________");
        }
        static void Main(string[] args)
        {
            int yourChoice;

            List<Teaching> teacherList = new List<Teaching>();
            //initializing object
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Add teacher record");
                Console.WriteLine("2.View all teachers records");
                Console.WriteLine("3.Search a teacher record");
                Console.WriteLine("4.Exit");
                Console.Write("Enter your choice:");
                yourChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the details of teacher");
                switch (yourChoice)
                {
                    case 1:
                        Console.WriteLine("Enter teacher ID");
                        int sid;
                        try
                        {
                            sid = int.Parse(Console.ReadLine());

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Entered ID is invalid");
                            goto case 1;

                        }
                        Nullable<int> salary = null;
                        int flag;
                        do
                        {
                            flag = 0;
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
                                    flag = 1;
                                }
                            }
                        } while (flag == 1);

                        Console.WriteLine("Enter subject");
                        string subject;
                        subject = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(subject))
                        {
                            subject = null;
                        }
                        teacherList.Add(item: new Teaching() { Institute = instituteName, Sid = sid, Salary = salary, Subject = subject });
                        break;

                    case 2:
                        foreach (Teaching t in teacherList)
                        {
                            display(t);
                        };
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id to be searched");
                        int iD = int.Parse(Console.ReadLine());
                        var item = teacherList.FirstOrDefault(o => o.Sid == iD);
                        if (item != null)
                        {
                            display(item);
                        }
                        else
                        {
                            Console.WriteLine("Staff with id:" + iD+ " does not exist");

                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }
    }
}
