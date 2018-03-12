using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using BE;

namespace LoadBalancer.Controllers
{
    public class LoadBalanceController : ApiController
    {
        public int temp = 0;

        // GET: api/LoadBalance
        public List<Department> Get()
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
                    //return new List<Department>();
                    throw new Exception("Cannot reach database.");
                }
            }
        }

        // GET: api/LoadBalance/5
        public Department Get(int id)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                var response = client.GetAsync("/api/department/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Department>().Result;
                }
                else
                {
                    throw new Exception("Cannot reach database or Department not found.");
                }
            }
        }

        // POST: api/LoadBalance
        public HttpResponseMessage Post(Department dep)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.PostAsJsonAsync("api/department", dep).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                return response;
            }
        }

        // PUT: api/LoadBalance/5
        public HttpResponseMessage Put(Department dep)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.PutAsJsonAsync("api/department", dep).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                return response;
            }
            }

        // DELETE: api/LoadBalance/5
        public HttpResponseMessage Delete(int id)
        {
            using (var client = new HttpClient())
            {
                PrepareHeader(client);
                //A new Department with name of newDepartment should be provided at method call.
                var response = client.DeleteAsync($"api/department/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                return response;
            }
        }
        private void PrepareHeader(HttpClient client)
        {

            List<string> lst = CollectAddress();

            if (temp >= lst.Count)
            {
                temp = 0;
            }

            client.BaseAddress = new Uri(lst.ElementAt(temp));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            temp++;
        }

        private List<string> CollectAddress()
        {
            List<string> lst = new List<string>();
            lst.Add("http://localhost:58458/");
            lst.Add("http://localhost:58015/");
            return lst;
        }

    }
}
