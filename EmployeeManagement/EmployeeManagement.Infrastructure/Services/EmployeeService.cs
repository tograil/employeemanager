using EmployeeManagement.Core.Contracts;
using EmployeeManagement.Core.Dto;
using EmployeeManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Services;

public class EmployeeService : IEmployeesService
{
    private readonly EmployeeContext _context;

    public EmployeeService(EmployeeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetEmployeesAsync()
    {
        return await _context.Set<Person>().ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Set<Employee>().AddAsync(employee);

        await _context.SaveChangesAsync();
    }

    public async Task AddManagerAsync(Manager manager)
    {
        await _context.Set<Manager>().AddAsync(manager);

        await _context.SaveChangesAsync();
    }

    public async Task AddSupervisorAsync(Supervisor supervisor)
    {
        await _context.Set<Supervisor>().AddAsync(supervisor);

        await _context.SaveChangesAsync();
    }
}