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
            //await Task.Delay(TimeSpan.FromSeconds(5));
            await Task.Run(() => {
                list = ReadDataFromSQL();
                //list = new List<Word>();
                Random rnd = new Random();
                //for (int i = 0; i < 10; i++)
                //{
                //    list.Add(new Word() { Value = rnd.Next(1, 13).ToString() });
                //}
            }
            );
            return list;
        }
        public List<Word> GetListOfIntsSync()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            List<Word> list = ReadDataFromSQL();
            //List<Word> list = new List<Word>();
            //Random rnd = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(new Word() { Value = rnd.Next(1, 13).ToString() });
            //}
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
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                //conn.ConnectionString = @"Server=[DESKTOP-TS29HM4\SERVERSEARCH];Database=[CustomSearch];Trusted_Connection=true";
                conn.ConnectionString = @"Server=(DESKTOP-TS29HM4\SERVERSEARCH);Database=CustomSearch;Trusted_Connection=Yes;";
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT * FROM Words_In_Documents WHERE ID = @0", conn);
                // Add the parameters.
                command.Parameters.Add(new SqlParameter("0", 1));

                /* Get the rows and display on the screen! 
                 * This section of the code has the basic code
                 * that will display the content from the Database Table
                 * on the screen using an SqlDataReader. */

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    while (reader.Read())
                    {
                        var word = new Word() { id = (int)reader[0], Value = (string)reader[1] };
                        list.Add(word);
                        //Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                        //reader[0], reader[1], reader[2], reader[3]));
                    }
                }
                // Create the command, to insert the data into the Table!
                // this is a simple INSERT INTO command!

                //SqlCommand insertCommand = new SqlCommand("INSERT INTO TableName (FirstColumn, SecondColumn, ThirdColumn, ForthColumn) VALUES (@0, @1, @2, @3)", conn);

                // In the command, there are some parameters denoted by @, you can 
                // change their value on a condition, in my code they're hardcoded.

                //insertCommand.Parameters.Add(new SqlParameter("0", 10));
                //insertCommand.Parameters.Add(new SqlParameter("1", "Test Column"));
                //insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                //insertCommand.Parameters.Add(new SqlParameter("3", false));

                // try block
                //try
                //{
                //    // Create the command to execute! With the wrong name of the table (Depends on your Database tables)
                //    SqlCommand errorCommand = new SqlCommand("SELECT * FROM someErrorColumn", conn);
                //    // Execute the command, here the error will pop up!
                //    // But since we're catching the code block's errors, it will be displayed inside the console.
                //    errorCommand.ExecuteNonQuery();
                //}
                //// catch block
                //catch (SqlException er)
                //{
                //    // Since there is no such column as someErrorColumn (Depends on your Database tables)
                //    // SQL Server will throw an error.
                //    Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                //}
            }
            return list;
        }
        public List<Word> ReadData()
        {
            List<Word> newList = new List<Word>();
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                newList.Add(new Word() { Value = rnd.Next(1, 13).ToString()});
            }
            return newList;
        }
    }
}
    

