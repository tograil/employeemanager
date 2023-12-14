using AutoMapper;
using EmployeeManagement.Api.Map;
using EmployeeManagement.Core.Dto;

namespace EmployeeManagement.Api.Models;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<SupervisorModel, Supervisor>()
            .ReverseMap();
        CreateMap<EmployeeModel, Employee>().ReverseMap();
        CreateMap<ManagerModel, Manager>().ReverseMap();

        CreateMap<Person, PersonModel>()
            .Include<Supervisor, SupervisorModel>()
            .Include<Employee, EmployeeModel>()
            .Include<Manager, ManagerModel>();
    }
}