using EmployeeManagement.Core.Enums;

namespace EmployeeManagement.Api.Map;

public class PersonModel
{
    PersonType PersonType { get; set; }
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}