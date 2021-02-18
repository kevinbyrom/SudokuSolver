using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace SudokuSolverTests
{
    [TestClass]
    public class BoardTests
    {



        [TestMethod]
        public void Board_Get_Rows()
        {
            var board = new Board();


            // Top left

            var topleft = board.GetRow(new Position(0, 0)).ToArray();

            Assert.AreEqual(topleft.Length, 9);
            Assert.IsTrue(topleft[0].Position == Position.At(0, 0));
            Assert.IsTrue(topleft[8].Position == Position.At(8, 0));


            // Middle

            var mid = board.GetRow(new Position(4, 4)).ToArray();

            Assert.AreEqual(mid.Length, 9);
            Assert.IsTrue(mid[0].Position == Position.At(0, 4));
            Assert.IsTrue(mid[8].Position == Position.At(8, 4));


            // Bottom right

            var botright = board.GetRow(new Position(8, 8)).ToArray();

            Assert.AreEqual(botright.Length, 9);
            Assert.IsTrue(botright[0].Position == Position.At(0, 8));
            Assert.IsTrue(botright[8].Position == Position.At(8, 8));
        }


        [TestMethod]
        public void Board_Get_Columns()
        {
            var board = new Board();


            // Top left

            var topleft = board.GetColumn(new Position(0, 0)).ToArray();

            Assert.AreEqual(topleft.Length, 9);
            Assert.IsTrue(topleft[0].Position == Position.At(0, 0));
            Assert.IsTrue(topleft[8].Position == Position.At(0, 8));


            // Middle

            var mid = board.GetColumn(new Position(4, 4)).ToArray();

            Assert.AreEqual(mid.Length, 9);
            Assert.IsTrue(mid[0].Position == Position.At(4, 0));
            Assert.IsTrue(mid[8].Position == Position.At(4, 8));


            // Bottom right

            var botright = board.GetColumn(new Position(8, 8)).ToArray();

            Assert.AreEqual(botright.Length, 9);
            Assert.IsTrue(botright[0].Position == Position.At(8, 0));
            Assert.IsTrue(botright[8].Position == Position.At(8, 8));
        }


        [TestMethod]
        public void Board_Get_Grids()
        {
            var board = new Board();


            // Top left

            var topleft = board.GetGrid(new Position(0, 0)).ToArray();

            Assert.AreEqual(topleft.Length, 9);
            Assert.IsTrue(topleft[0].Position == Position.At(0, 0));
            Assert.IsTrue(topleft[8].Position == Position.At(2, 2));


            // Middle

            var mid = board.GetGrid(new Position(3, 0)).ToArray();

            Assert.AreEqual(mid.Length, 9);
            Assert.IsTrue(mid[0].Position == Position.At(3, 0));
            Assert.IsTrue(mid[8].Position == Position.At(5, 2));


            // Bottom right

            var botright = board.GetGrid(new Position(8, 8)).ToArray();

            Assert.AreEqual(botright.Length, 9);
            Assert.IsTrue(botright[0].Position == Position.At(6, 6));
            Assert.IsTrue(botright[8].Position == Position.At(8, 8));
        }


        [TestMethod]
        public void Board_Not_Solved()
        {
            var board = new Board();

            Assert.IsTrue(!board.IsSolved());
        }


        [TestMethod]
        public void Board_Solved()
        {
            var cells = new int[] {
                8, 7, 2, 1, 5, 9, 6, 4, 3,
                6, 4, 3, 7, 8, 2, 9, 5, 1,
                1, 9, 5, 4, 3, 6, 7, 2, 8,
                4, 6, 8, 5, 9, 7, 1, 3, 2,
                9, 2, 1, 6, 4, 3, 5, 8, 7,
                5, 3, 7, 8, 2, 1, 4, 9, 6,
                7, 8, 9, 2, 6, 4, 3, 1, 5,
                2, 1, 4, 3, 7, 5, 8, 6, 9,
                3, 5, 6, 9, 1, 8, 2, 7, 4};

            var board = Board.FromArray(cells);

            Assert.IsTrue(board.IsSolved());
        }


        [TestMethod]
        public void Board_FromArray()
        {
            var cells = new int[] {
                1, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 2, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 3, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 4, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 5, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 6, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 7, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 8, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 9 };

            var board = Board.FromArray(cells);

            Assert.AreEqual(1, board.Cells[0,0].Final);
            Assert.AreEqual(4, board.Cells[3,3].Final);
            Assert.AreEqual(9, board.Cells[8,8].Final);
        }
    }
}
