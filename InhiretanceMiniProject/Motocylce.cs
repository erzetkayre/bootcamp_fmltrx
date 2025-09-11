using System.Diagnostics.CodeAnalysis;

public class Motocycle : Vehicle
{
    public bool HasSideCar { get; set; }

    [SetsRequiredMembers]
    public Motocycle(string make, string model, int year, bool hasSideCar) : base(make, model, year)
    {
        HasSideCar = hasSideCar;
    }

    public override void Brake(decimal amount)
    {
        if (amount < 0)
            Console.WriteLine("Pengeraman tidak bisa negatif");
        decimal addBrake = amount * 0.5m;
        base.Brake(addBrake);
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model} sedang {HasSideCar} di samping mobil. (Kecepatan: {CurrentSpeed} mph)";
    }
}