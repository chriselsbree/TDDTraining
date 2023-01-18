using ApprovalTests;

namespace Triangles;

[TestClass]
public class TriangleTest
{
    [TestMethod]
    public void TriangleHasPoints()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(3, 4));
        Approvals.VerifyAll("Points", triangle.Points,"Coordinate");
    }

    [TestMethod]
    public void TriangleHasSides()
    {
        var triangle = new Triangle(new Coordinate(1, 1), new Coordinate(1, 4), new Coordinate(6, 1));
        Approvals.VerifyAll("Sides", triangle.Sides, "Lines");
    }

    [TestMethod]
    public void TriangleHasPerimeter()
    {
        //Create triangle with points (1,1) , (5,1) and (1,4)
        var triangle = new Triangle(new Coordinate(1, 1), new Coordinate(5, 1), new Coordinate(1, 4));

        //Verify triagngle has perimeter of 12
        Assert.AreEqual(12,triangle.Perimeter);
    }
}

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
}