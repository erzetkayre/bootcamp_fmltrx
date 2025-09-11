namespace Inheritance;
public class Program
{
    static void Main() {
        var firstCar = new Car("Honda", "Civic", 2022, 4);
        var secondCar = new Car("Toyota", "Fortuner", 2025, 4);
        var thirdCar = new Car("Toyota", "Supra", 2024, 2);
        var electricCar = new ElectricCar("China", "BYD", 2024, 4, 50);

        firstCar.Accelerate(30);
        firstCar.BeepHorn();
        secondCar.Brake(20);
        secondCar.BeepHorn();
        thirdCar.Accelerate(50);
        thirdCar.BeepHorn();
        electricCar.Accelerate(50);
        electricCar.Brake(50);
        electricCar.BeepHorn();

        var firstMotor = new Motocycle("Honda", "Mio", 2020, true);
        var secondMotor = new Motocycle("Yamaha", "Beat", 2022, false);

        firstMotor.Brake(30);
        secondMotor.Accelerate(20);

        Console.WriteLine(firstCar);
        Console.WriteLine("=================================================");
        Console.WriteLine(secondCar);
        Console.WriteLine("=================================================");
        Console.WriteLine(thirdCar);
        Console.WriteLine("=================================================");
        Console.WriteLine(firstMotor);
        Console.WriteLine("=================================================");
        Console.WriteLine(secondMotor);
        Console.WriteLine(firstMotor);
        Console.WriteLine("=================================================");
        Console.WriteLine(electricCar);
    }
}


