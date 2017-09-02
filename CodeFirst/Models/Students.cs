using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Students
    {
       
        public int StudentsID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        
        public virtual Address Address { get; set; }
        public Standard Standard { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}