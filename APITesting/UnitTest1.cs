using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestFulAPI.Models;
//using NUnit.Framework;
using RestSharp;

namespace APITesting
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client = new RestClient("https://localhost:44364/api/");
        //[TestMethod]
        //public void TestingContentType()
        //{
        //    // arrange
        //    RestClient client = new RestClient("http://api.zippopotam.us");
        //    RestRequest request = new RestRequest("nl/3825", Method.GET);

        //    // act
        //    IRestResponse response = client.Execute(request);

        //    // assert
        //    Assert.AreEqual(response.ContentType, ("application/json"));
        //    //Assert.That(response.ContentType, Is.EqualTo("application/json"));
        //}

        //[TestMethod]
        //public void TestingGet()
        //{
        //    // arrange
        //    RestClient client = new RestClient("http://api.zippopotam.us");
        //    RestRequest request = new RestRequest("nl/3825", Method.GET);

        //    // act
        //    IRestResponse response = client.Execute(request);

        //    // assert
        //    Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NotFound);
        //    //Assert.That(response.ContentType, Is.EqualTo("application/json"));
        //}

        [TestMethod]
        public void GetEmployees()
        {
            // arrange
            
            RestRequest request = new RestRequest("Employees", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            var employees = JsonConvert.DeserializeObject<List<Employees>>(response.Content);
            Assert.AreEqual(2, employees.Count);
            //Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }



        [TestMethod]
        public void PostEmployees()
        {
            RestRequest request = new RestRequest("Employees") { Method = Method.POST };
            Employees emp = new Employees()
            {
                EmployeeName="Jayshu",
            };
            request.AddJsonBody(emp);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            RestRequest request = new RestRequest("Employees") { Method = Method.DELETE };
            request.AddParameter("id", 2);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }


    }
}
