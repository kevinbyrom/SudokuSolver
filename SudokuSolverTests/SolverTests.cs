using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace SudokuSolverTests
{
    [TestClass]
    public class SolverTests
    {


        [TestMethod]
        public void Solver_Solve()
        {
            var cells = new int[] {
                0, 7, 0, 1, 5, 0, 6, 4, 3,
                0, 0, 3, 7, 8, 2, 9, 0, 0,
                1, 0, 0, 0, 3, 0, 7, 0, 0,
                0, 6, 0, 0, 9, 0, 1, 3, 2,
                0, 0, 0, 6, 4, 3, 0, 0, 0,
                5, 3, 7, 0, 2, 0, 0, 9, 0,
                0, 0, 9, 0, 6, 0, 0, 0, 5,
                0, 0, 4, 3, 7, 5, 8, 0, 0,
                3, 5, 6, 0, 1, 8, 0, 7, 0};

            var board = Board.FromArray(cells);
           
            var solver = new Solver();

            //var solution = solver.Solve(board);

            //Assert.IsTrue(solution.Board.IsSolved());
        }
    }
}
