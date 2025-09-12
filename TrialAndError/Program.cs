// Parent Class
public abstract class Animal
{
    public abstract string Sound { get; }
    public abstract void Move();
    public abstract void Looks();
}

// Category Class
public abstract class Bird : Animal
{
    public override void Move() => Console.WriteLine("Flying and Walking...");
    public override void Looks() => Console.WriteLine("Small in the sky..");
}

public abstract class Mamals : Animal
{
    public override void Move() => Console.WriteLine("Walking and Running...");
    public override void Looks() => Console.WriteLine("Big Body in the jungle..");

}

// Interface
public interface IHerbivore
{
    void Eat() => Console.WriteLine("Eats only plant-based foods...");
}
public interface ICarnivore
{
    void Eat() => Console.WriteLine("Meat-eater...");
}
public interface IFlyingCreature
{
    void Fly() => Console.WriteLine("I believe I can Fly..");
}
public interface IGroundCreature
{
    void Walk() => Console.WriteLine("It might be exists in Hollow Earth..");
}

// Conrete Class
public class Ostrich : Bird, ICarnivore
{
    public override string Sound => "Wraaaw!";
}
public class Owl : Bird, ICarnivore, IFlyingCreature
{
    public override string Sound => "Huho!";
}
public class Elephant : Mamals, IHerbivore, IGroundCreature
{
    public override string Sound => "Ruaaaa!";
}
public class Monkey : Mamals, IHerbivore, IGroundCreature
{
    public override string Sound => "Huhuhaha!";
}

// Parent Class Different Case
public abstract class Vehicle
{
    public abstract string Sound { get; }
    public virtual string Color { get; } = "White";
    public abstract void Move();
    public virtual void Looks() => Console.WriteLine("Big and wide");
}

// Category Class
public abstract class LandVehicle : Vehicle
{
    public override void Move() => Console.WriteLine("Move in land..");
    public override void Looks() => Console.WriteLine("Has four tires..");
}
public abstract class SkyVehicle : Vehicle
{
    public override void Move() => Console.WriteLine("Flying in the sky..");
    public override void Looks() => Console.WriteLine("Has two wings");
}
public abstract class WaterVehicle : Vehicle
{
    public override void Move() => Console.WriteLine("Floating in the sea..");
}

// Interface
public interface IPublicTransport
{
    void Public() => Console.WriteLine("it's a public transportation...");
}
public interface IPrivateTransport
{
    void Private() => Console.WriteLine("It's a private transportation...");
}
public interface ITwoPassangers
{
    void Passangers() => Console.WriteLine("It's just can be used by one or two passangers..");
}
public interface IFourPassangers
{
    void Passangers() => Console.WriteLine("It's can be used by one until four passangers..");
}
public interface IALotPassangers
{
    void Passangers() => Console.WriteLine("It's can be used by a lot of passangers..");
}

// Concrete Class
public class Car : LandVehicle, IFourPassangers, IPrivateTransport
{
    public override string Sound => "Wroom";
    public override string Color => "Has a lot of colors";
}

public class Motocycle : LandVehicle, ITwoPassangers, IPrivateTransport
{
    public override string Sound => "Wrappp!";
    public override void Looks() => Console.WriteLine("Has two tires");
}

public class Ferry : WaterVehicle, IALotPassangers, IPublicTransport
{
    public override string Sound => "Hooooonk!";
    public override string Color => "Green";
}
public class Plane : SkyVehicle, IALotPassangers, IPublicTransport
{
    public override string Sound => "Whooooshhh!";
}
public class Train : LandVehicle, IALotPassangers, IPublicTransport
{
    public override string Sound => "Peem Peem!";
    public override void Looks() => Console.WriteLine("Using a railroad track");
}

public class ClassAndInterfaceDemo
{
    public static void Main()
    {
        Console.WriteLine("=========== Demo Class and Interface on Animal Case ===========");
        var animals = new Animal[]
        {
            new Ostrich(),
            new Owl(),
            new Elephant(),
            new Monkey(),
        };

        foreach (var animal in animals)
        {
            Console.WriteLine($"========== {animal.GetType().Name} ==========");

            Console.WriteLine($"Animal's sounds: {animal.Sound}");

            if (animal is ICarnivore carnivore)
            {
                Console.WriteLine("This animal is ....");
                carnivore.Eat();
            }

            if (animal is IHerbivore herbivore)
            {
                Console.WriteLine("This animal ....");
                herbivore.Eat();
            }
            if (animal is IFlyingCreature flyer)
            {
                flyer.Fly();
            }
            if (animal is IGroundCreature grounder)
            {
                grounder.Walk();
            }
            
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("=========== Demo Class and Interface on Vehicle Case ===========");
        var vehicles = new Vehicle[]{
            new Car(),
            new Motocycle(),
            new Ferry(),
            new Train(),
            new Plane(),
        };

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"============ {vehicle.GetType().Name} ============");
            Console.WriteLine($"Vehicle's sound: {vehicle.Sound}");
            Console.WriteLine($"Vehicle's color: {vehicle.Color}");

            if (vehicle is IPrivateTransport @private) @private.Private();
            if (vehicle is IPublicTransport @public) @public.Public();
            if (vehicle is ITwoPassangers two) two.Passangers();
            if (vehicle is IFourPassangers four) four.Passangers();
            if (vehicle is IALotPassangers aLot) aLot.Passangers();

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}