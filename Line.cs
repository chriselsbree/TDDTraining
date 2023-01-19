namespace Triangles;

public class Line
{
    public Line((int, int) point1, (int, int) point2)
    {
        (x1, y1) = point1;
        (x2, y2) = point2;
    }

    public Line(Coordinate point1, Coordinate point2)
    {
        x1 = point1.X;
        y1 = point1.Y;

        x2 = point2.X;
        y2 = point2.Y;
    }

    public int x1 { get; set; }

    public int y2 { get; set; }
    public int y1 { get; set; }

    public int x2 { get; set; }

    public double Length
    {
        get
        {
            var y = (y2 - y1);
            var x = (x2 - x1);
            return Math.Sqrt(y*y + x*x);
        }
    }

    public override string ToString()
    {
        return $"({x1},{y1}) to ({x2},{y2})";
    }

    protected bool Equals(Line other)
    {
        return x1 == other.x1 && y2 == other.y2 && y1 == other.y1 && x2 == other.x2;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Line)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x1, y2, y1, x2);
    }

    public Coordinate[] Endpoints => new []{new Coordinate(x1,y1),new Coordinate(x2,y2)};
}