using Api.DataContext;
using Api.Model;
using Api.ModelDto;

namespace Api.Storage
{
    public class ApplicationEfStorage : IStorage
    {
        private readonly ApplicationDbContext context;

        public ApplicationEfStorage(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Contact Add(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return contact;
        }

        public List<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }

        public bool Remove(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return true;
        }

        public bool UpdateContact(ContactDto contactDto, int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }
            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            context.SaveChanges();
            return true;
        }
    }
}
