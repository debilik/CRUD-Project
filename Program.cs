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
                      "\n 4) Закрыть программу");

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
            
            
            break;
        case "2":
            Console.WriteLine("Введите имя удаляемого сотрудника:");
            string firstNameToDelited = Console.ReadLine();
            Console.WriteLine("Введите фамилию удаляемого сотрудника:");
            string lastNameToDelited = Console.ReadLine();
            Console.WriteLine("Введите отчество удаляемого сотрудника:");
            string middleNameToDelited = Console.ReadLine();
            emplFileService.RemoveEmployee(firstNameToDelited, lastNameToDelited, middleNameToDelited);
            Console.WriteLine($"Сотрудник {firstNameToDelited} {lastNameToDelited} {middleNameToDelited} удалён");
            break;
        case "3":
            emplFileService.ReadEmployeesFile();
            break;
        case "4":
            showMenu = false;
            Console.WriteLine("Программа закрыта");
            break;
        default:
            Console.WriteLine("Некорректная опция");
            break;
    }
}