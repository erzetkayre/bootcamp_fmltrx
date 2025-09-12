using System.Drawing;

// Point
Point2D p1 = new Point2D(10, 15);
Point2D p2 = p1;
Point2D p3 = p2;
p1.X = 30;
p2.Y = 50;

// Color
ReadOnlyColor c1 = new ReadOnlyColor(255, 0, 0);

// Rectangle
Rectangle r1 = new Rectangle(new Point2D(2,3), 10, 5);

Console.WriteLine("============ Object Mini Project ============");
Console.WriteLine("========= Processing Point2D Struct =========");
Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine(p3);
Console.WriteLine();

Console.WriteLine("========== Processing Color Struct ==========");
Console.WriteLine(c1.ToHex());
Console.WriteLine(c1);
Console.WriteLine();

Console.WriteLine("======== Processing Rectangle Struct ========");
Console.WriteLine(r1);
Console.WriteLine($"Area of Rectangle is {r1.Area}");