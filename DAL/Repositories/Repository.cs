using EmployeeCRUDAPI.DAL.DBContext;
using EmployeeCRUDAPI.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeCRUDAPI.DAL.Repositories
{
    public class Repository <Entity> : IRepository <Entity> where Entity : class
    {
        EmployeeContext _dbContext;
        public Repository(EmployeeContext context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<Entity>> GetAll()

        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }
        public async Task<bool> AddAsync(Entity input)
        {
            await _dbContext.Set<Entity>().AddAsync(input);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(Entity input)
        {
            _dbContext.Entry(input).State = EntityState.Modified;

            return true;
        }
        public async Task<Entity?> GetFirstOrDefaultAsync(Expression<Func<Entity, bool>> condition)
        {
            return await _dbContext.Set<Entity>().FirstOrDefaultAsync(condition);
        }
        public async Task<bool> DeleteAsync(Entity input)
        {
            _dbContext.Set<Entity>().Remove(input);
            return true;
        }

    }
}
