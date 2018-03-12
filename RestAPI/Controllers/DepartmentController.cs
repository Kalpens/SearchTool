using BE;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        string connectionString = @"Data Source = DESKTOP-TS29HM4\SERVERSEARCH;" +
                                  "Initial Catalog = Company;" +
                                  "Integrated Security=SSPI;";
        private static readonly string FilePath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + @"\Log.txt";
        private static readonly ReaderWriterLock ReaderWriterLock = new ReaderWriterLock();
        // GET: api/Department
        public List<Department> Get()
        {
            //fileWriter.LogMethodStart("GetAllDepartments");
            var methodStartTime = DateTime.Now;
            List<Department> list = new List<Department>();

            // Create the connection to the resource!
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString = connectionString;
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_GetAllDepartments", conn) { CommandType = CommandType.StoredProcedure };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var department = new Department((string)reader["DName"], (int)reader["DNumber"], (int)reader["employeeCount"]); //(int)reader[0], Value = (string)reader[1] };
                        list.Add(department);
                    }
                }
            }
            //Making this method longer
            Thread.Sleep(TimeSpan.FromSeconds(3));
            LogMethod("GetAllDepartments", methodStartTime, DateTime.Now);
            return list;
        }

        // GET: api/Department/5
        public Department Get(int id)
        {
            Department dep = null;
            //fileWriter.LogMethodStart("GetDepartment");
            var methodStartTime = DateTime.Now;
            // Create the connection to the resource!
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString = connectionString;
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_GetDepartment", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DNumber", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dep = new Department((string)reader["DName"], (int)reader["DNumber"], (int)reader["employeeCount"]); //(int)reader[0], Value = (string)reader[1] };
                    }
                }
            }
            //Making this method longer
            Thread.Sleep(TimeSpan.FromSeconds(3));
            LogMethod("GetDepartment", methodStartTime, DateTime.Now);
            return dep;
        }

        // POST: api/Department/
        public void Post(Department dep)
        {
            //fileWriter.LogMethodStart("CreateDepartment");
            var methodStartTime = DateTime.Now;
            // Create the connection to the resource!
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString = connectionString;
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_CreateDepartment", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dep.DName;
                command.Parameters.Add("@MgrSSN", SqlDbType.Decimal).Value = dep.MgrSSN;
                command.ExecuteNonQuery();
            }
            //Making this method longer
            Thread.Sleep(TimeSpan.FromSeconds(3));
            LogMethod("CreateDepartment", methodStartTime, DateTime.Now);
        }

        // PUT: api/Department/
        public void Put(Department dep)
        {
            //fileWriter.LogMethodStart("UpdateDepartment");
            var methodStartTime = DateTime.Now;
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString = connectionString;
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_UpdateDepartmentName", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DNumber", SqlDbType.Int).Value = dep.DNumber;
                command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dep.DName;
                command.ExecuteNonQuery();
            }
            LogMethod("UpdateDepartment", methodStartTime, DateTime.Now);
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
            //fileWriter.LogMethodStart("DeleteDepartment");
            var methodStartTime = DateTime.Now;
            // Create the connection to the resource!
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString = connectionString;
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_DeleteDepartment", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DNumber", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
            //Making this method longer
            Thread.Sleep(TimeSpan.FromSeconds(3));
            LogMethod("DeleteDepartment", methodStartTime, DateTime.Now);
        }
        private void LogMethod(string methodType, DateTime start, DateTime end)
        {
            string textMethodStarted = "[" + start + "] " + methodType + " Method called";
            string textMethodEnded = "[" + end + "] " + methodType + " Method finished";
            string spacing = "---------------------";
            try
            {
                ReaderWriterLock.AcquireWriterLock(int.MaxValue);
                File.AppendAllLines(FilePath, new[] { textMethodStarted });
                File.AppendAllLines(FilePath, new[] { textMethodEnded });
                File.AppendAllLines(FilePath, new[] { spacing });
            }
            finally
            {
                ReaderWriterLock.ReleaseWriterLock();
            }
        }
    }
}
