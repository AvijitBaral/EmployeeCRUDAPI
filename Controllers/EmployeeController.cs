using EmployeeCRUDAPI.BAL;
using EmployeeCRUDAPI.DAL.DTOs;
using EmployeeCRUDAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        [HttpGet("v1/GetAllDepartment")]
        public async Task<ResponseModel<IEnumerable<DepartmentDTO>>> GetAllDepartmentController()
        {
            ResponseModel<IEnumerable<DepartmentDTO>> response = new ResponseModel<IEnumerable<DepartmentDTO>>();
            try
            {
                response.Result = await _departmentService.GetAllDepartmentService();
            }
            catch (Exception)
            {
                response.StatusMessage = "BAD REQUEST";
            }
            return response;
        }
        [HttpGet("v1/GetEmployeeById")]
        public async Task<ResponseModel<EmployeeDTO>> GetEmployeeById(int employeeId)
        {
            ResponseModel<EmployeeDTO> response = new ResponseModel<EmployeeDTO>();
            try
            {
                response.Result = await _employeeService.GetFirstEmployeeOnConditionService(employeeId);
            }
            catch (Exception )
            {
                response.StatusMessage = "BAD REQUEST";
            }
            return response;
        }

        [HttpPost("v1/AddEmployee")]
        public async Task<ResponseModel<int>> Add([FromBody] EmployeeDTO request)
        {
            ResponseModel<int> response = new ResponseModel<int>();
            try
            {
                response.Result = await _employeeService.AddEmployeeService(request);
                response.StatusMessage = "Employee added successfully";
            }
            catch (Exception )
            {
                response.StatusMessage = "BAD REQUEST";
            }
            return response;
        }
        [HttpPut("v1/UpdateEmployee")]
        public async Task<ResponseModel<EmployeeDTO>> UpdateEmployee([FromQuery] int employeeId, [FromBody] EmployeeDTO request)
        {
            ResponseModel<EmployeeDTO> response = new ResponseModel<EmployeeDTO>();
            try
            {
                response.Result = await _employeeService.UpdateEmployee(employeeId, request);
                response.StatusMessage = "Employee update successfully";
            }
            catch (Exception ex)
            {
                response.StatusMessage = "BAD REQUEST";
            }
            return response;
        }

        [HttpDelete("v1/DeleteEmployee")]
        public async Task<ResponseModel<int>> DeleteEmployee([FromQuery] int id)
        {
            ResponseModel<int> response = new ResponseModel<int>();
            try
            {
                response.Result = await _employeeService.DeleteEmployee(id);
                response.StatusMessage = "Employee Delete successfully";
            }
            catch (Exception)
            {
                response.StatusMessage = "BAD REQUEST";
            }
            return response;
        }
        [HttpGet("v1/GetEmployeeDetailsById")]
        public async Task<ResponseModel<IEnumerable<EmployeeDetailsDTO>>> GetEmployeeDetailsById(int employeeNo)
        {
            ResponseModel<IEnumerable<EmployeeDetailsDTO>> response = new ResponseModel<IEnumerable<EmployeeDetailsDTO>>();
            try
            {
                response.Result = await _employeeService.EmpDetailsByEmpNo(employeeNo);
            }
            catch (Exception)
            {
                response.StatusMessage = "BAD REQUEST";
            }
            return response;
        }
    }
            

}
