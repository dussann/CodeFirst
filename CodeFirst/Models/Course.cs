using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string NameOFCourse { get; set; }
        public int Duration { get; set; }
        public int Size { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}