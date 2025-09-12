using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class BoxedDataProcessor
{
    private object[] _dataStore;
    int position;

    public BoxedDataProcessor(int capacity)
    {
        _dataStore = new object[capacity];
    }

    public void AddData(object item)
    {
        if (item.GetType().IsValueType || item.GetType() == typeof(string))
            Console.WriteLine($"Boxing {item.GetType().Name}: {item}");

        _dataStore[position++] = item;
    }

    public void ProcessData(int index)
    {
        try
        {
            object item = _dataStore[index];
            Console.WriteLine($"Processing index.......\n index: {index}, value: {item}, data type: {item.GetType().Name}");

            if (item is int i)
            {
                int num = (int)item;
                Console.WriteLine($"Unboxing integer: {num}, square: {num * num}");
            }
            else if (item is string s)
            {
                Console.WriteLine($"Unboxing string with lenght: {s.Length}");
            }
            else if (item is bool b)
            {
                Console.WriteLine($"Boolean value:{b}, opposite: {!b}");
            }
            else if (item is double d)
            {
                double val = (double)item;
                int result = (int)val;
                Console.WriteLine($"Unboxing double: {val}, then numeric conversion to int:{result}");
            }
            else
            {
                Console.WriteLine($"Unknown type: {item.GetType().Name}, value: {item}");
            }

            Console.WriteLine();
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine($"InvalidCastException caught: {e.Message}");
        }
    }
    public void DisplayAllTypes()
    {
        for (int i = 0; i < _dataStore.Length; i++)
        {
            if (_dataStore != null)
            {
                Console.WriteLine($"Index {i} - Type: {_dataStore[i].GetType().Name} - Value: {_dataStore[i]}");
            }
        }
    }
}
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return $"Point ({X}, {Y})";
    }
}