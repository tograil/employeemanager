using AutoMapper;
using EmployeeManagement.Api.Map;
using EmployeeManagement.Core.Contracts;
using EmployeeManagement.Core.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeesService _employeeService;

        public EmployeeController(IMapper mapper, IEmployeesService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonModel>> Get()
        {
            return _mapper.Map<IEnumerable<PersonModel>>(await _employeeService.GetEmployeesAsync());
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task Post([FromBody] EmployeeModel value)
        {
            await _employeeService.AddEmployeeAsync(_mapper.Map<Employee>(value));
        }

        [HttpPost]
        [Route("AddManager")]
        public async Task Post([FromBody] ManagerModel value)
        {
            await _employeeService.AddManagerAsync(_mapper.Map<Manager>(value));
        }

        [HttpPost]
        [Route("AddSupervisor")]
        public async Task Post([FromBody] SupervisorModel value)
        {
            await _employeeService.AddSupervisorAsync(_mapper.Map<Supervisor>(value));
        }
    }
}
