using ContactsWeb.Data;
using ContactsWeb.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsWeb.Services
{
    public class ContactManager : IContactManager
    {
        private IRepository<Contact> _contactRepository { get; }

        public ContactManager(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> ExistsAsync(Contact contact)
        {
            return (await _contactRepository.GetAllAsync()).Any(c => c.Name == contact.Name && c.Number == contact.Number);
        }

        public Task<List<Contact>> GetAllContactsAsync()
        {
            return _contactRepository.GetAllAsync();
        }

        public Contact FindById(Guid id)
        {
            return _contactRepository.FindById(id);
        }

        public ValueTask<EntityEntry<Contact>> AddAsync(Contact contact)
        {
            return _contactRepository.Add(contact);
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public Task<int> SaveChangesAsync()
        {
            return _contactRepository.SaveChangesAsync();
        }
    }
}
