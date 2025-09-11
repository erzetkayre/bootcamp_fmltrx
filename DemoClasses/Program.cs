using System.Reflection.Metadata;

namespace Classes;

class Program
{
    static void Main()
    {
        // Mini Project
        // Console.WriteLine("1. Basic Classes - The Foundation:");

        // var author = new Author("Tere", "Liye", 2000);
        // var author2 = new Author("Andrea", "Hirata", 1999);

        // var book = new Book("Laskar Pelangi", author, 100, "ISJHDYTAGSTY2");
        // var book2 = new Book("Harry Potter", author2, 100, "");
        // var book3 = new Book("Rich Dad Poor Dad", new Author("Andrea", "Hirata", 2000), 230, "ad", -10);
        // book.Price = 100;

        // Console.WriteLine(author);
        // Console.WriteLine(author2);
        // Console.WriteLine(book);
        // Console.WriteLine(book2);
        // Console.WriteLine(book3);

        // Employee Demo
        EmployeeDemo();

        // Constants Demo
        ConstantsDemo();
    }

    static void EmployeeDemo()
    {
        Console.WriteLine("======= Class Demo using Employees Case ====================");
        Console.WriteLine("============================================================\n");
        var employee = new Employee("John Doe", 28);
        var teamLeader = new Employee("Jonathan Crabs", 45);

        Console.WriteLine($"Employee: {employee.Name}, Age: {employee.Age}");
        Console.WriteLine($"Team Leader: {teamLeader.Name}, Age: {teamLeader.Age}");
        Console.WriteLine("============================================================\n");
    }

    static void ConstantsDemo()
    {
        Console.WriteLine("\n======= Constant Demo using Math Case ======================");
        Console.WriteLine("============================================================\n");
    
        double radius = 10.55;
        // Constants -> cannot be different
        Console.WriteLine($"PI value: {Constants.PI}");
        Console.WriteLine($"Speed of Light value: {Constants.SPEED_OF_LIGHT}");
        Console.WriteLine($"E value: {Constants.E}");
        Console.WriteLine($"Avogadro value: {Constants.AVOGADRO_NUMBER_POWER}\n");

        // Static -> can be different each run
        Console.WriteLine($"Time now: {Constants.timeNow}");
        Console.WriteLine($"Random Value: {Constants.RandomSeed}");
        Console.WriteLine($"Area of Circle with radius of {radius} is {Constants.FindAreaOfCircle(radius)}");

        // Static readonly using PC and User Name
        Console.WriteLine($"Machine Name: {Constants.ComputerName}");
        Console.WriteLine($"User Name: {Constants.UserName}");
        Console.WriteLine("============================================================\n");

    }

}