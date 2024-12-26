using ECommerce.Core.Entities.Base;
using ECommerce.Data.DAL;
using ECommerce.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Repositories.Implementations
{
    public class Repository<T> : IRepositery<T> where T : BaseEntity,new() 
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        DbSet<T> table => _context.Set<T>();
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await table.Where(x => !x.IsDeleted).ToListAsync();
        }


        public async Task<T> CreateAsync(T entity)
        {
            await table.AddAsync(entity);
            return entity;
        }


        public async Task<T> GetByIdAsync(int Id)
        {
            var entity = await table.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int Id)
        {
            return await table.AnyAsync(x => x.Id == Id && !x.IsDeleted);
        }

    }
}
