using System.Runtime.Serialization;

namespace TrainingProjectsUsers;

public class EmployeeFileService
{
    private string _directoryPath;

    public string _filePath;

    List<Employee> _employees = new List<Employee>();

    public EmployeeFileService()
    {
        _directoryPath = Directory.GetCurrentDirectory();
        _filePath = Path.Combine(_directoryPath, "employee.txt");
    }

    public void CreateFile()
    {
        if (!File.Exists(_filePath))
        {
            using FileStream fs = File.Create(_filePath);
        }
    }

    public void SaveEmployeeToFile(Employee employee, string? serializeEmployeeString)
    {
        using (StreamWriter employeeWriter = new StreamWriter(_filePath, true))
        {
            employeeWriter.WriteLine(serializeEmployeeString);
            _employees.Add(employee);
        }
    }

    public void ReadEmployeesFile(string path)
    {
        using (StreamReader employeeReader = new StreamReader(path))
        {
            string employeeDetails = employeeReader.ReadToEnd();
            Console.WriteLine(employeeDetails);
        }
    }

    public void RemoveEmployee(string path)
    {
    }
}