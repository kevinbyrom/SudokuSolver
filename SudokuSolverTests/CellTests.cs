using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace SudokuSolverTests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void Cell_Has_No_Final_Value()
        {
            var cell = new Cell();

            Assert.IsFalse(cell.HasFinal);
        }

        [TestMethod]
        public void Cell_Has_Final_Value()
        {
            var cell = new Cell();

            cell.RemovePossible(1);
            cell.RemovePossible(2);
            cell.RemovePossible(3);
            cell.RemovePossible(4);
            cell.RemovePossible(6);
            cell.RemovePossible(7);
            cell.RemovePossible(8);
            cell.RemovePossible(9);
            
            Assert.IsTrue(cell.HasFinal);
            Assert.AreEqual(cell.Final, 5);
        }

        [TestMethod]
        public void Cell_Remove_Possible()
        {
            var cell = new Cell(Position.Zero);

            Assert.AreEqual(cell.Possible.Length, 9);
            
            cell.RemovePossible(1);
            Assert.AreEqual(cell.Possible.Length, 8);

            cell.RemovePossible(1);
            Assert.AreEqual(cell.Possible.Length, 8);
        }
    }
}
