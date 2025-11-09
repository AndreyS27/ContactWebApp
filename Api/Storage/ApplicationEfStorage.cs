using Api.DataContext;
using Api.Model;
using Api.ModelDto;
using Microsoft.EntityFrameworkCore;

namespace Api.Storage
{
    public class ApplicationEfStorage : IStorage
    {
        protected readonly ApplicationDbContext _context;

        public ApplicationEfStorage(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateContactAsync(ContactDto contactDto, int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }
            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
