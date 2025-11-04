using Api.DataContext;
using Api.Model;
using Api.ModelDto;

namespace Api.Storage
{
    public class ApplicationEfStorage : IStorage
    {
        private readonly ApplicationDbContext _context;

        public ApplicationEfStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contact Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public List<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }

        public bool Remove(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateContact(ContactDto contactDto, int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }
            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            _context.SaveChanges();
            return true;
        }
    }
}
