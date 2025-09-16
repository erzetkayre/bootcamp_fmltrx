using System.Drawing;
using Microsoft.VisualBasic;

public class Program
{
    static void Main()
    {
        Console.WriteLine("======================== Demo Enumerator ========================");
        BasicEnum();
        CollectionInitializer();
        DemoIterators();
    }

    static void BasicEnum()
    {
        Console.WriteLine("======================= Basic Enumerators =======================");
        string word = "bears";

        foreach (char c in word)
        {
            Console.WriteLine($"char: {c}");
        }
        Console.WriteLine();
    }

    static void CollectionInitializer()
    {
        Console.WriteLine("===================== Collection Initializer =====================");
        var colorCodes = new Dictionary<string, string>
        {
            {"red", "ff0000"},
            {"green", "00ff00"},
            {"blue", "0000ff"},
        };

        var moreColors = new Dictionary<string, string>
        {
            ["yellow"] = "ffff00",
            ["white"] = "ffffff",
            ["black"] = "000000",
        };

        var numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(3);
        numbers.Add(5);
        numbers.Add(7);

        foreach (var color in colorCodes)
            Console.WriteLine($"color name: {color.Key}, code: {color.Value}");
        Console.WriteLine();

        foreach (var moreColor in moreColors)
            Console.WriteLine($"color name: {moreColor.Key}, code: {moreColor.Value}");
        Console.WriteLine();

        foreach (var number in numbers)
            Console.WriteLine($"number {number}");
        Console.WriteLine();
    }

    static void DemoIterators()
    {
        Console.WriteLine("===================== Demo Iterators =====================");

        IEnumerable<int> Fibs(int fibCount)
        {
            for (int i = 0, prevFib = 1, curFib = 2; i < fibCount; i++)
            {
                yield return prevFib;
                int newFib = prevFib + curFib;
                prevFib = curFib;
                curFib = newFib;
            }
        }

        IEnumerable<int> Primes(int primeNum)
        {
            for (int i = 2; i <= primeNum; i++)
            {
                bool isPrime = true;
                for (int nums = 2; nums <= Math.Sqrt(i); nums++)
                {
                    if ((i % nums) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            if (isPrime) 
                yield return i;
            }
        }

        IEnumerable<int> Range (int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }

        IEnumerable<int> OddNumberOnly(IEnumerable<int> sequence)
        {
            foreach (int x in sequence)
            {
                if ((x % 2) == 1)
                    yield return x;
            }
        }

        IEnumerable<int> EvenNumberOnly(IEnumerable<int> sequence)
        {
            foreach (int i in sequence)
            {
                if ((i % 2) == 0)
                    yield return i;
            }
        }

        foreach (int fib in Fibs(6))
            Console.Write(fib + "   ");

        Console.WriteLine();

        foreach (int fib in OddNumberOnly(Fibs(6)))
            Console.Write(fib + "   ");

        Console.WriteLine();

        foreach (int fib in EvenNumberOnly(Fibs(6)))
            Console.Write(fib + "   ");

        Console.WriteLine();

        foreach (int prime in Primes(30))
            Console.Write(prime + "   ");

        Console.WriteLine();

        foreach (int n in Range(5,5))
            Console.Write(n + "   ");
    }
}