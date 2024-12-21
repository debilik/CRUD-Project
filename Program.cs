using TrainingProjectsUsers;

Employee employee1 = new Employee("Иван", "Иванов", "Иванович",
    new DateOnly(2001, 09, 02), "Пушкина 21",
    "Продажи", "Зверюга");

EmployeeSerialize serializer = new EmployeeSerialize();

string? serializeString = serializer.Serialize(employee1);

EmployeeFileService fileService = new EmployeeFileService();

fileService.CreateFile(fileService._filePath);

fileService.SaveEmployeeToFile(fileService._filePath, serializeString);

fileService.ReadEmployeesFile(fileService._filePath);