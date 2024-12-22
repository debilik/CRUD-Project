using System.Diagnostics;
using TrainingProjectsUsers;

EmployeeFileService emplFileService = new EmployeeFileService();
emplFileService.CreateFile();

Console.WriteLine("Выбирите опцию: " +
                  "\n 1) Добавить сотрудника" +
                  "\n 2) Удалить сотрудника " +
                  "\n 3) Просмотреть список сотрудников \n");

switch (Console.ReadLine())
{
    case "1":
        Employee employee1 = new Employee();
        
        Console.WriteLine("Введите имя сотрудника");
        employee1.FirstName = Console.ReadLine();
        Console.WriteLine("Введите фамилию сотрудника");
        employee1.LastName = Console.ReadLine();
        Console.WriteLine("Введите отчество сотрудника");
        employee1.MiddleName = Console.ReadLine();
        Console.WriteLine("Введите дату рождения сотрудника");
        employee1.DateOfBirth = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Введите адрес сотрудника");
        employee1.Address = Console.ReadLine();
        Console.WriteLine("Введите отдел сотрудника");
        employee1.AboutMe = Console.ReadLine();
        Console.WriteLine("Введите информацию 'о себе' сотрудника");
        
        EmployeeSerialize employeeSerialize = new EmployeeSerialize();
        string serializeString = employeeSerialize.Serialize(employee1);
        
        emplFileService.SaveEmployeeToFile(employee1, serializeString );
        break;
}