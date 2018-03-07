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
            await Task.Run(() => { list = ReadDataFromSQL(); }
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
            return null;
        }

        public void AddCrawledToDb()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                conn.ConnectionString =
                    @"Data Source = DESKTOP-S63EU1H;" +
                    "Initial Catalog = CustomSearch;" +
                    "Integrated Security=SSPI;";
                //Opening connection
                conn.Open();
                Crawler crawler = new Crawler();
                string[] words = crawler.ReadSingleFile();

                foreach (var word in words)
                {
                    SqlCommand insertCommand =
                        new SqlCommand(
                            "INSERT INTO Words (Value, DocumentId) VALUES (@0, @1)",
                            conn);

                    insertCommand.Parameters.Add(new SqlParameter("0", word));
                    insertCommand.Parameters.Add(new SqlParameter("1", 11));
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
    

