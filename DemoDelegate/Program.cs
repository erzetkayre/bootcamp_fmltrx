// Demo Delegate

using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;


class Program
{
    delegate string StringDelegate(string message);
    delegate void VoidDelegate();
    delegate int NumberDelegate(int a, int b);
    delegate void ProgressReport(int percentComplete);
    static void Main()
    {
        Console.WriteLine("==================== Demo Delegate ====================");
        DemoVoidDelegate();
        DemoIntDelegate();
        DemoStringDelegate();
        DemoMulticastDelegate();
    }

    // Demo string degelate
    static void DemoStringDelegate()
    {
        static string PrintMessage(string s)
        {
            string msg = s;
            return $"Demo string delegate result: {msg}";
        }

        static void TryAction(string a, int b)
        {
            Console.WriteLine($"string: {a}, int: {b}");
        }

        Action<string, int> act = TryAction;
        StringDelegate sd = PrintMessage;
        Console.WriteLine(sd("Check!"));
        Console.WriteLine(sd("Check - 3!"));
        Console.WriteLine(sd("Check - 2!"));
        Console.WriteLine(sd("Check - 1!"));
        Console.WriteLine();
        Console.WriteLine("Using Action!");
        act.Invoke("null", 0);
        act.Invoke("s for string", 10);
        Console.WriteLine();
    }

    // Demo void degelate
    static void DemoVoidDelegate()
    {
        static void PrintVoid1() { Console.WriteLine("Void one!"); }
        static void PrintVoid2() { Console.WriteLine("Void two!"); }

        VoidDelegate vd = PrintVoid1;
        vd += PrintVoid2;
        vd += PrintVoid2;
        vd -= PrintVoid1;

        vd();
        Console.WriteLine();
    }

    // Demo integer degelate
    static void DemoIntDelegate()
    {
        Calculator calc = new Calculator();
        NumberDelegate add = calc.Add;
        NumberDelegate sub = calc.Subtract;
        NumberDelegate mult = calc.Multiply;
        NumberDelegate div = calc.Division;

        Func<int, int, int> funcAdd = calc.Add;
        Func<int, int, int> funcSub = calc.Subtract;
        Func<int, int, int> funcMult = calc.Multiply;
        Func<int, int, int> funcDiv = calc.Division;

        Console.WriteLine("Without Func");
        Console.WriteLine($"Add result: {add(10, 20)}");
        Console.WriteLine($"Subtract result: {sub(10, 20)}");
        Console.WriteLine($"Multiply result: {mult(10, 20)}");
        Console.WriteLine($"Division result: {div(10, 20)}");
        Console.WriteLine();

        Console.WriteLine("Using Func");
        Console.WriteLine($"Add result: {funcAdd.Invoke(4,4)}");
        Console.WriteLine($"Add result: {funcSub.Invoke(4,4)}");
        Console.WriteLine($"Add result: {funcMult.Invoke(4,4)}");
        Console.WriteLine($"Add result: {funcDiv.Invoke(4,4)}");
        Console.WriteLine();        
    }
    class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Division(int a, int b) => a / b;
    }

    // Demo multicast delegate
    static void DemoMulticastDelegate()
    {
        static void Hadwork(ProgressReport p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10);
                System.Threading.Thread.Sleep(100);
            }
        }

        void WriteProgressToConsole(int percentComplete) { Console.WriteLine($"Console: {percentComplete}%  "); }
        void WriteProgressToFile(int percentComplete) { File.WriteAllText("progress.txt", percentComplete.ToString()); }

        ProgressReport p = WriteProgressToConsole;
        p += WriteProgressToFile;

        Hadwork(p);
    }

}