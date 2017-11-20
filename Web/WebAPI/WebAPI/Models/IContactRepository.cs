using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IContactRepository
    {
        IList<Contact> GetAllContacts();
        Contact GetContact(string id);
        Contact AddContact(Contact contact);
        bool RemoveContact(string id);
        bool UpdateContact(string id,Contact contact);
    }
}
