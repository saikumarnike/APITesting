using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestFulAPI.Models
{
    public class Employees
    {
        [Key]
        public int ID { get; set; }
        public string EmployeeName { get; set; }
    }
}