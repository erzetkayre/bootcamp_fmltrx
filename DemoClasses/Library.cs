namespace Classes;

public class Library
{
    public static readonly string LibraryName = "City Central Library";
    private List<Book> _books;
    static Library()
    {
        Console.WriteLine("Initializing Library System...");
    }
    public Library()
    {
        _books = new List<Book>();
    }

    
}