using ECommerce.Core.Entities.Base;

namespace ECommerce.Data.Repositories.Abstractions
{
    public interface IRepositery<T> where T : BaseEntity, new()
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<bool> IsExistsAsync(int Id);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void SoftDelete(T entity);
        Task<int> Save();
    }
}
