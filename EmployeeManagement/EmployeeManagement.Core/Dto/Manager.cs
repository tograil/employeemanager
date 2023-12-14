namespace EmployeeManagement.Core.Dto;

public class Manager : Person
{
    public decimal AnnualSalary { get; set; }
    public decimal MaxExpenseAmount { get; set; }
}