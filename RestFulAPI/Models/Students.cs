using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestFulAPI.Models
{
    public class Students
    {
        [Key]
        public int ID { get; set; }

        public string StudentName { get; set; }
    }
}