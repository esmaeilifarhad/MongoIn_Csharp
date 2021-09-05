using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCSharp_CRUD.Models
{
    public class DataManager
    {
       private MongoClient client;
        private MongoServer server;
        private MongoDatabase db;
       private MongoCollection<Person> people;
        public DataManager()
        {
            client = new MongoClient("mongodb://localhost");
            server = client.GetServer();
            db = server.GetDatabase("firstDatabase");
            people = db.GetCollection<Person>("people");
        }
        public IEnumerable<Person> GetAllPerson() {
            return  people.FindAll().ToList();
        }
        public Person GetPersonById(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            var query = Query<Person>.EQ(p => p._id, _id);
            return people.FindOne(query);
        }
        public void InsertPerson(Person person)
        {
            people.Insert(person);
        }
        public void Update(Person person)
        {
            var query = Query<Person>.EQ(p => p._id, person._id);
            var update = Update<Person>.Set(p => p.Name, person.Name).
                Set(p => p.Family, person.Family).
                Set(p => p.WebSite, person.WebSite);

            people.Update(query, update); 
        }
        public void DeletePerson(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            var query = Query<Person>.EQ(p => p._id, _id);
             people.Remove(query);
        }
    }
}
