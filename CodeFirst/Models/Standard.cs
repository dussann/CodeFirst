using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Standard
    {
        public int StandardID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Students> Student { get; set; }
    }
}