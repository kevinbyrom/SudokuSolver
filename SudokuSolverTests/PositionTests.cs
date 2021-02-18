using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace SudokuSolverTests
{
    [TestClass]
    public class PositionTests
    {

        [TestMethod]
        public void Positions_Are_Equal()
        {   
            var p1 = new Position(1, 1);         
            var p2 = new Position(1, 1);

            Assert.IsTrue(p1 == p2);
        }

        [TestMethod]
        public void Positions_Not_Equal()
        {   
            var p1 = new Position(1, 1);         
            var p2 = new Position(2, 1);

            Assert.IsTrue(p1 != p2);
        }


        [TestMethod]
        public void Position_At()
        {   
            var p1 = Position.At(1, 2);

            Assert.AreEqual(p1.X, 1);
            Assert.AreEqual(p1.Y, 2);
        }
    }
}
