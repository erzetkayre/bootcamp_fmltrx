Console.WriteLine("Input a number: ");

int number;
while (!int.TryParse(Console.ReadLine(), out number))
{
    Console.WriteLine("Only Number Input...");
}

var words = new Dictionary<int, string>
{
    {3, "foo"},
    {4, "baz"},
    {5, "bar"},
    {7, "jazz"},
    {9, "huzz"},
};

for (int i = 1; i <= number; i++)
{
    string result = "";
    foreach (var word in words)
    {
        if (i % word.Key == 0)
        {
            result += word.Value;
        }
    }
    Console.Write(string.IsNullOrEmpty(result) ? i + "  " : result + "  ");
}
