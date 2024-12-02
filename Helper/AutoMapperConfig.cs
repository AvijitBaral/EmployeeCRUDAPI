using AutoMapper;
using EmployeeCRUDAPI.DAL.DTOs;
using EmployeeCRUDAPI.DAL.Entities;

namespace EmployeeCRUDAPI.Helper
{
    public class AutoMapperConfig : Profile
    {
            public AutoMapperConfig()
            {
                CreateMap<Department, DepartmentDTO>()
                    .ForMember(src => src.DepartmentNumber, action => action.MapFrom(dst => dst.DeptNo))
                    .ReverseMap();

                CreateMap<Employee, EmployeeDTO>().ReverseMap();
                //CreateMap<Employee, EmployeeDetailsDTO>().ReverseMap();
        }

        }
    }
