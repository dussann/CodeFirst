using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public byte[] ImageFile { get; set; }
        public string Description { get; set; }
    }
}