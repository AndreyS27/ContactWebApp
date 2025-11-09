using Api.DataContext;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Storage
{
    public class ApplicationPaginationEfStorage : ApplicationEfStorage, IPaginationStorage
    {
        public ApplicationPaginationEfStorage(ApplicationDbContext context)
            : base(context)
        {   
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await base._context.Contacts.FindAsync(id);
        }

        public async Task<(List<Contact>, int TotalCount)> GetContactsAsync(int pageNumber, int pageSize)
        {
            int total = base._context.Contacts.Count();
            List<Contact> contacts = await base._context.Contacts
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (contacts, total);
        }
    }
}
