using ContactsWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsWeb.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
