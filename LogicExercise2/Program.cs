// Logic Exercise Project
using System.Data;
using System.Runtime.CompilerServices;

Console.WriteLine("Input a number: ");

int number;
while (!int.TryParse(Console.ReadLine(), out number))
{
    Console.WriteLine("Only Number Input...");
}

var prints = new Dictionary<int, string> {
    {3, "foo"},
    {5, "bar"},
    { 7, "jazz"},
};

for (int i = 1; i <= number; i++)
{
    string result = "";
    foreach (var print in prints)
    {
        if (i % print.Key == 0)
            result += print.Value;
    }
    Console.Write(string.IsNullOrEmpty(result) ? i + "  " : result + "  ");
}