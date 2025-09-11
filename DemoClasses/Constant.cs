namespace Classes;

public static class Constants
{
    // data numeric
    public const double PI = 3.14159265358979323846;
    public const double E = 2.71828182845904523536;
    public const double SPEED_OF_LIGHT = 299792458;
    public const int AVOGADRO_NUMBER_POWER = 23;

    // data string
    public const string MATH_LIBRARY_VERSION = "1.0.0";
    public const string AUTHOR = "Muhammad Alif";

    // read only data system
    public static readonly DateTime timeNow = DateTime.Now;
    public static readonly string ComputerName = Environment.MachineName;
    public static readonly string UserName = Environment.UserName;
    public static readonly int RandomSeed = new Random().Next(100, 2000);

    public static double FindAreaOfCircle(double radius)
    {
        return PI * radius * radius;
    }


}