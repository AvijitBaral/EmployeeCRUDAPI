using EmployeeCRUDAPI.DAL.DTOs;

namespace EmployeeCRUDAPI.BAL
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentDTO>> GetAllDepartmentService();
    }

}
