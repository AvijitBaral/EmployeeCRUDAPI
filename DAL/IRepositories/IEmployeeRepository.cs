using EmployeeCRUDAPI.DAL.DTOs;
using EmployeeCRUDAPI.DAL.Entities;

namespace EmployeeCRUDAPI.DAL.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<IEnumerable<EmployeeDetailsDTO>> EmpDetailsByEmpNo(int employeeNo);
    }
}
