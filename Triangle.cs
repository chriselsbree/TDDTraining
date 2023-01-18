namespace Triangles;

public class Triangle
{
    public Triangle(Coordinate first, Coordinate second, Coordinate third)
    {
        Points = new[] { first, second, third };
    }

    public Coordinate[] Points { get; }

    public IEnumerable<Line> Sides
    {
        get
        {
            return new Line[] { new Line(Points[0], Points[1]), 
                new Line(Points[1], Points[2]), 
                new Line(Points[2], Points[0])};
        }
    }

    public double Perimeter
    {
        get
        {
            return Sides.Sum(l => l.Length);
        }
    }

    public IEnumerable<Line> FindSides(Coordinate coordinate)
    {
        //Get sides where the start or end is at (0,0)
        return Sides.Where(s => s.Endpoints.Contains(coordinate));
    }
}