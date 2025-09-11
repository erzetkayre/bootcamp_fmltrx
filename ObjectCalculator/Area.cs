using System.Data;

namespace ObjectCalculator.AreaCalculator;

public class Area()
{
    public int Triangle(int a, int b)
    {
        int result = (a * b) / 2;
        return result;
    }
    public int Rectangle(int a, int b)
    {
        int result = a * b;
        return result;
    }
    public int Square(int a)
    {
        int result = a * a;
        return result;
    }
}