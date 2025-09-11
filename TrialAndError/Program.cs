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

// Conrete Class
public class Ostrich : Bird, IHerbivore
{
    public override string Sound => "Wraaaw!";
}
public class Owl : Bird, ICarnivore, IFlyingCreature
{
    public override string Sound => "Huho!";
}
public class Elephant : Mamals, IHerbivore
{
    public override string Sound => "Ruaaaa!";
}
public class Monkey : Mamals, IHerbivore
{
    public override string Sound => "Huhuhaha!";
}

public class ClassAndInterfaceDemo
{
    public static void Main()
    {
        var bird = new Ostrich();
        bird.Move();
        bird.Looks();

        if (bird is ICarnivore carnivore) carnivore.Eat();
        Console.WriteLine();
        Console.WriteLine(bird.Sound);
        

    }
}