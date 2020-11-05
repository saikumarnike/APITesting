using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestFulAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static RestClient _client = new RestClient();
        static void Main(string[] args)
        {
            RestRequest request = new RestRequest("https://localhost:44364/api/employees");
            IRestResponse response = _client.Execute(request);
            JArray arr = JArray.Parse(response.Content);
            Console.WriteLine(arr);
            var emp = arr.ToObject<List<Employees>>();
            Console.WriteLine(emp[0].ID);

            request = new RestRequest("https://localhost:44364/api/employees");
            request.AddParameter("id", 2);
            response = _client.Execute(request);
        }
    }
}
