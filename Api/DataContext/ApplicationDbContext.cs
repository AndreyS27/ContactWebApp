using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}
