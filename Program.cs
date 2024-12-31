using System.Diagnostics;
using TrainingProjectsUsers;

EmployeeFileService emplFileService = new EmployeeFileService();
emplFileService.CreateFile();

bool showMenu = true;

while (showMenu)
{
    Console.WriteLine("Выбирите опцию: " +
                      "\n 1) Добавить сотрудника" +
                      "\n 2) Удалить сотрудника " +
                      "\n 3) Просмотреть список сотрудников" +
                      "\n 4) Изменить данные сотрудника(предварительно посмотрите его ID)" +
                      "\n 5) Закрыть программу");
        

    switch (Console.ReadLine())
    {
        case "1":

            Console.WriteLine("Введите имя сотрудника");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите отчество сотрудника");
            string middleName = Console.ReadLine();
            Console.WriteLine("Введите дату рождения сотрудника");
            DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Введите адрес сотрудника");
            string address = Console.ReadLine();
            Console.WriteLine("Введите отдел сотрудника");
            string department = Console.ReadLine();
            Console.WriteLine("Введите информацию 'о себе' сотрудника");
            string aboutMe = Console.ReadLine();


            int id = File.ReadAllLines(emplFileService.FilePath).Count();

            Employee employee1 = new Employee(id, firstName, lastName, middleName, dateOfBirth, address, department,
                aboutMe);


            EmployeeSerialize employeeSerialize = new EmployeeSerialize();
            string serializeString = employeeSerialize.Serialize(employee1);

            emplFileService.SaveEmployeeToFile(employee1, serializeString);

            Console.WriteLine($"Сотрудник {firstName} {lastName} добавлен");
            
            
            break;
        case "2":
            Console.WriteLine("Введите id удаляемого сотрудника:");
            string idToDeleted = Console.ReadLine();
            emplFileService.DeleteEmployeeById(idToDeleted);
            Console.WriteLine($"Сотрудник удалён");
            break;
        case "3":
            emplFileService.ReadEmployeesFile();
            break;
        case "4":
            Console.WriteLine("Введите ID сотрудника: ");
            int idEmployee = int.Parse(Console.ReadLine());
            emplFileService.EditEmployee(idEmployee);
            break;
        case "5":
            showMenu = false;
            Console.WriteLine("Программа закрыта");
            break;
        default:
            Console.WriteLine("Некорректная опция");
            break;
    }
}