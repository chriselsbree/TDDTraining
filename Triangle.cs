using ApprovalTests.Core;

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

    public double[] Angles => Points.Select(GetAngleAt).ToArray();

    public IEnumerable<Line> FindSides(Coordinate coordinate)
    {
        return Sides.Where(s => s.Endpoints.Contains(coordinate));
    }

    public Line FindOppositeSide(Coordinate coordinate)
    {
        var findSides = FindSides(coordinate).ToArray();
        var oppositeSide = Sides.Except(findSides).ToArray();
        return oppositeSide.Single();
    }

    public double GetAngleAt(Coordinate coordinate)
    { 
        var a = FindSides(coordinate).First().Length;
        var b = FindSides(coordinate).Last().Length;
        var c = FindOppositeSide(coordinate).Length;

        return Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * 180 / Math.PI;
    }

    public bool IsRightTriangle()
    {
        //Check that any of the angles is 90 Deg
        return Angles.Any(a => IsAlmostEqual(a, 90, 0.001));
    }

    private bool IsAlmostEqual(double value1, double value2, double delta)
    {
        return Math.Abs(value1 - value2) <= delta;
    }

    public override string ToString()
    {
        return $"Triangle: {Points[0]}, {Points[1]}, {Points[2]}";
    }
}