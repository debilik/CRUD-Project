using System.Runtime.Serialization;

namespace TrainingProjectsUsers;

public class EmployeeFileService
{
    private string _directoryPath;

    public string FilePath;

    List<Employee> _employees = new List<Employee>();

    public EmployeeFileService()
    {
        _directoryPath = Directory.GetCurrentDirectory();
        FilePath = Path.Combine(_directoryPath, "employee.txt");
    }

    public void CreateFile()
    {
        if (!File.Exists(FilePath))
        {
            using FileStream fs = File.Create(FilePath);
        }
    }

    public void SaveEmployeeToFile(Employee employee, string? serializeEmployeeString)
    {
        using (StreamWriter employeeWriter = new StreamWriter(FilePath, true))
        {
            employeeWriter.WriteLine(serializeEmployeeString);
            _employees.Add(employee);
        }
    }

    public void ReadEmployeesFile()
    {
        using (StreamReader employeeReader = new StreamReader(FilePath))
        {
            string employeeDetails = employeeReader.ReadToEnd();
            Console.WriteLine(employeeDetails);
        }
    }

    public void RemoveEmployee(string firstName, string lastName, string middleName)
    {
        var lines = File.ReadAllLines(FilePath).ToList();
        var editedLine = lines.Where(line =>
        {
            var parts = line.Split(',');
            return !(parts[0] == firstName && parts[1] == lastName && parts[2] == middleName);
        }).ToList();
        File.WriteAllLines(FilePath, editedLine);
    }

    public void EditEmployee(int id)
    {
        /* var lines = File.ReadAllLines(_filePath).ToList();
        var editedLine = lines.Where(line =>
        {
            var parts = line.Split(',');
            if (parts[0] == firstName && parts[1] == lastName && parts[2] == middleName)
            {
                
            }

            
        }).ToList(); */
    }
}