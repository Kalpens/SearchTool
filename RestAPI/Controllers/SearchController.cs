using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class SearchController : ApiController
    {
        // GET: api/Search
        public List<Word> Get()
        {
            List<Word> list = new List<Word>();
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = CustomSearch;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT * FROM Words", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var word = new Word() { id = (int)reader[0], Value = (string)reader[1] };
                        list.Add(word);
                    }
                }
            }

            return list;
        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
