namespace TrainingProjectsUsers;

public class EmployeeSerialize
{
    private string[] employeeFields;
    
    
    public string? Serialize(Employee employee)
    {
        employeeFields = new[]
        {
            employee.Id.ToString(),
            employee.FirstName,
            employee.LastName,
            employee.MiddleName,
            employee.DateOfBirth.ToString(),
            employee.Address,
            employee.Department,
            employee.AboutMe
        };
        string serializeString = string.Join(",", employeeFields);
        return serializeString;
    }
}