using AutoMapper;
using EmployeeCRUDAPI.DAL.DTOs;
using EmployeeCRUDAPI.DAL.Entities;
using EmployeeCRUDAPI.DAL.IRepositories;

namespace EmployeeCRUDAPI.BAL
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _DepartmentRepository;
        IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _DepartmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentService()
        {
            IEnumerable<Department> fetchedDepartment = await _DepartmentRepository.GetAll();
            IEnumerable<DepartmentDTO> fetchedDeaprtmentDTO = _mapper.Map<IEnumerable<DepartmentDTO>>(fetchedDepartment);

            return fetchedDeaprtmentDTO;
        }

    }
}
