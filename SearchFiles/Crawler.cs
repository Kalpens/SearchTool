using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFiles
{
    public class Crawler
    {
        public string[] ReadSingleFile()
        {
            string[] words = null;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', '\r', (char)0 };
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\Users\abenc\Documents\GitHub\SearchTool\sample.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    words = sr.ReadToEnd().Split(delimiterChars);
                    words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                }
            }
            catch (Exception e)
            {
            }

            return words;
        }
    }
}
