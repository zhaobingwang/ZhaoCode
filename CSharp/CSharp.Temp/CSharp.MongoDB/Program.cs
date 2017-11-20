using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.MongoDB
{
    class Program
    {
        static IMongoDatabase _datebase = null;
        static IMongoCollection<Contact> _contacts = null;
        static MongoClient _client = null;
        static void Main(string[] args)
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _datebase = _client.GetDatabase("demo");
            _contacts = _datebase.GetCollection<Contact>("contacts");
            //collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

            

          

            //for (int index = 1; index < 5; index++)
            //{
            //    Contact contact1 = new Contact
            //    {
            //        Email = string.Format("test{0}@example.com", index),
            //        Name = string.Format("test{0}", index),
            //        Phone = string.Format("{0}{0}{0} {0}{0}{0} {0}{0}{0}{0}", index)
            //    };
            //    AddContact(contact1);
            //}
            var list = _contacts.Find(c=>true).ToList();
            foreach (var document in list)
            {
                Console.WriteLine(document.Name);
            }
            
        }
        public static Contact AddContact(Contact contact)
        {
            contact.Id = ObjectId.GenerateNewId().ToString();
            contact.LastModified = DateTime.UtcNow;
            _contacts.InsertOne(contact);
            return contact;
        }
    }
    public class Contact
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime LastModified { get; set; }
    }
}
