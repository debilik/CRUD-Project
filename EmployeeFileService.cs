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

    public void EditEmployee(int id)
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
        Console.WriteLine($"1. Имя: {employee.FirstName}");
        Console.WriteLine($"2. Фамилия: {employee.LastName}");
        Console.WriteLine($"3. Отчество: {employee.MiddleName}");
        Console.WriteLine($"4. Дата рождения: {employee.DateOfBirth}");
        Console.WriteLine($"5. Адрес: {employee.Address}");
        Console.WriteLine($"6. Отдел: {employee.Department}");
        Console.WriteLine($"7. О себе: {employee.AboutMe}");
        Console.WriteLine("Введите номер поля, которое хотите изменить, или 0 для завершения:");

        while (true)
        {
            int choice = Convert.ToInt32(Console.ReadLine() ?? "0");
            if (choice == 0) break;

            Console.WriteLine("Введите новое значение: ");
            string newValue = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case 1:
                    employee.FirstName = newValue;
                    break;
                case 2:
                    employee.LastName = newValue;
                    break;
                case 3:
                    employee.MiddleName = newValue;
                    break;
                case 4:
                    employee.DateOfBirth = DateOnly.Parse(newValue);
                    break;
                case 5:
                    employee.Address = newValue;
                    break;
                case 6:
                    employee.Department = newValue;
                    break;
                case 7:
                    employee.AboutMe = newValue;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    continue;
            }

            Console.WriteLine("Поле успешно обновлено. Выберите следующее или нажмите 0 для завершения");
        }

        lines[employeeIndex] = $"{employee.Id}, {employee.FirstName}, {employee.LastName}, {employee.MiddleName} " +
                               $"{employee.DateOfBirth}, {employee.Address}, {employee.Department}, {employee.AboutMe}";
        File.WriteAllLines(FilePath, lines);
        Console.WriteLine("Данные сотрудника обновлены");
    }
}