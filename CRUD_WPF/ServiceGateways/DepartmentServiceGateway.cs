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
        public List<Department> GetAllDepartments()
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("/api/department").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Department>>().Result;
                }
                else
                {
                    throw new Exception("Cannot reach database.");
                }
            }
        }

        public List<Department> GetDepartment(int departmentNumber)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("/api/department/"+departmentNumber).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Department>>().Result;
                }
                else
                {
                    throw new Exception("Cannot reach database or Department not found.");
                }
            }
        }

        public bool UpdateDepartment(Department updateDepartment)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);

                var response = client.PutAsJsonAsync("api/department", updateDepartment).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CreateDepartment(Department newDepartment)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);

                var response = client.PostAsJsonAsync("api/department", newDepartment).Result;

                if (response.IsSuccessStatusCode)
                {
                return true;
                }
                return false;
            }
        }

        public bool DeleteDepartment(int id)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);

                var response = client.DeleteAsync($"api/department/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                return true;
                }
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
