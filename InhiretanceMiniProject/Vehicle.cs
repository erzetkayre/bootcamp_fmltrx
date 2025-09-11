public class Vehicle
{
    public required string Make { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public decimal CurrentSpeed { get; protected set; }

    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
        CurrentSpeed = 40;
    }
    public virtual void Accelerate(decimal amount)
    {
        if (amount < 0)
            Console.WriteLine("Kecepatan tidak bisa negatif");
        CurrentSpeed += amount;

        Console.WriteLine($"Kendaraan {Make} {Model} sedang melaju dengan kecepatan {CurrentSpeed} mph");
    }

    public virtual void Brake(decimal amount)
    {
        if (amount < 0)
            Console.WriteLine("Pengereman tidak bisa negatif");
        CurrentSpeed -= amount;

        if (CurrentSpeed < 0) CurrentSpeed = 0;
        Console.WriteLine($"Kendaraan {Make} {Model} sedang melambat dengan kecepatan {CurrentSpeed} mph");
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model} (Kecepatan: {CurrentSpeed} mph)";
    }
}
