using EmployeeCRUDAPI.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeCRUDAPI.DAL.IRepositories
{
    public interface IRepository <Entity> where Entity : class
    {
       public Task<IEnumerable<Entity>> GetAll();
       public Task<bool> AddAsync(Entity input);
       public Task<bool> SaveChangesAsync();
       public Task<bool> UpdateAsync(Entity input);
       public Task<Entity?> GetFirstOrDefaultAsync(Expression<Func<Entity, bool>> condition);
       public Task<bool> DeleteAsync(Entity input);
    }
}
