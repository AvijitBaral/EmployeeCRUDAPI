using AutoMapper;
using EmployeeCRUDAPI.DAL.DTOs;
using EmployeeCRUDAPI.DAL.Entities;
using EmployeeCRUDAPI.DAL.IRepositories;
using EmployeeCRUDAPI.DAL.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeCRUDAPI.BAL
{

    public class EmployeeService : IEmployeeService
    {
        IMapper _mapper;
        IEmployeeRepository _employeeRepo;

        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepo)
        {
            _mapper = mapper;
            _employeeRepo = employeeRepo;
        }


        public async Task<int> AddEmployeeService(EmployeeDTO req)
        {
            Employee newEmployee = _mapper.Map<Employee>(req);
            await _employeeRepo.AddAsync(newEmployee);
            await _employeeRepo.SaveChangesAsync();
            return newEmployee.EmpNo;
        }
        public async Task<EmployeeDTO> GetFirstEmployeeOnConditionService(int employeeId)
        {
            Employee? fetchedEmployee = await _employeeRepo.GetFirstOrDefaultAsync(e => e.EmpNo == employeeId);
            return _mapper.Map<EmployeeDTO>(fetchedEmployee);
        }
        public async Task<EmployeeDTO> UpdateEmployee(int employeeId, EmployeeDTO request)
        {
            Employee? updateEmployee = await _employeeRepo.GetFirstOrDefaultAsync(e => e.EmpNo == employeeId);
            if (updateEmployee == null)
            {
                return null;
            }
            updateEmployee.EmpNo = employeeId;
            updateEmployee.FirstName = request.FirstName;
            updateEmployee.LastName = request.LastName;
            updateEmployee.BirthDate = request.BirthDate;
            await _employeeRepo.UpdateAsync(updateEmployee);
            await _employeeRepo.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(updateEmployee);
        }
        public async Task<int> DeleteEmployee(int employeeId)
        {
            Employee? existingEmployee = await _employeeRepo.GetFirstOrDefaultAsync(e => e.EmpNo == employeeId);
            if (existingEmployee == null)
            {
                return existingEmployee.EmpNo;
            }
            await _employeeRepo.DeleteAsync(existingEmployee);
            await _employeeRepo.SaveChangesAsync();
            return existingEmployee.EmpNo;

        }
        public async Task<IEnumerable<EmployeeDetailsDTO>> EmpDetailsByEmpNo(int employeeNo)
        {
            return await _employeeRepo.EmpDetailsByEmpNo(employeeNo);
        }
    }
}
