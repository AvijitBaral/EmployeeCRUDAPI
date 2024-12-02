using EmployeeCRUDAPI.DAL.DBContext;
using EmployeeCRUDAPI.DAL.Entities;
using EmployeeCRUDAPI.DAL.IRepositories;

namespace EmployeeCRUDAPI.DAL.Repositories
{
    public class DepartmentRepository : Repository<Department> , IDepartmentRepository
    {
        EmployeeContext _dbcontext;
        public DepartmentRepository(EmployeeContext context) : base(context)
        {
            _dbcontext = context;
        }

    }
}
