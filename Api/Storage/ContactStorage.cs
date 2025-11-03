using Api.Model;
using Api.ModelDto;

namespace Api.Storage
{
    public class ContactStorage
    {
        private List<Contact> Contacts { get; set; }
        public ContactStorage()
        {
            this.Contacts = new List<Contact>();

            for (int i = 0; i <= 5; i++)
            {
                this.Contacts.Add(new Contact()
                {
                    Id = i,
                    Name = $"Полное имя {i}",
                    Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{i}@example.com"
                });
            }
        }
        

        public List<Contact> GetContacts()
        {
            return Contacts;
        }

        public bool Add(Contact contact)
        {
            foreach (var item in Contacts)
            {
                if (item.Id == contact.Id)
                {
                    return false;
                }
            }
            Contacts.Add(contact);
            return true;
        }

        public bool Remove(int id) 
        {
            Contact contact;
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].Id == id)
                {
                    contact = Contacts[i];
                    Contacts.Remove(contact);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateContact(ContactDto contactDto, int id) 
        {
            Contact contact;
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].Id == id)
                {
                    contact = Contacts[i];
                    if (!String.IsNullOrEmpty(contactDto.Email))
                    {
                        contactDto.Email = contactDto.Email;
                    }
                    if (!String.IsNullOrEmpty(contactDto.Name))
                    {
                        contactDto.Name = contactDto.Name;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
