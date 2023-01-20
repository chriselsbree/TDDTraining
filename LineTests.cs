using System.Linq.Expressions;
using ApprovalTests;

namespace Triangles
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void TestVertical()
        {
            
            var line = new Line((1, 1), (1, 5));
            Assert.AreEqual(4,line.Length);

        }

        [TestMethod]
        public void TestHorizontal()
        {
            
            var line = new Line((5, 1), (8, 1));
            Assert.AreEqual(3, line.Length);

        }

        [TestMethod]
        public void TestDiagonal()
        {
            var line = new Line((0, 4), (3, 0));
            Assert.AreEqual(5, line.Length);
        }

        [TestMethod]
        public void TestLineWithEndpoints()
        {
            //Create a line with endpoints (1,5) and (6,5)
            //Verify that endpoints are (1,5) and (6,5)

            var line = new Line((1,5), (6,5));
            Approvals.VerifyAll("Endpoints", line.Endpoints,"Coordinate");

        }

        
       
    }
}