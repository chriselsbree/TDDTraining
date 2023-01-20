using ApprovalTests;

namespace Triangles;

[TestClass]
public class TriangleTest
{
    [TestMethod]
    public void TriangleHasPoints()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(3, 4));
        Approvals.VerifyAll(
            $"Points on {triangle}", triangle.Points,"Coordinate");
    }

    [TestMethod]
    public void TriangleHasSides()
    {
        var triangle = new Triangle(new Coordinate(1, 1), new Coordinate(1, 4), new Coordinate(6, 1));
        Approvals.VerifyAll($"Sides of {triangle}", triangle.Sides, "Lines");
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
        var coordinate = new Coordinate(0, 0);
        var sides = triangle.FindSides(coordinate);
        Approvals.VerifyAll($"Sides containing endpoint {coordinate} for {triangle}", sides, "Side");
    }

    [TestMethod]
    public void PointOppositeSide()
    {
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(0, 4));
        var coordinate = new Coordinate(0, 0);
        var side = triangle.FindOppositeSide(coordinate);
        Approvals.Verify($"On the {triangle}\nthe side opposite to {coordinate}\nis {side}");
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
        Approvals.VerifyAll($"{triangle} has 3 angles", angles, a => $"Angle = {a:.00}");
    }

    [TestMethod]
    public void IsRightTriangle()
    {
        var triangle = CreateTriangle(0, 0, 0, 4, 4, 0);
        Assert.IsTrue(triangle.IsRightTriangle());
    }

    [TestMethod]
    public void IsNotRightTriangle()
    {
        var triangle = CreateTriangle(0, 0, 7, 0, 5, 3);
        Assert.IsFalse(triangle.IsRightTriangle());
    }

    private Triangle CreateTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        return new Triangle(new Coordinate(x1, y1), new Coordinate(x2, y2), new Coordinate(x3, y3));
    }
}