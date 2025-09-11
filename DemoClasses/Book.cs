namespace Classes;

public class Book
{
    public const int MAX_TITLE_LENGTH = 100;
    public const decimal DEFAULT_PRICE = 25.00m;
    private string _isbn;
    private decimal _price;

    public string Title { get; set; }
    public Author BookAuthor { get; }
    public int Pages { get; }
    public string ISBN
    {
        get => _isbn;
        private set
        {
            if (value != null && value.Length == 13)
            {
                _isbn = value;
            }
            else
            {
                _isbn = "N/A";
                Console.WriteLine($"ISBN tidak ditemukan, {nameof(ISBN)} tidak ditemukan");
            }
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                _price = value;
            }
            else
            {
                _price = DEFAULT_PRICE;
                Console.WriteLine($"Harga {nameof(Price)} pada buku {Title} menjadi {DEFAULT_PRICE}");
            }
        }
    }

    public Book(string title, Author author, int pages, string isbn)
    {
        Title = title;
        BookAuthor = author;
        Pages = pages;
        ISBN = isbn;
        Price = DEFAULT_PRICE;
    }

    public Book(string title, Author author, int pages, string isbn, decimal price) : this(title, author, pages, isbn)
    {
        Price = price;
    }

    public override string ToString()
    {
        return $"Book Title: {Title}, Author: {BookAuthor}, Pages: {Pages}, ISBN: {ISBN}, Price: {Price}";
    }

}