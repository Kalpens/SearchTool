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

        public List<Word> GetAllWords()
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("/api/search").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Word>>().Result;
                }

                return new List<Word>();
            }
        }

        public void GetAllDepartments()
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("/api/department").Result;
                if (response.IsSuccessStatusCode)
                {
                    //return response.Content.ReadAsAsync<List<Department>>().Result;
                }

                //return new List<Department>();
                throw new NotImplementedException();
            }
        }
        //TODO
        //Return type needs to be changed to department
        public void GetDepartment(int departmentNumber)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("/api/department/"+departmentNumber).Result;
                if (response.IsSuccessStatusCode)
                {
                    //return response.Content.ReadAsAsync<Department>().Result;
                }

                //return new Department();
                throw new NotImplementedException();
            }
        }

        public bool UpdateDepartment()
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                //A new Department with name of newDepartment should be provided at method call.
                //var response = client.PutAsJsonAsync("api/department", newDepartment).Result;

                //if (response.EnsureSuccessStatusCode())
                //{
                    return true;
                //}
                return false;
            }
        }

        public bool CreateDepartment()
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                //A new Department with name of newDepartment should be provided at method call.
                //var response = client.PostAsJsonAsync("api/department", newDepartment).Result;

                //if (response.EnsureSuccessStatusCode())
                //{
                return true;
                //}
                return false;
            }
        }

        public bool DeleteDepartment(int id)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.DeleteAsync($"api/department/{id}").Result;

                //if (response.EnsureSuccessStatusCode())
                //{
                return true;
                //}
                return false;
            }
        }

        private void PrepareHeader(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:58458/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
