using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SearchFiles
{
    class DataSearch
    {
        public async Task<List<Word>> GetListOfInts()
        {
            List<Word> list = null;
            await Task.Delay(TimeSpan.FromSeconds(5));
            await Task.Run(() => {
                list = ReadDataFromSQL();
            }
            );
            return list;
        }
        public List<Word> GetListOfIntsSync()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            List<Word> list = ReadDataFromSQL();
            return list;
        }

        public List<Word> ReadDataFromSQL()
        {
            List<Word> list = new List<Word>();
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-TS29HM4\SERVERSEARCH;" +
                    "Initial Catalog = CustomSearch;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT * FROM Words_In_Documents", conn);
                
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
    }
}
    

