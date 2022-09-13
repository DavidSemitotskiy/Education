using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactsWeb.Data
{
    public interface IRepository<T> where T : class
    {
        T FindById(Guid id);

        Task<List<T>> GetAllAsync();

        ValueTask<EntityEntry<T>> Add(T item);

        void Update(T item);

        void Delete(T item);

        Task<int> SaveChangesAsync();
    }
}
