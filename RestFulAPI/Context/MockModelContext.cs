using RestFulAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestFulAPI.Context
{
    public class MockModel:DbContext
    {
        public DbSet<Employees> Employee { get; set; }

        public DbSet<Students> Student { get; set; }
    }
}