namespace Classes;

public class Author
{
    private readonly string _firstName;
    private readonly string _lastName;

    public string Fullname => $"({_firstName} {_lastName})";

    public int Yearborn { get; init; }

    public Author(string firstName, string lastName, int yearBorn)
    {
        _firstName = firstName;
        _lastName = lastName;
        Yearborn = yearBorn;
    }

    public override string ToString()
    {
        return $"Author: {Fullname}, born: {Yearborn}";
    }
    
}