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

    public Coordinate[] Endpoints => new []{new Coordinate(x1,y1),new Coordinate(x2,y2)};
}