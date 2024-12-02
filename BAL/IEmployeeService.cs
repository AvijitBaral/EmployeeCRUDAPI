using EmployeeCRUDAPI.DAL.DTOs;

namespace EmployeeCRUDAPI.BAL
{
    public interface IEmployeeService
    {
        public Task<int> AddEmployeeService(EmployeeDTO req);
        public Task<EmployeeDTO> GetFirstEmployeeOnConditionService(int employeeId);
        public Task<EmployeeDTO> UpdateEmployee(int employeeId, EmployeeDTO request);
        public Task<int> DeleteEmployee(int employeeId);
        public Task<IEnumerable<EmployeeDetailsDTO>> EmpDetailsByEmpNo(int employeeNo);
    }
}
