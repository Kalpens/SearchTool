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
<<<<<<< HEAD:SearchFiles/ServiceGateways/DepartmentServiceGateway.cs
        
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

=======
>>>>>>> master:CRUD_WPF/ServiceGateways/DepartmentServiceGateway.cs
        public List<Department> GetAllDepartments()
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("api/LoadBalance").Result;
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
<<<<<<< HEAD:SearchFiles/ServiceGateways/DepartmentServiceGateway.cs
        //TODO
        //Return type needs to be changed to department
=======

>>>>>>> master:CRUD_WPF/ServiceGateways/DepartmentServiceGateway.cs
        public List<Department> GetDepartment(int departmentNumber)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("api/LoadBalance/" + departmentNumber).Result;
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
<<<<<<< HEAD:SearchFiles/ServiceGateways/DepartmentServiceGateway.cs
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.PutAsJsonAsync("api/LoadBalance", updateDepartment).Result;
=======

                var response = client.PutAsJsonAsync("api/department", updateDepartment).Result;
>>>>>>> master:CRUD_WPF/ServiceGateways/DepartmentServiceGateway.cs

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
<<<<<<< HEAD:SearchFiles/ServiceGateways/DepartmentServiceGateway.cs
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.PostAsJsonAsync("api/LoadBalance", newDepartment).Result;
=======

                var response = client.PostAsJsonAsync("api/department", newDepartment).Result;
>>>>>>> master:CRUD_WPF/ServiceGateways/DepartmentServiceGateway.cs

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
<<<<<<< HEAD:SearchFiles/ServiceGateways/DepartmentServiceGateway.cs
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.DeleteAsync($"api/LoadBalance/{id}").Result;
=======

                var response = client.DeleteAsync($"api/department/{id}").Result;
>>>>>>> master:CRUD_WPF/ServiceGateways/DepartmentServiceGateway.cs

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
