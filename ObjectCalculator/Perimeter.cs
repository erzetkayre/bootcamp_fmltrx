using System.IO.Pipelines;

namespace ObjectCalculator.PerimeterCalculator;

public class Perimeter()
{
    public int Triangle(int a, int b, int c)
    {
        int result = a + b + c;
        return result;
    }

    public int Rectangle(int a, int b)
    {
        int result = (a + b) * 2;
        return result;
    }

    public int Square(int a)
    {
        int result = 4 * a;
        return result;
    } 
}
