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
        public HttpResponseMessage Get()
        {
            try
            {
                MyLogger.GetInstance().Info("calling GET api");
                return Request.CreateResponse(HttpStatusCode.OK, context.Employee);
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("error in retrieving all employees: "+ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        // GET: api/Employees/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                MyLogger.GetInstance().Info("calling employee by id API");
                var employee = context.Employee.Where(emp => emp.ID == id);
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("error in retrieving employee by ID: " + ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }

        // POST: api/Employees
        public HttpResponseMessage Post(Employees model)
        {
            try
            {
                context.Employee.Add(model);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, model);
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("error in adding employee data: " + ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }

        // PUT: api/Employees/5
        public void Put(Employees model)
        {
            //context.Employee.
        }

        // DELETE: api/Employees/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                context.Employee.Remove(context.Employee.Single(emp => emp.ID == id));
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("Error in deleting an employee: " + ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }
    }
}
