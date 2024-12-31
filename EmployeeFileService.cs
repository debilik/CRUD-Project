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

    public void DeleteEmployeeById(string id)
    {
        var lines = File.ReadAllLines(FilePath).ToList();

        var updatedLines = lines.Where(line => !line.StartsWith(id + ",")).ToList();

        if (updatedLines.Count == lines.Count)
        {
            Console.WriteLine("Сотрудник с таким ID не найден.");
            return;
        }

        File.WriteAllLines(FilePath, updatedLines);
        Console.WriteLine($"Сотрудник с ID {id} удалён.");
    }

    /*public void EditEmployee(int id)
    {
        var lines = File.ReadAllLines(FilePath).ToList();
        var employeeIndex = lines.FindIndex(line => line.StartsWith(id + ","));

        var parts = lines[employeeIndex].Split(",");
        var employee = new Employee
        {
            Id = int.Parse(parts[0]),
            FirstName = parts[1],
            LastName = parts[2],
            MiddleName = parts[3],
            DateOfBirth = DateOnly.Parse(parts[4]),
            Address = parts[5],
            Department = parts[6],
            AboutMe = parts[7],
        };

        Console.WriteLine("Текущие данные сотрудника:");
        Console.WriteLine($"1. FirstName: {employee.FirstName}");
        Console.WriteLine($"2. LastName: {employee.LastName}");
        Console.WriteLine($"3. MiddleName: {employee.MiddleName}");
        Console.WriteLine($"4. DateOfBirth: {employee.DateOfBirth}");
        Console.WriteLine($"5. Address: {employee.Address}");
        Console.WriteLine($"6. Department: {employee.Department}");
        Console.WriteLine($"7. AboutMe: {employee.AboutMe}");
        Console.WriteLine("Введите номер поля, которое хотите изменить, или 0 для завершения:");

        while (true)
        {
            int choice = Convert.ToInt32(Console.ReadLine() ?? "0");
            if (choice == 0) break;
            {
                
            }
        }
    }*/
}