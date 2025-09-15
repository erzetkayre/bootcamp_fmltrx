public class Dog
{
    public required string Name { get; set; }
    public required int? Age { get; set; }

    public event EventHandler? OnBark;

    public void Bark()
    {
        Console.WriteLine($"{Name} is barking");
        OnBark?.Invoke(this, EventArgs.Empty);
    }
}

public class Cat
{
    public required string Name { get; set; }
    public required int Age { get; set; }

    public event EventHandler? OnMeow;
    public void Meow()
    {
        Console.WriteLine($"{Name} says Meowww!!");
        OnMeow?.Invoke(this, EventArgs.Empty);
    }
    public void Feed(string food)
    {
        try
        {
            if ((string.IsNullOrEmpty(food)))
                throw new ArgumentException("Food cant be empty");

            Console.WriteLine($"{Name} eats {food} happily...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error feeding cat: {ex}");
        }
    }
}