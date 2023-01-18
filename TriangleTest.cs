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
        //Create new triangle that has (0,0) (3,0) and (0,4)
        //find sides that touch (0,0)
        //Verify that sides a and b touch (0,0)
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(0, 4));
        var sides = triangle.FindSides(new Coordinate(0, 0));
        Approvals.VerifyAll("Sides", sides, "Side");
    }

    [TestMethod]
    public void PointOppositeSide()
    {
        //create a new triangle that has (0,0), (3,0), (0,4)
        //find the side that is opposite to the point (0,0)
        //verify that the point is opposite the side
        var triangle = new Triangle(new Coordinate(0, 0), new Coordinate(3, 0), new Coordinate(0, 4));
        var side = triangle.FindOppositeSide(new Coordinate(0, 0));
        Approvals.Verify(side);


    }
}