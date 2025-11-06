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
    }
}
