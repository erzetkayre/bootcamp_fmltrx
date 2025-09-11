// See https://aka.ms/new-console-template for more information
using System.IO.Pipelines;


char[] vowels = ['a', 'b', 'c', 'd'];
int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
string[] phones = ["samsung", "iphone", "xiaomi", "asus", "oppo", "vivo"];

Console.WriteLine(vowels[0]);
Console.WriteLine(numbers[^3]);
Console.WriteLine(phones[5]);


string phoness = "oppo";
for (int i = 0; i < phones.Length; i++)
{
    if (phones[i] == phoness)
    {
        Console.WriteLine($"Found {phoness} at index {i}");
        break;
    }
}

foreach (string phone in phones)
{
    Console.WriteLine($"Read {phone}");
}

int[] number = new int[7];
number[0] = 0;
number[1] = 1;
number[5] = 1;

for (int i = 2; i < number.Length; i++)
{
    number[i] = number[i - 1] + number[i - 2];
}

foreach (int x in number)
{
    Console.WriteLine($"Read {x}");
}
