using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCSharp_CRUD.Models
{
    public class Person
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string WebSite { get; set; }
    }
}
