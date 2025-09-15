class Program
{
    static void Main()
    {
        Console.WriteLine("Masukkan Nama Kucing 1: ");
        string catName1 = Console.ReadLine() ?? "Mery";
        Console.WriteLine();
        Console.WriteLine("Masukkan Nama Kucing 2: ");
        string catName2 = Console.ReadLine() ?? "Unknown";
        Console.WriteLine();
        Console.WriteLine("Masukkan Nama Kucing 3: ");
        string catName3 = Console.ReadLine() ?? "Unknown";
        Console.WriteLine();



        var cat1 = new Cat { Name = catName1, Age = 2 };
        var cat2 = new Cat { Name = catName2, Age = 5 };
        var cat3 = new Cat { Name = catName3, Age = 10 };
        var dog = new Dog { Name = "Tigreal", Age = 12 };

        cat1.Meow();
        cat1.Feed("Fish");

        cat2.Meow();
        cat2.Feed("");

        dog.Bark();

        var house = new CatHouse();
        house.Add(cat1);
        house.Add(cat2);
        house.Add(cat3);

        Console.WriteLine("\nAll Cats in the House:");
    }
}

class CatHouse : IEnumerable<Cat>
{
    List<Cat> cats = new List<Cat>();

    public void Add(Cat cat) => cats.Add(cat);

    public IEnumerator<Cat> GetEnumerator()
    {
        foreach (var c in cats)
            yield return c;
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        => GetEnumerator();

}