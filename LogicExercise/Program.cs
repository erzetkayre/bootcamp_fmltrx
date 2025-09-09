// Logic Exercise Project
using System.Runtime.CompilerServices;

const int value = 30;

for (int i = 1; i <= value; i++)
{
    if ((i % 3) == 0)
        if ((i % 5) == 0)
            Console.WriteLine("foobar");
        else
            Console.WriteLine("foo");
    else if ((i % 5) == 0)
        if ((i % 3) == 0)
            Console.WriteLine("foobar");
        else
            Console.WriteLine("bar");
    else
        Console.WriteLine(i);
}


