namespace TrainingProjectsUsers;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Department { get; set; }
    public string AboutMe { get; set; }

    public Employee(int id, string firstName, string lastName, string middleName,
        DateOnly dateOfBirth, string address, string department, string aboutMe)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        DateOfBirth = dateOfBirth;
        Address = address;
        Department = department;
        AboutMe = aboutMe;
    }

    public Employee()
    {
    }
}