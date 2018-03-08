using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        public List<Department> Get()
        {
            List<Department> list = new List<Department>();

            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = Company;" +
                    "Integrated Security=SSPI;";
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


            return list;
        }

        // GET: api/Department/5
        public List<Department> Get(int id)
        {
            List<Department> dep = new List<Department>();

            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = Company;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_GetDepartment", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DNumber", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dep.Add(new Department((string)reader["DName"], (int)reader["DNumber"], (int)reader["employeeCount"])); //(int)reader[0], Value = (string)reader[1] };
                    }
                }
            }

            return dep;
        }

        // POST: api/Department/
        public void Post(Department dep)
        {
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = Company;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_CreateDepartment", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dep.DName;
                command.Parameters.Add("@MgrSSN", SqlDbType.Decimal).Value = dep.MgrSSN;
                command.ExecuteNonQuery();
            }
        }

        // PUT: api/Department/
        public void Put(Department dep)
        {
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = Company;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_UpdateDepartmentName", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DNumber", SqlDbType.Int).Value = dep.DNumber;
                command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dep.DName;
                command.ExecuteNonQuery();
            }
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = Company;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();

                // Create the command
                SqlCommand command = new SqlCommand("usp_DeleteDepartment", conn) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@DNumber", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }
    }
}
