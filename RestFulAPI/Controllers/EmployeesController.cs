using NLog;
using RestFulAPI.Context;
using RestFulAPI.Models;
using RestFulAPI.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFulAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        
        MockModel context = new MockModel();

        // GET: api/Employees
        public IEnumerable<Employees> Get()
        {
            MyLogger.GetInstance().Info("called Employees");
            return context.Employee;
        }

        // GET: api/Employees/5
        public IEnumerable<Employees> Get(int id)
        {
            MyLogger.GetInstance().Info("called Employee by id");
            return context.Employee.Where(emp=>emp.ID==id);
        }

        // POST: api/Employees
        public HttpResponseMessage Post(Employees model)
        {
            context.Employee.Add(model);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }

        // PUT: api/Employees/5
        public void Put(Employees model)
        {
            //context.Employee.
        }

        // DELETE: api/Employees/5
        public HttpResponseMessage Delete(int id)
        {
            context.Employee.Remove(context.Employee.Single(emp=>emp.ID==id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
