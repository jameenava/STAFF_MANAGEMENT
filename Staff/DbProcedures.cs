
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace StaffLibrary
{
    public class DbProcedures : IStaff
    {
        public string connectionString;
        public DbProcedures()
        {
            //string currentDirectory = @"C:\Users\lenovo\source\repos\Staff\StaffManagement";
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile(currentDirectory + $"\\appSettings.Development.json", true, true);
            string currentDirectory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .AddJsonFile(currentDirectory + $"\\appSettings.Development.json", true, true);
            var config = builder.Build();
            this.connectionString = config["MyConn"];

        }
        public void AddStaff(Staff staffObject)
        {

            try
            {


                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spInsertTeaching", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeID", staffObject.StaffID);
                cmd.Parameters.AddWithValue("@instituteName", staffObject.Institute);
                cmd.Parameters.AddWithValue("@salary", staffObject.Salary);
                cmd.Parameters.AddWithValue("@staffType", staffObject.Designation);
                if (staffObject.Designation == StaffType.Teaching)
                    cmd.Parameters.AddWithValue("@subjectorArea", ((Teaching)staffObject).Subject);
                else if (staffObject.Designation == StaffType.Administration)
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
        public void BulkInsert(List<Staff> staffList)

        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("EmployeeID", typeof(int)));
            dt.Columns.Add(new DataColumn("InstituteName", typeof(string)));
            dt.Columns.Add(new DataColumn("Salary", typeof(int)));
            dt.Columns.Add(new DataColumn("StaffType", typeof(int)));
            dt.Columns.Add(new DataColumn("SubjectorArea", typeof(string)));

            foreach (Staff staffObject in staffList)
            {
                DataRow dr = dt.NewRow();
                dr["EmployeeID"] = staffObject.StaffID;
                dr["InstituteName"] = staffObject.Institute;
                dr["Salary"] = staffObject.Salary;
                dr["StaffType"] = staffObject.Designation;
                if (staffObject.Designation == StaffType.Teaching)
                    dr["SubjectorArea"] = ((Teaching)staffObject).Subject;
                else if (staffObject.Designation == StaffType.Administration)
                    dr["SubjectorArea"] = ((Administration)staffObject).AdminArea;
                else
                    dr["SubjectorArea"] = ((Supporting)staffObject).SupportArea;

                dt.Rows.Add(dr);
            }
            using SqlConnection connection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("proc_BulkInsert", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@UserDefineTable", dt);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }

        public bool DeleteStaff(int staffID)
        {
            bool flag;

            try
            {
                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spDeleteStaff", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffID", staffID);
                cmd.ExecuteNonQuery(); 
                flag = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
                flag = false;
            }
            return flag;
        }
        public Staff GetStaffByID(int iD)
        {
            Staff staffObj = null;
            try
            {
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
                        staffObj = new Teaching((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (StaffType)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["Subject"]);
                    else if (staffType == 2)
                        staffObj = new Administration((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (StaffType)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["AdministrationArea"]);

                    else
                        staffObj = new Supporting((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (StaffType)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["SupportingArea"]);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);

            }
            return staffObj;
        }

        public void UpdateStaff(Staff staffObject)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateStaff", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffID", staffObject.StaffID);
                if (staffObject.Designation == StaffType.Teaching)
                {
                    cmd.Parameters.AddWithValue("@subjectOrArea", ((Teaching)staffObject).Subject);
                }
                else if (staffObject.Designation == StaffType.Administration)
                {
                    cmd.Parameters.AddWithValue("@subjectOrArea", ((Administration)staffObject).AdminArea);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@subjectOrArea", ((Supporting)staffObject).SupportArea);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);

            }
        }

        public List<Staff> GetAllStaff()
        {
            Staff staffObj = null;
            List<Staff> staffList = new List<Staff>();
            try
            {
                using SqlConnection connection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("spViewAllStaff", connection);

                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    int staffType = (int)(sdr["StaffType"]);
                    if (staffType == 1)
                        staffObj = new Teaching((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (StaffType)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["Subject"]);
                    else if (staffType == 2)
                        staffObj = new Administration((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (StaffType)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["AdministrationArea"]);

                    else
                        staffObj = new Supporting((int)sdr["StaffID"], (int)sdr["EmployeeID"], (int)sdr["Salary"], (StaffType)sdr["StaffType"], (string)sdr["InstituteName"], (string)sdr["SupportingArea"]);
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
