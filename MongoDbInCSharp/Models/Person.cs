using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbInCSharp.Models
{
    public class Person
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string WebSite { get; set; }
    }
}
