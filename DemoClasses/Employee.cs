namespace Classes;

public class Employee
{
    private string _name;
    private int _age;
    private readonly DateTime _hireDate;
    private static int _totalEmployees;
    private static int _totalWorkHours;

    public Employee(string name, int age)
    {
        this._name = name ?? throw new ArgumentNullException(nameof(name));
        this._age = age;
        this._hireDate = DateTime.Now;

        _totalEmployees++;

        Console.WriteLine($"New employee hired: {name}, total employee: {_totalEmployees}");
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            _name = value;
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 10 || value > 100)
                throw new ArgumentException("Age must be between 10 and 100");
            _age = value;
        }
    }
}