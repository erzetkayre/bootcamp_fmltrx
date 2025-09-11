using System.Diagnostics.CodeAnalysis;

public class ElectricCar : Car
{
    public decimal BatteryLevel { get; set; }

    [SetsRequiredMembers]
    public ElectricCar(string make, string model, int year, int numDoors, decimal battery) : base(make, model, year, numDoors)
    {
        BatteryLevel = battery;
    }

    public override void Accelerate(decimal amount)
    {
        if (amount < 0)
            Console.WriteLine("Kecepatan tidak bisa negatif");
        decimal electricCarSpeed = amount * 2.5m;
        base.Accelerate(electricCarSpeed);
    }

    public override void Brake(decimal amount)
    {
        if (amount < 0)
            Console.WriteLine("Pengereman tidak bisa negatif");
        decimal electricCarBrake = amount * 2.5m;
        base.Brake(electricCarBrake);
    }
}
