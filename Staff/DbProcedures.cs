
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace StaffLibrary
{
    public class DbProcedures : IStaff
    {
        public string connectionString;
        // public List<Staff> staffList = new List<Staff>();
        //[XmlElement("Staff")]
        //public List<Staff> StaffList
        //{
        //    get { return staffList; }
        //    set { staffList = value; }
        //}

        public void DbProceduress()
        {

            string currentDirectory = @"C:\Users\lenovo\source\repos\Staff\StaffManagement";
            var builder = new ConfigurationBuilder()
                .AddJsonFile(currentDirectory + $"\\appSettings.Development.json", true, true);
            var config = builder.Build();
            this.connectionString = config["MyConn"];
            Console.WriteLine(this.connectionString);

        }
        public void AddStaff(Staff staffObject)
        {

            try
            {

                DbProceduress();


                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spInsertTeaching", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeID", staffObject.StaffID);
                cmd.Parameters.AddWithValue("@instituteName", staffObject.Institute);
                cmd.Parameters.AddWithValue("@salary", staffObject.Salary);
                cmd.Parameters.AddWithValue("@staffType", staffObject.Designation);
                if (staffObject.Designation == 1)
                    cmd.Parameters.AddWithValue("@subjectorArea", ((Teaching)staffObject).Subject);
                else if (staffObject.Designation == 2)
                    cmd.Parameters.AddWithValue("@subjectorArea", ((Administration)staffObject).AdminArea);
                else
                    cmd.Parameters.AddWithValue("@subjectorArea", ((Supporting)staffObject).SupportArea);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }

        public bool DeleteStaff(int staffID)
        {
            bool flag;

            try
            {
                DbProceduress();


                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spDeleteStaff", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffID", staffID);

                int f = cmd.ExecuteNonQuery();
                Console.WriteLine(f);
                flag = true;


            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
                flag = false;
            }
            return flag;
        }
        public Staff SearchStaff(int iD)
        {
            Staff staffObj = null;
            try
            {
                DbProceduress();
                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spSearchStaff", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffID", iD);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    int staffType = (int)(sdr["StaffType"]);
                    if (staffType == 1)
                        staffObj = new Teaching((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (int)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["Subject"]);
                    else if (staffType == 2)
                        staffObj = new Administration((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (int)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["AdministrationArea"]);

                    else
                        staffObj = new Supporting((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (int)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["SupportingArea"]);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);

            }
            return staffObj;
        }

        public void UpdateStaff(int staffID, string subjectOrArea)
        {
            try
            {
                DbProceduress();
                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateStaff", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffID", staffID);
                cmd.Parameters.AddWithValue("@subjectOrArea", subjectOrArea);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);

            }
        }

        public List<Staff> ViewAllStaff()
        {
            Staff staffObj = null;
            List<Staff> staffList = new List<Staff>();
            try
            {
                DbProceduress();
                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spViewAllStaff", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    int staffType = (int)(sdr["StaffType"]);
                    if (staffType == 1)
                        staffObj = new Teaching((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (int)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["Subject"]);
                    else if (staffType == 2)
                        staffObj = new Administration((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (int)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["AdministrationArea"]);

                    else
                        staffObj = new Supporting((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (int)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["SupportingArea"]);
                    staffList.Add(staffObj);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);

            }

            return staffList;
        }
    }
}
