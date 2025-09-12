using System.Drawing;

public class Program
{
    static void Main()
    {
        Console.WriteLine("============ Object Mini Project ============");

        var processor = new BoxedDataProcessor(6);
        var point = new Point(3,5);

        Console.WriteLine("================ Adding Data ================");
        processor.AddData(30);
        processor.AddData("DemoProject");
        processor.AddData(40.324);
        processor.AddData(true);
        processor.AddData("Demo");
        processor.AddData(20);
        Console.WriteLine($"Override result from X and Y: {point}");

        Console.WriteLine();

        Console.WriteLine("========== Processing Data by Index =========");
        processor.ProcessData(0);
        processor.ProcessData(1);
        processor.ProcessData(2);
        processor.ProcessData(3);
        processor.ProcessData(4);
        processor.ProcessData(5);
        
        Console.WriteLine();

        Console.WriteLine("==== Print all the item and the data type ====");
        processor.DisplayAllTypes();
    }
}