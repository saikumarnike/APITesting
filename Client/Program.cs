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
            RestRequest request = new RestRequest("https://localhost:44364/api/employees") {Method=Method.GET };
            IRestResponse response = _client.Execute(request);
            JArray arr = JArray.Parse(response.Content);
            Console.WriteLine("Employees in organisation:");
            foreach(var a in arr)
            {
                Console.WriteLine("ID:"+a["ID"]+"name:"+a["EmployeeName"]);
            }

            request = new RestRequest("https://localhost:44364/api/employees") { Method=Method.GET};
            request.AddParameter("id", 2);
            response = _client.Execute(request);
            arr = JArray.Parse(response.Content);
            Console.WriteLine("Employee with ID:2");
            Console.WriteLine("Name: "+arr[0]["EmployeeName"]);

            request = new RestRequest("https://localhost:44364/api/employees") { Method = Method.DELETE };
            request.AddParameter("id", 2);
            response = _client.Execute(request);
            request = new RestRequest("https://localhost:44364/api/employees") { Method = Method.GET };
            response = _client.Execute(request);
            arr = JArray.Parse(response.Content);
            Console.WriteLine("Employees in organisation:");
            foreach (var a in arr)
            {
                Console.WriteLine("ID:" + a["ID"] + "name:" + a["EmployeeName"]);
            }


        }
    }
}
