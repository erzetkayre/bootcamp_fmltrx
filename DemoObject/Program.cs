// object menghimpun banyak data dengan berbagai type
// Menggunakan prinsip LIFO (Last in, First Out)
// Flexible untuk menghandle data dengan type data yang mixed

using System.Security.Cryptography.X509Certificates;

public class Stack
{
    int position;
    object[] data = new object[10];

    public void Push(object obj)
    {
        data[position++] = obj;
    }

    public object Pop()
    {
        return data[--position];
    }
}
public class Point
{
    public int X, A;
    public string Y = "";
    public bool T = true;
    public object[] B = new object[10];

    public override string ToString() => Y;
}

public class Program
{
    static void Main()
    {
        Stack stack = new Stack();

        stack.Push("sausage");
        string @string = (string)stack.Pop();
        Console.WriteLine($"String in object: {@string}");

        stack.Push(5646);
        int integer = (int)stack.Pop();
        Console.WriteLine($"Integer in object: {integer}");

        stack.Push(5646.1231);
        double @double = (double)stack.Pop();
        Console.WriteLine($"Double in object: {@double}");

        stack.Push(false);
        bool boolean = (bool)stack.Pop();
        Console.WriteLine($"Double in object: {boolean}");

        Console.WriteLine();

        int i = 3;
        object boxed = i;
        i = 5;
        Console.WriteLine($"Checking i as an integer: {i}, checking i as an object: {boxed}");

        Console.WriteLine();

        Point point = new Point() {Y = "Point Coffee"};
        Console.WriteLine("======== Demo GetType, typeof, and ToString ========");
        Console.WriteLine(point.GetType().Name);                                // runtime name type of point
        Console.WriteLine(typeof(Point).Name);                                  // compile-time type of Point
        Console.WriteLine(point.GetType().Name == typeof(Point).Name);          // checking if the name same or not
        Console.WriteLine(point.X.GetType().Name);                              // checking X type
        Console.WriteLine(point.Y.GetType().Name);                              // checking Y type
        Console.WriteLine(point.A.GetType().Name);                              // checking A type
        Console.WriteLine(point.B.GetType().Name);                              // checking B type
        Console.WriteLine(point.T.GetType().Name);                              // checking T type
        Console.WriteLine(point.Y.GetType().Name == point.X.GetType().Name);    // checking if X and Y in the same type
        Console.WriteLine(point.A.GetType().Name == point.X.GetType().Name);    // checking if X and Y in the same type
        Console.WriteLine($"Hasil override nilai Y menggunakan ToString: {point}");    

    }
}