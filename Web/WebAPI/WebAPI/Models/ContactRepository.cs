using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ContactRepository : IContactRepository
    {
        IMongoDatabase _datebase = null;
        IMongoCollection<Contact> _contacts = null;
        MongoClient _client = null;
        public ContactRepository(string connection)
        {
            if (string.IsNullOrEmpty(connection))
            {
                connection = "mongodb://localhost:27017";
            }
            _client = new MongoClient(connection);
            _datebase = _client.GetDatabase("foo");
            _contacts = _datebase.GetCollection<Contact>("contacts");

            // Reset database and add some default entries
            //_contacts.RemoveAll();

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
        }
        public Contact AddContact(Contact contact)
        {
            contact.Id = ObjectId.GenerateNewId().ToString();
            contact.LastModified = DateTime.UtcNow;
            _contacts.InsertOne(contact);
            return contact;
        }

        public Contact GetContact(string id)
        {
            return (Contact)_contacts.Find<Contact>(c => c.Id == id);
        }

        public IList<Contact> GetAllContacts()
        {
            return _contacts.Find<Contact>(c => true).ToList();
        }

        public bool RemoveContact(string id)
        {
            Contact result = _contacts.FindOneAndDelete(c => c.Id == id);
            return true;
        }

        public bool UpdateContact(string id, Contact contact)
        {
            //IMongoQuery query = Query.EQ("_id", id);
            //contact.LastModified = DateTime.UtcNow;
            //IMongoUpdate update = Update
            //    .Set("Email", contact.Email)
            //    .Set("LastModified", DateTime.UtcNow)
            //    .Set("Name", contact.Name)
            //    .Set("Phone", contact.Phone);
            //WriteConcernResult result = _contacts.UpdateOne(query, update);

            UpdateDefinition<Contact> updateDefinition = new ObjectUpdateDefinition<Contact>(contact);

            UpdateResult updateResult = _contacts.UpdateOne<Contact>(c => c.Id == id, updateDefinition);
            return updateResult.IsModifiedCountAvailable;
        }
    }
}