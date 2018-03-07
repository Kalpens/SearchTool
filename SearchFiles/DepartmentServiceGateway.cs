using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace SearchFiles
{
    public class DepartmentServiceGateway
    {

        public List<Word> GetAllDepartments()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58458/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/search").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Word>>().Result;
                }

                return new List<Word>();
            }
        }
        
    }
}
