using ContactsWeb.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsWeb.Services
{
    public interface IContactManager
    {
        Task<bool> ExistsAsync(Contact contact);

        Task<List<Contact>> GetAllContactsAsync();

        Contact FindById(Guid id);

        ValueTask<EntityEntry<Contact>> AddAsync(Contact contact);

        void Update(Contact contact);

        void Delete(Contact contact);

        Task<int> SaveChangesAsync();
    }
}
