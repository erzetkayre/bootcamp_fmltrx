using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        StringAndHandlingDemo();
        DateTimeDemo();
        FormattingAndParsingDemo();
        ConversionMechanismDemo();
        EnumsDemo();
    }

    #region String And Handling
    static void StringAndHandlingDemo()
    {
        Console.WriteLine("==================== 1. Demo String and Handling ====================");
        char c = 'A';
        char num = '4';
        char sym = '+';
        char newLine = '\n';
        string s = "Hello!!";

        Console.WriteLine(char.ToLower(c));
        Console.WriteLine(char.ToUpperInvariant('i'));
        Console.WriteLine($"Var num: {num} is digit was " + char.IsDigit(num));
        Console.WriteLine($"Var sym: {sym} is digit was " + char.IsSymbol(sym));
        Console.WriteLine("Var newLine:  is white space was " + char.IsWhiteSpace(newLine));

        Console.WriteLine(new string('*', 30));
        Console.WriteLine(new string(s[5], 30));

        foreach (char word in s)
            Console.Write(word + "   ");
        Console.WriteLine();

        Console.WriteLine(s.Insert(6, " World"));
        Console.WriteLine(s.Remove(6));
        Console.WriteLine(s.Substring(6));
        Console.WriteLine(s.Trim());

        StringBuilder sb = new StringBuilder("Helloooo");
        Console.WriteLine(sb.Append(" World!!"));

        string[] fruit = { "banana", "apple", "grape" };
        Console.WriteLine(string.Join(", ", fruit));
        Console.WriteLine();
    }
    #endregion

    #region DateTime
    static void DateTimeDemo()
    {
        Console.WriteLine("========================= 2. Demo DateTime =========================");
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(new TimeSpan(2, 30, 20));
        Console.WriteLine(TimeSpan.FromHours(2.9));
        Console.WriteLine();

        TimeSpan dur = TimeSpan.FromHours(2) + TimeSpan.FromMinutes(3);
        DateTime dt = DateTime.Now;
        DateTimeOffset dto = new DateTimeOffset(dt);

        Console.WriteLine(dur);
        Console.WriteLine($"Today's date in Indonesia: {dt}");
        Console.WriteLine($"Today's date in Malaysia: {dt.AddHours(1)}");
        Console.WriteLine($"Add Day: {dt.AddDays(2)}");
        Console.WriteLine($"Today's date with offset: {dto}");
        Console.WriteLine();

        Console.WriteLine($"Indonesia's independent day: {new DateOnly(1945, 8, 7)}");
        TimeOnly startWork = new TimeOnly(8, 0);
        TimeOnly endWork = new TimeOnly(17, 0);
        Console.WriteLine($"Work Hours: {endWork - startWork} with break time at {new TimeOnly(12)} until {new TimeOnly(13)}");
        Console.WriteLine();
    }
    #endregion

    #region Formatting and Parsing
    static void FormattingAndParsingDemo()
    {
        Console.WriteLine("==================== 3. Formatting and Parsing ====================");
        string s = true.ToString();
        bool b = bool.Parse(s);
        Console.WriteLine(b + " " + s);

        int.TryParse("12345678", out int i1);
        Console.WriteLine(i1);
        Console.WriteLine(double.Parse("12,345678"));
        Console.WriteLine(double.Parse("12.345678"));
        Console.WriteLine();

        NumberFormatInfo num = new NumberFormatInfo();
        num.CurrencySymbol = "$$";
        Console.WriteLine(3.ToString("C", num));
        Console.WriteLine();
    }
    #endregion

    #region Conversion Mechanism
    static void ConversionMechanismDemo()
    {
        Console.WriteLine("===================== 3. Conversion Mechanism =====================");
        double x = 4.9;
        double y = 4.2;
        double a = 3.5;
        double b = 6.5;

        Console.WriteLine($"Rounding double {x}: {Convert.ToInt32(x)}");
        Console.WriteLine($"Rounding double {y}: {Convert.ToInt32(y)}");
        Console.WriteLine($"Rounding double {a}: {Convert.ToInt32(a)}");
        Console.WriteLine($"Rounding double {b}: {Convert.ToInt32(b)}");
        Console.WriteLine();

        object source = "42";
        Console.WriteLine(Convert.ChangeType(source, typeof(int)));

        Half half = (Half)123.22134f;
        Console.WriteLine(half);
        Console.WriteLine();
    }
    #endregion

    #region Enums
    [Flags]
    enum Tools { pencil = 1, book = 2, ruler = 3, eraser = 4 }
    enum SecondTools { pencil, book, ruler, eraser }
    enum Size { large, medium, small }
    static void Display(Enum value)
    {
        Console.Write($"value: " + value.ToString() + " ");
        Console.Write($"type: " + value.GetType().Name);
        Console.WriteLine();
    }
    static void EnumsDemo()
    {
        Console.WriteLine("============================ 4. Enums ============================");
        Display(SecondTools.pencil);
        Display(Size.large);

        Tools tool = Tools.book | Tools.eraser;
        Size size = Size.large | Size.small;

        Console.WriteLine(tool);
        Console.WriteLine(size);
    }
    #endregion
}