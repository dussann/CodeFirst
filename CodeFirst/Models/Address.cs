using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Address
    {
        [ForeignKey("Student")]
        public int AddressID { get; set; }
        public string Address1 { get; set; }
        public int ZipCode { get; set; }

        public virtual Students Student { get; set; }

    }
}