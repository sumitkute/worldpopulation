using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace world.data
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AadhaarNo { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public DateTime ?DOB { get; set; }
    }
}