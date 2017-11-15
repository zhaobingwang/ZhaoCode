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
        MongoServer _server = null;
        MongoDatabase _datebase = null;
        MongoCollection _contacts = null;
        public ContactRepository(string connection)
        {
            if (!string.IsNullOrEmpty(connection))
            {
                connection = "mongodb://localhost:27017";
            }
            _server = new MongoClient(connection).GetServer();
            _datebase = _server.GetDatabase("Contacts");
            _contacts = _datebase.GetCollection("contacts");

            // Reset database and add some default entries
            _contacts.RemoveAll();
            for (int index = 1; index < 5; index++)
            {
                Contact contact1 = new Contact
                {
                    Email = string.Format("test{0}@example.com", index),
                    Name = string.Format("test{0}", index),
                    Phone = string.Format("{0}{0}{0} {0}{0}{0} {0}{0}{0}{0}", index)
                };
                AddContact(contact1);
            }
        }
        public Contact AddContact(Contact contact)
        {
            contact.Id = ObjectId.GenerateNewId().ToString();
            contact.LastModified = DateTime.UtcNow;
            _contacts.Insert(contact);
            return contact;
        }

        public Contact GetContact(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            return _contacts.FindAs<Contact>(query).FirstOrDefault();
        }

        public IEnumerable GeyAllContacts()
        {
            return _contacts.FindAllAs<Contact>();
        }

        public bool RemoveContact(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            WriteConcernResult result = _contacts.Remove(query);
            return result.DocumentsAffected == 1;
        }

        public bool UpdateContact(string id, Contact contact)
        {
            IMongoQuery query = Query.EQ("_id", id);
            contact.LastModified = DateTime.UtcNow;
            IMongoUpdate update = Update
                .Set("Email", contact.Email)
                .Set("LastModified", DateTime.UtcNow)
                .Set("Name", contact.Name)
                .Set("Phone", contact.Phone);
            WriteConcernResult result = _contacts.Update(query, update);
            return result.UpdatedExisting;
        }
    }
}