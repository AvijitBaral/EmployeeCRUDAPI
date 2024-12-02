using EmployeeCRUDAPI.DAL.DBContext;
using EmployeeCRUDAPI.DAL.DTOs;
using EmployeeCRUDAPI.DAL.Entities;
using EmployeeCRUDAPI.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDAPI.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        EmployeeContext _dbcontext;
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<EmployeeDetailsDTO>> EmpDetailsByEmpNo(int employeeNo)
        {
            // linq 
            return await (from e in _dbcontext.Employees 
            join dept_emp in _dbcontext.DeptEmps on e.EmpNo equals dept_emp.EmpNo
            join d in _dbcontext.Departments on dept_emp.DeptNo equals d.DeptNo
            join s in _dbcontext.Salaries on e.EmpNo equals s.EmpNo
            join t in _dbcontext.Titles on e.EmpNo equals t.EmpNo
            where s.EmpNo == employeeNo 
            where t.EmpNo == employeeNo
            select new EmployeeDetailsDTO
            {
                EmpNo = e.EmpNo,
                FirstName = e.FirstName,    
                DeptName = d.DeptName,
                Salary = s.Salary1,
                Title = t.Title1
            }).ToListAsync();



        }


    }
}
