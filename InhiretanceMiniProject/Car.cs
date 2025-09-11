using System.Diagnostics.CodeAnalysis;

public class Car : Vehicle
{
    public int NumDoors { get; set; }

    [SetsRequiredMembers]
    public Car(string make, string model, int year, int numDoors) : base(make, model, year)
    {
        NumDoors = numDoors;
    }

    public override void Accelerate(decimal amount)
    {
        if (amount < 0)
            Console.WriteLine("Kecepatan tidak bisa negatif");
        decimal addBoost = amount * 1.5m;

        base.Accelerate(addBoost);
    }

    public new void BeepHorn()
    {
        Console.WriteLine("Mobil klakson beeps!");
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model} memiliki {NumDoors} pintu. (Kecepatan: {CurrentSpeed} mph)";
    }

}