using ContactsWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsWeb.Data
{
    public class ContactRepository : IRepository<Contact>
    {
        private ApplicationContext _context { get; }

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Contact FindById(Guid id)
        {
            return _context.Contacts.FirstOrDefault(contact => contact.Id == id);
        }

        public Task<List<Contact>> GetAllAsync()
        {
            return _context.Contacts.ToListAsync();
        }

        public ValueTask<EntityEntry<Contact>> Add(Contact contact)
        {
            return _context.Contacts.AddAsync(contact);
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
        }

        public void Delete(Contact contact)
        {
            _context.Remove(contact);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
