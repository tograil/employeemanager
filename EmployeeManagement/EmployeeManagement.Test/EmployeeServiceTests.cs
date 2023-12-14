using EmployeeManagement.Core.Contracts;
using EmployeeManagement.Core.Dto;
using EmployeeManagement.Infrastructure.Services;
using EmployeeManagement.Test.Utils;
using NUnit.Framework;

namespace EmployeeManagement.Test;

[TestFixture]
public class EmployeeServiceTests
{
    private IEmployeesService _employeesService;

    [SetUp]
    public void Setup()
    {
        var context = DatabaseUtils.GetInMemoryDatabaseContext();

        _employeesService = new EmployeeService(context);
    }

    [Test]
    public async Task GetEmployeesAsync_ShouldReturnEmptyList_WhenNoEmployeesExist()
    {
        // Arrange

        // Act
        var employees = await _employeesService.GetEmployeesAsync();

        // Assert
        Assert.That(employees, Is.Empty);
    }

    [Test]
    public async Task GetEmployeesAsync_ShouldReturnEmployees_WhenEmployeesExist()
    {
        // Arrange
        var employee = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "123 Main St.",
            PayPerHour = 10

        };

        await _employeesService.AddEmployeeAsync(employee);

        // Act
        var employees = await _employeesService.GetEmployeesAsync();

        // Assert
        Assert.That(employees, Is.Not.Empty);
        Assert.That(employees.Count(), Is.EqualTo(1));
        Assert.That(employees.First().FirstName, Is.EqualTo(employee.FirstName));
        Assert.That(employees.First().LastName, Is.EqualTo(employee.LastName));
        Assert.That(employees.First().Address, Is.EqualTo(employee.Address));
        Assert.That(employees.First(), Is.TypeOf<Employee>());
        Assert.That((employees.First() as Employee)!.PayPerHour, Is.EqualTo(employee.PayPerHour));
    }

    [Test]
    public async Task AddManagerAsync_ShouldAddManager_WhenManagerDoesNotExist()
    {
        // Arrange
        var manager = new Manager
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "123 Main St.",
            AnnualSalary = 30000,
            MaxExpenseAmount = 1000
        };

        // Act
        await _employeesService.AddManagerAsync(manager);

        // Assert
        var employees = await _employeesService.GetEmployeesAsync();

        Assert.That(employees, Is.Not.Empty);
        Assert.That(employees.Count(), Is.EqualTo(1));
        Assert.That(employees.First().FirstName, Is.EqualTo(manager.FirstName));
        Assert.That(employees.First().LastName, Is.EqualTo(manager.LastName));
        Assert.That(employees.First().Address, Is.EqualTo(manager.Address));
        Assert.That(employees.First(), Is.TypeOf<Manager>());
        Assert.That((employees.First() as Manager)!.AnnualSalary, Is.EqualTo(manager.AnnualSalary));
        Assert.That((employees.First() as Manager)!.MaxExpenseAmount, Is.EqualTo(manager.MaxExpenseAmount));
    }

    [Test]
    public async Task AddSupervisorAsync_ShouldAddSupervisor_WhenSupervisorDoesNotExist()
    {
        // Arrange
        var supervisor = new Supervisor
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "123 Main St.",
            AnnualSalary = 30000
        };

        // Act
        await _employeesService.AddSupervisorAsync(supervisor);

        // Assert
        var employees = await _employeesService.GetEmployeesAsync();

        Assert.That(employees, Is.Not.Empty);
        Assert.That(employees.Count(), Is.EqualTo(1));
        Assert.That(employees.First().FirstName, Is.EqualTo(supervisor.FirstName));
        Assert.That(employees.First().LastName, Is.EqualTo(supervisor.LastName));
        Assert.That(employees.First().Address, Is.EqualTo(supervisor.Address));
        Assert.That(employees.First(), Is.TypeOf<Supervisor>());
        Assert.That((employees.First() as Supervisor)!.AnnualSalary, Is.EqualTo(supervisor.AnnualSalary));
    }

    [Test]
    public async Task GetPersonsOfDifferentTypes_ShouldReturnManagerAndSupervisor()
    {
        // Arrange
        var manager = new Manager
        {
            FirstName = "John",
            LastName = "Doe",
            Address = "123 Main St.",
            AnnualSalary = 30000,
            MaxExpenseAmount = 1000
        };

        var supervisor = new Supervisor
        {
            FirstName = "Jane",
            LastName = "Doe",
            Address = "123 Main St.",
            AnnualSalary = 30000
        };

        await _employeesService.AddManagerAsync(manager);
        await _employeesService.AddSupervisorAsync(supervisor);

        // Act
        var employees = await _employeesService.GetEmployeesAsync();

        // Assert
        Assert.That(employees, Is.Not.Empty);
        Assert.That(employees.Count(), Is.EqualTo(2));
        Assert.That(employees.First().FirstName, Is.EqualTo(manager.FirstName));
        Assert.That(employees.First().LastName, Is.EqualTo(manager.LastName));
        Assert.That(employees.First().Address, Is.EqualTo(manager.Address));
        Assert.That(employees.First(), Is.TypeOf<Manager>());
        Assert.That((employees.First() as Manager)!.AnnualSalary, Is.EqualTo(manager.AnnualSalary));
        Assert.That((employees.First() as Manager)!.MaxExpenseAmount, Is.EqualTo(manager.MaxExpenseAmount));

        Assert.That(employees.Last().FirstName, Is.EqualTo(supervisor.FirstName));
        Assert.That(employees.Last().LastName, Is.EqualTo(supervisor.LastName));
        Assert.That(employees.Last().Address, Is.EqualTo(supervisor.Address));
        Assert.That(employees.Last(), Is.TypeOf<Supervisor>());
        Assert.That((employees.Last() as Supervisor)!.AnnualSalary, Is.EqualTo(supervisor.AnnualSalary));
    }
}