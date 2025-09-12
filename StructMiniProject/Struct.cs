using System.Security.Cryptography.X509Certificates;

// Point Case
public struct Point2D
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Translate(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    public override string ToString()
    {
        return $"Point2D({X},{Y})";
    }
}

// Color Case
public readonly struct ReadOnlyColor
{
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;

    public static readonly ReadOnlyColor RED = new ReadOnlyColor(255, 0, 0);
    public static readonly ReadOnlyColor BLUE = new ReadOnlyColor(0, 0, 255);

    public ReadOnlyColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
    public readonly string ToHex()
    {
        return $"Color({R:X2}{G:X2}{B:X2})";
    }

    public override string ToString()
    {
        return $"Color(R:{R}, G:{G}, B:{B})";
    }
}

// Retangle Case
public struct Rectangle
{
    public Point2D TopLeft;
    public int Width;
    public int Height;

    public Rectangle(Point2D topLeft, int width, int height)
    {
        TopLeft = topLeft;
        Width = width;
        Height = height;
    }

    public readonly int Area => Width * Height;
    public override string ToString()
    {
        return $"Rectangle {TopLeft}, Width: {Width}, Height: {Height}, Area: {Area}";
    }
}