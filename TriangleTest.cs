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
        var triangle = new Triangle(new Coordinate(1, 1), new Coordinate(5, 1), new Coordinate(1, 4));
        Assert.AreEqual(12,triangle.Perimeter);
    }

    [TestMethod]
    public void PointHasSides()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(0, 4));
        var sides = triangle.FindSides(new Coordinate(0, 0));
        Approvals.VerifyAll("Sides", sides, "Side");
    }

    [TestMethod]
    public void PointOppositeSide()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(0, 4));
        var side = triangle.FindOppositeSide(new Coordinate(0, 0));
        Approvals.Verify(side);
    }

    [TestMethod] 
    public void CornerHasAngle()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(0, 3), new Coordinate(4, 0));
        double angle = triangle.GetAngleAt(new Coordinate(0, 0));
        Assert.AreEqual(90,angle);
        
    }

    [TestMethod]
    public void TriangleHasThreeAngles()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(0, 4), new Coordinate(4, 0));
        var angles = triangle.Angles;
        Approvals.VerifyAll("Angles", angles, "Angle");

    }

    [TestMethod]
    public void IsRightTriangle()
    {
        // Create a triangle with coordinates (0,0), (0,4), and (4,0)
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(0, 4), new Coordinate(4, 0));

        // Verify it is a right triangle
        Assert.IsTrue(triangle.IsRightTriangle());
    }

    [TestMethod]
    public void IsNotRightTriangle()
    {
        //Create triangle (0,0) (7,0) (5,3)
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(7, 0), new Coordinate(5, 3));
        Assert.IsFalse(triangle.IsRightTriangle());
        //Verify it is not a right triangle
    }
}