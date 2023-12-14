using EmployeeManagement.Core.Dto;

namespace EmployeeManagement.Core.Contracts;

public interface IEmployeesService
{
    public Task<IEnumerable<Person>> GetEmployeesAsync();
    public Task AddEmployeeAsync(Employee employee);
    public Task AddManagerAsync(Manager manager);
    public Task AddSupervisorAsync(Supervisor supervisor);
}