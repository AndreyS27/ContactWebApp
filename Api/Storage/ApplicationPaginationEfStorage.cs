using Api.DataContext;
using Api.Model;

namespace Api.Storage
{
    public class ApplicationPaginationEfStorage : ApplicationEfStorage, IPaginationStorage
    {
        public ApplicationPaginationEfStorage(ApplicationDbContext context)
            : base(context)
        {   
        }

        public Contact GetContactById(int id)
        {
            return base._context.Contacts.Find(id);
        }

        public (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize)
        {
            int total = base._context.Contacts.Count();
            List<Contact> contacts = base._context.Contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return (contacts, total);
        }
    }
}
