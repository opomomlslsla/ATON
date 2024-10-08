using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByAsync(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(Guid id);
        Task<ICollection<T>> GetCollectionByAsync(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}