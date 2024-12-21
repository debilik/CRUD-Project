using System.Runtime.Serialization;

namespace TrainingProjectsUsers;

public class EmployeeFileService
{
    private string _directoryPath;

    public string _filePath;

    public EmployeeFileService()
    {
        _directoryPath = Directory.GetCurrentDirectory();
        _filePath = Path.Combine(_directoryPath, "employee.txt");
    }

    public string CreateFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            using FileStream fs = File.Create(filePath);
        }

        return filePath;
    }

    public  void SaveEmployeeToFile(string path, string? serializeEmployeeString)
    {
        using (StreamWriter employeeWriter = new StreamWriter(path, true))
        {
             employeeWriter.WriteLine(serializeEmployeeString);
        };
    }

    public void ReadEmployeesFile(string path)
    {
        using (StreamReader employeeReader = new StreamReader(path))
        {
            string employeeDetails = employeeReader.ReadToEnd();
            Console.WriteLine(employeeDetails);
        }
    }
}